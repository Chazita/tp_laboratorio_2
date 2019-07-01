using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instaciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarNacionlidadDni()
        {
            bool error = false;
            try
            {
                Alumno a1 = new Alumno(1, "Jose", "Sand", "2", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch(NacionalidadInvalidaException)
            {
                error = true;
            }

            Assert.IsFalse(error);


            error = false;
            try
            {
                Alumno a1 = new Alumno(1, "Jose", "Sand", "2", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch(NacionalidadInvalidaException)
            {
                error = true;
            }

            Assert.IsTrue(error);
        }
    }
}
