using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formularios_bia.Data;
using Formularios_bia.Models;
using Formularios_bia.Models.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Formularios_bia
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //ModelTest();
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });

    /*static void ModelTest()
    {
      var form = new Form("Rafael Mesquita Brito");
      form.Id = 1;
      form.AddArticle(
        new Article(
          EArticleType.ArtigoDePeriodico,
          "Artigo teste 01",
          1,
          new Project(
              "Projeto Teste 01",
              "Iális Cavalcante",
              EPublicationFocusArea.InformationSystems,
              EPublicationResearchLines.DistributedProgrammingAlgorithms
          ),
          true,
          true,
          EAssociatedProgram.PPGEEC,
          form.Id
        )
      );
      form.AddCheckBoxAsk(
        new CheckBoxAsk(
            "Você atuou em alguma Organização de Evento científico?",
            true,
            form.Id
        )
      );
      form.AddCheckBoxAsk(
        new CheckBoxAsk(
          "Você atuou no Desenvolvimento de um Produto?",
          false,
          form.Id
        )
      );
      form.AddTextAsk(
        new TextAsk(
          "Cite outras informações que você julgar relevantes, como exemplo: bolsista de produtividade, membro de sociedade científica, revisor de periódico, organizador de evento, membro de comitês científicos, etc.:",
          "Fui bolsista do BIA e sou programador",
          form.Id
        )
      );
      form.ShowFormInfo();
    } */
  }
}
