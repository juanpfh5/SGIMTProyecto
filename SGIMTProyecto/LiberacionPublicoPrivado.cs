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
    public partial class LiberacionPublicoPrivado : UserControl
    {
        public LiberacionPublicoPrivado()
        {
            InitializeComponent();
        }

        #region Métodos
        private void LiberacionP_P(string cTexto)
        {
            D_LiberacionPublicoPrivado Datos = new D_LiberacionPublicoPrivado();
            MostrarDatos(Datos.LiberacionP_P(cTexto));
        }

        private void MostrarDatos(List<string[]> datos)
        {
            // Verificar que haya al menos una fila de datos
            if (datos.Count > 0)
            {
                // Acceder a los valores de la primera fila
                string[] primeraFila = datos[0];

                // Mostrar los valores en TextBox correspondientes
                if (primeraFila.Length > 0) TXT_Marca.Text = primeraFila[0];
                if (primeraFila.Length > 1) TXT_Modelo.Text = primeraFila[1];
                if (primeraFila.Length > 2) TXT_Tipo.Text = primeraFila[2];
                if (primeraFila.Length > 3) TXT_NoSerie.Text = primeraFila[3];
                if (primeraFila.Length > 4) TXT_NoMotor.Text = primeraFila[4];
            }
            else
            {
                TXT_Marca.Text = "";
                TXT_Modelo.Text = "";
                TXT_Tipo.Text = "";
                TXT_NoSerie.Text = "";
                TXT_NoMotor.Text = "";
                MessageBox.Show("Lo sentimos, la placa no existe en la base de datos :(", "Placa Ausente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void BTN_Buscar_Click(object sender, EventArgs e)
        {
            this.LiberacionP_P(TXT_Placa.Text.Trim());
        }
    }
}
