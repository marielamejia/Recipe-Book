using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class crearUsu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Para dar de alta un nuevo usuario
        protected void btnCreaU_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            if (con != null)
            {
                //se construye un id a partir del más alto actual registrado en la base
                string query = "select Isnull(max(idUsuario),0) from Usuario";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                int id = rd.GetInt16(0) + new Random().Next(1,5);
                rd.Close();
                //se insertan los datos proporcionados
                query = $"insert into Usuario values ({id}, '{txtNom.Text}', '{txtMail.Text}', '{txtContra.Text}')";
                cmd = new SqlCommand(query, con);
                try {
                    cmd.ExecuteNonQuery();
                    //también se registra su respectiva lista de super
                    query = $"insert into ListaSuper values ({id}, 0, {id})";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("usuarioLogin.aspx");
                }catch (Exception) //la inserción falla si el correo ya estaba registrado en la base, pues debe ser único
                {
                    con.Close();
                    lbResp.Text = "Correo ya registrado, ingrese otro";
                }
            }
        }
    }
}