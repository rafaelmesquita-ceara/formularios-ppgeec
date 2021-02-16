using System;
using Formularios_bia.Models.Enums;
using Formularios_bia.Models.Shared;

namespace Formularios_bia.Models
{
  public class Article : Base
  {
    public Article()
    {

    }
    public Article(EArticleType type, string description, int associatedProjectId, Project associatedProject, bool q1, bool q2, EAssociatedProgram associatedProgram, int formId)
    {
      Type = type;
      Description = description;
      AssociatedProjectId = associatedProjectId;
      AssociatedProject = associatedProject;
      Q1 = q1;
      Q2 = q2;
      AssociatedProgram = associatedProgram;
      FormId = formId;
    }

    public EArticleType Type { get; set; }
    public string Description { get; set; }
    public int AssociatedProjectId { get; set; }
    public Project AssociatedProject { get; set; }
    public bool Q1 { get; set; }
    public bool Q2 { get; set; }
    public EAssociatedProgram AssociatedProgram { get; set; }
    public int FormId { get; set; }

    public void ShowArticleInfo()
    {
      Console.WriteLine($"Type: {Type}");
      Console.WriteLine($"Description: {Description}");
      Console.WriteLine($"Associated Project: ");
      AssociatedProject.ShowProjectInfo();
      Console.WriteLine($"Q1 : {Q1}");
      Console.WriteLine($"Q2 : {Q2}");
      Console.WriteLine($"Associated Program : {AssociatedProgram}");
    }
  }
}