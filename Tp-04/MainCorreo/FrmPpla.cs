using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpla : Form
    {
        private Correo correo;
        public FrmPpla()
        {
            InitializeComponent();
            this.correo = new Correo();
            this.FormClosing += new FormClosingEventHandler(this.FrmPla_FormClosing);
        }


        /// <summary>
        /// Cierra todos los hilos al cerrar el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPla_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntrega();
        }


        /// <summary>
        /// Agrega un paquete al correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
            try
            {
                this.correo += paquete;
            }
            catch(TrackingIdRepetidoException tirE)
            {
                MessageBox.Show(tirE.Message, "ERROR!, el Paquete esta repetido.", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            this.ActualizarEstados();
        }

        /// <summary>
        /// Llama al metodo MostrarInformacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Actualiza el estado del paquete.
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete paquete in this.correo.Paquetes)
            {
                switch(paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paquete);
                        break;

                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paquete);
                        break;

                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paquete);
                        break;

                }
            }
        }


        /// <summary>
        /// Llama al metodo ActualizarEstados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] {sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }

        }


        /// <summary>
        /// Muestra los datos del correo en el RichTextBox.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(!Object.Equals(elemento,null))
            {
                string datos = this.correo.MostrarDatos(this.correo);
                this.rtbMostrar.Text = datos;

                try
                {
                    datos.Guardar("salida.txt");
                }
                catch(Exception)
                {
                    MessageBox.Show("Error al guardar el txt");
                }
            }
        }


        /// <summary>
        /// Al hace click derecho en el listBoxEntregado el item seleccionado se muestra en el RichTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rtbMostrar.Text = this.lstEstadoEntregado.SelectedItem.ToString();
        }
        
    }
}
