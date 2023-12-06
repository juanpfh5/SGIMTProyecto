
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

namespace SGIMTProyecto
{
    public partial class F_PermisoTransporteE : UserControl
    {
        public F_PermisoTransporteE()
        {
            InitializeComponent();
        }

        #region Métodos

        private void LimpiarTextBox() {
            TXT_Permisionario.Text = "";
            TXT_Domicilio.Text = "";
            TXT_CP.Text = "";
            TXT_Poblacion.Text = "";
            TXT_Placas.Text = "";
            TXT_TarjetaCirculacion.Text = "";
            TXT_Recorrido.Text = "";
            TXT_FolioPermiso.Text = "";
            TXT_NoMovimiento.Text = "";
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

        private void InsertarTransporteE(List<object> datosTransporteE) {
            D_PermisoTransporteE Datos = new D_PermisoTransporteE();
            Datos.InsertarTransporteE(datosTransporteE);
        }

        #endregion

        private void BTN_Imprimir_Click(object sender, EventArgs e) {
            (string mensajeError, bool bandera) = VerificacionParametros();

            if (bandera) 
            {
                MessageBox.Show(mensajeError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else 
            {
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

                List<object> datosTransporteE = new List<object> {
                        TXT_Permisionario.Text.Trim(),
                        TXT_Domicilio.Text.Trim(),
                        int.Parse(TXT_CP.Text.Trim()),
                        TXT_Poblacion.Text.Trim(),
                        TXT_Placas.Text.Trim(),
                        int.Parse(TXT_TarjetaCirculacion.Text.Trim()),
                        TXT_Recorrido.Text.Trim(),
                        fechaExpedicion,
                        fechaVigencia,
                        int.Parse(TXT_FolioPermiso.Text.Trim()),
                        int.Parse(TXT_NoMovimiento.Text.Trim())
                    };

                InsertarTransporteE(datosTransporteE);

                MessageBox.Show("El registro se agrego con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarTextBox();

                //imprimit
                /*REQUISITOS
                 * 
                 * string placa = "AXXXXX";
                    string nombre = "MANUEL ALEJANDRO MORA MENESES";
                    string direccion = "Enrique segoviano";
                    string poblacion = "AMAXAC DE GUERRERO";
                    int CP = 90600;
                    int TC = 4812;
                    string recorrido = "INFORNAVIT PETROQUIMICA.TLAX DE XICOHTENCATL-PROCURADURIA GRAL DE JUSTICIA PI (GRAN PATIO, SAN PABLO APETATITLAN, CAMINO REAL, GARITA, MERCADO, CENTRAL CAMNIONERA, SOBRE LIBRIAMIENTO INSTITUTO POLITECNICO NACIONAL, TEPEHITEC).";
                    string fechaVig = "31/12/2023";
                    string director = "LIC. JOSE ANTONIO CARAMILLO SANCHEZ";
                 * 
                 */
            }
        }
        private static void GenerarPDF()
        {
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            DateTime today = DateTime.Today;
            string fechaHoy = DateTime.Today.ToString("dd/M/yyyy", culturaEspañol);


            string placa = "AXXXXX";
            string nombre = "MANUEL ALEJANDRO MORA MENESES";
            string direccion = "ENCINOS NO 7 B. OCOTLAN DE TEPATLAXCO, CONTLA DE JUAN CUAMATIZI, TLAX.";
            string poblacion = "AMAXAC DE GUERRERO";
            int CP = 90600;
            int TC = 4812;
            string recorrido = "INFORNAVIT PETROQUIMICA.TLAX DE XICOHTENCATL-PROCURADURIA GRAL DE JUSTICIA PI (GRAN PATIO, SAN PABLO APETATITLAN, CAMINO REAL, GARITA, MERCADO, CENTRAL CAMNIONERA, SOBRE LIBRIAMIENTO INSTITUTO POLITECNICO NACIONAL, TEPEHITEC).";
            string fechaVig = "31/12/2023";
            string director = "LIC. JOSE ANTONIO CARAMILLO SANCHEZ";

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

            PdfWriter.GetInstance(doc, new FileStream("PermisoTransporteEscolar.pdf", FileMode.Create));
            doc.AddAuthor("SecretariaMovilidadyTransporte");
            doc.AddTitle("Documento de Permiso de Transporte Escolar");

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

            var tabla3 = new PdfPTable(new float[] { 40f, 60f }) { WidthPercentage = 100 };
            var t3cel1 = new PdfPCell(new Paragraph($"{placa}", fnormal)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t3cel2 = new PdfPCell(new Paragraph($"{TC}", fnormal)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            tabla3.AddCell(t3cel1);
            tabla3.AddCell(t3cel2);
            doc.Add(tabla3);

            var tabla4 = new PdfPTable(new float[] { 20f, 80f }) { WidthPercentage = 100 };
            var t4cel1 = new PdfPCell(new Paragraph($"", fnormal)) { MinimumHeight = 40f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t4cel2 = new PdfPCell(new Paragraph($"{recorrido}", fnormal_mini)) { MinimumHeight = 30f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            tabla4.AddCell(t4cel1);
            tabla4.AddCell(t4cel2);
            doc.Add(tabla4);

            var tabla5 = new PdfPTable(new float[] { 33f, 33f, 34f }) { WidthPercentage = 100 };
            var t5cel1 = new PdfPCell(new Paragraph($"{fechaHoy}", fnormal)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0, HorizontalAlignment = Element.ALIGN_BOTTOM };
            var t5cel2 = new PdfPCell(new Paragraph($"{fechaVig}", fnormal)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0, HorizontalAlignment = Element.ALIGN_BOTTOM };
            var t5cel3 = new PdfPCell(new Paragraph($"{director}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0, HorizontalAlignment = Element.ALIGN_BOTTOM };
            tabla5.AddCell(t5cel1);
            tabla5.AddCell(t5cel2);
            tabla5.AddCell(t5cel3);
            doc.Add(tabla5);
            doc.Close();
        }
    }
}
