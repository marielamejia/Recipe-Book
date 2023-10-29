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
                //se muestran los datos del usuario en la ventana
                SqlConnection con = Conexion.agregarConexion();
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
        //para que el usuario pueda establecer una nueva contraseña
        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            //se comprueba que se haya escrito la misma nueva contraseña en ambas cajas de texto
            if (txtContraseñaNueva.Text.Equals(txtRepetirContraseña.Text))
            {
                //actualización de la contraseña
                string query = $"update Usuario set contrasena = '{txtRepetirContraseña.Text}' where idUsuario = {Session["id"]}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //botón para cerrar la sesión
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        //Botones del footer para navegar entre páginas del usuario
        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarioPrincipal.aspx");
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
    }
}