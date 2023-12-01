using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLCRUD
{
    internal class Estudiante
    {
        public string Nombre { get; set; }

        public string Region { get; set; }

        public string Clase { get; set; }

        public string Seccion { get; set; }

        public Estudiante(string nombre, string region, string @clase, string seccion)
        {
            Nombre = nombre;
            Region = region;
            Clase = @clase;
            Seccion = seccion;
        }
    }
}
