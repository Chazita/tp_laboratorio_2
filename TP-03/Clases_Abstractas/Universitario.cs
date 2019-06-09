using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Metodos

        public Universitario()
            :this(-1,"","","",ENacionalidad.Argentino)
        {

        }

        /// <summary>
        /// Inicializa legajo y llama al constructor padre.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo,string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Sobreescritura del metodo Equals. Comprueba que el parametro obj es Universitario , si lo es los compara.
        /// En el caso contrario llama al Equals de la  clase padre.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is Universitario)
            {
                return this == (Universitario)obj;
            }
            return base.Equals(obj);
        }

        /// <summary>
        /// Retorna todos los datos de la clase Universitario . Inclusive los datos derivados de la clase padre.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString()+"\nLEGAJO NUMERO: "+this.legajo.ToString()+"\n";
        }

        /// <summary>
        /// Compara 2 Universitario.Son iguales si dni o legajo son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1,  Universitario pg2)
        {

            return pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo;
        }

        /// <summary>
        /// Compara 2 Universitario. Son desiguales si dni o legajo no son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// No retorna nada todavia.
        /// </summary>
        /// <returns></returns>
        protected virtual string ParticiparEnClase()
        {
            return "";
        }
        
        #endregion
    }
}
