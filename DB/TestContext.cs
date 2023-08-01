using Microsoft.EntityFrameworkCore;
using System;

namespace DB
{
    public class TestContext :DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        public DbSet<Persona> personas { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Cuenta> cuentas { get; set; }
        public DbSet<Movimiento> movimientos { get; set; }
    }
}
