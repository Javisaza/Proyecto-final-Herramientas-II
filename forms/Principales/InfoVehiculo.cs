using AutoCare.forms.formVentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoCare.Clases;

namespace AutoCare
{
    public partial class InfoVehiculo : AutoCare.plantilla
    {
        private Vehiculos _vehiculo;

        public InfoVehiculo(Vehiculos vehiculo)
        {
            InitializeComponent();
            _vehiculo = vehiculo;

            lblTitulo.Text = $"{vehiculo.Marca} {vehiculo.Modelo}";
            lblMarca.Text = "Marca: "+vehiculo.Marca;
            lblModelo.Text = "Modelo: "+vehiculo.Modelo;
            lblAnio.Text = "Año: "+vehiculo.Anio.ToString();
            lblKm.Text = "KM: "+vehiculo.Kilometraje.ToString();
            lblColor.Text = "Color: "+vehiculo.Color;
            lblCombustible.Text = "Combustible: "+vehiculo.TipoCombustible;
            txtEspecs.Text = vehiculo.Descripcion;
            lblPrecio.Text = $"${vehiculo.Precio:N0}";
            lblPrecioAntiguo.Text = $"${(vehiculo.Precio * 1.10m):N0}";
            string auto = vehiculo.Marca + " " + vehiculo.Modelo +" "+vehiculo.Anio;
            CargarImagenes(vehiculo.Marca, vehiculo.Modelo, vehiculo.Anio);
        }
        public int IdVehiculoActual { get; private set; }

        public InfoVehiculo(int auto)
        {
            InitializeComponent();
            IdVehiculoActual = auto;
        }

        private void InfoVehiculo_Load(object sender, EventArgs e)
        {
            if (SesionUsuario.Usuario != null)
            {
                if (SesionUsuario.Usuario.Rol == "Admin" || SesionUsuario.Usuario.Rol == "Vendedor")
                {
                    btnReservarVisita.Text = "Vender Auto";
                    lblAdmin.Visible = true;
                }
                else
                {
                    btnReservarVisita.Text = "Reservar Visita";
                    lblAdmin.Visible = false;
                }
            }
        }
        private void CargarImagenes(string marca, string modelo, int anio)
        {
            string basePath = Path.Combine(Application.StartupPath, "ImagenesVehiculos");
            string carpetaVehiculo = Path.Combine(basePath, $"{marca}_{modelo}_{anio}");

            if (Directory.Exists(carpetaVehiculo))
            {
                var archivos = Directory.GetFiles(carpetaVehiculo, "*.*")
                                        .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png") || f.EndsWith(".jpeg"))
                                        .ToArray();

                if (archivos.Length > 0)
                {
                    picCar.Image = Image.FromFile(archivos[0]);
                    picCar.SizeMode = PictureBoxSizeMode.Zoom;

                    foreach (var ruta in archivos)
                    {
                        var pic = new PictureBox
                        {
                            Image = Image.FromFile(ruta),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Width = 100,
                            Height = 75,
                            Margin = new Padding(5)
                        };
                        flowLayoutPanelGaleria.Controls.Add(pic);
                    }
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

        private void btnReservarVisita_Click(object sender, EventArgs e)
        {
            if (btnReservarVisita.Text == "Vender Auto")
            {
                new formRealizarVenta(_vehiculo).ShowDialog();
            }
            else
            {
                int idVehiculo = this.IdVehiculoActual;
                var formCita = new FormAgendaCita(_vehiculo);
                formCita.ShowDialog();
            }

        }

        private void lblKm_Click(object sender, EventArgs e)
        {

        }
    }

}
