using ConnectApp.Database;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoCare.Clases
{
    public class ClienteDAO
    {
        private readonly DatabaseConnection _db;

        public ClienteDAO(DatabaseConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool ObtenerOActualizarOInsertarCliente(Cliente cliente)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO clientes (nombre, apellido, telefono, email, identificacion)
                        VALUES (@nombre, @apellido, @telefono, @email, @identificacion)
                        ON CONFLICT (identificacion) DO UPDATE
                        SET nombre = EXCLUDED.nombre,
                            apellido = EXCLUDED.apellido,
                            telefono = EXCLUDED.telefono,
                            email = EXCLUDED.email;
                    ";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                        cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                        cmd.Parameters.AddWithValue("@email", cliente.Correo);
                        cmd.Parameters.AddWithValue("@identificacion", cliente.Identificacion);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar o actualizar cliente: " + ex.Message);
                return false;
            }
        }



        public int ObtenerIdPorIdentificacion(string identificacion)
        {
            var db = new DatabaseConnection(); // instancia local
            using (var conn = db.GetConnection())
            {
                using (var cmd = new NpgsqlCommand("SELECT id_cliente FROM clientes WHERE identificacion = @identificacion", conn))
                {
                    cmd.Parameters.AddWithValue("@identificacion", identificacion);

                    try
                    {
                        conn.Open();
                        var result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                    catch
                    {
                        return -1;
                    }
                }
            }
        }


    }
}
