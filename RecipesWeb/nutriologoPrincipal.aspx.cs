﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class nutriologoPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCuenta_Click(object sender, EventArgs e)
        {

        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("nutriologoAgregaRecetas.aspx");
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("nutriologoModificaRecetas.aspx");
        }

        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}