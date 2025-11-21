using AutoCare.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO; // Asegurar que System.IO esté incluido para la gestión de imágenes

namespace AutoCare.forms.administrador
{
    public partial class GestionVehiculos : AutoCare.plantilla
    {
        // 1. CAMPOS Y PROPIEDADES PRIVADAS
        private readonly VehiculoDAO _VehiculoDAO = new VehiculoDAO();
        private string _marcaOriginal;
        private string _modeloOriginal;
        private int _anioOriginal;
        private bool _modoEdicionActivo = false;

        // 2. CONSTRUCTOR E INICIALIZACIÓN
        public GestionVehiculos()
        {
            InitializeComponent();

            // Configuración inicial de DataGridView
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.ReadOnly = true;
            pnlNuevoVehiculo.Visible = false; // Ocultar panel de nuevo vehículo al inicio

            // Suscripciones de Eventos del Formulario
            this.Shown += FormGestionVehiculos_Shown;

            // Suscripciones de Eventos de DataGridView (Lógica de Edición)
            dgvVehiculos.CellBeginEdit += dgvVehiculos_CellBeginEdit;
            dgvVehiculos.CellEndEdit += dgvVehiculos_CellEndEdit;

            // Suscripciones de Eventos de Botones de Acción
            // NOTA: Asegúrate de que btnElimiar esté declarado en tu diseñador
            btnElimiar.Click += btnEliminarVehiculo_Click;

            // Suscripciones de Eventos de Agregar/Guardar/Cancelar Nuevo Vehículo
            btnAgregar.Click += btnAgregar_Click;
            btnGuardarNuevo.Click += btnGuardarNuevo_Click;
            btnCancelarNuevo.Click += btnCancelarNuevo_Click;
            btnHabilitarEdicion.Click += btnHabilitarEdicionVehiculos_Click;
            btnCargarImagenes.Click += btnCargarImagenes_Click;
        }

        // 3. LÓGICA DE CARGA DE DATOS
        private void FormGestionVehiculos_Shown(object sender, EventArgs e)
        {
            // Usamos BeginInvoke para asegurar que la UI se pinte antes de cargar datos pesados.
            this.BeginInvoke((MethodInvoker)delegate { CargarVehiculos(); });
        }

        private void CargarVehiculos()
        {
            try
            {
                // Este método ObtenerTodosLosVehiculos llama a ObtenerVehiculosFiltrados con filtros vacíos.
                DataTable vehiculos = _VehiculoDAO.ObtenerTodosLosVehiculos();

                if (vehiculos.Rows.Count > 0)
                {
                    dgvVehiculos.DataSource = vehiculos;
                }
                else
                {
                    dgvVehiculos.DataSource = null;
                    MessageBox.Show("No se encontraron vehículos en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enlazar datos al DataGrid: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        // 4. LÓGICA DE CREACIÓN (AGREGAR NUEVO VEHÍCULO)
        // ====================================================================

        private void LimpiarControlesNuevoVehiculo()
        {
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtColor.Text = "";
            txtPrecio.Text = "";
            txtAnio.Text = "";
            txtDescripcion.Text = "";
            txtKilometraje.Text = "";
            if (cmbtipoGasolina.Items.Count > 0) cmbtipoGasolina.SelectedIndex = 0;
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_modoEdicionActivo)
            {
                MessageBox.Show("Finalice la edición actual del DataGrid antes de agregar un nuevo vehículo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pnlNuevoVehiculo.Visible = true;
            LimpiarControlesNuevoVehiculo();
            txtMarca.Focus();
            pnlNuevoVehiculo.BringToFront();
        }

        private void btnCancelarNuevo_Click(object sender, EventArgs e)
        {
            pnlNuevoVehiculo.Visible = false;
            LimpiarControlesNuevoVehiculo();
        }

        private void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            // Validaciones de parsing robustas (importante para evitar errores de DB)
            if (!int.TryParse(txtAnio.Text.Trim(), out int anio) || anio == 0)
            {
                MessageBox.Show("El Año debe ser un número válido (mayor a 0).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtPrecio.Text.Trim(), out int precio) || precio < 0)
            {
                MessageBox.Show("El Precio debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtKilometraje.Text.Trim(), out int kilometraje) || kilometraje < 0)
            {
                MessageBox.Show("El Kilometraje debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string marca = txtMarca.Text.Trim().ToUpper();
            string modelo = txtModelo.Text.Trim().ToUpper();
            string color = txtColor.Text.Trim().ToUpper();
            string descripcion = txtDescripcion.Text.Trim();
            string tipoCombustible = cmbtipoGasolina.SelectedItem?.ToString().ToUpper() ?? "GASOLINA CORRIENTE";
            string estado = cmbEstado.SelectedItem?.ToString().ToUpper() ?? "NUEVO";
            DateTime fechaRegistro = DateTime.Now;


            if (string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(color) ||
                string.IsNullOrEmpty(estado))
            {
                MessageBox.Show("Los campos de Marca, Modelo, Color y Estado son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamada al método CrearVehiculo 
            bool creado = _VehiculoDAO.CrearVehiculo(marca, modelo, anio, precio, kilometraje,
                                                     color, descripcion, estado, tipoCombustible, fechaRegistro);

            if (creado)
            {
                MessageBox.Show("Vehículo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlNuevoVehiculo.Visible = false;
                LimpiarControlesNuevoVehiculo();
                CargarVehiculos();
            }
        }

        // ====================================================================
        // 5. LÓGICA DE ACTUALIZACIÓN (EDICIÓN EN DATA GRID VIEW)
        // ====================================================================

        private void btnHabilitarEdicionVehiculos_Click(object sender, EventArgs e)
        {
            _modoEdicionActivo = !_modoEdicionActivo;
            dgvVehiculos.ReadOnly = !_modoEdicionActivo;
            btnHabilitarEdicion.Text = _modoEdicionActivo ? "Guardar Cambios" : "Habilitar Edición";

            if (!_modoEdicionActivo)
            {
                // Al salir del modo edición, recargar para reflejar posibles errores y consolidar los datos.
                CargarVehiculos();
            }
        }

        private void dgvVehiculos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Guardar los valores originales antes de la edición (claves primarias)
            var row = dgvVehiculos.Rows[e.RowIndex];
            _marcaOriginal = row.Cells["marca"].Value?.ToString();
            _modeloOriginal = row.Cells["modelo"].Value?.ToString();
            _anioOriginal = Convert.ToInt32(row.Cells["anio"].Value);
        }

        // ** MÉTODO CORREGIDO **
        private void dgvVehiculos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvVehiculos.Rows[e.RowIndex];

            // 1. Lectura de campos de texto (cadenas)
            string nuevaMarca = row.Cells["marca"].Value?.ToString()?.Trim().ToUpper() ?? _marcaOriginal;
            string nuevoModelo = row.Cells["modelo"].Value?.ToString()?.Trim().ToUpper() ?? _modeloOriginal;
            string color = row.Cells["color"].Value?.ToString()?.Trim().ToUpper() ?? "";
            string tipoCombustible = row.Cells["tipo_combustible"].Value?.ToString()?.Trim().ToUpper() ?? "";
            string descripcion = row.Cells["descripcion"].Value?.ToString()?.Trim() ?? "";
            string estado = row.Cells["estado"].Value?.ToString()?.Trim().ToUpper() ?? "";

            // 2. CONVERSIONES ROBUSTAS DE ENTEROS (Solución al error 22P02)
            // Si el valor de la celda es null, "" o texto inválido, int.TryParse asignará 0.
            int nuevoanio = 0;
            int precio = 0;
            int kilometraje = 0;

            // Si la conversión falla, los valores serán 0, lo cual es manejable por el DAO.
            int.TryParse(row.Cells["anio"].Value?.ToString(), out nuevoanio);
            int.TryParse(row.Cells["precio"].Value?.ToString(), out precio);
            int.TryParse(row.Cells["kilometraje"].Value?.ToString(), out kilometraje);

            // Validación mínima para evitar actualización si los datos clave están vacíos/0.
            if (string.IsNullOrEmpty(nuevaMarca) || string.IsNullOrEmpty(nuevoModelo) || nuevoanio == 0)
            {
                MessageBox.Show("La Marca, Modelo y Año no pueden quedar vacíos o en cero.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarVehiculos(); // Recargar para revertir
                return;
            }

            // Llamada al método ActualizarVehiculo
            bool actualizado = _VehiculoDAO.ActualizarVehiculo(_marcaOriginal, _modeloOriginal, _anioOriginal,
                                                               nuevaMarca, nuevoModelo, nuevoanio,
                                                               color, estado, tipoCombustible, descripcion, precio, kilometraje);

            if (!actualizado)
            {
                MessageBox.Show("No se pudo actualizar el vehículo. Revise si la clave primaria (Marca, Modelo, Año) ha sido modificada a un valor ya existente o si ocurrió un error de DB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CargarVehiculos(); // Recargar para mostrar los datos originales o actualizados
            }
        }

        // ====================================================================
        // 6. LÓGICA DE ELIMINACIÓN
        // ====================================================================

        private void btnEliminarVehiculo_Click(object sender, EventArgs e)
        {
            if (_modoEdicionActivo)
            {
                MessageBox.Show("Finalice la edición actual antes de eliminar un vehículo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvVehiculos.SelectedRows.Count > 0)
            {
                var row = dgvVehiculos.SelectedRows[0];
                string marca = row.Cells["marca"].Value?.ToString();
                string modelo = row.Cells["modelo"].Value?.ToString();
                int anio = Convert.ToInt32(row.Cells["anio"].Value);

                DialogResult result = MessageBox.Show($"¿Está seguro de eliminar el vehículo {marca} {modelo} {anio}?",
                                                     "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (_VehiculoDAO.EliminarVehiculo(marca, modelo, anio))
                    {
                        MessageBox.Show("Vehículo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarVehiculos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el vehículo.", "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un vehículo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ====================================================================
        // 7. LÓGICA DE IMÁGENES (CORREGIDO: Eliminación de pictureBox1)
        // ====================================================================

        private void btnCargarImagenes_Click(object sender, EventArgs e)
        {
            if (dgvVehiculos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un vehículo primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvVehiculos.SelectedRows[0];
            string marca = row.Cells["marca"].Value?.ToString();
            string modelo = row.Cells["modelo"].Value?.ToString();

            // Usamos TryParse para manejar el caso de que el año no sea válido
            if (!int.TryParse(row.Cells["anio"].Value?.ToString(), out int anio))
            {
                MessageBox.Show("El año del vehículo no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            dialogo.Title = "Selecciona una imagen";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                // Guardar en carpeta del vehículo
                _VehiculoDAO.GuardarImagenVehiculo(marca, modelo, anio, dialogo.FileName);

                // La lógica de mostrar la imagen en un control PictureBox fue eliminada para resolver el error anterior.
            }
        }

        // ====================================================================
        // 8. NAVEGACIÓN (Fragmento del código original)
        // ====================================================================
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

        // Métodos vacíos proporcionados por el usuario
        private void btnGuardarNuevo_Click_1(object sender, EventArgs e)
        {

        }

        private void GestionVehiculos_Load(object sender, EventArgs e)
        {

        }
    }
}