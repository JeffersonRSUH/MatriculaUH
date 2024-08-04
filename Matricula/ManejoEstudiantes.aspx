<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManejoEstudiantes.aspx.cs" Inherits="Matricula.ManejoEstudiantes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Manejo Estudiantil</h1><br />
        <div>
            <h2>Busqueda Estudiante</h2>
            <asp:GridView ID="GridViewStudents" runat="server" AutoGenerateColumns="True"></asp:GridView>
            <asp:TextBox ID="txtStudentId" runat="server" Placeholder="Enter Student ID"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Label ID="lblStudentInfo" runat="server" Text=""></asp:Label>
        </div> <br />
        
        <div>
            <h2>Creacion Estudiante</h2>
            <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Apellido Paterno:"></asp:Label>
            <asp:TextBox ID="txtApellidoPaterno" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Apellido Materno:"></asp:Label>
            <asp:TextBox ID="txtApellidoMaterno" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Identificacion:"></asp:Label>
            <asp:TextBox ID="txtIdentificacion" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Fecha Nacimiento:"></asp:Label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Fecha Ingreso:"></asp:Label>
            <asp:TextBox ID="txtFechaIngreso" runat="server"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="Estado:"></asp:Label>
            <asp:DropDownList ID="ddlEstado" runat="server">
                <asp:ListItem Text="Activo" Value="0"></asp:ListItem>
                <asp:ListItem Text="Inactivo" Value="1"></asp:ListItem>
                <asp:ListItem Text="Graduado" Value="2"></asp:ListItem>
                <asp:ListItem Text="Matriculado" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label8" runat="server" Text="Tipo Identificacion:"></asp:Label>
            <asp:DropDownList ID="ddlTipoIdentificacion" runat="server">
                <asp:ListItem Text="Cedula" Value="0"></asp:ListItem>
                <asp:ListItem Text="Pasaporte" Value="1"></asp:ListItem>
                <asp:ListItem Text="Carnet Residente" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label9" runat="server" Text="Carrera:"></asp:Label>
            <asp:DropDownList ID="ddlCarrera" runat="server"></asp:DropDownList>
            <asp:Button ID="btnCrearEstudiante" runat="server" Text="Crear Estudiante" OnClick="btnCrearEstudiante_Click" />
        </div><br />
        
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    </form>
</body>
</html>
