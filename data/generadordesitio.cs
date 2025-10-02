using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primeraasignacionlimpia.data
{
    public class ContactoGenerator
    {
        public static void GenerarContacto()
        {
            string plantilla4 = File.ReadAllText(
                @"C:\Users\franc\OneDrive\Escritorio\tecnologiadelinternet2\primeraasignacionlimpia\templantes\contacto.handlebars");

            var template4 = Handlebars.Compile(plantilla4);


            var html4 = template4(new { });

            Directory.CreateDirectory("output");
            File.WriteAllText("output/contacto.html", html4);

            Console.WriteLine("Archivo HTML generado en output/contacto.html");
        }
    }
}


