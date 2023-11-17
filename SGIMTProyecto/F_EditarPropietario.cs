using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SGIMTProyecto
{
    public partial class F_EditarPropietario : UserControl
    {
        public F_EditarPropietario()
        {
            InitializeComponent();
        }

        #region Métodos
        private void DatosPropietario(string placa)
        {
            D_EditarPropietario Datos = new D_EditarPropietario();
            MostrarDatos(Datos.DatosPropietario(placa));
        }

        private void LimpiarTextBox() {
            TXT_Nombre.Text = "";
            TXT_Placas.Text = "";
            TXT_Domicilio.Text = "";
            TXT_RFC.Text = "";
            TXT_NoExterior.Text = "";
            TXT_NoInterior.Text = "";
            TXT_CP.Text = "";
            TXT_Colonia.Text = "";
            TXT_Municipio.Text = "";
            TXT_Estado.Text = "";
            TXT_NoConcesion.Text = "";
            TXT_NoSeguro.Text = "";
        }

        private void MostrarDatos(List<string[]> datos)
        {
            if (datos.Count > 0)
            {
                string[] primeraFila = datos[0];

                if (primeraFila.Length > 0) TXT_Nombre.Text = primeraFila[0];
                if (primeraFila.Length > 1) TXT_Placas.Text = primeraFila[1];
                if (primeraFila.Length > 2) TXT_Domicilio.Text = primeraFila[2];
                if (primeraFila.Length > 3) TXT_RFC.Text = primeraFila[3];
                if (primeraFila.Length > 4) TXT_NoExterior.Text = primeraFila[4];
                if (primeraFila.Length > 5) TXT_NoInterior.Text = primeraFila[5];
                if (primeraFila.Length > 6) TXT_CP.Text = primeraFila[6];
                if (primeraFila.Length > 7) TXT_Colonia.Text = primeraFila[7];
                if (primeraFila.Length > 8) TXT_Municipio.Text = primeraFila[8];
                if (primeraFila.Length > 9) TXT_Estado.Text = primeraFila[9];
                if (primeraFila.Length > 10) TXT_NoConcesion.Text = primeraFila[10];
                if (primeraFila.Length > 11) TXT_NoSeguro.Text = primeraFila[11];
            }
            else
            {
                LimpiarTextBox();
                MessageBox.Show("Lo sentimos, la placa no existe en la base de datos :(", "Placa Ausente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private (string, bool) VerificacionParametros() {
            string error = "";
            bool bandera = false;

            List<string> parametros = new List<string>();

            int tamanio;

            if (TXT_Nombre.Text.Length > 50 || TXT_Nombre.Text.Length < 1)
            {
                parametros.Add("Nombre");
                bandera = true;
            }
            if (TXT_Domicilio.Text.Length > 150 || TXT_Domicilio.Text.Length < 1)
            {
                parametros.Add("Domicilio");
                bandera = true;
            }
            if (TXT_RFC.Text.Length != 13)
            {
                parametros.Add("RFC");
                bandera = true;
            }
            if (TXT_NoExterior.Text.Length > 10 || TXT_NoExterior.Text.Length < 1)
            {
                parametros.Add("No. Exterior");
                bandera = true;
            }
            if (TXT_NoInterior.Text.Length > 10)
            {
                parametros.Add("No. Interior");
                bandera = true;
            }
            if (TXT_CP.Text.Length != 5 && int.TryParse(TXT_CP.Text, out int codigoPostal))
            {
                parametros.Add("CP");
                bandera = true;
            }
            if (TXT_Colonia.Text.Length > 50 || TXT_Colonia.Text.Length < 1)
            {
                parametros.Add("Colonia");
                bandera = true;
            }
            if (TXT_Municipio.Text.Length > 50 || TXT_Municipio.Text.Length < 1)
            {
                parametros.Add("Municipio");
                bandera = true;
            }
            if (TXT_Estado.Text.Length > 50 || TXT_Estado.Text.Length < 1)
            {
                parametros.Add("Estado");
                bandera = true;
            }

            tamanio = parametros.Count;

            if (tamanio == 1) {
                error = "Verifica el siguiente parámetro: ";
            } else {
                error = "Verifica los siguientes parámetros: ";
            }

            for (int i = 0; i < tamanio; i++) {
                error += parametros[i];
                if (i != tamanio - 1) {
                    error += ", ";
                }
            }

            return (error, bandera);
        }

        private bool ExistenciaVehiculo(string cTexto)
        {
            D_EditarPropietario Datos = new D_EditarPropietario();
            return Datos.ExistenciaVehiculo(cTexto);
        }

        private void ActualizarPropietario(List<object> datosPropietario, string placa) {
            D_EditarPropietario Datos = new D_EditarPropietario();
            Datos.ActualizarPropietario(datosPropietario, placa);
        }

        #endregion

        private void BTN_Buscar_Click(object sender, EventArgs e)
        {
            this.DatosPropietario(TXT_Placa.Text.Trim());
        }

        private void BTN_Guardar_Click(object sender, EventArgs e)
        {
            (string mensajeError, bool bandera) = VerificacionParametros();

            if (bandera)
            {
                MessageBox.Show(mensajeError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                if (this.ExistenciaVehiculo(TXT_Placa.Text.Trim())) {
                    List<object> datosPropietario = new List<object>();

                    datosPropietario.Add(TXT_Nombre.Text);
                    datosPropietario.Add(TXT_Domicilio.Text);
                    datosPropietario.Add(TXT_RFC.Text);
                    datosPropietario.Add(TXT_NoExterior.Text);
                    datosPropietario.Add(TXT_NoInterior.Text);
                    datosPropietario.Add(int.Parse(TXT_CP.Text));
                    datosPropietario.Add(TXT_Colonia.Text);
                    datosPropietario.Add(TXT_Municipio.Text);
                    datosPropietario.Add(TXT_Estado.Text);

                    ActualizarPropietario(datosPropietario, TXT_Placa.Text.Trim());

                    MessageBox.Show("Los datos del propietario se han actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarTextBox();
                } else {
                    MessageBox.Show("El vehículo no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #region PlaceHolder
        private void TXT_Placa_Enter(object sender, EventArgs e)
        {
            if (TXT_Placa.Text == "Placa") {
                TXT_Placa.Text = "";
                TXT_Placa.ForeColor = Color.Black;
            }
        }

        private void TXT_Placa_Leave(object sender, EventArgs e)
        {
            if (TXT_Placa.Text == "")
            {
                TXT_Placa.Text = "Placa";
                TXT_Placa.ForeColor = Color.Gray;
            }
        }
        #endregion
    }
}
