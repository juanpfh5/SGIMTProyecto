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

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using System.Globalization;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SGIMTProyecto
{
    public partial class F_TarjetaCirculacion : Form
    {
        public F_TarjetaCirculacion()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
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
        private static object GenerarPDF(string placa, string nombre, string direccion, string serie, string motor, int modelo, string marca, string tipo, string ruta, string rfc, string vehiculo, string clvVehicular, string ofcExp, string tipoServ, string vehOrig, string tramite, string fechaExp, string vigencia, string noConcecion, string cilindros, string combustible, string repuve, string capacidad, string toneladas, int personas, string uso, string secretario)
        {
            var documento = Document.Create(contenedor =>
            {
                contenedor.Page(pagina =>
                {
                    pagina.Margin(30);

                    //pagina.Header();
                    pagina.Content().Row(row =>
                    {

                        row.RelativeItem(2).Column(col =>
                        {
                            col.Item().PaddingVertical(60);
                            col.Item().Text($"{nombre}").FontSize(8);
                            col.Item().AlignRight().Text($"{rfc}").FontSize(8);
                            col.Item().Text("");
                            col.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(tabladef =>
                                {
                                    tabladef.RelativeColumn();
                                    tabladef.RelativeColumn();
                                });
                                tabla.Cell().Text($"{vehiculo}").FontSize(8);
                                tabla.Cell().Text($"{marca}").FontSize(8);
                            });
                            col.Item().Text("");
                            col.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(tabladef =>
                                {
                                    tabladef.RelativeColumn();
                                    tabladef.RelativeColumn();
                                    tabladef.RelativeColumn();
                                });
                                tabla.Cell().Text($"{modelo}").FontSize(8);
                                tabla.Cell().Text($"{tipo}").FontSize(8);
                                tabla.Cell().Text($"{clvVehicular}").FontSize(8);
                            });
                            col.Item().Text("");
                            col.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(tabladef =>
                                {
                                    tabladef.RelativeColumn();
                                    tabladef.RelativeColumn();
                                });
                                col.Item().PaddingVertical(3.5f);
                                tabla.Cell().Text($"{ofcExp}").FontSize(7);
                                tabla.Cell().Text($"{tipoServ}").FontSize(7);
                            });
                            col.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(tabladef =>
                                {
                                    tabladef.RelativeColumn();
                                    tabladef.RelativeColumn();
                                });
                                col.Item().PaddingVertical(2.5f);
                                tabla.Cell().Text($"{vehOrig}").FontSize(8);
                                tabla.Cell().Text($"{tramite}").FontSize(8);
                            });
                            col.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(tabladef =>
                                {
                                    tabladef.RelativeColumn();
                                    tabladef.RelativeColumn();
                                });
                                tabla.Cell().Text($"{fechaExp}").FontSize(8);
                                tabla.Cell().Text($"{vigencia}").FontSize(8);
                            });
                            col.Item().PaddingVertical(3.5f);
                            col.Item().AlignCenter().Text($"{noConcecion}").FontSize(9);
                            col.Item().PaddingVertical(7.5f);

                        });

                        row.RelativeItem(2).Column(col2 =>
                        {
                            col2.Item().PaddingVertical(60);
                            col2.Item().AlignCenter().Text($"{serie}").FontSize(10);
                            col2.Item().AlignCenter().Text($"{motor}").FontSize(10);
                            col2.Item().PaddingVertical(5.5f);//espacio
                            col2.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(tab =>
                                {
                                    tab.RelativeColumn();
                                    tab.RelativeColumn();
                                });
                                tabla.Cell().AlignCenter().Text($"{cilindros}").FontSize(8);
                                tabla.Cell().AlignCenter().Text($"{combustible}").FontSize(8);
                            });
                            col2.Item().PaddingVertical(9.5f);//espacio
                            col2.Item().AlignCenter().AlignBottom().Text($"{repuve}").FontSize(8);
                            col2.Item().PaddingVertical(9.5f);//espacio
                            col2.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(tabl =>
                                {
                                    tabl.RelativeColumn();
                                    tabl.RelativeColumn();
                                    tabl.RelativeColumn();
                                });
                                tabla.Cell().AlignCenter().Text($"{capacidad}").FontSize(8);
                                tabla.Cell().AlignCenter().Text($"{toneladas}").FontSize(8);
                                tabla.Cell().AlignCenter().Text($"{personas}").FontSize(8);
                            });
                            col2.Item().PaddingVertical(6.0f);//espacio
                            col2.Item().AlignCenter().Text($"{uso}").FontSize(8);
                            col2.Item().PaddingVertical(10.5f);//espacio
                            col2.Item().AlignCenter().Text($"{placa}").FontSize(14).Bold();

                        });

                        row.RelativeItem(2);
                        row.RelativeColumn(1);
                    });
                    pagina.Footer().Column(col =>
                    {

                        col.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(deff =>
                            {
                                deff.ConstantColumn(300);
                                deff.RelativeColumn();
                            });
                            tabla.Cell().Text($"{direccion}").FontSize(7);
                            tabla.Cell().Text($"");
                            tabla.Cell().Height(90).Text($"{ruta}").FontSize(7);
                            tabla.Cell().Text($"");
                            tabla.Cell().AlignRight().Text($"{secretario}           \nSECRETARIO DE MOVILIDAD Y TRANSPORTE").FontSize(7);

                        });


                        col.Item().PaddingBottom(345);
                    });

                });

            }).GeneratePdf();

            return documento;
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
        private static object GenerarProvisionalPDF(string placa, string nombre, string direccion, string serie, string motor, int modelo, string marca, string tipo, string ruta, string rfc, string clvVehicular, string ofcExp, string tipoServ, string vehOrig, string tramite, string noConcecion, string cilindros, string combustible, string toneladas, int personas, string uso, int diasPermiso, string director, int nOficio)
        {
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            DateTime today = DateTime.Today;
            int year = today.Year;
            int dia = today.Day;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);
            var documento =
            Document.Create(contenedor =>
            {
                contenedor.Page(pagina =>
                {
                    pagina.Margin(30);

                    pagina.Header().Row(fila =>
                    {

                        fila.RelativeItem().Text("");

                        fila.ConstantItem(120).Column(col =>
                        {

                            col.Item().Image("C:\\Users\\aleja\\OneDrive\\Documentos\\UATx\\PorgEvolutiva\\ConsolaOrdenCobroPDF\\Resources\\tlaxcala_nuevahistoria_black.png");
                        });
                        fila.RelativeItem().Text("");
                    });
                    pagina.Content().Column(col =>
                    {
                        col.Item().AlignRight().Text($"DT/DST/{nOficio}/{year}").FontSize(10);
                        col.Item().PaddingTop(25);
                        col.Item().Text($"A TODAS LAS AUTORIDADES FEDERALES").FontSize(10);
                        col.Item().Text($"ESTATALES, MUNICIPALES Y CIVILES.").FontSize(10).Bold();
                        col.Item().Text($"PRESENTES.").FontSize(10).Bold();
                        col.Item().Text($"").FontSize(10).Bold();
                        col.Item().Text($"SIRVA EL PRESENTE PARA OTORGAR EL PERMISO PARA CIRCULAR SIN TARJETA DE CIRCULACIÓN AL VEHÍCULO DE TRANSPORTE PÚBLICO CON LOS SIGUIENTES DATOS:\n").FontSize(11);
                        col.Item().Border(1).Text(texto =>
                        {
                            texto.Span(" Propietario: ").FontSize(10);
                            texto.Span($"{nombre}").FontSize(10);
                        });
                        col.Item().Border(1).Text(texto =>
                        {
                            texto.Span(" Domicilio: ").FontSize(10);
                            texto.Span($"{direccion}").FontSize(10);
                        });
                        col.Item().Row(row =>
                        {
                            row.RelativeItem(2).Border(1).Text($" No.de Serie: {serie}").FontSize(10);
                            row.RelativeItem().Border(1).Text($" RFC:{rfc}").FontSize(10);
                        });
                        col.Item().Row(row =>
                        {
                            row.RelativeItem(2).Border(1).Text($" No.de Motor: {motor}").FontSize(10);
                            row.RelativeItem().Border(1).Text($" Placas:{placa}").FontSize(10);
                        });
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Border(1).Text($" Modelo: {modelo}").FontSize(10);
                            row.RelativeItem().Border(1).Text($" Marca: {marca}").FontSize(10);
                            row.RelativeItem().Border(1).Text($" No. Concesión: {noConcecion}").FontSize(10);
                        });
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Border(1).Text($" Clave vehicular: {clvVehicular}").FontSize(10);
                            row.RelativeItem().Border(1).Text($" Combustible: {combustible}").FontSize(10);
                            row.RelativeItem().Border(1).Text($" Uso: {uso}").FontSize(10);
                        });
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Border(1).Text($" Toneladas: {toneladas}").FontSize(10);
                            row.RelativeItem().Border(1).Text($" No. de Personas: {personas}").FontSize(10);
                            row.RelativeItem().Border(1).Text($" Cilindros: {cilindros}").FontSize(10);
                        });
                        col.Item().Row(row =>
                        {
                            row.RelativeItem(2).Border(1).Text($" Servicio: {tipoServ}").FontSize(10);
                            row.RelativeItem().Border(1).Text($" Tipo: {tipo}").FontSize(10);
                        });
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Border(1).Text($" Oficina expendedora: {ofcExp}").FontSize(8);
                            row.RelativeItem().Border(1).Text($" Vehiculo de Origen: {vehOrig}").FontSize(8);
                            row.RelativeItem().Border(1).Text($" Tramite: {tramite}").FontSize(8);
                        });
                        col.Item().Row(row =>
                        {
                            row.RelativeItem(2).Border(1).Text($" Ruta: {ruta}").FontSize(10);

                        });
                        col.Item().PaddingTop(10);
                        col.Item().Text($"POR ENCONTRARSE EN TRÁMITE LA TARJETA DE CIRCULACIÓN EN ESTA SECRETARÍA, RAZÓN POR LA QUE SE LE EXTIENDE EL PRESENTE PARA PODER CIRCULAR POR UN PLAZO DE {diasPermiso} DIAS A PARTIR DE LA EXPEDICIÓN DE ESTE DOCUMENTO.").FontSize(11);
                        col.Item().PaddingTop(10);
                        col.Item().Text($"LO ANTERIOR CON FUNDAMENTO EN EL ART. 7 DE LA LEY DE COMUNICACIONES Y TRANSPORTES, 10 Y 15 FRACCIONES X, XIII Y XX, DEL REGLAMENTO INTERIOR DE LA SECRETARÍA DE MOVILIDAD Y TRANSPORTE Y DEMÁS RELATIVOS Y APLICABLES DEL REGLAMENTO DE LA LEY DE COMUNICACIONES Y TRANSPORTES EN EL ESTADO DE TLAXCALA EN MATERIA DE TRANSPORTE PÚBLICO Y PRIVADO.").FontSize(11);
                        col.Item().PaddingTop(10);
                        col.Item().Text("AGRADEZCO LA ATENCIÓN BRINDADA AL PORTADOR DEL PRESENTE.").FontSize(11);
                        col.Item().PaddingTop(55);
                        col.Item().AlignCenter().Text($"ATENTAMENTE APETATITLÁN, TLAX., {dia} DE {mes.ToUpper()} {year}").FontSize(11);
                        col.Item().PaddingTop(15);
                        col.Item().AlignCenter().Text($"DIRECTOR DE TRANSPORTES DE S.M.Y.T").FontSize(11);
                        col.Item().PaddingTop(55);
                        col.Item().AlignCenter().Text($"{director}").FontSize(11);


                    });
                    pagina.Footer().Row(row =>
                    {
                        row.ConstantItem(150).Column(col =>
                        {
                            col.Item().Text("").FontSize(7);
                            col.Item().Text("Hidalgo 17, Apetatitlán de Antonio Carbajal").FontSize(7);
                            col.Item().Text("Tlaxcala C.P. 90600").FontSize(7);
                            col.Item().Text("Teléfono 246 46 52 960 extensión 3304, 3305").FontSize(7);
                        });
                        row.RelativeItem();
                        row.ConstantItem(100).Column(col =>
                        {
                            col.Item().AlignLeft().Image("C:\\Users\\aleja\\OneDrive\\Documentos\\UATx\\PorgEvolutiva\\ConsolaOrdenCobroPDF\\Resources\\logosmyt_1920_black.png");
                        });
                    });
                });

            }).GeneratePdf();

            return documento;
        }
    }
}
