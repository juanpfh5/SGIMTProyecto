using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;

namespace SGIMTProyecto {
    public class D_OrdenCobro {
        public List<string[]> OrdenC(string placa) {
            MySqlDataReader Resultado;
            List<string[]> listaDatos = new List<string[]>();
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT nombre_co, placa_un, domicilio_co, cp_co, noSerie_un, noMotor_un, modelo_un, marca_un, claveVehicular_un, tipo_un, combustible_un, pasajeros_un FROM unidad_un INNER JOIN  concesionario_co ON unidad_un.id_co = concesionario_co.id_co WHERE placa_un = @Placa";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);
                Comando.Parameters.AddWithValue("@Placa", placa);
                Comando.CommandTimeout = 60;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();

                while (Resultado.Read()) {
                    string[] datosFila = new string[Resultado.FieldCount];

                    for (int i = 0; i < Resultado.FieldCount; i++) {
                        datosFila[i] = Resultado[i].ToString();
                    }

                    listaDatos.Add(datosFila);
                }

                return listaDatos;
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public List<string> ListadoPersonal() {
            List<string> listaNombres = new List<string>();
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT nombre_pe FROM personal_pe";

                using (MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon)) {
                    Comando.CommandTimeout = 60;
                    SqlCon.Open();

                    using (MySqlDataReader Resultado = Comando.ExecuteReader()) {
                        while (Resultado.Read()) {
                            string nombre = Resultado["nombre_pe"].ToString();
                            listaNombres.Add(nombre);
                        }
                    }
                }

                return listaNombres;
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public List<string> ListadoClaveConcepto(string busqueda) {
            MySqlDataReader listaClaveConcepto;
            List<string> listaBusqueda = new List<string>();
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = $"SELECT CONCAT(clave_cl, ' | ', concepto_cl) AS clave_concepto_cl FROM claves_cl WHERE clave_cl LIKE '%{busqueda}%' OR concepto_cl LIKE '%{busqueda}%'";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);
                Comando.CommandTimeout = 60;
                SqlCon.Open();
                listaClaveConcepto = Comando.ExecuteReader();

                while (listaClaveConcepto.Read()) {
                    listaBusqueda.Add(listaClaveConcepto["clave_concepto_cl"].ToString());
                }

                return listaBusqueda;
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }


        static void MostrarListaEnMessageBox(List<string> lista) {
            // Concatenar los elementos de la lista en una sola cadena
            string mensaje = string.Join(Environment.NewLine, lista);

            // Mostrar el MessageBox
            MessageBox.Show(mensaje, "Elementos de la Lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
