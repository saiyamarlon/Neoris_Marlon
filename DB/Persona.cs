using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public int edad { get; set; }
        public string identificacion { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }
}
