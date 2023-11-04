namespace SGIMTProyecto
{
    partial class MenuPermisos
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
            this.BTN_eventualFR = new System.Windows.Forms.Button();
            this.BTN_transportePE = new System.Windows.Forms.Button();
            this.BTN_pasoAnual = new System.Windows.Forms.Button();
            this.BTN_transporteE = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PUC_menuEditar = new System.Windows.Forms.Panel();
            this.SDP_menuEditar = new System.Windows.Forms.Panel();
            this.BTN_inicio = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(24)))), ((int)(((byte)(122)))));
            this.panel1.Controls.Add(this.SDP_menuEditar);
            this.panel1.Controls.Add(this.BTN_eventualFR);
            this.panel1.Controls.Add(this.BTN_transportePE);
            this.panel1.Controls.Add(this.BTN_pasoAnual);
            this.panel1.Controls.Add(this.BTN_transporteE);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 657);
            this.panel1.TabIndex = 0;
            // 
            // BTN_eventualFR
            // 
            this.BTN_eventualFR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_eventualFR.FlatAppearance.BorderSize = 0;
            this.BTN_eventualFR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_eventualFR.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_eventualFR.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_eventualFR.Image = global::SGIMTProyecto.Properties.Resources.rutas_white_25;
            this.BTN_eventualFR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_eventualFR.Location = new System.Drawing.Point(24, 476);
            this.BTN_eventualFR.Name = "BTN_eventualFR";
            this.BTN_eventualFR.Size = new System.Drawing.Size(240, 69);
            this.BTN_eventualFR.TabIndex = 5;
            this.BTN_eventualFR.Text = "    Eventual para Circular Fuera de Ruta";
            this.BTN_eventualFR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_eventualFR.UseVisualStyleBackColor = true;
            this.BTN_eventualFR.Click += new System.EventHandler(this.BTN_eventualFR_Click);
            // 
            // BTN_transportePE
            // 
            this.BTN_transportePE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_transportePE.FlatAppearance.BorderSize = 0;
            this.BTN_transportePE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_transportePE.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_transportePE.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_transportePE.Image = global::SGIMTProyecto.Properties.Resources.personal_white_25;
            this.BTN_transportePE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_transportePE.Location = new System.Drawing.Point(24, 370);
            this.BTN_transportePE.Name = "BTN_transportePE";
            this.BTN_transportePE.Size = new System.Drawing.Size(240, 69);
            this.BTN_transportePE.TabIndex = 4;
            this.BTN_transportePE.Text = "    Para Transporte de Personal de Empresas";
            this.BTN_transportePE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_transportePE.UseVisualStyleBackColor = true;
            this.BTN_transportePE.Click += new System.EventHandler(this.BTN_transportePE_Click);
            // 
            // BTN_pasoAnual
            // 
            this.BTN_pasoAnual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_pasoAnual.FlatAppearance.BorderSize = 0;
            this.BTN_pasoAnual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_pasoAnual.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_pasoAnual.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_pasoAnual.Image = global::SGIMTProyecto.Properties.Resources.calendario_anual_white_25px;
            this.BTN_pasoAnual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_pasoAnual.Location = new System.Drawing.Point(24, 272);
            this.BTN_pasoAnual.Name = "BTN_pasoAnual";
            this.BTN_pasoAnual.Size = new System.Drawing.Size(240, 69);
            this.BTN_pasoAnual.TabIndex = 3;
            this.BTN_pasoAnual.Text = "    De Paso Anual";
            this.BTN_pasoAnual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_pasoAnual.UseVisualStyleBackColor = true;
            this.BTN_pasoAnual.Click += new System.EventHandler(this.BTN_pasoAnual_Click);
            // 
            // BTN_transporteE
            // 
            this.BTN_transporteE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_transporteE.FlatAppearance.BorderSize = 0;
            this.BTN_transporteE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_transporteE.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTN_transporteE.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_transporteE.Image = global::SGIMTProyecto.Properties.Resources.autobus_escolar_white_25px;
            this.BTN_transporteE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_transporteE.Location = new System.Drawing.Point(24, 179);
            this.BTN_transporteE.Name = "BTN_transporteE";
            this.BTN_transporteE.Size = new System.Drawing.Size(240, 69);
            this.BTN_transporteE.TabIndex = 2;
            this.BTN_transporteE.Text = "    Para Transporte Escolar";
            this.BTN_transporteE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_transporteE.UseVisualStyleBackColor = true;
            this.BTN_transporteE.Click += new System.EventHandler(this.BTN_transporteE_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SGIMTProyecto.Properties.Resources.logosmyt_blanco_530;
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PUC_menuEditar
            // 
            this.PUC_menuEditar.BackColor = System.Drawing.Color.FloralWhite;
            this.PUC_menuEditar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PUC_menuEditar.Location = new System.Drawing.Point(267, 0);
            this.PUC_menuEditar.Name = "PUC_menuEditar";
            this.PUC_menuEditar.Size = new System.Drawing.Size(797, 611);
            this.PUC_menuEditar.TabIndex = 1;
            // 
            // SDP_menuEditar
            // 
            this.SDP_menuEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(126)))), ((int)(((byte)(188)))));
            this.SDP_menuEditar.Location = new System.Drawing.Point(0, 179);
            this.SDP_menuEditar.Name = "SDP_menuEditar";
            this.SDP_menuEditar.Size = new System.Drawing.Size(10, 69);
            this.SDP_menuEditar.TabIndex = 1;
            // 
            // BTN_inicio
            // 
            this.BTN_inicio.BackColor = System.Drawing.Color.DarkRed;
            this.BTN_inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_inicio.ForeColor = System.Drawing.SystemColors.Window;
            this.BTN_inicio.Location = new System.Drawing.Point(972, 617);
            this.BTN_inicio.Name = "BTN_inicio";
            this.BTN_inicio.Size = new System.Drawing.Size(80, 30);
            this.BTN_inicio.TabIndex = 24;
            this.BTN_inicio.Text = "Inicio";
            this.BTN_inicio.UseVisualStyleBackColor = false;
            this.BTN_inicio.Click += new System.EventHandler(this.BTN_inicio_Click);
            // 
            // MenuPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1064, 657);
            this.Controls.Add(this.BTN_inicio);
            this.Controls.Add(this.PUC_menuEditar);
            this.Controls.Add(this.panel1);
            this.Name = "MenuPermisos";
            this.Text = "MenuPermisos";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTN_eventualFR;
        private System.Windows.Forms.Button BTN_transportePE;
        private System.Windows.Forms.Button BTN_pasoAnual;
        private System.Windows.Forms.Button BTN_transporteE;
        private System.Windows.Forms.Panel PUC_menuEditar;
        private System.Windows.Forms.Panel SDP_menuEditar;
        private System.Windows.Forms.Button BTN_inicio;
    }
}