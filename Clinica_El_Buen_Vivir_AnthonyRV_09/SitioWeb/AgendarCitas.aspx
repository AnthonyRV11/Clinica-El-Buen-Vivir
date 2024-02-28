<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="AgendarCitas.aspx.cs" Inherits="SitioWeb.AgendarCitas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><%--Inicio del cuerpo--%>
    <h1 class="p-3 mb-3 bg-primary text-white text-center rounded-pill">Informacion del paciente</h1>
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
            <%--Fin de la validacion--%>            <%--Validacion al nombre--%>
            <div class="col-4">
                Nombre:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtNombre" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
               
            </div>
            <%--Fin de la validacion--%>            <%--Validacion al apellido1--%>
            <div class="col-4">
                Apellido 1:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtApellido1" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
               
            </div>
            <%--Fin de la validacion--%>            <%--Validacion al apellido1--%>
            <div class="col-4">
                Apellido 2:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtApellido2" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
                
            </div>
            <%--Fin de la validacion--%>             <%--Validacion al telefono--%>
            <div class="col-4">
                Telefono:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtTelefono" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
                
            </div>
            <%--Fin de la validacion--%>            <%--Validacion al cedula--%>
            <div class="col-4">
                Cedula:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtCedula" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
                
            </div>
            <%--Fin de la validacion--%>            <%--Validacion a la Correo--%>
            <div class="col-4">
                Correo:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtCorreo" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-4">
                <asp:Button ID="BtnBuscar" runat="server" Height="43px" Text="Buscar" Width="110px" class="btn btn-outline-primary" OnClick="BtnBuscar_Click" />
            &nbsp;<asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" Height="43px" Width="110px" class="btn btn-outline-primary" OnClick="BtnLimpiar_Click" />
            </div>
        <br />
            <br />
            <br />
            <br />
        </div>
        <div>

        </div>
        <div  class="container">
            <center>
            <h1 class="p-3 mb-3 bg-primary text-white text-center rounded-pill">Seleccionar especialidad</h1>
            <div class="col-7">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="150px" class="btn btn-outline-primary" Height="43px">
                    <asp:ListItem Value="1">Dermatologia</asp:ListItem>
                    <asp:ListItem Value="2">Cardiologia</asp:ListItem>
                    <asp:ListItem Value="3">Ortopedia</asp:ListItem>
                    <asp:ListItem Value="4">Oftalmologia</asp:ListItem>
                    <asp:ListItem Value="5">Ginecologia</asp:ListItem>
                    <asp:ListItem Value="6">Neurologia</asp:ListItem>
                    <asp:ListItem Value="7">Odontologia</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp; <asp:Button ID="BtnEspecialidad" runat="server" Text="Ver especialistas" Width="150px" class="btn btn-outline-primary" Height="43px" OnClick="BtnEspecialidad_Click"/>
            </div>
            </center>
        </div>
        <br />
        <center>
            <asp:GridView ID="grdAgenda" runat="server" AutoGenerateColumns="False" Height="220px" Width="893px" AllowPaging="True" PageSize="8" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="grdAgenda_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="ID_AGENDA" HeaderText="Id agenda" />
                    <asp:BoundField DataField="ID_ESPECIALIDAD" HeaderText="Id especialidad" />
                    <asp:BoundField DataField="ID_MEDICO" HeaderText="Id medico" />
                    <asp:BoundField DataField="NOMBRE_MEDICO" HeaderText="Nombre" />
                     <asp:BoundField DataField="HORA_INICIO" HeaderText="Fecha de inicio" />
                    <asp:BoundField DataField="HORA_FIN" HeaderText="Fecha del fin" />
                    <asp:TemplateField HeaderText="Seleccionar">
                        <ItemTemplate>
                            <asp:LinkButton ID="LnkSeleccionar" runat="server" CommandArgument='<%# Eval("ID_AGENDA").ToString() %>' CommandName="Seleccionar"  OnCommand="LnkSeleccionar_Command">Seleccionar</asp:LinkButton>
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


        <asp:Panel ID="PlnAgendaMedico" runat="server" Visible="False">
            <%--Validacion al id agenda--%>
            <div class="col-4">
                Id agenda:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtIdAgenda" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
                
            </div>
            <%--Fin de la validacion--%>
            <%--Validacion al id especialidad--%>
            <div class="col-4">
                Id especialidad:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtIdEspecialidad" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
               
            </div>
            <%--Fin de la validacion--%>
            <%--Validacion al id medico--%>
            <div class="col-4">
                Id medico:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtIdMedico" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
               
            </div>
            <%--Fin de la validacion--%>
            <%--Validacion al Nombre--%>
            <div class="col-4">
                Nombre medico:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtNombreMedico" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
                
            </div>
            <%--Fin de la validacion--%>
             <%--Validacion a la hora de inicio--%>
            <div class="col-4">
                Inicio:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtInicio" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
                
            </div>
            <%--Fin de la validacion--%>
            <%--Validacion a la hora de fin--%>
            <div class="col-4">
                Fin:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtFin" runat="server" Width="100%" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-1">
                
            </div>
            <%--Fin de la validacion--%>
           
        </asp:Panel>


        <br />
        <asp:Panel ID="PlnAgendarCita" runat="server" Visible="False">
            <h1 class="p-3 mb-3 bg-primary text-white text-center rounded-pill">Agendar cita</h1>
              <div class="col-4">
                Seleccione la hora:
            </div>
            <div class="col-7">
                <asp:TextBox ID="TxtHorario" runat="server" class="form-control btn btn-outline-primary" Width="110px" type="time" step="1800"></asp:TextBox>
            </div>
            <div class="col-4">
                <br />
                <asp:Button ID="BtnAgendar" runat="server" Height="43px" Text="Agendar" Width="110px" class="btn btn-outline-danger" OnClick="BtnAgendar_Click" />
            </div>
        </asp:Panel>


</asp:Content><%--Fin del cuerpo--%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoFooter" runat="server">
</asp:Content>
