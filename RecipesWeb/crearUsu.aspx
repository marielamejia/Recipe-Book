﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearUsu.aspx.cs" Inherits="RecipesWeb.crearUsu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Login Usuarios</title>
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

        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        h1 {
            color: #000000;
        }
        .login-form {
            width: 300px;
            padding: 20px;
            border-radius: 7px;
            background-color: #ffffff;
        }

        .input-group {
            margin-bottom: 20px;
        }

        .input-group label {
            display: block;
            font-weight: bold;
        }

        .input-group input[type="text"],
        .input-group input[type="text"]
        .input-group input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #000000;
            border-radius: 5px;
        }   
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
    </div>
    <div class="container">
        <h1>Crea tu cuenta</h1>
        <div class="login-form">
            <div class="input-group">
                <label for="Nombre">Nombre:</label>
                <asp:TextBox ID="txtNom" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <label for="Email">Email:</label>
                <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <label for="contrasena">Contraseña:</label>
                <asp:TextBox ID="txtContra" runat="server" CssClass="textbox" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                <br />
            </div>
            <asp:Button ID="btnCreaU" margin="12px" runat="server" BackColor="#E1A144" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Crear cuenta" Width="140px" display="inline-block"  BorderColor="White" OnClick="btnCreaU_Click" />
            <br />
            <br />
            <asp:Label ID="lbResp" runat="server" ForeColor="#FF6A6A"></asp:Label>    
        </div>
    </div>
    </form>
</body>
</html>
