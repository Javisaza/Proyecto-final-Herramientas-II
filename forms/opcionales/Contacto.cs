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
    public partial class FormContacto : AutoCare.plantilla
    {
        public FormContacto()
        {
            InitializeComponent();
        }

        private void FormContacto_Load(object sender, EventArgs e)
        {
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
