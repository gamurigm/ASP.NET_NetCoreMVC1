using Capa_Entidad;
using Microsoft.Extensions.Configuration;
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
                                    idSucursal = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    nombre = drd.IsDBNull(1) ? string.Empty : drd.GetString(1),
                                    direccion = drd.IsDBNull(2) ? string.Empty : drd.GetString(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<SucursalCLS>(); // Retorna una lista vacía en caso de error
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
