using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AutoCare.Clases.UsuarioActual;
using AutoCare.Clases;


namespace AutoCare
{
    public partial class Login : Form
    {
        bool verContrasena = false;
        private readonly UsuarioDAO _usuarioDAO = new UsuarioDAO();
        public Login()
        {
            InitializeComponent();

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "Contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.LightGray;
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "Contraseña";
                txtContrasena.ForeColor = Color.DimGray;
                txtContrasena.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnVerPass_Click(object sender, EventArgs e)
        {
            if (verContrasena == false )
            {
                btnVerPass.Image = Image.FromFile(@"Imagenes\eye-crossed.png");
                txtContrasena.UseSystemPasswordChar = false;
                verContrasena = true;
            }
            else if (verContrasena == true)
            {
                btnVerPass.Image = Image.FromFile(@"Imagenes\eye.png");
                txtContrasena.UseSystemPasswordChar = true;
                verContrasena = false;
            }
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

            if (txtContrasena.Text != "Contraseña" && txtContrasena.Text != "")
            {
                btnVerPass.Visible = true;
            }
            else
            {
                btnVerPass.Visible = false;
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            // 1. Validaciones de Interfaz (igual que tu código original)
            if (contrasena == "Contraseña" || string.IsNullOrEmpty(contrasena))
            {
                lblError.Text = "     Ingrese su contraseña";
                lblError.Visible = true;
                txtContrasena.Focus();
                return;
            }
            else if (usuario == "Usuario" || string.IsNullOrEmpty(usuario))
            {
                lblError.Text = "     Ingrese su usuario";
                lblError.Visible = true;
                txtUsuario.Focus();
                return;
            }


            // Llama al método que consulta PostgreSQL
            if (_usuarioDAO.AutenticarUsuario(usuario, contrasena))
            {
                // CREDENCIALES VÁLIDAS: Mismas acciones que tenías para el acceso exitoso
                string username = txtUsuario.Text;
                string password = txtContrasena.Text;

                var dao = new UsuarioDAO();
                var user = dao.ObtenerDatosUsuario(username, password);

                if (usuario != null)
                {
                    SesionUsuario.Usuario = user;
                    new FormHome1().Show();
                    this.Hide();

                }
                else
                {
                    // CREDENCIALES INVÁLIDAS: Mismas acciones que tenías para el acceso fallido
                    lblError.Text = "     Usuario o contraseña incorrecta";
                    lblError.Visible = true;

                    // Limpiar campos, restablecer estado, etc. (manteniendo tus propiedades)
                    txtContrasena.Text = "";
                    txtUsuario.Text = "";
                    txtContrasena.UseSystemPasswordChar = false;
                    btnVerPass.Visible = false;
                    verContrasena = false;
                    txtUsuario.Focus();
                }
            }else
            {
                lblError.Text = "     Usuario o contraseña incorrecta";
                lblError.Visible = true;

                // Limpiar campos, restablecer estado, etc. (manteniendo tus propiedades)
                txtContrasena.Text = "";
                txtUsuario.Text = "";
                txtContrasena.UseSystemPasswordChar = true;
                btnVerPass.Visible = false;
                verContrasena = false;
                txtUsuario.Focus();
            }
        }

        private void btnCerrar_MouseMove(object sender, MouseEventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Transparent;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FormHome1 home = new FormHome1();
            home.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
