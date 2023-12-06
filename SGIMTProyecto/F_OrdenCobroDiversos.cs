
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


using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Drawing.Printing;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

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
        private static void GenerarPdf()
        {
            #region DATOS
            DateTime today = DateTime.Today;
            //variables dentro de la funcion:
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            int dia = today.Day;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);
            int year = today.Year;
            //variables para la vigencia

            string mesVigencia = today.ToString("MMMM", culturaEspañol);
            int diaVigencia = today.Day;
            int yearVigencia = today.Year;

            string placa = "AXXXXX";
            string nombre = "MANUEL ALEJANDRO MORA MENESES";
            string direccion = "ENCINOS NO 7 B. OCOTLAN DE TEPATLAXCO, CONTLA DE JUAN CUAMATIZI, TLAX.";
            int folioR = 185;

            string serie = "VF1FLADRACY419294";
            string motor = "C683198";
            int modelo = 2023;
            string marca = "RENAULT TRAFIC";
            string clvVehicular = "1982432";
            string tipo = "PANEL";
            decimal total = 1535;
            string elaboro = "J.A.C.M.";
            int nMovimiento = 234;
            //creacion de las listas para las claves, descripcion e importe
            List<int> claves = new List<int> { 512, 511, 315 };
            List<String> descripcion = new List<String> { "RREFRENDO 2023 PARA VEHICULOS DE 15 A 20 PSJ.", "Refrendo 2023 para vehiculos 5-14 pasajeros", "BAJA DE UNIDAD" };
            List<decimal> importe = new List<decimal> { 720, 711, 104 };
            #endregion

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("OrdenCobroDiversos.pdf", FileMode.Create));
            doc.AddAuthor("SecretariaMovilidadyTransporte");
            doc.AddTitle("Documento de Orden de Cobro Diversos");

            //creamos nuestras fuentes del texto
            BaseFont basefuente = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
            iTextSharp.text.Font fnormal = new iTextSharp.text.Font(basefuente, 10f);
            iTextSharp.text.Font fnormal_mini = new iTextSharp.text.Font(basefuente, 8f);
            iTextSharp.text.Font fnegrita = new iTextSharp.text.Font(basefuente, 10f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fnegrita_mini = new iTextSharp.text.Font(basefuente, 8f, iTextSharp.text.Font.BOLD);
            //creamos la instancia para usar nuestras imagenes
            System.Drawing.Bitmap bitmap = Properties.Resources.logosmyt_530;

            // Convierte el Bitmap a un arreglo de bytes
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageB_logosmyt = stream.ToArray();//imagen 1 Bytes
            System.Drawing.Bitmap bitm2 = Properties.Resources.tlax_nh_horizontal;
            System.IO.MemoryStream stream2 = new System.IO.MemoryStream();
            bitm2.Save(stream2, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageB_gobT = stream2.ToArray();//imagen 2 Bytes
            iTextSharp.text.Image logo1 = iTextSharp.text.Image.GetInstance(imageB_logosmyt);
            iTextSharp.text.Image logo2 = iTextSharp.text.Image.GetInstance(imageB_gobT);


            doc.Open();//abre documento

            //doc.Add(new Phrase("REPORTE HOLA MUNDO", fuenteFuerte));
            //doc.Add(Chunk.NEWLINE);//saltos de linea

            //Chunk linea = new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(5f, 100f, BaseColor.RED, Element.ALIGN_CENTER, 0f));
            //doc.Add(linea);
            //logo1.ScaleAbsoluteWidth(10f);
            /*CREAMOS LA TLABLA
             * 
             * 
             */
            var tabla = new PdfPTable(new float[] { 20f, 50f, 25f }) { WidthPercentage = 100f };
            //tabla.AddCell(logo1);
            //tabla.AddCell(new Phrase("ORDEN DE COBRO DE DERECHOS"));
            //tabla.AddCell(logo2);
            logo1.ScalePercent(20f);
            logo2.ScalePercent(20f);

            var cell1 = new PdfPCell(logo1) { Rowspan = 2, Border = 0 };
            var cell2 = new PdfPCell(new Phrase($"ORDEN DE COBRO DE DERECHOS", fnegrita)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
            var cell3 = new PdfPCell(logo2) { Rowspan = 2, Border = 0 };

            tabla.AddCell(cell1);
            tabla.AddCell(cell2);
            tabla.AddCell(cell3);

            cell2.Phrase = new Phrase($"VEHICULARES TRANSPORTE PUBLICO {year}", fnegrita);
            //cell3.Phrase = new Phrase("");
            tabla.AddCell(cell2);
            doc.Add(tabla);

            doc.Add(new Paragraph($"Apetatitlán Tlax, a {dia} de {mes} {year}", fnegrita));
            doc.Add(new Phrase($"PLACA: ", fnegrita));
            doc.Add(new Phrase($"{placa}", fnormal));
            doc.Add(new Paragraph($"DATOS DE CONCECIONARIO", fnegrita) { Alignment = Element.ALIGN_CENTER });

            Chunk linea = new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f));
            doc.Add(linea);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase($"NOMBRE: ", fnegrita));
            doc.Add(new Phrase($"{nombre}", fnormal));
            doc.Add(new Phrase("    FOLIO REVISTA: ", fnegrita));
            doc.Add(new Phrase($"{folioR}", fnormal));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase($"DIRECCIÓN: ", fnegrita));
            doc.Add(new Phrase($"{direccion}", fnormal));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f)));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph($"DATOS DEL VEHICULO ", fnegrita) { Alignment = Element.ALIGN_CENTER });
            doc.Add(Chunk.NEWLINE);
            var tabla2 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100 };
            var parrafoSerie = new Paragraph
            {
                new Chunk("SERIE: ", fnegrita),
                new Chunk($"{serie}", fnormal)
            };
            var cel1 = new PdfPCell(parrafoSerie) { Border = 0 };
            var prrfmotor = new Paragraph
            {
                new Chunk("MOTOR: ", fnegrita),
                new Chunk($"{motor}", fnormal)
            };
            var cel2 = new PdfPCell(prrfmotor) { Border = 0 };
            var prrfmodelo = new Paragraph
            {
                new Chunk("MODELO: ", fnegrita),
                new Chunk($"{modelo}", fnormal)
            };
            var cel3 = new PdfPCell(prrfmodelo) { Border = 0 };

            tabla2.AddCell(cel1);
            tabla2.AddCell(cel2);
            tabla2.AddCell(cel3);

            var prrfmarca = new Paragraph
            {
                new Chunk("MARCA: ", fnegrita),
                new Chunk($"{marca}", fnormal)
            };

            cel1.Phrase = new Phrase(prrfmarca);
            var prrfclv = new Paragraph
            {
                new Chunk("CLV_VEHICULAR: ", fnegrita),
                new Chunk($"{clvVehicular}", fnormal)
            };
            cel2.Phrase = new Phrase(prrfclv);
            var prftipo = new Paragraph
            {
                new Chunk("TIPO: ", fnegrita),
                new Chunk($"{tipo}", fnormal)
            };
            cel3.Phrase = new Phrase(prftipo);

            tabla2.AddCell(cel1);
            tabla2.AddCell(cel2);
            tabla2.AddCell(cel3);

            doc.Add(tabla2);

            //tlaba de descripciones
            doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f)));
            doc.Add(Chunk.NEWLINE);
            var tabla3 = new PdfPTable(new float[] { 20f, 60f, 20f }) { WidthPercentage = 100 };
            var t3cell1 = new PdfPCell(new Phrase("CLAVE", fnegrita)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var t3cell2 = new PdfPCell(new Phrase("DESCRIPCION", fnegrita)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var t3cell3 = new PdfPCell(new Phrase("IMPORTE", fnegrita)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };

            tabla3.AddCell(t3cell1);
            tabla3.AddCell(t3cell2);
            tabla3.AddCell(t3cell3);

            for (int i = 0; i < claves.Count; i++)
            {
                t3cell1.Phrase = new Phrase($"{claves[i]}");
                t3cell2.Phrase = new Phrase($"{descripcion[i]}");
                t3cell3.Phrase = new Phrase($"${importe[i]}");

                tabla3.AddCell(t3cell1);
                tabla3.AddCell(t3cell2);
                tabla3.AddCell(t3cell3);
            }
            var prftotal = new Paragraph
            {
                new Chunk("TOTAL: ", fnegrita),
                new Chunk($"${total}", fnormal)
            };

            doc.Add(tabla3);
            doc.Add(new Paragraph(prftotal) { Alignment = Element.ALIGN_RIGHT });

            doc.Add(new Paragraph("AUTORIZÓ", fnegrita) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 60f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f)));
            doc.Add(new Paragraph($"{nombre}", fnormal) { Alignment = Element.ALIGN_CENTER });
            doc.Add(Chunk.NEWLINE);
            var tabla4 = new PdfPTable(new float[] { 30f, 10f, 30f }) { WidthPercentage = 100 };
            var prfmovimiento = new Paragraph
            {
                new Chunk("NÚMERO DE MOVIMIENTO: ",fnormal),
                new Chunk($"{nMovimiento}")
            };
            var t4cell1 = new PdfPCell(prfmovimiento) { Rowspan = 3, Border = 0 };
            var t4cell2 = new PdfPCell(new Phrase("")) { Rowspan = 3, Border = 0 };

            var t4cell3 = new PdfPCell(new Phrase($"VIGENCIA HASTA EL 31 DE DICIEMBRE DE {year}", fnegrita_mini)) { Border = 0 };


            tabla4.AddCell(t4cell1);
            tabla4.AddCell(t4cell2);
            tabla4.AddCell(t4cell3);

            t4cell3.Phrase = new Phrase($"ELABORO: {elaboro}", fnegrita_mini);

            tabla4.AddCell(t4cell3);

            t4cell3.Phrase = new Phrase($"SAN PABLO APETATITLÁN.", fnegrita_mini);

            tabla4.AddCell(t4cell3);

            doc.Add(tabla4);


            doc.Close();

        }

        private static void GenerarpdfResumen()
        {
            #region DATOS 
            DateTime today = DateTime.Today;
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            int dia = today.Day;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);
            int year = today.Year;
            string servicio = "COLECTIVO";
            string placa = "AXXXXX";
            string nombre = "MANUEL ALEJANDRO MORA MENESES";
            string rfc = "TUX920811PQ7";
            string serie = "VF1FLADRACY419294";
            string motor = "C683198";
            int modelo = 2023;
            string marca = "RENAULT TRAFIC";
            string clvVehicular = "1982432";
            string tipo = "PANEL";
            string cilindros = "4 CIL";
            decimal total = 1535;
            string elaboroC = "JOSE ALFREDO CRUZ MARTINEZ";
            string ruta = "INFORNAVIT PETROQUIMICA.TLAX DE XICOHTENCATL-PROCURADURIA GRAL DE JUSTICIA PI (GRAN PATIO, SAN PABLO APETATITLAN, CAMINO REAL, GARITA, MERCADO, CENTRAL CAMNIONERA, SOBRE LIBRIAMIENTO INSTITUTO POLITECNICO NACIONAL, TEPEHITEC).";
            string observaciones = "CANJE DE PLACAS 2023";
            string combustible = "GASOLINA";
            string capacidad = "20 PASAJEROS";
            string autorizoC = "ING. FELIPE HERNANDEZ JUAREZ";
            //creacion de las listas para las claves, descripcion e importe
            List<int> claves = new List<int> { 512, 511, 315 };
            List<String> descripcion = new List<String> { "RREFRENDO 2023 PARA VEHICULOS DE 15 A 20 PSJ.", "Refrendo 2023 para vehiculos 5-14 pasajeros", "BAJA DE UNIDAD" };
            List<decimal> importe = new List<decimal> { 720, 711, 104 };

            #endregion

            #region DOCUMENTO PDF
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("ResumenCobro.pdf", FileMode.Create));
            doc.AddAuthor("SecretariaMovilidadyTransporte");
            doc.AddTitle("Documento de Resumen de Orden de cobro");
            /*
             * FUENTES
             */
            BaseFont basefuente = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
            iTextSharp.text.Font fnormal = new iTextSharp.text.Font(basefuente, 10f);
            iTextSharp.text.Font fnormal_mini = new iTextSharp.text.Font(basefuente, 9f);
            iTextSharp.text.Font fnegrita = new iTextSharp.text.Font(basefuente, 10f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fnegrita_mini = new iTextSharp.text.Font(basefuente, 8f, iTextSharp.text.Font.BOLD);
            //inicia documento

            //creamos la instancia para usar nuestras imagenes
            System.Drawing.Bitmap bitmap = Properties.Resources.logosmyt_530;
            // Convierte el Bitmap a un arreglo de bytes
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageB_logosmyt = stream.ToArray();//imagen 1 Bytes
            System.Drawing.Bitmap bitm2 = Properties.Resources.tlax_nh_horizontal;
            System.IO.MemoryStream stream2 = new System.IO.MemoryStream();
            bitm2.Save(stream2, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageB_gobT = stream2.ToArray();//imagen 2 Bytes
            iTextSharp.text.Image logo1 = iTextSharp.text.Image.GetInstance(imageB_logosmyt);
            iTextSharp.text.Image logo2 = iTextSharp.text.Image.GetInstance(imageB_gobT);
            logo1.ScalePercent(20f);
            logo2.ScalePercent(20f);
            doc.Open();
            var tabla = new PdfPTable(new float[] { 20f, 50f, 25f }) { WidthPercentage = 100f };
            var cell1 = new PdfPCell(logo1) { Rowspan = 3, Border = 0 };
            var cell2 = new PdfPCell(new Phrase($"GOBIERNO DEL ESTADO DE TLAXCALA", fnegrita)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
            var cell3 = new PdfPCell(logo2) { Rowspan = 3, Border = 0 };

            tabla.AddCell(cell1);
            tabla.AddCell(cell2);
            tabla.AddCell(cell3);

            cell2.Phrase = new Phrase("SECETARIA DE MOVILIDAD Y TRANSPORTE", fnegrita);
            tabla.AddCell(cell2);

            cell2.Phrase = new Phrase("SOLICITUD DE SERVICIO PÚBLICO DE PASAJEROS", fnormal);
            tabla.AddCell(cell2);


            doc.Add(tabla);
            doc.Add(new Phrase($"PLACA: {placa}\n", fnormal));
            doc.Add(new iTextSharp.text.Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f)));
            doc.Add(iTextSharp.text.Chunk.NEWLINE);
            doc.Add(new iTextSharp.text.Paragraph("NOMBRE DEL CONCECIONARIO: ", fnegrita));
            doc.Add(new iTextSharp.text.Paragraph($"{nombre}", fnormal));
            doc.Add(new iTextSharp.text.Paragraph("DOMICILIO: ", fnegrita));
            doc.Add(new iTextSharp.text.Paragraph($"{nombre}", fnormal));
            var prfrfc = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("RFC: ", fnegrita),
                new iTextSharp.text.Chunk($"{rfc}\n", fnormal)
            };
            doc.Add(new iTextSharp.text.Paragraph(prfrfc));
            doc.Add(new iTextSharp.text.Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f)));

            var tabla2 = new PdfPTable(new float[] { 25f, 25f, 25f, 25f }) { WidthPercentage = 100f };
            var prfserie = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("SERIE: ",fnegrita_mini),
                new iTextSharp.text.Chunk($"{serie}",fnormal_mini)
            };
            var t2cel1 = new PdfPCell(prfserie) { Padding = 4, Border = 0 };
            var prfmotor = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("MOTOR: ",fnegrita_mini),
                new iTextSharp.text.Chunk($"{motor}",fnormal_mini)
            };
            var t2cel2 = new PdfPCell(prfmotor) { Padding = 4, Border = 0 };
            var prfmodelo = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("MODELO:", fnegrita_mini),
                new iTextSharp.text.Chunk($"{modelo}",fnormal_mini)
            };
            var t2cel3 = new PdfPCell(prfmodelo) { Padding = 4, Border = 0 };
            var prfcapacidad = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("CAPACIDAD: ", fnegrita_mini),
                new iTextSharp.text.Chunk($"{capacidad}",fnormal_mini)
            };
            var t2cel4 = new PdfPCell(prfcapacidad) { Padding = 4, Border = 0 };

            tabla2.AddCell(t2cel1);
            tabla2.AddCell(t2cel2);
            tabla2.AddCell(t2cel3);
            tabla2.AddCell(t2cel4);



            var prfmarca = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("MARCA: ", fnegrita_mini),
                new iTextSharp.text.Chunk($"{marca}", fnormal_mini)
            };
            t2cel1.Phrase = new Phrase(prfmarca);
            var prfclv = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("CVE_VEHICULAR: ", fnegrita_mini),
                new iTextSharp.text.Chunk($"{clvVehicular}", fnormal_mini)
            };
            t2cel2.Phrase = new Phrase(prfclv);
            t2cel3.Phrase = new Phrase
            {
                new iTextSharp.text.Chunk("CLASE: ",fnegrita_mini),
                new iTextSharp.text.Chunk($"{tipo}", fnormal_mini)
            };
            t2cel4.Phrase = new Phrase
            {
                new iTextSharp.text.Chunk("SERVICIO: ", fnegrita_mini),
                new iTextSharp.text.Chunk($"{servicio}", fnormal_mini)
            };

            tabla2.AddCell(t2cel1);
            tabla2.AddCell(t2cel2);
            tabla2.AddCell(t2cel3);
            tabla2.AddCell(t2cel4);
            doc.Add(tabla2);

            var tabla3 = new PdfPTable(new float[] { 25f, 25f, 25f, 25f }) { WidthPercentage = 100f, PaddingTop = 4 };
            var prfcombustible = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("COMBUSTIBLE: ",fnegrita_mini),
                new iTextSharp.text.Chunk($"{combustible}",fnormal_mini)
            };
            var t3cel1 = new PdfPCell(prfcombustible) { Padding = 4, Border = 0 };
            var prfcilindros = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("CILINDROS: ",fnegrita_mini),
                new iTextSharp.text.Chunk($"{cilindros}",fnormal_mini)
            };
            var t3cel2 = new PdfPCell(prfcombustible) { Padding = 4, Border = 0 };
            var t3cel3 = new PdfPCell(new Phrase("")) { Padding = 4, Border = 0 };
            var t3cel4 = new PdfPCell(new Phrase("")) { Padding = 4, Border = 0 };

            tabla3.AddCell(t3cel1);
            tabla3.AddCell(t3cel2);
            tabla3.AddCell(t3cel3);
            tabla3.AddCell(t3cel4);
            doc.Add(tabla3);
            doc.Add(iTextSharp.text.Chunk.NEWLINE);
            doc.Add(new iTextSharp.text.Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f)));
            doc.Add(iTextSharp.text.Chunk.NEWLINE);
            var rutaAutorizada = new Phrase
            {
                new iTextSharp.text.Chunk("RUTA AUROTIZADA: ",fnegrita),
                new iTextSharp.text.Chunk($"{ruta}",fnormal)
            };
            doc.Add(new iTextSharp.text.Paragraph(rutaAutorizada));
            doc.Add(new iTextSharp.text.Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f)));

            var tabla4 = new PdfPTable(new float[] { 20f, 60f, 20f }) { WidthPercentage = 100 };
            var t4cell1 = new PdfPCell(new Phrase("CLAVE", fnegrita)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var t4cell2 = new PdfPCell(new Phrase("DESCRIPCION", fnegrita)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var t4cell3 = new PdfPCell(new Phrase("IMPORTE", fnegrita)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };

            tabla4.AddCell(t4cell1);
            tabla4.AddCell(t4cell2);
            tabla4.AddCell(t4cell3);

            for (int i = 0; i < claves.Count; i++)
            {
                t4cell1.Phrase = new Phrase($"{claves[i]}", fnormal);
                t4cell2.Phrase = new Phrase($"{descripcion[i]}", fnormal);
                t4cell3.Phrase = new Phrase($"${importe[i]}", fnormal);

                tabla4.AddCell(t4cell1);
                tabla4.AddCell(t4cell2);
                tabla4.AddCell(t4cell3);
            }
            var prftotal = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("TOTAL: ", fnegrita),
                new iTextSharp.text.Chunk($"${total}", fnormal)
            };

            doc.Add(tabla4);
            doc.Add(new iTextSharp.text.Paragraph(prftotal) { Alignment = Element.ALIGN_RIGHT });
            doc.Add(iTextSharp.text.Chunk.NEWLINE);
            doc.Add(new iTextSharp.text.Paragraph($"OBSERVACIONES: {observaciones}", fnormal));
            doc.Add(iTextSharp.text.Chunk.NEWLINE); doc.Add(iTextSharp.text.Chunk.NEWLINE); doc.Add(iTextSharp.text.Chunk.NEWLINE); doc.Add(iTextSharp.text.Chunk.NEWLINE); doc.Add(iTextSharp.text.Chunk.NEWLINE); doc.Add(iTextSharp.text.Chunk.NEWLINE); doc.Add(iTextSharp.text.Chunk.NEWLINE);
            doc.Add(iTextSharp.text.Chunk.NEWLINE); doc.Add(iTextSharp.text.Chunk.NEWLINE); doc.Add(iTextSharp.text.Chunk.NEWLINE); doc.Add(iTextSharp.text.Chunk.NEWLINE);
            doc.Add(new iTextSharp.text.Paragraph(" "));
            doc.Add(new iTextSharp.text.Paragraph(" "));
            doc.Add(new iTextSharp.text.Paragraph(" "));
            doc.Add(new iTextSharp.text.Paragraph(" "));
            var tablafooter = new PdfPTable(new float[] { 33f, 33f, 33f }) { WidthPercentage = 100 };

            var tfcel1 = new PdfPCell(new iTextSharp.text.Paragraph($"{dia}/{mes.ToUpper()}/{year}", fnormal)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER };
            var tfcel2 = new PdfPCell(new iTextSharp.text.Paragraph($"{elaboroC}", fnormal)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER };
            var tfcel3 = new PdfPCell(new iTextSharp.text.Paragraph($"{autorizoC}", fnormal)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER };

            tablafooter.AddCell(tfcel1);
            tablafooter.AddCell(tfcel2);
            tablafooter.AddCell(tfcel3);

            tfcel1 = new PdfPCell(new iTextSharp.text.Paragraph($"FECHA", fnegrita)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER };
            tfcel2 = new PdfPCell(new iTextSharp.text.Paragraph($"ELABORÓ", fnegrita)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER };
            tfcel3 = new PdfPCell(new iTextSharp.text.Paragraph($"AUTORIZÓ", fnegrita)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER };


            tablafooter.AddCell(tfcel1);
            tablafooter.AddCell(tfcel2);
            tablafooter.AddCell(tfcel3);

            doc.Add(tablafooter);

            doc.Close();

            #endregion
        }

        #endregion

    }
}
