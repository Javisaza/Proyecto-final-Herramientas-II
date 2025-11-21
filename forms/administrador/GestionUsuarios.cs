using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ConnectApp.Database; // Referencia a la capa de datos
using System.ComponentModel; // Se añade si es necesario para DataViewRowState (aunque ya está en System.Data)

namespace AutoCare
{
    public partial class GestionUsuarios : Form
    {
        // ====================================================================
        // 1. CAMPOS Y PROPIEDADES PRIVADAS
        // ====================================================================

        private readonly UsuarioDAO _usuarioDAO = new UsuarioDAO();
        private string _usernameOriginal; // Guarda el username antes de editar la celda
        private bool _modoEdicionActivo = false; // False = Vista (predeterminado), True = Edición

        // ====================================================================
        // 2. CONSTRUCTOR E INICIALIZACIÓN
        // ====================================================================

        public GestionUsuarios()
        {
            InitializeComponent();

            // Configuración inicial de DataGridView
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.ReadOnly = true; // Empieza en modo solo lectura
            pnlNuevoUsuario.Visible = false; // Ocultar panel de nuevo usuario al inicio

            // Suscripciones de Eventos del Formulario
            this.Shown += FormGestionUsuarios_Shown;

            // Suscripciones de Eventos de DataGridView (Lógica de Edición)
            dgvUsuarios.CellBeginEdit += dgvUsuarios_CellBeginEdit;
            dgvUsuarios.CellEndEdit += dgvUsuarios_CellEndEdit; // Aunque el método está vacío, la suscripción se mantiene

            // Suscripciones de Eventos de Botones de Acción
            btnElimiarUser.Click += btnElimiarUser_Click;

            // Suscripciones de Eventos de Agregar/Guardar/Cancelar Nuevo Usuario
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            btnGuardarNuevo.Click += btnGuardarNuevo_Click;
            btnCancelarNuevo.Click += btnCancelarNuevo_Click;
            btnHabilitarEdicionUsers.Click += btnHabilitarEdicionUsers_Click; // Lógica de Guardar/Activar Edición

            // NOTA: Los eventos btnCerrar_Click, btnMin_Click, btnMinMax_Click, 
            // y los eventos MouseMove/MouseLeave para efectos de color deben 
            // estar suscritos en el archivo Designer.cs o aquí si no lo están.
        }

        // ====================================================================
        // 3. LÓGICA DE CARGA DE DATOS Y ROLES
        // ====================================================================

        // Usar BeginInvoke en Shown para deferir la carga y evitar el error reentrante
        private void FormGestionUsuarios_Shown(object sender, EventArgs e)
        {
            // Garantiza que el DataGridView haya terminado su inicialización antes de cargar datos.
            this.BeginInvoke((MethodInvoker)delegate { CargarUsuarios(); });
        }

        private void CargarUsuarios()
        {
            try
            {
                DataTable usuarios = _usuarioDAO.ObtenerTodosLosUsuarios();

                if (usuarios.Rows.Count > 0)
                {
                    dgvUsuarios.DataSource = usuarios;
                    // Ocultar la columna de 'password' por seguridad
                    if (dgvUsuarios.Columns.Contains("password"))
                    {
                        dgvUsuarios.Columns["password"].Visible = false;
                    }
                }
                else
                {
                    dgvUsuarios.DataSource = null; // Limpiar la vista
                    MessageBox.Show("No se encontraron usuarios en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enlazar datos al DataGrid: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRoles()
        {
            if (cmbRolNuevo != null)
            {
                cmbRolNuevo.SelectedIndex = 0; // Rol por defecto
            }
        }

        private void cmbRolNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento se mantiene por si se necesita lógica futura.
        }

        // ====================================================================
        // 4. LÓGICA DE CREACIÓN (AGREGAR NUEVO USUARIO)
        // ====================================================================

        private void LimpiarControlesNuevoUsuario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtUsernameNuevo.Text = "";
            txtPasswordNuevo.Text = "";
            if (cmbRolNuevo.Items.Count > 0) cmbRolNuevo.SelectedIndex = 0;
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            // Comprobación de estado
            if (_modoEdicionActivo)
            {
                MessageBox.Show("Finalice la edición actual del DataGrid antes de agregar un nuevo usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pnlNuevoUsuario.Visible = true;
            LimpiarControlesNuevoUsuario();
            CargarRoles();
            txtNombre.Focus();
        }

        private void btnCancelarNuevo_Click(object sender, EventArgs e)
        {
            pnlNuevoUsuario.Visible = false;
            LimpiarControlesNuevoUsuario();
        }

        private void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            // 1. Recoger datos
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsernameNuevo.Text.Trim();
            string password = txtPasswordNuevo.Text.Trim();
            string rol = cmbRolNuevo.SelectedItem?.ToString() ?? "Vendedor";

            // 2. Validación
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Los campos Usuario, Nombre, Email y Contraseña son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Llamar al DAO para crear
            if (_usuarioDAO.CrearUsuario(nombre, apellido, email, username, password, rol))
            {
                MessageBox.Show("Nuevo usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ocultar el panel, limpiar controles y recargar la tabla principal
                pnlNuevoUsuario.Visible = false;
                LimpiarControlesNuevoUsuario();
                CargarUsuarios();
            }
            // Si falla, el mensaje de error es manejado por el DAO (debe ser capturado y mostrado en el DAO).
        }

        // ====================================================================
        // 5. LÓGICA DE ACTUALIZACIÓN (EDICIÓN EN DATA GRID VIEW)
        // ====================================================================

        private void btnHabilitarEdicionUsers_Click(object sender, EventArgs e)
        {
            if (!_modoEdicionActivo)
            {
                // ACTIVAR MODO EDICIÓN
                if (pnlNuevoUsuario.Visible)
                {
                    MessageBox.Show("Cierre el panel de 'Agregar Nuevo Usuario' antes de habilitar la edición de la tabla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _modoEdicionActivo = true;
                dgvUsuarios.ReadOnly = false;
                btnHabilitarEdicionUsers.Text = "Guardar Cambios";
                btnAgregarUsuario.Enabled = false;
                MessageBox.Show("Modo Edición Activado. Haga doble clic en la celda para modificar y luego presione 'Guardar Cambios'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // DESACTIVAR MODO EDICIÓN Y GUARDAR
                GuardarCambios(); // Intentar guardar los cambios

                _modoEdicionActivo = false;
                dgvUsuarios.ReadOnly = true;
                btnHabilitarEdicionUsers.Text = "Habilitar Edición";
                btnAgregarUsuario.Enabled = true;
                CargarUsuarios(); // Recargar para confirmar y limpiar la edición
            }
        }

        private void dgvUsuarios_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Almacenar el valor original del username antes de la edición para usarlo como clave de actualización.
            if (dgvUsuarios.Columns.Contains("username"))
            {
                var row = dgvUsuarios.Rows[e.RowIndex];
                _usernameOriginal = row.Cells["username"].Value?.ToString();
            }
            else
            {
                _usernameOriginal = null;
            }
        }

        private void dgvUsuarios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GuardarCambios()
        {
            // Detener cualquier edición en curso para forzar la validación de la celda y marcar la fila como Modified
            dgvUsuarios.EndEdit();

            int cambiosGuardados = 0;
            int cambiosFallidos = 0;

            if (dgvUsuarios.DataSource is DataTable dt)
            {
                // Obtener solo las filas que han sido modificadas.
                var filasModificadas = dt.Select(null, null, DataViewRowState.ModifiedCurrent);

                foreach (DataRow row in filasModificadas)
                {
                    try
                    {
                        // Obtener los valores originales y actuales usando DataRowVersion.
                        string oldUsername = row["username", DataRowVersion.Original].ToString();
                        string newUsername = row["username", DataRowVersion.Current].ToString();
                        string nombre = row["nombre", DataRowVersion.Current].ToString();
                        string apellido = row["apellido", DataRowVersion.Current].ToString();
                        string email = row["email", DataRowVersion.Current].ToString();
                        string password = row["password", DataRowVersion.Current].ToString(); // Valor actual (si se editó o el original si no)
                        string rol = row["rol", DataRowVersion.Current].ToString();

                        // Validación mínima (asumiendo que las columnas existen)
                        if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                        {
                            MessageBox.Show($"Falla en la validación para el usuario '{oldUsername}'. Los campos obligatorios no pueden estar vacíos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            row.RejectChanges(); // Revertir cambios en la UI para esta fila
                            cambiosFallidos++;
                            continue;
                        }

                        // Llamar al DAO para la actualización
                        if (_usuarioDAO.ActualizarUsuario(oldUsername, nombre, apellido, email, newUsername, password, rol))
                        {
                            cambiosGuardados++;
                        }
                        else
                        {
                            // Si el DAO reporta un fallo, revertir el cambio visual
                            row.RejectChanges();
                            cambiosFallidos++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al procesar la fila con username original '{_usernameOriginal}': {ex.Message}", "Error de Procesamiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        row.RejectChanges();
                        cambiosFallidos++;
                    }
                }
            }

            if (cambiosGuardados > 0 || cambiosFallidos > 0)
            {
                MessageBox.Show($"Proceso de guardado finalizado: {cambiosGuardados} usuario(s) actualizado(s) correctamente, {cambiosFallidos} fallo(s).", "Guardar Cambios", MessageBoxButtons.OK, (cambiosFallidos == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning));
            }
            else
            {
                MessageBox.Show("No se detectaron cambios pendientes para guardar.", "Guardar Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ====================================================================
        // 6. LÓGICA DE ELIMINACIÓN (DELETE)
        // ====================================================================

        private void btnElimiarUser_Click(object sender, EventArgs e)
        {
            if (_modoEdicionActivo)
            {
                MessageBox.Show("Finalice la edición actual del DataGrid antes de eliminar un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var selectedRow = dgvUsuarios.SelectedRows[0];

                if (!dgvUsuarios.Columns.Contains("username"))
                {
                    MessageBox.Show("La columna 'username' no está disponible para eliminar.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string usernameAEliminar = selectedRow.Cells["username"].Value?.ToString();

                if (string.IsNullOrEmpty(usernameAEliminar))
                {
                    MessageBox.Show("El valor del username en la fila seleccionada es nulo o vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar al usuario '{usernameAEliminar}'?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (_usuarioDAO.EliminarUsuario(usernameAEliminar))
                    {
                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el usuario. Revise la conexión a la base de datos o si el usuario tiene dependencias.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ====================================================================
        // 7. EVENT HANDLERS DE INTERFAZ DE VENTANA (Cerrar, Min/Max)
        // ====================================================================
        // NOTA: Estos métodos fueron tomados del primer código.

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMinMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;
        }

        private void btnCerrar_MouseMove(object sender, MouseEventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave_1(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Transparent;
        }

        private void btnAgregarUsuario_Click_1(object sender, EventArgs e)
        {
            pnlNuevoUsuario.BringToFront();
        }

        private void btnGuardarNuevo_Click_1(object sender, EventArgs e)
        {

        }

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

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnHabilitarEdicionUsers_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pnlNuevoUsuario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void btnElimiarUser_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}