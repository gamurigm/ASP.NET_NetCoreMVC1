using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class DataAccess<T>
    {
        private readonly Func<SqlConnection> _getConnection;
        private readonly Func<SqlDataReader, T> _mapper;

        public DataAccess(Func<SqlConnection> getConnection, Func<SqlDataReader, T> mapper)
        {
            _getConnection = getConnection ?? throw new ArgumentNullException(nameof(getConnection));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public List<T> ExecuteQuery(string query, CommandType commandType, Action<SqlCommand> setParameters = null)
        {
            List<T> lista = new List<T>();

            try
            {
                using (SqlConnection cn = _getConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.CommandType = commandType;
                        setParameters?.Invoke(cmd);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(_mapper(dr));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                lista = new List<T>();
            }

            return lista;
        }
    }
}
