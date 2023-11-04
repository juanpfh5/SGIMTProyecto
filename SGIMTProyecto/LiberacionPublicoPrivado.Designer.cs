namespace SGIMTProyecto
{
    partial class LiberacionPublicoPrivado
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
            this.GRB_Liberacion = new System.Windows.Forms.GroupBox();
            this.DTP_Fecha = new System.Windows.Forms.DateTimePicker();
            this.JBL_Fecha = new System.Windows.Forms.Label();
            this.TXT_NoBaja = new System.Windows.Forms.TextBox();
            this.JBL_NoBaja = new System.Windows.Forms.Label();
            this.JBL_NoMotor = new System.Windows.Forms.Label();
            this.TXT_NoMotor = new System.Windows.Forms.TextBox();
            this.JBL_NoSerie = new System.Windows.Forms.Label();
            this.TXT_NoSerie = new System.Windows.Forms.TextBox();
            this.JBL_Tipo = new System.Windows.Forms.Label();
            this.TXT_Tipo = new System.Windows.Forms.TextBox();
            this.JBL_Modelo = new System.Windows.Forms.Label();
            this.TXT_Modelo = new System.Windows.Forms.TextBox();
            this.JBL_Marca = new System.Windows.Forms.Label();
            this.TXT_Marca = new System.Windows.Forms.TextBox();
            this.BTN_Imprimir = new System.Windows.Forms.Button();
            this.BTN_Buscar = new System.Windows.Forms.Button();
            this.TXT_Placa = new System.Windows.Forms.TextBox();
            this.GRB_Liberacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // GRB_Liberacion
            // 
            this.GRB_Liberacion.Controls.Add(this.JBL_Marca);
            this.GRB_Liberacion.Controls.Add(this.TXT_Marca);
            this.GRB_Liberacion.Controls.Add(this.JBL_Modelo);
            this.GRB_Liberacion.Controls.Add(this.TXT_Modelo);
            this.GRB_Liberacion.Controls.Add(this.JBL_Tipo);
            this.GRB_Liberacion.Controls.Add(this.TXT_Tipo);
            this.GRB_Liberacion.Controls.Add(this.JBL_NoSerie);
            this.GRB_Liberacion.Controls.Add(this.TXT_NoSerie);
            this.GRB_Liberacion.Controls.Add(this.JBL_NoMotor);
            this.GRB_Liberacion.Controls.Add(this.TXT_NoMotor);
            this.GRB_Liberacion.Controls.Add(this.JBL_NoBaja);
            this.GRB_Liberacion.Controls.Add(this.TXT_NoBaja);
            this.GRB_Liberacion.Controls.Add(this.JBL_Fecha);
            this.GRB_Liberacion.Controls.Add(this.DTP_Fecha);
            this.GRB_Liberacion.Location = new System.Drawing.Point(52, 59);
            this.GRB_Liberacion.Name = "GRB_Liberacion";
            this.GRB_Liberacion.Size = new System.Drawing.Size(667, 493);
            this.GRB_Liberacion.TabIndex = 0;
            this.GRB_Liberacion.TabStop = false;
            this.GRB_Liberacion.Text = "Liberacion de Servicio Publico a Privado";
            this.GRB_Liberacion.Enter += new System.EventHandler(this.GRB_Liberacion_Enter);
            // 
            // DTP_Fecha
            // 
            this.DTP_Fecha.Location = new System.Drawing.Point(267, 391);
            this.DTP_Fecha.Name = "DTP_Fecha";
            this.DTP_Fecha.Size = new System.Drawing.Size(200, 20);
            this.DTP_Fecha.TabIndex = 0;
            // 
            // JBL_Fecha
            // 
            this.JBL_Fecha.AutoSize = true;
            this.JBL_Fecha.Location = new System.Drawing.Point(187, 397);
            this.JBL_Fecha.Name = "JBL_Fecha";
            this.JBL_Fecha.Size = new System.Drawing.Size(43, 13);
            this.JBL_Fecha.TabIndex = 1;
            this.JBL_Fecha.Text = "Fecha: ";
            // 
            // TXT_NoBaja
            // 
            this.TXT_NoBaja.Location = new System.Drawing.Point(267, 354);
            this.TXT_NoBaja.Name = "TXT_NoBaja";
            this.TXT_NoBaja.Size = new System.Drawing.Size(199, 20);
            this.TXT_NoBaja.TabIndex = 2;
            this.TXT_NoBaja.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // JBL_NoBaja
            // 
            this.JBL_NoBaja.AutoSize = true;
            this.JBL_NoBaja.Location = new System.Drawing.Point(187, 361);
            this.JBL_NoBaja.Name = "JBL_NoBaja";
            this.JBL_NoBaja.Size = new System.Drawing.Size(54, 13);
            this.JBL_NoBaja.TabIndex = 3;
            this.JBL_NoBaja.Text = "No. Baja: ";
            this.JBL_NoBaja.Click += new System.EventHandler(this.label2_Click);
            // 
            // JBL_NoMotor
            // 
            this.JBL_NoMotor.AutoSize = true;
            this.JBL_NoMotor.Location = new System.Drawing.Point(187, 325);
            this.JBL_NoMotor.Name = "JBL_NoMotor";
            this.JBL_NoMotor.Size = new System.Drawing.Size(60, 13);
            this.JBL_NoMotor.TabIndex = 5;
            this.JBL_NoMotor.Text = "No. Motor: ";
            // 
            // TXT_NoMotor
            // 
            this.TXT_NoMotor.Location = new System.Drawing.Point(267, 318);
            this.TXT_NoMotor.Name = "TXT_NoMotor";
            this.TXT_NoMotor.Size = new System.Drawing.Size(199, 20);
            this.TXT_NoMotor.TabIndex = 4;
            // 
            // JBL_NoSerie
            // 
            this.JBL_NoSerie.AutoSize = true;
            this.JBL_NoSerie.Location = new System.Drawing.Point(187, 287);
            this.JBL_NoSerie.Name = "JBL_NoSerie";
            this.JBL_NoSerie.Size = new System.Drawing.Size(57, 13);
            this.JBL_NoSerie.TabIndex = 7;
            this.JBL_NoSerie.Text = "No. Serie: ";
            // 
            // TXT_NoSerie
            // 
            this.TXT_NoSerie.Location = new System.Drawing.Point(267, 280);
            this.TXT_NoSerie.Name = "TXT_NoSerie";
            this.TXT_NoSerie.Size = new System.Drawing.Size(199, 20);
            this.TXT_NoSerie.TabIndex = 6;
            // 
            // JBL_Tipo
            // 
            this.JBL_Tipo.AutoSize = true;
            this.JBL_Tipo.Location = new System.Drawing.Point(187, 251);
            this.JBL_Tipo.Name = "JBL_Tipo";
            this.JBL_Tipo.Size = new System.Drawing.Size(34, 13);
            this.JBL_Tipo.TabIndex = 9;
            this.JBL_Tipo.Text = "Tipo: ";
            // 
            // TXT_Tipo
            // 
            this.TXT_Tipo.Location = new System.Drawing.Point(267, 244);
            this.TXT_Tipo.Name = "TXT_Tipo";
            this.TXT_Tipo.Size = new System.Drawing.Size(199, 20);
            this.TXT_Tipo.TabIndex = 8;
            // 
            // JBL_Modelo
            // 
            this.JBL_Modelo.AutoSize = true;
            this.JBL_Modelo.Location = new System.Drawing.Point(187, 212);
            this.JBL_Modelo.Name = "JBL_Modelo";
            this.JBL_Modelo.Size = new System.Drawing.Size(48, 13);
            this.JBL_Modelo.TabIndex = 11;
            this.JBL_Modelo.Text = "Modelo: ";
            // 
            // TXT_Modelo
            // 
            this.TXT_Modelo.Location = new System.Drawing.Point(267, 205);
            this.TXT_Modelo.Name = "TXT_Modelo";
            this.TXT_Modelo.Size = new System.Drawing.Size(199, 20);
            this.TXT_Modelo.TabIndex = 10;
            // 
            // JBL_Marca
            // 
            this.JBL_Marca.AutoSize = true;
            this.JBL_Marca.Location = new System.Drawing.Point(187, 165);
            this.JBL_Marca.Name = "JBL_Marca";
            this.JBL_Marca.Size = new System.Drawing.Size(43, 13);
            this.JBL_Marca.TabIndex = 13;
            this.JBL_Marca.Text = "Marca: ";
            // 
            // TXT_Marca
            // 
            this.TXT_Marca.Location = new System.Drawing.Point(267, 158);
            this.TXT_Marca.Name = "TXT_Marca";
            this.TXT_Marca.Size = new System.Drawing.Size(199, 20);
            this.TXT_Marca.TabIndex = 12;
            // 
            // BTN_Imprimir
            // 
            this.BTN_Imprimir.Location = new System.Drawing.Point(358, 579);
            this.BTN_Imprimir.Name = "BTN_Imprimir";
            this.BTN_Imprimir.Size = new System.Drawing.Size(75, 23);
            this.BTN_Imprimir.TabIndex = 1;
            this.BTN_Imprimir.Text = "button1";
            this.BTN_Imprimir.UseVisualStyleBackColor = true;
            // 
            // BTN_Buscar
            // 
            this.BTN_Buscar.Location = new System.Drawing.Point(644, 20);
            this.BTN_Buscar.Name = "BTN_Buscar";
            this.BTN_Buscar.Size = new System.Drawing.Size(75, 23);
            this.BTN_Buscar.TabIndex = 2;
            this.BTN_Buscar.Text = "button1";
            this.BTN_Buscar.UseVisualStyleBackColor = true;
            // 
            // TXT_Placa
            // 
            this.TXT_Placa.Location = new System.Drawing.Point(529, 22);
            this.TXT_Placa.Name = "TXT_Placa";
            this.TXT_Placa.Size = new System.Drawing.Size(100, 20);
            this.TXT_Placa.TabIndex = 3;
            // 
            // LiberacionPublicoPrivado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TXT_Placa);
            this.Controls.Add(this.BTN_Buscar);
            this.Controls.Add(this.GRB_Liberacion);
            this.Controls.Add(this.BTN_Imprimir);
            this.Name = "LiberacionPublicoPrivado";
            this.Size = new System.Drawing.Size(756, 657);
            this.GRB_Liberacion.ResumeLayout(false);
            this.GRB_Liberacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GRB_Liberacion;
        private System.Windows.Forms.Label JBL_NoBaja;
        private System.Windows.Forms.TextBox TXT_NoBaja;
        private System.Windows.Forms.Label JBL_Fecha;
        private System.Windows.Forms.DateTimePicker DTP_Fecha;
        private System.Windows.Forms.Label JBL_Marca;
        private System.Windows.Forms.TextBox TXT_Marca;
        private System.Windows.Forms.Label JBL_Modelo;
        private System.Windows.Forms.TextBox TXT_Modelo;
        private System.Windows.Forms.Label JBL_Tipo;
        private System.Windows.Forms.TextBox TXT_Tipo;
        private System.Windows.Forms.Label JBL_NoSerie;
        private System.Windows.Forms.TextBox TXT_NoSerie;
        private System.Windows.Forms.Label JBL_NoMotor;
        private System.Windows.Forms.TextBox TXT_NoMotor;
        private System.Windows.Forms.Button BTN_Imprimir;
        private System.Windows.Forms.Button BTN_Buscar;
        private System.Windows.Forms.TextBox TXT_Placa;
    }
}
