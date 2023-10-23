<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nutriologoLogin.aspx.cs" Inherits="RecipesWeb.nutriologoLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login Nutriólogos</title>
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
        <h1>Nutriólogos</h1>
        <div class="login-form">
            <div class="input-group">
                <label for="usuario">Cédula:</label>
                <asp:TextBox ID="txtUsu" runat="server"></asp:TextBox>
            </div>
            <div class="input-group">
                <label for="contrasena">Contraseña:</label>
                <asp:TextBox ID="txtContra" runat="server"></asp:TextBox>
                <br />
            </div>
            <asp:Button ID="btnLoginNutri" margin="12px" runat="server" BackColor="#829949" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Login" Width="140px" display="inline-block"  BorderColor="White" OnClick="btnLoginNutri_Click" />
        </div>
    </div>
    </form>
</body>
</html>
