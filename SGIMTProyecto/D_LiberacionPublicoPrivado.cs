using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SGIMTProyecto
{
    public class D_LiberacionPublicoPrivado
    {
        public List<string[]> LiberacionP_P(string placa)
        {
            MySqlDataReader Resultado;
            List<string[]> listaDatos = new List<string[]>();
            MySqlConnection SqlCon = new MySqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT marca_un, modelo_un, tipo_un, noSerie_un, noMotor_un FROM unidad_un WHERE placa_un = @Placa";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);
                Comando.Parameters.AddWithValue("@Placa", placa);
                Comando.CommandTimeout = 60;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();

                while (Resultado.Read())
                {
                    string[] datosFila = new string[Resultado.FieldCount];

                    for (int i = 0; i < Resultado.FieldCount; i++)
                    {
                        datosFila[i] = Resultado[i].ToString();
                    }

                    listaDatos.Add(datosFila);
                }

                return listaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public bool ExistenciaVehiculo(string placa)
        {
            MySqlConnection SqlCon = new MySqlConnection();

            try
            {
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public void ActualizarLiberacion(string placa)
        {
            MySqlConnection SqlCon = new MySqlConnection();

            try
            {
                int count = 0;
                string parametro;

                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "UPDATE unidad_un SET baja_un = true WHERE placa_un = @Placa";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);

                Comando.Parameters.AddWithValue("@Placa", placa);
                Comando.CommandTimeout = 60;
                SqlCon.Open();
                Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
