using Capa_Entidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Capa_Datos
{
    public class TipoMedicamentoDAL : BaseDatos
    {

        public TipoMedicamentoCLS recuperarTipoMedicamento(int id)
        {
            TipoMedicamentoCLS oTipoMedicamentoCLS = null;

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT iidtipomedicamento as id, nombre, descripcion FROM TipoMedicamento WHERE BHABILITADO = 1 AND IIDTIPOMEDICAMENTO = @id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", id); 

                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            if (drd.Read()) // Solo se lee un registro
                            {
                                oTipoMedicamentoCLS = new TipoMedicamentoCLS
                                {
                                    id = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    nombre = drd.IsDBNull(1) ? string.Empty : drd.GetString(1),
                                    descripcion = drd.IsDBNull(2) ? string.Empty : drd.GetString(2)
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }

            return oTipoMedicamentoCLS; // Retorna null si no encuentra el medicamento
        }

        public int GuardarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
            int rpta =0;

            using (SqlConnection cn = ObtenerConexion())
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO TipoMedicamento(NOMBRE, DESCRIPCION, BHABILITADO) VALUES(@nombre, @descripcion, 1)", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", oTipoMedicamentoCLS.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oTipoMedicamentoCLS.descripcion);
                   
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
