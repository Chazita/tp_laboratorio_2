using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Evento y delegado
        public delegate void DelegadoEstado(object sender, EventArgs args);
        public event DelegadoEstado InformaEstado;
        #endregion


        #region Enumerado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion


        #region Atributos

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion


        #region Propiedades

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }


        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }


        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        #endregion

        #region Constructor
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion
        #region Metodos

        /// <summary>
        /// Cambia el estado del paquete cada 4 segundos y lo inserta ,si el paquete esta entregado, a la base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformaEstado(null, null);
            }

            if (this.Estado == EEstado.Entregado)
            {
                try
                {
                    if (!PaqueteDAO.Insertar(this))
                    {

                    }
                }
                catch(Exception)
                {

                }
                
            }
        }

        /// <summary>
        /// Retorna los datos de elemento en formato string.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }

        /// <summary>
        /// Compara dos paquetes. Solo seran iguales si ambos paquetes tiene el mismo trackingID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }

        /// <summary>
        /// Compara dos paquetes. Solo seran desiguales si ambos paquetes tiene el mismo trackingID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Devuelve los datos del paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        #endregion

    }
}
