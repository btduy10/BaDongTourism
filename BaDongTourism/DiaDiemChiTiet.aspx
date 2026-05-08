<%@ Page Title="Chi Tiết Địa Điểm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DiaDiemChiTiet.aspx.cs" Inherits="DiaDiemChiTiet" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-hero">
    <div class="container">
        <h1 id="heroTitle" runat="server">Chi Tiết Địa Điểm</h1>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx"><i class="fas fa-home"></i> Trang chủ</a></li>
                <li class="breadcrumb-item"><a href="DiaDiem.aspx">Địa Điểm</a></li>
                <li class="breadcrumb-item active" id="breadTitle" runat="server">Chi Tiết</li>
            </ol>
        </nav>
    </div>
</div>

<section class="section-py">
    <div class="container">
        <asp:Panel ID="pnlContent" runat="server">
            <div class="row g-5">
                <div class="col-lg-8">
                    <img id="imgMain" runat="server" src="" alt="" class="detail-img mb-4" />
                    <div class="detail-meta mb-3">
                        <span><i class="fas fa-map-marker-alt"></i><span id="lblDiaChi" runat="server"></span></span>
                        <span><i class="fas fa-tag"></i><span id="lblDanhMuc" runat="server"></span></span>
                        <span><i class="fas fa-eye"></i><span id="lblLuotXem" runat="server"></span> lượt xem</span>
                    </div>
                    <h2 id="lblTen" runat="server" class="mb-4" style="font-family:'Playfair Display',serif;color:#1a1a2e;"></h2>
                    <div class="detail-content" id="lblMoTa" runat="server"></div>

                    <!-- Map -->
                    <asp:Panel ID="pnlMap" runat="server" CssClass="mt-4">
                        <h5 class="fw-bold mb-3"><i class="fas fa-map me-2 text-primary"></i>Bản Đồ</h5>
                        <div id="mapContent" runat="server"></div>
                    </asp:Panel>
                </div>

                <div class="col-lg-4">
                    <div class="sidebar-card">
                        <div class="sidebar-card-header"><i class="fas fa-map me-2"></i>Địa Điểm Khác</div>
                        <div class="sidebar-card-body" id="sidebarDiaDiem" runat="server"></div>
                    </div>
                    <div class="text-center mt-3">
                        <a href="Tour.aspx" class="btn btn-primary w-100"><i class="fas fa-map me-2"></i>Đặt Tour Tham Quan</a>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Label ID="lblNotFound" runat="server" Text="Không tìm thấy địa điểm." CssClass="text-muted" Visible="false" />
    </div>
</section>

</asp:Content>
