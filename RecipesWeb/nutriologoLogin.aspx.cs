using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class nutriologoLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //para comprobar que se ingresaron cédula y contraseña válidos
        protected void btnLoginNutri_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                //se busca la contraseña para la cédula ingresada
                string query = $"select Nutriologo.contrasena from Nutriologo where cedula = '{txCedula.Text}'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                //si el query regresa información la cédula estaba registrada
                if (rd.Read())
                {
                    //comprobación de contraseña
                    if (rd.GetString(0).Equals(txContra.Text))
                    {
                        //se guardan los datos del usuario y se da acceso
                        Session["cedula"] = txCedula.Text;
                        Session["contra"] = txContra.Text;
                        rd.Close();
                        con.Close();
                        Response.Redirect("nutriologoPrincipal.aspx");

                    }
                    else //contraseña incorrecta
                    {
                        lbResp.Text = "Contraseña incorrecta";
                    }
                }
                //si el query no regresa nada, no estaba registrada la cédula
                else
                {
                    lbResp.Text = "El nutriólogo no está dado de alta";
                }
                rd.Close();
                con.Close();
            }
            else
            {
                lbResp.Text = "no hubo conexión";
            }
        }

    }
}