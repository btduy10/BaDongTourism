<%@ Page Title="Địa Điểm Tham Quan" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DiaDiem.aspx.cs" Inherits="DiaDiemPage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-hero">
    <div class="container">
        <h1><i class="fas fa-map-pin me-3"></i>Địa Điểm Tham Quan</h1>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx"><i class="fas fa-home"></i> Trang chủ</a></li>
                <li class="breadcrumb-item active">Địa Điểm</li>
            </ol>
        </nav>
    </div>
</div>

<section class="section-py">
    <div class="container">
        <div class="row g-4" id="diaDiemList" runat="server"></div>
        <asp:Label ID="lblNoData" runat="server" Text="Chưa có địa điểm nào." CssClass="text-muted d-block text-center mt-4" Visible="false" />
    </div>
</section>

</asp:Content>
