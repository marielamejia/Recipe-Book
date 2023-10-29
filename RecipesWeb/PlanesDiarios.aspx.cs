using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class PlanesDiarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarPlanes();
            }
            
        }

        protected void btnMostrarPlan_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnAgregarPlan_Click(object sender, EventArgs e)
        {
            
        }

        protected void btCrearPlan_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                string query = "SELECT Isnull(max(idPlan),0) FROM PlanDia";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                int id = 0;
                while (rd.Read())
                {
                    id = rd.GetInt16(0) + new Random().Next(1, 5);
                }
                rd.Close();
                query = String.Format("INSERT INTO PlanDia VALUES ({0}, '{1}', {2})", id, txCrearPlan.Text, Int16.Parse(Session["id"].ToString()));
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        protected void btAgregarAListaSuper_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            SqlCommand cmd;
            SqlDataReader rd;
            string query;
            for (int j = 0; j<gvRecetasDelPlan.DataKeys.Count; j++)
            {
                Session["idReceta"] = gvRecetasDelPlan.DataKeys[j];
                query = $"select Ingrediente.idIngrediente, numPiezas from Ingrediente inner join RecetaIngrediente on Ingrediente.idIngrediente = RecetaIngrediente.idIngrediente where idReceta = {Session["idReceta"]}";
                cmd = new SqlCommand(query, con);
                rd = cmd.ExecuteReader();
                List<Int16> IDs = new List<short>();
                List<Decimal> piezasIng = new List<decimal>();
                while (rd.Read())
                {
                    IDs.Add(rd.GetInt16(0));
                    piezasIng.Add(rd.GetDecimal(1));
                }
                rd.Close();
                Decimal piezasPrevias;
                for (int i = 0; i < IDs.Count; i++)
                {
                    query = $"select numPiezas from IngredienteListaSuper where idLista = {Session["idLista"]} and idIngrediente = {IDs[i]}";
                    cmd = new SqlCommand(query, con);
                    rd = cmd.ExecuteReader();
                    if (rd.Read()) //el ingrediente ya se encontraba en la lista, sólo se actualiza la cantidad
                    {
                        piezasPrevias = rd.GetDecimal(0);
                        query = $"update IngredienteListaSuper set numPiezas = {piezasIng[i] + piezasPrevias} where idLista = {Session["idLista"]} and idIngrediente = {IDs[i]}";
                    }
                    else //se registra un nuevo ingrediente en la lista
                    {
                        query = $"insert into IngredienteListaSuper values ({IDs[i]},{Session["idLista"]},{piezasIng[i]})";
                    }
                    rd.Close();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
            }
            con.Close();
        }

        protected void ddPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            { 
                String var = ddPlan.SelectedValue;
                string query = String.Format("SELECT Receta.nombre, RecetaPlan.idReceta FROM Receta JOIN RecetaPlan ON Receta.idReceta = RecetaPlan.idReceta WHERE RecetaPlan.idPlan ={0}", Int16.Parse(var));
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                gvRecetasDelPlan.DataSource = rd;
                gvRecetasDelPlan.DataBind();
                rd.Close();
                con.Close();

            }
        }

        protected void gvRecetasDelPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void llenarPlanes()
        {
            SqlConnection con = Conexion.agregarConexion();
            String query = String.Format("SELECT nombre, idPlan FROM PlanDia WHERE idUsuario={0}", Session["id"]);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            ddPlan.DataSource = rd;
            ddPlan.DataTextField = "nombre";
            ddPlan.DataValueField = "idPlan";
            ddPlan.DataBind();
            rd.Close();
            con.Close();
        }

        protected void gvRecetasDelPlan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalles")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string idReceta = gvRecetasDelPlan.DataKeys[index]["idReceta"].ToString();
                // Guardamos en sesion para la pagina detallada de la receta
                Session["idReceta"] = idReceta;

                // Luego, puedes realizar cualquier otra lógica necesaria, como redireccionar a una página de detalles.
                Response.Redirect("VisualizarReceta.aspx");
            }
        }
    }
}