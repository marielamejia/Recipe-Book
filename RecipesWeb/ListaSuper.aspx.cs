using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class ListaSuper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            String query = String.Format("SELECT * from IngredienteListaSuper");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            gVListaSuper.DataSource = rd; 
            gVListaSuper.DataBind();  
            rd.Close();
            con.Close();
        }
        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarioPrincipal.aspx");
        }
        protected void btnLista_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnRecetas_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecetasUsuario.aspx");
        }
        protected void btnPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlanesDiarios.aspx");
        }

        protected void gVListaSuperr_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = gVListaSuper.SelectedRow.Cells[0].Text.ToString();
            TextBox2.Text = gVListaSuper.SelectedRow.Cells[0].Text.ToString();
            TextBox3.Text = gVListaSuper.SelectedRow.Cells[0].Text.ToString();
            TextBox4.Text = gVListaSuper.SelectedRow.Cells[0].Text.ToString();
        }

        protected void btEliminarTodo_Click(object sender, EventArgs e)
        {
            gVListaSuper.DataSource = null; 
            gVListaSuper.DataBind();
        }
    }
}