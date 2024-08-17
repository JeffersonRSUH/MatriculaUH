<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManejoGrupos.aspx.cs" Inherits="Matricula.ManejoGrupos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Grupos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="Content/CSS/ManejoGrupos.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server" class="container my-4">
        <div>
            <h2 class="mb-4">Manejo de Grupos</h2>

            <div class="mb-3">
                <label for="txtNumeroGrupo" class="form-label">Número de Grupo:</label>
                <asp:TextBox ID="txtNumeroGrupo" runat="server" CssClass="form-control" placeholder="Numero Grupo"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtCupo" class="form-label">Cupo:</label>
                <asp:TextBox ID="txtCupo" runat="server" CssClass="form-control" placeholder="Cupo"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="ddlMateria" class="form-label">Materia:</label>
                <asp:DropDownList ID="ddlMateria" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddlHorario" class="form-label">Horario:</label>
                <asp:DropDownList ID="ddlHorario" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddlEstado" class="form-label">Estado:</label>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Button ID="btnCrearGrupo" runat="server" CssClass="btn btn-primary me-2" Text="Crear Grupo" OnClick="btnCrearGrupo_Click" />
                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary" Text="Back" OnClick="btnBack_Click" />
            </div>

            <asp:Label ID="lblMessage" runat="server" CssClass="d-block mb-3"></asp:Label>

            <asp:GridView ID="gvGrupos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="IdGrupo" HeaderText="ID Grupo" />
                    <asp:BoundField DataField="NumeroGrupo" HeaderText="Número de Grupo" />
                    <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                    <asp:BoundField DataField="Materia" HeaderText="Materia" />
                    <asp:BoundField DataField="Horario" HeaderText="Horario" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
