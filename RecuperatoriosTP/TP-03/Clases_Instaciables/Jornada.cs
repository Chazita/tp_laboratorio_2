using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instaciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Profesor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa la clase y el instructor.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Guarda los datos de la jornada en un archivo.txt
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTxt = new Texto();
            return archivoTxt.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee el archivo .txt y los devuelve en string.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string rto = "";
            Texto txt = new Texto();
            txt.Leer("Jornada.txt",out rto);

            return rto;
        }

        /// <summary>
        /// Compara si la clase de la jornada es igual a la clase del alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.Clase;
        }

        /// <summary>
        /// Compara si la clase de la joranda es desigual a la clase del alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j==a);
        }

        /// <summary>
        /// Agrega al alumno si dicho participa en la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if (a == item)
                {
                    return j;
                }
            }
            j.alumnos.Add(a);
            return j;
        }

        /// <summary>
        /// Retorna todos los datos de la jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DE: " + clase.ToString() + " POR " + instructor.ToString() + "Alumnos: \n");
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        #endregion

    }
}
