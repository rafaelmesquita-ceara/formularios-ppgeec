using System.Collections.Generic;

namespace Formularios_bia.Models
{
  public class Form
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Article> Articles { get; set; }
    public IList<CheckBoxAsk> CheckBoxAsks { get; set; }
    public IList<TextAsk> TextAsks { get; set; }
  }
}