using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesStandalone
{
    class Ingredient
    {
        //defining the different attribute the object ingredient needs 

        public static Int16 folio = 100; 
        public Int16 ingredientId { get; set; }
        public String name { get; set; }
        public Decimal avgPrice { get; set; }

        //constructors
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
        public int deleteIngredient(int ingredientId)
        {
            int res = 0;
            SqlConnection con;
            con = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format(("delete from Ingrediente where idIngrediente ={0}"), ingredientId), con);
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int modify(Int16 clave, Decimal nuevoPrecio)
        {
            int res = 0;
            SqlConnection con = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format("update ingrediente set precioPromPorKg = {0} where idIngrediente = {1}", nuevoPrecio, clave), con);
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public List<Ingredient> IngredientSearch(String name)
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

        public List<Ingredient> IngredientNames()
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
