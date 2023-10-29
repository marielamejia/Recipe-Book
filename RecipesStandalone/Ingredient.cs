using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesStandalone
{
    //Clase que contiene toda la funcionalidad de las ventanas de ingredientes
     
    class Ingredient
    {
        
        //los atributos son iguales a los campos de la tabla Ingrediente de la base de datos
        public static Int16 folio = 100; 
        public Int16 ingredientId { get; set; }
        public String name { get; set; }
        public Decimal avgPrice { get; set; }

        //constructores
        public Ingredient()
        {

        }
        public Ingredient( String name)
        {
            this.ingredientId = folio;
            this.name = name;
            folio++; 
        }
       
        public Ingredient( String name, Decimal avgPrice)
        {
            this.ingredientId = folio;
            this.name = name;
            this.avgPrice = avgPrice;
            folio++; 
        }
       
        //metodos y funciones
        public int addIngredient(Ingredient i)
        {
            //se realiza un insert con todos los parámetros del ingrediente
            int res = 0;
            SqlConnection con;
            SqlCommand cmd;
            con = Conexion.agregarConexion();
            cmd = new SqlCommand(String.Format("insert into ingrediente(ingredientId,name,avgPrice) values({0},'{1}',{2})",
                i.ingredientId, i.name, i.avgPrice), con);
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int deleteIngredient(int ingredientId) //query de delete, según el id recibido
        {
            int res = 0;
            SqlConnection con;
            con = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format(("delete from Ingrediente where idIngrediente ={0}"), ingredientId), con);
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int modify(Int16 clave, Decimal nuevoPrecio) //se reciben la clavev del ingrediente a modificar y el nuevo precio
        {
            int res = 0;
            SqlConnection con = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format("update ingrediente set precioPromPorKg = {0} where idIngrediente = {1}", nuevoPrecio, clave), con);
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public List<Ingredient> IngredientSearch(String name) //devuelve una lista de objetos co todos los ingredientes de la base
        {
            List<Ingredient> lis = new List<Ingredient>();
            Ingredient a;
            SqlConnection con = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format("select * from Ingrediente where nombre like '%{0}%'", name), con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                a = new Ingredient();
                a.ingredientId = dr.GetInt16(0);
                a.name = dr.GetString(1);
                a.avgPrice = dr.GetDecimal(2);
                lis.Add(a);
            }
            con.Close();
            return lis;
        }

        public List<Ingredient> IngredientNames() //devuelve una lista con los nombres de todos los ingredientes de la base
        {
            Ingredient a;
            List<Ingredient> lis = new List<Ingredient>();
            SqlConnection con = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand("select * from Ingrediente",  con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                a = new Ingredient();
                a.ingredientId = dr.GetInt16(0);
                a.name = dr.GetString(1);
                a.avgPrice = dr.GetDecimal(2);
                lis.Add(a);
            }
            con.Close();
            return lis; 
        }

    }
}
