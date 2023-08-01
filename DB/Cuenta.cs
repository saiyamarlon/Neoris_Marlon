using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Cuenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int cliente_id { get; set; }
        public float saldo_inicial { get; set; }
        public bool estado { get; set; }
        public string numero { get; set; }
        public string tipo_cuenta {get; set;}

        [ForeignKey("cliente_id")]
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
