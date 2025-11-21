using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ConnectApp.Database
{
    public class DatabaseConnection
    // Mantenemos la cadena de conexión que proporcionaste
    {
        private readonly string connectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=sistemaventasvehiculos;";

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        /// <summary>
        /// Intenta establecer una conexión y reporta el estado a la consola.
        /// </summary>
        /// <returns>True si la conexión fue exitosa.</returns>
        public bool ProbarConexion()
        {
            using (NpgsqlConnection conn = GetConnection())
            {
                    //abrir la conexión
                    conn.Open();
                    conn.Close();
                    return true;
            }
        }
    }
}