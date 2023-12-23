
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

using System.Security.Cryptography;
using HarfBuzzSharp;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading;
using SGIMTProyecto.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Syncfusion.XPS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;
using iTextSharp.text.pdf.qrcode;
using MySqlX.XDevAPI.Relational;

namespace SGIMTProyecto
{
    public partial class F_OrdenCobro : UserControl
    {
        private F_VisualizacionPDF formVisualizador;
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
                TXT_Nombre.Enabled = true;
                TXT_PlacaActual.Enabled = true;
                TXT_Domicilio.Enabled = true;
                TXT_CP.Enabled = true;
                TXT_NoSerie.Enabled = true;
                TXT_NoMotor.Enabled = true;
                TXT_Modelo.Enabled = true;
                TXT_Marca.Enabled = true;
                TXT_ClaveVehicular.Enabled = true;
                TXT_Tipo.Enabled = true;
                TXT_Combustible.Enabled = true;
                TXT_NoPasajeros.Enabled = true;
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
            if (TXT_PlacaActual.Text.Trim().Length != 7) {
                variable = JLB_PlacaActual.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            if (TXT_Domicilio.Text.Trim().Length > 150 || (TXT_Domicilio.Text.Trim().Length < 1)) {
                variable = JLB_Domicilio.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }
            /*if (TXT_NuevaPlaca.Text.Trim().Length != 9) {
                variable = JLB_NuevaPlaca.Text;
                parametros.Add(variable.Substring(0, variable.Length - 1));
                bandera = true;
            }*/
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

        private string ObtenerDirector() {
            D_OrdenCobro Datos = new D_OrdenCobro();
            return Datos.ObtenerDirector();
        }
        private string ObtenerRFC(string placa) {
            D_OrdenCobro Datos = new D_OrdenCobro();
            return Datos.ObtenerRFC(placa);
        }

        private decimal ObtenerDescuento(string fecha) {
            D_OrdenCobro Datos = new D_OrdenCobro();
            return Datos.ObtenerDescuento(fecha);
        }

        private Tuple<string, string> ObtenerCilindrosYRuta(string placa) {
            D_OrdenCobro Datos = new D_OrdenCobro();
            return Datos.ObtenerCilindrosYRuta(placa);
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
                this.OrdenC(TXT_Placa.Text.Trim());
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
                    if (TXT_NuevaPlaca.Text.Trim().Length > 0) {
                        if (TXT_NuevaPlaca.Text.Trim().Length == 7){
                            DialogResult resultado = MessageBox.Show("¿Desea actualizar la placa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultado == DialogResult.Yes) {
                                Console.WriteLine("Usuario seleccionó Sí");

                            } else {
                                TXT_NuevaPlaca.Text = "";
                            }
                        } else {
                            MessageBox.Show("La nueva placa no cumple con parámetros válidos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                     // Message => Actualizar índice
                    }
                    // GENERAR PDF ORDEN COBRO
                    
                    string placa = TXT_PlacaActual.Text.Trim();
                    string nombre = TXT_Nombre.Text.Trim();
                    string direccion = TXT_Domicilio.Text.Trim();
                    int folioR = Convert.ToInt32(TXT_FolioRevista.Text.Trim());
                    string serie = TXT_NoSerie.Text.Trim();
                    string motor = TXT_NoMotor.Text.Trim();
                    int modelo = Convert.ToInt32(TXT_Modelo.Text.Trim());
                    string marca = TXT_Marca.Text.Trim();
                    string clvVehicular = TXT_ClaveVehicular.Text.Trim();
                    string tipo = TXT_Tipo.Text.Trim();
                    decimal total = Convert.ToDecimal(TXT_Total.Text.Trim());
                    string elaboro = CMB_Elaboro.Text.Trim();
                    int nMovimiento = Convert.ToInt32(TXT_NoMovimiento.Text.Trim());
                    string combustible = TXT_Combustible.Text.Trim();
                    string capacidad = TXT_NoPasajeros.Text.Trim() + " pasajeros";
                    List<int> claves = new List<int>();
                    List<string> descripcion = new List<string>();
                    List<decimal> importe = new List<decimal>();
                    string cp = TXT_CP.Text.Trim();

                    string servicio = "Colectivo";
                    string rfc = ObtenerRFC(placa);
                    Tuple<string, string> CilYRuta = ObtenerCilindrosYRuta(placa);
                    string cilindros = CilYRuta.Item1;
                    string ruta = CilYRuta.Item2;
                    string observaciones = TXT_Observaciones.Text.Trim();
                    string autorizoC = ObtenerDirector();

                    foreach (DataGridViewRow fila in DGV_Clave.Rows) {
                        if (fila.Cells["Clave"].Value != null) {
                            if (int.TryParse(fila.Cells["Clave"].Value.ToString(), out int clave)) {
                                claves.Add(clave);
                            }
                        }

                        // Lista de descripciones (índice 1)
                        if (fila.Cells["Concepto"].Value != null) {
                            descripcion.Add(fila.Cells["Concepto"].Value.ToString());
                        }

                        // Lista de importes (índice 4)
                        if (fila.Cells["Costo"].Value != null) {
                            if (decimal.TryParse(fila.Cells["Costo"].Value.ToString(), out decimal valorImporte)) {
                                importe.Add(valorImporte);
                            }
                        }
                    }


                    GenerarpdfResumen(servicio, placa, nombre, direccion, rfc, serie, motor, modelo, marca, clvVehicular, tipo, cilindros, total, elaboro, ruta, observaciones, combustible, capacidad, autorizoC, claves, descripcion, importe, cp);

                    if (formVisualizador == null || formVisualizador.IsDisposed) {
                        F_VisualizacionPDF formVisualizador = new F_VisualizacionPDF();
                        formVisualizador.RecibirNombre("ResumenCobro.pdf");
                        formVisualizador.ShowDialog();
                    }

                    GenerarPdf(placa, nombre, direccion, folioR, serie, motor, modelo, marca, clvVehicular, tipo, total, elaboro, nMovimiento, combustible, capacidad, claves, descripcion, importe, cp);

                    if (formVisualizador == null || formVisualizador.IsDisposed) {
                        F_VisualizacionPDF formVisualizador = new F_VisualizacionPDF();
                        formVisualizador.RecibirNombre("OrdenCobro.pdf");
                        formVisualizador.ShowDialog();
                    }
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
            TXT_Descuento.Text = ObtenerDescuento(DateTime.Now.ToString("yyyy-MM-dd")).ToString() + "%";
            AutoCompleteClave();
            DGV_Clave.ColumnCount = 3;
            DGV_Clave.Columns[0].Name = "Clave";
            DGV_Clave.Columns[1].Name = "Concepto";
            //DGV_Clave.Columns[2].Name = "Costo";
            //DGV_Clave.Columns[3].Name = "Cantidad";
            DGV_Clave.Columns[2].Name = "Costo";

             //DGV_Clave.Rows.Add(4410, "Pago Tarjeta", 502.5, 1);
             //DGV_Clave.Rows.Add(4410, "Pago Tarjeta", 502.5, 2, 1);
             //DGV_Clave.Rows.Add(4410, "Pago Tarjeta", 502.5, 3, 1);

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
                //ActualizarCosto(index);
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
                SumarCostos();
            }
        }

        /*private Dictionary<int, int> valores = new Dictionary<int, int>();*/ // Almacena los valores para cada fila

        /*private void DGV_Clave_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex == DGV_Clave.Columns["Cantidad"].Index) { // Ajusta el índice de la columna según sea necesario
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                // Obtener el valor actual para la fila
                int valorActual = valores.ContainsKey(e.RowIndex) ? valores[e.RowIndex] : 1;

                // Dibujar el primer botón
                var buttonRect1 = new System.Drawing.Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 2, e.CellBounds.Width / 4 - 5, e.CellBounds.Height - 4);
                ControlPaint.DrawButton(e.Graphics, buttonRect1, ButtonState.Normal);
                
                // Dibujar el icono en el primer botón
                System.Drawing.Image iconomas = Properties.Resources.signomas10px;
                //Image icono1 = Image.FromFile("Resources/signomas.png"); // Ajusta la ruta según tu proyecto
                int x1 = buttonRect1.X + (buttonRect1.Width - iconomas.Width) / 2;
                int y1 = buttonRect1.Y + (buttonRect1.Height - iconomas.Height) / 2;
                e.Graphics.DrawImage(iconomas, x1, y1);

                // Dibujar el número en medio de los dos botones
                var textRect = new System.Drawing.Rectangle(e.CellBounds.X + e.CellBounds.Width / 4, e.CellBounds.Y, e.CellBounds.Width / 2, e.CellBounds.Height);
                TextRenderer.DrawText(e.Graphics, valorActual.ToString(), e.CellStyle.Font, textRect, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                System.Drawing.Image iconomenos = Properties.Resources.signomenos10px;
                
                // Dibujar el segundo botón
                var buttonRect2 = new System.Drawing.Rectangle(e.CellBounds.X + e.CellBounds.Width * 3 / 4, e.CellBounds.Y + 2, e.CellBounds.Width / 4 - 5, e.CellBounds.Height - 4);
                ControlPaint.DrawButton(e.Graphics, buttonRect2, ButtonState.Normal);
                int x2 = buttonRect2.X + (buttonRect2.Width - iconomenos.Width) / 2;
                int y2 = buttonRect2.Y + (buttonRect2.Height - iconomenos.Height) / 2;
                e.Graphics.DrawImage(iconomenos, x2, y2);

                e.Handled = true;
            }
        }*/

        /*private void DGV_Clave_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex == DGV_Clave.Columns["Cantidad"].Index) {
                // Determinar si se hizo clic en el primer o segundo botón
                var clickPosition = DGV_Clave.PointToClient(Cursor.Position);
                var buttonRect1 = new System.Drawing.Rectangle(DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).X + 5, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Y + 2, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Width / 4 - 5, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Height - 4);
                var buttonRect2 = new System.Drawing.Rectangle(DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).X + DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Width * 3 / 4, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Y + 2, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Width / 4 - 5, DGV_Clave.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Height - 4);

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
        }*/

        /*private void ActualizarCosto(int rowIndex) {
        // Obtener la cantidad y el costo unitario de la fila
            int cantidad = valores.ContainsKey(rowIndex) ? valores[rowIndex] : 1;

            // Asegurarse de que las celdas tengan valores numéricos
            if (decimal.TryParse(DGV_Clave.Rows[rowIndex].Cells[2].Value?.ToString(), out decimal costoUnitario)) {
                // Calcular el costo multiplicando cantidad por costo unitario
                decimal costo = cantidad * costoUnitario;

                // Actualizar el valor en la columna "Costo"
                DGV_Clave.Rows[rowIndex].Cells[4].Value = costo;
            }
        }*/

        private void SumarCostos(){
            decimal Total = 0;
            decimal descuento = ObtenerDescuento(DateTime.Now.ToString("yyyy-MM-dd"));

            foreach (DataGridViewRow row in DGV_Clave.Rows){
                Total += Convert.ToDecimal(row.Cells["Costo"].Value);
            }
            
            TXT_Total.Text = (Total * (1 - (descuento / 100))).ToString();
        }

        #region funciones de PDF
        private static void GenerarPdf(string placa, string nombre, string direccion, int folioR, string serie, string motor, int modelo, string marca, string clvVehicular, string tipo, decimal total, string elaboro, int nMovimiento, string combustible, string capacidad, List<int> claves, List<string> descripcion, List<decimal> importe, string cp)
        {
            #region DATOS
            DateTime today = DateTime.Today;
            //variables dentro de la funcion:
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            int dia = today.Day;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);
            int year = today.Year;
            //variables para la vigencia

            /*string placa = "AXXXXX";
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
            string combustible = "GASOLINA";
            string capacidad = "20 PASAJEROS";
            //creacion de las listas para las claves, descripcion e importe
            List<int> claves = new List<int> { 512, 511, 315 };
            List<String> descripcion = new List<String> { "RREFRENDO 2023 PARA VEHICULOS DE 15 A 20 PSJ.", "Refrendo 2023 para vehiculos 5-14 pasajeros", "BAJA DE UNIDAD" };
            List<decimal> importe = new List<decimal> { 720, 711, 104 };*/
            #endregion

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("OrdenCobro.pdf", FileMode.Create));
            doc.AddAuthor("SecretariaMovilidadyTransporte");
            doc.AddTitle("Documento de Orden de Cobro");

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

            doc.Open();
            var tabla = new PdfPTable(new float[] { 20f, 50f, 25f }) { WidthPercentage = 100f };
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

            doc.Add(new iTextSharp.text.Paragraph($"Apetatitlán Tlax, a {dia} de {mes} {year}", fnegrita));
            doc.Add(new Phrase($"PLACA: ", fnegrita));
            doc.Add(new Phrase($"{placa}", fnormal));
            doc.Add(new iTextSharp.text.Paragraph($"DATOS DE CONCECIONARIO", fnegrita) { Alignment = Element.ALIGN_CENTER });

            iTextSharp.text.Chunk linea = new iTextSharp.text.Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f));
            doc.Add(linea);
            doc.Add(iTextSharp.text.Chunk.NEWLINE);
            doc.Add(new Phrase($"NOMBRE: ", fnegrita));
            doc.Add(new Phrase($"{nombre}", fnormal));
            doc.Add(new Phrase("    FOLIO REVISTA: ", fnegrita));
            doc.Add(new Phrase($"{folioR}", fnormal));
            doc.Add(iTextSharp.text.Chunk.NEWLINE);
            doc.Add(new Phrase($"DIRECCIÓN: ", fnegrita));
            doc.Add(new Phrase($"{direccion}", fnormal));
            doc.Add(iTextSharp.text.Chunk.NEWLINE);
            var prfrfc = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("CP: ", fnegrita),
                new iTextSharp.text.Chunk($"{cp}\n", fnormal)
            };
            doc.Add(new iTextSharp.text.Paragraph(prfrfc));
            doc.Add(new iTextSharp.text.Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f)));
            doc.Add(iTextSharp.text.Chunk.NEWLINE);
            doc.Add(new iTextSharp.text.Paragraph($"DATOS DEL VEHICULO ", fnegrita) { Alignment = Element.ALIGN_CENTER });
            doc.Add(iTextSharp.text.Chunk.NEWLINE);
            var tabla2 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100 };
            var parrafoSerie = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("SERIE: ", fnegrita),
                new iTextSharp.text.Chunk($"{serie}", fnormal)
            };
            var cel1 = new PdfPCell(parrafoSerie) { Border = 0 };
            var prrfmotor = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("MOTOR: ", fnegrita),
                new iTextSharp.text.Chunk($"{motor}", fnormal)
            };
            var cel2 = new PdfPCell(prrfmotor) { Border = 0 };
            var prrfmodelo = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("MODELO: ", fnegrita),
                new iTextSharp.text.Chunk($"{modelo}", fnormal)
            };
            var cel3 = new PdfPCell(prrfmodelo) { Border = 0 };

            tabla2.AddCell(cel1);
            tabla2.AddCell(cel2);
            tabla2.AddCell(cel3);

            var prrfmarca = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("MARCA: ", fnegrita),
                new iTextSharp.text.Chunk($"{marca}", fnormal)
            };

            cel1.Phrase = new Phrase(prrfmarca);
            var prrfclv = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("CLV_VEHICULAR: ", fnegrita),
                new iTextSharp.text.Chunk($"{clvVehicular}", fnormal)
            };
            cel2.Phrase = new Phrase(prrfclv);
            var prftipo = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("TIPO: ", fnegrita),
                new iTextSharp.text.Chunk($"{tipo}", fnormal)
            };
            cel3.Phrase = new Phrase(prftipo);

            tabla2.AddCell(cel1);
            tabla2.AddCell(cel2);
            tabla2.AddCell(cel3);

            var prfcomb = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("COMBUSTIBLE: ", fnegrita),
                new iTextSharp.text.Chunk($"{combustible}", fnormal)
            };
            cel1.Phrase = new Phrase(prfcomb);
            var prfcapacidad = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("CAPACIDAD: ", fnegrita),
                new iTextSharp.text.Chunk($"{capacidad}", fnormal)
            };
            cel2.Phrase = new Phrase(prfcapacidad);
            cel3.Phrase = new Phrase("");

            tabla2.AddCell(cel1);
            tabla2.AddCell(cel2);
            tabla2.AddCell(cel3);

            doc.Add(tabla2);

            //tlaba de descripciones
            doc.Add(new iTextSharp.text.Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f)));
            doc.Add(iTextSharp.text.Chunk.NEWLINE);
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
            var prftotal = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("TOTAL: ", fnegrita),
                new iTextSharp.text.Chunk($"${total}", fnormal)
            };

            doc.Add(tabla3);
            doc.Add(new iTextSharp.text.Paragraph(prftotal) { Alignment = Element.ALIGN_RIGHT });

            doc.Add(new iTextSharp.text.Paragraph("AUTORIZÓ", fnegrita) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new iTextSharp.text.Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 60f, BaseColor.BLACK, Element.ALIGN_CENTER, 0f)));
            doc.Add(new iTextSharp.text.Paragraph($"{nombre}", fnormal) { Alignment = Element.ALIGN_CENTER });
            doc.Add(iTextSharp.text.Chunk.NEWLINE);
            var tabla4 = new PdfPTable(new float[] { 30f, 10f, 30f }) { WidthPercentage = 100 };
            var prfmovimiento = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("NÚMERO DE MOVIMIENTO: ",fnormal),
                new iTextSharp.text.Chunk($"{nMovimiento}")
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

        private static void GenerarpdfResumen(string servicio, string placa, string nombre, string domicilio, string rfc, string serie, string motor, int modelo, string marca, string clvVehicular, string tipo, string cilindros, decimal total, string elaboroC, string ruta, string observaciones, string combustible, string capacidad, string autorizoC, List<int> claves, List<String> descripcion, List<decimal> importe, string cp)
        {
            DateTime today = DateTime.Today;
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            int dia = today.Day;
            string mes = DateTime.Today.ToString("MMMM", culturaEspañol);
            int year = today.Year;


            //string servicio = "COLECTIVO";
            //string placa = "AXXXXX";
            //string nombre = "MANUEL ALEJANDRO MORA MENESES";
            //string rfc = "TUX920811PQ7";
            //string serie = "VF1FLADRACY419294";
            //string motor = "C683198";
            //int modelo = 2023;
            //string marca = "RENAULT TRAFIC";
            //string clvVehicular = "1982432";
            //string tipo = "PANEL";
            //string cilindros = "4 CIL";
            //decimal total = 1535;
            //string elaboroC = "JOSE ALFREDO CRUZ MARTINEZ";
            //string ruta = "INFORNAVIT PETROQUIMICA.TLAX DE XICOHTENCATL-PROCURADURIA GRAL DE JUSTICIA PI (GRAN PATIO, SAN PABLO APETATITLAN, CAMINO REAL, GARITA, MERCADO, CENTRAL CAMNIONERA, SOBRE LIBRIAMIENTO INSTITUTO POLITECNICO NACIONAL, TEPEHITEC).";
            //string observaciones = "CANJE DE PLACAS 2023";
            //string combustible = "GASOLINA";
            //string capacidad = "20 PASAJEROS";
            //string autorizoC = "ING. FELIPE HERNANDEZ JUAREZ";
            ////creacion de las listas para las claves, descripcion e importe
            //List<int> claves = new List<int> { 512, 511, 315 };
            //List<String> descripcion = new List<String> { "RREFRENDO 2023 PARA VEHICULOS DE 15 A 20 PSJ.", "Refrendo 2023 para vehiculos 5-14 pasajeros", "BAJA DE UNIDAD" };
            //List<decimal> importe = new List<decimal> { 720, 711, 104 };


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
            doc.Add(new iTextSharp.text.Paragraph($"{domicilio}", fnormal));
            var prfrfc = new iTextSharp.text.Paragraph
            {
                new iTextSharp.text.Chunk("CP: ", fnegrita),
                new iTextSharp.text.Chunk($"{cp}\n", fnormal)
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
            var t3cel2 = new PdfPCell(prfcilindros) { Padding = 4, Border = 0 };
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

        private void DGV_Clave_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            SumarCostos();
        }
    }
}
