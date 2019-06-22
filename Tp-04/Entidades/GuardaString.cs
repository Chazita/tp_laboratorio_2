using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{

    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension que guarda 'archivo' en el desktop del usuario.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool rto = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "\\" + archivo;
            try
            {

                StreamWriter sw = new StreamWriter(path);
                
                sw.WriteLine(texto);

                sw.Close();
                rto = true;

            }
            catch(Exception)
            {

            }

            return rto;
        }
    }
}
