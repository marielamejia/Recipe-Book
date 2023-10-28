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
   </style>
</head>
<body>
    <form id="form" runat="server">
        <div>
            <div class="header">
            </div>
            <h1>Modificar</h1>
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
