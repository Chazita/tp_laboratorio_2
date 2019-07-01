using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool rto = false;
            try
            {
                StreamWriter sw = new StreamWriter(archivo);
                sw.WriteLine(datos);
                sw.Close();
                rto = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return rto;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool rto = false;

            try
            {
                StreamReader sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                sr.Close();
                rto = true;

            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return rto;
        }
    }
}
