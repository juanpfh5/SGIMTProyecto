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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Threading;
using HarfBuzzSharp;

namespace SGIMTProyecto {
    public partial class F_LiberacionPublicoPrivado : UserControl {
        private F_VisualizacionPDF formVisualizador;

        public F_LiberacionPublicoPrivado() {
            InitializeComponent();
        }

        #region Métodos Base de Datos
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

        private bool ExistenciaVehiculo(string cTexto) {
            D_LiberacionPublicoPrivado Datos = new D_LiberacionPublicoPrivado();
            return Datos.ExistenciaVehiculo(cTexto);
        }

        private void ActualizarLiberacion(string placa) {
            D_LiberacionPublicoPrivado Datos = new D_LiberacionPublicoPrivado();
            Datos.ActualizarLiberacion(placa);
        }

        private string ObtenerDirector() {
            D_LiberacionPublicoPrivado Datos = new D_LiberacionPublicoPrivado();
            return Datos.ObtenerDirector();
        }
        private int ObtenerFolio() {
            D_LiberacionPublicoPrivado Datos = new D_LiberacionPublicoPrivado();
            return Datos.ObtenerFolio();
        }

        #endregion

        #region Métodos Botones
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

                        string nOficio = ObtenerFolio().ToString("D4");
                        string marca = TXT_Marca.Text;
                        int modelo = Convert.ToInt32(TXT_Modelo.Text);
                        string tipo = TXT_Tipo.Text;
                        string serie = TXT_NoSerie.Text;
                        string motor = TXT_NoMotor.Text;
                        int nBaja = Convert.ToInt32(TXT_NoBaja.Text);
                        string fechaRecibo = DTP_Fecha.Value.ToString("dd/MM/yyyy");
                        string director = ObtenerDirector();
                        GenerarLiberacion(nOficio, marca, modelo, tipo, serie, motor, nBaja, fechaRecibo, director);

                        if (formVisualizador == null || formVisualizador.IsDisposed) {
                            F_VisualizacionPDF formVisualizador = new F_VisualizacionPDF();
                            formVisualizador.RecibirNombre("Liberacion.pdf");
                            formVisualizador.ShowDialog();  // Utiliza ShowDialog en lugar de Show
                        }

                        MessageBox.Show("La unidad ha sido dada de baja correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarTextBox();
                    } else {
                        MessageBox.Show("El vehículo no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        #endregion

        #region Métodos Extra
        private void LimpiarTextBox() {
            TXT_Marca.Text = "";
            TXT_Modelo.Text = "";
            TXT_Tipo.Text = "";
            TXT_NoSerie.Text = "";
            TXT_NoMotor.Text = "";
            TXT_NoBaja.Text = "";
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

        #endregion

        #region Métodos PDF
        private static void GenerarLiberacion(string nOficio, string marca, int modelo, string tipo, string serie, string motor, int nBaja, string fechaRecibo, string director) {
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            DateTime today = DateTime.Today;

            string fechaHoy = DateTime.Today.ToString("dd/M/yyyy", culturaEspañol);

            int year = today.Year;
            int dia = today.Day;
            int mesn = today.Month;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);

            /*
             * FUENTES
             * 
             */
            BaseFont basefuente = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
            iTextSharp.text.Font fnormal = new iTextSharp.text.Font(basefuente, 10f);
            iTextSharp.text.Font fnormal_mini = new iTextSharp.text.Font(basefuente, 8f);
            iTextSharp.text.Font fnegrita = new iTextSharp.text.Font(basefuente, 10f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fnegrita_mini = new iTextSharp.text.Font(basefuente, 8f, iTextSharp.text.Font.BOLD);

            /**
             * 
             * IMAGENES
             * 
             */
            System.Drawing.Bitmap bitmap = Properties.Resources.logosmyt_530;
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageB_logosmyt = stream.ToArray();//imagen 1 Bytes
            System.Drawing.Bitmap bitm2 = Properties.Resources.tlax_nh_horizontal;
            System.IO.MemoryStream stream2 = new System.IO.MemoryStream();
            bitm2.Save(stream2, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageB_gobT = stream2.ToArray();//imagen 2 Bytes

            iTextSharp.text.Image logo1 = iTextSharp.text.Image.GetInstance(imageB_logosmyt);
            iTextSharp.text.Image logo2 = iTextSharp.text.Image.GetInstance(imageB_gobT);

            /*
             * 
             * DOCUMENTO 
             * 
             */
            var doc = new Document();

            PdfWriter.GetInstance(doc, new FileStream("Liberacion.pdf", FileMode.Create));
            doc.AddAuthor("SecretariaMovilidadyTransporte");
            doc.AddTitle("Documento de Liberacion");
            doc.SetMargins(100f, 100f, 50f, 50f);

            doc.Open();

            logo1.ScalePercent(30f);
            logo2.ScalePercent(30f);
            var header = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100 };
            var cell1 = new PdfPCell(logo1) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
            var cell2 = new PdfPCell(logo2) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_MIDDLE };

            header.AddCell(cell1);
            header.AddCell(cell2);
            doc.Add(header);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph($"FORMATO: DST/{nOficio}/{year}", fnormal) { Alignment = Element.ALIGN_RIGHT });
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph($"SECRETARÍA DE MOVILIDAD Y TRANSPORTES.", fnegrita) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph($"TRAMITE DE ALTA VEHICULAR.", fnegrita) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph($"SERVICIO PARTICULAR.", fnegrita) { Alignment = Element.ALIGN_CENTER });
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph($"FECHA: {dia}/{mesn}/{year}", fnormal) { Alignment = Element.ALIGN_RIGHT });
            doc.Add(Chunk.NEWLINE);
            var contenido = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
            var txtmarca = new Paragraph
            {
                new Chunk("MARCA: ", fnegrita),
                new Chunk($"{marca}", fnormal)
            };
            var Ccell1 = new PdfPCell(new Paragraph(txtmarca) { Alignment = Element.ALIGN_CENTER }) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 30f };
            contenido.AddCell(Ccell1);

            var txtmodelo = new Paragraph
            {
                new Chunk("MODELO: ", fnegrita),
                new Chunk($"{modelo}", fnormal)
            };
            Ccell1 = new PdfPCell(new Paragraph(txtmodelo) { Alignment = Element.ALIGN_CENTER }) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 30f };
            contenido.AddCell(Ccell1);

            var txttipo = new Paragraph
            {
                new Chunk("TIPO: ", fnegrita),
                new Chunk($"{tipo}", fnormal)
            };
            Ccell1 = new PdfPCell(new Paragraph(txttipo) { Alignment = Element.ALIGN_CENTER }) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 50f };
            contenido.AddCell(Ccell1);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            var txtserie = new Phrase
            {
                new Chunk("SERIE: ", fnegrita),
                new Chunk($"{serie}", fnormal)
            };
            Ccell1 = new PdfPCell(new Paragraph(txtserie) { Alignment = Element.ALIGN_CENTER }) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 30f };
            contenido.AddCell(Ccell1);
            var txtmotor = new Paragraph
            {
                new Chunk("MOTOR: ", fnegrita),
                new Chunk($"{motor}", fnormal)
            };
            Ccell1 = new PdfPCell(new Paragraph(txtmotor) { Alignment = Element.ALIGN_CENTER }) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 50f };
            contenido.AddCell(Ccell1);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            var txtnbaja = new Paragraph
            {
                new Chunk("NÚMERO DE BAJA: ", fnegrita),
                new Chunk($"{nBaja}", fnormal)
            };
            Ccell1 = new PdfPCell(new Paragraph(txtnbaja) { Alignment = Element.ALIGN_CENTER }) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 30f };
            contenido.AddCell(Ccell1);
            var txtfecha = new Paragraph
            {
                new Chunk("FECHA: ", fnegrita),
                new Chunk($"{fechaRecibo}", fnormal)
            };
            Ccell1 = new PdfPCell(new Paragraph(txtfecha) { Alignment = Element.ALIGN_CENTER }) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 60f };
            contenido.AddCell(Ccell1);

            doc.Add(contenido);

            var pr1 = new Paragraph("PREVIO ANALISIS DE DOCUMENTACIÓN CORRESPONDIENTE.", fnormal);
            pr1.Alignment = Element.ALIGN_CENTER;
            var pr2 = new Paragraph
            {
                new Chunk("NOTA: ", fnormal),
                new Chunk("EMPLACAMIENTO A PLACAS PARTICULARES, NO AUTORIZA ", fnegrita),
                new Chunk(" TRANSPORTE DE PERSONAL.", fnormal)
            };
            pr2.Alignment = Element.ALIGN_CENTER;

            doc.Add(pr1);
            doc.Add(pr2);


            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            var ultimo = new Paragraph("DIRECTOR DE TRANSPORTE DE LA SMYT.", fnegrita);
            ultimo.Alignment = Element.ALIGN_CENTER;
            doc.Add(ultimo);
            var direc = new Paragraph($"{director}", fnegrita);
            direc.Alignment = Element.ALIGN_CENTER;
            doc.Add(direc);

            doc.Close();
        }

        #endregion

        #region Métodos PlaceHolder
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
