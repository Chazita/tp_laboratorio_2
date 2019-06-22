using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributes
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion


        #region Propiedad
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion


        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Cierra todos los hilos.
        /// </summary>
        public void FinEntrega()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                item.Abort();
            }
        }


        /// <summary>
        /// Devuelve todos los datos de la lista en formato string.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string rto = "";
            if (!object.Equals(elemento, null))
            {
                foreach (Paquete p in ((Correo)elemento).Paquetes)
                {
                    rto += string.Format("{0} para {1} ({2})\r\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
                }
            }

            return rto;
        }

        /// <summary>
        /// Agrega un paquete en el correo. Arroja una excepcion TrackingIdRepetidoException.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c,Paquete p)
        {
            foreach (Paquete item in c.paquetes)
            {
                if(item == p)
                {
                    throw new TrackingIdRepetidoException("Trackingid repetido");
                }
            }

            c.paquetes.Add(p);
            c.mockPaquetes.Add(new Thread(p.MockCicloDeVida));
            int index = c.paquetes.IndexOf(p);
            c.mockPaquetes[index].Start();
            return c;
        }
    }
}
