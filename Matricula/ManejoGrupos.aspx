<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManejoGrupos.aspx.cs" Inherits="Matricula.ManejoGrupos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Grupos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Manejo de Grupos</h2>

            <label for="txtNumeroGrupo">Número de Grupo:</label>
            <asp:TextBox ID="txtNumeroGrupo" runat="server"></asp:TextBox>
            <br />

            <label for="txtCupo">Cupo:</label>
            <asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>
            <br />

            <label for="ddlMateria">Materia:</label>
            <asp:DropDownList ID="ddlMateria" runat="server"></asp:DropDownList>
            <br />

            <label for="ddlHorario">Horario:</label>
            <asp:DropDownList ID="ddlHorario" runat="server"></asp:DropDownList>
            <br />

            <label for="ddlEstado">Estado:</label>
            <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
            <br />

            <asp:Button ID="btnCrearGrupo" runat="server" Text="Crear Grupo" OnClick="btnCrearGrupo_Click" /> o
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            <br />

            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <br />

            <asp:GridView ID="gvGrupos" runat="server" AutoGenerateColumns="false">
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
