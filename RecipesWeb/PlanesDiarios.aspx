<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanesDiarios.aspx.cs" Inherits="RecipesWeb.PlanesDiarios" %>

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
            <h2>Planes</h2>
             <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="true"></asp:DropDownList>
             <br />
            <br />
            <asp:Button ID="btnMostrarPlan" runat="server" Text="Mostrar Plan" margin="12px" BackColor="#e1a144" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Width="180px" display="inline-block"  BorderColor="White" OnClick="btnMostrarPlan_Click" />
            <br />
            <br />
            <asp:Button ID="btnAgregarPlan" runat="server" Text="Agregar Plan" margin="12px" BackColor="#e1a144" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Width="180px" display="inline-block"  BorderColor="White" OnClick="btnAgregarPlan_Click" />
            <footer>
            <div class="button-container">
                <asp:Button ID="btnUsuario" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Perfil" Width="140px" OnClick="btnUsuario_Click" />
                <asp:Button ID="btnLista" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Super" Width="140px" OnClick="btnLista_Click" />
                <asp:Button ID="btnRecetas" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Recetas" Width="140px" OnClick="btnRecetas_Click" />
                <asp:Button ID="btnPlan" runat="server" margin="12px" BackColor="Black" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Text="Plan" Width="140px" OnClick="btnPlan_Click" />
            </div>
           </footer>
        </div>
    </form>
</body>
</html>
