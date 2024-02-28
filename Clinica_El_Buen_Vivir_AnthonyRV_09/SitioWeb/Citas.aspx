<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="Citas.aspx.cs" Inherits="SitioWeb.Citas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="p-3 mb-3 bg-primary text-white text-center rounded-pill">Ver citas del paciente</h1>

    <di class="container">
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
                <asp:TextBox ID="TxtNombre" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            
            <div class="col-4">
                <asp:Button ID="BtnBuscar" runat="server" Height="43px" Text="Buscar" Width="110px" class="btn btn-outline-primary" OnClick="BtnBuscar_Click" />
            &nbsp;<asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" Height="43px" Width="110px" class="btn btn-outline-primary" OnClick="BtnLimpiar_Click"/>
                &nbsp;</div>
        <br />
            <br />
            <br />
            <br />
        </div>
        <h1 class="p-3 mb-3 bg-primary text-white text-center rounded-pill">Sus citas</h1>
         <center>
            <asp:GridView ID="grdCitas" runat="server" AutoGenerateColumns="False" Height="309px" Width="1039px" AllowPaging="True" PageSize="8" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="No tiene citas agendadas actualmente">
                <Columns>
                    <asp:BoundField DataField="ID_CITA" HeaderText="Id cita" />
                    <asp:BoundField DataField="ID_AGENDA" HeaderText="Id agenda" />
                    <asp:BoundField DataField="ID_PACIENTE" HeaderText="Id paciente" />
                    <asp:BoundField DataField="NOMBRE_PACIENTE" HeaderText="Nombre paciente" />
                     <asp:BoundField DataField="HORARIO" HeaderText="Horario" />
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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoFooter" runat="server">
</asp:Content>
