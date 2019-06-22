using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Instancia los atributos de la clase.
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.Connection = conexion;
        }

        /// <summary>
        /// Inserta un paquete a la base de datos.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool todoOk = false;

            string sql = string.Format("INSERT INTO Paquetes values ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Chazarreta Matias");


            try
            {
                PaqueteDAO.comando.CommandText = sql;
                PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;

                PaqueteDAO.conexion.Open();

                PaqueteDAO.comando.ExecuteNonQuery();

                todoOk = true;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (todoOk)
                    PaqueteDAO.conexion.Close();
            }
            return todoOk;
        }
    }
}
