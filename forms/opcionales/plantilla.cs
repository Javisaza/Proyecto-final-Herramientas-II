using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AutoCare.forms.opcionales;
using AutoCare.Clases;


namespace AutoCare
{
    public partial class plantilla : Form
    {
        public plantilla()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


       private void plantilla_Load(object sender, EventArgs e)
        {
            if (SesionUsuario.Usuario != null)
            {
                btnUser1.Text = SesionUsuario.Usuario.Username;

                if (SesionUsuario.Usuario.Rol == "Invitado")
                {
                    btnUser1.Visible = false;
                    btnUser3.Visible = false;
                    btnUser4.Text = "Iniciar Sesión";
                    pnlUsuario.Size = new Size(175, 45);
                    
                }
                else
                {
                    btnUser1.Visible = true;
                    btnUser3.Visible = true;
                    btnUser4.Text = "Cerrar Sesión";
                    pnlUsuario.Size = new Size(175, 135);
                }
            }
            else
            {
                btnUser1.Text = "Invitado";
                btnUser1.Visible = false;
                btnUser3.Visible = false;
                btnUser4.Text = "Iniciar Sesión";
                pnlUsuario.Size = new Size(175, 45);
            }
        }
       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Form actual = this.FindForm();

            if (!(actual is InfoVehiculo))
            {
                Application.Exit();
                return;
            }

            CatalogoCars catalogoCars = new CatalogoCars();
            catalogoCars.Show();
            actual.Hide(); 
        }

        private void btnMinMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lblCatalogo_Click(object sender, EventArgs e)
        {
            new CatalogoCars().Show();
            this.Hide();
        }

        private void btnCerrar_MouseMove(object sender, MouseEventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Transparent;

        }

        private void plantilla_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pnlUsuario.Visible = true;
            pnlUsuario.BringToFront();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
          
            pnlUsuario.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pnlUsuario.Visible)
                pnlUsuario.Visible = false;
            else
                pnlUsuario.Visible = true;
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

        private void btnUser4_Click(object sender, EventArgs e)
        {
            if (btnUser4.Text == "Cerrar Sesión")
            {
                new PreLogin().Show();
                this.Hide();
            }
            else
            {
                new Login().Show();
                this.Hide();
            }
        }

        private void btnUser1_Click(object sender, EventArgs e)
        {

        }
    }
}
