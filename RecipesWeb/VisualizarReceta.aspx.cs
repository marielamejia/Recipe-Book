using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class VisualizarReceta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = Conexion.agregarConexion();
                string query;
                SqlCommand cmd;
                SqlDataReader rd;
                //llenado de nombre e instrucciones:
                query = $"select nombre, instrucciones from Receta where idReceta = {Session["idReceta"]}";
                cmd = new SqlCommand(query, con);
                rd = cmd.ExecuteReader();
                rd.Read();
                lbNombre.Text = rd.GetString(0);
                lbInstrucciones.Text = rd.GetString(1);
                rd.Close();
                //llenado del grid de ingredientes:
                query = $"select Ingrediente.idIngrediente as id, nombre, precioPromPorKg, numPiezas from Ingrediente inner join RecetaIngrediente on Ingrediente.idIngrediente = RecetaIngrediente.idIngrediente where idReceta = {Session["idReceta"]} ";
                cmd = new SqlCommand(query, con);
                rd = cmd.ExecuteReader();
                gvIngredientes.DataSource = rd;
                gvIngredientes.DataBind();
                rd.Close();
                //se muestran las etiquetas
                query = $"select etiqueta from RecetaEtiqueta where idReceta = {Session["idReceta"]}";
                cmd = new SqlCommand(query, con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lbEtiquetas.Text += rd.GetString(0) + "\t";
                }
                rd.Close();
                //llenado dropdown list de planes del usuario
                query = $"select idPlan, nombre from PlanDia where idUsuario = {Session["id"]}";
                cmd = new SqlCommand(query, con);
                rd = cmd.ExecuteReader();
                ddPlanes.DataSource = rd;
                ddPlanes.DataValueField = "idPlan";
                ddPlanes.DataTextField = "nombre";
                ddPlanes.DataBind();
                ddPlanes.SelectedIndex = 0;
                rd.Close();
                con.Close();
            }
        }

        //para añadir la receta a un plan
        protected void btAgregarRceta_Click(object sender, EventArgs e)
        {
            if (ddPlanes.Items.Count > 0) //se comprueba que haya planes
            {
                SqlConnection con = Conexion.agregarConexion();
                string query = $"insert into RecetaPlan values({Session["idReceta"]},{ddPlanes.SelectedValue})";
                SqlCommand cmd = new SqlCommand(query, con);
                //se intenta la inserción
                try {
                    cmd.ExecuteNonQuery();
                    lbMsg.Text = "Receta agregada al plan";
                }
                catch (Exception) //si hay error es porque ya estaba esta receta en el plan seleccionado
                {
                    lbMsg.Text = "La receta ya se encontraba en este plan";
                }
            }
            else
            {
                lbMsg.Text = "Primero debes elegir un Plan. Si no hay ninguno, créalo desde la sección Plan";
            }
        }

        //para añadir los ingredientes de la receta a la lista de super del usuario:
        protected void btAddIngsALista_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            SqlCommand cmd;
            SqlDataReader rd;
            string query;
            //se guardan en dos listas paralelas los ingredientes de la receta y su respectiva cantidad
            query = $"select Ingrediente.idIngrediente, numPiezas from Ingrediente inner join RecetaIngrediente on Ingrediente.idIngrediente = RecetaIngrediente.idIngrediente where idReceta = {Session["idReceta"]}";
            cmd = new SqlCommand(query, con);
            rd = cmd.ExecuteReader();
            List<Int16> IDs = new List<short>();
            List<Decimal> piezasIng = new List<decimal>();
            while (rd.Read())
            {
                IDs.Add(rd.GetInt16(0));
                piezasIng.Add(rd.GetDecimal(1));
            }
            rd.Close();
            //se busca, si existe, la cantidad ya guardada en la lista de cada ingrediente
            Decimal piezasPrevias;
            for (int i = 0; i < IDs.Count; i++)
            {
                query = $"select numPiezas from IngredienteListaSuper where idLista = {Session["idLista"]} and idIngrediente = {IDs[i]}";
                cmd = new SqlCommand(query, con);
                rd = cmd.ExecuteReader();
                if (rd.Read()) //el ingrediente ya se encontraba en la lista, sólo se actualiza la cantidad
                {
                    piezasPrevias = rd.GetDecimal(0);
                    query = $"update IngredienteListaSuper set numPiezas = {piezasIng[i] + piezasPrevias} where idLista = {Session["idLista"]} and idIngrediente = {IDs[i]}";
                }
                else //se registra un nuevo ingrediente en la lista
                {
                    query = $"insert into IngredienteListaSuper values ({IDs[i]},{Session["idLista"]},{piezasIng[i]})";
                }
                rd.Close();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
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
    }
}