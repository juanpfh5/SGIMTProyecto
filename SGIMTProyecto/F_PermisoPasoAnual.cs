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

namespace SGIMTProyecto {
    public partial class F_PermisoPasoAnual : UserControl {
        private F_VisualizacionPDF formVisualizador;
        public F_PermisoPasoAnual() {
            InitializeComponent();
        }

        #region Métodos Base de Datos
        private string ObtenerTitularSMyT() {
            D_PermisoPasoAnual Datos = new D_PermisoPasoAnual();
            return Datos.ObtenerTitularSMyT();
        }

        private void InsertarPasoAnual(List<object> datosPasoAnual) {
            D_PermisoPasoAnual Datos = new D_PermisoPasoAnual();
            Datos.InsertarPasoAnual(datosPasoAnual);
        }

        private bool ExistenciaMovimiento(int movimiento) {
            D_PermisoPasoAnual Datos = new D_PermisoPasoAnual();
            return Datos.ExistenciaMovimiento(movimiento);
        }

        #endregion

        #region Métodos Botones
        private void TXT_Placas_KeyPress(object sender, KeyPressEventArgs e) {
            if (char.IsLower(e.KeyChar)) {
                // Si es una letra minúscula, conviértela a mayúscula
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

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

                string placa = TXT_Placas.Text.Trim();
                string nombre = TXT_Nombre.Text.Trim();
                string direccion = TXT_Domicilio.Text.Trim();
                string poblacion = TXT_Poblacion.Text.Trim();
                int CP = Convert.ToInt32(TXT_CP.Text.Trim());
                int TC = Convert.ToInt32(TXT_TarjetaCirculacion.Text.Trim());
                string serie = TXT_NoSerie.Text.Trim();
                string motor = TXT_NoMotor.Text.Trim();
                int modelo = Convert.ToInt32(TXT_Modelo.Text.Trim());
                int folio = Convert.ToInt32(TXT_FolioPermiso.Text.Trim());
                string marca = TXT_Marca.Text.Trim();
                string rfv = TXT_RFV.Text.Trim();

                string recorrido = TXT_Recorrido.Text.Trim();
                string fechaHoy = DTP_FechaExpedicion.Value.ToString("dd/MM/yyyy");
                string fechaVig = DTP_FechaVigencia.Value.ToString("dd/MM/yyyy");
                string director = ObtenerTitularSMyT();

                GenerarPDF(placa, nombre, direccion, poblacion, CP, TC, serie, motor, modelo, folio, marca, rfv, recorrido, fechaVig, director, fechaHoy);

                if (formVisualizador == null || formVisualizador.IsDisposed) {
                    F_VisualizacionPDF formVisualizador = new F_VisualizacionPDF();
                    formVisualizador.RecibirNombre("PermisoPasoAnual.pdf");
                    formVisualizador.ShowDialog();
                }

                MessageBox.Show("El registro se agrego con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarTextBox();
            }
        }

        #endregion

        #region Métodos Extra
        private (string, bool) VerificacionParametros() {
            string error, variable, mensajeExtra = "";
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
            if (TXT_Placas.Text.Length != 7) {
                variable = JLB_Placas.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_TarjetaCirculacion.Text.Trim(), out int tarjetaCirculacion)) {
                variable = JLB_TarjetaCirculacion.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Recorrido.Text.Trim().Length > 5000 || TXT_Recorrido.Text.Trim().Length < 1) {
                variable = JLB_Recorrido.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (DTP_FechaExpedicion.Value >= DTP_FechaVigencia.Value) {
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
            if (!int.TryParse(TXT_NoMovimiento.Text.Trim(), out int noMovimiento) || !ExistenciaMovimiento(Convert.ToInt32(TXT_NoMovimiento.Text))) {
                variable = JLB_NoMovimiento.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
                if (!ExistenciaMovimiento(Convert.ToInt32(TXT_NoMovimiento.Text))) {
                    mensajeExtra = "No. Movimiento no existente.";
                }
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

            error += "\n" + mensajeExtra;

            return (error, bandera);
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

        #region Métodos PDF
        private static void GenerarPDF(string placa, string nombre, string direccion, string poblacion, int CP, int TC, string serie, string motor, int modelo, int folio, string marca, string rfv, string recorrido, string fechaVig, string director, string fechaHoy)
        {
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            
            /*
             * FUENTES
             * 
             */
            BaseFont basefuente = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
            iTextSharp.text.Font fnormal = new iTextSharp.text.Font(basefuente, 9f);
            iTextSharp.text.Font fnormal_mini = new iTextSharp.text.Font(basefuente, 6f);
            iTextSharp.text.Font fnormal_supermini = new iTextSharp.text.Font(basefuente, 5f);
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

            PdfWriter.GetInstance(doc, new FileStream("PermisoPasoAnual.pdf", FileMode.Create));
            doc.AddAuthor("SecretariaMovilidadyTransporte");
            doc.AddTitle("Documento de Permiso de Paso Anual");

            doc.SetMargins(30f, 30f, 0f, 30f);

            doc.Open();
            var tabla1 = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
            var t1cel1 = new PdfPCell(new Paragraph($"{nombre}", fnormal)) { MinimumHeight = 90f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t1cel2 = new PdfPCell(new Paragraph($"{direccion}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };

            tabla1.AddCell(t1cel1);
            tabla1.AddCell(t1cel2);

            doc.Add(tabla1);

            var tabla2 = new PdfPTable(new float[] { 70f, 30f }) { WidthPercentage = 100 };
            var t2cel1 = new PdfPCell(new Paragraph($"{poblacion}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            var t2cel2 = new PdfPCell(new Paragraph($"{CP}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            tabla2.AddCell(t2cel1);
            tabla2.AddCell(t2cel2);
            doc.Add(tabla2);

            var tabla4 = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
            var t4cel2 = new PdfPCell(new Paragraph($"{recorrido}", fnormal_mini)) { MinimumHeight = 45f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            tabla4.AddCell(t4cel2);
            doc.Add(tabla4);

            var tabla5 = new PdfPTable(new float[] { 30f, 50f, 20f }) { WidthPercentage = 100 };
            var t5cel1 = new PdfPCell(new Paragraph($"{motor}", fnormal)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t5cel2 = new PdfPCell(new Paragraph($"{serie}", fnormal)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t5cel3 = new PdfPCell(new Paragraph($"{rfv}", fnormal)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            tabla5.AddCell(t5cel1);
            tabla5.AddCell(t5cel2);
            tabla5.AddCell(t5cel3);
            doc.Add(tabla5);

            var tabla6 = new PdfPTable(new float[] { 30f, 23f, 23f, 24f }) { WidthPercentage = 100 };
            var t6cel1 = new PdfPCell(new Paragraph($"{marca}", fnormal)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t6cel2 = new PdfPCell(new Paragraph($"{placa}", fnormal)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t6cel3 = new PdfPCell(new Paragraph($"{modelo}", fnormal)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t6cel4 = new PdfPCell(new Paragraph($"{TC}", fnormal)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            tabla6.AddCell(t6cel1);
            tabla6.AddCell(t6cel2);
            tabla6.AddCell(t6cel3);
            tabla6.AddCell(t6cel4);
            doc.Add(tabla6);

            var tabla7 = new PdfPTable(new float[] { 30f, 25f, 45f });
            var t7cel1 = new PdfPCell(new Paragraph($"{fechaHoy}", fnormal)) { MinimumHeight = 25f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t7cel2 = new PdfPCell(new Paragraph($"{fechaVig}", fnormal)) { MinimumHeight = 25f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t7cel3 = new PdfPCell(new Paragraph($"{director}", fnormal_mini)) { MinimumHeight = 25f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            tabla7.AddCell(t7cel1);
            tabla7.AddCell(t7cel2);
            tabla7.AddCell(t7cel3);
            doc.Add(tabla7);
            doc.Close();
        }

        #endregion

    }
}
