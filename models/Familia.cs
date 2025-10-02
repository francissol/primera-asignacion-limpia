using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primeraasignacionlimpia.models
{
   public class Familia
    {
        
        public string Nombre { get; set; }
        public string Parentezco { get; set; }

        public byte[] Foto { get; set; }
        public string Fotobase64 { get; set; }

    }
}
