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

                    using (SqlCommand cmd = new SqlCommand("uspListarLaboratorio", cn))
                    {
                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                lista.Add(new LaboratorioCLS
                                {
                                    id = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
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
                                    id = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
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

        public LaboratorioCLS recuperarLaboratorio(int id)
        {
            LaboratorioCLS oLaboratorioCLS = null;

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT iidlaboratorio, nombre, descripcion, personacontacto FROM Laboratorio WHERE BHABILITADO = 1 AND IIDLABORATORIO = @id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            if (drd.Read())
                            {
                                oLaboratorioCLS = new LaboratorioCLS
                                {
                                    id = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    NOMBRE = drd.IsDBNull(1) ? string.Empty : drd.GetString(1),
                                    DIRECCION  = drd.IsDBNull(2) ? string.Empty : drd.GetString(2),
                                    PERSONACONTACTO = drd.IsDBNull(2) ? string.Empty : drd.GetString(3)
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

            return oLaboratorioCLS;
        }

        public int Eliminar(int id)
        {
            int rpta = 0;

            using (SqlConnection cn = ObtenerConexion())
            {
                try
                {
                    cn.Open();

                    string sqlCommand = "DELETE FROM Laboratorio WHERE IIDLABORATORIO = @id";

                    using (SqlCommand cmd = new SqlCommand(sqlCommand, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        if (id != 0)
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                        }

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error SQL: {ex.Message}");
                }
                finally
                {
                    cn.Close();
                }
            }
            return rpta;
        }

        //public int GuardarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        //{
        //    int rpta = 0;

        //    using (SqlConnection cn = ObtenerConexion())
        //    {
        //        try
        //        {
        //            cn.Open();
        //            string sqlCommand;

        //            if (oTipoMedicamentoCLS.id == 0)
        //            {
        //                // Inserción
        //                sqlCommand = "INSERT INTO TipoMedicamento(NOMBRE, DESCRIPCION, BHABILITADO) VALUES(@nombre, @descripcion, 1)";
        //            }
        //            else
        //            {
        //                // Actualización
        //                sqlCommand = "UPDATE TipoMedicamento SET NOMBRE = @nombre, DESCRIPCION = @descripcion WHERE IIDTIPOMEDICAMENTO = @id";
        //            }

        //            using (SqlCommand cmd = new SqlCommand(sqlCommand, cn))
        //            {
        //                cmd.CommandType = CommandType.Text;
        //                cmd.Parameters.AddWithValue("@nombre", oTipoMedicamentoCLS.nombre);
        //                cmd.Parameters.AddWithValue("@descripcion", oTipoMedicamentoCLS.descripcion);

        //                if (oTipoMedicamentoCLS.id != 0)
        //                {
        //                    cmd.Parameters.AddWithValue("@id", oTipoMedicamentoCLS.id);
        //                }

        //                rpta = cmd.ExecuteNonQuery();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Error SQL: {ex.Message}");
        //        }
        //        finally
        //        {
        //            cn.Close();
        //        }
        //    }
        //    return rpta;
        //}


    }
}
