using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class PersonaDAL : BaseDatos
    {
        private readonly DataAccess<PersonaCLS> _dataAccess;

        public PersonaDAL()
        {
            _dataAccess = new DataAccess<PersonaCLS>(
                () => ObtenerConexion(),
                MapPersona
            );
        }

        private PersonaCLS MapPersona(SqlDataReader dr)
        {
            return new PersonaCLS
            {
                iidPersona = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1),
                apPaterno = dr.IsDBNull(2) ? string.Empty : dr.GetString(2),
                apMaterno = dr.IsDBNull(3) ? string.Empty : dr.GetString(3),
                email = dr.IsDBNull(4) ? string.Empty : dr.GetString(4),
                direccion = dr.IsDBNull(5) ? string.Empty : dr.GetString(5),
                iidsexo = dr.IsDBNull(6) ? 0 : dr.GetInt32(6),
                bhabilitado = dr.IsDBNull(7) ? 0 : dr.GetInt32(7),
                telefono = dr.IsDBNull(8) ? string.Empty : dr.GetString(8),
                bempleado = dr.IsDBNull(9) ? 0 : dr.GetInt32(9),
                iidSucursal = dr.IsDBNull(10) ? 0 : dr.GetInt32(10)
            };
        }

        public List<PersonaCLS> listarPersona()
        {
            string query = "SELECT * FROM Persona";
            return _dataAccess.ExecuteQuery(query, CommandType.Text);
        }

        public List<PersonaCLS> filtrarPersona(string nombre)
        {
            string storedProcedure = "uspFiltrarPersona";
            return _dataAccess.ExecuteQuery(
                storedProcedure,
                CommandType.StoredProcedure,
                cmd => cmd.Parameters.AddWithValue("@nombre", nombre ?? string.Empty)
            );
        }
    }
}
