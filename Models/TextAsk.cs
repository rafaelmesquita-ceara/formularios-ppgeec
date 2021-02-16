using System;
using Formularios_bia.Models.Shared;

namespace Formularios_bia.Models
{
  public class TextAsk : Base
  {
    public TextAsk(string text, string value, int formId)
    {
      Text = text;
      Value = value;
      FormId = formId;
    }

    public string Text { get; set; }
    public string Value { get; set; }
    public int FormId { get; set; }
    public void ShowTextAskInfo()
    {
      Console.WriteLine($"Text: {Text}");
      Console.WriteLine($"Value: {Value}");
    }
  }
}