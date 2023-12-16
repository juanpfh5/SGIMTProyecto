
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
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace SGIMTProyecto
{
    public partial class F_TarjetaCirculacion : Form
    {
        public F_TarjetaCirculacion()
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
        private void TC(string cTexto)
        {
            D_TarjetaCirculacion Datos = new D_TarjetaCirculacion();
            MostrarDatos(Datos.TC(cTexto));
        }

        private void MostrarDatos(List<string[]> datos)
        {
            // Verificar que haya al menos una fila de datos
            if (datos.Count > 0)
            {
                // Acceder a los valores de la primera fila
                string[] primeraFila = datos[0];

                // Mostrar los valores en TextBox correspondientes
                if (primeraFila.Length > 0) TXT_Propietario.Text = primeraFila[0];
                if (primeraFila.Length > 1) TXT_Domicilio.Text = primeraFila[1];
                if (primeraFila.Length > 2) TXT_Vehiculo.Text = primeraFila[2];
                if (primeraFila.Length > 3) TXT_RFC.Text = primeraFila[3];
                if (primeraFila.Length > 4) TXT_Repuve.Text = primeraFila[4];
                if (primeraFila.Length > 5) TXT_NIV.Text = primeraFila[5];
                if (primeraFila.Length > 6) TXT_Placas.Text = primeraFila[6];
                if (primeraFila.Length > 7) TXT_Toneladas.Text = primeraFila[7];
                if (primeraFila.Length > 8) TXT_NoMotor.Text = primeraFila[8];
                if (primeraFila.Length > 9) TXT_Cilindros.Text = primeraFila[9];
                if (primeraFila.Length > 10) TXT_Personas.Text = primeraFila[10];
                if (primeraFila.Length > 11) TXT_Marca.Text = primeraFila[11];
                if (primeraFila.Length > 12) TXT_Combustible.Text = primeraFila[12];
                if (primeraFila.Length > 13) TXT_Modelo.Text = primeraFila[13];
                if (primeraFila.Length > 14) TXT_ClaveVehicular.Text = primeraFila[14];
                if (primeraFila.Length > 15) TXT_ClaseTipo.Text = primeraFila[15];
                if (primeraFila.Length > 16) TXT_Uso.Text = primeraFila[16];
                if (primeraFila.Length > 17) TXT_TipoServicio.Text = primeraFila[17];
                if (primeraFila.Length > 18) TXT_NoConcesion.Text = primeraFila[18];
                if (primeraFila.Length > 19) TXT_VehiculoOrigen.Text = primeraFila[19];
                if (primeraFila.Length > 20) TXT_SitioRuta.Text = primeraFila[20];
                if (primeraFila.Length > 21) TXT_Folio.Text = primeraFila[21];
            }
            else
            {
                TXT_Propietario.Text = "";
                TXT_Domicilio.Text = "";
                TXT_Vehiculo.Text = "";
                TXT_RFC.Text = "";
                TXT_Repuve.Text = "";
                TXT_NIV.Text = "";
                TXT_Placas.Text = "";
                TXT_Toneladas.Text = "";
                TXT_NoMotor.Text = "";
                TXT_Cilindros.Text = "";
                TXT_Personas.Text = "";
                TXT_Marca.Text = "";
                TXT_Combustible.Text = "";
                TXT_Modelo.Text = "";
                TXT_ClaveVehicular.Text = "";
                TXT_ClaseTipo.Text = "";
                TXT_Uso.Text = "";
                TXT_TipoServicio.Text = "";
                TXT_NoConcesion.Text = "";
                TXT_VehiculoOrigen.Text = "";
                TXT_SitioRuta.Text = "";
                TXT_Folio.Text = "";
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
            this.TC(TXT_Placa.Text.Trim());
        }

        private void BTN_TarjetaCirculacion_Click(object sender, EventArgs e)
        {
            /*REQUISITOS PARA ENVIAR EN LA ELABORACION DEL PDF
             * 
             * 
             * string placa = "AXXXXX";
                string nombre = "MANUEL ALEJANDRO MORA MENESES";
                string direccion = "EL ROBLE EXT. 4 INT. - COL. EL SABINAL, TLAXCO, TLAXCALA";
                string serie = "VF1FLADRACY419294";
                string motor = "C683198";
                int modelo = 2023;
                string marca = "RENAULT TRAFIC";
                string tipo = "PANEL";
                string pasajeros = "20 PASAJEROS";
                string concecion = "COLECTIVO";
                string ruta = "INFORNAVIT PETROQUIMICA.TLAX DE XICOHTENCATL-PROCURADURIA GRAL DE JUSTICIA PI (GRAN PATIO, SAN PABLO APETATITLAN, CAMINO REAL, GARITA, MERCADO, CENTRAL CAMNIONERA, SOBRE LIBRIAMIENTO INSTITUTO POLITECNICO NACIONAL, TEPEHITEC).";
                string rfc = "TUX920811PQ7";
                string vehiculo = "NISSAN";
                string clvVehicular = "1982432";
                string ofcExp = "SAN PABLO APETATITLAN";
                string tipoServ = "SERV.PUB.LOCAL CON ITINERARIO FIJO";
                string vehOrig = "NACIONAL";
                string tramite = "";
                string fechaExp = "17-JULIO-23";
                string vigencia = "31-DIC-2023";
                string noConcecion = "P/213/23";
                string cilindros = "4 CIL";
                string combustible = "GASOLINA";
                string repuve = "322PIE61";
                string capacidad = "";
                string toneladas = "";
                int personas = 17;
                string uso = "COLECTIVO";
                string secretario = "LIC. JUAN TAPIA PELCASTRE";
             * 
             */
        }
        private static void GenerarPDF()
        {
            string placa = "AXXXXX";
            string nombre = "MANUEL ALEJANDRO MORA MENESES";
            string direccion = "EL ROBLE EXT. 4 INT. - COL. EL SABINAL, TLAXCO, TLAXCALA";
            string serie = "VF1FLADRACY419294";
            string motor = "C683198";
            int modelo = 2023;
            string marca = "RENAULT TRAFIC";
            string tipo = "PANEL";
            string pasajeros = "20 PASAJEROS";
            string concecion = "COLECTIVO";
            string ruta = "INFORNAVIT PETROQUIMICA.TLAX DE XICOHTENCATL-PROCURADURIA GRAL DE JUSTICIA PI (GRAN PATIO, SAN PABLO APETATITLAN, CAMINO REAL, GARITA, MERCADO, CENTRAL CAMNIONERA, SOBRE LIBRIAMIENTO INSTITUTO POLITECNICO NACIONAL, TEPEHITEC).";
            string rfc = "TUX920811PQ7";
            string vehiculo = "NISSAN";
            string clvVehicular = "1982432";
            string ofcExp = "SAN PABLO APETATITLAN";
            string tipoServ = "SERV.PUB.LOCAL CON ITINERARIO FIJO";
            string vehOrig = "NACIONAL";
            string tramite = "";
            string fechaExp = "17-JULIO-23";
            string vigencia = "31-DIC-2023";
            string noConcecion = "P/213/23";
            string cilindros = "4 CIL";
            string combustible = "GASOLINA";
            string repuve = "322PIE61";
            string capacidad = "";
            string toneladas = "";
            int personas = 17;
            string uso = "COLECTIVO";
            string secretario = "LIC. JUAN TAPIA PELCASTRE";

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

            PdfWriter.GetInstance(doc, new FileStream("TarjetaCirculacion.pdf", FileMode.Create));
            doc.AddAuthor("SecretariaMovilidadyTransporte");
            doc.AddTitle("Documento de Liberacion");

            doc.SetMargins(35f, 50f, 0f, 50f);

            doc.Open();
            var tabla1 = new PdfPTable(new float[] { 25f, 25f, 50f }) { WidthPercentage = 100f };
            var cel1 = new PdfPCell(new Paragraph($"{nombre}", fnormal_mini)) { MinimumHeight = 100f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var cel2 = new PdfPCell(new Paragraph($"{serie}", fnormal_mini)) { VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var cel3 = new PdfPCell(new Paragraph("")) { Border = 0 };

            tabla1.AddCell(cel1);
            tabla1.AddCell(cel2);
            tabla1.AddCell(cel3);

            var cel4 = new PdfPCell(new Paragraph($"{rfc}", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };
            var cel5 = new PdfPCell(new Paragraph($"{serie}", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var cel6 = new PdfPCell(new Paragraph($"", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };

            tabla1.AddCell(cel4);
            tabla1.AddCell(cel5);
            tabla1.AddCell(cel6);
            doc.Add(tabla1);

            var tabla2 = new PdfPTable(new float[] { 12f, 12f, 12f, 12f, 48f }) { WidthPercentage = 100 };
            var t2cel1 = new PdfPCell(new Paragraph($"{vehiculo}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };
            var t2cel2 = new PdfPCell(new Paragraph($"{marca}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };
            var t2cel3 = new PdfPCell(new Paragraph($"{cilindros}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };
            var t2cel4 = new PdfPCell(new Paragraph($"{combustible}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };
            var t2cel5 = new PdfPCell(new Paragraph($"", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };

            tabla2.AddCell(t2cel1);
            tabla2.AddCell(t2cel2);
            tabla2.AddCell(t2cel3);
            tabla2.AddCell(t2cel4);
            tabla2.AddCell(t2cel5);
            doc.Add(tabla2);

            var tabla3 = new PdfPTable(new float[] { 8f, 8f, 9f, 25f, 50f }) { WidthPercentage = 100 };
            var t3cel1 = new PdfPCell(new Paragraph($"{modelo}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t3cel2 = new PdfPCell(new Paragraph($"{tipo}", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t3cel3 = new PdfPCell(new Paragraph($"{clvVehicular}", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t3cel4 = new PdfPCell(new Paragraph($"{repuve}", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t3cel5 = new PdfPCell(new Paragraph("")) { Border = 0 };
            tabla3.AddCell(t3cel1);
            tabla3.AddCell(t3cel2);
            tabla3.AddCell(t3cel3);
            tabla3.AddCell(t3cel4);
            tabla3.AddCell(t3cel5);
            doc.Add(tabla3);

            var tabla4 = new PdfPTable(new float[] { 12f, 13f, 8f, 8f, 8f, 50f }) { WidthPercentage = 100f };
            var t4cel1 = new PdfPCell(new Paragraph($"{ofcExp}", fnormal_supermini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t4cel2 = new PdfPCell(new Paragraph($"{tipoServ}", fnormal_supermini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t4cel3 = new PdfPCell(new Paragraph($"{capacidad}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t4cel4 = new PdfPCell(new Paragraph($"{toneladas}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t4cel5 = new PdfPCell(new Paragraph($"{personas}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t4cel6 = new PdfPCell(new Paragraph($"", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            tabla4.AddCell(t4cel1);
            tabla4.AddCell(t4cel2);
            tabla4.AddCell(t4cel3);
            tabla4.AddCell(t4cel4);
            tabla4.AddCell(t4cel5);
            tabla4.AddCell(t4cel6);
            doc.Add(tabla4);

            var tabla5 = new PdfPTable(new float[] { 12f, 13f, 25f, 50f }) { WidthPercentage = 100f };
            var t5cel1 = new PdfPCell(new Paragraph($"{vehOrig}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t5cel2 = new PdfPCell(new Paragraph($"{tramite}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t5cel3 = new PdfPCell(new Paragraph($"{uso}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t5cel4 = new PdfPCell(new Paragraph($"", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            tabla5.AddCell(t5cel1);
            tabla5.AddCell(t5cel2);
            tabla5.AddCell(t5cel3);
            tabla5.AddCell(t5cel4);
            doc.Add(tabla5);

            var tabla6 = new PdfPTable(new float[] { 12f, 13f, 25f, 50f }) { WidthPercentage = 100f };
            var t6cel1 = new PdfPCell(new Paragraph($"{fechaExp}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t6cel2 = new PdfPCell(new Paragraph($"{vigencia}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t6cel3 = new PdfPCell(new Paragraph($"{placa}", fnegrita)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 2, Border = 0 };
            var t6cel4 = new PdfPCell(new Paragraph("")) { Border = 0 };
            tabla6.AddCell(t6cel1);
            tabla6.AddCell(t6cel2);
            tabla6.AddCell(t6cel3);
            tabla6.AddCell(t6cel4);

            t6cel1.Phrase = new Phrase($"{noConcecion}", fnormal_mini);
            t6cel1.HorizontalAlignment = Element.ALIGN_RIGHT;
            t6cel2.Phrase = new Phrase("");
            t6cel4.Phrase = new Phrase("");
            tabla6.AddCell(t6cel1);
            tabla6.AddCell(t6cel2);
            tabla6.AddCell(t6cel4);
            doc.Add(tabla6);

            var tabla7 = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100f };
            var t7cel1 = new PdfPCell(new Paragraph($"{direccion}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            tabla7.AddCell(t7cel1);
            doc.Add(tabla7);

            var tabla8 = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100f };
            var t8cel1 = new PdfPCell(new Paragraph($"\n\n{ruta}", fnormal_mini)) { MinimumHeight = 100f, Border = 0 };
            var t8cel2 = new PdfPCell(new Paragraph($"", fnormal_mini)) { MinimumHeight = 60f, Border = 0 };
            tabla8.AddCell(t8cel1);
            tabla8.AddCell(t8cel2);
            doc.Add(tabla8);

            var tabla9 = new PdfPTable(new float[] { 25f, 25f, 50f }) { WidthPercentage = 100f };
            var t9cel1 = new PdfPCell(new Paragraph("")) { MinimumHeight = 20f, Border = 0 };
            var t9cel2 = new PdfPCell(new Paragraph($"{secretario}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var t9cel3 = new PdfPCell(new Paragraph("")) { MinimumHeight = 20f, Border = 0 };
            tabla9.AddCell(t9cel1);
            tabla9.AddCell(t9cel2);
            tabla9.AddCell(t9cel3);
            doc.Add(tabla9);

            //segunda parte

            var tabla10 = new PdfPTable(new float[] { 25f, 25f, 50f }) { WidthPercentage = 100f };
            var cel10 = new PdfPCell(new Paragraph($"{nombre}", fnormal_mini)) { MinimumHeight = 100f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var cel20 = new PdfPCell(new Paragraph($"{serie}", fnormal_mini)) { VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var cel30 = new PdfPCell(new Paragraph("")) { Border = 0 };

            tabla10.AddCell(cel10);
            tabla10.AddCell(cel20);
            tabla10.AddCell(cel30);

            var cel40 = new PdfPCell(new Paragraph($"{rfc}", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };
            var cel50 = new PdfPCell(new Paragraph($"{serie}", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var cel60 = new PdfPCell(new Paragraph($"", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };

            tabla10.AddCell(cel40);
            tabla10.AddCell(cel50);
            tabla10.AddCell(cel60);
            doc.Add(tabla10);

            var tabla20 = new PdfPTable(new float[] { 12f, 12f, 12f, 12f, 48f }) { WidthPercentage = 100 };
            var t20cel1 = new PdfPCell(new Paragraph($"{vehiculo}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };
            var t20cel2 = new PdfPCell(new Paragraph($"{marca}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };
            var t20cel3 = new PdfPCell(new Paragraph($"{cilindros}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };
            var t20cel4 = new PdfPCell(new Paragraph($"{combustible}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };
            var t20cel5 = new PdfPCell(new Paragraph($"", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };

            tabla20.AddCell(t20cel1);
            tabla20.AddCell(t20cel2);
            tabla20.AddCell(t20cel3);
            tabla20.AddCell(t20cel4);
            tabla20.AddCell(t20cel5);
            doc.Add(tabla20);

            var tabla30 = new PdfPTable(new float[] { 8f, 8f, 9f, 25f, 50f }) { WidthPercentage = 100 };
            var t30cel1 = new PdfPCell(new Paragraph($"{modelo}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t30cel2 = new PdfPCell(new Paragraph($"{tipo}", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t30cel3 = new PdfPCell(new Paragraph($"{clvVehicular}", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t30cel4 = new PdfPCell(new Paragraph($"{repuve}", fnormal_mini)) { HorizontalAlignment = Element.ALIGN_CENTER, MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0 };
            var t30cel5 = new PdfPCell(new Paragraph("")) { Border = 0 };
            tabla30.AddCell(t30cel1);
            tabla30.AddCell(t30cel2);
            tabla30.AddCell(t30cel3);
            tabla30.AddCell(t30cel4);
            tabla30.AddCell(t30cel5);
            doc.Add(tabla30);

            var tabla40 = new PdfPTable(new float[] { 12f, 13f, 8f, 8f, 8f, 50f }) { WidthPercentage = 100f };
            var t40cel1 = new PdfPCell(new Paragraph($"{ofcExp}", fnormal_supermini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t40cel2 = new PdfPCell(new Paragraph($"{tipoServ}", fnormal_supermini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t40cel3 = new PdfPCell(new Paragraph($"{capacidad}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t40cel4 = new PdfPCell(new Paragraph($"{toneladas}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t40cel5 = new PdfPCell(new Paragraph($"{personas}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t40cel6 = new PdfPCell(new Paragraph($"", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            tabla40.AddCell(t40cel1);
            tabla40.AddCell(t40cel2);
            tabla40.AddCell(t40cel3);
            tabla40.AddCell(t40cel4);
            tabla40.AddCell(t40cel5);
            tabla40.AddCell(t40cel6);
            doc.Add(tabla40);

            var tabla50 = new PdfPTable(new float[] { 12f, 13f, 25f, 50f }) { WidthPercentage = 100f };
            var t50cel1 = new PdfPCell(new Paragraph($"{vehOrig}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t50cel2 = new PdfPCell(new Paragraph($"{tramite}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t50cel3 = new PdfPCell(new Paragraph($"{uso}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t50cel4 = new PdfPCell(new Paragraph($"", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            tabla50.AddCell(t50cel1);
            tabla50.AddCell(t50cel2);
            tabla50.AddCell(t50cel3);
            tabla50.AddCell(t50cel4);
            doc.Add(tabla50);

            var tabla60 = new PdfPTable(new float[] { 12f, 13f, 25f, 50f }) { WidthPercentage = 100f };
            var t60cel1 = new PdfPCell(new Paragraph($"{fechaExp}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t60cel2 = new PdfPCell(new Paragraph($"{vigencia}", fnormal_mini)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t60cel3 = new PdfPCell(new Paragraph($"{placa}", fnegrita)) { MinimumHeight = 20f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 2, Border = 0 };
            var t60cel4 = new PdfPCell(new Paragraph("")) { Border = 0 };
            tabla60.AddCell(t60cel1);
            tabla60.AddCell(t60cel2);
            tabla60.AddCell(t60cel3);
            tabla60.AddCell(t60cel4);

            t60cel1.Phrase = new Phrase($"{noConcecion}", fnormal_mini);
            t60cel1.HorizontalAlignment = Element.ALIGN_RIGHT;
            t60cel1.Border = 0;
            t60cel2.Phrase = new Phrase("");
            t60cel2.Border = 0;
            t60cel4.Phrase = new Phrase("");
            t60cel4.Border = 0;
            tabla60.AddCell(t60cel1);
            tabla60.AddCell(t60cel2);
            tabla60.AddCell(t60cel4);
            doc.Add(tabla60);

            var tabla70 = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100f };
            var t70cel1 = new PdfPCell(new Paragraph($"{direccion}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            tabla70.AddCell(t70cel1);
            doc.Add(tabla70);

            var tabla80 = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100f };
            var t80cel1 = new PdfPCell(new Paragraph($"\n\n{ruta}", fnormal_mini)) { MinimumHeight = 100f, Border = 0 };
            var t80cel2 = new PdfPCell(new Paragraph($"", fnormal_mini)) { MinimumHeight = 60f, Border = 0 };
            tabla80.AddCell(t80cel1);
            tabla80.AddCell(t80cel2);
            doc.Add(tabla80);

            var tabla90 = new PdfPTable(new float[] { 25f, 25f, 50f }) { WidthPercentage = 100f };
            var t90cel1 = new PdfPCell(new Paragraph("")) { MinimumHeight = 20f, Border = 0 };
            var t90cel2 = new PdfPCell(new Paragraph($"{secretario}", fnormal_mini)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_BOTTOM, HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var t90cel3 = new PdfPCell(new Paragraph("")) { MinimumHeight = 20f, Border = 0 };
            tabla90.AddCell(t90cel1);
            tabla90.AddCell(t90cel2);
            tabla90.AddCell(t90cel3);
            doc.Add(tabla90);
            doc.Close();
        }

        private void BTN_PermisoProvisional_Click(object sender, EventArgs e)
        {
            //en caso de ser permiso provisional
            /*REQUISITOS PARA IMPRESION:
             * 
             * #region DATOS - PERMISO SIN TC

                CultureInfo culturaEspañol = new CultureInfo("es-ES");
                DateTime today = DateTime.Today;
                int nOficio = 1570;
                int year = today.Year;
                int dia = today.Day;
                string mes = DateTime.Today.ToString("MMMM", culturaEspañol);

                string placa = "AXXXXX";
                string nombre = "MANUEL ALEJANDRO MORA MENESES";
                string direccion = "EL ROBLE EXT. 4 INT. - COL. EL SABINAL, TLAXCO, TLAXCALA";
                string serie = "VF1FLADRACY419294";
                string motor = "C683198";
                int modelo = 2023;
                string marca = "RENAULT TRAFIC";
                string tipo = "PANEL";
                string ruta = "INFORNAVIT PETROQUIMICA.TLAX DE XICOHTENCATL-PROCURADURIA GRAL DE JUSTICIA PI (GRAN PATIO, SAN PABLO APETATITLAN, CAMINO REAL, GARITA, MERCADO, CENTRAL CAMNIONERA, SOBRE LIBRIAMIENTO INSTITUTO POLITECNICO NACIONAL, TEPEHITEC).";
                string rfc = "TUX920811PQ7";
                string clvVehicular = "1982432";
                string ofcExp = "SAN PABLO APETATITLAN";
                string tipoServ = "SERV.PUB.LOCAL CON ITINERARIO FIJO";
                string vehOrig = "NACIONAL";
                string tramite = "";
                string noConcecion = "P/213/23";
                string cilindros = "4 CIL";
                string combustible = "GASOLINA";
                string toneladas = "";
                int personas = 17;
                string uso = "COLECTIVO";
                int diasPermiso = 90;
                string director = "LIC. JOSE ANTONIO CARAMILLO SANCHEZ";
                int nOficio = 1570;
                #endregion
             */

        }
        private static void GenerarProvisionalPDF()
        {
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            DateTime today = DateTime.Today;

            int year = today.Year;
            int dia = today.Day;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);

            string placa = "AXXXXX";
            string nombre = "MANUEL ALEJANDRO MORA MENESES";
            string direccion = "EL ROBLE EXT. 4 INT. - COL. EL SABINAL, TLAXCO, TLAXCALA";
            string serie = "VF1FLADRACY419294";
            string motor = "C683198";
            int modelo = 2023;
            string marca = "RENAULT TRAFIC";
            string tipo = "PANEL";
            string ruta = "INFORNAVIT PETROQUIMICA.TLAX DE XICOHTENCATL-PROCURADURIA GRAL DE JUSTICIA PI (GRAN PATIO, SAN PABLO APETATITLAN, CAMINO REAL, GARITA, MERCADO, CENTRAL CAMNIONERA, SOBRE LIBRIAMIENTO INSTITUTO POLITECNICO NACIONAL, TEPEHITEC).";
            string rfc = "TUX920811PQ7";
            string clvVehicular = "1982432";
            string ofcExp = "SAN PABLO APETATITLAN";
            string tipoServ = "SERV.PUB.LOCAL CON ITINERARIO FIJO";
            string vehOrig = "NACIONAL";
            string tramite = "";
            string noConcecion = "P/213/23";
            string cilindros = "4 CIL";
            string combustible = "GASOLINA";
            string toneladas = "";
            int personas = 17;
            string uso = "COLECTIVO";
            int diasPermiso = 90;
            string director = "LIC. JOSE ANTONIO CARAMILLO SANCHEZ";
            int nOficio = 1570;
            /*
             * FUENTES
             * 
             */
            BaseFont basefuente = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
            iTextSharp.text.Font fnormal = new iTextSharp.text.Font(basefuente, 10f);
            iTextSharp.text.Font fnormal_media = new iTextSharp.text.Font(basefuente, 9f);
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

            PdfWriter.GetInstance(doc, new FileStream("PermisoSinTC.pdf", FileMode.Create));
            doc.AddAuthor("SecretariaMovilidadyTransporte");
            doc.AddTitle("Documento Permiso sin TC");

            doc.SetMargins(30f, 30f, 30f, 30f);

            doc.Open();
            logo2.ScalePercent(25f);
            logo1.ScalePercent(25f);

            var tabla1 = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
            var t1cel1 = new PdfPCell(logo2) { MinimumHeight = 50f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            var t1cel2 = new PdfPCell(new Paragraph($"DT/DST/{nOficio}/{year}", fnormal)) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0 };
            var t1cel3 = new PdfPCell(new Paragraph($"A TODAS LAS AUTORIDADES FEDERALES", fnormal)) { Border = 0, MinimumHeight = 20f };

            tabla1.AddCell(t1cel1);
            tabla1.AddCell(t1cel2);
            tabla1.AddCell(t1cel3);
            doc.Add(tabla1);

            doc.Add(new Paragraph("ESTATALES, MUNICIPALES Y CIVILES.\nPRESENTES.", fnegrita));
            doc.Add(new Paragraph("\nSIRVA LA PRESENTE PARA OTORGAR EL PERMISO PARA CIRCULAR SIN TARJETA DE CIRCULACION AL VEHICULO DE TRANSPORTE PÚBLICO CON LOS SIGUIENTES DATOS:", fnormal));

            doc.Add(Chunk.NEWLINE);
            var tabla2 = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
            var txtpropietario = new Paragraph
            {
                new Chunk("Propietario: ", fnegrita),
                new Chunk($"{nombre}", fnormal)
            };
            var t2cel1 = new PdfPCell(new Paragraph(txtpropietario)) { VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = 20f };
            var txtdomicilio = new Paragraph
            {
                new Chunk("Domicilio: ",fnegrita),
                new Chunk($"{direccion}",fnormal)
            };
            var t2cel2 = new PdfPCell(new Paragraph(txtdomicilio)) { VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = 20f };
            tabla2.AddCell(t2cel1);
            tabla2.AddCell(t2cel2);
            doc.Add(tabla2);

            var tabla3 = new PdfPTable(new float[] { 60f, 40f }) { WidthPercentage = 100 };
            var txtserire = new Paragraph
            {
                new Chunk("No. Serie: ",fnegrita),
                new Chunk($"{serie}",fnormal)
            };
            var t3cel1 = new PdfPCell(new Paragraph(txtserire)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            var txtrfc = new Paragraph
            {
                new Chunk("RFC: ",fnegrita),
                new Chunk($"{rfc}",fnormal)
            };
            var t3cel2 = new PdfPCell(new Paragraph(txtrfc)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            tabla3.AddCell(t3cel1);
            tabla3.AddCell(t3cel2);

            var txtmotor = new Paragraph
            {
                new Chunk("No. Motor: ",fnegrita),
                new Chunk($"{motor}",fnormal)
            };
            var t3cel3 = new PdfPCell(new Paragraph(txtmotor)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            var txtplacas = new Paragraph
            {
                new Chunk("Placas: ", fnegrita),
                new Chunk($"{placa}", fnormal)
            };
            var t3cel4 = new PdfPCell(new Paragraph(txtplacas)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            tabla3.AddCell(t3cel3);
            tabla3.AddCell(t3cel4);

            doc.Add(tabla3);

            var tabla4 = new PdfPTable(new float[] { 30f, 30f, 40f }) { WidthPercentage = 100 };
            var txtmodelo = new Paragraph
            {
                new Chunk($"MODELO: ", fnegrita),
                new Chunk($"{modelo}", fnormal)
            };
            var t4cel1 = new PdfPCell(new Paragraph(txtmodelo)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            var txtmarca = new Paragraph
            {
                new Chunk($"MARCA: ", fnegrita),
                new Chunk($"{marca}", fnormal)
            };
            var t4cel2 = new PdfPCell(new Paragraph(txtmarca)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            var txtnoconcesion = new Paragraph
            {
                new Chunk($"No. Concesion: ", fnegrita),
                new Chunk($"{marca}", fnormal)
            };
            var t4cel3 = new PdfPCell(new Paragraph(txtnoconcesion)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };

            tabla4.AddCell(t4cel1);
            tabla4.AddCell(t4cel2);
            tabla4.AddCell(t4cel3);
            var txtclv = new Paragraph
            {
                new Chunk("Clave Vehicular: ", fnegrita),
                new Chunk($"{clvVehicular}", fnormal)
            };
            var t4cel4 = new PdfPCell(new Paragraph(txtclv)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            var txtcombustilble = new Paragraph
            {
                new Chunk("Combustible: ", fnegrita),
                new Chunk($"{combustible}", fnormal)
            };
            var t4cel5 = new PdfPCell(new Paragraph(txtcombustilble)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            var txtuso = new Paragraph
            {
                new Chunk("Uso: ", fnegrita),
                new Chunk($"{uso}", fnormal)
            };
            var t4cel6 = new PdfPCell(new Paragraph(txtuso)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            tabla4.AddCell(t4cel4);
            tabla4.AddCell(t4cel5);
            tabla4.AddCell(t4cel6);
            var txttoneladas = new Paragraph
            {
                new Chunk("Toneladas: ", fnegrita),
                new Chunk($"{toneladas}", fnormal)
            };
            var t4cel7 = new PdfPCell(new Paragraph(txttoneladas)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            var txtnPersonas = new Paragraph
            {
                new Chunk("No. Personas: ", fnegrita),
                new Chunk($"{personas}", fnormal)
            };
            var t4cel8 = new PdfPCell(new Paragraph(txtnPersonas)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            var txtcilindros = new Paragraph
            {
                new Chunk("Cilindros: ", fnegrita),
                new Chunk($"{cilindros}", fnormal)
            };
            var t4cel9 = new PdfPCell(new Paragraph(txtcilindros)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            tabla4.AddCell(t4cel7);
            tabla4.AddCell(t4cel8);
            tabla4.AddCell(t4cel9);
            doc.Add(tabla4);

            var tabla5 = new PdfPTable(new float[] { 60f, 40f }) { WidthPercentage = 100 };
            var txtservicio = new Paragraph
            {
                new Chunk("Servicio: ", fnegrita),
                new Chunk($"{tipoServ}",fnormal)
            };
            var t5cel1 = new PdfPCell(new Paragraph(txtservicio)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            var txttipo = new Paragraph
            {
                new Chunk("Tipo: ", fnegrita),
                new Chunk($"{tipo}", fnormal)
            };
            var t5cel2 = new PdfPCell(new Paragraph(txttipo)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };

            tabla5.AddCell(t5cel1);
            tabla5.AddCell(t5cel2);
            doc.Add(tabla5);

            var tabla6 = new PdfPTable(new float[] { 30f, 30f, 40f }) { WidthPercentage = 100 };
            var txtoficina = new Paragraph
            {
                new Chunk("Oficina Expendedora: ", fnegrita),
                new Chunk($"{ofcExp}",fnormal)
            };
            var txtorigen = new Paragraph
            {
                new Chunk("Vehículo Origen: ", fnegrita),
                new Chunk($"{vehOrig}", fnormal)
            };
            var txttramite = new Paragraph
            {
                new Chunk("Trámite: ", fnegrita),
                new Chunk($"{tramite}", fnormal)
            };
            var t6cel1 = new PdfPCell(new Paragraph(txtoficina)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            var t6cel2 = new PdfPCell(new Paragraph(txtorigen)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            var t6cel3 = new PdfPCell(new Paragraph(txttramite)) { MinimumHeight = 20f, VerticalAlignment = Element.ALIGN_MIDDLE };
            tabla6.AddCell(t6cel1);
            tabla6.AddCell(t6cel2);
            tabla6.AddCell(t6cel3);
            doc.Add(tabla6);

            var tablaruta = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100f };
            var txtruta = new Paragraph
            {
                new Chunk("Ruta:", fnegrita),
                new Chunk($"{ruta}", fnormal)
            };
            var trcel1 = new PdfPCell(new Paragraph(txtruta)) { MinimumHeight = 50f, VerticalAlignment = Element.ALIGN_MIDDLE };
            tablaruta.AddCell(trcel1);
            doc.Add(tablaruta);

            doc.Add(new Paragraph($"POR ENCONTRARSE EN TRÁMITE LA TARJETA DE CIRCULACIÓN EN ESTA SECRETARÍA, RAZÓN POR LA QUE SE EXTIENDE EL PRESENTE PARA PODER CIRCULAR POR UN PLAZO DE {diasPermiso} DÍAS A PARTIR DE LA EXPEDICIÓN DE ESTE DOCUMENTO.", fnormal_media) { Alignment = Element.ALIGN_JUSTIFIED });
            doc.Add(new Paragraph($"LO ANTERIOR CON FUNDAMENTO EN EL ART. 7 DE LA LEY DE COMUNICACIONES Y TRANSPORTES, 10 Y 15 FRACCIONES X, XII Y XX, DEL REGLAMENTO INTERIOR DE LA SECRETARÍA DE MOVILIDAD Y TRANSPORTE Y DEMÁS RELATIVOS Y APLICABLES DEL REGLAMENTO DE LA LEY DE COMUNICACIONES Y TRANSPORTES EN EL ESTADO DE TLAXCALA EN MATERIA DE TRANSPORTE PÚBLICO Y PRIVADO.\nAGRADEZCO LA ATENCIÓN BRINDA AL PORTADOR DEL PRESENTE.", fnormal_media) { Alignment = Element.ALIGN_JUSTIFIED });

            doc.Add(new Paragraph($"\n\nATENTAMENTE APETATITLÁN, TLAX., {dia} DE {mes.ToUpper()} {year}", fnormal_media) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph($"DIRECTOR DE TRANSPORTE DE S.M.Y.T.", fnormal_media) { Alignment = Element.ALIGN_CENTER });
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph($"{director}", fnegrita) { Alignment = Element.ALIGN_CENTER });
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            var fotoer = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100 };
            var txtfo = new Paragraph
            {
                new Chunk("Hidalgo 17, Apetatitlán de Antonio Carbajal\n", fnormal_mini),
                new Chunk("Tlaxcala, CP 90600\n", fnormal_mini),
                new Chunk("Teléfono 246 46 52 960 extensión 3304, 3305\n", fnormal_mini),
            };
            var fcel1 = new PdfPCell(new Paragraph(txtfo)) { HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_MIDDLE, Border = 0, MinimumHeight = 30f };
            fotoer.AddCell(fcel1);
            var fcel2 = new PdfPCell(logo1) { HorizontalAlignment = Element.ALIGN_MIDDLE, VerticalAlignment = Element.ALIGN_BOTTOM, Border = 0 };
            fotoer.AddCell(fcel2);
            doc.Add(fotoer);

            doc.Close();
        }
    }
}
