using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.Models
{
    public class PeliculasViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreOriginal { get; set; }
        public string Descripción { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public IEnumerable<Apariciones> Apariciones { get; set; }
    }
}
