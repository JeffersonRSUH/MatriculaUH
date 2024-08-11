<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManejoMatricula.aspx.cs" Inherits="Matricula.ManejoMatricula" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Matrícula</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Matricula</h1>
            <h2>Estudiantes</h2>
            <asp:Literal ID="ltEstudiantes" runat="server"></asp:Literal>

            <h2>Grupos</h2>
            <asp:Literal ID="ltGrupos" runat="server"></asp:Literal>

            <h2>Matricular un Curso</h2>
            <asp:Label Text="Estudiante Id" runat="server" />
            <asp:TextBox ID="txtEstudianteId" runat="server" />

            <asp:Label Text="Grupo Id" runat="server" />
            <asp:TextBox ID="txtGrupoId" runat="server" />

            <asp:Button ID="btnMatricular" runat="server" Text="Matricular" OnClick="btnMatricular_Click" />

            <h2>Listado de Matrículas</h2>
            <asp:Literal ID="ltMatriculas" runat="server"></asp:Literal>

            <h2>Desmatricular un Curso</h2>
            <asp:Label Text="Matricula Id" runat="server" />
            <asp:TextBox ID="txtMatriculaId" runat="server" />

            <asp:Button ID="btnDesmatricular" runat="server" Text="Desmatricular" OnClick="btnDesmatricular_Click" /> o
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
