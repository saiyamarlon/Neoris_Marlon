using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPrueba1
{
    public class TestCliente
    {
        public int id { get; set; }
        public string contrasena { get; set; }
        public bool estado { get; set; }
        public int persona_id { get; set; }
        public Persona Persona { get; set; }
    }
    public class Persona
    {
       
        public int id { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public int edad { get; set; }
        public string identificacion { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }
}
