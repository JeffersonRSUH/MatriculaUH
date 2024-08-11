<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Matricula.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Admin Management Dashboard</h1><br />
        <div>
            <asp:Button ID="btnStudentManagement" runat="server" Text="Estudiantes" OnClick="btnStudentManagement_Click" />
            <asp:Button ID="btnCarreras" runat="server" Text="Carreras" OnClick="btnCarreras_Click" />
            <asp:Button ID="btnSubjectManagement" runat="server" Text="Materias" OnClick="btnSubjectManagement_Click" />
            <asp:Button ID="btnGroupManagement" runat="server" Text="Grupos" OnClick="btnGroupManagement_Click" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>
