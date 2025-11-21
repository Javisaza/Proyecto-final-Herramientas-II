using AutoCare.Clases;
using ConnectApp.Database;
using System;
using System.Data;
using Npgsql;

public class VentasDAO
{
    private readonly DatabaseConnection _db;

    public VentasDAO(DatabaseConnection db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public bool InsertarVenta(Ventas venta)
    {
        string query = @"
            INSERT INTO ventas 
            (id_vehiculo, id_cliente, id_vendedor, fecha_venta, precio_venta, metodo_pago)
            VALUES (@idVehiculo, @idCliente, @idVendedor, @fechaVenta, @precioVenta, @metodoPago);
        ";

        using (var conn = _db.GetConnection())
        using (var cmd = new NpgsqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@idVehiculo", venta.IdVehiculo);
            cmd.Parameters.AddWithValue("@idCliente", venta.IdCliente);
            cmd.Parameters.AddWithValue("@idVendedor", venta.IdVendedor);
            cmd.Parameters.AddWithValue("@fechaVenta", venta.FechaVenta);
            cmd.Parameters.AddWithValue("@precioVenta", venta.PrecioVenta);
            cmd.Parameters.AddWithValue("@metodoPago", venta.MetodoPago);

            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }

    public DataTable ObtenerVentas()
    {
        string query = "SELECT * FROM ventas";
        DataTable tablaVentas = new DataTable();

        using (var conn = _db.GetConnection())
        using (var cmd = new NpgsqlCommand(query, conn))
        using (var adapter = new NpgsqlDataAdapter(cmd))
        {
            conn.Open();
            adapter.Fill(tablaVentas);
        }

        return tablaVentas;
    }

    public DataTable ObtenerVehiculos()
    {
        string query = "SELECT id_vehiculo, nombre_vehiculo FROM vehiculos";
        DataTable tabla = new DataTable();

        using (var conn = _db.GetConnection())
        using (var cmd = new NpgsqlCommand(query, conn))
        using (var adapter = new NpgsqlDataAdapter(cmd))
        {
            conn.Open();
            adapter.Fill(tabla);
        }

        return tabla;
    }

    public DataTable ObtenerVentasDetalladas()
    {
        string query = @"
        SELECT v.id_venta,
               c.nombre || ' ' || c.apellido AS cliente,
               ve.marca || ' ' || ve.modelo AS vehiculo,
               u.nombre AS vendedor,
               v.fecha_venta,
               v.precio_venta AS monto_total,
               v.metodo_pago
        FROM ventas v
        INNER JOIN clientes c ON v.id_cliente = c.id_cliente
        INNER JOIN vehiculos ve ON v.id_vehiculo = ve.id_vehiculo
        INNER JOIN usuarios u ON v.id_vendedor = u.id_usuario
        ORDER BY v.fecha_venta DESC;
    ";

        DataTable tabla = new DataTable();

        using (var conn = _db.GetConnection())
        using (var cmd = new NpgsqlCommand(query, conn))
        using (var adapter = new NpgsqlDataAdapter(cmd))
        {
            conn.Open();
            adapter.Fill(tabla);
        }

        return tabla;
    }

    public DataTable ObtenerClientes()
    {
        string query = "SELECT id_cliente, nombre_cliente FROM clientes";
        DataTable tabla = new DataTable();

        using (var conn = _db.GetConnection())
        using (var cmd = new NpgsqlCommand(query, conn))
        using (var adapter = new NpgsqlDataAdapter(cmd))
        {
            conn.Open();
            adapter.Fill(tabla);
        }

        return tabla;
    }

    public string ObtenerNombreVendedor(int idVendedor)
    {
        string query = "SELECT nombre FROM usuarios WHERE id_usuario = @id";

        using (var conn = _db.GetConnection())
        using (var cmd = new NpgsqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@id", idVendedor);
            conn.Open();
            object result = cmd.ExecuteScalar();
            return result?.ToString() ?? string.Empty;
        }
    }
}