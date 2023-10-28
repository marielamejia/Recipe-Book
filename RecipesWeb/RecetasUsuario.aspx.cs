using System;
using System.Collections.Generic;
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

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}