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
    public partial class OrdenCobroDiversos : UserControl
    {
        public OrdenCobroDiversos()
        {
            InitializeComponent();
        }

        #region Métodos
        private void OrdenCD(string cTexto)
        {
            D_OrdenCobroDiversos Datos = new D_OrdenCobroDiversos();
            MostrarDatos(Datos.OrdenCD(cTexto));
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
                if (primeraFila.Length > 1) TXT_NoExterior.Text = primeraFila[1];
                if (primeraFila.Length > 2) TXT_Domicilio.Text = primeraFila[2];
                if (primeraFila.Length > 3) TXT_NoInterior.Text = primeraFila[3];
                if (primeraFila.Length > 4) TXT_RFC.Text = primeraFila[4];
                if (primeraFila.Length > 5) TXT_CP.Text = primeraFila[5];
                if (primeraFila.Length > 6) TXT_Colonia.Text = primeraFila[6];
                if (primeraFila.Length > 7) TXT_Estado.Text = primeraFila[7];
                if (primeraFila.Length > 8) TXT_Municipio.Text = primeraFila[8];
            }
            else
            {
                TXT_Nombre.Text = "";
                TXT_NoExterior.Text = "";
                TXT_Domicilio.Text = "";
                TXT_NoInterior.Text = "";
                TXT_RFC.Text = "";
                TXT_CP.Text = "";
                TXT_Colonia.Text = "";
                TXT_Estado.Text = "";
                TXT_Municipio.Text = "";
                MessageBox.Show("Lo sentimos, la placa no existe en la base de datos :(", "Placa Ausente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void BTN_BuscarPlaca_Click(object sender, EventArgs e)
        {
            this.OrdenCD(TXT_Placa.Text.Trim());
        }
    }
}
