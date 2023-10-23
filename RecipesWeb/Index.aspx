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
            margin-top: 20px;
        }

        .btn-nutriologo {
            display: inline-block;
            padding: 10px 20px;
            margin: 10px;
            font-size: 18px;
            background-color: #829949;
            color: #ffffff;
            border: none;
            cursor: pointer;
            border-radius: 5px;
        }

        .btn-usuario {
            display: inline-block;
            padding: 10px 20px;
            margin: 10px;
            font-size: 18px;
            background-color: #e1a144;
            color: #ffffff;
            border: none;
            cursor: pointer;
            border-radius: 5px;
        }

        .btn-nutriologo:hover, .btn-usuario:hover {
            background-color: #000000;
        }
    </style>
    </head>
        <body>
        <div class="container">
            <h1>Bienvenido a Nutrini</h1>
        <div class="buttons">
            <a href="login-nutriologo.html" class="btn-nutriologo">Nutriólogo</a>
            <a href="login-usuario.html" class="btn-usuario">Usuario</a>
        </div>
        </div>
</body>
</html>
