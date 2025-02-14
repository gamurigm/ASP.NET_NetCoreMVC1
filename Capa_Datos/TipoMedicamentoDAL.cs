using Capa_Entidad;
using System;
using System.Collections.Generic;
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
                lista = new List<TipoMedicamentoCLS>(); // Retorna una lista vacía en lugar de null
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
