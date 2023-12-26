using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SGIMTProyecto {
    public class D_LiberacionPublicoPrivado {
        public List<string[]> LiberacionP_P(string placa) {
            MySqlDataReader Resultado;
            List<string[]> listaDatos = new List<string[]>();
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT marca_un, modelo_un, tipo_un, noSerie_un, noMotor_un FROM unidad_un WHERE placa_un = @Placa AND baja_un IS NULL";

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
                Comando.Parameters.AddWithValue("@Placa", placa);
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

        public void ActualizarLiberacion(string placa) {
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "UPDATE unidad_un SET baja_un = true WHERE placa_un = @Placa";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);

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

        public string ObtenerDirector() {
            MySqlConnection SqlCon = new MySqlConnection();
            string nombreDirector = "";

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT nombre_se FROM secretario_se ORDER BY id_se DESC LIMIT 1;";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);

                Comando.CommandTimeout = 60;
                SqlCon.Open();

                using (var reader = Comando.ExecuteReader()) {
                    if (reader.Read()) {
                        nombreDirector = reader["nombre_se"].ToString();
                    }
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
            return nombreDirector;
        }

        public int ObtenerFolio() {
            MySqlConnection SqlCon = new MySqlConnection();
            int id = 0;

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "INSERT INTO autoincrementable_au() VALUES(); SELECT id_au FROM autoincrementable_au ORDER BY id_au DESC LIMIT 1;";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);

                Comando.CommandTimeout = 60;
                SqlCon.Open();

                using (var reader = Comando.ExecuteReader()) {
                    if (reader.Read()) {
                        id = Convert.ToInt32(reader["id_au"]);
                    }
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

            return id;
        }
    }
}
