using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instaciables
{
    

    public class Universidad 
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

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

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }


        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion


        #region Metodos
        /// <summary>
        /// Inicializa las listas.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Guarda la variable en un archivo xml.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Lee el archivo guardado.
        /// </summary>
        /// <returns></returns>
        public Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad uni = new Universidad();
            xml.Leer("Universidad.xml", out uni);
            return uni;
        }

        /// <summary>
        /// Retorna todo el contenido de la variable en formato string.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<---------------------------------------------------------------------->");
            sb.AppendLine("JORNADA:");
            foreach (Jornada j in uni.Jornadas)
            {
                sb.AppendLine(j.ToString());
            }
            sb.AppendLine("<---------------------------------------------------------------------->");
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno a in uni.Alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            sb.AppendLine("<---------------------------------------------------------------------->");
            sb.AppendLine("PROFESOR:");
            foreach (Profesor p in uni.Instructores)
            {
                sb.AppendLine(p.ToString());
            }
            sb.AppendLine("<---------------------------------------------------------------------->");
            return sb.ToString();
        }

        /// <summary>
        /// Comprueba si el alumno esta en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.alumnos.Contains(a);
        }

        /// <summary>
        /// Comprubea si no esta el alumno en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compruba si el profesor da clases en esa universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.profesores.Contains(i);
        }

        /// <summary>
        /// Compruba si el profesor no da clases en esa universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Comprueba si hay un profesor para la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Instructores)
            {
                if (p == clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Comprueba si no hay un profesor para la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Instructores)
            {
                if (p != clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega una jornada y a sus alumnos.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);
            for(int i =0;i<g.alumnos.Count;i++)
            {
                if(g.alumnos[i]==clase)
                {
                    j += g.alumnos[i];
                }
            }
            g.jornada.Add(j);
            return g;
        }

        /// <summary>
        /// Agrega a un alumno que no este en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g != a)
            {
                g.alumnos.Add(a);
            }
            return g;
        }

        /// <summary>
        /// Agrega a un profesor que no este en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if(g != i)
            {
                g.profesores.Add(i);
            }
            return g;
        }

        /// <summary>
        /// Retorna todos los datos de la universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }


        #endregion

    }
}
