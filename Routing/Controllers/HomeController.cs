using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Routing.Models;

namespace Routing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Peliculas()
        {
            pixarContext context = new pixarContext();
            var peliculas = context.Pelicula.OrderBy(x => x.Nombre);
            return View(peliculas);
        }
        [Route("{id}")]
        public IActionResult InfoPeliculas(string id)
        {
            pixarContext context = new pixarContext();
            var nombre = id.Replace("-", " ").ToUpper();
            var peliculas = context.Pelicula.Include(x=>x.Apariciones).FirstOrDefault(x => x.Nombre.ToUpper()==nombre);
            var aparicion = context.Apariciones.Include(x => x.IdPersonajeNavigation)
                .Include(x => x.IdPeliculaNavigation).Where(x => (x.IdPelicula
                == peliculas.Id)).Select(x => x);
            if (peliculas == null)
            {
                return RedirectToAction("Peliculas");
            }
            else
            {
                PeliculasViewModel pvm = new PeliculasViewModel();
                pvm.Nombre = peliculas.Nombre;
                pvm.Id = peliculas.Id;
                pvm.NombreOriginal = peliculas.NombreOriginal;
                pvm.FechaEstreno = peliculas.FechaEstreno;
                pvm.Descripción = peliculas.Descripción;
                pvm.Apariciones = aparicion;
                return View(pvm); 
            }
        }
        public IActionResult Cortometrajes()
        {
            pixarContext context = new pixarContext();
            var categorias = context.Categoria.Include(x => x.Cortometraje).OrderBy(x=>x.Nombre).Select(x => new CortosViewModel {NombreCategoria=x.Nombre,
            Cortometraje=x.Cortometraje.OrderBy(x=>x.Nombre)});
            
            return View(categorias);
        }
        public IActionResult InfoCortos(string id)
        {
            pixarContext context = new pixarContext();
            var nombre = id.Replace("-", " ");
            var corto = context.Cortometraje.FirstOrDefault(x => x.Nombre.ToLower() == nombre);
            if (corto == null)
            {
                return RedirectToAction("Cortometrajes");
            }
            else
            {
                return View(corto);
            }
        }
    }
}
