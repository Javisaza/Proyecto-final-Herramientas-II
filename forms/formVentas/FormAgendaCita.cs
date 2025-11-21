using AutoCare.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCare.forms.formVentas
{
    public partial class FormAgendaCita : AutoCare.plantilla
    {
        private Vehiculos _Vehiculo;

        public FormAgendaCita(Vehiculos formVehiculo)
        {
            InitializeComponent();
            _Vehiculo = formVehiculo;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var vehiculoDAO = new VehiculoDAO();
            int? idVehiculo = vehiculoDAO.ObtenerIdVehiculo(_Vehiculo.Marca, _Vehiculo.Modelo, _Vehiculo.Anio);

            if (idVehiculo == null)
            {
                MessageBox.Show("No se encontró el vehículo especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Captura de datos
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string email = txtEmail.Text.Trim();
            string identificacion = txtID.Text.Trim();
            string motivo = cmbTipVisita.Text.Trim();
            DateTime fechaHora = DateFecha.Value;

            // Validaciones previas
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(identificacion))
            {
                MessageBox.Show("La identificación es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("El correo electrónico es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Debes seleccionar el tipo de visita.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fechaHora < DateTime.Now)
            {
                MessageBox.Show("La fecha de la cita no puede ser en el pasado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si todo cumple, recién aquí se guarda la cita
            var citaDAO = new CitaDAO();
            int idCliente = citaDAO.ObtenerOInsertarCliente(nombre, apellido, telefono, email, identificacion);
            bool exito = citaDAO.AgendarCita(nombre, apellido, email, telefono, fechaHora, motivo, idVehiculo.Value, idCliente, identificacion);

            if (exito)
            {
                MessageBox.Show("Cita agendada correctamente.");
                LimpiarFormulario();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo agendar la cita.");
                LimpiarFormulario();
                this.Close();
            }
        }
        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtID.Clear();
            cmbTipVisita.SelectedIndex = -1;
            DateFecha.Value = DateTime.Now;
        }

        private void FormAgendaCita_Load(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
