<%@ Page Title="Quản Lý Tin Tức" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeFile="QuanLyTinTuc.aspx.cs" Inherits="Admin_QuanLyTinTuc" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" runat="server">

<div class="d-flex justify-content-between align-items-center mb-4">
    <h5 class="fw-bold mb-0"><i class="fas fa-newspaper me-2 text-primary"></i>Quản Lý Tin Tức</h5>
    <button type="button" class="btn btn-primary btn-sm" onclick="showForm()"><i class="fas fa-plus me-1"></i>Thêm Mới</button>
</div>
<asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3" />

<!-- FORM -->
<div class="admin-card mb-4" id="formPanel" runat="server" style="display:none;">
    <div class="admin-card-title" id="formTitle" runat="server">Thêm Bài Viết</div>
    <asp:HiddenField ID="hfMaTT" runat="server" Value="0" />
    <div class="row g-3">
        <div class="col-md-8">
            <label class="form-label fw-600">Tiêu Đề <span class="text-danger">*</span></label>
            <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-4">
            <label class="form-label fw-600">Danh Mục</label>
            <asp:DropDownList ID="ddlDanhMuc" runat="server" CssClass="form-select" />
        </div>
        <div class="col-md-6">
            <label class="form-label fw-600">Hình Ảnh (tên file)</label>
            <asp:TextBox ID="txtHinhAnh" runat="server" CssClass="form-control" placeholder="tintuc1.jpg" />
        </div>
        <div class="col-md-3">
            <label class="form-label fw-600">&nbsp;</label>
            <div class="form-check form-switch mt-3">
                <asp:CheckBox ID="chkNoiBat" runat="server" CssClass="form-check-input" />
                <label class="form-check-label">Nổi Bật</label>
            </div>
        </div>
        <div class="col-12">
            <label class="form-label fw-600">Tóm Tắt</label>
            <asp:TextBox ID="txtTomTat" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" />
        </div>
        <div class="col-12">
            <label class="form-label fw-600">Nội Dung</label>
            <asp:TextBox ID="txtNoiDung" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="8" />
        </div>
        <div class="col-12 d-flex gap-3">
            <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary px-4" OnClick="btnLuu_Click" />
            <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn btn-secondary px-4" OnClick="btnHuy_Click" CausesValidation="false" />
        </div>
    </div>
</div>

<!-- TABLE -->
<div class="admin-card">
    <div class="table-responsive">
        <table class="table table-admin table-hover">
            <thead>
                <tr><th>#</th><th>Tiêu Đề</th><th>Danh Mục</th><th>Ngày Đăng</th><th>Lượt Xem</th><th>Nổi Bật</th><th>Hành Động</th></tr>
            </thead>
            <tbody id="tableBody" runat="server">
                <tr><td colspan="7" class="text-center text-muted py-4">Chưa có bài viết.</td></tr>
            </tbody>
        </table>
    </div>
</div>

</asp:Content>
<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
<script>function showForm(){var fp=document.getElementById('<%=formPanel.ClientID%>');fp.style.display=fp.style.display==='none'?'block':'none';}</script>
</asp:Content>
