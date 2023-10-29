using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesStandalone
{
    //Clase que contiene toda la funcionalidad de las ventanas de nutriólogo
    class ClaseNutriologo
    {
        //Atributos iguales a los campos de la tabla de Nutriólogo de la base de datos
        public String cedula { get; set; }
        public String nombre { get; set; }
        public String contrasena { get; set; }


        // Constructores 
        public ClaseNutriologo()
        {
        }
        

        //Métodos y funciones 
        public int addNutriologo(String cedula, String nombre, String contra) //recibe todos los atributos del nutriólogo a ergistrar
        {
            int res = 0;
            SqlConnection cnn = Conexion.agregarConexion();
            string query = $"insert into Nutriologo values ('{cedula}', '{nombre}', '{contra}')";
            SqlCommand cmd = new SqlCommand(query, cnn);
            res = cmd.ExecuteNonQuery();
            cnn.Close();
            return res;
        }
        public int deleteNutriologo(String cedula) //recibe la cédula del nutriólogo a eliminar
        {
            int res = 0;
            SqlConnection cnn;
            cnn = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format(("delete from Nutriologo where cedula ='{0}'"), cedula), cnn);
            res = cmd.ExecuteNonQuery();
            cnn.Close();
            return res;
        }
        public List<ClaseNutriologo> ListarNutriologos() //construye una lista con todos los nutriólogos en la base
        {
            List<ClaseNutriologo> lis = new List<ClaseNutriologo>();
            ClaseNutriologo n;
            SqlConnection cnn = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format("select * from Nutriologo"), cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                n = new ClaseNutriologo();
                n.cedula = dr.GetString(0);
                n.nombre = dr.GetString(1);
                n.contrasena = dr.GetString(2);
                lis.Add(n);
            }
            cnn.Close();
            return lis;
        }
    }
}
