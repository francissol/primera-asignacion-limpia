using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primeraasignacionlimpia.models
{
    public class Series
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Trailerurl { get; set; }

        public byte[] Imagen { get; set; }
        public string imagenbase64 { get; set; }
    }
}
