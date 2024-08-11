<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDashboard.aspx.cs" Inherits="Matricula.StudentDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student - Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Estudiantes</h1>
            <asp:Button ID="btnMatricula" runat="server" Text="Matricula" OnClick="btnMatricula_Click" />
        </div>
    </form>
</body>
</html>
