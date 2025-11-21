using AutoCare.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCare
{
    public partial class VehiculoCard : UserControl
    {
        private Vehiculos _vehiculo;
        private VehiculoDAO vehiculoDao = new VehiculoDAO();
        public VehiculoCard(Vehiculos vehiculo)
        {
            InitializeComponent();
            _vehiculo = vehiculo;

            lblCarMarca1.Text = $"{vehiculo.Marca}";
            lblCar1.Text = $"{vehiculo.Modelo}";
            lblPrecioCar1.Text = $"${vehiculo.Precio:N0}";
            string estado = vehiculoDao.ObtenerEstadoVehiculoPorDatos(_vehiculo.Marca, _vehiculo.Modelo, _vehiculo.Anio);
            if (estado == "VENDIDO")
            {
                guna2Button1.Enabled = false;
                guna2Button1.Text = "VENDIDO";
                
            }

            var imagen = ObtenerPrimeraImagenVehiculo(vehiculo.Marca, vehiculo.Modelo, vehiculo.Anio);
            if (imagen != null)
            {
                pictureBox4.Image = imagen;
                pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            }


        }

        private void btnVerAuto_Click(object sender, EventArgs e)
        {
            if(_vehiculo.Estado == "VENDIDO")
            {
                MessageBox.Show("Este vehículo ya ha sido vendido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                var detalleForm = new InfoVehiculo(_vehiculo);
                detalleForm.ShowDialog();
            }
                
        }

        public Image ObtenerPrimeraImagenVehiculo(string marca, string modelo, int anio)
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
                    return Image.FromFile(archivos[0]); // primera imagen encontrada
                }
            }

            return null; // si no hay imagen
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new InfoVehiculo(_vehiculo).Show();
            this.FindForm().Hide();
        }
    }
}
