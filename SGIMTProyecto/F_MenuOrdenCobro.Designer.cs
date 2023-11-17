namespace SGIMTProyecto
{
    partial class F_MenuOrdenCobro
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
            this.PNL_MenuOrdenC = new System.Windows.Forms.Panel();
            this.PCB_LogoSMyT = new System.Windows.Forms.PictureBox();
            this.SDP_MenuOC = new System.Windows.Forms.Panel();
            this.BTN_OrdenCobroDiversos = new System.Windows.Forms.Button();
            this.BTN_OrdenCobro = new System.Windows.Forms.Button();
            this.PNL_OrdenC = new System.Windows.Forms.Panel();
            this.BTN_Inicio = new System.Windows.Forms.Button();
            this.PNL_MenuOrdenC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_LogoSMyT)).BeginInit();
            this.SuspendLayout();
            // 
            // PNL_MenuOrdenC
            // 
            this.PNL_MenuOrdenC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(24)))), ((int)(((byte)(122)))));
            this.PNL_MenuOrdenC.Controls.Add(this.PCB_LogoSMyT);
            this.PNL_MenuOrdenC.Controls.Add(this.SDP_MenuOC);
            this.PNL_MenuOrdenC.Controls.Add(this.BTN_OrdenCobroDiversos);
            this.PNL_MenuOrdenC.Controls.Add(this.BTN_OrdenCobro);
            this.PNL_MenuOrdenC.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNL_MenuOrdenC.Location = new System.Drawing.Point(0, 0);
            this.PNL_MenuOrdenC.Name = "PNL_MenuOrdenC";
            this.PNL_MenuOrdenC.Size = new System.Drawing.Size(1064, 100);
            this.PNL_MenuOrdenC.TabIndex = 0;
            // 
            // PCB_LogoSMyT
            // 
            this.PCB_LogoSMyT.Image = global::SGIMTProyecto.Properties.Resources.logosmyt_blanco_530;
            this.PCB_LogoSMyT.Location = new System.Drawing.Point(3, 3);
            this.PCB_LogoSMyT.Name = "PCB_LogoSMyT";
            this.PCB_LogoSMyT.Size = new System.Drawing.Size(202, 97);
            this.PCB_LogoSMyT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PCB_LogoSMyT.TabIndex = 2;
            this.PCB_LogoSMyT.TabStop = false;
            // 
            // SDP_MenuOC
            // 
            this.SDP_MenuOC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(126)))), ((int)(((byte)(188)))));
            this.SDP_MenuOC.Location = new System.Drawing.Point(397, 75);
            this.SDP_MenuOC.Name = "SDP_MenuOC";
            this.SDP_MenuOC.Size = new System.Drawing.Size(283, 25);
            this.SDP_MenuOC.TabIndex = 1;
            // 
            // BTN_OrdenCobroDiversos
            // 
            this.BTN_OrdenCobroDiversos.FlatAppearance.BorderSize = 0;
            this.BTN_OrdenCobroDiversos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OrdenCobroDiversos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_OrdenCobroDiversos.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_OrdenCobroDiversos.Image = global::SGIMTProyecto.Properties.Resources.salarioCobroDiversos_white_50px;
            this.BTN_OrdenCobroDiversos.Location = new System.Drawing.Point(723, 0);
            this.BTN_OrdenCobroDiversos.Name = "BTN_OrdenCobroDiversos";
            this.BTN_OrdenCobroDiversos.Size = new System.Drawing.Size(283, 69);
            this.BTN_OrdenCobroDiversos.TabIndex = 1;
            this.BTN_OrdenCobroDiversos.Text = "  Orden de Cobro de Derechos (Diversos)";
            this.BTN_OrdenCobroDiversos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_OrdenCobroDiversos.UseVisualStyleBackColor = true;
            this.BTN_OrdenCobroDiversos.Click += new System.EventHandler(this.BTN_OrdenCobroDiversos_Click);
            // 
            // BTN_OrdenCobro
            // 
            this.BTN_OrdenCobro.FlatAppearance.BorderSize = 0;
            this.BTN_OrdenCobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OrdenCobro.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_OrdenCobro.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_OrdenCobro.Image = global::SGIMTProyecto.Properties.Resources.salarioCobro_white_50px;
            this.BTN_OrdenCobro.Location = new System.Drawing.Point(397, 0);
            this.BTN_OrdenCobro.Name = "BTN_OrdenCobro";
            this.BTN_OrdenCobro.Size = new System.Drawing.Size(283, 69);
            this.BTN_OrdenCobro.TabIndex = 0;
            this.BTN_OrdenCobro.Text = "  Orden de Cobro de Derechos";
            this.BTN_OrdenCobro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_OrdenCobro.UseVisualStyleBackColor = true;
            this.BTN_OrdenCobro.Click += new System.EventHandler(this.BTN_OrdenCobro_Click);
            // 
            // PNL_OrdenC
            // 
            this.PNL_OrdenC.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNL_OrdenC.Location = new System.Drawing.Point(0, 100);
            this.PNL_OrdenC.Name = "PNL_OrdenC";
            this.PNL_OrdenC.Size = new System.Drawing.Size(1064, 638);
            this.PNL_OrdenC.TabIndex = 1;
            // 
            // BTN_Inicio
            // 
            this.BTN_Inicio.BackColor = System.Drawing.Color.DarkRed;
            this.BTN_Inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Inicio.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_Inicio.Location = new System.Drawing.Point(972, 744);
            this.BTN_Inicio.Name = "BTN_Inicio";
            this.BTN_Inicio.Size = new System.Drawing.Size(80, 30);
            this.BTN_Inicio.TabIndex = 24;
            this.BTN_Inicio.Text = "Inicio";
            this.BTN_Inicio.UseVisualStyleBackColor = false;
            this.BTN_Inicio.Click += new System.EventHandler(this.BTN_Inicio_Click);
            // 
            // MenuOrdenCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1064, 781);
            this.Controls.Add(this.PNL_OrdenC);
            this.Controls.Add(this.PNL_MenuOrdenC);
            this.Controls.Add(this.BTN_Inicio);
            this.Name = "MenuOrdenCobro";
            this.Text = "MenuOrdenCobro";
            this.PNL_MenuOrdenC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCB_LogoSMyT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNL_MenuOrdenC;
        private System.Windows.Forms.Button BTN_OrdenCobroDiversos;
        private System.Windows.Forms.Panel SDP_MenuOC;
        private System.Windows.Forms.PictureBox PCB_LogoSMyT;
        private System.Windows.Forms.Panel PNL_OrdenC;
        private System.Windows.Forms.Button BTN_Inicio;
        private System.Windows.Forms.Button BTN_OrdenCobro;
    }
}