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
        public Int16 ingredientId { get; set; }

        public static Int16 folio = 100; 
        public String name { get; set; }
        public int avgPrice { get; set; }

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
       
        public Ingredient( String name, int avgPrice)
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
            SqlCommand cmd = new SqlCommand(String.Format(("delete from ingrediente where ingredientId ={0}"), ingredientId), con);
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int modify(Ingredient i)
        {
            int res = 0;
            SqlConnection con = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format("update ingrediente set avgPrice = {0} where ingredientId = {1}", i.avgPrice, i.ingredientId), con);
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public List<Ingredient> IngredientSearch()
        {
            List<Ingredient> lis = new List<Ingredient>();
            Ingredient a;
            SqlConnection con = Conexion.agregarConexion();
            SqlCommand cmd = new SqlCommand(String.Format("select ingredientId, name, avgPrice from ingrediente where name like '%{0}%'", name), con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                a = new Ingredient();
                a.ingredientId = dr.GetInt16(0); //???? 
                a.name = dr.GetString(1);
                a.avgPrice = dr.GetInt32(2);
                lis.Add(a);
            }
            con.Close();
            return lis;
        }

    }
}
