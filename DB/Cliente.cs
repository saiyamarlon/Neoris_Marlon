using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string contrasena { get; set; }
        public bool estado { get; set; }
        public int persona_id { get; set; }
        [ForeignKey("persona_id")]
        public virtual Persona Persona { get; set; }

        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
}
