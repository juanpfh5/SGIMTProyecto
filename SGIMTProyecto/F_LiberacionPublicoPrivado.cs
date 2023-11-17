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
    public partial class F_LiberacionPublicoPrivado : UserControl
    {
        public F_LiberacionPublicoPrivado()
        {
            InitializeComponent();
        }

        #region Métodos

        private void LimpiarTextBox() {
            TXT_Marca.Text = "";
            TXT_Modelo.Text = "";
            TXT_Tipo.Text = "";
            TXT_NoSerie.Text = "";
            TXT_NoMotor.Text = "";
        }
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
                LimpiarTextBox();
                MessageBox.Show("Lo sentimos, la placa no existe en la base de datos :(", "Placa Ausente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private (string, bool) VerificacionParametros()
        {
            string error = "";
            bool bandera = false;

            List<string> parametros = new List<string>();

            int tamanio;

            if (!int.TryParse(TXT_NoBaja.Text, out int noBaja))
            {
                parametros.Add("No. Baja");
                bandera = true;
            }
            
            tamanio = parametros.Count;

            if (tamanio == 1)
            {
                error = "Verifica el siguiente parámetro: ";
            }
            else
            {
                error = "Verifica los siguientes parámetros: ";
            }

            for (int i = 0; i < tamanio; i++)
            {
                error += parametros[i];
                if (i != tamanio - 1)
                {
                    error += ", ";
                }
            }

            return (error, bandera);
        }

        private bool ExistenciaVehiculo(string cTexto)
        {
            D_LiberacionPublicoPrivado Datos = new D_LiberacionPublicoPrivado();
            return Datos.ExistenciaVehiculo(cTexto);
        }

        private void ActualizarLiberacion(string placa)
        {
            D_LiberacionPublicoPrivado Datos = new D_LiberacionPublicoPrivado();
            Datos.ActualizarLiberacion(placa);
        }

        #endregion

        private void BTN_Buscar_Click(object sender, EventArgs e)
        {
            this.LiberacionP_P(TXT_Placa.Text.Trim());
        }

        private void BTN_Imprimir_Click(object sender, EventArgs e)
        {
            (string mensajeError, bool bandera) = VerificacionParametros();

            if (bandera)
            {
                MessageBox.Show(mensajeError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (this.ExistenciaVehiculo(TXT_Placa.Text.Trim()))
                {

                    ActualizarLiberacion(TXT_Placa.Text.Trim());

                    MessageBox.Show("La unidad ha sido dada de baja correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarTextBox();
                }
                else
                {
                    MessageBox.Show("El vehículo no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
