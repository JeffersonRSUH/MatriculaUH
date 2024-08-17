<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDashboard.aspx.cs" Inherits="Matricula.StudentDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student - Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="Content/CSS/StudentDashboard.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server" class="container my-4">
        <div class="text-center">
            <h1 class="mb-4">Student Dashboard</h1>

            <asp:Button ID="btnMatricula" runat="server" CssClass="btn btn-primary btn-lg me-2" Text="Matricula" OnClick="btnMatricula_Click" />
            <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-outline-danger btn-lg" Text="Logout" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>
