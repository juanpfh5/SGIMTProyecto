namespace SGIMTProyecto
{
    partial class MenuEditar
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BTN_datosV = new System.Windows.Forms.Button();
            this.BTN_datosP = new System.Windows.Forms.Button();
            this.PUC_menuEditar = new System.Windows.Forms.Panel();
            this.BTN_inicio = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(24)))), ((int)(((byte)(122)))));
            this.panel2.Controls.Add(this.BTN_datosP);
            this.panel2.Controls.Add(this.BTN_datosV);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1064, 109);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SGIMTProyecto.Properties.Resources.logosmyt_blanco_530;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(198, 106);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // BTN_datosV
            // 
            this.BTN_datosV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_datosV.FlatAppearance.BorderSize = 0;
            this.BTN_datosV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_datosV.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_datosV.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_datosV.Image = global::SGIMTProyecto.Properties.Resources.coche_white_50px;
            this.BTN_datosV.Location = new System.Drawing.Point(309, 22);
            this.BTN_datosV.Name = "BTN_datosV";
            this.BTN_datosV.Size = new System.Drawing.Size(338, 69);
            this.BTN_datosV.TabIndex = 1;
            this.BTN_datosV.Text = "Datos del Vehículo";
            this.BTN_datosV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_datosV.UseVisualStyleBackColor = true;
            this.BTN_datosV.Click += new System.EventHandler(this.BTN_datosV_Click);
            // 
            // BTN_datosP
            // 
            this.BTN_datosP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_datosP.FlatAppearance.BorderSize = 0;
            this.BTN_datosP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_datosP.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_datosP.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_datosP.Image = global::SGIMTProyecto.Properties.Resources.perfil_white_50px;
            this.BTN_datosP.Location = new System.Drawing.Point(653, 22);
            this.BTN_datosP.Name = "BTN_datosP";
            this.BTN_datosP.Size = new System.Drawing.Size(337, 69);
            this.BTN_datosP.TabIndex = 2;
            this.BTN_datosP.Text = "Datos del Propietario";
            this.BTN_datosP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_datosP.UseVisualStyleBackColor = true;
            this.BTN_datosP.Click += new System.EventHandler(this.BTN_datosP_Click);
            // 
            // PUC_menuEditar
            // 
            this.PUC_menuEditar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PUC_menuEditar.Location = new System.Drawing.Point(0, 109);
            this.PUC_menuEditar.Name = "PUC_menuEditar";
            this.PUC_menuEditar.Size = new System.Drawing.Size(1064, 506);
            this.PUC_menuEditar.TabIndex = 2;
            // 
            // BTN_inicio
            // 
            this.BTN_inicio.BackColor = System.Drawing.Color.DarkRed;
            this.BTN_inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_inicio.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_inicio.Location = new System.Drawing.Point(972, 621);
            this.BTN_inicio.Name = "BTN_inicio";
            this.BTN_inicio.Size = new System.Drawing.Size(80, 30);
            this.BTN_inicio.TabIndex = 25;
            this.BTN_inicio.Text = "Inicio";
            this.BTN_inicio.UseVisualStyleBackColor = false;
            this.BTN_inicio.Click += new System.EventHandler(this.BTN_inicio_Click);
            // 
            // MenuEditar
            // 
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1064, 657);
            this.Controls.Add(this.BTN_inicio);
            this.Controls.Add(this.PUC_menuEditar);
            this.Controls.Add(this.panel2);
            this.Name = "MenuEditar";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTN_datosV;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button BTN_datosP;
        private System.Windows.Forms.Panel PUC_menuEditar;
        private System.Windows.Forms.Button BTN_inicio;
    }
}