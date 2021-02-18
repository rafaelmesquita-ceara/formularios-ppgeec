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
  [Route("coleta-capes")]
  public class CapesController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public CapesController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    [Route("")]
    public IActionResult Index([FromServices] DataContext context)
    {
      return View();
    }

    [Route("error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
