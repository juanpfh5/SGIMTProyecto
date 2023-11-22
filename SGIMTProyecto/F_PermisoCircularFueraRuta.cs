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
    public partial class F_PermisoCircularFueraRuta : UserControl
    {
        public F_PermisoCircularFueraRuta()
        {
            InitializeComponent();
        }

        #region Métodos
        private void CircularFR(string cTexto)
        {
            D_PermisoCircularFueraRuta Datos = new D_PermisoCircularFueraRuta();
            MostrarDatos(Datos.CircularFR(cTexto));
        }

        private void LimpiarTextBox() {
            TXT_Permisionario.Text = "";
            TXT_Domicilio.Text = "";
            TXT_Poblacion.Text = "";
            TXT_CP.Text = "";
            TXT_NoSerie.Text = "";
            TXT_NoMotor.Text = "";
            TXT_Repuve.Text = "";
            TXT_Marca.Text = "";
            TXT_Modelo.Text = "";
            TXT_Placas.Text = "";
            TXT_TarjetaCirculacion.Text = "";
            TXT_Recorrido.Text = "";
            TXT_Motivo.Text = "";
            TXT_FolioPermiso.Text = "";
            TXT_Placa.Text = "Placa";
            TXT_Placas.Enabled = true;
            TXT_TarjetaCirculacion.Enabled = true;
        }

        private void MostrarDatos(List<string[]> datos)
        {
            // Verificar que haya al menos una fila de datos
            if (datos.Count > 0)
            {
                // Acceder a los valores de la primera fila
                string[] primeraFila = datos[0];

                // Mostrar los valores en TextBox correspondientes
                if (primeraFila.Length > 0) TXT_Permisionario.Text = primeraFila[0];
                if (primeraFila.Length > 1) TXT_Domicilio.Text = primeraFila[1];
                if (primeraFila.Length > 2) TXT_Poblacion.Text = primeraFila[2];
                if (primeraFila.Length > 3) TXT_CP.Text = primeraFila[3];
                if (primeraFila.Length > 4) TXT_NoSerie.Text = primeraFila[4];
                if (primeraFila.Length > 5) TXT_NoMotor.Text = primeraFila[5];
                if (primeraFila.Length > 6) TXT_Repuve.Text = primeraFila[6];
                if (primeraFila.Length > 7) TXT_Marca.Text = primeraFila[7];
                if (primeraFila.Length > 8) TXT_Modelo.Text = primeraFila[8];
                if (primeraFila.Length > 9) TXT_Placas.Text = primeraFila[9];
                if (primeraFila.Length > 10) TXT_TarjetaCirculacion.Text = primeraFila[10];
                if (primeraFila.Length > 11) TXT_Recorrido.Text = primeraFila[11];
                if (primeraFila.Length > 12) TXT_TitularSMyT.Text = primeraFila[12];
            }
            else
            {
                LimpiarTextBox();
                MessageBox.Show("Lo sentimos, la placa no existe en la base de datos :(", "Placa Ausente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private (string, bool) VerificacionParametros() {
            string error, variable;
            bool bandera = false;

            List<string> parametros = new List<string>();

            int tamanio;

            if (TXT_Permisionario.Text.Trim().Length > 60 || TXT_Permisionario.Text.Trim().Length < 1) {
                variable = JLB_Permisionario.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Domicilio.Text.Trim().Length > 150 || TXT_Domicilio.Text.Trim().Length < 1) {
                variable = JLB_Domicilio.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Poblacion.Text.Trim().Length > 100 || TXT_Domicilio.Text.Trim().Length < 1) {
                variable = JLB_Poblacion.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_CP.Text.Trim().Length != 5 || !int.TryParse(TXT_CP.Text.Trim(), out int codigoPostal)) {
                variable = JLB_CP.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_NoSerie.Text.Length > 17 || TXT_NoSerie.Text.Length < 1) {
                variable = JLB_NoSerie.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_NoMotor.Text, out int noMotor)) {
                variable = JLB_NoMotor.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Repuve.Text.Length > 15 || TXT_Repuve.Text.Length < 1) {
                variable = JLB_Repuve.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Marca.Text.Trim().Length > 15 || TXT_Marca.Text.Trim().Length < 1) {
                variable = JLB_Marca.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_Modelo.Text.Trim(), out int modelo)) {
                variable = JLB_Modelo.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Placas.Text.Length != 9) {
                variable = JLB_Placas.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_TarjetaCirculacion.Text.Trim(), out int tarjetaCirculacion)) {
                variable = JLB_TarjetaCirculacion.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Recorrido.Text.Trim().Length > 500 || TXT_Recorrido.Text.Trim().Length < 1) {
                variable = JLB_Recorrido.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (DTP_FechaExpedicion.Value > DateTime.Now) {
                variable = JLB_FechaExpedicion.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (DTP_FechaVigencia.Value <= DateTime.Now) {
                variable = JLB_FechaVigencia.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Motivo.Text.Trim().Length > 200 || TXT_Motivo.Text.Trim().Length < 1) {
                variable = JLB_Motivo.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_FolioPermiso.Text.Trim(), out int folioPermiso)) {
                variable = JLB_FolioPermiso.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
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

        private string ObtenerTitularSMyT() {
            D_PermisoCircularFueraRuta Datos = new D_PermisoCircularFueraRuta();
            return Datos.ObtenerTitularSMyT();
        }

        private void InsertarFueraRuta(List<object> datosFueraRuta) {
            D_PermisoCircularFueraRuta Datos = new D_PermisoCircularFueraRuta();
            Datos.InsertarFueraRuta(datosFueraRuta);
        }
        #endregion

        private void BTN_BuscarPlaca_Click(object sender, EventArgs e)
        {
            if (!TXT_Placa.Text.Trim().Equals("Placa")) {
                this.CircularFR(TXT_Placa.Text.Trim());
                TXT_Placas.Enabled = false;
                TXT_TarjetaCirculacion.Enabled = false;
            }
        }

        private void BTN_Imprimir_Click(object sender, EventArgs e) {
            if (!TXT_Placa.Text.Trim().Equals("Placa")) {
                (string mensajeError, bool bandera) = VerificacionParametros();

                if (bandera) {
                    MessageBox.Show(mensajeError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    DateTime fechaSeleccionada = DTP_FechaExpedicion.Value;
                    string anio = fechaSeleccionada.Year.ToString();
                    string mes = fechaSeleccionada.Month.ToString("00");
                    string dia = fechaSeleccionada.Day.ToString("00");
                    string fechaExpedicion = anio + '-' + mes + '-' + dia;

                    fechaSeleccionada = DTP_FechaVigencia.Value;
                    anio = fechaSeleccionada.Year.ToString();
                    mes = fechaSeleccionada.Month.ToString("00");
                    dia = fechaSeleccionada.Day.ToString("00");
                    string fechaVigencia = anio + '-' + mes + '-' + dia;

                    List<object> datosFueraRuta = new List<object> {
                        TXT_Permisionario.Text.Trim(),
                        TXT_Domicilio.Text.Trim(),
                        TXT_Poblacion.Text.Trim(),
                        int.Parse(TXT_CP.Text.Trim()),
                        int.Parse(TXT_TarjetaCirculacion.Text.Trim()),
                        TXT_Marca.Text.Trim(),
                        TXT_Modelo.Text.Trim(),
                        TXT_NoSerie.Text.Trim(),
                        int.Parse(TXT_NoMotor.Text.Trim()),
                        TXT_Repuve.Text.Trim(),
                        TXT_Recorrido.Text.Trim(),
                        TXT_Motivo.Text.Trim(),
                        fechaExpedicion,
                        fechaVigencia,
                        int.Parse(TXT_FolioPermiso.Text.Trim()),
                        int.Parse(TXT_NoMovimiento.Text.Trim())
                    };

                    InsertarFueraRuta(datosFueraRuta);

                    MessageBox.Show("El registro se agrego con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarTextBox();
                }
            }
        }

        private void F_PermisoCircularFueraRuta_Load(object sender, EventArgs e) {
            TXT_TitularSMyT.Text = ObtenerTitularSMyT();
        }

        #region PlaceHolder
        private void TXT_Placa_Enter(object sender, EventArgs e) {
            if (TXT_Placa.Text == "Placa") {
                TXT_Placa.Text = "";
                TXT_Placa.ForeColor = Color.Black;
            }
        }

        private void TXT_Placa_Leave(object sender, EventArgs e) {
            if (TXT_Placa.Text == "") {
                TXT_Placa.Text = "Placa";
                TXT_Placa.ForeColor = Color.Gray;
            }
        }
        #endregion

    }
}
