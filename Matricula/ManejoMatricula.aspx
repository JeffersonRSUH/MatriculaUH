<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManejoMatricula.aspx.cs" Inherits="Matricula.ManejoMatricula" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Matrícula</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="Content/CSS/ManejoMatricula.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container py-4">
            <h1 class="mb-4">Matricula</h1>

            <h2>Estudiantes</h2>
            <asp:Literal ID="ltEstudiantes" runat="server" />

            <h2>Grupos</h2>
            <asp:Literal ID="ltGrupos" runat="server" />

            <h2>Matricular un Curso</h2>
            <div class="mb-3">
                <label for="txtEstudianteId" class="form-label">Estudiante Id</label>
                <asp:TextBox ID="txtEstudianteId" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtGrupoId" class="form-label">Grupo Id</label>
                <asp:TextBox ID="txtGrupoId" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnMatricular" runat="server" CssClass="btn btn-primary me-2" Text="Matricular" OnClick="btnMatricular_Click" />

            <h2 class="mt-4">Listado de Matrículas</h2>
            <asp:Literal ID="ltMatriculas" runat="server" />

            <h2 class="mt-4">Desmatricular un Curso</h2>
            <div class="mb-3">
                <label for="txtMatriculaId" class="form-label">Matricula Id</label>
                <asp:TextBox ID="txtMatriculaId" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnDesmatricular" runat="server" CssClass="btn btn-danger me-2" Text="Desmatricular" OnClick="btnDesmatricular_Click" />
            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary" Text="Back" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
