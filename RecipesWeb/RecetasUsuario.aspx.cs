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
                //se cargan todas las etiquetas existentes en los checkbox
                SqlConnection con = Conexion.agregarConexion();
                string query = $"select distinct etiqueta from RecetaEtiqueta";
                SqlCommand cmd = new SqlCommand(query, con);
                cbFiltros.DataSource = cmd.ExecuteReader();
                cbFiltros.DataTextField = "etiqueta";
                cbFiltros.DataBind();
                con.Close();
                //llenado del grid, aparecerán todas las recetas
                llenaGrid();
            }
        }

        //botón para visualizar con detalle una determinada receta
        protected void gvBuscarRecetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idReceta"] = gvBuscarRecetas.SelectedValue; //se guarda el id de la receta seleccionada
            Response.Redirect("VisualizarReceta.aspx");
        }

        protected void cbFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenaGrid(); //se actualizan el grid
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            llenaGrid(); //se actualizan el grid
        }

        //método para mostrar recetas que coincidan con el nombre en la barra de búsqueda y cumplan todos los filtros seleccionados
        private void llenaGrid()
        {
            SqlConnection con = Conexion.agregarConexion();
            //se seleccionan las recetas con nombre similar a lo que esté escrito en la barra de búsqueda
            string query = $"SELECT DISTINCT Receta.idReceta as id, nombre from Receta inner join RecetaEtiqueta on Receta.idReceta = RecetaEtiqueta.idReceta where nombre like '%{txBuscador.Text}%'";
            //se añaden restricciones al query para cada filtro seleccionado
            for (int i = 0; i < cbFiltros.Items.Count; i++)
                if (cbFiltros.Items[i].Selected)
                    query += $" and etiqueta = '{cbFiltros.Items[i].Text}'";
            //llenado del grid
            SqlCommand cmd = new SqlCommand(query, con);
            gvBuscarRecetas.DataSource = cmd.ExecuteReader();
            gvBuscarRecetas.DataBind();
            con.Close();
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
        protected void btBuscar_Click(object sender, EventArgs e)
        {

        }
        protected void gvBuscarRecetas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}