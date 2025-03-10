﻿using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Capa_Datos
{
    public class SucursalDAL : BaseDatos
    {
        public int GuardarSucursal(SucursalCLS sucursal)
        {
            int rpta = 0;

            using (SqlConnection cn = ObtenerConexion())
            {
                try
                {
                    cn.Open();
                    string sqlCommand;

                    if (sucursal.id == 0)
                    {
                        sqlCommand = "INSERT INTO Sucursal (nombre, direccion, BHABILITADO) VALUES (@nombre, @direccion, 1)";
                    }
                    else
                    {
                        sqlCommand = "UPDATE Sucursal SET nombre = @nombre, direccion = @direccion WHERE IIDSUCURSAL = @id";
                    }

                    using (SqlCommand cmd = new SqlCommand(sqlCommand, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        if (sucursal.id != 0)
                        {
                            cmd.Parameters.AddWithValue("@id", sucursal.id);
                        }

                        cmd.Parameters.AddWithValue("@nombre", sucursal.NOMBRE);
                        cmd.Parameters.AddWithValue("@direccion", sucursal.DIRECCION);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error SQL: {ex.Message}");
                    rpta = 0;
                }
                finally
                {
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
                                    id = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
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
                                    id = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
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

        public SucursalCLS recuperarSucursal(int id)
        {
            SucursalCLS oSucursalCLS = null;

            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT iidsucursal as id, nombre, direccion FROM Sucursal WHERE BHABILITADO = 1 AND IIDSUCURSAL = @id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            if (drd.Read())
                            {
                                oSucursalCLS = new SucursalCLS
                                {
                                    id = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    NOMBRE = drd.IsDBNull(1) ? string.Empty : drd.GetString(1),
                                    DIRECCION = drd.IsDBNull(2) ? string.Empty : drd.GetString(2)
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

            return oSucursalCLS;
        }

        public int Eliminar(int id)
        {
            int rpta = 0;

            using (SqlConnection cn = ObtenerConexion())
            {
                try
                {
                    cn.Open();

                    string sqlCommand = "DELETE FROM Sucursal WHERE IIDSUCURSAL = @id";

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





    }

}

