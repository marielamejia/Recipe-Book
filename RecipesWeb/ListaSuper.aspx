<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaSuper.aspx.cs" Inherits="RecipesWeb.ListaSuper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Página Principal</title>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
     <style>
        body {
            background-color: #ffffff;
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            text-align: center;
        }
        .header {
            background-color: #e1a144;
            color: #ffffff;
            padding: 20px;
        }
        footer {
            background-color: black;
            color: white;
            text-align: center;
            position: fixed;
            bottom: 0;
            left: 0; 
            width: 100%; 
        }
        .button-container {
            display: flex;
            justify-content: space-between;
            padding: 10px;
        }
        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
            </div>
            <h1>Lista de Super</h1>
            <p>Consulta tu lista de super: </p>
            <p>
                &nbsp;</p>
           <footer>
            <div class="button-container">
                <asp:Button ID="btnUsuario" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Perfil" Width="140px" OnClick="btnUsuario_Click" />
                <asp:Button ID="btnRecetas" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Recetas" Width="140px" OnClick="btnRecetas_Click" />
                <asp:Button ID="btnPlan" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Planes" Width="140px" OnClick="btnPlan_Click" />
                <asp:Button ID="btnLista" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Lista de Super" Width="140px" OnClick="btnLista_Click" />
            </div>
           </footer>
        </div>
         
      <asp:GridView ID="gVListaSuper" runat="server" Height="303px" Width="540px" CssClass="centered-gridview" style="margin: 0 auto; text-align: center;" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnSelectedIndexChanged="gVListaSuperr_SelectedIndexChanged">
          <AlternatingRowStyle BackColor="PaleGoldenrod" />
          <Columns>
              <asp:BoundField DataField="Ingrediente.idIngrediente" HeaderText="id" ReadOnly="True" SortExpression="Ingrediente.idIngrediente" Visible="False" />
              <asp:BoundField DataField="Ingrediente.nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="Ingrediente.nombre" />
              <asp:BoundField DataField="IngredienteListaSuper.precioPromPorKg" HeaderText="Precio" ReadOnly="True" SortExpression="IngredienteListaSuper.precioPromPorKg" />
              <asp:BoundField DataField="IngredienteListaSuper.numPiezas" HeaderText="Piezas" ReadOnly="True" SortExpression="IngredienteListaSuper.numPiezas" />
              <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Eliminar" ShowHeader="True" Text="x" />
          </Columns>
          <FooterStyle BackColor="Tan" />
          <HeaderStyle BackColor="Tan" Font-Bold="True" />
          <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
          <SortedAscendingCellStyle BackColor="#FAFAE7" />
          <SortedAscendingHeaderStyle BackColor="#DAC09E" />
          <SortedDescendingCellStyle BackColor="#E1DB9C" />
          <SortedDescendingHeaderStyle BackColor="#C2A47B" />
</asp:GridView>

        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btLimpiar" runat="server" OnClick="btLimpiar_Click" Text="Limpiar lista" Width="199px" />
        </p>

    </form>
</body>
</html>
