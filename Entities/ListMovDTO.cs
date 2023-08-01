using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ListMovDTO
    {
        
        public DateTime fecha { get; set; }
        public string cliente { get; set; }
        public string numero { get; set; }
        public float saldo { get; set; }
        public bool estado { get; set; }
        public float movimiento { get; set; }
        public float saldo_disponible { get; set; }
        public string tipo { get; set; }

    }
}
