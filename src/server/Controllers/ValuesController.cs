using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
      public class FallbackController : Controller
  {
    public IActionResult Index()
    {
      return File("~/index.html", "text/html");
    }

    public IActionResult Test()
    {
      return Content("Passed");
    }
  }
}
