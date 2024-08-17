<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManejoEstudiantes.aspx.cs" Inherits="Matricula.ManejoEstudiantes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Estudiantes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="Content/CSS/ManejoEstudiantes.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center mb-4">Manejo Estudiantil</h1>
            
            <div class="mb-4">
                <h2>Busqueda Estudiante</h2>
                <asp:GridView ID="GridViewStudents" runat="server" AutoGenerateColumns="True" CssClass="table table-striped table-bordered"></asp:GridView>
                <div class="input-group mb-3">
                    <asp:TextBox ID="txtStudentId" runat="server" CssClass="form-control" Placeholder="Enter Student ID"></asp:TextBox>
                    <asp:Button ID="btnSearchStudent" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
                <asp:Label ID="lblStudentInfo" runat="server" CssClass="form-text"></asp:Label>
            </div>
            
            <div class="mb-4">
                <h2>Creacion Estudiante</h2>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre:</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtApellidoPaterno" class="form-label">Apellido Paterno:</label>
                    <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="form-control" placeholder="Apellido Paterno"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtApellidoMaterno" class="form-label">Apellido Materno:</label>
                    <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="form-control" placeholder="Apellido Materno"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtIdentificacion" class="form-label">Identificacion:</label>
                    <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control" placeholder="Identificacion"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtFechaNacimiento" class="form-label">Fecha Nacimiento:</label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" placeholder="Fecha Nacimiento"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtFechaIngreso" class="form-label">Fecha Ingreso:</label>
                    <asp:TextBox ID="txtFechaIngreso" runat="server" CssClass="form-control" placeholder="Fecha Ingreso"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="ddlEstado" class="form-label">Estado:</label>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Activo" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Inactivo" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Graduado" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Matriculado" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlTipoIdentificacion" class="form-label">Tipo Identificacion:</label>
                    <asp:DropDownList ID="ddlTipoIdentificacion" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Cedula" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Pasaporte" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Carnet Residente" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlCarrera" class="form-label">Carrera:</label>
                    <asp:DropDownList ID="ddlCarrera" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <asp:Button CssClass="btn btn-success" ID="btnCrearEstudiante" runat="server" Text="Crear Estudiante" OnClick="btnCrearEstudiante_Click" />
                <asp:Button CssClass="btn btn-outline-secondary" ID="Button1" runat="server" Text="Back" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
