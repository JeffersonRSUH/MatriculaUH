<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Matricula.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="Content/CSS/AdminDashboard.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body class="d-flex align-items-center justify-content-center vh-100">
    <form id="form1" runat="server" class="text-center">
        <h1 class="mb-4">Admin Dashboard</h1>
        <div class="row g-3 justify-content-center">
            <div class="col-12 col-md-6 col-lg-4">
                <asp:Button ID="btnStudentManagement" runat="server" Text="Estudiantes" CssClass="btn btn-primary btn-lg w-100" OnClick="btnStudentManagement_Click" />
            </div>
            <div class="col-12 col-md-6 col-lg-4">
                <asp:Button ID="btnCarreras" runat="server" Text="Carreras" CssClass="btn btn-secondary btn-lg w-100" OnClick="btnCarreras_Click" />
            </div>
            <div class="col-12 col-md-6 col-lg-4">
                <asp:Button ID="btnSubjectManagement" runat="server" Text="Materias" CssClass="btn btn-success btn-lg w-100" OnClick="btnSubjectManagement_Click" />
            </div>
            <div class="col-12 col-md-6 col-lg-4">
                <asp:Button ID="btnGroupManagement" runat="server" Text="Grupos" CssClass="btn btn-info btn-lg w-100" OnClick="btnGroupManagement_Click" />
            </div>
            <div class="col-12 col-md-6 col-lg-4">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger btn-lg w-100" OnClick="btnLogout_Click" />
            </div>
        </div>
    </form>
</body>
</html>
