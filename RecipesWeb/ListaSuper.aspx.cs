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
            string query = $"select Ingrediente.idIngrediente, Ingrediente.nombre, Ingrediente.precioPromPorKg, IngredienteListaSuper.numPiezas from Ingrediente inner join IngredienteListaSuper on Ingrediente.idIngrediente = IngredienteListaSuper.idIngrediente where idLista = {Session["idLista"]}";
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
            SqlConnection con = Conexion.agregarConexion();
            string query = $"delete from IngredienteListaSuper where idPlan = {Session["idLista"]} and idIngrediente = {gVListaSuper.SelectedRow.Cells[0]}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            gVListaSuper.DeleteRow(gVListaSuper.SelectedIndex);
        }

        protected void btLimpiar_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            string query = $"delete from IngredienteListaSuper where idPlan = {Session["idLista"]}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close(); gVListaSuper.DataSource = null;
            gVListaSuper.DataBind();
        }
    }
}