using System;
using System.Collections.Generic;
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

        }

        protected void btAgregarAListaSuper_Click(object sender, EventArgs e)
        {

        }

        protected void gvMostrarPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvRecetasDelPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}