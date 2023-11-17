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
    public class D_EditarVehiculo
    {
        public List<string[]> DatosVehiculo(string placa)
        {
            MySqlDataReader Resultado;
            List<string[]> listaDatos = new List<string[]>();
            MySqlConnection SqlCon = new MySqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT nombre_co, vehiculo_un, marca_un, modelo_un, tipo_un, tipoServicio_un, vehiculoOrigen_un, claveVehicular_un, noSeguro_un, repuve_un, noSerie_un, noMotor_un, cilindros_un, combustible_un, toneladas_un, pasajeros_un, uso_un, placa_un, ruta_un, folioTC_un, rfv_un, folioRevista_un FROM unidad_un INNER JOIN concesionario_co ON unidad_un.id_co = concesionario_co.id_co WHERE placa_un = @Placa";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);
                Comando.Parameters.AddWithValue("@Placa", placa);
                Comando.CommandTimeout = 60;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();

                while (Resultado.Read())
                {
                    // Crear un array para almacenar los datos de cada fila
                    string[] datosFila = new string[Resultado.FieldCount];

                    // Copiar los datos de cada columna al array
                    for (int i = 0; i < Resultado.FieldCount; i++)
                    {
                        datosFila[i] = Resultado[i].ToString();
                    }

                    // Agregar el array a la lista
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

        public void ActualizarVehiculo(List<object> datosVehiculo, string placa)
        {
            MySqlConnection SqlCon = new MySqlConnection();

            try
            {
                int count = 0;
                string parametro;

                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "UPDATE unidad_un SET vehiculo_un = @Vehiculo, marca_un = @Marca, modelo_un = @Modelo, tipo_un = @Tipo, tipoServicio_un = @TipoServicio, vehiculoOrigen_un = @VehiculoOrigen, claveVehicular_un = @ClaveVehicular, noSeguro_un = @NoSeguro, repuve_un = @Repuve, ruta_un = @Ruta, folioTC_un = @FolioTC, rfv_un = @RFV, folioRevista_un = @FolioRevista, noSerie_un = @NoSerie, noMotor_un = @NoMotor, cilindros_un = @Cilindros, combustible_un = @Combustible, toneladas_un = @Toneladas, pasajeros_un = @Pasajeros, uso_un = @Uso WHERE placa_un = @Placa;";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);

                foreach (var elemento in datosVehiculo)
                {
                    parametro = "";
                    switch (count)
                    {
                        case 0:
                            parametro = "@Vehiculo";
                            break;
                        case 1:
                            parametro = "@Marca";
                            break;
                        case 2:
                            parametro = "@Modelo";
                            break;
                        case 3:
                            parametro = "@Tipo";
                            break;
                        case 4:
                            parametro = "@TipoServicio";
                            break;
                        case 5:
                            parametro = "@VehiculoOrigen";
                            break;
                        case 6:
                            parametro = "@ClaveVehicular";
                            break;
                        case 7:
                            parametro = "@NoSeguro";
                            break;
                        case 8:
                            parametro = "@Repuve";
                            break;
                        case 9:
                            parametro = "@Ruta";
                            break;
                        case 10:
                            parametro = "@FolioTC";
                            break;
                        case 11:
                            parametro = "@RFV";
                            break;
                        case 12:
                            parametro = "@FolioRevista";
                            break;
                        case 13:
                            parametro = "@NoSerie";
                            break;
                        case 14:
                            parametro = "@NoMotor";
                            break;
                        case 15:
                            parametro = "@Cilindros";
                            break;
                        case 16:
                            parametro = "@Combustible";
                            break;
                        case 17:
                            parametro = "@Toneladas";
                            break;
                        case 18:
                            parametro = "@Pasajeros";
                            break;
                        case 19:
                            parametro = "@Uso";
                            break;
                    }
                    Comando.Parameters.AddWithValue(parametro, elemento);
                    count++;
                }
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
