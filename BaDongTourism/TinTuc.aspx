<%@ Page Title="Tin Tức & Sự Kiện" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TinTuc.aspx.cs" Inherits="TinTucPage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-hero">
    <div class="container">
        <h1><i class="fas fa-newspaper me-3"></i>Tin Tức & Sự Kiện</h1>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx"><i class="fas fa-home"></i> Trang chủ</a></li>
                <li class="breadcrumb-item active">Tin Tức</li>
            </ol>
        </nav>
    </div>
</div>

<section class="section-py">
    <div class="container">
        <div class="row g-4" id="tinTucList" runat="server"></div>
        <asp:Label ID="lblNoData" runat="server" Text="Chưa có tin tức nào." CssClass="text-muted d-block text-center mt-4" Visible="false" />
    </div>
</section>

</asp:Content>
