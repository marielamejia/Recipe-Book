using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class nutriologoPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //se muestran los datos del nutriólogo en pantalla
                lbCedula.Text = (string)Session["cedula"];
                lbContra.Text = (string)Session["contra"];
            }
        }
        //para modificar contraseña
        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            //se revisa que ambos textbox contengan la misma contraseña
            if (con != null && txtContraseñaNueva.Text.Equals(txtRepetirContraseña.Text))
            {
                //se realiza el update
                string query = $"update Nutriologo set contrasena = '{txtRepetirContraseña.Text}' where cedula = '{Session["cedula"]}'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //botón para cerrar sesión y volver al index
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        //botones del footer para navegar las páginas de nutriólogo
        protected void btnCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("nutriologoPrincipal.aspx");
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("nutriologoAgregaRecetas.aspx");
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("nutriologoModificaRecetas.aspx");
        }

    }
}