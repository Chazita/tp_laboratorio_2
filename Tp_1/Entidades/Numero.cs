using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {

        private double _numero;

        public string SetNumero
        {
            set
            {
                this._numero = this.ValidarNumero(value);
            }
        }

        #region Constructores

        /// <summary>
        /// Se inicializa el objeto en 0.
        /// </summary>
        public Numero()
            :this("0")
        {

        }

        /// <summary>
        /// Se inicializa el objeto con el dato recibido.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
            :this(numero.ToString())    
        {

        }

        /// <summary>
        /// Se inicializa el objeto con el dato recibido y se valida.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Convierte un numero Binario a Decimal. En caso de no poder retornara el mensaje de error.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido\n";

            double cantidad = binario.Length;
            double numero = 0;

            int comprobacion;

            if(int.TryParse(binario,out comprobacion))
            {
                for (int i = 0; i < cantidad; i++)
                {
                    if (binario[i] == '1' || binario[i] == '0')
                    {
                        numero += int.Parse(binario[i].ToString()) * Math.Pow(2, (cantidad - 1 - i));
                    }
                    else
                    {
                        retorno = numero.ToString();
                        break;
                    }
                }
            }

            return retorno;
        }

        /// <summary>
        ///  Comvierte un numero Decimal a Binario. En caso de no poder retornara el mensaje de error.
        /// </summary>
        /// <param name="numero">Numero en decimal</param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string retorno = "Valor invalido\n";
            string numeroBinario = "";
            string numeroBinarioInvertido = "";
            string aux = numero.ToString();

            if(numero != 0)
            {
                while (numero != 0)
                {
                    numeroBinario += (int)numero % 2;
                    numero = (int)numero / 2;
                }

                if (numero == 0)
                {
                    for (int i = numeroBinario.Length - 1; i >= 0; i--)
                    {
                        numeroBinarioInvertido += numeroBinario[i];
                    }
                    retorno = numeroBinarioInvertido;
                }
            }
            else
            {
                retorno = "0";
            }
            
            return retorno;
        }

        /// <summary>
        /// Comvierte un numero string Decimal a Binario. En caso de no poder retornara el mensaje de error.
        /// </summary>
        /// <param name="strNumero">Un numero en decimal con formato string</param>
        /// <returns></returns>
        public static string DecimalBinario(string strNumero)
        {
            string retorno = "Valor invalido";
            double aux;

            if (!double.TryParse(strNumero, out aux))
            {
                
            }
            else
            {
                retorno = DecimalBinario(aux);
            }

            return retorno;
        }

        /// <summary>
        /// Valida si es posible convertir el string a double. En caso de no poder retornara 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double num;
            if(double.TryParse(strNumero, out num))
            {
                
            }
            else
            {
                num = 0;
            }

            return num;
        }


        #endregion

        #region Operadores
        /// <summary>
        /// Resta los atributos numero entre n1 y n2
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado = 0;
            if(!Object.Equals(n1,null) && !Object.Equals(n2,null))
            {
                resultado = n1._numero - n2._numero;
            }
            return resultado;
        }

        /// <summary>
        /// Sumar los atributos numero entre n1 y n2
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = 0;
            if (!Object.Equals(n1, null) && !Object.Equals(n2, null))
            {
                resultado = n1._numero + n2._numero;
            }
            return resultado;
        }

        /// <summary>
        /// Divide los atributos numero entre n1 y n2. Si es 0 devuelve el valor minimo de double.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = 0;
            if (!Object.Equals(n1, null) && !Object.Equals(n2, null))
            {
                if(n2._numero == 0 || n1._numero == 0)
                {
                    resultado = double.MinValue;
                }
                else
                {
                    resultado = n1._numero / n2._numero;
                }
                
            }
            return resultado;
        }

        /// <summary>
        /// Multiplica los atributos numero entre n1 y n2
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = 0;
            if (!Object.Equals(n1, null) && !Object.Equals(n2, null))
            {
                resultado = n1._numero * n2._numero;
            }
            return resultado;
        }
        #endregion
    }
}
