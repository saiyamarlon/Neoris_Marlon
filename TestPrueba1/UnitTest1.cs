using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPrueba1
{
    [TestClass]
    public class UnitTest1
    {
       private static readonly  DbContextOptionsBuilder builder =
            new DbContextOptionsBuilder().UseSqlServer("Server=localhost\\Test;Database=Test;Trusted_Connection=True;MultipleActiveResultSets=true")
            ;

        

        [TestMethod]
        public void TestMethod1()
        {

            var builder1 = new DbContext( builder.Options);
            var cliente = new TestCliente();

            cliente.contrasena = "123";
            cliente.estado = true;
            cliente.Persona = new Persona()
            {
                nombre = "Pepe",
                genero = "Masculino",
                edad = 34,
                identificacion = "1234567",
                direccion = "pereira",
                telefono = "345678"

            };


            builder1.Add(cliente);
            var result_test = builder1.SaveChanges();
            Assert.AreEqual(result_test,1);
        }
    }
}
