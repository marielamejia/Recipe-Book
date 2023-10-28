using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class crearUsu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreaU_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                string query = "select Isnull(max(idUsuario),0) from Usuario";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                int id = rd.GetInt16(0) + new Random().Next(1,5);
                rd.Close();
                query = $"insert into Usuario values ({id}, '{txtNom.Text}', '{txtMail.Text}', '{txtContra.Text}')";
                cmd = new SqlCommand(query, con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    query = $"insert into ListaSuper values ({id}, 0, {id})";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("usuarioLogin.aspx");
                }
                else
                {
                    con.Close();
                    lbResp.Text = "Alta fallida";
                }
            }
        }
    }
}