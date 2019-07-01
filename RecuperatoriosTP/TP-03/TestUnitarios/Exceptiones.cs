using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instaciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class Exceptiones
    {
        [TestMethod]
        public void AlumnoRepetidoExpcetion()
        {
            bool error1 = false;
            try
            {
                Universidad uni = new Universidad();

                Alumno a1 = new Alumno(1, "Quico", "Ñubel", "15", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno a2 = new Alumno(2, "Jose", "Sand", "12", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

                uni += a1;
                uni += a2;
            }
            catch(AlumnoRepetidoException)
            {
                error1 = true;
            }
            Assert.IsFalse(error1);


            bool error2 = false;
            try
            {
                Universidad uni = new Universidad();

                Alumno a3 = new Alumno(3, "Jose", "Sand", "123", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

                uni += a3;
                uni += a3;
            }
            catch (AlumnoRepetidoException)
            {
                error2 = true;
            }
            Assert.IsTrue(error2);
        }

        [TestMethod]
        public void SinProfesorException()
        {
            bool error = false;

            try
            {
                Universidad uni = new Universidad();

                uni += Clases_Instaciables.Universidad.EClases.Laboratorio;
            }
            catch(SinProfesorException)
            {
                error = true;
            }

            Assert.IsTrue(error);
        }
    }
}
