using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace Clases_Instaciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Metodos
        public Profesor()
            :this(-1,"","","",ENacionalidad.Argentino)
        {

        }

        /// <summary>
        /// Se inicializa el atributo random.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }
        /// <summary>
        /// Se inicializan los atributos y se llama a la funcion _randomClase. Y llama al constructor padre.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }

        /// <summary>
        /// Retorna clases aleatorias.
        /// </summary>
        private void _randomClase()
        {
            for(int i =0;i<2;i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
            }
        }

        /// <summary>
        /// Muestra todos los datos del profer.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Compara profesor y clase. Es igual si el profesor da esa clase.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor p,Universidad.EClases clase)
        {
            bool rta = false;
            foreach (Universidad.EClases item in p.clasesDelDia)
            {
                if (item == clase)
                    rta = true;
            }
            return rta;
        }

        /// <summary>
        /// Compara profesor y clase. Son desiguales si ese profesor no da esa clase.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor p , Universidad.EClases clase)
        {
            return !(p == clase);
        }

        /// <summary>
        /// Retornara las clases que da el profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA: ");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString() ;
        }

        /// <summary>
        /// Llama al metodo MostrarDatos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion


    }
}
