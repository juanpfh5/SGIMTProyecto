using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Crypto.Digests.SkeinEngine;

namespace SGIMTProyecto {
    public partial class F_VisualizacionPDF : Form {
        private string nombrePDF;
        public F_VisualizacionPDF() {
            InitializeComponent();
        }

        public void RecibirNombre(string nombrePDF) {
            this.nombrePDF = nombrePDF;
        }

        private void F_VisualizacionPDF_Load(object sender, EventArgs e) {
            nombrePDF = "C:/Users/luiz_/source/repos/SGIMTProyecto/SGIMTProyecto/bin/Debug/" + nombrePDF;
            PDF_Visualizador.src = nombrePDF;
        }
    }
}
