﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanesDiarios.aspx.cs" Inherits="RecipesWeb.PlanesDiarios" %>

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
            <h1>Planes</h1>
            <br />
            Nuevo Plan:
            <asp:TextBox ID="txCrearPlan" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btCrearPlan" runat="server" Height="35px" OnClick="btCrearPlan_Click" Text="Crear" Width="89px" />
            <br />
        <asp:GridView ID="gvMostrarPlanes" runat="server" OnSelectedIndexChanged="gvMostrarPlanes_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="idPlan" HeaderText="id" ReadOnly="True" SortExpression="idPlan" Visible="False" />
                <asp:BoundField DataField="nombre" HeaderText="Plan" ReadOnly="True" SortExpression="nombre" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Desplegar" ShowHeader="True" Text="..." />
            </Columns>
        </asp:GridView>
            <br />
            <br />
            <strong>Recetas del plan:</strong><br />
        <asp:GridView ID="gvRecetasDelPlan" runat="server" OnSelectedIndexChanged="gvRecetasDelPlan_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="idReceta" HeaderText="id" ReadOnly="True" SortExpression="idReceta" Visible="False" />
                <asp:BoundField DataField="nombre" HeaderText="Receta" ReadOnly="True" SortExpression="nombre" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Detalles" ShowHeader="True" Text="ver" />
            </Columns>
        </asp:GridView>
            <br />
            <asp:Button ID="btAgregarAListaSuper" runat="server" OnClick="btAgregarAListaSuper_Click" Text="Agregar ingredientes de las recetas a la lista de súper" Width="712px" />
            <br />
           <footer>
            <div class="button-container">
                <asp:Button ID="btnUsuario" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Perfil" Width="140px" OnClick="btnUsuario_Click" />
                <asp:Button ID="btnLista" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Super" Width="140px" OnClick="btnLista_Click" />
                <asp:Button ID="btnRecetas" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Recetas" Width="140px" OnClick="btnRecetas_Click" />
                <asp:Button ID="btnPlan" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Plan" Width="140px" OnClick="btnPlan_Click" />
            </div>
           </footer>
        <div>
        </div>
        </div>
    </form>
</body>
</html>
