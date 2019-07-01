using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool rto = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(sw, datos);
                    sw.Close();
                    rto = true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return rto;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool rto = false;
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    datos = (T)serializer.Deserialize(sr);
                    sr.Close();
                    rto = true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return rto;
        }
    }
}
