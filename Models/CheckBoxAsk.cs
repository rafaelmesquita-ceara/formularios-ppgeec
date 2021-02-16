using System;
using Formularios_bia.Models.Shared;

namespace Formularios_bia.Models
{
  public class CheckBoxAsk : Base
  {
    public CheckBoxAsk(string text, bool value, int formId)
    {
      Text = text;
      Value = value;
      FormId = formId;
    }

    public string Text { get; set; }
    public bool Value { get; set; }
    public int FormId { get; set; }

    public void ShowCheckBoxAskInfo()
    {
      Console.WriteLine($"Text: {Text}");
      Console.WriteLine($"Value: {Value}");
    }
  }
}