using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Changuito
    {
        List<Producto> productos;
        int espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="chango">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito chango, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", chango.productos.Count, chango.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto productoEnChango in chango.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(productoEnChango is Snacks)
                            sb.AppendLine(productoEnChango.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if (productoEnChango is Dulce)
                            sb.AppendLine(productoEnChango.Mostrar());
                        break;
                    case ETipo.Leche:
                        if (productoEnChango is Leche)
                            sb.AppendLine(productoEnChango.Mostrar());
                        break;
                    default:
                        sb.AppendLine(productoEnChango.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="chango">Objeto donde se agregará el elemento</param>
        /// <param name="producto">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito chango, Producto producto)
        {
            bool flag = false;
            foreach (Producto productoEnChango in chango.productos)
            {
                if (productoEnChango == producto)
                    flag = true;
            }

            if(chango.productos.Count()<chango.espacioDisponible && flag == false)
            {
                chango.productos.Add(producto);
            }
            
            return chango;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="chango">Objeto donde se quitará el elemento</param>
        /// <param name="producto">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito chango, Producto producto)
        {
            bool flag = false;
            foreach (Producto productoEnChango in chango.productos)
            {
                if (productoEnChango == producto)
                {
                    flag = true;
                }
            }

            if(flag)
            {
                chango.productos.Remove(producto);
            }

            return chango;
        }
        #endregion
    }
}
