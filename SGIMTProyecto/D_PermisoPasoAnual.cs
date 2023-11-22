using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIMTProyecto {

    public class D_PasoAnual {
            public void InsertarPasoAnual(List<object> datosPasoAnual) {
                MySqlConnection SqlCon = new MySqlConnection();

                try {
                    int count = 0;
                    string parametro;

                    SqlCon = Conexion.getInstancia().CrearConexion();
                    string sql_tarea = "INSERT INTO pasoanual_pa (permisionario_pa, domicilio_pa, poblacion_pa, cp_pa, rutaAutorizada_pa, noMotor_pa, noSerie_pa, rfv_pa, marca_pa, placa_pa, modelo_pa, folioTC_pa, fechaVigencia_pa, fechaExpedicion_pa, folioPermiso_pa, id_mo) VALUES (@Permisionario, @Domicilio, @Poblacion, @CP, @Recorrido, @NoMotor, @NoSerie, @RFV, @Marca, @Placa, @Modelo, @FolioTC, @FechaVigencia, @FechaExpedicion, @FolioPermiso, @NoMovimiento);";

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
                                parametro = "@NoSerie";
                                break;
                            case 5:
                                parametro = "@NoMotor";
                                break;
                            case 6:
                                parametro = "@RFV";
                                break;
                            case 7:
                                parametro = "@Marca";
                                break;
                            case 8:
                                parametro = "@Modelo";
                                break;
                            case 9:
                                parametro = "@Placa";
                                break;
                            case 10:
                                parametro = "@FolioTC";
                                break;
                            case 11:
                                parametro = "@Recorrido";
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
            public string ObtenerTitularSMyT() {
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT nombre_di FROM director_di ORDER BY id_di DESC LIMIT 1;";

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
    }
}
