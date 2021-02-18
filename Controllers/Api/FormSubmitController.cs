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
  [Route("api/v1/formsubmit")]
  public class FormSubmitController : Controller
  {
    [HttpGet]
    [Route("")]
    [AllowAnonymous]
    public async Task<ActionResult<List<Form>>> Get([FromServices] DataContext context)
    {
      var forms = await context
        .Forms
        .Include(x => x.Articles)
        .Include(x => x.CheckBoxAsks)
        .Include(x => x.TextAsks)
        .AsNoTracking()
        .ToListAsync();

      var projects = await context.Projects.ToListAsync();
      foreach (var form in forms)
      {
        foreach (var article in form.Articles)
        {
          article.AssociatedProject = projects.FirstOrDefault(x => x.ID == article.AssociatedProjectId);
        }
      }
      return Ok(forms);
    }

    [HttpGet]
    [Route("{id:int}")]
    [AllowAnonymous]
    public async Task<ActionResult<Form>> GetById(
      int id,
      [FromServices] DataContext context
    )
    {
      var form = await context
        .Forms
        .Include(x => x.Articles)
        .Include(x => x.CheckBoxAsks)
        .Include(x => x.TextAsks)
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.ID == id);

      var projects = await context.Projects.ToListAsync();
      foreach (var article in form.Articles)
      {
        article.AssociatedProject = projects.FirstOrDefault(x => x.ID == article.AssociatedProjectId);
      }
      return Ok(form);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Form>> Post([FromServices] DataContext context, [FromBody] Form form)
    {
      if (ModelState.IsValid)
      {
        try
        {
          context.Forms.Add(form);
          await context.SaveChangesAsync();
          return Ok(form);
        }
        catch (Exception)
        {
          return BadRequest(new { message = "Não foi possível submeter os dados do formulário" });
        }
      }
      else
      {
        return BadRequest(ModelState);
      }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Form>> Delete(
      int id,
      [FromServices] DataContext context
    )
    {
      var form = await context.Forms.FirstOrDefaultAsync(x => x.ID == id);
      if (form == null)
        return NotFound(new { message = "Submissão não encontrada" });

      try
      {
        context.Forms.Remove(form);
        await context.SaveChangesAsync();
        return Ok(new { message = "Submissão removida com sucesso" });
      }
      catch (Exception)
      {
        return BadRequest(new { message = "Não foi possível remover a submissão" });
      }
    }
  }
}