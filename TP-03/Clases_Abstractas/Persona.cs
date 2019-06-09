using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{

    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = Persona.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Retorna el atributo dni.
        /// Valida que dicho dni sea valido.En caso contrario arrojara excepciones.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                try
                {
                    this.dni = Persona.ValidarDni(this.Nacionalidad, value.ToString());
                }
                catch(NacionalidadInvalidaException)
                {

                }
                catch(DniInvalidoException)
                {

                }
                catch(Exception)
                {

                }
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Retorna el atributo nombre.
        /// Valida que dicho atributo sea valido.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = Persona.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Retorna el dni en forma de string.
        /// Valida que dicho atributo sea valido. En caso contrario arrojara excepcion.
        /// </summary>
        public string StringToDNI
        {
            get
            {
                return this.dni.ToString();
            }
            set
            {
                try
                {
                    this.dni = Persona.ValidarDni(this.Nacionalidad,value);
                }
                catch (NacionalidadInvalidaException)
                {

                }
                catch (DniInvalidoException)
                {

                }
                catch (Exception)
                {

                }

            }
        }

        #endregion

        #region Metodos
        public Persona()
            :this("","","",ENacionalidad.Argentino)
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            :this(nombre,apellido,"-1",nacionalidad)
        {
            
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,dni.ToString(),nacionalidad)
        {

        }

        /// <summary>
        /// Inicializa todos los datos de la clase y verifica que cuyos datos cuenten con las reglas impuestas.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.StringToDNI = dni;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Sobreescritura del metodo ToString. Retornara todos los datos de la persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO:" + this.apellido + this.nombre);
            sb.AppendLine("NACIONALIDAD: " + this.nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Valida si la persona es argentina tengo el dni correctamente y si es extranjero tambien
        /// Retornara el dni si este es correcto, en caso de no arrojara la Excepcion NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad , int dato)
        {
            int rDni = 0;
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                rDni = dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                rDni = dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }

            return rDni;
        }

        /// <summary>
        /// Valida si el dni son numero y no tiene caracteres ajenos.
        /// Arrojara una excepcion si este no es valido "DniInvalidoException".Y retornara dicho dni.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int rDni = -1;
            for(int i =0;i<dato.Length;i++)
            {
                if(!char.IsDigit(dato[i]))
                {
                    throw new DniInvalidoException();
                }
            }

            rDni = Persona.ValidarDni(nacionalidad, int.Parse(dato));

            return rDni;
        }

        /// <summary>
        /// Valida que un string solo tenga caracteres.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static string ValidarNombreApellido(string dato)
        {
            for(int i = 0;i<dato.Length;i++)
            {
                if(!char.IsLetter(dato[i]))
                {
                    return "";
                }
            }

            return dato;
        }


        #endregion
    }
}
