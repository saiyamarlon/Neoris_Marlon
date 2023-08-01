using DB;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly TestContext _testContext;
        public CuentaController(TestContext testContext)
        {
            _testContext = testContext;
        }
        // GET: api/<CuentaController>
        [HttpGet]
        public IEnumerable<Cuenta> Get()
        {
            return _testContext.cuentas.ToList();
        }

        // GET api/<CuentaController>/5
        [HttpGet("{id}")]
        public Cuenta Get(int id)
        {
            return _testContext.cuentas.FirstOrDefault(c=> c.id ==id);
        }

        // POST api/<CuentaController>
        [HttpPost]
        public void Post([FromBody] CuentaDTO value)
        {
            if(value != null)
            {
                if(!_testContext.cuentas.Any(c =>c.numero == value.numero))
                {
                    Cuenta cuenta = new Cuenta();
                    cuenta.numero = value.numero;
                    cuenta.saldo_inicial = value.saldo_inicial;
                    cuenta.estado = value.estado;
                    cuenta.Cliente.Persona.nombre = value.nombre;
                    cuenta.tipo_cuenta = value.tipo_cuenta;

                    _testContext.cuentas.Add(cuenta);
                    _testContext.SaveChanges();
                }
            }
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CuentaDTO value)
        {
            if (id > 0 && value != null)
            {
                var cuentExists = _testContext.cuentas.FirstOrDefault(p => p.id == id);
                if (cuentExists != null)
                {

                    cuentExists.numero = value.numero;
                    cuentExists.saldo_inicial = value.saldo_inicial;
                    cuentExists.estado = value.estado;
                    cuentExists.Cliente.Persona.nombre = value.nombre;
                    cuentExists.tipo_cuenta = value.tipo_cuenta;

                    _testContext.cuentas.Update(cuentExists);
                    _testContext.SaveChanges();
                }
            }
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id > 0)
            {
                var cuentExists = _testContext.cuentas.FirstOrDefault(p => p.id == id);
                if (cuentExists != null)
                {
                    _testContext.cuentas.Remove(cuentExists);
                    _testContext.SaveChanges();
                }

            }
        }
    }
}
