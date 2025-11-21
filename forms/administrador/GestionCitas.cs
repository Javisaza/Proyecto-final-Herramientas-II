using AutoCare.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCare.forms.administrador
{
    public partial class GestionCitas : AutoCare.plantilla
    {
        private readonly CitaDAO _citaDAO = new CitaDAO();
        public GestionCitas()
        {
            InitializeComponent();
            dgvCitas.AllowUserToAddRows = false;
            dgvCitas.ReadOnly = true; // Empieza en modo solo lectura

        }

        private void GestionCitas_Load(object sender, EventArgs e)
        {
            CargarCitas();

        }

        // ====================================================================
        // 5. LÓGICA DE ACTUALIZACIÓN (EDICIÓN EN DATA GRID VIEW)
        // ====================================================================

        private int _idCitaOriginal;
        private bool _modoEdicionActivo = false;

        private void btnHabilitarEdicionCitas_Click(object sender, EventArgs e)
        {
            if (!_modoEdicionActivo)
            {

                _modoEdicionActivo = true;
                dgvCitas.ReadOnly = false;
                btnHabilitarEdicion.Text = "Guardar Cambios";
                MessageBox.Show("Modo Edición Activado. Haga doble clic en la celda para modificar y luego presione 'Guardar Cambios'.", "Modo Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GuardarCambiosCitas();

                _modoEdicionActivo = false;
                dgvCitas.ReadOnly = true;
                btnHabilitarEdicion.Text = "Habilitar Edición";
                CargarCitas();
            }
        }
        private void CargarCitas()
        {
            var dt = _citaDAO.ObtenerCitasConVehiculo();
            dgvCitas.DataSource = dt;

        }

        private void dgvCitas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvCitas.Columns.Contains("id_cita"))
            {
                var row = dgvCitas.Rows[e.RowIndex];
                _idCitaOriginal = Convert.ToInt32(row.Cells["id_cita"].Value);
            }
            else
            {
                _idCitaOriginal = -1;
            }
        }

        private void GuardarCambiosCitas()
        {
            dgvCitas.EndEdit();

            int cambiosGuardados = 0;
            int cambiosFallidos = 0;

            if (dgvCitas.DataSource is DataTable dt)
            {
                var filasModificadas = dt.Select(null, null, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in filasModificadas)
                {
                    try
                    {
                        int idCita = Convert.ToInt32(row["id_cita", DataRowVersion.Original]);
                        string nombre = row["nombre_cliente_reserva", DataRowVersion.Current].ToString();
                        string apellido = row["apellido_cliente_reserva", DataRowVersion.Current].ToString();
                        string email = row["email_cliente_reserva", DataRowVersion.Current].ToString();
                        string telefono = row["telefono_cliente_reserva", DataRowVersion.Current].ToString();
                        string identificacion = row["identificacion_cliente_reserva", DataRowVersion.Current].ToString();
                        string motivo = row["motivo", DataRowVersion.Current].ToString();
                        DateTime fechaHora = Convert.ToDateTime(row["fecha_hora_cita", DataRowVersion.Current]);

                        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(email) || fechaHora < DateTime.Now)
                        {
                            MessageBox.Show($"Falla en la validación para la cita #{idCita}. Verifica los campos obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            row.RejectChanges();
                            cambiosFallidos++;
                            continue;
                        }

                        if (_citaDAO.ActualizarCita(idCita, nombre, apellido, email, telefono, identificacion, motivo, fechaHora))
                        {
                            cambiosGuardados++;
                        }
                        else
                        {
                            row.RejectChanges();
                            cambiosFallidos++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al procesar la cita #{_idCitaOriginal}: {ex.Message}", "Error de Procesamiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        row.RejectChanges();
                        cambiosFallidos++;
                    }
                }
            }

            if (cambiosGuardados > 0 || cambiosFallidos > 0)
            {
                MessageBox.Show($"Guardado finalizado: {cambiosGuardados} cita(s) actualizada(s), {cambiosFallidos} con error.", "Guardar Cambios", MessageBoxButtons.OK, (cambiosFallidos == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning));
            }
            else
            {
                MessageBox.Show("No se detectaron cambios pendientes para guardar.", "Guardar Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ====================================================================
        // 6. LÓGICA DE ELIMINACIÓN (DELETE)
        // ====================================================================

        private void btnEliminarCita_Click(object sender, EventArgs e)
        {
            if (_modoEdicionActivo)
            {
                MessageBox.Show("Finalice la edición actual antes de eliminar una cita.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCitas.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCitas.SelectedRows[0];

                if (!dgvCitas.Columns.Contains("id_cita"))
                {
                    MessageBox.Show("La columna 'id_cita' no está disponible.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idCita = Convert.ToInt32(selectedRow.Cells["id_cita"].Value);

                DialogResult result = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar la cita #{idCita}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (_citaDAO.EliminarCita(idCita))
                    {
                        MessageBox.Show("Cita eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la cita. Verifica dependencias o conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnHabilitarEdicion_Click(object sender, EventArgs e)
        {

        }

        private void btnElimiar_Click(object sender, EventArgs e)
        {

        }

        //navegacion
        #region Navegacion
        private void winSercios(object sender, EventArgs e)
        {
            new FormServicio().Show();
            this.Hide();
        }
        private void winHome(object sender, EventArgs e)
        {
            new FormHome1().Show();
            this.Hide();
        }
        private void winContacto(object sender, EventArgs e)
        {
            new FormContacto().Show();
            this.Hide();
        }

        private void winAdmin(object sender, EventArgs e)
        {
            new HomeUsuario1().Show();
            this.Hide();
        }
        private void winCatalogo(object sender, EventArgs e)
        {
            new CatalogoCars().Show();
            this.Hide();
        }
        #endregion
    }
}
