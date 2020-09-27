using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing.Models
{
    public class CortosViewModel
    {
        public string NombreCategoria { get; set; }
        public IEnumerable<Models.Cortometraje> Cortometraje { get; set; }
    }
}
