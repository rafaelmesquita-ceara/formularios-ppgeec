using System.Threading.Tasks;
using Formularios_bia.Data;
using Formularios_bia.Models;
using Formularios_bia.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Formularios_bia.Controllers.Api
{
  [Route("api/v1")]
  public class SeedController : Controller
  {
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
    {
      // Add form
      var form = new Form("Rafael Mesquita Brito");
      context.Forms.Add(form);
      await context.SaveChangesAsync();

      // Add project
      var project = new Project(
          "Projeto Teste 01",
          "Iális Cavalcante",
          EPublicationFocusArea.InformationSystems,
          EPublicationResearchLines.DistributedProgrammingAlgorithms
        );
      context.Projects.Add(project);
      await context.SaveChangesAsync();

      var article = new Article(
          EArticleType.ArtigoDePeriodico,
          "Artigo teste 01",
          project.ID,
          project,
          true,
          true,
          EAssociatedProgram.PPGEEC,
          form.ID
        );
      context.Articles.Add(article);

      var checkBoxAsk1 = new CheckBoxAsk(
           "Você atuou em alguma Organização de Evento científico?",
           true,
           form.ID
        );
      var checkBoxAsk2 = new CheckBoxAsk(
          "Você atuou no Desenvolvimento de um Produto?",
          false,
          form.ID
        );
      context.CheckBoxAsks.Add(checkBoxAsk1);
      context.CheckBoxAsks.Add(checkBoxAsk2);

      var textAsk = new TextAsk(
          "Cite outras informações que você julgar relevantes, como exemplo: bolsista de produtividade, membro de sociedade científica, revisor de periódico, organizador de evento, membro de comitês científicos, etc.:",
          "Fui bolsista do BIA e sou programador",
          form.ID
        );
      context.TextAsks.Add(textAsk);

      await context.SaveChangesAsync();

      return Ok(
        new { message = "Dados configurados" }
      );
    }
  }
}