using ConnectApp.Database;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AutoCare.Clases
{
    public class CitaDAO
    {
        private readonly DatabaseConnection _dbConnection = new DatabaseConnection();

        public int ObtenerOInsertarCliente(string nombre, string apellido, string telefono, string email, string identificacion)
        {
            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();

                using (NpgsqlCommand checkCmd = new NpgsqlCommand("SELECT id_cliente FROM clientes WHERE identificacion = @identificacion", conn))
                {
                    checkCmd.Parameters.AddWithValue("identificacion", identificacion);
                    object result = checkCmd.ExecuteScalar();
                    if (result != null)
                        return (int)result;
                }

                using (NpgsqlCommand insertCmd = new NpgsqlCommand(@"
            INSERT INTO clientes (nombre, apellido, telefono, email, identificacion)
            VALUES (@nombre, @apellido, @telefono, @email, @identificacion)
            RETURNING id_cliente", conn))
                {
                    insertCmd.Parameters.AddWithValue("nombre", nombre);
                    insertCmd.Parameters.AddWithValue("apellido", apellido);
                    insertCmd.Parameters.AddWithValue("telefono", telefono);
                    insertCmd.Parameters.AddWithValue("email", email);
                    insertCmd.Parameters.AddWithValue("identificacion", identificacion);

                    return (int)insertCmd.ExecuteScalar();
                }
            }
        }
       
        public bool EliminarCita(int idCita)
        {
            string query = "DELETE FROM citas WHERE id_cita = @idCita;";

            using (var conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idCita", idCita);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la cita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public DataTable ObtenerCitasConVehiculo()
        {
            var dt = new DataTable();
            string query = @"
                    SELECT c.id_cita, c.nombre_cliente_reserva, c.apellido_cliente_reserva, c.email_cliente_reserva,
                           c.telefono_cliente_reserva, c.identificacion_cliente_reserva, c.motivo, c.fecha_hora_cita,
                           v.marca, v.modelo, v.anio
                    FROM citas c
                    JOIN vehiculos v ON c.id_vehiculo = v.id_vehiculo
                    ORDER BY c.fecha_hora_cita DESC;
                ";

            using (var conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader); // Carga directamente el resultado en el DataTable
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener citas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return dt;
        }

        /// Agenda una cita en la base de datos.
        public bool AgendarCita(string nombre, string apellido, string email, string telefono,
                         DateTime fechaHora, string motivo, int idVehiculo,
                         int idCliente, string identificacion)
        {
            string query = @"
        INSERT INTO citas (
            nombre_cliente_reserva, apellido_cliente_reserva, email_cliente_reserva, telefono_cliente_reserva,
            fecha_hora_cita, motivo, id_vehiculo, id_cliente_existente,
            identificacion_cliente_reserva
        )
        VALUES (
            @nombre, @apellido, @email, @telefono,
            @fechaHora, @motivo, @idVehiculo, @idCliente,
            @identificacion);";

            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("nombre", nombre);
                        cmd.Parameters.AddWithValue("apellido", apellido);
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("telefono", telefono);
                        cmd.Parameters.AddWithValue("fechaHora", fechaHora);
                        cmd.Parameters.AddWithValue("motivo", (object)motivo ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("idVehiculo", idVehiculo);
                        cmd.Parameters.AddWithValue("idCliente", idCliente);
                        cmd.Parameters.AddWithValue("identificacion", identificacion);

                        int filas = cmd.ExecuteNonQuery();
                        return filas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agendar cita: " + ex.Message, "Error de Cita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public bool ActualizarCita(int idCita, string nombre, string apellido, string email, string telefono, string identificacion, string motivo, DateTime fechaHora)
        {
            string query = @"
        UPDATE citas
        SET nombre_cliente_reserva = @nombre,
            apellido_cliente_reserva = @apellido,
            email_cliente_reserva = @email,
            telefono_cliente_reserva = @telefono,
            identificacion_cliente_reserva = @identificacion,
            motivo = @motivo,
            fecha_hora_cita = @fechaHora
        WHERE id_cita = @idCita;
            ";

            using (var conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@identificacion", identificacion);
                        cmd.Parameters.AddWithValue("@motivo", motivo);
                        cmd.Parameters.AddWithValue("@fechaHora", fechaHora);
                        cmd.Parameters.AddWithValue("@idCita", idCita);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la cita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}

