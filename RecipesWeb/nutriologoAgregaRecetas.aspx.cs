using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class nutriologoAgregaRecetas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarEtiquetas();
                llenarIngredientes();
            }
        }

        protected void btnCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("nutriologoPrincipal.aspx");
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //boton de esta pagina
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("nutriologoModificaRecetas.aspx");
        }

        protected void btnSubirReceta_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            String queryCount = String.Format("SELECT COUNT(DISTINCT idReceta) FROM Receta");
            SqlCommand cmdCount = new SqlCommand(queryCount, con);
            int idNuevo = (int)cmdCount.ExecuteScalar() + 1;
            cmdCount.ExecuteReader().Close();

            String queryRegistro = String.Format("INSERT INTO Receta VALUES({0}, '{1}', '{2}')", idNuevo, txtNombreReceta.Text, txtInstrucciones.Text);
            SqlCommand cmdRegistro = new SqlCommand(queryRegistro, con);
            cmdRegistro.ExecuteReader();
            cmdRegistro.ExecuteReader().Close();

            String queryReceta = String.Format("INSERT INTO RegistroReceta VALUES({0}, {1}, {2})", idNuevo, 100 + idNuevo, (string)Session["cedula"]);
            SqlCommand cmdReceta = new SqlCommand(queryReceta, con);
            cmdReceta.ExecuteReader();
            cmdReceta.ExecuteReader().Close();

            if (con != null)
            {
                foreach (ListItem item in chkEtiquetas.Items)
                {
                    if (item.Selected)
                    {
                        int etiquetaId = int.Parse(item.Value);
                        String queryEtiqueta = String.Format("INSERT INTO RecetaEtiqueta VALUES({0}, {1})", idNuevo, etiquetaId);
                        SqlCommand cmdEtiqueta = new SqlCommand(queryEtiqueta, con);
                        cmdEtiqueta.ExecuteReader();
                    }
                }
                foreach (ListItem item in lstIngredientesAgregados.Items)
                {
                    int ingredienteId = int.Parse(item.Value);
                    String queryIngrediente = String.Format("INSERT INTO RecetaIngrediente VALUES({0}, {1})", idNuevo, ingredienteId);
                    SqlCommand cmdIngrediente = new SqlCommand(queryIngrediente, con);
                    cmdIngrediente.ExecuteReader();
                }
            }
            con.Close();
        }
        protected void btnAgregarIngrediente_Click(object sender, EventArgs e)
        {
            lstIngredientesAgregados.Items.Add(ddlIngredientes.SelectedItem);
        }

        //metodo para agregar etiquetas a check boxes
        protected void llenarEtiquetas()
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                String query = String.Format("SELECT distinct etiqueta FROM RecetaEtiqueta");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string etiqueta = rd["etiqueta"].ToString();
                    ListItem item = new ListItem(etiqueta, etiqueta); //el valor y el texto que es igual
                    chkEtiquetas.Items.Add(item);
                }
                con.Close();
            }
        }

        protected void llenarIngredientes()
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                String query = String.Format("SELECT idIngrediente, nombre FROM Ingrediente");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                ddlIngredientes.DataSource = rd;
                ddlIngredientes.DataTextField = "nombre";
                ddlIngredientes.DataValueField = "idIngrediente"; //el valor es el id para que podamos accesarlo facilmente
                ddlIngredientes.DataBind();
            }
        }
    }

}
