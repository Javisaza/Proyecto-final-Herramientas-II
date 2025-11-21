using AutoCare.Clases;
using AutoCare.forms.administrador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCare
{
    public partial class HomeUsuario1 : AutoCare.plantilla
    {
        public HomeUsuario1()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new GestionUsuarios().Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new GestionVehiculos().Show();
            this.Hide();
        }

        private void HomeUsuario1_Load(object sender, EventArgs e)
        {
            if(SesionUsuario.Usuario != null)
            {
                if (SesionUsuario.Usuario.Rol == "Administrador" || SesionUsuario.Usuario.Rol == "Admin")
                {
                    pnlAdmOtros.Visible = true;
                    pnlAdmUser.Visible = true;
                    pnlAdmCar.Visible = true;
                }
                else 
                {
                    pnlAdmCar.Visible = false;
                    pnlAdmUser.Visible = false;
                    pnlAdmOtros.Visible = false;
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new GestionCitas().Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new GestionVentas().Show();
        }
    }
}
