using ConnectApp.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCare.forms.administrador
{
    public partial class GestionVentas : AutoCare.plantilla
    {
        public GestionVentas()
        {
            InitializeComponent();
        }

        private void GestionVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();
        }
        private void CargarVentas()
        {
            var conexion = new DatabaseConnection();
            var ventasDAO = new VentasDAO(conexion);
            dgvVentas.DataSource = ventasDAO.ObtenerVentasDetalladas();

            dgvVentas.Columns["id_venta"].HeaderText = "ID Venta";
            dgvVentas.Columns["cliente"].HeaderText = "Cliente";
            dgvVentas.Columns["vehiculo"].HeaderText = "Vehículo";
            dgvVentas.Columns["vendedor"].HeaderText = "Vendedor";
            dgvVentas.Columns["fecha_venta"].HeaderText = "Fecha";
            dgvVentas.Columns["monto_total"].HeaderText = "Monto Total";
            dgvVentas.Columns["metodo_pago"].HeaderText = "Método de Pago";
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
    }
}
