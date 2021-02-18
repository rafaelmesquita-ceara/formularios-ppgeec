using System;
using System.ComponentModel.DataAnnotations;
using Formularios_bia.Models.Shared;

namespace Formularios_bia.Models
{
  public class TextAsk : Base
  {
    public TextAsk()
    {
        
    }
    public TextAsk(string text, string value, int formId)
    {
      Text = text;
      Value = value;
      FormId = formId;
    }

    public string Text { get; set; }

    [Required(ErrorMessage = "Preencha todos os campos obrigatórios!")]
    public string Value { get; set; }
    public int FormId { get; set; }
    public void ShowTextAskInfo()
    {
      Console.WriteLine($"Text: {Text}");
      Console.WriteLine($"Value: {Value}");
    }
  }
}