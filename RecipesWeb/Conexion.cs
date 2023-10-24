using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RecipesWeb
{
	public class Conexion
	{
        public static SqlConnection agregarConexion()
        {
            SqlConnection cnn;
            try
            {
                cnn = new SqlConnection("Data Source=192.168.0.12;Initial Catalog=BDnutricion;Integrated Security=False;TrustServerCertificate=True;User ID=sa;Password=VeryStr0ngP@ssw0rd;Encrypt=False;");
                cnn.Open();
                //MessageBox.Show("conectado");
            }
            catch (Exception ex)
            {
                cnn = null;
            }
            return cnn;
        }
    }
}