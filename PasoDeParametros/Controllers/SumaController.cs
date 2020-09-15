using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PasoDeParametros.Controllers
{
    public class SumaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Resultado(int numero1, int numero2)
        {
            int res = numero1 + numero2;
            return View(res);
        }
        public IActionResult SolicitarNumeros()
        {
            return View();
        }
    }
}
