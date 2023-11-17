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
    public class D_PermisoCircularFueraRuta
    {
        public List<string[]> CircularFR(string placa)
        {
            MySqlDataReader Resultado;
            List<string[]> listaDatos = new List<string[]>();
            MySqlConnection SqlCon = new MySqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT nombre_co, domicilio_co, estado_co, cp_co, noSerie_un, noMotor_un, repuve_un, marca_un, modelo_un, unidad_un.placa_un, folioTC_un, ruta_un, nombre_di FROM unidad_un INNER JOIN movimiento_mo ON unidad_un.placa_un = movimiento_mo.placa_un INNER JOIN concesionario_co ON unidad_un.id_co = concesionario_co.id_co INNER JOIN director_di ON movimiento_mo.id_di = director_di.id_di WHERE unidad_un.placa_un = @Placa";

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
    }
}
