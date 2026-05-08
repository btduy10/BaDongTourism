<%@ Page Title="Tour Du Lịch" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Tour.aspx.cs" Inherits="TourPage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-hero">
    <div class="container">
        <h1><i class="fas fa-map me-3"></i>Tour Du Lịch</h1>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx"><i class="fas fa-home"></i> Trang chủ</a></li>
                <li class="breadcrumb-item active">Tour Du Lịch</li>
            </ol>
        </nav>
    </div>
</div>

<section class="section-py">
    <div class="container">
        <div class="row g-4" id="tourList" runat="server">
            <!-- Render by code-behind -->
        </div>
        <div class="text-center mt-4">
            <asp:Label ID="lblNoData" runat="server" Text="Hiện chưa có tour nào." CssClass="text-muted" Visible="false" />
        </div>
    </div>
</section>

</asp:Content>
