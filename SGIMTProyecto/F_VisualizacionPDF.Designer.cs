namespace SGIMTProyecto {
    partial class F_VisualizacionPDF {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_VisualizacionPDF));
            this.PDF_Visualizador = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.PDF_Visualizador)).BeginInit();
            this.SuspendLayout();
            // 
            // PDF_Visualizador
            // 
            this.PDF_Visualizador.Enabled = true;
            this.PDF_Visualizador.Location = new System.Drawing.Point(-2, 1);
            this.PDF_Visualizador.Name = "PDF_Visualizador";
            this.PDF_Visualizador.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDF_Visualizador.OcxState")));
            this.PDF_Visualizador.Size = new System.Drawing.Size(885, 862);
            this.PDF_Visualizador.TabIndex = 0;
            // 
            // F_VisualizacionPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 861);
            this.Controls.Add(this.PDF_Visualizador);
            this.MaximizeBox = false;
            this.Name = "F_VisualizacionPDF";
            this.Text = "Visualización del PDF";
            this.Load += new System.EventHandler(this.F_VisualizacionPDF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PDF_Visualizador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF PDF_Visualizador;
    }
}