<%@ Page Title="Thư Viện Ảnh" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="GalleryPage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-hero">
    <div class="container">
        <h1><i class="fas fa-images me-3"></i>Thư Viện Ảnh</h1>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx"><i class="fas fa-home"></i> Trang chủ</a></li>
                <li class="breadcrumb-item active">Thư Viện Ảnh</li>
            </ol>
        </nav>
    </div>
</div>

<section class="section-py">
    <div class="container">
        <div class="section-header" data-aos="fade-up">
            <div class="section-subtitle">Gallery</div>
            <h2 class="section-title">Khoảnh Khắc Đẹp Tại Ba Động</h2>
            <div class="section-divider"></div>
        </div>
        <div class="gallery-grid" id="galleryGrid" runat="server"></div>
        <asp:Label ID="lblNoData" runat="server" Text="Chưa có ảnh nào." CssClass="text-muted d-block text-center" Visible="false" />
    </div>
</section>

</asp:Content>
