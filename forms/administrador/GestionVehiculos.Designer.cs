namespace AutoCare.forms.administrador
{
    partial class GestionVehiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionVehiculos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblSerivicios = new System.Windows.Forms.Label();
            this.lblCatalogo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlNuevoVehiculo = new Guna.UI2.WinForms.Guna2Panel();
            this.cmbEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtKilometraje = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbtipoGasolina = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCancelarNuevo = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuardarNuevo = new Guna.UI2.WinForms.Guna2Button();
            this.txtAnio = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtModelo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPrecio = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMarca = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtColor = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCargarImagenes = new Guna.UI2.WinForms.Guna2Button();
            this.btnAgregar = new Guna.UI2.WinForms.Guna2Button();
            this.btnHabilitarEdicion = new Guna.UI2.WinForms.Guna2Button();
            this.btnElimiar = new Guna.UI2.WinForms.Guna2Button();
            this.dgvVehiculos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlNuevoVehiculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2VSeparator1
            // 
            this.guna2VSeparator1.Location = new System.Drawing.Point(89, 115);
            this.guna2VSeparator1.Name = "guna2VSeparator1";
            this.guna2VSeparator1.Size = new System.Drawing.Size(10, 46);
            this.guna2VSeparator1.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(104, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 32);
            this.label2.TabIndex = 71;
            this.label2.Text = "Gestion de Vehiculos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdmin
            // 
            this.lblAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdmin.ForeColor = System.Drawing.Color.IndianRed;
            this.lblAdmin.Location = new System.Drawing.Point(931, 51);
            this.lblAdmin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(53, 19);
            this.lblAdmin.TabIndex = 69;
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
            this.lblContacto.Location = new System.Drawing.Point(1135, 51);
            this.lblContacto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(100, 19);
            this.lblContacto.TabIndex = 70;
            this.lblContacto.Text = "Contactanos";
            this.lblContacto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContacto.Click += new System.EventHandler(this.winContacto);
            // 
            // lblSerivicios
            // 
            this.lblSerivicios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSerivicios.AutoSize = true;
            this.lblSerivicios.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerivicios.ForeColor = System.Drawing.Color.LightGray;
            this.lblSerivicios.Location = new System.Drawing.Point(1064, 51);
            this.lblSerivicios.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSerivicios.Name = "lblSerivicios";
            this.lblSerivicios.Size = new System.Drawing.Size(69, 19);
            this.lblSerivicios.TabIndex = 68;
            this.lblSerivicios.Text = "Serivicios";
            this.lblSerivicios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSerivicios.Click += new System.EventHandler(this.winSercios);
            // 
            // lblCatalogo
            // 
            this.lblCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCatalogo.AutoSize = true;
            this.lblCatalogo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalogo.ForeColor = System.Drawing.Color.LightGray;
            this.lblCatalogo.Location = new System.Drawing.Point(986, 51);
            this.lblCatalogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCatalogo.Name = "lblCatalogo";
            this.lblCatalogo.Size = new System.Drawing.Size(75, 19);
            this.lblCatalogo.TabIndex = 67;
            this.lblCatalogo.Text = "Catalogo";
            this.lblCatalogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCatalogo.Click += new System.EventHandler(this.winCatalogo);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(5, 35);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 53);
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.winHome);
            // 
            // pnlNuevoVehiculo
            // 
            this.pnlNuevoVehiculo.BackColor = System.Drawing.Color.Transparent;
            this.pnlNuevoVehiculo.Controls.Add(this.cmbEstado);
            this.pnlNuevoVehiculo.Controls.Add(this.txtKilometraje);
            this.pnlNuevoVehiculo.Controls.Add(this.label3);
            this.pnlNuevoVehiculo.Controls.Add(this.txtDescripcion);
            this.pnlNuevoVehiculo.Controls.Add(this.label1);
            this.pnlNuevoVehiculo.Controls.Add(this.cmbtipoGasolina);
            this.pnlNuevoVehiculo.Controls.Add(this.btnCancelarNuevo);
            this.pnlNuevoVehiculo.Controls.Add(this.btnGuardarNuevo);
            this.pnlNuevoVehiculo.Controls.Add(this.txtAnio);
            this.pnlNuevoVehiculo.Controls.Add(this.txtModelo);
            this.pnlNuevoVehiculo.Controls.Add(this.txtPrecio);
            this.pnlNuevoVehiculo.Controls.Add(this.txtMarca);
            this.pnlNuevoVehiculo.Controls.Add(this.txtColor);
            this.pnlNuevoVehiculo.Location = new System.Drawing.Point(775, 170);
            this.pnlNuevoVehiculo.Name = "pnlNuevoVehiculo";
            this.pnlNuevoVehiculo.Size = new System.Drawing.Size(481, 487);
            this.pnlNuevoVehiculo.TabIndex = 65;
            this.pnlNuevoVehiculo.Visible = false;
            // 
            // cmbEstado
            // 
            this.cmbEstado.BackColor = System.Drawing.Color.Transparent;
            this.cmbEstado.BorderRadius = 6;
            this.cmbEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbEstado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbEstado.ItemHeight = 30;
            this.cmbEstado.Items.AddRange(new object[] {
            "Vendido",
            "Usado",
            "Nuevo",
            "De aseguradora"});
            this.cmbEstado.Location = new System.Drawing.Point(257, 235);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(203, 36);
            this.cmbEstado.TabIndex = 65;
            // 
            // txtKilometraje
            // 
            this.txtKilometraje.BorderRadius = 6;
            this.txtKilometraje.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKilometraje.DefaultText = "";
            this.txtKilometraje.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtKilometraje.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtKilometraje.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKilometraje.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKilometraje.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKilometraje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKilometraje.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKilometraje.Location = new System.Drawing.Point(29, 235);
            this.txtKilometraje.Name = "txtKilometraje";
            this.txtKilometraje.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtKilometraje.PlaceholderText = "Kilometraje";
            this.txtKilometraje.SelectedText = "";
            this.txtKilometraje.Size = new System.Drawing.Size(203, 36);
            this.txtKilometraje.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Descripcion*";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Animated = true;
            this.txtDescripcion.AutoScroll = true;
            this.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescripcion.DefaultText = "";
            this.txtDescripcion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescripcion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescripcion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescripcion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescripcion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescripcion.Location = new System.Drawing.Point(27, 310);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PlaceholderText = "";
            this.txtDescripcion.SelectedText = "";
            this.txtDescripcion.Size = new System.Drawing.Size(433, 41);
            this.txtDescripcion.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(48, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 19);
            this.label1.TabIndex = 60;
            this.label1.Text = "Info. Nuevo Vehiculo";
            // 
            // cmbtipoGasolina
            // 
            this.cmbtipoGasolina.BackColor = System.Drawing.Color.Transparent;
            this.cmbtipoGasolina.BorderRadius = 6;
            this.cmbtipoGasolina.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbtipoGasolina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipoGasolina.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbtipoGasolina.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbtipoGasolina.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbtipoGasolina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbtipoGasolina.ItemHeight = 30;
            this.cmbtipoGasolina.Items.AddRange(new object[] {
            "Tipo Combustible",
            "Gasolina Corriente",
            "Gasolina Extra",
            "Diesel"});
            this.cmbtipoGasolina.Location = new System.Drawing.Point(257, 180);
            this.cmbtipoGasolina.Name = "cmbtipoGasolina";
            this.cmbtipoGasolina.Size = new System.Drawing.Size(203, 36);
            this.cmbtipoGasolina.TabIndex = 59;
            // 
            // btnCancelarNuevo
            // 
            this.btnCancelarNuevo.Animated = true;
            this.btnCancelarNuevo.BorderRadius = 6;
            this.btnCancelarNuevo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelarNuevo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelarNuevo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelarNuevo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelarNuevo.FillColor = System.Drawing.Color.Firebrick;
            this.btnCancelarNuevo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarNuevo.ForeColor = System.Drawing.Color.White;
            this.btnCancelarNuevo.Location = new System.Drawing.Point(177, 424);
            this.btnCancelarNuevo.Name = "btnCancelarNuevo";
            this.btnCancelarNuevo.Size = new System.Drawing.Size(123, 43);
            this.btnCancelarNuevo.TabIndex = 58;
            this.btnCancelarNuevo.Text = "Cancelar";
            // 
            // btnGuardarNuevo
            // 
            this.btnGuardarNuevo.Animated = true;
            this.btnGuardarNuevo.BorderRadius = 6;
            this.btnGuardarNuevo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardarNuevo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardarNuevo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardarNuevo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardarNuevo.FillColor = System.Drawing.Color.Firebrick;
            this.btnGuardarNuevo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarNuevo.ForeColor = System.Drawing.Color.White;
            this.btnGuardarNuevo.Location = new System.Drawing.Point(28, 424);
            this.btnGuardarNuevo.Name = "btnGuardarNuevo";
            this.btnGuardarNuevo.Size = new System.Drawing.Size(123, 43);
            this.btnGuardarNuevo.TabIndex = 53;
            this.btnGuardarNuevo.Text = "Agregar";
            this.btnGuardarNuevo.Click += new System.EventHandler(this.btnGuardarNuevo_Click_1);
            // 
            // txtAnio
            // 
            this.txtAnio.BorderRadius = 6;
            this.txtAnio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAnio.DefaultText = "";
            this.txtAnio.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAnio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAnio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAnio.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAnio.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAnio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAnio.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAnio.Location = new System.Drawing.Point(257, 115);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtAnio.PlaceholderText = "Año";
            this.txtAnio.SelectedText = "";
            this.txtAnio.Size = new System.Drawing.Size(203, 36);
            this.txtAnio.TabIndex = 57;
            // 
            // txtModelo
            // 
            this.txtModelo.BorderRadius = 6;
            this.txtModelo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtModelo.DefaultText = "";
            this.txtModelo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtModelo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtModelo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtModelo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtModelo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtModelo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtModelo.Location = new System.Drawing.Point(257, 52);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtModelo.PlaceholderText = "Modelo";
            this.txtModelo.SelectedText = "";
            this.txtModelo.Size = new System.Drawing.Size(203, 36);
            this.txtModelo.TabIndex = 54;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BorderRadius = 6;
            this.txtPrecio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecio.DefaultText = "";
            this.txtPrecio.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrecio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrecio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecio.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecio.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrecio.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecio.Location = new System.Drawing.Point(29, 180);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPrecio.PlaceholderText = "Precio";
            this.txtPrecio.SelectedText = "";
            this.txtPrecio.Size = new System.Drawing.Size(203, 36);
            this.txtPrecio.TabIndex = 56;
            // 
            // txtMarca
            // 
            this.txtMarca.BorderRadius = 6;
            this.txtMarca.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMarca.DefaultText = "";
            this.txtMarca.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMarca.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMarca.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMarca.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMarca.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMarca.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMarca.Location = new System.Drawing.Point(27, 52);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtMarca.PlaceholderText = "Marca";
            this.txtMarca.SelectedText = "";
            this.txtMarca.Size = new System.Drawing.Size(205, 36);
            this.txtMarca.TabIndex = 53;
            // 
            // txtColor
            // 
            this.txtColor.BorderRadius = 6;
            this.txtColor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtColor.DefaultText = "";
            this.txtColor.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtColor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtColor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtColor.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtColor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtColor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtColor.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtColor.Location = new System.Drawing.Point(27, 115);
            this.txtColor.Name = "txtColor";
            this.txtColor.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtColor.PlaceholderText = "Color";
            this.txtColor.SelectedText = "";
            this.txtColor.Size = new System.Drawing.Size(205, 36);
            this.txtColor.TabIndex = 55;
            // 
            // btnCargarImagenes
            // 
            this.btnCargarImagenes.Animated = true;
            this.btnCargarImagenes.BorderRadius = 10;
            this.btnCargarImagenes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCargarImagenes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCargarImagenes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCargarImagenes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCargarImagenes.FillColor = System.Drawing.Color.Firebrick;
            this.btnCargarImagenes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCargarImagenes.ForeColor = System.Drawing.Color.White;
            this.btnCargarImagenes.Location = new System.Drawing.Point(1119, 594);
            this.btnCargarImagenes.Name = "btnCargarImagenes";
            this.btnCargarImagenes.Size = new System.Drawing.Size(122, 43);
            this.btnCargarImagenes.TabIndex = 63;
            this.btnCargarImagenes.Text = "Subir Imagenes";
            this.btnCargarImagenes.Click += new System.EventHandler(this.btnCargarImagenes_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BorderRadius = 6;
            this.btnAgregar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAgregar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAgregar.FillColor = System.Drawing.Color.Firebrick;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(579, 186);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(170, 45);
            this.btnAgregar.TabIndex = 64;
            this.btnAgregar.Text = "Agregar Vehiculo";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnHabilitarEdicion
            // 
            this.btnHabilitarEdicion.Animated = true;
            this.btnHabilitarEdicion.BorderRadius = 6;
            this.btnHabilitarEdicion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHabilitarEdicion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHabilitarEdicion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHabilitarEdicion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHabilitarEdicion.FillColor = System.Drawing.Color.Firebrick;
            this.btnHabilitarEdicion.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnHabilitarEdicion.ForeColor = System.Drawing.Color.White;
            this.btnHabilitarEdicion.Location = new System.Drawing.Point(216, 186);
            this.btnHabilitarEdicion.Name = "btnHabilitarEdicion";
            this.btnHabilitarEdicion.Size = new System.Drawing.Size(159, 45);
            this.btnHabilitarEdicion.TabIndex = 63;
            this.btnHabilitarEdicion.Text = "Habilitar edicion";
            // 
            // btnElimiar
            // 
            this.btnElimiar.Animated = true;
            this.btnElimiar.BorderRadius = 6;
            this.btnElimiar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnElimiar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnElimiar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnElimiar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnElimiar.FillColor = System.Drawing.Color.Firebrick;
            this.btnElimiar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnElimiar.ForeColor = System.Drawing.Color.White;
            this.btnElimiar.Location = new System.Drawing.Point(392, 186);
            this.btnElimiar.Name = "btnElimiar";
            this.btnElimiar.Size = new System.Drawing.Size(169, 45);
            this.btnElimiar.TabIndex = 62;
            this.btnElimiar.Text = "Eliminar Vehiculo";
            // 
            // dgvVehiculos
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehiculos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvVehiculos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehiculos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvVehiculos.ColumnHeadersHeight = 40;
            this.dgvVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehiculos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvVehiculos.GridColor = System.Drawing.Color.Black;
            this.dgvVehiculos.Location = new System.Drawing.Point(36, 259);
            this.dgvVehiculos.Name = "dgvVehiculos";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehiculos.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvVehiculos.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dgvVehiculos.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvVehiculos.Size = new System.Drawing.Size(1205, 398);
            this.dgvVehiculos.TabIndex = 61;
            this.dgvVehiculos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvVehiculos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvVehiculos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvVehiculos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvVehiculos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvVehiculos.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.dgvVehiculos.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dgvVehiculos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvVehiculos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVehiculos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvVehiculos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvVehiculos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvVehiculos.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvVehiculos.ThemeStyle.ReadOnly = false;
            this.dgvVehiculos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvVehiculos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVehiculos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvVehiculos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvVehiculos.ThemeStyle.RowsStyle.Height = 22;
            this.dgvVehiculos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVehiculos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // GestionVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.guna2VSeparator1);
            this.Controls.Add(this.btnCargarImagenes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.lblContacto);
            this.Controls.Add(this.lblSerivicios);
            this.Controls.Add(this.lblCatalogo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlNuevoVehiculo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnHabilitarEdicion);
            this.Controls.Add(this.btnElimiar);
            this.Controls.Add(this.dgvVehiculos);
            this.Name = "GestionVehiculos";
            this.Load += new System.EventHandler(this.GestionVehiculos_Load);
            this.Controls.SetChildIndex(this.dgvVehiculos, 0);
            this.Controls.SetChildIndex(this.btnElimiar, 0);
            this.Controls.SetChildIndex(this.btnHabilitarEdicion, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.pnlNuevoVehiculo, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.lblCatalogo, 0);
            this.Controls.SetChildIndex(this.lblSerivicios, 0);
            this.Controls.SetChildIndex(this.lblContacto, 0);
            this.Controls.SetChildIndex(this.lblAdmin, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnCargarImagenes, 0);
            this.Controls.SetChildIndex(this.guna2VSeparator1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlNuevoVehiculo.ResumeLayout(false);
            this.pnlNuevoVehiculo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.Label lblSerivicios;
        private System.Windows.Forms.Label lblCatalogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Panel pnlNuevoVehiculo;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbtipoGasolina;
        private Guna.UI2.WinForms.Guna2Button btnCancelarNuevo;
        private Guna.UI2.WinForms.Guna2Button btnGuardarNuevo;
        private Guna.UI2.WinForms.Guna2TextBox txtAnio;
        private Guna.UI2.WinForms.Guna2TextBox txtModelo;
        private Guna.UI2.WinForms.Guna2TextBox txtPrecio;
        private Guna.UI2.WinForms.Guna2TextBox txtMarca;
        private Guna.UI2.WinForms.Guna2TextBox txtColor;
        private Guna.UI2.WinForms.Guna2Button btnAgregar;
        private Guna.UI2.WinForms.Guna2Button btnHabilitarEdicion;
        private Guna.UI2.WinForms.Guna2Button btnElimiar;
        private Guna.UI2.WinForms.Guna2DataGridView dgvVehiculos;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtDescripcion;
        private Guna.UI2.WinForms.Guna2Button btnCargarImagenes;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2TextBox txtKilometraje;
        private Guna.UI2.WinForms.Guna2ComboBox cmbEstado;
    }
}
