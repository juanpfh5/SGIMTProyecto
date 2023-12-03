using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//librerias para la creacion de pdf
using QuestPDF.Fluent;
using System.Globalization;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using System.Security.Cryptography;
using HarfBuzzSharp;
using static QuestPDF.Helpers.Colors;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading;

namespace SGIMTProyecto
{
    public partial class F_OrdenCobro : UserControl
    {
        public F_OrdenCobro()
        {
            InitializeComponent();
        }

        #region Métodos
        private void OrdenC(string cTexto)
        {
            D_OrdenCobro Datos = new D_OrdenCobro();
            MostrarDatos(Datos.OrdenC(cTexto));
        }

        private void LimpiarTextBox() {
            TXT_Nombre.Text = "";
            TXT_PlacaActual.Text = "";
            TXT_Domicilio.Text = "";
            TXT_CP.Text = "";
            TXT_NoSerie.Text = "";
            TXT_NoMotor.Text = "";
            TXT_Modelo.Text = "";
            TXT_Marca.Text = "";
            TXT_ClaveVehicular.Text = "";
            TXT_Tipo.Text = "";
            TXT_Combustible.Text = "";
            TXT_NoPasajeros.Text = "";
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
                if (primeraFila.Length > 1) TXT_PlacaActual.Text = primeraFila[1];
                if (primeraFila.Length > 2) TXT_Domicilio.Text = primeraFila[2];
                if (primeraFila.Length > 3) TXT_CP.Text = primeraFila[3];
                if (primeraFila.Length > 4) TXT_NoSerie.Text = primeraFila[4];
                if (primeraFila.Length > 5) TXT_NoMotor.Text = primeraFila[5];
                if (primeraFila.Length > 6) TXT_Modelo.Text = primeraFila[6];
                if (primeraFila.Length > 7) TXT_Marca.Text = primeraFila[7];
                if (primeraFila.Length > 8) TXT_ClaveVehicular.Text = primeraFila[8];
                if (primeraFila.Length > 9) TXT_Tipo.Text = primeraFila[9];
                if (primeraFila.Length > 10) TXT_Combustible.Text = primeraFila[10];
                if (primeraFila.Length > 11) TXT_NoPasajeros.Text = primeraFila[11];
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
            if (TXT_PlacaActual.Text.Trim().Length != 9) {
                variable = JLB_PlacaActual.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Domicilio.Text.Trim().Length > 150 || (TXT_Domicilio.Text.Trim().Length < 1)) {
                variable = JLB_Domicilio.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_NuevaPlaca.Text.Trim().Length != 9) {
                variable = JLB_NuevaPlaca.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_CP.Text.Trim().Length != 5 || !int.TryParse(TXT_CP.Text.Trim(), out int cp)) {
                variable = JLB_CP.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_FolioRevista.Text.Trim(), out int folioRevista)) {
                variable = JLB_FolioRevista.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_NoSerie.Text.Trim().Length > 17 || (TXT_NoSerie.Text.Trim().Length < 1)) {
                variable = JLB_NoSerie.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_NoMotor.Text.Trim(), out int noMotor)) {
                variable = JLB_NoMotor.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_Modelo.Text.Trim(), out int modelo)) {
                variable = JLB_Modelo.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Marca.Text.Trim().Length > 15 || (TXT_Marca.Text.Trim().Length < 1)) {
                variable = JLB_Marca.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_ClaveVehicular.Text.Trim().Length > 7 || (TXT_ClaveVehicular.Text.Trim().Length < 1)) {
                variable = JLB_ClaveVehicular.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Tipo.Text.Trim().Length > 15 || (TXT_Tipo.Text.Trim().Length < 1)) {
                variable = JLB_Tipo.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Combustible.Text.Trim().Length > 15 || (TXT_Combustible.Text.Trim().Length < 1)) {
                variable = JLB_Combustible.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_NoPasajeros.Text.Trim(), out int noPasajeros)) {
                variable = JLB_NoPasajeros.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Observaciones.Text.Trim().Length > 100) {
                variable = JLB_Observaciones.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (!int.TryParse(TXT_NoMovimiento.Text.Trim(), out int noMovimiento)) {
                variable = JLB_NoMovimiento.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (DGV_Clave.Rows.Count  < 1) {
                variable = JLB_Clave.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            //ObtenerInformacionDataGridView();

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

        private DataTable ExtraerDatosDataGridView(DataGridView dataGridView) {
            DataTable dataTable = new DataTable();

            // Agrega columnas al DataTable
            foreach (DataGridViewColumn column in dataGridView.Columns) {
                dataTable.Columns.Add(column.Name);
            }

            // Agrega filas al DataTable
            foreach (DataGridViewRow row in dataGridView.Rows) {
                if (!row.IsNewRow) {
                    DataRow dataRow = dataTable.NewRow();

                    foreach (DataGridViewCell cell in row.Cells) {
                        dataRow[cell.ColumnIndex] = cell.Value;
                    }

                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }

        private void ObtenerInformacionDataGridView() {
            DataTable datosExtraidos = ExtraerDatosDataGridView(DGV_Clave);
            String mensaje = "";
            // Ahora puedes trabajar con el DataTable 'datosExtraidos'.
            // Puedes mostrarlo en un MessageBox, guardarlo en una base de datos, etc.
            foreach (DataRow row in datosExtraidos.Rows) {
                foreach (DataColumn col in datosExtraidos.Columns) {
                    mensaje = row[col] + "\t";
                }
                mensaje = "\t";
            }
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ExistenciaVehiculo(string cTexto) {
            D_EditarPropietario Datos = new D_EditarPropietario();
            return Datos.ExistenciaVehiculo(cTexto);
        }

        private List<string> ListadoPersonal() {
            D_OrdenCobro Datos = new D_OrdenCobro();
            return Datos.ListadoPersonal();
        }

        private List<string> ListadoClaveConcepto(string busqueda) {
            D_OrdenCobro Datos = new D_OrdenCobro();
            return Datos.ListadoClaveConcepto(busqueda);
        }

        private List<string> AgregarClave(string concepto) {
            D_OrdenCobro Datos = new D_OrdenCobro();
            return Datos.AgregarClave(concepto);
        }

        private void AutoCompleteClave() {
            AutoCompleteStringCollection colClaveConcepto = new AutoCompleteStringCollection();
            List<string> claveConcepto = ListadoClaveConcepto(TXT_Clave.Text);
            foreach (string clc in claveConcepto) {
                colClaveConcepto.Add(clc);
            }
            TXT_Clave.AutoCompleteCustomSource = colClaveConcepto;
            TXT_Clave.AutoCompleteMode = AutoCompleteMode.Suggest;
            TXT_Clave.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Manejar el evento TextChanged para deshabilitar el TextBox al seleccionar una opción
            TXT_Clave.TextChanged += (sender, e) => {
                string textoIngresado = TXT_Clave.Text;
                if (colClaveConcepto.Contains(textoIngresado)) {
                    // La opción seleccionada está en la colección de autocompletado, deshabilitar el TextBox
                    TXT_Clave.Enabled = false;
                }
            };
        }

        private string TruncarTextBox(string textBox) {
            string concepto = "";
            if (textBox.Length > 7) {
                concepto = textBox.Substring(7);
            } else {
                concepto = string.Empty;
            }
            return concepto;
        }
        #endregion

        private void BTN_BuscarPlaca_Click(object sender, EventArgs e)
        {
            if (!TXT_Placa.Text.Trim().Equals("Placa")) {
                this.OrdenC(TXT_Placa.Text.Trim());
                TXT_Nombre.Enabled = false;
                TXT_PlacaActual.Enabled = false;
                TXT_Domicilio.Enabled = false;
                TXT_CP.Enabled = false;
                TXT_NoSerie.Enabled = false;
                TXT_NoMotor.Enabled = false;
                TXT_Modelo.Enabled = false;
                TXT_Marca.Enabled = false;
                TXT_ClaveVehicular.Enabled = false;
                TXT_Tipo.Enabled = false;
                TXT_Combustible.Enabled = false;
                TXT_NoPasajeros.Enabled = false;
            }
        }

        private void BTN_Imprimir_Click(object sender, EventArgs e) {
            if (!TXT_Placa.Text.Trim().Equals("Placa")){
                (string mensajeError, bool bandera) = VerificacionParametros();

                if (bandera)
                {
                    MessageBox.Show(mensajeError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Generar pdf
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
                     * 
                     * string combustible
                     * string capacidad
                     * 
                     */
                    #endregion

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
        private void F_OrdenCobro_Load(object sender, EventArgs e) {
            CMB_Elaboro.DataSource = ListadoPersonal();
            AutoCompleteClave();
            DGV_Clave.ColumnCount = 5;
            DGV_Clave.Columns[0].Name = "Clave";
            DGV_Clave.Columns[1].Name = "Concepto";
            DGV_Clave.Columns[2].Name = "Costo Unitario";
            DGV_Clave.Columns[3].Name = "Cantidad";
            DGV_Clave.Columns[4].Name = "Costo";

            // DGV_Clave.Rows.Add(4410, "Pago Tarjeta", 502.5, 1);
            // DGV_Clave.Rows.Add(4410, "Pago Tarjeta", 502.5, 2);
            // DGV_Clave.Rows.Add(4410, "Pago Tarjeta", 502.5, 3);

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar Registro";
            btnEliminar.Name = "EliminarRegistro";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            DGV_Clave.Columns.Add(btnEliminar);
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

        private void BTN_Agregar_Click(object sender, EventArgs e) {
            List<string> concepto = AgregarClave(TruncarTextBox(TXT_Clave.Text));

            // Suponiendo que concepto tiene la estructura Clave, Concepto, Valor repetida
            for (int i = 0; i < concepto.Count; i += 3) {
                int index = DGV_Clave.Rows.Add(concepto[i], concepto[i + 1], concepto[i + 2]);
                ActualizarCosto(index);
            }

            BTN_LimpiarClave_Click(sender, e);
        }

        private void BTN_LimpiarClave_Click(object sender, EventArgs e) {
            TXT_Clave.Enabled = true;    
            TXT_Clave.Text = "";
        }

        private void DGV_Clave_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if(e.ColumnIndex == DGV_Clave.Columns["EliminarRegistro"].Index) {
                DGV_Clave.Rows.RemoveAt(e.RowIndex);
            }
        }

        private Dictionary<int, int> valores = new Dictionary<int, int>(); // Almacena los valores para cada fila

        private void DGV_Clave_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex == DGV_Clave.Columns["Cantidad"].Index) { // Ajusta el índice de la columna según sea necesario
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                // Obtener el valor actual para la fila
                int valorActual = valores.ContainsKey(e.RowIndex) ? valores[e.RowIndex] : 1;

                // Dibujar el primer botón
                var buttonRect1 = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 2, e.CellBounds.Width / 4 - 5, e.CellBounds.Height - 4);
                ControlPaint.DrawButton(e.Graphics, buttonRect1, ButtonState.Normal);

                // Dibujar el número en medio de los dos botones
                var textRect = new Rectangle(e.CellBounds.X + e.CellBounds.Width / 4, e.CellBounds.Y, e.CellBounds.Width / 2, e.CellBounds.Height);
                TextRenderer.DrawText(e.Graphics, valorActual.ToString(), e.CellStyle.Font, textRect, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                // Dibujar el segundo botón
                var buttonRect2 = new Rectangle(e.CellBounds.X + e.CellBounds.Width * 3 / 4, e.CellBounds.Y + 2, e.CellBounds.Width / 4 - 5, e.CellBounds.Height - 4);
                ControlPaint.DrawButton(e.Graphics, buttonRect2, ButtonState.Normal);

                e.Handled = true;
            }
        }

        private void DGV_Clave_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex == DGV_Clave.Columns["Cantidad"].Index) {
                // Determinar si se hizo clic en el primer o segundo botón
                var clickPosition = DGV_Clave.PointToClient(Cursor.Position);
                var buttonRect1 = new Rectangle(DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).X + 5, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Y + 2, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Width / 4 - 5, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Height - 4);
                var buttonRect2 = new Rectangle(DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).X + DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Width * 3 / 4, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Y + 2, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Width / 4 - 5, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Height - 4);

                if (buttonRect1.Contains(clickPosition)) {
                    // Clic en el primer botón
                    if (valores.ContainsKey(e.RowIndex)) {
                        if (valores[e.RowIndex] < 5) {
                            valores[e.RowIndex]++;
                        }
                    } else {
                        valores.Add(e.RowIndex, 1);
                    }
                } else if (buttonRect2.Contains(clickPosition)) {
                    // Clic en el segundo botón
                    if (valores.ContainsKey(e.RowIndex)) {
                        if (valores[e.RowIndex] > 1) {
                            valores[e.RowIndex]--;
                        }
                    } else {
                        valores.Add(e.RowIndex, -1);
                    }
                }

                // Actualizar la visualización después de hacer clic
                DGV_Clave.InvalidateCell(e.ColumnIndex, e.RowIndex);

                // Actualizar el valor en la columna "Costo"
                ActualizarCosto(e.RowIndex);
            }
        }

        private void ActualizarCosto(int rowIndex) {
        // Obtener la cantidad y el costo unitario de la fila
            int cantidad = valores.ContainsKey(rowIndex) ? valores[rowIndex] : 1;

            // Asegurarse de que las celdas tengan valores numéricos
            if (decimal.TryParse(DGV_Clave.Rows[rowIndex].Cells[2].Value?.ToString(), out decimal costoUnitario)) {
                // Calcular el costo multiplicando cantidad por costo unitario
                decimal costo = cantidad * costoUnitario;

                // Actualizar el valor en la columna "Costo"
                DGV_Clave.Rows[rowIndex].Cells[4].Value = costo;
            }
        }

        #region funciones de PDF
        private static object GenerarPdf(string placa, string nombre, string direccion, int CP, int folioR, string serie, string motor, int modelo, string marca, string clvVehicular, string tipo, decimal total, string elaboro, List<int> claves, List<String> descripcion, List<decimal> importe, string mesVigencia, int diaVigencia, int yearVigencia, int nMovimiento, string combustible, string capacidad)
        {
            //obtenemos los valores del dia de hoy
            DateTime today = DateTime.Today;
            //variables dentro de la funcion:
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            int dia = today.Day;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);
            //creamos nuestro pdf
            var documentoPDF =
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
                            .Text("ORDEN DE COBRO DERECHOS")
                            .Bold()
                            .FontSize(10);
                            col.Item()
                            .AlignCenter()
                            .Text("VEHICULARES TRANSPORTE PUBLICO 2023")
                            .Bold()
                            .FontSize(10);
                        });
                        fila.ConstantItem(100).Image("C:\\Users\\aleja\\OneDrive\\Documentos\\UATx\\PorgEvolutiva\\ConsolaOrdenCobroPDF\\Resources\\tlaxcala_nuevahistoria_black.png");
                    });
                    page.Content().Column(col1 =>
                    {
                        col1.Item().Text($"Apetatitlán, Tlax a {dia} de {mes} 2023").Bold();
                        col1.Item().Text($"PLACA: {placa}");
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
