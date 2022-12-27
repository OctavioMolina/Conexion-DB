using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Conexion_base_datos
{
    internal class Program
    {
        static void Main(string[] args)
        {
                List<Elementos> listar()
            {
                List<Elementos> lista = new List<Elementos>();
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;

                try
                {
                    conexion.ConnectionString = "server=.\\SQLEXPRESS; database=(DB sobre la cual quiero trabajar); integrated security=true";
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "(query a realizar)";
                    comando.Connection = conexion;

                    conexion.Open();
                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        Elementos aux = new Elementos();
                        aux.precio = lector.GetInt32(0);
                        aux.color = (string)lector["color"];
                        aux.medida = (string)lector["medida"];

                        lista.Add(aux);
                    }

                    conexion.Close();
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                listar();
            }

        }
    }
}
