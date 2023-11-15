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
    public class D_OrdenCobroDiversos
    {
        public List<string[]> OrdenCD(string cTexto)
        {
            MySqlDataReader Resultado;
            List<string[]> listaDatos = new List<string[]>();
            MySqlConnection SqlCon = new MySqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "SELECT nombre_co, noExterior_co, domicilio_co, noInterior_co, rfc_co, cp_co, colonia_co, estado_co, municipio_co FROM unidad_un INNER JOIN  concesionario_co ON unidad_un.id_co = concesionario_co.id_co WHERE placa_un = '" + cTexto + "' ";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);
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
    }
}
