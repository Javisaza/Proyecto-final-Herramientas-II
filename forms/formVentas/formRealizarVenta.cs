using AutoCare.Clases;
using ConnectApp.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCare.forms.formVentas
{


    public partial class formRealizarVenta : AutoCare.plantilla
    {
        Vehiculos _vehiculo;
        private readonly DatabaseConnection _db;
        private readonly ClienteDAO _clienteDao;


        public formRealizarVenta(Vehiculos vehiculo)
        {
            InitializeComponent();
            _vehiculo = vehiculo;
            _db = new DatabaseConnection();
            _clienteDao = new ClienteDAO(_db);

        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtEmail.Text,
                Identificacion = txtIdentificacion.Text
            };

            ClienteDAO clienteDao = new ClienteDAO(_db);
            bool clienteGuardado = clienteDao.ObtenerOActualizarOInsertarCliente(cliente);
            int idCliente = clienteDao.ObtenerIdPorIdentificacion(cliente.Identificacion);
            VehiculoDAO vehiculoDao = new VehiculoDAO();
            int? idVehiculo = vehiculoDao.ObtenerIdVehiculo(_vehiculo.Marca, _vehiculo.Modelo, _vehiculo.Anio);

            if (clienteGuardado && idCliente != -1)
            {
                Ventas venta = new Ventas
                {
                    IdVehiculo = idVehiculo.Value,
                    IdCliente = idCliente,
                    IdVendedor = SesionUsuario.Usuario.IdUsuario,
                    FechaVenta = DateTime.Now,
                    PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                    MetodoPago = cmbMetodoPago.SelectedItem.ToString()
                };

                DatabaseConnection conexion = new DatabaseConnection();
                VentasDAO ventasDAO = new VentasDAO(conexion);
                bool ventaRegistrada = ventasDAO.InsertarVenta(venta);

                if (ventaRegistrada)
                {
                    string nombreCliente = cliente.Nombre + " " + cliente.Apellido;
                    string nombreVendedor = SesionUsuario.Usuario.Nombre;
                    string nombreVehiculo = $"{_vehiculo.Marca} {_vehiculo.Modelo} {_vehiculo}";

                    MessageBox.Show($"Venta registrada correctamente:\n" +
                                    $"Cliente: {nombreCliente}\n" +
                                    $"Vehículo: {nombreVehiculo}\n" +
                                    $"Vendedor: {nombreVendedor}",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    vehiculoDao.ActualizarVehiculo(_vehiculo.Marca, _vehiculo.Modelo, _vehiculo.Anio,
                                                _vehiculo.Marca, _vehiculo.Modelo, _vehiculo.Anio,
                                                _vehiculo.Color, "VENDIDO", _vehiculo.TipoCombustible,
                                                _vehiculo.Descripcion, (int)venta.PrecioVenta, _vehiculo.Kilometraje);
                }
                else
                {
                    MessageBox.Show("Error al registrar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
