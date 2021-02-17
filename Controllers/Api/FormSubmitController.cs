using System.Collections.Generic;
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

      foreach (var form in forms)
      {
        foreach (var article in form.Articles)
        {
          article.AssociatedProject = await context
            .Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == article.AssociatedProjectId);
        }
      }

      return Ok(forms);
    }
  }
}