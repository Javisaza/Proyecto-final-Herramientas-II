using AutoCare.Clases;
using ConnectApp.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCare
{
    public partial class CatalogoCars : AutoCare.plantilla
    {
        public CatalogoCars()
        {
            InitializeComponent();
            // Asocia el evento Click del botón de Filtrar (btnFiltra) a la función de aplicar filtros
            btnFiltra.Click += btnAplicarFiltros_Click;
            // Asocia el evento Click del botón de Quitar Filtros (btnQuitarFiltros)
            btnQuitarFiltros.Click += btnQuitarFiltros_Click;


        }

        // Limpia los campos de filtro en la interfaz de usuario
        private void LimpiarFiltros()
        {
            cmbMarca.SelectedIndex = 0;
            txtPrecioDesde.Text = "";
            txtPrecioHasta.Text = "";
            cmbTipoCombustible.SelectedIndex = -1;
            txtKmDesde.Text = "";
            txtKmHasta.Text = "";
        }
        // Evento que se dispara al hacer click en el botón "Filtra"
        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            CargarCatalogo(aplicarFiltros: true);
        }

        // Evento que se dispara al hacer click en el botón "Quitar Filtros"
        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            CargarCatalogo(); // Recarga el catálogo sin filtros
        }


        private void CatalogoCars_Load(object sender, EventArgs e)
        {
            CargarCatalogo();
            CargarMarcas();
            if (SesionUsuario.Usuario != null)
            {
                if (SesionUsuario.Usuario.Rol == "Admin" || SesionUsuario.Usuario.Rol == "Vendedor")
                {
                    lblAdmin.Visible = true;
                }
                else
                {
                    lblAdmin.Visible = false;
                }
            }

        }
        private void CargarMarcas()
        {
            var conexion = new DatabaseConnection();
            var vehiculoDAO = new VehiculoDAO();
            var marcas = vehiculoDAO.ObtenerMarcasUnicas();

            cmbMarca.Items.Clear();
            cmbMarca.Items.AddRange(marcas.ToArray());
        }

        // Mapea los resultados del DataTable a una lista de objetos Vehiculos
        public List<Vehiculos> MapearVehiculos(DataTable dt)
        {
            var lista = new List<Vehiculos>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Vehiculos
                {
                    Marca = row["marca"].ToString(),
                    Modelo = row["modelo"].ToString(),
                    Anio = Convert.ToInt32(row["anio"]),
                    Color = row["color"].ToString(),
                    TipoCombustible = row["tipo_combustible"].ToString(),
                    Descripcion = row["descripcion"].ToString(),
                    Precio = Convert.ToDecimal(row["precio"]),
                    Kilometraje = Convert.ToInt32(row["kilometraje"])
                });
            }
            return lista;
        }
        public void CargarCatalogo(bool aplicarFiltros = false)
        {
            string marca = null;
            decimal precioMin = 0;
            decimal precioMax = 0;
            string tipoCombustible = null;
            int kmMin = 0;
            int kmMax = 0;

            if (aplicarFiltros)
            {
                // 1. Obtiene Marca, Precio, Combustible y Kilometraje del formulario
                if (cmbMarca.SelectedItem != null && cmbMarca.SelectedItem.ToString() != "Todas")
                {
                    marca = cmbMarca.SelectedItem.ToString();
                }

                // Captura y parsea precios (quita símbolos y espacios)
                decimal.TryParse(txtPrecioDesde.Text.Replace("$", "").Replace(",", "").Trim(), out precioMin);
                decimal.TryParse(txtPrecioHasta.Text.Replace("$", "").Replace(",", "").Trim(), out precioMax);
                if (precioMax > 0 && precioMax < precioMin) precioMax = 0; // Asegura coherencia

                if (cmbTipoCombustible.SelectedItem != null && cmbTipoCombustible.SelectedItem.ToString() != "Todos")
                {
                    tipoCombustible = cmbTipoCombustible.SelectedItem.ToString();
                }

                // Captura y parsea kilometraje
                int.TryParse(txtKmDesde.Text.Trim(), out kmMin);
                int.TryParse(txtKmHasta.Text.Trim(), out kmMax);
                if (kmMax > 0 && kmMax < kmMin) kmMax = 0; // Asegura coherencia
            }

            var dao = new VehiculoDAO();

            // Llama al DAO para obtener datos, pasándole los valores de filtro o nulo/cero
            DataTable dt = dao.ObtenerVehiculosFiltrados(marca, precioMin, precioMax, tipoCombustible, kmMin, kmMax);

            var lista = MapearVehiculos(dt);

            flowLayoutPanelCatalogo.Controls.Clear();

            // Muestra un mensaje si no se encontraron resultados al aplicar un filtro
            if (lista.Count == 0 && aplicarFiltros)
            {
                MessageBox.Show("No se encontraron vehículos con los filtros seleccionados.", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Crea y añade las tarjetas (VehicleCard) al FlowLayoutPanel
            foreach (var v in lista)
            {
                if (v.Estado != "Vendido")
                {
                    ; // Solo muestra vehículos disponibles
                    var card = new VehiculoCard(v);
                    flowLayoutPanelCatalogo.Controls.Add(card);
                }
            }
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

        private void flowLayoutPanelCatalogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQuitarFiltros_Click_1(object sender, EventArgs e)
        {

        }
    }
}
