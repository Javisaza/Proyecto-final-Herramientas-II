namespace AutoCare
{
    partial class InfoVehiculo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoVehiculo));
            this.lblAdmin = new System.Windows.Forms.Label();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblSerivicios = new System.Windows.Forms.Label();
            this.lblCatalogo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picCar = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlGenVenta = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutPanelGaleria = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlVenta = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlDescripcion = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCombustible = new System.Windows.Forms.Label();
            this.lblKm = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtEspecs = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnContactarAsesor = new Guna.UI2.WinForms.Guna2Button();
            this.btnReservarVisita = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblPrecioAntiguo = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).BeginInit();
            this.pnlGenVenta.SuspendLayout();
            this.pnlVenta.SuspendLayout();
            this.pnlDescripcion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAdmin
            // 
            this.lblAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdmin.Location = new System.Drawing.Point(932, 53);
            this.lblAdmin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(53, 19);
            this.lblAdmin.TabIndex = 49;
            this.lblAdmin.Text = "Admin";
            this.lblAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdmin.Click += new System.EventHandler(this.winAdmin);
            // 
            // lblContacto
            // 
            this.lblContacto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContacto.AutoSize = true;
            this.lblContacto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContacto.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblContacto.Location = new System.Drawing.Point(1136, 53);
            this.lblContacto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(100, 19);
            this.lblContacto.TabIndex = 50;
            this.lblContacto.Text = "Contactanos";
            this.lblContacto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContacto.Click += new System.EventHandler(this.winContacto);
            // 
            // lblSerivicios
            // 
            this.lblSerivicios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSerivicios.AutoSize = true;
            this.lblSerivicios.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerivicios.Location = new System.Drawing.Point(1065, 53);
            this.lblSerivicios.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSerivicios.Name = "lblSerivicios";
            this.lblSerivicios.Size = new System.Drawing.Size(69, 19);
            this.lblSerivicios.TabIndex = 48;
            this.lblSerivicios.Text = "Serivicios";
            this.lblSerivicios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSerivicios.Click += new System.EventHandler(this.winSercios);
            // 
            // lblCatalogo
            // 
            this.lblCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCatalogo.AutoSize = true;
            this.lblCatalogo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalogo.Location = new System.Drawing.Point(987, 53);
            this.lblCatalogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCatalogo.Name = "lblCatalogo";
            this.lblCatalogo.Size = new System.Drawing.Size(75, 19);
            this.lblCatalogo.TabIndex = 47;
            this.lblCatalogo.Text = "Catalogo";
            this.lblCatalogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCatalogo.Click += new System.EventHandler(this.winCatalogo);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(8, 35);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 53);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.winHome);
            // 
            // picCar
            // 
            this.picCar.BackColor = System.Drawing.Color.Transparent;
            this.picCar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picCar.BackgroundImage")));
            this.picCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picCar.BorderRadius = 10;
            this.picCar.FillColor = System.Drawing.Color.Transparent;
            this.picCar.ImageRotate = 0F;
            this.picCar.Location = new System.Drawing.Point(185, 137);
            this.picCar.Name = "picCar";
            this.picCar.Size = new System.Drawing.Size(501, 374);
            this.picCar.TabIndex = 52;
            this.picCar.TabStop = false;
            // 
            // pnlGenVenta
            // 
            this.pnlGenVenta.BackColor = System.Drawing.Color.Transparent;
            this.pnlGenVenta.BorderRadius = 20;
            this.pnlGenVenta.Controls.Add(this.flowLayoutPanelGaleria);
            this.pnlGenVenta.Controls.Add(this.pnlVenta);
            this.pnlGenVenta.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.pnlGenVenta.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pnlGenVenta.Location = new System.Drawing.Point(169, 113);
            this.pnlGenVenta.Name = "pnlGenVenta";
            this.pnlGenVenta.Size = new System.Drawing.Size(942, 553);
            this.pnlGenVenta.TabIndex = 57;
            this.pnlGenVenta.UseTransparentBackground = true;
            // 
            // flowLayoutPanelGaleria
            // 
            this.flowLayoutPanelGaleria.Location = new System.Drawing.Point(16, 405);
            this.flowLayoutPanelGaleria.Name = "flowLayoutPanelGaleria";
            this.flowLayoutPanelGaleria.Size = new System.Drawing.Size(501, 137);
            this.flowLayoutPanelGaleria.TabIndex = 2;
            // 
            // pnlVenta
            // 
            this.pnlVenta.AutoScroll = true;
            this.pnlVenta.BorderRadius = 15;
            this.pnlVenta.Controls.Add(this.pnlDescripcion);
            this.pnlVenta.Controls.Add(this.btnContactarAsesor);
            this.pnlVenta.Controls.Add(this.btnReservarVisita);
            this.pnlVenta.Controls.Add(this.guna2Separator1);
            this.pnlVenta.Controls.Add(this.lblPrecioAntiguo);
            this.pnlVenta.Controls.Add(this.lblPrecio);
            this.pnlVenta.Controls.Add(this.lblTitulo);
            this.pnlVenta.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlVenta.Location = new System.Drawing.Point(546, 24);
            this.pnlVenta.Name = "pnlVenta";
            this.pnlVenta.Size = new System.Drawing.Size(388, 518);
            this.pnlVenta.TabIndex = 1;
            // 
            // pnlDescripcion
            // 
            this.pnlDescripcion.AutoScroll = true;
            this.pnlDescripcion.Controls.Add(this.lblCombustible);
            this.pnlDescripcion.Controls.Add(this.lblKm);
            this.pnlDescripcion.Controls.Add(this.lblModelo);
            this.pnlDescripcion.Controls.Add(this.lblAnio);
            this.pnlDescripcion.Controls.Add(this.lblColor);
            this.pnlDescripcion.Controls.Add(this.lblMarca);
            this.pnlDescripcion.Controls.Add(this.txtEspecs);
            this.pnlDescripcion.Location = new System.Drawing.Point(13, 221);
            this.pnlDescripcion.Name = "pnlDescripcion";
            this.pnlDescripcion.Size = new System.Drawing.Size(372, 277);
            this.pnlDescripcion.TabIndex = 7;
            // 
            // lblCombustible
            // 
            this.lblCombustible.AutoSize = true;
            this.lblCombustible.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombustible.ForeColor = System.Drawing.Color.Black;
            this.lblCombustible.Location = new System.Drawing.Point(152, 31);
            this.lblCombustible.Name = "lblCombustible";
            this.lblCombustible.Size = new System.Drawing.Size(96, 20);
            this.lblCombustible.TabIndex = 12;
            this.lblCombustible.Text = "Combustible:";
            // 
            // lblKm
            // 
            this.lblKm.AutoSize = true;
            this.lblKm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKm.ForeColor = System.Drawing.Color.Black;
            this.lblKm.Location = new System.Drawing.Point(152, 6);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(89, 20);
            this.lblKm.TabIndex = 11;
            this.lblKm.Text = "Kilometraje:";
            this.lblKm.Click += new System.EventHandler(this.lblKm_Click);
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.ForeColor = System.Drawing.Color.Black;
            this.lblModelo.Location = new System.Drawing.Point(7, 31);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(64, 20);
            this.lblModelo.TabIndex = 10;
            this.lblModelo.Text = "Modelo:";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.ForeColor = System.Drawing.Color.Black;
            this.lblAnio.Location = new System.Drawing.Point(7, 76);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(39, 20);
            this.lblAnio.TabIndex = 9;
            this.lblAnio.Text = "Año:";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.ForeColor = System.Drawing.Color.Black;
            this.lblColor.Location = new System.Drawing.Point(7, 54);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(48, 20);
            this.lblColor.TabIndex = 8;
            this.lblColor.Text = "Color:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.ForeColor = System.Drawing.Color.Black;
            this.lblMarca.Location = new System.Drawing.Point(7, 6);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(53, 20);
            this.lblMarca.TabIndex = 7;
            this.lblMarca.Text = "Marca:";
            // 
            // txtEspecs
            // 
            this.txtEspecs.Animated = true;
            this.txtEspecs.BorderRadius = 5;
            this.txtEspecs.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEspecs.DefaultText = resources.GetString("txtEspecs.DefaultText");
            this.txtEspecs.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEspecs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEspecs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEspecs.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEspecs.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEspecs.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEspecs.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEspecs.ForeColor = System.Drawing.Color.Black;
            this.txtEspecs.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEspecs.Location = new System.Drawing.Point(0, 94);
            this.txtEspecs.Multiline = true;
            this.txtEspecs.Name = "txtEspecs";
            this.txtEspecs.PlaceholderText = "";
            this.txtEspecs.ReadOnly = true;
            this.txtEspecs.SelectedText = "";
            this.txtEspecs.Size = new System.Drawing.Size(352, 1124);
            this.txtEspecs.TabIndex = 6;
            // 
            // btnContactarAsesor
            // 
            this.btnContactarAsesor.BorderRadius = 10;
            this.btnContactarAsesor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnContactarAsesor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnContactarAsesor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnContactarAsesor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnContactarAsesor.FillColor = System.Drawing.Color.SeaGreen;
            this.btnContactarAsesor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContactarAsesor.ForeColor = System.Drawing.Color.White;
            this.btnContactarAsesor.Location = new System.Drawing.Point(203, 152);
            this.btnContactarAsesor.Name = "btnContactarAsesor";
            this.btnContactarAsesor.Size = new System.Drawing.Size(163, 52);
            this.btnContactarAsesor.TabIndex = 5;
            this.btnContactarAsesor.Text = "Contactar Asesor";
            // 
            // btnReservarVisita
            // 
            this.btnReservarVisita.BorderRadius = 10;
            this.btnReservarVisita.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReservarVisita.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReservarVisita.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReservarVisita.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReservarVisita.FillColor = System.Drawing.Color.SeaGreen;
            this.btnReservarVisita.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservarVisita.ForeColor = System.Drawing.Color.White;
            this.btnReservarVisita.Location = new System.Drawing.Point(23, 152);
            this.btnReservarVisita.Name = "btnReservarVisita";
            this.btnReservarVisita.Size = new System.Drawing.Size(163, 52);
            this.btnReservarVisita.TabIndex = 4;
            this.btnReservarVisita.Text = "Reservar Visita";
            this.btnReservarVisita.Click += new System.EventHandler(this.btnReservarVisita_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Separator1.Location = new System.Drawing.Point(35, 118);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(164, 10);
            this.guna2Separator1.TabIndex = 3;
            this.guna2Separator1.UseTransparentBackground = true;
            // 
            // lblPrecioAntiguo
            // 
            this.lblPrecioAntiguo.AutoSize = true;
            this.lblPrecioAntiguo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioAntiguo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrecioAntiguo.Location = new System.Drawing.Point(34, 112);
            this.lblPrecioAntiguo.Name = "lblPrecioAntiguo";
            this.lblPrecioAntiguo.Size = new System.Drawing.Size(162, 21);
            this.lblPrecioAntiguo.TabIndex = 2;
            this.lblPrecioAntiguo.Text = "Antes: $754,000,000";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.Black;
            this.lblPrecio.Location = new System.Drawing.Point(29, 76);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(189, 36);
            this.lblPrecio.TabIndex = 1;
            this.lblPrecio.Text = "$709,000,000";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(30, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(320, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Toyota Land Cruiser-LC300";
            // 
            // InfoVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.picCar);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.lblContacto);
            this.Controls.Add(this.lblSerivicios);
            this.Controls.Add(this.lblCatalogo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlGenVenta);
            this.Name = "InfoVehiculo";
            this.Load += new System.EventHandler(this.InfoVehiculo_Load);
            this.Controls.SetChildIndex(this.pnlGenVenta, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.lblCatalogo, 0);
            this.Controls.SetChildIndex(this.lblSerivicios, 0);
            this.Controls.SetChildIndex(this.lblContacto, 0);
            this.Controls.SetChildIndex(this.lblAdmin, 0);
            this.Controls.SetChildIndex(this.picCar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).EndInit();
            this.pnlGenVenta.ResumeLayout(false);
            this.pnlVenta.ResumeLayout(false);
            this.pnlVenta.PerformLayout();
            this.pnlDescripcion.ResumeLayout(false);
            this.pnlDescripcion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.Label lblSerivicios;
        private System.Windows.Forms.Label lblCatalogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox picCar;
        private Guna.UI2.WinForms.Guna2Panel pnlGenVenta;
        private Guna.UI2.WinForms.Guna2Panel pnlVenta;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPrecio;
        private Guna.UI2.WinForms.Guna2Button btnReservarVisita;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label lblPrecioAntiguo;
        private Guna.UI2.WinForms.Guna2Button btnContactarAsesor;
        private Guna.UI2.WinForms.Guna2TextBox txtEspecs;
        private Guna.UI2.WinForms.Guna2Panel pnlDescripcion;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblCombustible;
        private System.Windows.Forms.Label lblKm;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGaleria;
    }
}
