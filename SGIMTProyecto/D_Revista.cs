using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SGIMTProyecto {
    public class D_Revista {
        public List<string[]> Rev(string placa) {
            MySqlDataReader Resultado;
            List<string[]> listaDatos = new List<string[]>();
            MySqlConnection SqlCon = new MySqlConnection();

            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT nombre_co, CONCAT(domicilio_co, ' No. ', noExterior_co, ', ', municipio_co, ', ', estado_co) AS domicilio_co, placa_un, noSerie_un, tipo_un, noMotor_un, modelo_un, claveVehicular_un, marca_un, pasajeros_un, folioRevista_un, tipo_co, resolucion_co, ruta_un FROM unidad_un INNER JOIN concesionario_co ON unidad_un.id_co = concesionario_co.id_co WHERE placa_un = @Placa AND baja_un IS NULL;";

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
    }
}
