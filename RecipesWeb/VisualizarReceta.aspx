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
            bottom: 9px;
            left: 2px; 
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
            <h1>Detalles Receta</h1>
            </div>
            <br />
            <strong>Nombre:</strong><br />
            <asp:Label ID="lbNombre" runat="server"></asp:Label>
            <br />
            <br />
            <strong>Etiquetas:<br />
            </strong>
            <asp:Label ID="lbEtiquetas" runat="server"></asp:Label>
            <strong>
            <br />
            </strong>
            <br />
            <strong>Ingredientes:</strong><br />
            <br />
        <asp:GridView ID="gvIngredientes" runat="server" CssClass="centered-gridview" style="margin: 0 auto; text-align: center;" AutoGenerateColumns="False" DataKeyNames="id">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" Visible="False" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="nombre" />
                <asp:BoundField DataField="precioPromPorKg" HeaderText="Precio promedio [Kg]" ReadOnly="True" SortExpression="precioPromPorKg" />
                <asp:BoundField DataField="numPiezas" HeaderText="Piezas" ReadOnly="True" SortExpression="numPiezas" />
            </Columns>
        </asp:GridView>
            <br />
            <strong>Instrucciones:</strong><br />
            <asp:Label ID="lbInstrucciones" runat="server"></asp:Label>
            <br />
            <br />
            <strong>&nbsp;Guardar en un plan: </strong>
            <asp:DropDownList ID="ddPlanes" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Button ID="btAgregarIngsALista" runat="server" Height="36px" Text="Agregar" Width="133px" OnClick="btAgregarIngsALista_Click" />
            &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="lbMsg" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btAddIngsALista" runat="server" OnClick="btAddIngsALista_Click" Text="Agregar ingredientes a lista de súper" Width="484px" />
            <br />
            <footer>
            <div class="button-container">
                <asp:Button ID="btnUsuario" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Perfil" Width="140px" OnClick="btnUsuario_Click" />
                <asp:Button ID="btnRecetas" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Recetas" Width="140px" OnClick="btnRecetas_Click" />
                <asp:Button ID="btnPlan" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Planes" Width="140px" OnClick="btnPlan_Click" />
                <asp:Button ID="btnLista" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Lista de Super" Width="140px" OnClick="btnLista_Click" />
            </div>
           </footer>
        </div>
    </form>
</body>
</html>
