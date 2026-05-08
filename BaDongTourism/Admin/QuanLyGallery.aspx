<%@ Page Title="Quản Lý Thư Viện Ảnh" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeFile="QuanLyGallery.aspx.cs" Inherits="Admin_QuanLyGallery" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" runat="server">

<div class="d-flex justify-content-between align-items-center mb-4">
    <h5 class="fw-bold mb-0"><i class="fas fa-images me-2 text-primary"></i>Quản Lý Thư Viện Ảnh</h5>
</div>
<asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3" />

<!-- FORM UPLOAD -->
<div class="admin-card mb-4">
    <div class="admin-card-title">Thêm Ảnh Mới</div>
    <div class="row g-3">
        <div class="col-md-6">
            <label class="form-label fw-600">Chọn File Ảnh <span class="text-danger">*</span></label>
            <asp:FileUpload ID="fuAnh" runat="server" CssClass="form-control" accept="image/*" />
        </div>
        <div class="col-md-6">
            <label class="form-label fw-600">Tiêu Đề</label>
            <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control" placeholder="Mô tả ảnh..." />
        </div>
        <div class="col-md-4">
            <label class="form-label fw-600">Danh Mục</label>
            <asp:TextBox ID="txtDanhMuc" runat="server" CssClass="form-control" placeholder="Phong cảnh / Ẩm thực / ..." />
        </div>
        <div class="col-md-2">
            <label class="form-label fw-600">Thứ Tự</label>
            <asp:TextBox ID="txtThuTu" runat="server" CssClass="form-control" TextMode="Number" Text="0" />
        </div>
        <div class="col-12">
            <asp:Button ID="btnUpload" runat="server" Text="Upload Ảnh" CssClass="btn btn-primary px-4" OnClick="btnUpload_Click" />
        </div>
    </div>
</div>

<!-- DANH SACH ANH -->
<div class="admin-card">
    <div class="admin-card-title">Danh Sách Ảnh</div>
    <div class="row g-3" id="galleryList" runat="server">
        <p class="text-muted">Chưa có ảnh nào.</p>
    </div>
</div>

</asp:Content>
