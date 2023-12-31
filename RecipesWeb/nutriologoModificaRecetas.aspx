﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nutriologoModificaRecetas.aspx.cs" Inherits="RecipesWeb.nutriologoModificaRecetas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Nutríologo Principal</title>
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
           background-color: #829949;
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
       .button {
           background-color: #333;
           color: white;
           border: none;
           padding: 10px 20px;
           text-align: center;
           text-decoration: none;
           display: inline-block;
           font-size: 16px;
           margin: 5px;
           cursor: pointer;
       }
       .container {
           display: flex;
           flex-direction: column;
           align-items: center;
           justify-content: center;
       }
       .parr {
        font-size: 16px;
        text-align: justify;
        margin: 0 40px;
        line-height: 1.6;
        color: #333;
    }
   </style>
</head>
<body>
    <form id="form" runat="server">
        <div>
            <div class="header">
            </div>
            <h2>Eliminar</h2>
            <asp:DropDownList ID="ddRecetas" runat="server" OnSelectedIndexChanged="ddRecetas_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <br />
            <br />
            <label id="labelid" style="font-weight: bold;">idReceta:</label>
            <asp:Label ID="lbId" runat="server" Text="" Font-Size="16px">
            </asp:Label>
            <br />
            <label id="labelNombre" style="font-weight: bold;">Nombre:</label>
            <asp:Label ID="lbNombre" runat="server" Text="" Font-Size="16px">
            </asp:Label>
            <br />
             <br />
            <label id="labelInstrucciones" style="font-weight: bold;">Instrucciones:</label>
            <div id="parrafoTexto" runat="server" class="parr"></div>
            <br />
            <br />
            <label id="labelEtiquetas" style="font-weight: bold;">Etiquetas:</label>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <label id="labelIngredientes" style="font-weight: bold;">Ingredientes:</label>
            <br />
            <br />
            <asp:ListBox ID="lstEtiquetas" runat="server" SelectionMode="Multiple" style="width: 200px"></asp:ListBox>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:ListBox ID="lstIngredientes" runat="server" SelectionMode="Multiple" style="width: 200px"></asp:ListBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnEliminarReceta" runat="server" Text="Eliminar receta" margin="12px" BackColor="#829949" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Width="180px" display="inline-block" BorderColor="White" OnClick="btnEliminarReceta_Click" />
            <br />
            <asp:Label ID="lbEliminar" runat="server" Text=""  Font-Size="16px" ForeColor="#DA593C"></asp:Label>
            </div>
            <footer>
                <div class="button-container">
                    <asp:Button ID="btnCuenta" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Cuenta" Width="140px" OnClick="btnCuenta_Click" />
                    <asp:Button ID="btnAgregar" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Agregar" Width="140px" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnModificar" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Eliminar" Width="140px" OnClick="btnModificar_Click" />
               </div>
            </footer>
    </form>
</body>
</html>
