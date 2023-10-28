<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nutriologoAgregaRecetas.aspx.cs" Inherits="RecipesWeb.nutriologoAgregaRecetas" %>

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
                <h2>Agregar</h2>
                <asp:Label ID="lbNombreRec" runat="server" Text="Nombre de la Receta:" Font-Bold="True" Font-Size="16px"></asp:Label>
                <asp:TextBox ID="txtNombreReceta" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lbInstrucciones" runat="server" Text="Instrucciones:" Font-Bold="True" Font-Size="16px"></asp:Label>
                <br />
                <asp:TextBox ID="txtInstrucciones" runat="server" TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox>
                <br />
                <br />
                <div class="container">
                <asp:Label ID="lbEtiquetas" runat="server" Text="Etiquetas:" Font-Bold="True" Font-Size="16px"></asp:Label>
                <asp:CheckBoxList ID="chkEtiquetas" runat="server"></asp:CheckBoxList>
                </div>
                <br />
                <asp:Label ID="lblIngredientes" runat="server" Text="Ingredientes:" Font-Bold="True" Font-Size="16px"></asp:Label>
                <asp:DropDownList ID="ddlIngredientes" runat="server"></asp:DropDownList>
                <asp:Button ID="btnAgregarIngrediente" runat="server" Text="Agregar ingrediente" margin="12px" BackColor="#829949" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Width="180px" display="inline-block"  BorderColor="White" OnClick="btnAgregarIngrediente_Click" />
                <br />
                <br />
                <asp:Label ID="lbIngedientes" runat="server" Text="Agregados:" Font-Bold="True" Font-Size="16px"></asp:Label>
                <asp:ListBox ID="lstIngredientesAgregados" runat="server" SelectionMode="Multiple" style="width: 200px"></asp:ListBox>
                <br />
                <br />
                <asp:Button ID="btnSubirReceta" runat="server" Text="Agregar receta" margin="12px" BackColor="#829949" BorderWidth="4px" border-radius="6px" ForeColor="White" Height="50px" font-size="18px" font="sans-serif" Width="180px" display="inline-block"  BorderColor="White" OnClick="btnSubirReceta_Click" />
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
