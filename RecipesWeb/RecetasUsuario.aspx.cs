using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class RecetasUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //cargar filtros
                SqlConnection con = Conexion.agregarConexion();
                string query = $"select distinct etiqueta from RecetaEtiqueta";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                cbFiltros.DataSource = rd;
                cbFiltros.DataTextField = "etiqueta";
                cbFiltros.DataBind();
                rd.Close();
                con.Close();
            }
            llenaGrid();
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
            
        }
        protected void btnPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlanesDiarios.aspx");
        }

        protected void gvBuscarRecetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idReceta"] = gvBuscarRecetas.SelectedRow.Cells[0];
            Response.Redirect("VisualizarReceta.aspx");
        }

        protected void cbFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenaGrid();
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void llenaGrid()
        {
            SqlConnection con = Conexion.agregarConexion();
            string query = $"SELECT DISTINCT receta.idReceta, nombre from Receta inner join RecetaEtiqueta on Receta.idReceta = RecetaEtiqueta.idReceta where nombre like '%{txBuscador.Text}%'";
            for (int i = 0; i < cbFiltros.Items.Count; i++)
                if (cbFiltros.Items[i].Selected)
                    query += $" and etiqueta = '{cbFiltros.Items[i].Text}'";
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataReader rd = cmd.ExecuteReader();
            gvBuscarRecetas.DataSource = rd;
            gvBuscarRecetas.DataBind();
        }
    }
}