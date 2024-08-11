﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carreras.aspx.cs" Inherits="Matricula.Carreras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Carreras</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divCarreras" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Carrera:">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></asp:Label>
                <asp:Button ID="btnInsertaCarrera" runat="server" Text="Insertar" OnClick="btnInsertaCarrera_Click"/>
                <asp:Button ID="btnUpdateCarrera" runat="server" Text="Actualizar" OnClick="btnUpdateCarrera_Click"/>
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            <br />
            <h1>Listado carreras:</h1><br />

        </div>
    </form>
</body>
</html>
