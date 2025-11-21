using ConnectApp.Database;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AutoCare.Clases
{
    public class VehiculoDAO
    {
        private readonly DatabaseConnection _dbConnection = new DatabaseConnection();

        public string ObtenerEstadoVehiculoPorDatos(string marca, string modelo, int anio)
        {
            try
            {
                using (var conn = _dbConnection.GetConnection())
                using (var cmd = new NpgsqlCommand(@"
            SELECT estado 
            FROM vehiculos 
            WHERE marca = @marca AND modelo = @modelo AND anio = @anio
            LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@marca", marca);
                    cmd.Parameters.AddWithValue("@modelo", modelo);
                    cmd.Parameters.AddWithValue("@anio", anio);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : "Desconocido";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener estado del vehículo: " + ex.Message);
                return "Error";
            }
        }
        // Método principal para aplicar todos los filtros de búsqueda.
        public DataTable ObtenerVehiculosFiltrados(string marca, decimal precioMin, decimal precioMax, string tipoCombustible, int kmMin, int kmMax)
        {
            DataTable dtVehiculos = new DataTable();
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // CORRECCIÓN PRINCIPAL: Se añadió 'estado' a la lista de columnas seleccionadas.
            string query = @"
            SELECT marca, modelo, anio, color, tipo_combustible, descripcion, precio, kilometraje, estado
            FROM vehiculos
            WHERE 1=1 ";

            // Lógica de construcción dinámica: Se añade la cláusula AND solo si el filtro tiene valor.
            if (!string.IsNullOrEmpty(marca) && marca != "Todas")
            {
                query += " AND marca = @marca ";
                parameters.Add(new NpgsqlParameter("@marca", marca));
            }
            if (precioMin > 0)
            {
                query += " AND precio >= @precioMin ";
                parameters.Add(new NpgsqlParameter("@precioMin", precioMin));
            }
            if (precioMax > 0 && precioMax >= precioMin)
            {
                query += " AND precio <= @precioMax ";
                parameters.Add(new NpgsqlParameter("@precioMax", precioMax));
            }
            if (!string.IsNullOrEmpty(tipoCombustible) && tipoCombustible != "Todos")
            {
                query += " AND tipo_combustible = @tipoCombustible ";
                parameters.Add(new NpgsqlParameter("@tipoCombustible", tipoCombustible));
            }
            if (kmMin > 0)
            {
                query += " AND kilometraje >= @kmMin ";
                parameters.Add(new NpgsqlParameter("@kmMin", kmMin));
            }
            if (kmMax > 0 && kmMax >= kmMin)
            {
                query += " AND kilometraje <= @kmMax ";
                parameters.Add(new NpgsqlParameter("@kmMax", kmMax));
            }

            query += " ORDER BY marca, modelo, anio;";

            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }

                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        da.Fill(dtVehiculos);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al aplicar filtros: " + ex.Message, "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dtVehiculos;
        }

        // El método ObtenerTodosLosVehiculos simplemente llama al método filtrado con valores vacíos.
        public DataTable ObtenerTodosLosVehiculos()
        {
            return ObtenerVehiculosFiltrados(null, 0, 0, null, 0, 0);
        }

        public List<string> ObtenerMarcasUnicas()
        {
            List<string> marcas = new List<string>();
            string query = "SELECT DISTINCT marca FROM vehiculos ORDER BY marca";

            using (var conn = _dbConnection.GetConnection())
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marcas.Add(reader.GetString(0));
                    }
                }
            }
            return marcas;
        }


        /// <summary>
        /// Crea un nuevo vehículo en la base de datos y su carpeta de imágenes.
        /// </summary>
        // CORRECCIÓN: Se añadió 'tipo_combustible' a la firma del método.
        public bool CrearVehiculo(string marca, string modelo, int anio, int precio, int kilometraje,
                                  string color, string descripcion, string estado, string tipo_combustible, DateTime fechaRegistro)
        {
            string query = @"
            INSERT INTO vehiculos (marca, modelo, anio, precio, kilometraje, color, descripcion, estado, tipo_combustible, fecha_registro)
            VALUES (@marca, @modelo, @anio, @precio, @kilometraje, @color, @descripcion, @estado, @tipoCombustible, @fechaRegistro);"; // CORRECCIÓN: Se añadió tipo_combustible en el SQL

            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@marca", marca);
                        cmd.Parameters.AddWithValue("@modelo", modelo);
                        cmd.Parameters.AddWithValue("@anio", anio);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@kilometraje", kilometraje);
                        cmd.Parameters.AddWithValue("@color", color);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@tipoCombustible", tipo_combustible); // CORRECCIÓN: Se añadió el parámetro
                        cmd.Parameters.AddWithValue("@fechaRegistro", fechaRegistro);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear vehículo: " + ex.Message, "Error de Creación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        /// <summary>
        /// Mapea los DataRow de un DataTable a una lista de objetos Vehiculos.
        /// </summary>
        public List<Vehiculos> MapearVehiculos(DataTable dt)
        {
            var lista = new List<Vehiculos>();

            foreach (DataRow row in dt.Rows)
            {
                var vehiculo = new Vehiculos
                {
                    Marca = row["marca"].ToString(),
                    Modelo = row["modelo"].ToString(),
                    Anio = Convert.ToInt32(row["anio"]),
                    Color = row["color"].ToString(),
                    Estado = row["estado"].ToString(), // CORRECCIÓN: Mapeo de la columna 'estado'
                    TipoCombustible = row["tipo_combustible"].ToString(),
                    Descripcion = row["descripcion"].ToString(),
                    Precio = Convert.ToDecimal(row["precio"]),
                    Kilometraje = Convert.ToInt32(row["kilometraje"])
                };

                // Verificación visual (solo para debugging, puedes eliminarlo)
                // MessageBox.Show("Km cargado: " + vehiculo.Kilometraje);

                lista.Add(vehiculo);
            }

            return lista;
        }

        /// Actualiza todos los campos de un vehículo. Se identifica por marca, modelo y anio.
        // CORRECCIÓN: Se añadió 'estado' a la firma del método.
        // Dentro de VehiculoDAO.cs
        public bool ActualizarVehiculo(string marcaOriginal, string modeloOriginal, int anioOriginal,
                                               string nuevaMarca, string nuevoModelo, int nuevoanio,
                                               string color, string estado, string tipoCombustible, string descripcion, int precio, int Km)
        {
            string query = @"
                UPDATE vehiculos
                SET ""marca"" = @nuevaMarca,
                    ""modelo"" = @nuevoModelo,
                    ""anio"" = @nuevoanio,
                    ""color"" = @color,
                    ""estado"" = @estado,
                    ""tipo_combustible"" = @tipoCombustible,
                    ""descripcion"" = @descripcion,
                    ""precio"" = @precio,
                    ""kilometraje"" = @kilometraje     -- ¡Comillas dobles aquí!
                WHERE ""marca"" = @marcaOriginal AND ""modelo"" = @modeloOriginal AND ""anio"" = @anioOriginal;"; // También en el WHERE

            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nuevaMarca", nuevaMarca);
                        cmd.Parameters.AddWithValue("@nuevoModelo", nuevoModelo);
                        cmd.Parameters.AddWithValue("@nuevoanio", nuevoanio);
                        cmd.Parameters.AddWithValue("@color", color);
                        cmd.Parameters.AddWithValue("@estado", estado);           // <--- ¡CORREGIDO!
                        cmd.Parameters.AddWithValue("@tipoCombustible", tipoCombustible);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@kilometraje", Km);

                        cmd.Parameters.AddWithValue("@marcaOriginal", marcaOriginal);
                        cmd.Parameters.AddWithValue("@modeloOriginal", modeloOriginal);
                        cmd.Parameters.AddWithValue("@anioOriginal", anioOriginal);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar vehículo: " + ex.Message, "Error de Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina un vehículo identificado por marca, modelo y anio.
        /// </summary>
        public bool EliminarVehiculo(string marca, string modelo, int anio)
        {
            string query = "DELETE FROM vehiculos WHERE marca = @marca AND modelo = @modelo AND anio = @anio;";

            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@marca", marca);
                        cmd.Parameters.AddWithValue("@modelo", modelo);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar vehículo: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        public void GuardarImagenVehiculo(string marca, string modelo, int anio, string rutaImagen)
        {
            try
            {
                // Carpeta base donde se guardarán todas las imágenes
                string basePath = Path.Combine(Application.StartupPath, "ImagenesVehiculos");

                // Carpeta específica para el vehículo (ejemplo: Toyota_Corolla_2020)
                string carpetaVehiculo = Path.Combine(basePath, $"{marca}_{modelo}_{anio}");

                // Crear carpeta si no existe
                if (!Directory.Exists(carpetaVehiculo))
                {
                    Directory.CreateDirectory(carpetaVehiculo);
                }

                // Nombre del archivo original
                string nombreArchivo = Path.GetFileName(rutaImagen);

                // Ruta destino dentro de la carpeta del vehículo
                string destino = Path.Combine(carpetaVehiculo, nombreArchivo);

                // Copiar la imagen (sobrescribe si ya existe)
                File.Copy(rutaImagen, destino, true);

                MessageBox.Show("Imagen guardada correctamente en la carpeta del vehículo.",
                                 "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la imagen: " + ex.Message,
                                 "Error de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int? ObtenerIdVehiculo(string marca, string modelo, int anio)
        {
            string query = @"SELECT id_vehiculo FROM vehiculos WHERE marca = @marca AND modelo = @modelo AND anio = @anio;";

            using (NpgsqlConnection conn = _dbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("marca", marca);
                        cmd.Parameters.AddWithValue("modelo", modelo);
                        cmd.Parameters.AddWithValue("anio", anio);

                        object result = cmd.ExecuteScalar();
                        return result != null ? (int?)result : null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener ID del vehículo: " + ex.Message, "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }
}