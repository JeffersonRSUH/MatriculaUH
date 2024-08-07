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
            <asp:GridView ID="GridViewMaterias" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewMaterias_RowCommand">
                <Columns>
                    <asp:BoundField DataField="IdMateria" HeaderText="ID" />
                    <asp:BoundField DataField="Carrera" HeaderText="Carrera" />
                    <asp:BoundField DataField="Materia" HeaderText="Materia" />
                    <asp:ButtonField ButtonType="Button" CommandName="EditMateria" Text="Edit" />
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="HiddenFieldIdMateria" runat="server" />
            <asp:DropDownList ID="DropDownListCarrera" runat="server" />
            <asp:TextBox ID="TxtMateria" runat="server" />
            <asp:Button ID="BtnCrearMateria" runat="server" Text="Crear Materia" OnClick="BtnCrearMateria_Click" />
            <asp:Button ID="BtnActualizarMateria" runat="server" Text="Actualizar Materia" OnClick="BtnActualizarMateria_Click" />
        </div>
    </form>
</body>
</html>
