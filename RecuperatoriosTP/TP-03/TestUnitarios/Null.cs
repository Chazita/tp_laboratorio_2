using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Clases_Instaciables;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class Null
    {
        [TestMethod]
        public void NullsAlumnos()
        {
            Alumno a1 = new Alumno(2, "Jose", "Sand", "12", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsNotNull(a1);

            Assert.IsNotNull(a1.Nombre);
            Assert.IsNotNull(a1.DNI);
            Assert.IsNotNull(a1.Apellido);
            Assert.IsNotNull(a1.Nacionalidad);
        }
    }
}
