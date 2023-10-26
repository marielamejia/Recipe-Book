using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class usuarioPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = Conexion.agregarConexion();
                if (con != null)
                {
                    string query = $"select nombre, correo, contrasena from Usuario where idUsuario = {Session["id"]}";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    lbNombre.Text = rd.GetString(0);
                    lbEmail.Text = rd.GetString(1);
                    lbContra.Text = rd.GetString(2);
                    rd.Close();
                    con.Close();
                }
            }
        }
        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnLista_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaSuper.aspx");
        }
        protected void btnRecetas_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecetasUsuario.aspx");
        }
        protected void btnPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlanesDiarios.aspx");
        }
        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null && txtContraseñaNueva.Text.Equals(txtRepetirContraseña.Text))
            {
                string query = $"update Usuario set contrasena = '{txtRepetirContraseña.Text}' where idUsuario = {Session["id"]}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}