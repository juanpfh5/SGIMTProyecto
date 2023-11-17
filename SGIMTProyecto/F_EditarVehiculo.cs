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
    public partial class F_EditarVehiculo : UserControl
    {
        public F_EditarVehiculo()
        {
            InitializeComponent();
        }

        #region Métodos

        private void LimpiarTextBox() {
            TXT_Nombre.Text = "";
            TXT_Vehiculo.Text = "";
            TXT_Marca.Text = "";
            TXT_Modelo.Text = "";
            TXT_Tipo.Text = "";
            TXT_TipoServicio.Text = "";
            TXT_VehiculoOrigen.Text = "";
            TXT_ClaveVehicular.Text = "";
            TXT_NoSeguro.Text = "";
            TXT_Repuve.Text = "";
            TXT_NoSerie.Text = "";
            TXT_NoMotor.Text = "";
            TXT_Cilindros.Text = "";
            TXT_Combustible.Text = "";
            TXT_Toneladas.Text = "";
            TXT_Pasajeros.Text = "";
            TXT_Uso.Text = "";
            TXT_Placas.Text = "";
            TXT_SitioRuta.Text = "";
            TXT_FolioTC.Text = "";
            TXT_RFV.Text = "";
            TXT_FolioRevista.Text = "";
        }
        private void DatosVehiculo (string cTexto)
        {
            D_EditarVehiculo Datos = new D_EditarVehiculo();
            MostrarDatos(Datos.DatosVehiculo(cTexto));
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
                if (primeraFila.Length > 1) TXT_Vehiculo.Text = primeraFila[1];
                if (primeraFila.Length > 2) TXT_Marca.Text = primeraFila[2];
                if (primeraFila.Length > 3) TXT_Modelo.Text = primeraFila[3];
                if (primeraFila.Length > 4) TXT_Tipo.Text = primeraFila[4];
                if (primeraFila.Length > 5) TXT_TipoServicio.Text = primeraFila[5];
                if (primeraFila.Length > 6) TXT_VehiculoOrigen.Text = primeraFila[6];
                if (primeraFila.Length > 7) TXT_ClaveVehicular.Text = primeraFila[7];
                if (primeraFila.Length > 8) TXT_NoSeguro.Text = primeraFila[8];
                if (primeraFila.Length > 9) TXT_Repuve.Text = primeraFila[9];
                if (primeraFila.Length > 10) TXT_NoSerie.Text = primeraFila[10];
                if (primeraFila.Length > 11) TXT_NoMotor.Text = primeraFila[11];
                if (primeraFila.Length > 12) TXT_Cilindros.Text = primeraFila[12];
                if (primeraFila.Length > 13) TXT_Combustible.Text = primeraFila[13];
                if (primeraFila.Length > 14) TXT_Toneladas.Text = primeraFila[14];
                if (primeraFila.Length > 15) TXT_Pasajeros.Text = primeraFila[15];
                if (primeraFila.Length > 16) TXT_Uso.Text = primeraFila[16];
                if (primeraFila.Length > 17) TXT_Placas.Text = primeraFila[17];
                if (primeraFila.Length > 18) TXT_SitioRuta.Text = primeraFila[18];
                if (primeraFila.Length > 19) TXT_FolioTC.Text = primeraFila[19];
                if (primeraFila.Length > 20) TXT_RFV.Text = primeraFila[20];
                if (primeraFila.Length > 21) TXT_FolioRevista.Text = primeraFila[21];
            }
            else
            {
                LimpiarTextBox();
                MessageBox.Show("Lo sentimos, la placa no existe en la base de datos :(", "Placa Ausente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ExistenciaVehiculo(string cTexto)
        {
            D_EditarPropietario Datos = new D_EditarPropietario();
            return Datos.ExistenciaVehiculo(cTexto);
        }

        private void ActualizarVehiculo(List<object> datosVehiculo, string placa)
        {
            D_EditarVehiculo Datos = new D_EditarVehiculo();
            Datos.ActualizarVehiculo(datosVehiculo, placa);
        }

        private (string, bool) VerificacionParametros()
        {
            string error = "";
            bool bandera = false;

            List<string> parametros = new List<string>();

            int tamanio;

            /*if (TXT_Nombre.Text.Length > 50 || TXT_Nombre.Text.Length < 1)
            {
                parametros.Add("Nombre");
                bandera = true;
            }*/
            if (TXT_Vehiculo.Text.Length > 15 || TXT_Vehiculo.Text.Length < 1)
            {
                parametros.Add("Vehículo");
                bandera = true;
            }
            if (TXT_Marca.Text.Length > 15 || TXT_Marca.Text.Length < 1)
            {
                parametros.Add("Marca");
                bandera = true;
            }
            if (TXT_Modelo.Text.Length != 4 && int.TryParse(TXT_Modelo.Text, out int modelo))
            {
                parametros.Add("Modelo");
                bandera = true;
            }
            if (TXT_Tipo.Text.Length > 15 || TXT_Tipo.Text.Length < 1)
            {
                parametros.Add("Clase y Tipo");
                bandera = true;
            }
            if (TXT_TipoServicio.Text.Length > 50 || TXT_Tipo.Text.Length < 1)
            {
                parametros.Add("Tipo de Servicio");
                bandera = true;
            }
            if (TXT_VehiculoOrigen.Text.Length > 20 || TXT_VehiculoOrigen.Text.Length < 1)
            {
                parametros.Add("Vehículo Origen");
                bandera = true;
            }
            if (TXT_ClaveVehicular.Text.Length != 7)
            {
                parametros.Add("Clave Vehicular");
                bandera = true;
            }
            if (TXT_NoSeguro.Text.Length > 15 || TXT_NoSeguro.Text.Length < 1)
            {
                parametros.Add("No. Seguro");
                bandera = true;
            }
            if (TXT_Repuve.Text.Length > 15 || TXT_Repuve.Text.Length < 1)
            {
                parametros.Add("Repuve");
                bandera = true;
            }
            if (TXT_SitioRuta.Text.Length > 500 || TXT_SitioRuta.Text.Length < 1)
            {
                parametros.Add("Sitio o Ruta Autorizada");
                bandera = true;
            }
            if (!int.TryParse(TXT_FolioTC.Text, out int folioTC))
            {
                parametros.Add("Folio TC");
                bandera = true;
            }
            if (TXT_RFV.Text.Length > 17 || TXT_RFV.Text.Length < 1)
            {
                parametros.Add("RFV");
                bandera = true;
            }
            if (!int.TryParse(TXT_FolioRevista.Text, out int folioRevista))
            {
                parametros.Add("Folio Revista");
                bandera = true;
            }
            if (TXT_NoSerie.Text.Length > 17 || TXT_NoSerie.Text.Length < 1)
            {
                parametros.Add("No. Serie");
                bandera = true;
            }
            if (!int.TryParse(TXT_NoMotor.Text, out int noMotor))
            {
                parametros.Add("No. Motor");
                bandera = true;
            }
            if (TXT_Cilindros.Text.Length > 10 || TXT_Cilindros.Text.Length < 1)
            {
                parametros.Add("Cilindros");
                bandera = true;
            }
            if (TXT_Combustible.Text.Length > 15 || TXT_Combustible.Text.Length < 1)
            {
                parametros.Add("Combustible");
                bandera = true;
            }
            if (TXT_Toneladas.Text.Length > 10 || TXT_Toneladas.Text.Length < 1)
            {
                parametros.Add("Toneladas");
                bandera = true;
            }
            if (!int.TryParse(TXT_Pasajeros.Text, out int pasajeros))
            {
                parametros.Add("Pasajeros");
                bandera = true;
            }
            if (TXT_Uso.Text.Length > 25 || TXT_Uso.Text.Length < 1)
            {
                parametros.Add("Uso");
                bandera = true;
            }
            /*if (TXT_NoConcesion.Text.Length > 25 || TXT_NoConcesion.Text.Length < 1)
            {
                parametros.Add("No. Concesion");
                bandera = true;
            }*/

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

        #endregion

        private void BTN_Buscar_Click(object sender, EventArgs e)
        {
            this.DatosVehiculo(TXT_Placa.Text.Trim());
        }

        private void BTN_Guardar_Click(object sender, EventArgs e)
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
                    List<object> datosVehiculo = new List<object>();

                    datosVehiculo.Add(TXT_Vehiculo.Text);
                    datosVehiculo.Add(TXT_Marca.Text);
                    datosVehiculo.Add(TXT_Modelo.Text);
                    datosVehiculo.Add(TXT_Tipo.Text);
                    datosVehiculo.Add(TXT_TipoServicio.Text);
                    datosVehiculo.Add(TXT_VehiculoOrigen.Text);
                    datosVehiculo.Add(TXT_ClaveVehicular.Text);
                    datosVehiculo.Add(TXT_NoSeguro.Text);
                    datosVehiculo.Add(TXT_Repuve.Text);
                    datosVehiculo.Add(TXT_SitioRuta.Text);
                    datosVehiculo.Add(int.Parse(TXT_FolioTC.Text));
                    datosVehiculo.Add(TXT_RFV.Text);
                    datosVehiculo.Add(int.Parse(TXT_FolioRevista.Text));
                    datosVehiculo.Add(TXT_NoSerie.Text);
                    datosVehiculo.Add(TXT_NoMotor.Text);
                    datosVehiculo.Add(TXT_Cilindros.Text);
                    datosVehiculo.Add(TXT_Combustible.Text);
                    datosVehiculo.Add(TXT_Toneladas.Text);
                    datosVehiculo.Add(TXT_Pasajeros.Text);
                    datosVehiculo.Add(TXT_Uso.Text);

                    ActualizarVehiculo(datosVehiculo, TXT_Placa.Text.Trim());

                    MessageBox.Show("Los datos del propietario se han actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
