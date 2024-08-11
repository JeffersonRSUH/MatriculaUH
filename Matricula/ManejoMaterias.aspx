<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManejoMaterias.aspx.cs" Inherits="Matricula.ManejoMaterias" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Materias</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Manejo de Materias</h1>
        <div>
        <asp:GridView ID="GridViewMaterias" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewMaterias_RowCommand" DataKeyNames="IdMateria">
            <Columns>
                <asp:BoundField DataField="IdMateria" HeaderText="ID" />
                <asp:TemplateField HeaderText="Carrera">
                    <ItemTemplate>
                        <asp:Label ID="LblCarrera" runat="server" Text='<%# Eval("Carrera.Carrera") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Materia" HeaderText="Materia" />
                <asp:BoundField DataField="Creditos" HeaderText="Créditos" />
                <asp:TemplateField HeaderText="Acción">
            <ItemTemplate>
                <asp:Button ID="BtnEdit" runat="server" CommandName="EditMateria" CommandArgument='<%# Eval("IdMateria") %>' Text="Edit" />
            </ItemTemplate>
        </asp:TemplateField>

            </Columns>
        </asp:GridView>


        <asp:HiddenField ID="HiddenFieldIdMateria" runat="server" />
        <asp:DropDownList ID="DropDownListCarrera" runat="server" />
        <asp:TextBox ID="TxtMateria" runat="server" />
        <asp:TextBox ID="TxtCreditos" runat="server" />
        <asp:Button ID="BtnCrearMateria" runat="server" Text="Crear Materia" OnClick="BtnCrearMateria_Click" />
        <asp:Button ID="BtnActualizarMateria" runat="server" Text="Actualizar Materia" OnClick="BtnActualizarMateria_Click" />

        </div>
    </form>
</body>
</html>
