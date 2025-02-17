using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class TipoMedicamentoDAL : BaseDatos
    {
        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            List<TipoMedicamentoCLS> lista = new();

            try
            {
                using SqlConnection cn = ObtenerConexion();
                cn.Open();

                using SqlCommand cmd = new("SELECT IIDTIPOMEDICAMENTO, NOMBRE, DESCRIPCION FROM TipoMedicamento", cn);
                using SqlDataReader drd = cmd.ExecuteReader();

                while (drd.Read())
                {
                    lista.Add(new TipoMedicamentoCLS
                    {
                        id = drd.GetInt32(0),
                        nombre = drd.GetString(1),
                        descripcion = drd.GetString(2)
                    });
                }
             
            }
            catch (SqlException ex)
            {
                // Puedes registrar el error en un log para depuración
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<TipoMedicamentoCLS>(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<TipoMedicamentoCLS>();
            }

            return lista;
        }

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(string nombre)
        {
            List<TipoMedicamentoCLS> lista = new();

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspFiltrarTipoMedicamento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@descripcion", nombre == null ? string.Empty : nombre);

                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                lista.Add(new TipoMedicamentoCLS
                                {
                                    id = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    nombre = drd.IsDBNull(1) ? string.Empty : drd.GetString(1),
                                    descripcion = drd.IsDBNull(2) ? string.Empty : drd.GetString(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<TipoMedicamentoCLS>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<TipoMedicamentoCLS>();
            }

            return lista;
        }

    }
}
