using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class nutriologoModificaRecetas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarRecetas();
            }
        }

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
            //boton para esta pagina
        }
        protected void ddRecetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection miConexion = Conexion.agregarConexion();
            if (miConexion != null)
            {
                String var = ddRecetas.SelectedValue;
                String query = String.Format("SELECT idReceta, nombre, instrucciones FROM Receta WHERE idReceta={0}", Int16.Parse(var));
                SqlCommand cmd = new SqlCommand(query, miConexion);
                SqlDataReader rd = cmd.ExecuteReader();
                gvReceta.DataSource = rd;
                gvReceta.DataBind();
                rd.Close();
                miConexion.Close();
            }
            lbEliminar.Text = "";
        }

        protected void btnEliminarReceta_Click(object sender, EventArgs e)
        {
            SqlConnection miConexion = Conexion.agregarConexion();
            if (miConexion != null)
            {
                String var = ddRecetas.SelectedValue;
                String query = String.Format("DELETE FROM RecetaIngrediente where idReceta={0}", Int16.Parse(var));
                SqlCommand cmd = new SqlCommand(query, miConexion);
                cmd.ExecuteNonQuery();
                query = String.Format("DELETE FROM RecetaEtiqueta where idReceta={0}", Int16.Parse(var));
                cmd = new SqlCommand(query, miConexion);
                cmd.ExecuteNonQuery();
                query = String.Format("DELETE FROM RegistroReceta where idReceta={0}", Int16.Parse(var));
                cmd = new SqlCommand(query, miConexion);
                cmd.ExecuteNonQuery();
                query = String.Format("DELETE FROM Receta where idReceta={0}", Int16.Parse(var));
                cmd = new SqlCommand(query, miConexion);
                cmd.ExecuteNonQuery();
                miConexion.Close();
                gvReceta.DataSource = null;
                gvReceta.DataBind();
                lbEliminar.Text = "Se eliminó correctamente";
            }
            else
            {
                lbEliminar.Text = "No se pudo eliminar";
            }
        }

        protected void llenarRecetas()
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                String query = String.Format("SELECT DISTINCT Receta.nombre, Receta.idReceta FROM Receta INNER JOIN RegistroReceta ON Receta.idReceta = RegistroReceta.idReceta WHERE RegistroReceta.cedulaNutriologo={0}", Session["cedula"]);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                ddRecetas.DataSource = rd;
                ddRecetas.DataTextField = "nombre";
                ddRecetas.DataValueField = "idReceta";
                ddRecetas.DataBind();
            }
        }

    }
}