namespace AutoCare
{
    partial class VehiculoCard
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel6 = new System.Windows.Forms.Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.lblPrecioCar1 = new System.Windows.Forms.Label();
            this.lblCarMarca1 = new System.Windows.Forms.Label();
            this.lblCar1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.panel6.Controls.Add(this.guna2Button1);
            this.panel6.Controls.Add(this.lblPrecioCar1);
            this.panel6.Controls.Add(this.lblCarMarca1);
            this.panel6.Controls.Add(this.lblCar1);
            this.panel6.Controls.Add(this.pictureBox4);
            this.panel6.Location = new System.Drawing.Point(4, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(160, 238);
            this.panel6.TabIndex = 57;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.IndianRed;
            this.guna2Button1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(19, 192);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(120, 38);
            this.guna2Button1.TabIndex = 6;
            this.guna2Button1.Text = "Ver este Auto";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // lblPrecioCar1
            // 
            this.lblPrecioCar1.AutoSize = true;
            this.lblPrecioCar1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioCar1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPrecioCar1.Location = new System.Drawing.Point(70, 167);
            this.lblPrecioCar1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecioCar1.Name = "lblPrecioCar1";
            this.lblPrecioCar1.Size = new System.Drawing.Size(84, 17);
            this.lblPrecioCar1.TabIndex = 5;
            this.lblPrecioCar1.Text = "$109,500,000";
            this.lblPrecioCar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCarMarca1
            // 
            this.lblCarMarca1.AutoSize = true;
            this.lblCarMarca1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarMarca1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCarMarca1.Location = new System.Drawing.Point(5, 118);
            this.lblCarMarca1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarMarca1.Name = "lblCarMarca1";
            this.lblCarMarca1.Size = new System.Drawing.Size(48, 20);
            this.lblCarMarca1.TabIndex = 4;
            this.lblCarMarca1.Text = "BMW";
            // 
            // lblCar1
            // 
            this.lblCar1.AutoSize = true;
            this.lblCar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCar1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCar1.Location = new System.Drawing.Point(6, 138);
            this.lblCar1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCar1.Name = "lblCar1";
            this.lblCar1.Size = new System.Drawing.Size(35, 18);
            this.lblCar1.TabIndex = 3;
            this.lblCar1.Text = "118i";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(160, 116);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // VehiculoCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.panel6);
            this.Name = "VehiculoCard";
            this.Size = new System.Drawing.Size(168, 238);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label lblPrecioCar1;
        private System.Windows.Forms.Label lblCarMarca1;
        private System.Windows.Forms.Label lblCar1;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}
