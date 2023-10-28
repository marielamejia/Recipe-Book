using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            //esta pag
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

        }

        protected void ddPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvRecetasDelPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void llenarPlanes()
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                String query = String.Format("SELECT nombre, idPlan FROM PlanDia WHERE idUsuario={0}", Session["id"]);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                ddPlanes.DataSource = rd;
                ddPlanes.DataTextField = "nombre";
                ddPlanes.DataValueField = "idPlan";
                ddPlanes.DataBind();
            }
        }
    }
}