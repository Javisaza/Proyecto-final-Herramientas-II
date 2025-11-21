using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoCare
{
    public partial class FormCarga : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public FormCarga()
        {
            InitializeComponent();
            InicializarCarga();
        }
        private void carga_Load(object sender, EventArgs e)
        {
            picLogo.Image = Image.FromFile(@"media\logo.gif");
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void InicializarCarga()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            timer.Interval = 50; // velocidad de carga
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 2;
                lblEstado.Text = $"Cargando... {progressBar1.Value}%";
            }
            else
            {
                timer.Stop();
                lblEstado.Text = "Carga completa";
                this.Hide();
                FormHome1 homeForm = new FormHome1();
                homeForm.Show();
            }
        }
        
    }
}
