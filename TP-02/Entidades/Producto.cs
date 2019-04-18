using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        EMarca marca;
        string codigoDeBarras;
        ConsoleColor colorPrimarioEmpaque;

        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = patente;
            this.colorPrimarioEmpaque = color;
            this.marca = marca;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected virtual short CantidadCalorias { get;}

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <param name="producto"></param>
        public static explicit operator string(Producto producto)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: "+producto.codigoDeBarras);
            sb.AppendLine("MARCA          : "+ producto.marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : "+ producto.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="producto1"></param>
        /// <param name="producto2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto producto1, Producto producto2)
        {
            return (producto1.codigoDeBarras == producto2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="producto1"></param>
        /// <param name="producto2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto producto1, Producto producto2)
        {
            return !(producto1==producto2);
        }
    }
}
