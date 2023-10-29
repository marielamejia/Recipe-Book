<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarioPrincipal.aspx.cs" Inherits="RecipesWeb.usuarioPrincipal" %>

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

        .seccionContrasena {
            background-color: white; 
            padding: 20px;
            margin-top: 20px;
            color: black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
            <h1>Tu cuenta</h1>
            </div>
                <br />
                <label for="Nombre">Nombre:</label>
                <asp:Label ID="lbNombre" runat="server" ForeColor="#FF6A6A"></asp:Label>  
                <br />
                <br />
                <label for="Email">Email:</label>
                <asp:Label ID="lbEmail" runat="server" ForeColor="#FF6A6A"></asp:Label> 
                <br />
                <br />
                <label for="Contrasena">Contraseña:</label>
                <asp:Label ID="lbContra" runat="server" ForeColor="#FF6A6A"></asp:Label> 
            </div>
            <div class="seccionContrasena">
                <h2>Cambiar Contraseña</h2>
                <asp:TextBox ID="txtContraseñaNueva" runat="server" CssClass="textbox" TextMode="Password" placeholder="Contraseña Nueva"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="txtRepetirContraseña" runat="server" CssClass="textbox" TextMode="Password" placeholder="Repetir Contraseña"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnCambiarContraseña" runat="server" BackColor="black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Cambiar Contraseña" CssClass="button" OnClick="btnCambiarContraseña_Click" />
                <br />
                <asp:Button ID="btnSalir" runat="server" BackColor="#E1A144" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Cerrar Sesión" CssClass="button" OnClick="btnSalir_Click" />
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
