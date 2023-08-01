using DB;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly TestContext _testContext;
        public MovimientoController(TestContext testContext)
        {
            _testContext = testContext;
        }
        // GET: MovimientoController
        [HttpGet]
        public IEnumerable<ListMovDTO> Get([FromBody] ParaMovList value)
        {
            return
                _testContext.movimientos
                .Where(m => m.fecha == value.fecha && m.Cuenta.Cliente.Persona.nombre == value.usuario)
                .Select(m => new ListMovDTO
                {
                    fecha = m.fecha,
                    cliente = m.Cuenta.Cliente.Persona.nombre,
                    numero = m.Cuenta.numero,
                    tipo = m.Cuenta.tipo_cuenta,
                    saldo = m.Cuenta.saldo_inicial,
                    estado = m.Cuenta.estado,
                    movimiento = m.saldo,
                    saldo_disponible = m.Cuenta.saldo_inicial
                }
                ).ToList() ?? new List<ListMovDTO>();
        }

        // GET: MovimientoController/Details/5
        [HttpPost]
        public void Post([FromBody] MovimientoDTO value)
        {
            if (value != null)
            {

                Movimiento movimiento = new Movimiento();
                movimiento.Cuenta.numero = value.numero;
                movimiento.Cuenta.tipo_cuenta = value.tipo_cuenta;
                movimiento.saldo = value.saldo_inicial;
                movimiento.Cuenta.estado = value.estado;
                movimiento.tipo_movimiento = value.tipo_movimiento;

                var saldo_actual =
                    _testContext.cuentas.FirstOrDefault(c => c.numero == value.numero)?.saldo_inicial ?? 0;

                if (saldo_actual>=0)
                    movimiento.Cuenta.saldo_inicial = saldo_actual - value.saldo_inicial;

                _testContext.movimientos.Add(movimiento);
                _testContext.SaveChanges();
            }
        }

        // GET: MovimientoController/Create
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MovimientoDTO value)
        {
            if (value != null)
            {
                var movimientoExist = _testContext.movimientos.FirstOrDefault(m => m.id == id);
                if (movimientoExist != null)
                {
                    Movimiento movimiento = new Movimiento();
                    movimiento.saldo = value.saldo_inicial;
                    movimiento.tipo_movimiento = value.tipo_movimiento;
                    movimiento.Cuenta.numero = value.numero;
                    movimiento.Cuenta.tipo_cuenta = value.tipo_cuenta;

                    _testContext.movimientos.Add(movimiento);
                    _testContext.SaveChanges();
                }
            }
        }

        // POST: MovimientoController/Create
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
                if(id > 0)
                {
                    var movimientoExists = _testContext.movimientos.FirstOrDefault(p => p.id == id);
                    if (movimientoExists != null)
                    {
                        _testContext.movimientos.Remove(movimientoExists);
                        _testContext.SaveChanges();
                    }
                }
        }

        
    }
}
