using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuestPDF.Fluent;
using System.Globalization;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Drawing.Printing;

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

                    /* PARAMETROS A PASAR:
                     * var documentoPDF = GenerarPdf();# aqui se le pasa los parametros que son:
                     * 
                     * string placa, 
                     * string nombre, 
                     * string direccion, 
                     * int CP, 
                     * int folioR, 
                     * string serie, 
                     * string motor, 
                     * int modelo, 
                     * string marca, 
                     * string clvVehicular, 
                     * string tipo, 
                     * decimal total, 
                     * string elaboro, 
                     * List<int> claves, 
                     * List<String>descripcion, 
                     * List<decimal>importe, 
                     * string mesVigencia, 
                     * int diaVigencia, 
                     * int yearVigencia
                     * int nMovimiento
                     */

                    #region Generar Resumen
                    /*
                     * //datos diferentes para el RESUMEN
                     * 
                        funcion:
                        GenerarpdfResumen()

                        string rfc = "TUX920811PQ7";
                        string ruta = "INTERNA DE LA CIUDAD DE TLAXCALA AUTORIZADA POR LA SECRETARIA DE COMUNICACIONES CONFORME A PLANO SUJETO A ROL POR LA EMPRESA";
                        string observaciones = "CANJE DE PLACAS 2023";
                        string fecha = "15/AGOSTO/2023";
                        string elaboroC = "JOSE ALFREDO CRUZ MARTINEZ";
                        string autorizoC = "ING. FELIPE HERNANDEZ JUAREZ";
                        string combustible = "GASOLINA";
                        string capacidad = "20 PASAEROS";
                     * 
                     * 
                     */
                    #endregion
                }
            }
            

            /*POSIBLE FORMA DE VISUALIZAR EL PDF
             * 
             * 
             * var docPDFgenerado = GenerarPdf(placa, nombre, direccion, CP, folioR, serie, motor, modelo, marca, clvVehicular, tipo, total, elaboro, claves, descripcion, importe, mesVigencia, diaVigencia, yearVigencia);
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

            printPreviewDialog1.Document = docPDFgenerado as PrintDocument;
            printPreviewDialog1.ShowDialog();*/
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

        #region Generacion de PDF
        private static object GenerarPdf(string placa, string nombre, string direccion, int CP, int folioR, string serie, string motor, int modelo, string marca, string clvVehicular, string tipo, decimal total, string elaboro, List<int> claves, List<String> descripcion, List<decimal> importe, string mesVigencia, int diaVigencia, int yearVigencia, int nMovimiento)
        {
            
            DateTime today = DateTime.Today;
            //variables dentro de la funcion:
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            int dia = today.Day;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);
            //creamos nuestro documento pdf
            var documentoPDF =
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(10);
                    page.Header().Row(fila =>
                    {
                        fila.ConstantItem(160).Background(Colors.Green.Medium).Height(100).Placeholder();
                        fila.RelativeItem().Column(col =>
                        {
                            col.Item()
                            .Height(20);
                            col.Item()
                            .AlignCenter()
                            .Text("ORDEN DE COBRO DERECHOS")
                            .Bold()
                            .FontSize(10);
                            col.Item()
                            .AlignCenter()
                            .Text("VEHICULARES TRANSPORTE PUBLICO 2023")
                            .Bold()
                            .FontSize(10);
                        });
                        fila.ConstantItem(160).Background(Colors.Grey.Medium).Height(100).Placeholder();
                    });
                    page.Content().Column(col1 =>
                    {
                        col1.Item().Text($"Apetatitlán, Tlax a {dia} de {mes} 2023").Bold();
                        col1.Item().Text($"PLACA: {placa}").Bold();
                        col1.Item().AlignCenter().Text("DATOS DE CONCECIONARIO").Bold().FontSize(12);
                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().Text(txt =>
                        {
                            txt.Span("NOMBRE: ").Bold().FontSize(10);
                            txt.Span($"{nombre}");
                            txt.Span("       CP: ").Bold().FontSize(10);
                            txt.Span($"{CP}");
                            txt.Span("       FOLIO DE REVISTA: ").Bold().FontSize(10);
                            txt.Span($"{folioR}");
                        });
                        col1.Item().Text(txt2 =>
                        {
                            txt2.Span("DIRECCION: ").Bold().FontSize(10);
                            txt2.Span($"{direccion}");


                        });
                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().AlignCenter().Text("DATOS  VEHÍCULO").Bold().FontSize(12);
                        // creacion de tabla

                        col1.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(60);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });
                            tabla.Cell().Text(" SERIE:").Bold();
                            tabla.Cell().AlignCenter().Text($"{serie}").FontSize(9);
                            tabla.Cell().Text(" MOTOR: ").Bold();
                            tabla.Cell().AlignCenter().Text($"{motor}").FontSize(9);
                            tabla.Cell().Text(" MODELO").Bold();
                            tabla.Cell().AlignCenter().Text($"{modelo}").FontSize(9);
                            tabla.Cell().Text(" MARCA: ").Bold();
                            tabla.Cell().AlignCenter().Text($"{marca}").FontSize(9);
                            tabla.Cell().Text(" CVE_VEHICULAR:").Bold();
                            tabla.Cell().AlignCenter().Text($"{clvVehicular}").FontSize(9);
                            tabla.Cell().Text(" TIPO: ").Bold();
                            tabla.Cell().AlignCenter().Text($"{tipo}").FontSize(9);
                        });
                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().Table(tabla2 =>
                        {
                            tabla2.ColumnsDefinition(columnas =>
                            {
                                columnas.ConstantColumn(60);
                                columnas.RelativeColumn();
                                columnas.ConstantColumn(100);
                            });

                            tabla2.Header(cabezera =>
                            {
                                cabezera.Cell().Text("CLAVE").Bold();
                                cabezera.Cell().AlignCenter().Text("DESCRIPCIÓN").Bold();
                                cabezera.Cell().Text("IMPORTE").Bold();
                            });
                            //aqui comenzamos la tabla dinamica
                            for (int i = 0; i < claves.Count; i++)
                            {
                                tabla2.Cell().Text($"{claves[i]}");
                                tabla2.Cell().AlignCenter().Text($"{descripcion[i]}");
                                tabla2.Cell().Text($"{importe[i]}");
                            }
                            tabla2.Cell().Text("");
                            tabla2.Cell().Text("");
                            tabla2.Cell().Text(txt =>
                            {
                                txt.Span("Total: ").Bold().FontSize(13);
                                txt.Span($"${total}");
                            });

                        });
                        col1.Item().AlignCenter().Text("");
                        col1.Item().AlignCenter().Text("AUTORIZÓ").Bold();
                        col1.Item().AlignCenter().Width(250).LineHorizontal(1f);
                        col1.Item().AlignCenter().Text($"{nombre}");
                        col1.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(160);
                                columns.RelativeColumn();
                                columns.ConstantColumn(200);
                            });
                            tabla.Cell().Text("");
                            tabla.Cell().Text("");
                            tabla.Cell().Text("");

                            tabla.Cell().Text(texto =>
                            {
                                texto.Span($"NUMERO DE MOVIMIENTO:{nMovimiento}").Bold().FontSize(9);
                            });
                            tabla.Cell().Text("");
                            tabla.Cell().Row(row =>
                            {
                                row.RelativeItem().Column(colum =>
                                {
                                    colum.Item().Text(texto =>
                                    {
                                        texto.Span("VIGENCIA HASTA:").FontSize(9).Bold();
                                        texto.Span($"{diaVigencia} DE {mesVigencia.ToUpper()} {yearVigencia}").FontSize(9);
                                    });
                                    colum.Item().Text(texto =>
                                    {
                                        texto.Span("ELABORÓ:").FontSize(9).Bold();
                                        texto.Span($"{elaboro}").FontSize(9);
                                    });
                                    colum.Item().Text(texto =>
                                    {
                                        texto.Span("SAN PABLO APETATITLÁN").FontSize(9).Bold();

                                    });

                                });

                            });

                        });
                    });
                });
            }).GeneratePdf();
            return documentoPDF;
        }

        private static object GenerarpdfResumen(string placa, string nombre, string direccion, int CP, int folioR, string serie, string motor, int modelo, string marca, string clvVehicular, string tipo, decimal total, string elaboro, List<int> claves, List<String> descripcion, List<decimal> importe, string mesVigencia, int diaVigencia, int yearVigencia, int nMovimiento, string rfc, string ruta, string observaciones, string fecha, string elaboroC, string autorizoC, string combustible, string capacidad)
        {
            var resumenPDF =
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(10);
                    page.Header().Row(fila =>
                    {
                        fila.ConstantItem(160).Image("C:\\Users\\aleja\\OneDrive\\Documentos\\UATx\\PorgEvolutiva\\ConsolaOrdenCobroPDF\\Resources\\logosmyt_1920_black.png");
                        fila.RelativeItem().Column(col =>
                        {
                            col.Item()
                            .Height(20);
                            col.Item()
                            .AlignCenter()
                            .Text("GOBIERNO DEL ESTADO DE TLAXCALA")
                            .Bold()
                            .FontSize(9);
                            col.Item()
                            .AlignCenter()
                            .Text("SECRETARIA DE MOVILIDAD Y TRANSPORTE")
                            .Bold()
                            .FontSize(9);
                            col.Item().AlignCenter().Text("SOLICITUD DE SERVICIO PUBLICO DE PASAJEROS").FontSize(9);
                        });
                        fila.ConstantItem(100).AlignLeft().Image("C:\\Users\\aleja\\OneDrive\\Documentos\\UATx\\PorgEvolutiva\\ConsolaOrdenCobroPDF\\Resources\\tlaxcala_nuevahistoria_black.png");
                    });
                    page.Content().Column(col1 =>
                    {

                        col1.Item().Text($"PLACA: {placa}");
                        col1.Item().AlignCenter().Text("DATOS DE CONCECIONARIO").Bold().FontSize(12);
                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().Text("NOMBRE DEL CONCECIONARIO: ").FontSize(10).Bold();
                        col1.Item().Text($"{nombre}").FontSize(10);
                        col1.Item().Text("DOMICILIO:").Bold().FontSize(10);
                        col1.Item().Text($"{direccion}").FontSize(10);

                        col1.Item().Text(texto =>
                        {
                            texto.Span("RFC: ").Bold().FontSize(10);
                            texto.Span($"{rfc}").FontSize(10);
                        });

                        col1.Item().Text("");
                        col1.Item().LineHorizontal(0.5f);
                        // creacion de tabla
                        col1.Item().Text("");

                        col1.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(65);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });
                            tabla.Cell().Text(" SERIE:").Bold().FontSize(9);
                            tabla.Cell().AlignCenter().Text($"{serie}").FontSize(9);
                            tabla.Cell().Text(" MOTOR: ").Bold().FontSize(9);
                            tabla.Cell().AlignCenter().Text($"{motor}").FontSize(9);
                            tabla.Cell().Text(" MODELO").Bold().FontSize(9);
                            tabla.Cell().AlignCenter().Text($"{modelo}").FontSize(9);
                            tabla.Cell().Text(" MARCA: ").Bold().FontSize(9);
                            tabla.Cell().AlignCenter().Text($"{marca}").FontSize(9);
                            tabla.Cell().Text(" CVE_VEHICULAR:").Bold().FontSize(9);
                            tabla.Cell().AlignCenter().Text($"{clvVehicular}").FontSize(9);
                            tabla.Cell().Text(" TIPO: ").Bold().FontSize(9);
                            tabla.Cell().AlignCenter().Text($"{tipo}").FontSize(9);
                            tabla.Cell().Text("COMBUSTIBLE: ").Bold().FontSize(9);
                            tabla.Cell().AlignCenter().Text($"{combustible}").FontSize(9);
                            tabla.Cell().Text("CAPACIDAD: ").Bold().FontSize(9);
                            tabla.Cell().AlignCenter().Text($"{capacidad}").FontSize(9);
                        });

                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().Text(texto =>
                        {
                            texto.Span("RUTA AUTORIZADA: ").FontSize(10).Bold();
                            texto.Span($"{ruta}").FontSize(10);
                        });
                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().Table(tabla2 =>
                        {
                            tabla2.ColumnsDefinition(columnas =>
                            {
                                columnas.ConstantColumn(60);
                                columnas.RelativeColumn();
                                columnas.ConstantColumn(100);
                            });

                            tabla2.Header(cabezera =>
                            {
                                cabezera.Cell().Text("CLAVE").Bold();
                                cabezera.Cell().AlignCenter().Text("DESCRIPCIÓN").Bold();
                                cabezera.Cell().Text("IMPORTE").Bold();
                            });
                            //aqui comenzamos la tabla dinamica
                            for (int i = 0; i < claves.Count; i++)
                            {
                                tabla2.Cell().Text($"{claves[i]}");
                                tabla2.Cell().AlignCenter().Text($"{descripcion[i]}");
                                tabla2.Cell().Text($"{importe[i]}");
                            }
                            tabla2.Cell().Text("");
                            tabla2.Cell().Text("");
                            tabla2.Cell().Text(txt =>
                            {
                                txt.Span("Total: ").Bold().FontSize(13);
                                txt.Span($"${total}");
                            });

                        });
                        col1.Item().AlignCenter().Text("");
                        col1.Item().AlignCenter().Text("AUTORIZÓ").Bold();
                        col1.Item().AlignCenter().Width(250).LineHorizontal(1f);
                        col1.Item().AlignCenter().Text($"{nombre}");
                        col1.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(160);
                                columns.RelativeColumn();
                                columns.ConstantColumn(200);
                            });
                            tabla.Cell().Text("");
                            tabla.Cell().Text("");
                            tabla.Cell().Text("");

                            tabla.Cell().Text(texto =>
                            {
                                texto.Span($"OBSERVACIONES:{observaciones}").Bold().FontSize(9);
                            });
                            tabla.Cell().Text("");
                            tabla.Cell().Row(row =>
                            {
                                row.RelativeItem().Column(colum =>
                                {
                                    colum.Item().Text(texto =>
                                    {
                                        texto.Span("VIGENCIA HASTA:").FontSize(9).Bold();
                                        texto.Span($"{diaVigencia} DE {mesVigencia.ToUpper()} {yearVigencia}").FontSize(9);
                                    });
                                    colum.Item().Text(texto =>
                                    {
                                        texto.Span("ELABORÓ:").FontSize(9).Bold();
                                        texto.Span($"{elaboro}").FontSize(9);
                                    });
                                    colum.Item().Text(texto =>
                                    {
                                        texto.Span("SAN PABLO APETATITLÁN").FontSize(9).Bold();

                                    });

                                });

                            });

                        });
                    });
                    page.Footer().Row(row =>
                    {

                        row.RelativeItem().AlignCenter().Column(texto =>
                        {
                            texto.Item().Text($"{fecha}").FontSize(9);
                            texto.Item().AlignCenter().Text("FECHA").Bold();
                        });
                        row.RelativeItem().AlignCenter().Column(texto =>
                        {
                            texto.Item().Text($"{elaboroC}").FontSize(9);
                            texto.Item().AlignCenter().Text("ELABORÓ").Bold();
                        });
                        row.RelativeItem().AlignCenter().Column(texto =>
                        {
                            texto.Item().Text($"{autorizoC}").FontSize(9);
                            texto.Item().AlignCenter().Text("AUTORIZÓ").Bold();
                        });

                    });
                });
            }).GeneratePdf();

            return resumenPDF;
        }

        #endregion

    }
}
