<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="AdministrarPacientes.aspx.cs" Inherits="SitioWeb.AdministrarPacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="p-3 mb-3 bg-primary text-white text-center rounded-pill">Modificar o agregar paciente</h1>
     <div class="container">
        <div  class="row">

            <%--Validacion al id--%>
            <div class="col-4">
                Id:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtId" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
                
            </div>
            <%--Fin de la validacion--%>

            <%--Validacion al nombre--%>
            <div class="col-4">
                Nombre:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtNombre" runat="server" Width="100%" class="form-control">

                </asp:TextBox>
            </div>
            <div class="col-1">
                <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="El nombre debe de ser un texto" MaximumValue="z" MinimumValue="A" ValidationGroup="ValidarFormulario" ControlToValidate="TxtNombre">*</asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNombre" ErrorMessage="El nombre es requerido" ValidationGroup="ValidarFormulario" class="text-danger">*</asp:RequiredFieldValidator>
            </div>
            <%--Fin de la validacion--%>

            <%--Validacion al apellido1--%>
            <div class="col-4">
                Apellido 1:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtApellido1" runat="server" Width="100%" class="form-control">

                </asp:TextBox>
            </div>
            <div class="col-1">
                <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="El apellido debe de ser un texto" MaximumValue="z" MinimumValue="A" ValidationGroup="ValidarFormulario" ControlToValidate="TxtApellido1">*</asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtApellido1" ErrorMessage="El apellido es requerido" ValidationGroup="ValidarFormulario" class="text-danger">*</asp:RequiredFieldValidator>
            </div>
            <%--Fin de la validacion--%>

            <%--Validacion al apellido1--%>
            <div class="col-4">
                Apellido 2:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtApellido2" runat="server" Width="100%" class="form-control">

                </asp:TextBox>
            </div>
            <div class="col-1">
                <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="El apellido debe de ser un texto" MaximumValue="z" MinimumValue="A" ValidationGroup="ValidarFormulario" ControlToValidate="TxtApellido2">*</asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtApellido1" ErrorMessage="El apellido es requerido" ValidationGroup="ValidarFormulario" class="text-danger">*</asp:RequiredFieldValidator>
            </div>
            <%--Fin de la validacion--%>

             <%--Validacion al telefono--%>
            <div class="col-4">
                Telefono:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtTelefono" runat="server" Width="100%" class="form-control">

                </asp:TextBox>
            </div>
            <div class="col-1">   
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtTelefono" ErrorMessage="El telefono es requerido" ValidationGroup="ValidarFormulario" class="text-danger">*</asp:RequiredFieldValidator>
            </div>
            <%--Fin de la validacion--%>

            <%--Validacion al cedula--%>
            <div class="col-4">
                Cedula:
            </div>
            <div class="col-7">

                <asp:TextBox ID="TxtCedula" runat="server" Width="100%" class="form-control" ReadOnly="False"></asp:TextBox>
            </div>
            <div class="col-1">

                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtCedula" ErrorMessage="La cedula es requerida" ValidationGroup="ValidarFormulario" class="text-danger">*</asp:RequiredFieldValidator>
            </div>
            <%--Fin de la validacion--%>

            <%--Validacion a la Correo--%>
            <div class="col-4">
                Correo:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtCorreo" runat="server" Width="100%" class="form-control">

                </asp:TextBox>
            </div>
            <div class="col-1">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="El correo electronico es invalido EJEMPLO(anthony@gmail.com)" ControlToValidate="TxtCorreo" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ValidarFormulario">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtCorreo" ErrorMessage="El correo es requerido" ValidationGroup="ValidarFormulario" class="text-danger">*</asp:RequiredFieldValidator>
            </div>
            <%--Fin de la validacion--%>
            <br />
        <br />
        <asp:Button ID="BtnGuardar" runat="server" Height="43px" Text="Guardar" Width="110px" ValidationGroup="ValidarFormulario" class="btn btn-outline-primary" OnClick="BtnGuardar_Click" />
            &nbsp;<br />
        <asp:Button ID="BtnCancelar" runat="server" Height="43px" Text="Cancelar" Width="98px" class="btn btn-outline-primary" OnClick="BtnCancelar_Click" />
       </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidarFormulario" class="text-danger"/>
     </div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoFooter" runat="server">
</asp:Content>
