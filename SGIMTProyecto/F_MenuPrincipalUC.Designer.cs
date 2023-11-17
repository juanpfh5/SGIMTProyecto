namespace SGIMTProyecto
{
    partial class F_MenuPrincipalUC
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
            this.PCB_LogoSMyT = new System.Windows.Forms.PictureBox();
            this.PCB_ImagenCombi = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_LogoSMyT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_ImagenCombi)).BeginInit();
            this.SuspendLayout();
            // 
            // PCB_LogoSMyT
            // 
            this.PCB_LogoSMyT.Image = global::SGIMTProyecto.Properties.Resources.logosmyt_530;
            this.PCB_LogoSMyT.Location = new System.Drawing.Point(325, 201);
            this.PCB_LogoSMyT.Name = "PCB_LogoSMyT";
            this.PCB_LogoSMyT.Size = new System.Drawing.Size(301, 163);
            this.PCB_LogoSMyT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PCB_LogoSMyT.TabIndex = 1;
            this.PCB_LogoSMyT.TabStop = false;
            // 
            // PCB_ImagenCombi
            // 
            this.PCB_ImagenCombi.Image = global::SGIMTProyecto.Properties.Resources.combi_logo;
            this.PCB_ImagenCombi.Location = new System.Drawing.Point(123, 214);
            this.PCB_ImagenCombi.Name = "PCB_ImagenCombi";
            this.PCB_ImagenCombi.Size = new System.Drawing.Size(184, 150);
            this.PCB_ImagenCombi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PCB_ImagenCombi.TabIndex = 0;
            this.PCB_ImagenCombi.TabStop = false;
            // 
            // MenuPrincipalUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.Controls.Add(this.PCB_ImagenCombi);
            this.Controls.Add(this.PCB_LogoSMyT);
            this.Name = "MenuPrincipalUC";
            this.Size = new System.Drawing.Size(759, 657);
            ((System.ComponentModel.ISupportInitialize)(this.PCB_LogoSMyT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_ImagenCombi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PCB_ImagenCombi;
        private System.Windows.Forms.PictureBox PCB_LogoSMyT;
    }
}
