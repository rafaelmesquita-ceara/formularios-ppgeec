using System;
using System.ComponentModel.DataAnnotations;
using Formularios_bia.Models.Enums;
using Formularios_bia.Models.Shared;

namespace Formularios_bia.Models
{
  public class Project : Base
  {
    public Project(string title, string teacher, EPublicationFocusArea publicationFocusArea, EPublicationResearchLines publicationResearchLines)
    {
      Title = title;
      Teacher = teacher;
      PublicationFocusArea = publicationFocusArea;
      PublicationResearchLines = publicationResearchLines;
    }
    public Project()
    {
        
    }

    [Required(ErrorMessage = "Preencha todos os campos obrigatórios!")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Preencha todos os campos obrigatórios!")]
    public string Teacher { get; set; }
    public EPublicationFocusArea PublicationFocusArea { get; set; }
    public EPublicationResearchLines PublicationResearchLines { get; set; }
    public void ShowProjectInfo()
    {
      Console.WriteLine($"Title: {Title}");
      Console.WriteLine($"Teacher: {Teacher}");
      Console.WriteLine($"Publication focus area: {PublicationFocusArea}");
      Console.WriteLine($"Publication ResearchLines: {PublicationResearchLines}");
    }
  }
}