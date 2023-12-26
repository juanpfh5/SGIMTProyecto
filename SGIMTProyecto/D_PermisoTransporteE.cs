using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SGIMTProyecto {
    public class D_PermisoTransporteE {
        public void InsertarTransporteE(List<object> datosTransporteE) {
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                int count = 0;
                string parametro;

                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "INSERT INTO transporteescolar_te (permisionario_te, domicilio_te, poblacion_te, cp_te, placa_te, folioTC_te, recorrido_te, fechaExpedicion_te, fechaVigencia_te, folioPermiso_te, id_mo) VALUES (@Permisionario, @Domicilio, @Poblacion, @CP, @Placa, @FolioTC, @Recorrido, @FechaExpedicion, @FechaVigencia, @FolioPermiso, @NoMovimiento);";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);

                foreach (var elemento in datosTransporteE) {
                    parametro = "";
                    switch (count) {
                        case 0:
                            parametro = "@Permisionario";
                            break;
                        case 1:
                            parametro = "@Domicilio";
                            break;
                        case 2:
                            parametro = "@CP";
                            break;
                        case 3:
                            parametro = "@Poblacion";
                            break;
                        case 4:
                            parametro = "@Placa";
                            break;
                        case 5:
                            parametro = "@FolioTC";
                            break;
                        case 6:
                            parametro = "@Recorrido";
                            break;
                        case 7:
                            parametro = "@FechaExpedicion";
                            break;
                        case 8:
                            parametro = "@FechaVigencia";
                            break;
                        case 9:
                            parametro = "@FolioPermiso";
                            break;
                        case 10:
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
