using System;
using System.ComponentModel.DataAnnotations;

namespace Formularios_bia.Models.Shared
{
  public class Base
  {
    [Key]
    public int ID { get; set; }
  }
}