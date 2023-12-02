using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using QuestPDF.Helpers;
using QuestPDF.Previewer;

namespace SGIMTProyecto {
    public partial class F_PermisoPasoAnual : UserControl {
        public F_PermisoPasoAnual() {
            InitializeComponent();
        }

        #region
        private (string, bool) VerificacionParametros() {
            string error, variable;
            bool bandera = false;

            List<string> parametros = new List<string>();

            int tamanio;

            if (TXT_Nombre.Text.Trim().Length > 60 || TXT_Nombre.Text.Trim().Length < 1) {
                variable = JLB_Nombre.Text;
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
            if (TXT_RFV.Text.Length > 17 || TXT_RFV.Text.Length < 1) {
                variable = JLB_RFV.Text;
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
            if (TXT_Recorrido.Text.Trim().Length > 200 || TXT_Recorrido.Text.Trim().Length < 1) {
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
            if (!int.TryParse(TXT_FolioPermiso.Text.Trim(), out int folioPermiso)) {
                variable = JLB_FolioPermiso.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_NoMovimiento.Text.Trim(), out int noMovimiento)) {
                variable = JLB_NoMovimiento.Text;
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
            D_PasoAnual Datos = new D_PasoAnual();
            return Datos.ObtenerTitularSMyT();
        }

        private void InsertarPasoAnual(List<object> datosPasoAnual) {
            D_PasoAnual Datos = new D_PasoAnual();
            Datos.InsertarPasoAnual(datosPasoAnual);
        }

        private void LimpiarTextBox() {
            TXT_Nombre.Text = "";
            TXT_Domicilio.Text = "";
            TXT_Poblacion.Text = "";
            TXT_CP.Text = "";
            TXT_NoSerie.Text = "";
            TXT_NoMotor.Text = "";
            TXT_RFV.Text = "";
            TXT_Marca.Text = "";
            TXT_Modelo.Text = "";
            TXT_Placas.Text = "";
            TXT_TarjetaCirculacion.Text = "";
            TXT_Recorrido.Text = "";
            TXT_FolioPermiso.Text = "";
            TXT_NoMovimiento.Text = "";
        }
        #endregion

        private void F_PermisoPasoAnual_Load(object sender, EventArgs e) {
            TXT_TitularSMyT.Text = ObtenerTitularSMyT();
            TXT_TitularSMyT.Enabled = false;
        }

        private void BTN_Imprimir_Click(object sender, EventArgs e) {

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

                List<object> datosPasoAnual = new List<object> {
                        TXT_Nombre.Text.Trim(),
                        TXT_Domicilio.Text.Trim(),
                        TXT_Poblacion.Text.Trim(),
                        int.Parse(TXT_CP.Text.Trim()),
                        TXT_NoSerie.Text.Trim(),
                        int.Parse(TXT_NoMotor.Text.Trim()),
                        TXT_RFV.Text.Trim(),
                        TXT_Marca.Text.Trim(),
                        TXT_Modelo.Text.Trim(),
                        TXT_Placas.Text.Trim(),
                        int.Parse(TXT_TarjetaCirculacion.Text.Trim()),
                        TXT_Recorrido.Text.Trim(),
                        fechaExpedicion,
                        fechaVigencia,
                        int.Parse(TXT_FolioPermiso.Text.Trim()),
                        int.Parse(TXT_NoMovimiento.Text.Trim())
                    };

                InsertarPasoAnual(datosPasoAnual);

                MessageBox.Show("El registro se agrego con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarTextBox();

                //impresion
                /*REQUISITOS
                 * 
                 * string placa = "AXXXXX";
                    string nombre = "MANUEL ALEJANDRO MORA MENESES";
                    string direccion = "Enrique segoviano";
                    string poblacion = "AMAXAC DE GUERRERO";
                    int CP = 90600;
                    int TC = 4812;
                    string serie = "VF1FLADRACY419294";
                    string motor = "C683198";
                    int modelo = 2023;
                    int folio = 2712;
                    string marca = "RENAULT TRAFIC";

                    string recorrido = "INFORNAVIT PETROQUIMICA.TLAX DE XICOHTENCATL-PROCURADURIA GRAL DE JUSTICIA PI (GRAN PATIO, SAN PABLO APETATITLAN, CAMINO REAL, GARITA, MERCADO, CENTRAL CAMNIONERA, SOBRE LIBRIAMIENTO INSTITUTO POLITECNICO NACIONAL, TEPEHITEC).";
                    string fechaVig = "31/12/2023";
                    string director = "LIC. JOSE ANTONIO CARAMILLO SANCHEZ";
                 * 
                 */
            }
        }

        private static object GenerarPDF(string placa, string nombre, string direccion, string poblacion, int CP, int TC, string serie, string motor, int modelo, int folio, string marca, string recorrido, string fechaVig, string director)
        {
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            DateTime today = DateTime.Today;
            string fechaHoy = DateTime.Today.ToString("dd/M/yyyy", culturaEspañol);

            var documentopdf =
            Document.Create(documento =>
            {
                documento.Page(pagina =>
                {
                    pagina.Margin(30);
                    pagina.Header().Text("");
                    pagina.Content().Column(col =>
                    {
                        col.Item().PaddingTop(50);
                        col.Item().Text($"{nombre}").FontSize(10);
                        col.Item().Padding(10);
                        col.Item().Text($"{direccion}").FontSize(10);
                        col.Item().Padding(10);
                        col.Item().Row(row =>
                        {
                            row.RelativeItem(3).Text($"{poblacion}").FontSize(10);
                            row.RelativeItem().Text($"{CP}").FontSize(10);
                        });
                        col.Item().Padding(10);
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"{recorrido}").FontSize(9);
                        });
                        col.Item().Padding(10);
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"{motor}").FontSize(9);
                            row.RelativeItem().Text($"{serie}").FontSize(9);
                            row.RelativeItem().Text($"").FontSize(9);
                        });
                        col.Item().Padding(10);
                        col.Item().Row(row =>
                        {
                            row.RelativeItem(1.5f).Text($"{marca}").FontSize(9);
                            row.RelativeItem().Text($"{placa}").FontSize(9);
                            row.RelativeItem().Text($"{modelo}").FontSize(9);
                            row.RelativeItem().Text($"{TC}").FontSize(9);
                        });

                        col.Item().Padding(20);
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"{fechaHoy}").FontSize(10);
                            row.RelativeItem().Text($"{fechaVig}").FontSize(9);
                            row.RelativeItem().Text($"{director}").FontSize(9);
                        });
                        col.Item().Padding(20);
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"{folio}").FontSize(10);
                        });
                    });
                });
            }).GeneratePdf();

            return documentopdf;
        }

    }
}
