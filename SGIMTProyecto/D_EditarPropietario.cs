using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SGIMTProyecto {
    public class D_EditarPropietario {
        public List<string[]> DatosPropietario(string placa) {
            MySqlDataReader Resultado;
            List<string[]> listaDatos = new List<string[]>();
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT nombre_co, placa_un, domicilio_co, rfc_co, noExterior_co, noInterior_co, cp_co, colonia_co, municipio_co, estado_co, noConcesion_un, noSeguro_un FROM unidad_un INNER JOIN concesionario_co ON unidad_un.id_co = concesionario_co.id_co WHERE placa_un = @Placa";

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

        public bool ExistenciaVehiculo(string placa) {
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT EXISTS(SELECT 1 FROM unidad_un WHERE placa_un = @Placa) as existeVehiculo";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);
                Comando.Parameters.AddWithValue("@Placa", placa);  // Utiliza parámetros para evitar la inyección de SQL
                Comando.CommandTimeout = 60;
                SqlCon.Open();

                // Ejecutar la consulta y obtener el resultado
                int resultado = Convert.ToInt32(Comando.ExecuteScalar());

                // Devolver true si el vehículo existe, false si no existe
                return resultado == 1;
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public void ActualizarPropietario(List<object> datosPropietario, string placa) {
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                int count = 0;
                string parametro;

                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "UPDATE concesionario_co SET nombre_co = @Nombre, domicilio_co = @Domicilio, rfc_co = @RFC, noExterior_co = @NoExterior, noInterior_co = @NoInterior, cp_co = @CP, colonia_co = @Colonia, municipio_co = @Municipio, estado_co = @Estado WHERE  id_co = (SELECT id_co FROM unidad_un WHERE placa_un = @Placa)";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);

                foreach (var elemento in datosPropietario) {
                    parametro = "";
                    switch (count) {
                        case 0:
                            parametro = "@Nombre";
                            break;
                        case 1:
                            parametro = "@Domicilio";
                            break;
                        case 2:
                            parametro = "@RFC";
                            break;
                        case 3:
                            parametro = "@NoExterior";
                            break;
                        case 4:
                            parametro = "@NoInterior";
                            break;
                        case 5:
                            parametro = "@CP";
                            break;
                        case 6:
                            parametro = "@Colonia";
                            break;
                        case 7:
                            parametro = "@Municipio";
                            break;
                        case 8:
                            parametro = "@Estado";
                            break;
                            /*case 9:
                                parametro = "@NoConcesion";
                                break;
                            case 10:
                                parametro = "@NoSeguro";
                                break;*/
                    }
                    Comando.Parameters.AddWithValue(parametro, elemento);
                    count++;
                }
                Comando.Parameters.AddWithValue("@Placa", placa);
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
    }

}
