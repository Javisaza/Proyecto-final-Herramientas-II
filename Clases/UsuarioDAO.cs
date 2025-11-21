using AutoCare.Clases;
using ConnectApp.Database;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCare
{
    public class UsuarioDAO
    {
        // Creamos una instancia de la clase de conexión para acceder al método GetConnection()
        private readonly DatabaseConnection _dbConnection = new DatabaseConnection();

        /// <summary>
        /// Verifica si el usuario y la contraseña existen en la tabla 'usuarios'.
        /// </summary>
        /// <param name="username">El nombre de usuario.</param>
        /// <param name="password">La contraseña.</param>
        /// <returns>True si las credenciales son válidas, False en caso contrario.</returns>

        public UsuarioActual ObtenerDatosUsuario(string username, string password)
        {
            string query = @"
        SELECT id_usuario, nombre, apellido, email, username, password, rol
        FROM usuarios
        WHERE username = @username AND password = @password;
    ";

            using (var conn = _dbConnection.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password); 

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UsuarioActual(
                                reader.GetInt32(reader.GetOrdinal("id_usuario")),
                                reader.GetString(reader.GetOrdinal("nombre")),
                                reader.GetString(reader.GetOrdinal("apellido")),
                                reader.GetString(reader.GetOrdinal("email")),
                                reader.GetString(reader.GetOrdinal("username")),
                                reader.GetString(reader.GetOrdinal("password")),
                                reader.GetString(reader.GetOrdinal("rol"))

                            );
                        }
                    }
                }
            }

            return null; // si no se encontró
        }

        public bool AutenticarUsuario(string username, string password)
        {
            bool credencialesValidas = false;

            // Query parametrizada para prevenir inyección SQL
            string query = "SELECT COUNT(username) FROM usuarios WHERE username = @user AND password = @pass;";

            // Usamos el método GetConnection() para obtener la conexión
            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        // Añadir parámetros de forma segura
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);

                        // ExecuteScalar devuelve el número de filas coincidentes
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        credencialesValidas = count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de DB al intentar autenticar: " + ex.Message, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return credencialesValidas;
        }
        /// <summary>
        /// Obtiene todos los campos de todos los usuarios para llenar el DataGridView.
        /// </summary>
        public DataTable ObtenerTodosLosUsuarios()
        {
            DataTable dtUsuarios = new DataTable();
            // Seleccionamos todos los campos excepto la clave primaria (id_usuario), 
            // ya que la actualización se basará en el username, que es UNIQUE.
            string query = "SELECT username, nombre, apellido, email, password, rol FROM usuarios ORDER BY username;";

            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                    da.Fill(dtUsuarios);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dtUsuarios;
        }

        // Nuevo: Actualizar TODOS los campos de un usuario.
        // Se utiliza el 'oldUsername' para buscar el registro si el username fue cambiado.
        public bool ActualizarUsuario(string oldUsername, string nombre, string apellido, string email, string newUsername, string password, string rol)
        {
            // La consulta actualiza todos los campos y usa oldUsername para identificar la fila.
            string query = @"
                UPDATE usuarios 
                SET 
                    nombre = @nombre, 
                    apellido = @apellido, 
                    email = @email, 
                    username = @newUsername, 
                    password = @password, 
                    rol = @rol 
                WHERE 
                    username = @oldUsername;";

            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        // Añadir todos los parámetros
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@newUsername", newUsername);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@rol", rol);
                        cmd.Parameters.AddWithValue("@oldUsername", oldUsername); // Cláusula WHERE

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar errores de unicidad (si el nuevo username/email ya existe)
                    MessageBox.Show("Error al actualizar: Asegúrese de que el Usuario y Email sean únicos. Detalles: " + ex.Message, "Error de Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public bool EliminarUsuario(string username)
        {
            string query = "DELETE FROM usuarios WHERE username = @user;";

            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        int filasAfectadas = cmd.ExecuteNonQuery(); // Devuelve el número de filas afectadas
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        internal bool CrearUsuario(string nombre, string apellido, string email, string username, string password, string rol)
        {
            string query = @"
        INSERT INTO usuarios (nombre, apellido, email, username, password, rol)
        VALUES (@nombre, @apellido, @email, @username, @password, @rol);";

            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@rol", rol);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear usuario: El Usuario o Email ya existen. Detalles: " + ex.Message, "Error de Creación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        
    }
}
