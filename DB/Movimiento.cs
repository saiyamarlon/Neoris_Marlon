using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Movimiento
    {

        public Movimiento()
        {
            this.fecha = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int cuenta_id { get; set; }
        public DateTime fecha { get; set; }
        public float saldo { get; set; }
        public string tipo_movimiento { get; set; }

        [ForeignKey("cuenta_id")]
        public virtual Cuenta Cuenta { get; set; }
    }
}
