using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SGIMTProyecto {
    public class D_PermisoCircularFueraRuta {
        public List<string[]> CircularFR(string placa) {
            MySqlDataReader Resultado;
            List<string[]> listaDatos = new List<string[]>();
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT nombre_co, domicilio_co, estado_co, cp_co, noSerie_un, noMotor_un, repuve_un, marca_un, modelo_un, unidad_un.placa_un, folioTC_un, ruta_un FROM unidad_un INNER JOIN movimiento_mo ON unidad_un.placa_un = movimiento_mo.placa_un INNER JOIN concesionario_co ON unidad_un.id_co = concesionario_co.id_co WHERE unidad_un.placa_un = @Placa AND unidad_un.baja_un IS NULL";

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

        public string ObtenerTitularSMyT() {
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT nombre_se FROM secretario_se ORDER BY id_se DESC LIMIT 1;";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);
                Comando.CommandTimeout = 60;
                SqlCon.Open();

                object resultado = Comando.ExecuteScalar();

                if (resultado != null) {
                    return resultado.ToString();
                } else {
                    return "No se encontró un Titular.";
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                if (SqlCon.State == ConnectionState.Open) {
                    SqlCon.Close();
                }
            }
        }

        public void InsertarFueraRuta(List<object> datosPasoAnual) {
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                int count = 0;
                string parametro;

                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "INSERT INTO fueraruta_fr (permisionario_fr, domicilio_fr, poblacion_fr, cp_fr, folioTC_fr, marca_fr, modelo_fr, noSerie_fr, noMotor_fr, repuve_fr, recorrido_fr, motivo_fr, fechaExpedicion_fr, fechaVigencia_fr, folioPermiso_fr, id_mo) VALUES (@Permisionario, @Domicilio, @Poblacion, @CP, @FolioTC, @Marca, @Modelo, @NoSerie, @Nomotor, @Repuve, @Recorrido, @Motivo, @FechaExpedicion,  @FechaVigencia, @FolioPermiso, @NoMovimiento);";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);

                foreach (var elemento in datosPasoAnual) {
                    parametro = "";
                    switch (count) {
                        case 0:
                            parametro = "@Permisionario";
                            break;
                        case 1:
                            parametro = "@Domicilio";
                            break;
                        case 2:
                            parametro = "@Poblacion";
                            break;
                        case 3:
                            parametro = "@CP";
                            break;
                        case 4:
                            parametro = "@FolioTC";
                            break;
                        case 5:
                            parametro = "@Marca";
                            break;
                        case 6:
                            parametro = "@Modelo";
                            break;
                        case 7:
                            parametro = "@NoSerie";
                            break;
                        case 8:
                            parametro = "@NoMotor";
                            break;
                        case 9:
                            parametro = "@Repuve";
                            break;
                        case 10:
                            parametro = "@Recorrido";
                            break;
                        case 11:
                            parametro = "@Motivo";
                            break;
                        case 12:
                            parametro = "@FechaExpedicion";
                            break;
                        case 13:
                            parametro = "@FechaVigencia";
                            break;
                        case 14:
                            parametro = "@FolioPermiso";
                            break;
                        case 15:
                            parametro = "@NoMovimiento";
                            break;

                    }
                    Comando.Parameters.AddWithValue(parametro, elemento);
                    count++;
                }
                Comando.CommandTimeout = 60;
                SqlCon.Open();
                Comando.ExecuteReader();
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public bool ExistenciaMovimiento(int movimiento) {
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT EXISTS(SELECT 1 FROM movimiento_mo WHERE id_mo = @Movimiento) as existeMovimiento;";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);
                Comando.Parameters.AddWithValue("@Movimiento", movimiento);
                Comando.CommandTimeout = 60;
                SqlCon.Open();

                int resultado = Convert.ToInt32(Comando.ExecuteScalar());
                return resultado == 1;
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
