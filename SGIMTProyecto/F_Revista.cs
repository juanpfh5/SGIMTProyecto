using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using System.Globalization;

namespace SGIMTProyecto
{
    public partial class F_Revista : Form
    {
        public F_Revista()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region Métodos
        private void Rev(string cTexto)
        {
            D_Revista Datos = new D_Revista();
            MostrarDatos(Datos.Rev(cTexto));
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

        private static object generarPDF (string placa, string nombre, string direccion, string serie, string motor, int modelo, string marca, string tipo, string pasajeros, string concecion, string resolucion, string docUnidad, string ruta, string condicionesR, string espejos, string llantas, string limpiadores, string llantaAux, string vestiduras, string luces, string defensas, string direccionales, string pinturaG, string cristales, string rotulacion, string observaciones)
        {
            DateTime today = DateTime.Today;
            //variables dentro de la funcion:
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            int dia = today.Day;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);
            int year = DateTime.Today.Year;
            var documento =
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Header().Row(fila =>
                    {
                        fila.RelativeItem().Height(150);
                    });
                    page.Content().Column(col =>
                    {
                        col.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(table =>
                            {
                                table.ConstantColumn(70);
                                table.RelativeColumn();
                            });
                            tabla.Cell().Text("NOMBRE:");
                            tabla.Cell().Text($"{nombre}");
                            tabla.Cell().Text("DOMICILIO:");
                            tabla.Cell().Text($"{direccion}");
                        });
                        col.Item().Text("");
                        col.Item().Text("");
                        col.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(table =>
                            {
                                table.ConstantColumn(70);
                                table.RelativeColumn();
                                table.ConstantColumn(70);
                                table.RelativeColumn();
                                table.ConstantColumn(70);
                                table.RelativeColumn();
                            });
                            tabla.Cell().Text("PLACAS:");
                            tabla.Cell().Text($"{placa}");
                            tabla.Cell().Text("No.SERIE:");
                            tabla.Cell().Text($"{serie}").FontSize(9);
                            tabla.Cell().Text("TIPO:");
                            tabla.Cell().Text($"{tipo}");
                            tabla.Cell().Text("No.Motor:");
                            tabla.Cell().AlignBottom().Text($"  {motor}").FontSize(9);
                            tabla.Cell().Text("   ");
                            tabla.Cell().AlignBottom().Text($"    {modelo}").FontSize(9);
                            tabla.Cell().Text("   ");
                            tabla.Cell().Text("   ");
                            tabla.Cell().Text("MARCA");
                            tabla.Cell().Text($"{marca}").FontSize(9);
                            tabla.Cell().Text("PASAJEROS");
                            tabla.Cell().AlignBottom().Text($"                  {pasajeros}").FontSize(9);
                        });
                        col.Item().Text("");
                        col.Item().Text("");
                        col.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(colm =>
                            {
                                colm.RelativeColumn();
                            });
                            tabla.Cell().Text(texto =>
                            {
                                texto.Span("                                  ");
                                texto.Span($"{concecion}");
                            });
                            tabla.Cell().Text(texto =>
                            {
                                texto.Span("                             ");
                                texto.Span($"{resolucion}");
                            });
                            tabla.Cell().Text(texto =>
                            {
                                texto.Span("                             ");
                                texto.Span($"");
                            });
                            tabla.Cell().Text(texto =>
                            {
                                texto.Span("                                                                    ");
                                texto.Span($"{docUnidad}");
                            });
                            tabla.Cell().Text(texto =>
                            {
                                texto.Span("                             ");
                                texto.Span($"{ruta}");
                            });

                        });
                        col.Item().PaddingVertical(30);
                        col.Item().Row(row =>
                        {
                            row.Spacing(20);
                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{condicionesR}");

                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{espejos}");
                        });
                        col.Item().Row(row =>
                        {
                            row.Spacing(20);
                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{llantas}");

                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{limpiadores}");
                        });
                        col.Item().Row(row =>
                        {
                            row.Spacing(20);
                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{llantaAux}");

                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{vestiduras}");
                        });
                        col.Item().Row(row =>
                        {
                            row.Spacing(20);
                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{luces}");

                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{defensas}");
                        });
                        col.Item().Row(row =>
                        {
                            row.Spacing(20);
                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{direccionales}");

                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{pinturaG}");
                        });
                        col.Item().Row(row =>
                        {
                            row.Spacing(20);
                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{cristales}");

                            row.RelativeItem(5).Text("");
                            row.RelativeItem(5).Text($"{rotulacion}");
                        });
                        col.Item().PaddingTop(30);
                        col.Item().Text($"                                  {observaciones}");
                        col.Item().PaddingTop(60);
                        //col.Item().AlignCenter().Text("NOTA:EN CASO DE INCUMPLIMIENTO DE LAS OBSERVACIONES HECHAS, EL PROPIETARIO SE HARÁ ACREEDOR A LAS\nSANCIONES CORRESPONDIENTES, DE ACUERDO A LA LEY DE LA SMyT Y SU REGLAMENTO").FontSize(9);
                        col.Item().PaddingTop(25);
                        col.Item().AlignCenter().Text($"                   {dia}                              {mes.ToUpper()}                                 {year}").FontSize(9);
                    });

                });
            }).GeneratePdf();


            return documento;

        }
    }
}
