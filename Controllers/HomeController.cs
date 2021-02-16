using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Formularios_bia.Models;
using Formularios_bia.Data;

namespace Formularios_bia.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index([FromServices] DataContext context)
    {
      context.CheckBoxAsks.Add(new CheckBoxAsk("Teste", true, 1));
      context.CheckBoxAsks.Add(new CheckBoxAsk("Teste 2", false, 1));
      context.SaveChanges();
      foreach (var item in context.CheckBoxAsks)
      {
          item.ShowCheckBoxAskInfo();
      }

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
