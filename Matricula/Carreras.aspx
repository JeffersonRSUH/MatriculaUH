<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carreras.aspx.cs" Inherits="Matricula.Carreras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Carreras</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="Content/CSS/Carreras.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server" class="container my-4">
        <div id="divCarreras" runat="server">
            <div class="mb-3">
                <asp:Label ID="Label1" runat="server" CssClass="form-label" Text="Carrera:"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnInsertaCarrera" runat="server" CssClass="btn btn-primary me-2" Text="Insertar" OnClick="btnInsertaCarrera_Click"/>
                <asp:Button ID="btnUpdateCarrera" runat="server" CssClass="btn btn-secondary me-2" Text="Actualizar" OnClick="btnUpdateCarrera_Click"/>
                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-light" Text="Back" OnClick="btnBack_Click" />
            </div>
            <h1>Listado carreras:</h1>
            <br />
        </div>
    </form>
</body>
</html>
