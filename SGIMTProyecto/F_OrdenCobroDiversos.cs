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
    public partial class F_OrdenCobroDiversos : UserControl
    {
        public F_OrdenCobroDiversos()
        {
            InitializeComponent();
        }

        #region Métodos
        private void OrdenCD(string cTexto)
        {
            D_OrdenCobroDiversos Datos = new D_OrdenCobroDiversos();
            MostrarDatos(Datos.OrdenCD(cTexto));
        }

        private List<string> ListadoPersonal() {
            D_OrdenCobroDiversos Datos = new D_OrdenCobroDiversos();
            return Datos.ListadoPersonal();
        }

        private void LimpiarTextBox() {
            TXT_Nombre.Text = "";
            TXT_NoExterior.Text = "";
            TXT_Domicilio.Text = "";
            TXT_NoInterior.Text = "";
            TXT_RFC.Text = "";
            TXT_CP.Text = "";
            TXT_Colonia.Text = "";
            TXT_Estado.Text = "";
            TXT_Municipio.Text = "";
            TXT_NoMovimiento.Text = "";
            TXT_Total.Text = "";
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
                LimpiarTextBox();
                MessageBox.Show("Lo sentimos, la placa no existe en la base de datos :(", "Placa Ausente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private (string, bool) VerificacionParametros() {
            string error, variable;
            bool bandera = false;

            List<string> parametros = new List<string>();

            int tamanio;

            if (TXT_Nombre.Text.Trim().Length > 60 || (TXT_Nombre.Text.Trim().Length < 1)) {
                variable = JLB_Nombre.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_NoExterior.Text.Trim().Length > 10 || (TXT_NoExterior.Text.Trim().Length < 1)) {
                variable = JLB_NoExterior.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Domicilio.Text.Trim().Length > 150 || (TXT_Domicilio.Text.Trim().Length < 1)) {
                variable = JLB_Domicilio.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_NoInterior.Text.Trim().Length > 10) {
                variable = JLB_NoInterior.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_RFC.Text.Trim().Length > 13 || (TXT_RFC.Text.Trim().Length < 1)) {
                variable = JLB_RFC.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_CP.Text.Trim().Length != 5 || !int.TryParse(TXT_CP.Text.Trim(), out int cp)) {
                variable = JLB_CP.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Colonia.Text.Trim().Length > 50 || (TXT_Colonia.Text.Trim().Length < 1)) {
                variable = JLB_Colonia.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Estado.Text.Trim().Length > 50 || (TXT_Estado.Text.Trim().Length < 1)) {
                variable = JLB_Estado.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Municipio.Text.Trim().Length > 50 || (TXT_Municipio.Text.Trim().Length < 1)) {
                variable = JLB_Municipio.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_NoMovimiento.Text.Trim(), out int noMovimiento)) {
                variable = JLB_NoMovimiento.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (DGV_Clave.Rows.Count < 1) {
                variable = JLB_Clave.Text;
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

        #endregion

        private void BTN_BuscarPlaca_Click(object sender, EventArgs e)
        {
            if (!TXT_Placa.Text.Trim().Equals("Placa")) {
                this.OrdenCD(TXT_Placa.Text.Trim());
                TXT_Nombre.Enabled = false;
                TXT_NoExterior.Enabled = false;
                TXT_Domicilio.Enabled = false;
                TXT_NoInterior.Enabled = false;
                TXT_RFC.Enabled = false;
                TXT_CP.Enabled = false;
                TXT_Colonia.Enabled = false;
                TXT_Estado.Enabled = false;
                TXT_Municipio.Enabled = false;
            }
        }
        private void BTN_Imprimir_Click(object sender, EventArgs e) {
            if (!TXT_Placa.Text.Trim().Equals("Placa")){
                (string mensajeError, bool bandera) = VerificacionParametros();

                if (bandera) {
                    MessageBox.Show(mensajeError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    /*if (this.ExistenciaVehiculo(TXT_Placa.Text.Trim())) {

                    }*/
                }
            }
        }
        private void F_OrdenCobroDiversos_Load(object sender, EventArgs e) {
            CMB_Elaboro.DataSource = ListadoPersonal();
            DGV_Clave.Rows.Clear();
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
