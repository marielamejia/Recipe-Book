using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class usuarioLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginUsu_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                String query = String.Format("select nombre from usuario where email='{0}' and contrasena='{1}'", txtUsu.Text, txtContra.Text);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    Session["nombre"] = rd;
                    con.Close();
                    Response.Redirect("usuarioPrincipal.aspx");
                }
                else
                {
                    lbResp.Text = "mail o password incorrecto";
                    con.Close();
                }
            }
            else
            {
                lbResp.Text = "no hubo conexión";
            }
        }

        protected void btnCreaUsu_Click(object sender, EventArgs e)
        {
            Response.Redirect("crearUsu.aspx");
        }
    }
}
