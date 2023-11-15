using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGIMTProyecto
{
    public partial class Revista : Form
    {
        public Revista()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region Métodos
        private void Rev(string cTexto)
        {
            D_Revista Datos = new D_Revista();
            MostrarDatos(Datos.Rev(cTexto));
        }

        private void MostrarDatos(List<string[]> datos)
        {
            // Verificar que haya al menos una fila de datos
            if (datos.Count > 0)
            {
                // Acceder a los valores de la primera fila
                string[] primeraFila = datos[0];

                // Mostrar los valores en TextBox correspondientes
                if (primeraFila.Length > 0) TXT_Nombre.Text = primeraFila[0];
                if (primeraFila.Length > 1) TXT_Domicilio.Text = primeraFila[1];
                if (primeraFila.Length > 2) TXT_Placas.Text = primeraFila[2];
                if (primeraFila.Length > 3) TXT_NoSerie.Text = primeraFila[3];
                if (primeraFila.Length > 4) TXT_Tipo.Text = primeraFila[4];
                if (primeraFila.Length > 5) TXT_NoMotor.Text = primeraFila[5];
                if (primeraFila.Length > 6) TXT_AnioModelo.Text = primeraFila[6];
                if (primeraFila.Length > 7) TXT_ClaveVehicular.Text = primeraFila[7];
                if (primeraFila.Length > 8) TXT_Marca.Text = primeraFila[8];
                if (primeraFila.Length > 9) TXT_NoPasajeros.Text = primeraFila[9];
                if (primeraFila.Length > 10) TXT_TipoConcesion.Text = primeraFila[10];
                if (primeraFila.Length > 11) TXT_Resolucion.Text = primeraFila[11];
                if (primeraFila.Length > 12) TXT_SitioRuta.Text = primeraFila[12];
            }
            else
            {
                TXT_Nombre.Text = "";
                TXT_Domicilio.Text = "";
                TXT_Placas.Text = "";
                TXT_NoSerie.Text = "";
                TXT_Tipo.Text = "";
                TXT_NoMotor.Text = "";
                TXT_AnioModelo.Text = "";
                TXT_ClaveVehicular.Text = "";
                TXT_Marca.Text = "";
                TXT_NoPasajeros.Text = "";
                TXT_TipoConcesion.Text = "";
                TXT_Resolucion.Text = "";
                TXT_SitioRuta.Text = "";
                MessageBox.Show("Lo sentimos, la placa no existe en la base de datos :(", "Placa Ausente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void BTN_Inicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_BuscarPlaca_Click(object sender, EventArgs e)
        {
            this.Rev(TXT_Placa.Text.Trim());
        }
    }
}
