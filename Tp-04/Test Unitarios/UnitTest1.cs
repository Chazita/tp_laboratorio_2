using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPaqueteDeCorreoNULL()
        {
            Correo correoTest = new Correo();

            bool verificacion = false;

            try
            {
                Assert.IsNotNull(correoTest);
                verificacion = true;
            }
            catch(Exception)
            {

            }

            Assert.IsTrue(verificacion);
        }

        [TestMethod]
        public void TestPaquetesTrackingID()
        {
            Correo correTest = new Correo();
            Paquete p1 = new Paquete("Alguna Calle", "123");
            Paquete p2 = new Paquete("Alguna Calle", "123");

            bool verificacion = false;
            
            try
            {
                correTest += p1;
                correTest += p2;
            }
            catch(TrackingIdRepetidoException)
            {
                verificacion = true;
            }

            Assert.IsTrue(verificacion);
        }
    }
}
