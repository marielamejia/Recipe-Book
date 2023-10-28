<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RecipesWeb.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Página Principal</title>
    <style>
        body {
            background-color: #ffffff;
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            text-align: center;
        }
        .container {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        h1 {
            color: #000000;
        }

        .buttons {
            margin-top: 22px;
        }

        .btnNutriologo:hover, .btnUsuario:hover {
            background-color: #000000;
        }
    </style>
    </head>
        <body>
            <form id="form1" runat="server">
        <div class="container">
            <h1>Bienvenido a FlavorFlow</h1>
            <div class="buttons">
                <asp:Button ID="btnNutriologo" margin="12px" runat="server" BackColor="#829949" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Nutriólogo" Width="140px" display="inline-block"  OnClick="btnNutriologo_Click" BorderColor="White" />
                <asp:Button ID="btnUsuario" margin="12px" runat="server" BackColor="#E1A144" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Usuario" Width="140px" display="inline-block"  OnClick="btnUsuario_Click" BorderColor="White"  />
            </div>
        </div>
            </form>
</body>
</html>
