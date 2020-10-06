using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Models;

namespace Services.Services
{
    public class CategoriasService
    {
        public List<Clase> Clases { get; set; }
        public CategoriasService()
        {
            using (animalesContext context = new animalesContext()) {
                Clases = context.Clase.OrderBy(x => x.Nombre).ToList();
            }
                
        }
    }
}
