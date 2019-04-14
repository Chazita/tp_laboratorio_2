using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida y realiza la operacion pedida entre num1 y num2.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1,Numero num2,string operador)
        {
            double resultado = 0;
            if(!Object.Equals(num1,null) && !Object.Equals(num2,null))
            {
                switch (ValidarOperador(operador))
                {
                    case "+":
                        resultado = num1 + num2;
                        break;

                    case "-":
                        resultado = num1 - num2;
                        break;

                    case "/":
                        resultado = num1 / num2;

                        break;

                    case "*":
                        resultado = num1 * num2;
                        break;
                    default:
                        resultado = 0;
                        break;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Valida el operador recibido . Si no ninguno de los operadores correspondiente retornara '+'.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            string rta= "";
            switch (operador)
            {
                case "-":
                    rta += "-";
                    break;

                case "*":
                    rta += "*";
                    break;

                case "/":
                    rta += "/";
                    break;

                default:
                    rta += "+";
                    break;
            }
            return rta;
        }
    }
}
