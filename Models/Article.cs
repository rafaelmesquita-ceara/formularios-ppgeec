using Formularios_bia.Models.Enums;

namespace Formularios_bia.Models
{
  public class Article
  {
    public int Id { get; set; }
    public EArticleType Type { get; set; }
    public string Description { get; set; }
    public int AssociatedProjectId { get; set; }
    public Project AssociatedProject { get; set; }
    public bool Q1 { get; set; }
    public bool Q2 { get; set; }
    public EAssociatedProgram AssociatedProgram { get; set; }
    public int FormId { get; set; }
  }
}