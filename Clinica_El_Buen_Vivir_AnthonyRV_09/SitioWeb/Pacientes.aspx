<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="SitioWeb.Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="p-3 mb-3 bg-primary text-white text-center rounded-pill">Administrar pacientes</h1>
    <div>
        <center>
            <asp:GridView ID="grdPacientes" runat="server" AutoGenerateColumns="False" Height="309px" Width="1039px" AllowPaging="True" PageSize="8" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="grdPacientes_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="ID_PACIENTE" HeaderText="Id cliente" />
                    <asp:BoundField DataField="NOMBRE_PACIENTE" HeaderText="Nombre" />
                    <asp:BoundField DataField="APELLIDO1" HeaderText="Apellido 1" />
                    <asp:BoundField DataField="APELLIDO2" HeaderText="Apellido 2" />
                     <asp:BoundField DataField="CEDULA" HeaderText="Cedula" />
                    <asp:BoundField DataField="TELEFONO" HeaderText="Telefono" />
                    <asp:BoundField DataField="CORREO" HeaderText="Correo" />

                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="LnkEliminar" runat="server" CommandArgument='<%# Eval("ID_PACIENTE").ToString() %>' CommandName="Eliminar" OnCommand="LnkEliminar_Command">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Modificar">
                        <ItemTemplate>
                            <asp:LinkButton ID="LnkModificar" runat="server" CommandArgument='<%# Eval("ID_PACIENTE").ToString() %>' CommandName="Modificar" OnCommand="LnkModificar_Command">Modificar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Seleccionar">
                        <ItemTemplate>
                            <asp:LinkButton ID="LnkSeleccionar" runat="server" CommandArgument='<%# Eval("ID_PACIENTE").ToString() %>' CommandName="Seleccionar" OnCommand="LnkSeleccionar_Command" >Seleccionar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ver citas">
                        <ItemTemplate>
                            <asp:LinkButton ID="LnkPaciente" runat="server" CommandArgument='<%# Eval("ID_PACIENTE").ToString() %>' CommandName="Paciente" Visible="True" OnCommand="LnkPaciente_Command">Ver citas</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </center>
        </div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server" Width="256px"></asp:TextBox>
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" class="btn btn-outline-primary" OnClick="BtnBuscar_Click" />
        <asp:Button ID="BtnAgregar" runat="server" Text="Agregar cliente" class="btn btn-outline-primary" OnClick="BtnAgregar_Click" />
    <br />
    <br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoFooter" runat="server">
</asp:Content>
