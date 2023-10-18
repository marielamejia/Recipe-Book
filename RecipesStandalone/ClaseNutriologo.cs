using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesStandalone
{
    class ClaseNutriologo
    {
        //Atributos 
        public static Int32 cedula = 100;
        public Int32 nutriologoID { get; set; }
        public String nombre { get; set; }


        // Constructores 
        public ClaseNutriologo()
        {
        }
        public ClaseNutriologo(String nombre)
        {
            this.nutriologoID = cedula;
            this.nombre = nombre;
            cedula++;
        }

        public ClaseNutriologo(int nutriologoID, string nombre)
        {
            this.nutriologoID = nutriologoID;
            this.nombre = nombre;
        }

        //Métodos y funciones 
        public int addNutriologo(ClaseNutriologo n)
        {
            int res = 0;
            SqlConnection cnn = Conexion.agregarConexion();
            SqlCommand cmd;
            
            cmd = new SqlCommand(String.Format("insert into Nutriologo(nombre, cedula) values {0},'{1}')",
                n.nombre, n.nutriologoID), cnn);
            res = cmd.ExecuteNonQuery();
            cnn.Close();
            return res;
        }
        public int deleteNutriologo(int nutriologoID)
        {
            int res = 0;
            SqlConnection cnn;
            cnn = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format(("delete from Nutriologo where cedula ={0}"), nutriologoID), cnn);
            res = cmd.ExecuteNonQuery();
            cnn.Close();
            return res;
        }
        public List<ClaseNutriologo> NutriologoSearch()
        {
            List<ClaseNutriologo> lis = new List<ClaseNutriologo>();
            ClaseNutriologo n;
            SqlConnection cnn = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format("select * from nutriologo", nombre), cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                n = new ClaseNutriologo();
                n.nutriologoID = dr.GetInt16(0); //???? 
                n.nombre = dr.GetString(1);
                lis.Add(n);
            }
            cnn.Close();
            return lis;
        }
    }
}
