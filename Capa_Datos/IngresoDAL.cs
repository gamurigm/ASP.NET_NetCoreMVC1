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
    public class IngresoDAL : BaseDatos
    {
        public List<IngresoCLS> listarIngreso()
        {
            List<IngresoCLS> lista = new();

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
                                lista.Add(new IngresoCLS
                                {
                                    IIDINGRESO = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    IIDMEDICAMENTO = drd.IsDBNull(1) ? (int?)null : drd.GetInt32(1),
                                    IIDLABORATORIO = drd.IsDBNull(2) ? (int?)null : drd.GetInt32(2),
                                    FECHACOMPRA = drd.IsDBNull(3) ? (DateTime?)null : drd.GetDateTime(3),
                                    CANTIDAD = drd.IsDBNull(4) ? (int?)null : drd.GetInt32(4),
                                    FECHAVENCIMIENTO = drd.IsDBNull(5) ? (DateTime?)null : drd.GetDateTime(5),
                                    PRECIOCOMPRA = drd.IsDBNull(6) ? (decimal?)null : drd.GetDecimal(6),
                                    BHABILITADO = drd.IsDBNull(7) ? (int?)null : drd.GetInt32(7),
                                    DFECHAVENCIMIENTO = drd.IsDBNull(8) ? (DateTime?)null : drd.GetDateTime(8),
                                    IIDMARCA = drd.IsDBNull(9) ? (int?)null : drd.GetInt32(9),
                                    PRECIOVENTA = drd.IsDBNull(10) ? (decimal?)null : drd.GetDecimal(10)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<IngresoCLS>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<IngresoCLS>();
            }

            return lista;
        }

        public List<IngresoCLS> filtrarSucursal(string nombre)
        {
            List<IngresoCLS> lista = new();

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
                                lista.Add(new IngresoCLS
                                {
                                    IIDINGRESO = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    IIDMEDICAMENTO = drd.IsDBNull(1) ? (int?)null : drd.GetInt32(1),
                                    IIDLABORATORIO = drd.IsDBNull(2) ? (int?)null : drd.GetInt32(2),
                                    FECHACOMPRA = drd.IsDBNull(3) ? (DateTime?)null : drd.GetDateTime(3),
                                    CANTIDAD = drd.IsDBNull(4) ? (int?)null : drd.GetInt32(4),
                                    FECHAVENCIMIENTO = drd.IsDBNull(5) ? (DateTime?)null : drd.GetDateTime(5),
                                    PRECIOCOMPRA = drd.IsDBNull(6) ? (decimal?)null : drd.GetDecimal(6),
                                    BHABILITADO = drd.IsDBNull(7) ? (int?)null : drd.GetInt32(7),
                                    DFECHAVENCIMIENTO = drd.IsDBNull(8) ? (DateTime?)null : drd.GetDateTime(8),
                                    IIDMARCA = drd.IsDBNull(9) ? (int?)null : drd.GetInt32(9),
                                    PRECIOVENTA = drd.IsDBNull(10) ? (decimal?)null : drd.GetDecimal(10)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<IngresoCLS>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<IngresoCLS>();
            }

            return lista;
        }
    }
}

