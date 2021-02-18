using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formularios_bia.Data;
using Formularios_bia.Models;
using Formularios_bia.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formularios_bia.Controllers.Api
{
  [Route("api/v1/projects")]
  public class ProjectController : Controller
  {
    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Project>> Post([FromServices] DataContext context, [FromBody] Project model)
    {
      try
      {
        context.Projects.Add(model);
        await context.SaveChangesAsync();
        return Ok(model);
      }
      catch (Exception)
      {
        return BadRequest(new { message = "Não foi possível cadastrar o projeto" });
      }
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<Project>> Get(
      [FromServices] DataContext context,
      [FromQuery(Name = "focus-area")] EPublicationFocusArea focusArea,
      [FromQuery(Name = "research-line")] EPublicationResearchLines researchLine
    )
    {
      if (focusArea == 0 && researchLine == 0)
      {
        var projects = await context.Projects.AsNoTracking().ToListAsync();
        return Ok(projects);
      }
      else
      {
        var projects = await context
           .Projects
           .Where(x => x.PublicationFocusArea == focusArea)
           .Where(x => x.PublicationResearchLines == researchLine)
           .AsNoTracking()
           .FirstOrDefaultAsync();
        return Ok(projects);
      }

    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Project>> Put(
      int id,
      [FromServices] DataContext context,
      [FromBody] Project model
    )
    {
      if (model.ID != id)
        return NotFound(new { message = "Projeto não encontrado" });

      try
      {
        context.Entry<Project>(model).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Ok(model);
      }
      catch (DbUpdateConcurrencyException)
      {
        return BadRequest(new { message = "Este registro já foi atualizado" });
      }
      catch (Exception)
      {
        return BadRequest(new { message = "Não foi possivel atualizar a categoria" });
      }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Project>> Delete(
      int id,
      [FromServices] DataContext context
    )
    {
      var project = await context.Projects.FirstOrDefaultAsync(x => x.ID == id);
      if (project == null)
        return NotFound(new { message = "Projeto não encontrado" });

      try
      {
        context.Projects.Remove(project);
        await context.SaveChangesAsync();
        return Ok(new { message = "Projeto removido com sucesso" });
      }
      catch (System.Exception)
      {
        return BadRequest(new { message = "Não foi possivel remover o projeto" });
      }
    }
  }
}