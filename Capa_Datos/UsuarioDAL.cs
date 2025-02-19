using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class UsuarioDAL : BaseDatos
    {
        public List<UsuarioCLS> listarUsuario()
        {
            List<UsuarioCLS> lista = new();

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("Listar", cn))
                    {
                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                lista.Add(new UsuarioCLS
                                {
                                    
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<UsuarioCLS>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<UsuarioCLS>();
            }

            return lista;
        }

        public List<UsuarioCLS> filtrarUsuario(string nombre)
        {
            List<UsuarioCLS> lista = new();

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspFiltrarUsuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreUsuario", nombre == null ? string.Empty : nombre);

                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                lista.Add(new UsuarioCLS
                                {
                                    
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<UsuarioCLS>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<UsuarioCLS>();
            }

            return lista;
        }
    }
}
