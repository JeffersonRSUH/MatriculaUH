<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManejoMaterias.aspx.cs" Inherits="Matricula.ManejoMaterias" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Materias</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="Content/CSS/ManejoMaterias.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server" class="container my-4">
        <div>
            <h1 class="mb-4">Manejo de Materias</h1>

            <asp:GridView ID="GridViewMaterias" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewMaterias_RowCommand" DataKeyNames="IdMateria" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="IdMateria" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Carrera">
                        <ItemTemplate>
                            <asp:Label ID="LblCarrera" runat="server" CssClass="d-block" Text='<%# Eval("Carrera.Carrera") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Materia" HeaderText="Materia" />
                    <asp:BoundField DataField="Creditos" HeaderText="Creditos" />
                    <asp:TemplateField HeaderText="Acción">
                        <ItemTemplate>
                            <asp:Button ID="BtnEdit" runat="server" CssClass="btn btn-warning btn-sm" CommandName="EditMateria" CommandArgument='<%# Eval("IdMateria") %>' Text="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />

            <div class="border p-4 rounded bg-light">
                <asp:HiddenField ID="HiddenFieldIdMateria" runat="server" />

                <div class="mb-3">
                    <asp:Label ID="LblCarrera" runat="server" CssClass="form-label" Text="Carrera:" />
                    <asp:DropDownList ID="DropDownListCarrera" runat="server" CssClass="form-select" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="LblMateria" runat="server" CssClass="form-label" Text="Materia:" />
                    <asp:TextBox ID="TxtMateria" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="LblCreditos" runat="server" CssClass="form-label" Text="Creditos:" />
                    <asp:TextBox ID="TxtCreditos" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Button ID="BtnCrearMateria" runat="server" CssClass="btn btn-primary me-2" Text="Crear Materia" OnClick="BtnCrearMateria_Click" />
                    <asp:Button ID="BtnActualizarMateria" runat="server" CssClass="btn btn-success me-2" Text="Actualizar Materia" OnClick="BtnActualizarMateria_Click" />
                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-outline-secondary" Text="Back" OnClick="BtnBack_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
