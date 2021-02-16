using Microsoft.EntityFrameworkCore;
using Formularios_bia.Models;

namespace Formularios_bia.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Form> Forms { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<CheckBoxAsk> CheckBoxAsks { get; set; }
    public DbSet<TextAsk> TextAsks { get; set; }
    public DbSet<Article> Articles { get; set; }

  }
}