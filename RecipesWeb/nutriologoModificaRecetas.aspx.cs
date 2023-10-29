using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            {   //queries para mostrar info de la receta
                String var = ddRecetas.SelectedValue;
                String query = String.Format("SELECT idReceta, nombre, instrucciones FROM Receta WHERE idReceta={0}", Int16.Parse(var));
                SqlCommand cmd = new SqlCommand(query, miConexion);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    string idReceta = rd["idReceta"].ToString();
                    lbId.Text = idReceta;
                    string nombreReceta = rd["nombre"].ToString();
                    lbNombre.Text = nombreReceta; 
                    string instrucciones = rd["instrucciones"].ToString();
                    parrafoTexto.InnerHtml = instrucciones;

                }
                rd.Close();
                query = String.Format("SELECT etiqueta FROM RecetaEtiqueta WHERE idReceta={0}", Int16.Parse(var));
                cmd = new SqlCommand(query, miConexion);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string etiqueta = rd["etiqueta"].ToString();
                    lstEtiquetas.Items.Add(etiqueta);
                }
                rd.Close();
                query = String.Format("SELECT Ingrediente.nombre, RecetaIngrediente.numPiezas FROM Ingrediente JOIN RecetaIngrediente ON Ingrediente.idIngrediente = RecetaIngrediente.idIngrediente WHERE RecetaIngrediente.idReceta={0}", Int16.Parse(var));
                cmd = new SqlCommand(query, miConexion);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string nombre = rd["nombre"].ToString();
                    string numPiezas = rd["numPiezas"].ToString();
                    lstIngredientes.Items.Add(numPiezas + " " + nombre);
                }
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