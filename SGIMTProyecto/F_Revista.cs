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
using System.Reflection;

namespace SGIMTProyecto
{
    public partial class F_Revista : Form
    {
        private F_VisualizacionPDF formVisualizador;
        public F_Revista()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += Formulario_FormClosing;
        }
        private void LimpiarTextBox(Control control)
        {
            foreach (Control c in control.Controls)
            {
                // Si el control es un TextBox, establece su texto en blanco
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }

                // Si el control contiene otros controles, llama recursivamente a la función
                if (c.HasChildren)
                {
                    LimpiarTextBox(c);
                }
            }
        }
        private void Formulario_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Llamar al método para limpiar los TextBox cuando se cierra el formulario
            LimpiarTextBox(this);
        }

        #region Métodos
        private void Rev(string cTexto)
        {
            D_Revista Datos = new D_Revista();
            MostrarDatos(Datos.Rev(cTexto));
        }

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
            if (TXT_Placas.Text.Length != 9) {
                variable = JLB_Placas.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_NoSerie.Text.Trim().Length > 17 || TXT_NoSerie.Text.Trim().Length < 1) {
                variable = JLB_NoSerie.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Tipo.Text.Trim().Length > 15 || TXT_Tipo.Text.Trim().Length < 1) {
                variable = JLB_Tipo.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_NoMotor.Text.Trim(), out int noMotor)) {
                variable = JLB_NoMotor.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_AnioModelo.Text.Trim().Length != 4 || !int.TryParse(TXT_AnioModelo.Text.Trim(), out int anioModelo)) {
                variable = JLB_AnioModelo.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_ClaveVehicular.Text.Trim().Length > 7 || TXT_ClaveVehicular.Text.Trim().Length < 1) {
                variable = JLB_ClaveVehicular.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Marca.Text.Trim().Length > 15 || TXT_Marca.Text.Trim().Length < 1) {
                variable = JLB_Marca.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_NoPasajeros.Text.Trim(), out int noPasajeros)) {
                variable = JLB_NoPasajeros.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_FolioRevista.Text.Trim(), out int folioRevista)) {
                variable = JLB_FolioRevista.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_TipoConcesion.Text.Trim().Length > 50 || TXT_TipoConcesion.Text.Trim().Length < 1) {
                variable = JLB_TipoConcesion.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Resolucion.Text.Trim().Length > 50 || TXT_Resolucion.Text.Trim().Length < 1) {
                variable = JLB_Resolucion.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_SitioRuta.Text.Trim().Length > 500 || TXT_SitioRuta.Text.Trim().Length < 1) {
                variable = JLB_SitioRuta.Text;
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

        private string DocumentosUnidad() {
            string docUnidad = "";
            List<string> parametros = new List<string>();

            int tamanio;

            if (CHB_Repuve.Checked) {
                parametros.Add(CHB_Repuve.Text);
            }
            if (CHB_INE.Checked) {
                parametros.Add(CHB_INE.Text);
            }
            if (CHB_Seguro.Checked) {
                parametros.Add(CHB_Seguro.Text);
            }
            if (CHB_Factura.Checked) {
                parametros.Add(CHB_Factura.Text);
            }
            if (CHB_Dictamen.Checked) {
                parametros.Add(CHB_Dictamen.Text);
            }
            if (CHB_Contrato.Checked) {
                parametros.Add(CHB_Contrato.Text);
            }
            if (CHB_TarjetaCirculacion.Checked) {
                parametros.Add(CHB_TarjetaCirculacion.Text);
            }

            tamanio = parametros.Count;
            
            for (int i = 0; i < tamanio; i++) {
                docUnidad += parametros[i];
                if (i != tamanio - 1) {
                    docUnidad += ", ";
                }
            }

            return docUnidad;
        }

        private void LimpiarTextBox(){
            TXT_Nombre.Text = "";
            TXT_Domicilio.Text = "";
            TXT_Placas.Text = "";
            TXT_NoSerie.Text = "";
            TXT_Tipo.Text = "";
            TXT_NoMotor.Text = "";
            TXT_AnioModelo.Text = "";
            TXT_ClaveVehicular.Text = "";
            TXT_Marca.Text = "";
            TXT_NoPasajeros.Text = "";
            TXT_TipoConcesion.Text = "";
            TXT_Resolucion.Text = "";
            TXT_SitioRuta.Text = "";
            TXT_FolioRevista.Text = "";
            CHB_Repuve.Checked = false;
            CHB_INE.Checked = false;
            CHB_Seguro.Checked = false;
            CHB_Factura.Checked = false;
            CHB_Dictamen.Checked = false;
            CHB_Contrato.Checked = false;
            CHB_TarjetaCirculacion.Checked = false;
            CHB_ConcidcionesMecanicas.Checked = false;
            CHB_Llantas.Checked = false;
            CHB_LlantaAux.Checked = false;
            CHB_Luces.Checked = false;
            CHB_Direccionales.Checked = false;
            CHB_Cristales.Checked = false;
            CHB_Espejos.Checked = false;
            CHB_Limpiadores.Checked = false;
            CHB_Vestiduras.Checked = false;
            CHB_Defensas.Checked = false;
            CHB_PinturaGeneral.Checked = false;
            CHB_Rotulacion.Checked = false;
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
                if (primeraFila.Length > 1) TXT_Domicilio.Text = primeraFila[1];
                if (primeraFila.Length > 2) TXT_Placas.Text = primeraFila[2];
                if (primeraFila.Length > 3) TXT_NoSerie.Text = primeraFila[3];
                if (primeraFila.Length > 4) TXT_Tipo.Text = primeraFila[4];
                if (primeraFila.Length > 5) TXT_NoMotor.Text = primeraFila[5];
                if (primeraFila.Length > 6) TXT_AnioModelo.Text = primeraFila[6];
                if (primeraFila.Length > 7) TXT_ClaveVehicular.Text = primeraFila[7];
                if (primeraFila.Length > 8) TXT_Marca.Text = primeraFila[8];
                if (primeraFila.Length > 9) TXT_NoPasajeros.Text = primeraFila[9];
                if (primeraFila.Length > 10) TXT_TipoConcesion.Text = primeraFila[10];
                if (primeraFila.Length > 11) TXT_Resolucion.Text = primeraFila[11];
                if (primeraFila.Length > 12) TXT_SitioRuta.Text = primeraFila[12];
            }
            else
            {
                LimpiarTextBox();
                MessageBox.Show("Lo sentimos, la placa no existe en la base de datos :(", "Placa Ausente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void BTN_Inicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_BuscarPlaca_Click(object sender, EventArgs e)
        {
            this.Rev(TXT_Placa.Text.Trim());
        }

        private void BTN_GuardaImprimir_Click(object sender, EventArgs e)
        {
            (string mensajeError, bool bandera) = VerificacionParametros();

            if (bandera) {
                MessageBox.Show(mensajeError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                string placa = TXT_Placas.Text.Trim();
                string nombre = TXT_Nombre.Text.Trim();
                string direccion = TXT_Domicilio.Text.Trim();
                string serie = TXT_NoSerie.Text.Trim();
                string motor = TXT_NoMotor.Text.Trim();
                int modelo = Convert.ToInt32(TXT_AnioModelo.Text.Trim());
                string marca = TXT_Marca.Text.Trim();
                string tipo = TXT_Tipo.Text.Trim();
                string pasajeros = TXT_NoPasajeros.Text.Trim();
                string concecion = TXT_TipoConcesion.Text.Trim();
                string resolucion = TXT_Resolucion.Text.Trim();

                string docUnidad = DocumentosUnidad();
                string ruta = TXT_SitioRuta.Text.Trim();

                string condicionesR = "";
                string espejos = "";
                string llantas = "";
                string limpiadores = "";
                string llantaAux = "";
                string vestiduras = "";
                string luces = "";
                string defensas = "";
                string direccionales = "";
                string pinturaG = "";
                string cristales = "";
                string rotulacion = "";
                string observaciones = TXT_Observaciones.Text.Trim();

                if (CHB_ConcidcionesMecanicas.Checked){
                    condicionesR = "Check";
                }
                if (CHB_Llantas.Checked) {
                    llantas = "Check";
                }
                if (CHB_LlantaAux.Checked) {
                    llantaAux = "Check";
                }
                if (CHB_Luces.Checked) {
                    luces = "Check";
                }
                if (CHB_Direccionales.Checked) {
                    direccionales = "Check";
                }
                if (CHB_Cristales.Checked) {
                    cristales = "Check";
                }
                if (CHB_Espejos.Checked) {
                    espejos = "Check";
                }
                if (CHB_Limpiadores.Checked) {
                    limpiadores = "Check";
                }
                if (CHB_Vestiduras.Checked) {
                    vestiduras = "Check";
                }
                if (CHB_Defensas.Checked) {
                    defensas = "Check";
                }
                if (CHB_PinturaGeneral.Checked) {
                    pinturaG = "Check";
                }
                if (CHB_Rotulacion.Checked) {
                    rotulacion = "Check";
                }

                generarPDF(placa, nombre, direccion, serie, motor, modelo, marca, tipo, pasajeros, concecion, resolucion, docUnidad, ruta, condicionesR, espejos, llantas, limpiadores, llantaAux, vestiduras, luces, defensas, direccionales, pinturaG, cristales, rotulacion, observaciones);

                if (formVisualizador == null || formVisualizador.IsDisposed) {
                    F_VisualizacionPDF formVisualizador = new F_VisualizacionPDF();
                    formVisualizador.RecibirNombre("Revista.pdf");
                    formVisualizador.ShowDialog();
                }

                MessageBox.Show("El registro se agrego con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarTextBox();
            }
                /*REGISTROS QUE OCUPA 
                 * Boton de imprimir y guardar
                 * 
                 * string placa = "AXXXXX";
                    string nombre = "MANUEL ALEJANDRO MORA MENESES";
                    string direccion = "Enrique segoviano";
                    string serie = "VF1FLADRACY419294";
                    string motor = "C683198";
                    int modelo = 2023;
                    string marca = "RENAULT TRAFIC";
                    string tipo = "PANEL";
                    string pasajeros = "20 PASAJEROS";
                    string concecion = "COLECTIVO";
                    string resolucion = "RESOLUCION";
                    string docUnidad = "FACTURA, REPUVE , SEGURO, INE, CONTRATO DE COMPRA VENTA";
                    string ruta = "PAPALOTLA - PANZACOLA - P.I.(BUENAVENTURA)";
                    string condicionesR = "Check";
                    string espejos = "Check";
                    string llantas = "Check";
                    string limpiadores = "Check";
                    string llantaAux = "Check";
                    string vestiduras = "Check";
                    string luces = "Check";
                    string defensas = "Check";
                    string direccionales = "Check";
                    string pinturaG = "Check";
                    string cristales = "Check";
                    string rotulacion = "Check";
                    string observaciones = "CAMBIO DE UNIDAD SALE TOYOTA 2016, ENTRA TOYOTA 2010";
                 * 
                 * 
                 * 
                 */


            }

        private static void generarPDF (string placa, string nombre, string direccion, string serie, string motor, int modelo, string marca, string tipo, string pasajeros, string concecion, string resolucion, string docUnidad, string ruta, string condicionesR, string espejos, string llantas, string limpiadores, string llantaAux, string vestiduras, string luces, string defensas, string direccionales, string pinturaG, string cristales, string rotulacion, string observaciones)
        {

            #region datos
            DateTime today = DateTime.Today;
            //variables dentro de la funcion:
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            int dia = today.Day;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);
            int year = DateTime.Today.Year;

            /*string placa = "AXXXXX";
            string nombre = "MANUEL ALEJANDRO MORA MENESES";
            string direccion = "ENCINOS NO 7 B. OCOTLAN DE TEPATLAXCO, CONTLA DE JUAN CUAMATIZI, TLAX.";
            string serie = "VF1FLADRACY419294";
            string motor = "C683198";
            int modelo = 2023;
            string marca = "RENAULT TRAFIC";
            string tipo = "PANEL";
            string pasajeros = "20 PASAJEROS";
            string concecion = "COLECTIVO";
            string resolucion = "RESOLUCION";
            string docUnidad = "FACTURA, REPUVE , SEGURO, INE, CONTRATO DE COMPRA VENTA";
            string ruta = "PAPALOTLA - PANZACOLA - P.I.(BUENAVENTURA)";
            string condicionesR = "Check";
            string espejos = "Check";
            string llantas = "Check";
            string limpiadores = "Check";
            string llantaAux = "Check";
            string vestiduras = "Check";
            string luces = "Check";
            string defensas = "Check";
            string direccionales = "Check";
            string pinturaG = "Check";
            string cristales = "Check";
            string rotulacion = "Check";
            string observaciones = "CAMBIO DE UNIDAD SALE TOYOTA 2016, ENTRA TOYOTA 2010";*/
            #endregion

            #region generar pdf
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("Revista.pdf", FileMode.Create));
            doc.AddAuthor("SecretariaMovilidadyTransporte");
            doc.AddTitle("Documento de Revista");

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

            doc.Open();
            var Header = new PdfPTable(new float[] { 5f, 95f }) { WidthPercentage = 100 };

            var Hcell1 = new PdfPCell(new Paragraph($"", fnormal_mini)) { MinimumHeight = 150f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var Hcell2 = new PdfPCell(new Paragraph($"{nombre}", fnormal)) { MinimumHeight = 90f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };

            Header.AddCell(Hcell1);
            Header.AddCell(Hcell2);

            doc.Add(Header);

            var tabla2 = new PdfPTable(new float[] { 7f, 93f }) { WidthPercentage = 100 };
            var t2cel1 = new PdfPCell(new Paragraph("")) { MinimumHeight = 55f, Border = 0 };
            var t2cel2 = new PdfPCell(new Paragraph($"\n{direccion}", fnormal)) { MinimumHeight = 55f, Border = 0 };

            tabla2.AddCell(t2cel1);
            tabla2.AddCell(t2cel2);

            doc.Add(tabla2);

            var tabla3 = new PdfPTable(new float[] { 8f, 35f, 10f, 33f, 10f, 33f }) { WidthPercentage = 100 };
            var t3cel1 = new PdfPCell(new Paragraph("")) { MinimumHeight = 20f, Border = 0 };
            var t3cel2 = new PdfPCell(new Paragraph($"{placa}", fnormal)) { Border = 0 };
            var t3cel3 = new PdfPCell(new Paragraph("")) { Border = 0 };
            var t3cel4 = new PdfPCell(new Paragraph($"{serie}", fnormal)) { Border = 0 };
            var t3cel5 = new PdfPCell(new Paragraph("")) { Border = 0 };
            var t3cel6 = new PdfPCell(new Paragraph($"{tipo}", fnormal)) { Border = 0 };

            tabla3.AddCell(t3cel1);
            tabla3.AddCell(t3cel2);
            tabla3.AddCell(t3cel3);
            tabla3.AddCell(t3cel4);
            tabla3.AddCell(t3cel5);

            tabla3.AddCell(t3cel6);
            doc.Add(tabla3);

            var tabla4 = new PdfPTable(new float[] { 14f, 35f, 12f, 33f, 10f, 33f }) { WidthPercentage = 100 };

            var t4cel1 = new PdfPCell(new Paragraph(" ")) { Border = 0, MinimumHeight = 20f };
            var t4cel2 = new PdfPCell(new Paragraph($"{motor}", fnormal)) { Border = 0 };
            var t4cel3 = new PdfPCell(new Paragraph("")) { Border = 0 };
            var t4cel4 = new PdfPCell(new Paragraph($"{modelo}", fnormal)) { Border = 0 };
            var t4cel5 = new PdfPCell(new Paragraph("")) { Border = 0 };
            var t4cel6 = new PdfPCell(new Paragraph("")) { Border = 0 };

            tabla4.AddCell(t4cel1);
            tabla4.AddCell(t4cel2);
            tabla4.AddCell(t4cel3);
            tabla4.AddCell(t4cel4);
            tabla4.AddCell(t4cel5);
            tabla4.AddCell(t4cel6);

            doc.Add(tabla4);

            var tabla5 = new PdfPTable(new float[] { 8f, 40, 10f, 42f }) { WidthPercentage = 100 };
            var t5cel1 = new PdfPCell(new Paragraph(" ")) { Border = 0 };
            var t5cel2 = new PdfPCell(new Paragraph($"{marca}", fnormal)) { Border = 0 };
            var t5cel3 = new PdfPCell(new Paragraph(" ")) { Border = 0 };
            var t5cel4 = new PdfPCell(new Paragraph($"{pasajeros}", fnormal)) { Border = 0 };

            tabla5.AddCell(t5cel1);
            tabla5.AddCell(t5cel2);
            tabla5.AddCell(t5cel3);
            tabla5.AddCell(t5cel4);

            doc.Add(tabla5);

            var tablac1 = new PdfPTable(new float[] { 16f, 86f }) { WidthPercentage = 100 };
            var tc1cell1 = new PdfPCell(new Paragraph(" ")) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var tc1cell2 = new PdfPCell(new Paragraph($"{concecion}", fnormal)) { MinimumHeight = 25f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };

            tablac1.AddCell(tc1cell1);
            tablac1.AddCell(tc1cell2);

            doc.Add(tablac1);

            var tablac2 = new PdfPTable(new float[] { 14f, 86f }) { WidthPercentage = 100 };
            var tc2cel1 = new PdfPCell(new Paragraph("")) { MinimumHeight = 20f, Border = 0 };
            var tc2cel2 = new PdfPCell(new Paragraph($"{resolucion}", fnormal)) { MinimumHeight = 15f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };

            tablac2.AddCell(tc2cel1);
            tablac2.AddCell(tc2cel2);

            doc.Add(tablac2);

            var tablac3 = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
            var tc3cel1 = new PdfPCell(new Paragraph("")) { MinimumHeight = 20f, Border = 0 };
            tablac3.AddCell(tc3cel1);
            doc.Add(tablac3);

            var tablac4 = new PdfPTable(new float[] { 20f, 80f }) { WidthPercentage = 100f };
            var tc4cel1 = new PdfPCell(new Paragraph("")) { Border = 0 };
            var tc4cel2 = new PdfPCell(new Paragraph($"{docUnidad}", fnormal)) { Border = 0 };
            tablac4.AddCell(tc4cel1);
            tablac4.AddCell(tc4cel2);
            doc.Add(tablac4);

            var tablac5 = new PdfPTable(new float[] { 10f, 80f }) { WidthPercentage = 100f };
            var tc5cel1 = new PdfPCell(new Paragraph("")) { Border = 0 };
            var tc5cel2 = new PdfPCell(new Paragraph($"{ruta}", fnormal)) { Border = 0 };
            tablac5.AddCell(tc5cel1);
            tablac5.AddCell(tc5cel2);
            doc.Add(tablac5);

            var tablac6 = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
            var tc6cel1 = new PdfPCell(new Paragraph("")) { MinimumHeight = 45f, Border = 0 };
            tablac6.AddCell(tc6cel1);
            doc.Add(tablac6);

            var tabc = new PdfPTable(new float[] { 17f, 40, 15, 28f }) { WidthPercentage = 100 };
            var tbc1cel1 = new PdfPCell(new Paragraph("")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel2 = new PdfPCell(new Paragraph($"{condicionesR}", fnormal)) { Border = 0 };
            var tbc1cel3 = new PdfPCell(new Paragraph($"")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel4 = new PdfPCell(new Paragraph($"{espejos}", fnormal)) { Border = 0 };
            var tbc1cel5 = new PdfPCell(new Paragraph($"")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel6 = new PdfPCell(new Paragraph($"{llantas}", fnormal)) { Border = 0 };
            var tbc1cel7 = new PdfPCell(new Paragraph($"")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel8 = new PdfPCell(new Paragraph($"{limpiadores}", fnormal)) { Border = 0, MinimumHeight = 20 };
            var tbc1cel9 = new PdfPCell(new Paragraph($"")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel10 = new PdfPCell(new Paragraph($"{llantaAux}", fnormal)) { Border = 0, MinimumHeight = 20 };
            var tbc1cel11 = new PdfPCell(new Paragraph($"")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel12 = new PdfPCell(new Paragraph($"{vestiduras}", fnormal)) { Border = 0, MinimumHeight = 20 };
            var tbc1cel13 = new PdfPCell(new Paragraph($"")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel14 = new PdfPCell(new Paragraph($"{luces}", fnormal)) { Border = 0, MinimumHeight = 20 };
            var tbc1cel15 = new PdfPCell(new Paragraph($"")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel16 = new PdfPCell(new Paragraph($"{defensas}", fnormal)) { Border = 0, MinimumHeight = 20 };
            var tbc1cel17 = new PdfPCell(new Paragraph($"")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel18 = new PdfPCell(new Paragraph($"{direccionales}", fnormal)) { Border = 0, MinimumHeight = 20 };
            var tbc1cel19 = new PdfPCell(new Paragraph($"")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel20 = new PdfPCell(new Paragraph($"{pinturaG}", fnormal)) { Border = 0, MinimumHeight = 20 };
            var tbc1cel21 = new PdfPCell(new Paragraph($"")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel22 = new PdfPCell(new Paragraph($"{cristales}", fnormal)) { Border = 0, MinimumHeight = 20 };
            var tbc1cel23 = new PdfPCell(new Paragraph($"")) { Border = 0, MinimumHeight = 20 };
            var tbc1cel24 = new PdfPCell(new Paragraph($"{rotulacion}", fnormal)) { Border = 0, MinimumHeight = 20 };
            tabc.AddCell(tbc1cel1);
            tabc.AddCell(tbc1cel2);
            tabc.AddCell(tbc1cel3);
            tabc.AddCell(tbc1cel4);
            tabc.AddCell(tbc1cel5);
            tabc.AddCell(tbc1cel6);
            tabc.AddCell(tbc1cel7);
            tabc.AddCell(tbc1cel8);
            tabc.AddCell(tbc1cel9);
            tabc.AddCell(tbc1cel10);
            tabc.AddCell(tbc1cel11);
            tabc.AddCell(tbc1cel12);
            tabc.AddCell(tbc1cel13);
            tabc.AddCell(tbc1cel14);
            tabc.AddCell(tbc1cel15);
            tabc.AddCell(tbc1cel16);
            tabc.AddCell(tbc1cel17);
            tabc.AddCell(tbc1cel18);
            tabc.AddCell(tbc1cel19);
            tabc.AddCell(tbc1cel20);
            tabc.AddCell(tbc1cel21);
            tabc.AddCell(tbc1cel22);
            tabc.AddCell(tbc1cel23);
            tabc.AddCell(tbc1cel24);

            doc.Add(tabc);

            var tblanco = new PdfPTable(new float[] { 100f });
            var celblanco = new PdfPCell(new Paragraph(" ")) { Border = 0 };
            tblanco.AddCell(celblanco);
            doc.Add(tblanco);

            var tablaobservaciones = new PdfPTable(new float[] { 12f, 93f }) { WidthPercentage = 100 };
            var c1 = new PdfPCell(new Paragraph("")) { MinimumHeight = 65f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var c2 = new PdfPCell(new Paragraph($"{observaciones}", fnormal)) { MinimumHeight = 50f, Border = 0 };
            tablaobservaciones.AddCell(c1);
            tablaobservaciones.AddCell(c2);
            doc.Add(tablaobservaciones);

            var tablafondo = new PdfPTable(new float[] { 30f, 35f, 25f }) { WidthPercentage = 100 };
            var cl1 = new PdfPCell(new Paragraph("")) { Border = 0 };
            var cl2 = new PdfPCell(new Paragraph($"{dia}            {mes.ToUpper()}", fnormal_mini)) { MinimumHeight = 60f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var cl3 = new PdfPCell(new Paragraph($"{year}", fnormal_mini)) { MinimumHeight = 40f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            tablafondo.AddCell(cl1);
            tablafondo.AddCell(cl2);
            tablafondo.AddCell(cl3);
            doc.Add(tablafondo);
            doc.Close();

            #endregion
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
