<%@ Page Title="Chi Tiết Tin Tức" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TinTucChiTiet.aspx.cs" Inherits="TinTucChiTiet" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<section class="section-py">
    <div class="container">
        <asp:Panel ID="pnlContent" runat="server">
            <div class="row g-5">
                <div class="col-lg-8">
                    <img id="imgMain" runat="server" src="" alt=""
                         class="img-fluid rounded-4 mb-4" style="width:100%;height:380px;object-fit:cover;" />
                    <div class="detail-meta mb-2">
                        <span><i class="fas fa-tag"></i><span id="lblDanhMuc" runat="server"></span></span>
                        <span><i class="fas fa-calendar"></i><span id="lblNgay" runat="server"></span></span>
                        <span><i class="fas fa-user"></i><span id="lblTacGia" runat="server"></span></span>
                        <span><i class="fas fa-eye"></i><span id="lblLuotXem" runat="server"></span> lượt xem</span>
                    </div>
                    <h1 id="lblTieuDe" runat="server" style="font-family:'Playfair Display',serif;font-size:1.9rem;color:#1a1a2e;" class="mb-4"></h1>
                    <div class="detail-content" id="lblNoiDung" runat="server"></div>
                </div>

                <div class="col-lg-4">
                    <div class="sidebar-card">
                        <div class="sidebar-card-header"><i class="fas fa-newspaper me-2"></i>Tin Tức Khác</div>
                        <div class="sidebar-card-body" id="sidebarTinTuc" runat="server"></div>
                    </div>
                    <div class="sidebar-card mt-4">
                        <div class="sidebar-card-header"><i class="fas fa-map me-2"></i>Khám Phá Tour</div>
                        <div class="sidebar-card-body">
                            <p class="small text-muted mb-3">Hãy trải nghiệm những tour tuyệt vời tại Ba Động!</p>
                            <a href="Tour.aspx" class="btn btn-primary w-100 btn-sm">Xem Tour Ngay</a>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Label ID="lblNotFound" runat="server" Text="Không tìm thấy bài viết." CssClass="text-muted" Visible="false" />
    </div>
</section>

</asp:Content>
