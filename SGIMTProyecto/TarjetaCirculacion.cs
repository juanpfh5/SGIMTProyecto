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
    public partial class TarjetaCirculacion : Form
    {
        public TarjetaCirculacion()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region Métodos
        private void TC(string cTexto)
        {
            D_TarjetaCirculacion Datos = new D_TarjetaCirculacion();
            MostrarDatos(Datos.TC(cTexto));
        }

        private void MostrarDatos(List<string[]> datos)
        {
            // Verificar que haya al menos una fila de datos
            if (datos.Count > 0)
            {
                // Acceder a los valores de la primera fila
                string[] primeraFila = datos[0];

                // Mostrar los valores en TextBox correspondientes
                if (primeraFila.Length > 0) TXT_Propietario.Text = primeraFila[0];
                if (primeraFila.Length > 1) TXT_Domicilio.Text = primeraFila[1];
                if (primeraFila.Length > 2) TXT_Vehiculo.Text = primeraFila[2];
                if (primeraFila.Length > 3) TXT_RFC.Text = primeraFila[3];
                if (primeraFila.Length > 4) TXT_Repuve.Text = primeraFila[4];
                if (primeraFila.Length > 5) TXT_NIV.Text = primeraFila[5];
                if (primeraFila.Length > 6) TXT_Placas.Text = primeraFila[6];
                if (primeraFila.Length > 7) TXT_Toneladas.Text = primeraFila[7];
                if (primeraFila.Length > 8) TXT_NoMotor.Text = primeraFila[8];
                if (primeraFila.Length > 9) TXT_Cilindros.Text = primeraFila[9];
                if (primeraFila.Length > 10) TXT_Personas.Text = primeraFila[10];
                if (primeraFila.Length > 11) TXT_Marca.Text = primeraFila[11];
                if (primeraFila.Length > 12) TXT_Combustible.Text = primeraFila[12];
                if (primeraFila.Length > 13) TXT_Modelo.Text = primeraFila[13];
                if (primeraFila.Length > 14) TXT_ClaveVehicular.Text = primeraFila[14];
                if (primeraFila.Length > 15) TXT_ClaseTipo.Text = primeraFila[15];
                if (primeraFila.Length > 16) TXT_Uso.Text = primeraFila[16];
                if (primeraFila.Length > 17) TXT_TipoServicio.Text = primeraFila[17];
                if (primeraFila.Length > 18) TXT_NoConcesion.Text = primeraFila[18];
                if (primeraFila.Length > 19) TXT_VehiculoOrigen.Text = primeraFila[19];
                if (primeraFila.Length > 20) TXT_SitioRuta.Text = primeraFila[20];
                if (primeraFila.Length > 21) TXT_Folio.Text = primeraFila[21];
            }
            else
            {
                TXT_Propietario.Text = "";
                TXT_Domicilio.Text = "";
                TXT_Vehiculo.Text = "";
                TXT_RFC.Text = "";
                TXT_Repuve.Text = "";
                TXT_NIV.Text = "";
                TXT_Placas.Text = "";
                TXT_Toneladas.Text = "";
                TXT_NoMotor.Text = "";
                TXT_Cilindros.Text = "";
                TXT_Personas.Text = "";
                TXT_Marca.Text = "";
                TXT_Combustible.Text = "";
                TXT_Modelo.Text = "";
                TXT_ClaveVehicular.Text = "";
                TXT_ClaseTipo.Text = "";
                TXT_Uso.Text = "";
                TXT_TipoServicio.Text = "";
                TXT_NoConcesion.Text = "";
                TXT_VehiculoOrigen.Text = "";
                TXT_SitioRuta.Text = "";
                TXT_Folio.Text = "";
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
            this.TC(TXT_Placa.Text.Trim());
        }
    }
}
