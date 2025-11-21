namespace AutoCare
{
    partial class HomeUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeUsuario));
            this.pctBoxButtonModUsers = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxButtonModUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBoxButtonModUsers
            // 
            this.pctBoxButtonModUsers.Image = ((System.Drawing.Image)(resources.GetObject("pctBoxButtonModUsers.Image")));
            this.pctBoxButtonModUsers.ImageRotate = 0F;
            this.pctBoxButtonModUsers.Location = new System.Drawing.Point(126, 60);
            this.pctBoxButtonModUsers.Name = "pctBoxButtonModUsers";
            this.pctBoxButtonModUsers.Size = new System.Drawing.Size(229, 200);
            this.pctBoxButtonModUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBoxButtonModUsers.TabIndex = 0;
            this.pctBoxButtonModUsers.TabStop = false;
            this.pctBoxButtonModUsers.Click += new System.EventHandler(this.pctBoxButtonModUsers_Click);
            // 
            // HomeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pctBoxButtonModUsers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomeUsuario";
            this.Text = "HomeUsuario";
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxButtonModUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pctBoxButtonModUsers;
    }
}