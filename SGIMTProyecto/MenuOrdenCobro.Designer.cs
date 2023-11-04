namespace SGIMTProyecto
{
    partial class MenuOrdenCobro
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_ordenCD = new System.Windows.Forms.Button();
            this.SDP_menuOC = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PUC_menuOrdenC = new System.Windows.Forms.Panel();
            this.BTN_inicio = new System.Windows.Forms.Button();
            this.BTN_ordenCobro = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(24)))), ((int)(((byte)(122)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.SDP_menuOC);
            this.panel1.Controls.Add(this.BTN_ordenCD);
            this.panel1.Controls.Add(this.BTN_ordenCobro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 100);
            this.panel1.TabIndex = 0;
            // 
            // BTN_ordenCD
            // 
            this.BTN_ordenCD.FlatAppearance.BorderSize = 0;
            this.BTN_ordenCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ordenCD.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_ordenCD.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_ordenCD.Image = global::SGIMTProyecto.Properties.Resources.salarioCobroDiversos_white_50px;
            this.BTN_ordenCD.Location = new System.Drawing.Point(723, 0);
            this.BTN_ordenCD.Name = "BTN_ordenCD";
            this.BTN_ordenCD.Size = new System.Drawing.Size(283, 69);
            this.BTN_ordenCD.TabIndex = 1;
            this.BTN_ordenCD.Text = "  Orden de Cobro de Derechos (Diversos)";
            this.BTN_ordenCD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_ordenCD.UseVisualStyleBackColor = true;
            this.BTN_ordenCD.Click += new System.EventHandler(this.BTN_ordenCobroD_Click);
            // 
            // SDP_menuOC
            // 
            this.SDP_menuOC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(126)))), ((int)(((byte)(188)))));
            this.SDP_menuOC.Location = new System.Drawing.Point(397, 75);
            this.SDP_menuOC.Name = "SDP_menuOC";
            this.SDP_menuOC.Size = new System.Drawing.Size(283, 25);
            this.SDP_menuOC.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SGIMTProyecto.Properties.Resources.logosmyt_blanco_530;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // PUC_menuOrdenC
            // 
            this.PUC_menuOrdenC.Dock = System.Windows.Forms.DockStyle.Top;
            this.PUC_menuOrdenC.Location = new System.Drawing.Point(0, 100);
            this.PUC_menuOrdenC.Name = "PUC_menuOrdenC";
            this.PUC_menuOrdenC.Size = new System.Drawing.Size(1064, 638);
            this.PUC_menuOrdenC.TabIndex = 1;
            // 
            // BTN_inicio
            // 
            this.BTN_inicio.BackColor = System.Drawing.Color.DarkRed;
            this.BTN_inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_inicio.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_inicio.Location = new System.Drawing.Point(972, 744);
            this.BTN_inicio.Name = "BTN_inicio";
            this.BTN_inicio.Size = new System.Drawing.Size(80, 30);
            this.BTN_inicio.TabIndex = 24;
            this.BTN_inicio.Text = "Inicio";
            this.BTN_inicio.UseVisualStyleBackColor = false;
            this.BTN_inicio.Click += new System.EventHandler(this.BTN_inicio_Click);
            // 
            // BTN_ordenCobro
            // 
            this.BTN_ordenCobro.FlatAppearance.BorderSize = 0;
            this.BTN_ordenCobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ordenCobro.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_ordenCobro.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_ordenCobro.Image = global::SGIMTProyecto.Properties.Resources.salarioCobro_white_50px;
            this.BTN_ordenCobro.Location = new System.Drawing.Point(397, 0);
            this.BTN_ordenCobro.Name = "BTN_ordenCobro";
            this.BTN_ordenCobro.Size = new System.Drawing.Size(283, 69);
            this.BTN_ordenCobro.TabIndex = 0;
            this.BTN_ordenCobro.Text = "  Orden de Cobro de Derechos";
            this.BTN_ordenCobro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_ordenCobro.UseVisualStyleBackColor = true;
            this.BTN_ordenCobro.Click += new System.EventHandler(this.BTN_ordenCobro_Click);
            // 
            // MenuOrdenCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1064, 781);
            this.Controls.Add(this.BTN_inicio);
            this.Controls.Add(this.PUC_menuOrdenC);
            this.Controls.Add(this.panel1);
            this.Name = "MenuOrdenCobro";
            this.Text = "MenuOrdenCobro";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTN_ordenCD;
        private System.Windows.Forms.Panel SDP_menuOC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PUC_menuOrdenC;
        private System.Windows.Forms.Button BTN_inicio;
        private System.Windows.Forms.Button BTN_ordenCobro;
    }
}