using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SGIMTProyecto
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Puerto;
        private string Usuario;
        private string Clave;
        private static Conexion Con = null;

        private Conexion()
        {
            this.Base = "sgimt";
            this.Servidor = "localhost";
            this.Puerto = "3306";
            this.Usuario = "root";
            this.Clave = "4815926";
        }

        public MySqlConnection CrearConexion()
        {
            MySqlConnection conexion = new MySqlConnection();
            try
            {
                conexion.ConnectionString = "datasource = " + this.Servidor + "; port  = " + this.Puerto + "; username = " + this.Usuario + "; password = " + this.Clave + "; database = " + this.Base;
            }
            catch (Exception ex)
            {
                conexion = null;
                throw ex;
            }
            return conexion;
        }

        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
