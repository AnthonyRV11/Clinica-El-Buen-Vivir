<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SitioWeb.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="p-3 mb-3 bg-primary text-white text-center rounded-pill"> Clinica el buen vivir</h1>
  <div id="carouselExampleControlsNoTouching" class="carousel slide" data-bs-touch="false">
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="Images/Cardiologia.png" class="d-block w-100" alt="Cardiologia" width="75%">
    </div>
    <div class="carousel-item">
      <img src="Images/Dermatologia.jpg" class="d-block w-100" alt="Dermatologia" width="75%">
    </div>
    <div class="carousel-item">
      <img src="Images/Ginecologia.jpg" class="d-block w-100" alt="Ginecologia" width="75%">
    </div>
    <div class="carousel-item">
      <img src="Images/Neurologia.jpg" class="d-block w-100" alt="Neurologia" width="75%">
    </div>
    <div class="carousel-item">
      <img src="Images/odontologia.jpg" class="d-block w-100" alt="Odontologia" width="75%">
    </div>
    <div class="carousel-item">
      <img src="Images/Oftalmologia.jpg" class="d-block w-100" alt="Oftalmologia" width="75%">
    </div>
    <div class="carousel-item">
      <img src="Images/ortopedia.jpg" class="d-block w-100" alt="Ortopedia" width="75%">
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControlsNoTouching" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControlsNoTouching" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoFooter" runat="server">
</asp:Content>
