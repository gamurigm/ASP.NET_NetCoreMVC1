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

        //public int GuardarLaboratorio(LaboratorioCLS oLaboratorioCLS)
        //{
        //    int rpta = 0;

        //    using (SqlConnection cn = ObtenerConexion())
        //    {
        //        try
        //        {
        //            cn.Open();

        //            using (SqlCommand cmd = new SqlCommand("INSERT INTO Laboratorio", cn))
        //            {
        //                cmd.CommandType = CommandType.Text;
        //                cmd.Parameters.AddWithValue("@nombre", oLaboratorioCLS.NOMBRE);
        //                cmd.Parameters.AddWithValue("@direccion", oLaboratorioCLS.DIRECCION);

        //                rpta = cmd.ExecuteNonQuery();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Error SQL: {ex.Message}");
        //            cn.Close();
        //        }
        //    }
        //    return rpta;
        //}
        public List<LaboratorioCLS> listarLaboratorio()
        {
            List<LaboratorioCLS> lista = new();

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListarLaboratorio", cn))
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
                                 
                                    PERSONACONTACTO = drd.IsDBNull(3) ? string.Empty : drd.GetString(3)
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

        public List<LaboratorioCLS> filtrarLaboratorio(LaboratorioCLS obj)
        {
            List<LaboratorioCLS> lista = new();

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspFiltrarLaboratorio", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", obj.NOMBRE == null ? string.Empty : obj.NOMBRE);
                        cmd.Parameters.AddWithValue("@direccion", obj.DIRECCION == null ? string.Empty : obj.DIRECCION);
                        cmd.Parameters.AddWithValue("@personacontacto", obj.PERSONACONTACTO == null ? string.Empty : obj.PERSONACONTACTO);

                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                lista.Add(new LaboratorioCLS
                                {
                                    IIDLABORATORIO = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    NOMBRE = drd.IsDBNull(1) ? string.Empty : drd.GetString(1),
                                    DIRECCION = drd.IsDBNull(2) ? string.Empty : drd.GetString(2),
                              
                                    PERSONACONTACTO = drd.IsDBNull(3) ? string.Empty : drd.GetString(3)
                                  
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
