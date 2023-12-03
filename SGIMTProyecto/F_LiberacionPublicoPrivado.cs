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
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using System.Globalization;


namespace SGIMTProyecto {
    public partial class F_LiberacionPublicoPrivado : UserControl {
        public F_LiberacionPublicoPrivado() {
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
        private void LiberacionP_P(string cTexto) {
            D_LiberacionPublicoPrivado Datos = new D_LiberacionPublicoPrivado();
            MostrarDatos(Datos.LiberacionP_P(cTexto));
        }

        private void MostrarDatos(List<string[]> datos) {
            // Verificar que haya al menos una fila de datos
            if (datos.Count > 0) {
                // Acceder a los valores de la primera fila
                string[] primeraFila = datos[0];

                // Mostrar los valores en TextBox correspondientes
                if (primeraFila.Length > 0) TXT_Marca.Text = primeraFila[0];
                if (primeraFila.Length > 1) TXT_Modelo.Text = primeraFila[1];
                if (primeraFila.Length > 2) TXT_Tipo.Text = primeraFila[2];
                if (primeraFila.Length > 3) TXT_NoSerie.Text = primeraFila[3];
                if (primeraFila.Length > 4) TXT_NoMotor.Text = primeraFila[4];
            } else {
                LimpiarTextBox();
                MessageBox.Show("Lo sentimos, la placa no existe en la base de datos :(", "Placa Ausente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private (string, bool) VerificacionParametros() {
            string error, variable;
            bool bandera = false;

            List<string> parametros = new List<string>();

            int tamanio;

            if (!int.TryParse(TXT_NoBaja.Text, out int noBaja)) {
                variable = JLB_NoBaja.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (DTP_Fecha.Value > DateTime.Now) {
                variable = JLB_Fecha.Text;
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

        private bool ExistenciaVehiculo(string cTexto) {
            D_LiberacionPublicoPrivado Datos = new D_LiberacionPublicoPrivado();
            return Datos.ExistenciaVehiculo(cTexto);
        }

        private void ActualizarLiberacion(string placa) {
            D_LiberacionPublicoPrivado Datos = new D_LiberacionPublicoPrivado();
            Datos.ActualizarLiberacion(placa);
        }

        #endregion

        private void BTN_Buscar_Click(object sender, EventArgs e) {
            if (!TXT_Placa.Text.Trim().Equals("Placa")) {
                this.LiberacionP_P(TXT_Placa.Text.Trim());
            }
        }

        private void BTN_Imprimir_Click(object sender, EventArgs e) {
            if (!TXT_Placa.Text.Trim().Equals("Placa")) {
                (string mensajeError, bool bandera) = VerificacionParametros();

                if (bandera) {
                    MessageBox.Show(mensajeError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    if (this.ExistenciaVehiculo(TXT_Placa.Text.Trim())) {

                        ActualizarLiberacion(TXT_Placa.Text.Trim());

                        // Imprimir
                        /*DATOS NECESARIOS PARA IMPRIMIR
                         * 
                         * CultureInfo culturaEspañol = new CultureInfo("es-ES");
                            DateTime today = DateTime.Today;

                            string fechaHoy = DateTime.Today.ToString("dd/M/yyyy", culturaEspañol);

                            int year = today.Year;
                            int dia = today.Day;
                            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);

                            int nOficio = 1570;
                            string marca = "TOYOTA";
                            int modelo = 2009;
                            string tipo = "HIACE GV S";
                            string serie = "JTFPX22P890015513";
                            string motor = "2TR8162498";

                            int nBaja = 45971683;
                            string fechaRecibo = "2/22/2022";
                            string director = "LIC. JOSE ANTONIO CARAMILLO SANCHEZ";
                         * 
                         */

                        MessageBox.Show("La unidad ha sido dada de baja correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarTextBox();
                    } else {
                        MessageBox.Show("El vehículo no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
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

        private void F_LiberacionPublicoPrivado_Click(object sender, EventArgs e) {

        }

        private static object GenerarLiberacion(int nOficio, string marca, int modelo, string tipo, string serie, string motor, int nBaja, string fechaRecibo, string director)
        {
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            DateTime today = DateTime.Today;
            string fechaHoy = DateTime.Today.ToString("dd/M/yyyy", culturaEspañol);
            int year = today.Year;
            int dia = today.Day;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);

            var documentopdf =
            Document.Create(documento =>
            {
                documento.Page(pagina =>
                {
                    pagina.Margin(80);
                    pagina.Header().Column(colh =>
                    {
                        colh.Item().Table(row =>
                        {
                            row.ColumnsDefinition(deff =>
                            {
                                deff.RelativeColumn(3);
                                deff.RelativeColumn(2);
                            });
                            row.Cell().Width(180).AlignRight().Image("C:\\Users\\aleja\\OneDrive\\Documentos\\UATx\\PorgEvolutiva\\ConsolaOrdenCobroPDF\\Resources\\logosmyt_1920_black.png");
                            row.Cell().Width(120).AlignLeft().Image("C:\\Users\\aleja\\OneDrive\\Documentos\\UATx\\PorgEvolutiva\\ConsolaOrdenCobroPDF\\Resources\\tlaxcala_nuevahistoria_black.png");

                        });

                    });
                    pagina.Content().Column(columna =>
                    {
                        columna.Item().PaddingTop(3);
                        columna.Item().AlignRight().Text($"FORMATO DST/{nOficio}/{year}").FontSize(10);
                        columna.Item().Padding(15);
                        columna.Item().AlignCenter().Text("SECRETARÍA DE MOVILIDAD Y TRANSPORTES.").FontSize(9).Bold();
                        columna.Item().AlignCenter().Text("TRAMITE DE ALTA VEHICULAR.").FontSize(9).Bold();
                        columna.Item().AlignCenter().Text("SERVICIO PARTICULAR.").FontSize(9).Bold();
                        columna.Item().AlignRight().Text($"FECHA:{fechaHoy}").FontSize(9);
                        columna.Item().Padding(25);
                        columna.Item().AlignCenter().Text(texto =>
                        {
                            texto.Span("MARCA:  ").FontSize(9).Bold();
                            texto.Span($"{marca}").FontSize(9);
                        });
                        columna.Item().Padding(10);
                        columna.Item().AlignCenter().Text(texto =>
                        {
                            texto.Span("MODELO:  ").FontSize(9).Bold();
                            texto.Span($"{modelo}").FontSize(9);
                        });
                        columna.Item().Padding(10);
                        columna.Item().AlignCenter().Text(texto =>
                        {
                            texto.Span("TIPO:  ").FontSize(9).Bold();
                            texto.Span($"{tipo}").FontSize(9);
                        });
                        columna.Item().Padding(25);
                        columna.Item().AlignCenter().Text(texto =>
                        {
                            texto.Span("SERIE:  ").FontSize(9).Bold();
                            texto.Span($"{serie}").FontSize(9);
                        });
                        columna.Item().Padding(10);
                        columna.Item().AlignCenter().Text(texto =>
                        {
                            texto.Span("MOTOR:  ").FontSize(9).Bold();
                            texto.Span($"{motor}").FontSize(9);
                        });
                        columna.Item().Padding(25);
                        columna.Item().AlignCenter().Text(texto =>
                        {
                            texto.Span("NÚMERO DE BAJA:  ").FontSize(9).Bold();
                            texto.Span($"{nBaja}").FontSize(9);
                        });
                        columna.Item().Padding(10);
                        columna.Item().AlignCenter().Text(texto =>
                        {
                            texto.Span("FECHA:  ").FontSize(9).Bold();
                            texto.Span($"{fechaRecibo}").FontSize(9);
                        });

                        columna.Item().Padding(35);
                        columna.Item().AlignCenter().Text("PREVIO ANALISIS DE DOCUMENTACION CORRESPONDIENTE").FontSize(9);
                        columna.Item().AlignCenter().Text(texto =>
                        {
                            texto.Span("NOTA: ").FontSize(9);
                            texto.Span("ENPLACAMIENTO A PLACAS PARTICULARES, NO AUTORIZA ").FontSize(9).Bold();
                            texto.Span("TRANSPORTE DE PERSONAL.").FontSize(9);
                        });
                        columna.Item().Padding(15);
                        columna.Item().AlignCenter().Text($"DIRECTOR DE TRANSPORTES DE LA SMYT").Bold().FontSize(9);
                        columna.Item().AlignCenter().Text($"{director}").Bold().FontSize(9);


                    });
                });
            }).GeneratePdf();

            return documentopdf;

        }
    }
}
