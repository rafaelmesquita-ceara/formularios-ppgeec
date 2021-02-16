using System;
using System.Collections.Generic;
using Formularios_bia.Models.Shared;

namespace Formularios_bia.Models
{
  public class Form : Base
  {
    public Form()
    {
      Articles = new List<Article>();
      CheckBoxAsks = new List<CheckBoxAsk>();
      TextAsks = new List<TextAsk>();
    }
    public Form(string name)
    {
      Name = name;
      Articles = new List<Article>();
      CheckBoxAsks = new List<CheckBoxAsk>();
      TextAsks = new List<TextAsk>();
    }
    public string Name { get; set; }
    public IList<Article> Articles { get; set; }
    public IList<CheckBoxAsk> CheckBoxAsks { get; set; }
    public IList<TextAsk> TextAsks { get; set; }
    public DateTime SubmitDate => DateTime.Now;

    public void AddArticle(Article article) => Articles.Add(article);
    public void AddCheckBoxAsk(CheckBoxAsk checkBoxAsk) => CheckBoxAsks.Add(checkBoxAsk);
    public void AddTextAsk(TextAsk textAsk) => TextAsks.Add(textAsk);
    public void ShowFormInfo()
    {
      Console.WriteLine($"Name: {Name}");
      Console.WriteLine($"Submit Date: {SubmitDate.ToString("dd/MM/yyyy")}");
      Console.WriteLine("##############");
      Console.WriteLine("Articles: ");
      Console.WriteLine("##############");
      foreach (var article in Articles)
      {
        article.ShowArticleInfo();
      }
      Console.WriteLine("##############");
      Console.WriteLine("CheckBox Asks:");
      Console.WriteLine("##############");
      foreach (var checkBoxAsk in CheckBoxAsks)
      {
        checkBoxAsk.ShowCheckBoxAskInfo();
      }
      Console.WriteLine("##############");
      Console.WriteLine("Text Asks");
      Console.WriteLine("##############");
      foreach (var textAsk in TextAsks)
      {
        textAsk.ShowTextAskInfo();
      }
    }
  }
}