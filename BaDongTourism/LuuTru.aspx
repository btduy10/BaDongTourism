<%@ Page Title="Lưu Trú" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="LuuTru.aspx.cs" Inherits="LuuTruPage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-hero">
    <div class="container">
        <h1><i class="fas fa-hotel me-3"></i>Lưu Trú</h1>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx"><i class="fas fa-home"></i> Trang chủ</a></li>
                <li class="breadcrumb-item active">Lưu Trú</li>
            </ol>
        </nav>
    </div>
</div>

<section class="section-py">
    <div class="container">
        <div class="row g-4" id="luuTruList" runat="server"></div>
        <asp:Label ID="lblNoData" runat="server" Text="Chưa có cơ sở lưu trú nào." CssClass="text-muted d-block text-center mt-4" Visible="false" />
    </div>
</section>

</asp:Content>
