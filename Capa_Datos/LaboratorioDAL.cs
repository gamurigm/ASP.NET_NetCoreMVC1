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
    public class LaboratorioDAL : BaseDatos
    {
        public List<LaboratorioCLS> listarLaboratorio()
        {
            List<LaboratorioCLS> lista = new();

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Laboratorio", cn))
                    {
                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                lista.Add(new LaboratorioCLS
                                {
                                    IIDLABORATORIO = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    NOMBRE = drd.IsDBNull(1) ? string.Empty : drd.GetString(1),
                                    DIRECCION = drd.IsDBNull(2) ? string.Empty : drd.GetString(2),
                                    BHABILITADO = drd.IsDBNull(3) ? (int?)null : drd.GetInt32(3),
                                    PERSONACONTACTO = drd.IsDBNull(4) ? string.Empty : drd.GetString(4),
                                    NUMEROCONTACTO = drd.IsDBNull(5) ? string.Empty : drd.GetString(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<LaboratorioCLS>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<LaboratorioCLS>();
            }

            return lista;
        }

        public List<LaboratorioCLS> filtrarLaboratorio(string nombre)
        {
            List<LaboratorioCLS> lista = new();

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Laboratorio", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombresucursal", nombre == null ? string.Empty : nombre);

                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                lista.Add(new LaboratorioCLS
                                {
                                    IIDLABORATORIO = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    NOMBRE = drd.IsDBNull(1) ? string.Empty : drd.GetString(1),
                                    DIRECCION = drd.IsDBNull(2) ? string.Empty : drd.GetString(2),
                                    BHABILITADO = drd.IsDBNull(3) ? (int?)null : drd.GetInt32(3),
                                    PERSONACONTACTO = drd.IsDBNull(4) ? string.Empty : drd.GetString(4),
                                    NUMEROCONTACTO = drd.IsDBNull(5) ? string.Empty : drd.GetString(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                lista = new List<LaboratorioCLS>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                lista = new List<LaboratorioCLS>();
            }

            return lista;
        }
    }
}
