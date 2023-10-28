<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizarReceta.aspx.cs" Inherits="RecipesWeb.VisualizarReceta" %>

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
    <form id="form2" runat="server">
        <div>
            <div class="header">
            </div>
            <h1>Receta</h1>
            <br />
            <strong>Nombre:</strong><br />
            <asp:Label ID="lbNombre" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <strong>Ingredientes:</strong><br />
            <br />
        <asp:GridView ID="gvBuscarRecetas1" runat="server" OnSelectedIndexChanged="gvBuscarRecetas_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="idReceta" HeaderText="id" ReadOnly="True" SortExpression="idReceta" Visible="False" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="nombre" />
                <asp:BoundField DataField="numPiezas" HeaderText="Piezas" ReadOnly="True" SortExpression="numPiezas" />
                <asp:BoundField DataField="precioPromPorKg " HeaderText="Precio promedio [Kg]" ReadOnly="True" SortExpression="precioPromPorKg " />
            </Columns>
        </asp:GridView>
            <br />
            <br />
            <strong>Etiquetas:</strong><asp:BulletedList ID="listaEtiquetas" runat="server" EnableTheming="True">
            </asp:BulletedList>
            <br />
            <br />
            <br />
            <strong>Instrucciones:</strong><br />
            <asp:Label ID="lbInstrucciones" runat="server"></asp:Label>
            <br />
           <footer>
            <div class="button-container">
                <asp:Button ID="btnUsuario" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Perfil" Width="140px" OnClick="btnUsuario_Click" />
                <asp:Button ID="btnLista" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Super" Width="140px" OnClick="btnLista_Click" />
                <asp:Button ID="btnRecetas" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Recetas" Width="140px" OnClick="btnRecetas_Click" />
                <asp:Button ID="btnPlan" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Plan" Width="140px" OnClick="btnPlan_Click" />
            </div>
           </footer>
            <br />
            <strong>Agregar a un plan: </strong>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" Height="42px" OnClick="Button1_Click" Text="Agregar" Width="133px" />
            <br />
        <div>
        </div>
        </div>
    </form>
</body>
</html>
