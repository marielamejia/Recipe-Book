using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesWeb
{
    public partial class ListaSuper : System.Web.UI.Page
    {
        //para cargar los datos de la lista de súper en el grid 
        private void llenarGrid()
        {
            //se buscan nombre, precio y cantidad guardada de todos los ingredientes en la lista de super del usuario
            SqlConnection con = Conexion.agregarConexion();
            string query = $"select Ingrediente.idIngrediente as id, Ingrediente.nombre as nombre, Ingrediente.precioPromPorKg as precio, IngredienteListaSuper.numPiezas as piezas from Ingrediente inner join IngredienteListaSuper on Ingrediente.idIngrediente = IngredienteListaSuper.idIngrediente where idLista = {Session["idLista"]}";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            //se llena el grid
            gVListaSuper.DataSource = rd;
            gVListaSuper.DataBind();
            rd.Close();
            //se mustra también el total de elementos
            lbCuantos.Text = gVListaSuper.Rows.Count.ToString();
            con.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGrid();//se llena el grid
        }

        //para eliminar un sólo ingrediente de la lista
        protected void gVListaSuperr_SelectedIndexChanged(object sender, EventArgs e)
        {
            //se elimina de la base de datos
            SqlConnection con = Conexion.agregarConexion();
            string query = $"delete from IngredienteListaSuper where idLista = {Session["idLista"]} and idIngrediente = {gVListaSuper.SelectedValue}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //se actualiza el grid
            llenarGrid();
        }

        //para vaciar por completo la lista
        protected void btLimpiar_Click(object sender, EventArgs e)
        {
            //se elimina toda la información de la lista del usuario
            SqlConnection con = Conexion.agregarConexion();
            string query = $"delete from IngredienteListaSuper where idLista = {Session["idLista"]}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //se actualiza el grid
            llenarGrid();
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