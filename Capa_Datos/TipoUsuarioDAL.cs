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
    public class TipoUsuarioDAL : BaseDatos
    {
        public List<TipoUsuarioCLS> listarTipoUsuario()
        {
            List<TipoUsuarioCLS> lista = new();

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario", cn))
                    {
                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                lista.Add(new TipoUsuarioCLS
                                {
                                    IdTipoUsuario = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    Nombre = drd.IsDBNull(1) ? string.Empty : drd.GetString(1),
                                    Descripcion = drd.IsDBNull(2) ? string.Empty : drd.GetString(2),
                                    Bhabilitado = drd.IsDBNull(3) ? 0 : drd.GetInt32(3),

                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<TipoUsuarioCLS>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<TipoUsuarioCLS>();
            }

            return lista;
        }

        public List<TipoUsuarioCLS> filtrarUsuario(string nombre)
        {
            List<TipoUsuarioCLS> lista = new();

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
                                lista.Add(new TipoUsuarioCLS
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
                lista = new List<TipoUsuarioCLS>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<TipoUsuarioCLS>();
            }

            return lista;
        }
    }
}
