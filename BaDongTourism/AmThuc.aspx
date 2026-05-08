<%@ Page Title="Ẩm Thực" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AmThuc.aspx.cs" Inherits="AmThucPage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-hero">
    <div class="container">
        <h1><i class="fas fa-utensils me-3"></i>Ẩm Thực Địa Phương</h1>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx"><i class="fas fa-home"></i> Trang chủ</a></li>
                <li class="breadcrumb-item active">Ẩm Thực</li>
            </ol>
        </nav>
    </div>
</div>

<section class="section-py">
    <div class="container">
        <div class="row g-4" id="amThucList" runat="server"></div>
        <asp:Label ID="lblNoData" runat="server" Text="Chưa có thông tin ẩm thực." CssClass="text-muted d-block text-center mt-4" Visible="false" />
    </div>
</section>

</asp:Content>
