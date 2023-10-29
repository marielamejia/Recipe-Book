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
            bottom: -284px;
            left: -3px; 
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
            <br />
            <strong>Etiquetas:</strong><asp:BulletedList ID="listaEtiquetas" runat="server" EnableTheming="True">
            </asp:BulletedList>
            <br />
            <strong>Instrucciones:</strong><br />
            <asp:Label ID="lbInstrucciones" runat="server"></asp:Label>
            <br />
            <br />
            <strong>&nbsp;Guardar en un plan: </strong>
            <asp:DropDownList ID="ddPlanes" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Button ID="btAgregarIngsALista" runat="server" Height="42px" Text="Agregar" Width="133px" OnClick="btAgregarIngsALista_Click" />
            &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="lbMsg" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btAddIngsALista" runat="server" OnClick="btAddIngsALista_Click" Text="Agregar ingredientes a lista de súper" Width="484px" />
            <br />
            <br />
            <asp:Button ID="btVolver" runat="server" BackColor="#FF9900" OnClick="btVolver_Click" Text="Volver" />
            <br />
        </div>
    </form>
</body>
</html>
