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

                if (bandera) {
                    MessageBox.Show(mensajeError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    /*if (this.ExistenciaVehiculo(TXT_Placa.Text.Trim())) { 

                    }*/
                }
            }
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



    }
}
