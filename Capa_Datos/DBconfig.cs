using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

namespace Capa_Datos
{
    public abstract class BaseDatos
    {
        private static readonly string cadenaConexion;

        static BaseDatos()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var root = builder.Build();
            cadenaConexion = root.GetConnectionString("cn");
        }

        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}