using Formularios_bia.Models.Enums;

namespace Formularios_bia.Models
{
  public class Project
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Teacher { get; set; }
    public EPublicationFocusArea PublicationFocusArea { get; set; }
    public EPublicationResearchLines PublicationResearchLines { get; set; }
  }
}