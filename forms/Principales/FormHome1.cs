using AutoCare.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCare
{
    public partial class FormHome1 : AutoCare.plantilla
    {
        public FormHome1()
        {
            InitializeComponent();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
        private void btnVerMas_MouseMove(object sender, MouseEventArgs e)
        {
            btnVerMas.FillColor = Color.LightCoral;
        }

        #endregion

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void btnVerMas_MouseLeave(object sender, EventArgs e)
        {
            btnVerMas.FillColor = Color.IndianRed;
        }

        private void FormHome1_Load(object sender, EventArgs e)
        {
            CargarCatalogo();
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

        private void CargarCatalogo()
        {
            var dao = new VehiculoDAO();
            var service = new VehiculoService();

            DataTable dt = dao.ObtenerTodosLosVehiculos();
            List<Vehiculos> lista = service.MapearVehiculos(dt);

            flowLayoutPanelCatalogo.SuspendLayout();
            flowLayoutPanelCatalogo.Controls.Clear();

            int maxVehiculos = 5;
            int contador = 0;

            foreach (var v in lista)
            {
                if (contador >= maxVehiculos)
                    break;

                var card = new VehiculoCard(v);
                flowLayoutPanelCatalogo.Controls.Add(card);
                contador++;
            }

            flowLayoutPanelCatalogo.ResumeLayout();
        }

        private void flowLayoutPanelCatalogo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
