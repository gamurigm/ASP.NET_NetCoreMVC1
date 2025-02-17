using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class SucursalDAL : BaseDatos
    {
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

        public List<SucursalCLS> filtrarSucursal(string nombre)
        {
            List<SucursalCLS> lista = new();

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspFiltrarSucursal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombresucursal", nombre == null ? string.Empty : nombre);

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

