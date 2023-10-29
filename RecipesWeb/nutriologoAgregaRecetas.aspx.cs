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
                //se cargan los ingredientes registrados en la base y las etiquetas actualmente usadas
                llenarEtiquetas();
                llenarIngredientes();
            }
        }

        //para registra una receta
        protected void btnSubirReceta_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                //se genera el siguiente id contando las recetas ya registradas
                String queryCount = String.Format("SELECT COUNT(DISTINCT idReceta) FROM Receta");
                SqlCommand cmdCount = new SqlCommand(queryCount, con);
                int idNuevo = (int)cmdCount.ExecuteScalar() + 1;
                cmdCount.ExecuteReader().Close();

                //alta de la receta
                String queryRegistro = String.Format("INSERT INTO Receta VALUES({0}, '{1}', '{2}')", idNuevo, txtNombreReceta.Text, txtInstrucciones.Text);
                SqlCommand cmdRegistro = new SqlCommand(queryRegistro, con);
                cmdRegistro.ExecuteNonQuery();

                //creación del registro que une a la receta con el nutriólogo que la escribió
                String queryReceta = String.Format("INSERT INTO RegistroReceta VALUES({0}, {1}, {2})", idNuevo, 100 + idNuevo, (string)Session["cedula"]);
                SqlCommand cmdReceta = new SqlCommand(queryReceta, con);
                cmdReceta.ExecuteNonQuery();

                //se registran las etiquetas que satisface la receta según marcado en los checkbox
                foreach (ListItem item in chkEtiquetas.Items)
                {
                    if (item.Selected)
                    {
                        String etiquetaId = item.Value.ToString();
                        String queryEtiqueta = String.Format("INSERT INTO RecetaEtiqueta VALUES({0}, '{1}')", idNuevo, etiquetaId);
                        SqlCommand cmdEtiqueta = new SqlCommand(queryEtiqueta, con);
                        cmdEtiqueta.ExecuteNonQuery();
                    }
                }
                //se registran los ingredientes que usa la receta según marcado en la lista
                foreach (ListItem item in lstIngredientesAgregados.Items)
                {
                    int ingredienteId = int.Parse(item.Value);
                    String queryExistencia = String.Format("SELECT numPiezas FROM RecetaIngrediente WHERE idReceta ={0} AND idIngrediente ={1}", idNuevo, ingredienteId);
                    SqlCommand cmdExistencia = new SqlCommand(queryExistencia, con);
                    var result = cmdExistencia.ExecuteScalar();
                    if (result != null)
                    {
                        float numPiezas = 0;
                        if (float.TryParse(result.ToString(), out numPiezas))
                        {
                            numPiezas++; // Aumenta en 1
                            string queryActualizar = string.Format("UPDATE RecetaIngrediente SET numPiezas = {0} WHERE idReceta = {1} AND idIngrediente = {2}", numPiezas, idNuevo, ingredienteId);
                            SqlCommand cmdActualizar = new SqlCommand(queryActualizar, con);
                            cmdActualizar.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // No existe, agrega una nueva instancia
                        string queryInsertar = String.Format("INSERT INTO RecetaIngrediente VALUES ({0}, {1}, {2})",idNuevo, ingredienteId, 1);
                        SqlCommand cmdInsertar = new SqlCommand(queryInsertar, con);
                        cmdInsertar.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
            //aviso de que se realizó el alta
            txtNombreReceta.Text = "";
            txtInstrucciones.Text = "Se agregó la receta";
            lstIngredientesAgregados.Items.Clear();
        }

        //para seleccionar un ingrediente como parte de la receta que se está creando:
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
