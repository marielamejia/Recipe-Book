﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //para enviar a la ventana de login de usuario
        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarioLogin.aspx");
        }

        //para enviar a la ventana de login de nutriólogo
        protected void btnNutriologo_Click(object sender, EventArgs e)
        {
            Response.Redirect("nutriologoLogin.aspx");
        }
    }
}