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
    public class ClienteController : ControllerBase
    {
        private readonly TestContext _testContext;
        public ClienteController(TestContext testContext)
        {
            _testContext = testContext;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _testContext.clientes.ToList();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public List<Cliente> Get(int id)
        {
            return _testContext.clientes.Where(p => p.id == id).ToList();
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] PersonaDTO value)
        {
            if(value != null)
            {
                if(!_testContext.personas.Any(p=> p.nombre == value.nombre))
                {
                    Cliente cliente = new Cliente();
                    cliente.Persona.nombre = value.nombre;
                    cliente.Persona.direccion = value.direccion;
                    cliente.Persona.telefono = value.telefono;
                    cliente.contrasena = value.constrasena;
                    cliente.estado = value.estado;

                    _testContext.clientes.Add(cliente);
                    _testContext.SaveChanges();

                }
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PersonaDTO value)
        {
            if(id > 0 && value != null) 
            {
                var clientExists = _testContext.clientes.FirstOrDefault(p => p.id == id);
                if(clientExists != null)
                {

                    clientExists.Persona.nombre = value.nombre;
                    clientExists.Persona.direccion = value.direccion;
                    clientExists.Persona.telefono = value.telefono;
                    clientExists.contrasena = value.constrasena;
                    clientExists.estado = value.estado;

                    _testContext.clientes.Update(clientExists);
                    _testContext.SaveChanges();
                }
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id > 0)
            {
                var clientExists =_testContext.clientes.FirstOrDefault(p => p.id == id);
                if(clientExists!= null)
                {
                    _testContext.clientes.Remove(clientExists);
                    _testContext.SaveChanges();
                }

            }
        }
    }
}
