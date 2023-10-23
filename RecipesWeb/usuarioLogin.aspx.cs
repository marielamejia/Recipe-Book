using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class usuarioLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginUsu_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                String query = String.Format("select ");
                SqlCommand cmd = new SqlCommand(query, con);
            }
            
        }
    }
}