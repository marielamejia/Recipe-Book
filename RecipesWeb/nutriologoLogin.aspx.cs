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

        protected void btnLoginNutri_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                string query = $"select Nutriologo.contrasena from Nutriologo where cedula = '{txCedula.Text}'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    if (rd.GetString(0).Equals(txContra.Text))
                    {
                        Session["cedula"] = txCedula.Text;
                        Session["contra"] = txContra.Text;
                        rd.Close();
                        con.Close();
                        Response.Redirect("nutriologoPrincipal.aspx");

                    }
                    else
                    {
                        lbResp.Text = "Contraseña incorrecta";
                    }
                }
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