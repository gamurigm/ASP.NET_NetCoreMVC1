using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Capa_Datos
{
    public class SucursalDAL : BaseDatos
    {
        public int GuardarSucursal(SucursalCLS oSucursalCLS)
        {
            int rpta = 0;

            using (SqlConnection cn = ObtenerConexion())
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Sucursal(NOMBRE, DIRECCION, BHABILITADO) VALUES(@nombre, @direccion, 1)", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", oSucursalCLS.NOMBRE);
                        cmd.Parameters.AddWithValue("@direccion", oSucursalCLS.DIRECCION);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error SQL: {ex.Message}");
                    cn.Close();
                }
            }
            return rpta;
        }

        public List<SucursalCLS> listarSucursal()
        {
            List<SucursalCLS> lista = new();

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
                                lista.Add(new SucursalCLS
                                {
                                    IIDSUCURSAL = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    NOMBRE = drd.IsDBNull(1) ? string.Empty : drd.GetString(1),
                                    DIRECCION = drd.IsDBNull(2) ? string.Empty : drd.GetString(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<SucursalCLS>(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<SucursalCLS>();
            }

            return lista;
        }

        public List<SucursalCLS> filtrarSucursal(SucursalCLS obj)
        {
            List<SucursalCLS> lista = new();

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspFiltrarSucursal2", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombresucursal", obj.NOMBRE == null ? string.Empty : obj.NOMBRE);
                        cmd.Parameters.AddWithValue("@direccion", obj.DIRECCION == null ? string.Empty : obj.DIRECCION);

                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                lista.Add(new SucursalCLS
                                {
                                    IIDSUCURSAL = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    NOMBRE = drd.IsDBNull(1) ? string.Empty : drd.GetString(1),
                                    DIRECCION = drd.IsDBNull(2) ? string.Empty : drd.GetString(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<SucursalCLS>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<SucursalCLS>();
            }

            return lista;
        }
    }

}

