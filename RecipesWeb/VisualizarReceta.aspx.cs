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
                //llenado de lista de etiquetas
                query = $"select etiqueta from RecetaEtiqueta where idReceta = {Session["idReceta"]}";
                cmd = new SqlCommand(query, con);
                rd = cmd.ExecuteReader();
                listaEtiquetas.DataSource = rd;
                listaEtiquetas.DataTextField = "etiqueta";
                listaEtiquetas.DataBind();
                rd.Close();
                //llenado dropdown list de planes del usuario
                query = $"select idPlan, nombre from PlanDia where idUsuario = {Session["id"]}";
                cmd = new SqlCommand(query, con);
                rd = cmd.ExecuteReader();
                ddPlanes.DataSource = rd;
                ddPlanes.DataValueField = "idPlan";
                ddPlanes.DataTextField = "nombre";
                ddPlanes.DataBind();
                rd.Close();
                con.Close();
            }
        }
        protected void btAgregarIngsALista_Click(object sender, EventArgs e)
        {
            if (ddPlanes.SelectedIndex > 0)
            {
                SqlConnection con = Conexion.agregarConexion();
                string query = $"insert into RecetaPlan values({Session["idReceta"]},{ddPlanes.SelectedValue})";
                SqlCommand cmd = new SqlCommand(query, con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    lbMsg.Text = "Receta agregada al plan";
                }
                else
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
        protected void btVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecetasUsuario.aspx");
        }
    }
}