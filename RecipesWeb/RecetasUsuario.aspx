<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecetasUsuario.aspx.cs" Inherits="RecipesWeb.RecetasUsuario" %>

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
            bottom: 171px;
            left: -2px; 
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
            <h1>Recetas</h1>
            </div>
        </div>
        <br />
        <asp:TextBox ID="txBuscador" runat="server" Width="499px" BorderColor="Black" BorderWidth="2" Height="24px" style="margin-top: 0px"></asp:TextBox>
        <asp:Button ID="btBuscar" runat="server" Height="30px" Text="Buscar" Width="120px" OnClick="btBuscar_Click" />
        <br />
        <br />
        <asp:CheckBoxList ID="cbFiltros" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="cbFiltros_SelectedIndexChanged">
        </asp:CheckBoxList>
        <br />
        <asp:GridView ID="gvBuscarRecetas" runat="server" OnSelectedIndexChanged="gvBuscarRecetas_SelectedIndexChanged" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="idReceta" HeaderText="id" ReadOnly="True" SortExpression="idReceta" Visible="False" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="nombre" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Mostrar" ShowHeader="True" Text="ver" />
            </Columns>
        </asp:GridView>
           <footer>
            <div class="button-container">
                <asp:Button ID="btnUsuario" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Perfil" Width="140px" OnClick="btnUsuario_Click" />
                <asp:Button ID="btnRecetas" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Recetas" Width="140px" OnClick="btnRecetas_Click" />
                <asp:Button ID="btnPlan" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Planes" Width="140px" OnClick="btnPlan_Click" />
                <asp:Button ID="btnLista" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Lista de Super" Width="140px" OnClick="btnLista_Click" />
            </div>
           </footer>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>
