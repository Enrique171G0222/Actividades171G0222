using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Models;

namespace Services.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            animalesContext context = new animalesContext();
            var animales = context.Clase.OrderBy(x => x.Nombre);
            return View(animales);
        }
    }
}
