using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MovimientoDTO
    {
        public string numero { get; set; }
        public string tipo_cuenta { get; set; }
        public float saldo_inicial { get; set; }
        public bool estado { get; set; }
        public string tipo_movimiento { get; set; }

    }
}
