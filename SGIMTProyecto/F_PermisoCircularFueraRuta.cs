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
using HarfBuzzSharp;
using System.Numerics;
using System.Text.RegularExpressions;

namespace SGIMTProyecto
{
    public partial class F_PermisoCircularFueraRuta : UserControl
    {
        private F_VisualizacionPDF formVisualizador;
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
            string error, variable, mensajeExtra = "";
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

        private string ObtenerTitularSMyT() {
            D_PermisoCircularFueraRuta Datos = new D_PermisoCircularFueraRuta();
            return Datos.ObtenerTitularSMyT();
        }

        private void InsertarFueraRuta(List<object> datosFueraRuta) {
            D_PermisoCircularFueraRuta Datos = new D_PermisoCircularFueraRuta();
            Datos.InsertarFueraRuta(datosFueraRuta);
        }

        private bool ExistenciaMovimiento(int movimiento) {
            D_PermisoCircularFueraRuta Datos = new D_PermisoCircularFueraRuta();
            return Datos.ExistenciaMovimiento(movimiento);
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

                    string placa = TXT_Placas.Text.Trim();
                    string nombre = TXT_Permisionario.Text.Trim();
                    string direccion = TXT_Domicilio.Text.Trim();
                    string poblacion = TXT_Poblacion.Text.Trim();
                    int CP = Convert.ToInt32(TXT_CP.Text.Trim());
                    int TC = Convert.ToInt32(TXT_TarjetaCirculacion.Text.Trim());
                    int modelo = Convert.ToInt32(TXT_Modelo.Text.Trim());
                    string serie = TXT_NoSerie.Text.Trim();
                    string motor = TXT_NoMotor.Text.Trim();
                    string marca = TXT_Marca.Text.Trim();
                    string motivo = TXT_Motivo.Text.Trim();
                    string fechaVig = DTP_FechaVigencia.Value.ToString("dd/MM/yyyy");
                    string director = ObtenerTitularSMyT();
                    string repuve = TXT_Repuve.Text.Trim();

                    GenerarPDF(placa, nombre, direccion, poblacion, CP, TC, modelo, serie, motor, marca, motivo, fechaVig, director, repuve);

                    if (formVisualizador == null || formVisualizador.IsDisposed) {
                        F_VisualizacionPDF formVisualizador = new F_VisualizacionPDF();
                        formVisualizador.RecibirNombre("PermisoFueraRuta.pdf");
                        formVisualizador.ShowDialog();
                    }

                    MessageBox.Show("El registro se agrego con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTextBox();

                    //imprimir
                    /*REQUISITOS PARA IMPRESION
                     * 
                     * CultureInfo culturaEspañol = new CultureInfo("es-ES");
                        DateTime today = DateTime.Today;

                        string fechaHoy = DateTime.Today.ToString("dd/M/yyyy", culturaEspañol);


                        string placa = "AXXXXX";
                        string nombre = "MANUEL ALEJANDRO MORA MENESES";
                        string direccion = "Enrique segoviano";
                        string poblacion = "AMAXAC DE GUERRERO";
                        int CP = 90600;
                        int TC = 4812;
                        int modelo = 2023;
                        string serie = "VF1FLADRACY419294";
                        string motor = "C683198";
                        string marca = "RENAULT TRAFIC";
                        string motivo = "INFORNAVIT PETROQUIMICA.TLAX DE XICOHTENCATL-PROCURADURIA GRAL DE JUSTICIA PI (GRAN PATIO, SAN PABLO APETATITLAN, CAMINO REAL, GARITA, MERCADO, CENTRAL CAMNIONERA, SOBRE LIBRIAMIENTO INSTITUTO POLITECNICO NACIONAL, TEPEHITEC).";
                        string fechaVig = "31/12/2023";
                        string director = "LIC. JOSE ANTONIO CARAMILLO SANCHEZ";
                        string repuve = "322PIE61";
                     * 
                     */
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

        private static void GenerarPDF(string placa, string nombre, string direccion, string poblacion, int CP, int TC, int modelo, string serie, string motor, string marca, string motivo, string fechaVig, string director, string repuve)
        {
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            DateTime today = DateTime.Today;

            string fechaHoy = DateTime.Today.ToString("dd/M/yyyy", culturaEspañol);


            /*string placa = "AXXXXX";
            string nombre = "MANUEL ALEJANDRO MORA MENESES";
            string direccion = "ENCINOS NO 7 B. OCOTLAN DE TEPATLAXCO, CONTLA DE JUAN CUAMATIZI, TLAX.";
            string poblacion = "AMAXAC DE GUERRERO";
            int CP = 90600;
            int TC = 4812;
            int modelo = 2023;
            string serie = "VF1FLADRACY419294";
            string motor = "C683198";
            string marca = "RENAULT TRAFIC";
            string motivo = "INFORNAVIT PETROQUIMICA.TLAX DE XICOHTENCATL-PROCURADURIA GRAL DE JUSTICIA PI (GRAN PATIO, SAN PABLO APETATITLAN, CAMINO REAL, GARITA, MERCADO, CENTRAL CAMNIONERA, SOBRE LIBRIAMIENTO INSTITUTO POLITECNICO NACIONAL, TEPEHITEC).";
            string fechaVig = "31/12/2023";
            string director = "LIC. JOSE ANTONIO CARAMILLO SANCHEZ";
            string repuve = "322PIE61";*/
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

            PdfWriter.GetInstance(doc, new FileStream("PermisoFueraRuta.pdf", FileMode.Create));
            doc.AddAuthor("SecretariaMovilidadyTransporte");
            doc.AddTitle("Documento de Permiso Fuera de Ruta");

            doc.SetMargins(30f, 30f, 0f, 30f);

            doc.Open();
            var tabla1 = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
            var t1cel1 = new PdfPCell(new Paragraph($"{nombre}", fnormal)) { MinimumHeight = 90f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t1cel2 = new PdfPCell(new Paragraph($"{direccion}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };

            tabla1.AddCell(t1cel1);
            tabla1.AddCell(t1cel2);

            doc.Add(tabla1);

            var tabla2 = new PdfPTable(new float[] { 80f, 20f }) { WidthPercentage = 100 };
            var t2cel1 = new PdfPCell(new Paragraph($"{poblacion}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            var t2cel2 = new PdfPCell(new Paragraph($"{CP}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            tabla2.AddCell(t2cel1);
            tabla2.AddCell(t2cel2);
            doc.Add(tabla2);

            var tabla3 = new PdfPTable(new float[] { 34f, 33f, 33f, 33f }) { WidthPercentage = 100 };
            var t3cel1 = new PdfPCell(new Paragraph($"{placa}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            var t3cel2 = new PdfPCell(new Paragraph($"{TC}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            var t3cel3 = new PdfPCell(new Paragraph($"{marca}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            var t3cel4 = new PdfPCell(new Paragraph($"{modelo}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };

            tabla3.AddCell(t3cel1);
            tabla3.AddCell(t3cel2);
            tabla3.AddCell(t3cel3);
            tabla3.AddCell(t3cel4);

            doc.Add(tabla3);

            var tabla4 = new PdfPTable(new float[] { 30f, 50f, 20f }) { WidthPercentage = 100 };
            var t4cel1 = new PdfPCell(new Paragraph($"{motor}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            var t4cel2 = new PdfPCell(new Paragraph($"{serie}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            var t4cel3 = new PdfPCell(new Paragraph($"{repuve}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            tabla4.AddCell(t4cel1);
            tabla4.AddCell(t4cel2);
            tabla4.AddCell(t4cel3);
            doc.Add(tabla4);

            var tabla5 = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
            var t5cel1 = new PdfPCell(new Paragraph($"{motivo}", fnormal_mini)) { MinimumHeight = 25f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            tabla5.AddCell(t5cel1);
            doc.Add(tabla5);

            var tabla6 = new PdfPTable(new float[] { 33f, 33f, 34f }) { WidthPercentage = 100 };
            var t6cel1 = new PdfPCell(new Paragraph($"{fechaHoy}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            var t6cel2 = new PdfPCell(new Paragraph($"{fechaVig}", fnormal)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            var t6cel3 = new PdfPCell(new Paragraph($"{director}", fnormal_mini)) { MinimumHeight = 20f, Border = 0, VerticalAlignment = Element.ALIGN_MIDDLE };
            tabla6.AddCell(t6cel1);
            tabla6.AddCell(t6cel2);
            tabla6.AddCell(t6cel3);
            doc.Add(tabla6);

            doc.Close();
        }

        private void TXT_Placas_KeyPress(object sender, KeyPressEventArgs e) {
            if (char.IsLower(e.KeyChar)) {
                // Si es una letra minúscula, conviértela a mayúscula
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
    }
}
