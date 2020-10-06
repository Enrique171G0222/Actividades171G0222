using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Services.Controllers
{
    public class EspecieController : Controller
    {
        
        [Route("/Especie/{id}")]
        public IActionResult Index(string Id)
        {
            animalesContext context = new animalesContext();
            var nombre = Id.Replace("-", " ").ToLower();
            var especies = context.Especies.Where(x => x.IdClaseNavigation.Nombre.ToLower() == Id.ToLower()).OrderBy(x => x.Especie);
            if (especies==null)
            {
                return RedirectToAction("~/Home/Index");
            }
            else
            {
                return View(especies);
            }
        }
    }
}
