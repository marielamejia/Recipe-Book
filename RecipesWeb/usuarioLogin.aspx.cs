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
                //se busca que exista una tupla con los datos ingresados
                String query = String.Format("SELECT idUsuario FROM Usuario WHERE correo='{0}' and contrasena='{1}'", txtUsu.Text, txtContra.Text);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                //si los datos son correctos, el query regresa una tupla
                if (rd.HasRows)
                {
                    //se guardan los datos del usuario y se da acceso
                    rd.Read();
                    Session["id"] = rd.GetInt16(0);
                    Session["idLista"] = rd.GetInt16(0);
                    rd.Close();
                    con.Close();
                    Response.Redirect("usuarioPrincipal.aspx");
                }
                else
                //mensaje de error
                {
                    lbResp.Text = "mail o password incorrecto";
                    rd.Close();
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
