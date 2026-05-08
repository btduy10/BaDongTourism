<%@ Page Title="Quản Lý Lưu Trú" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeFile="QuanLyLuuTru.aspx.cs" Inherits="Admin_QuanLyLuuTru" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" runat="server">

<div class="d-flex justify-content-between align-items-center mb-4">
    <h5 class="fw-bold mb-0"><i class="fas fa-hotel me-2 text-primary"></i>Quản Lý Lưu Trú</h5>
    <button type="button" class="btn btn-primary btn-sm" onclick="showForm()"><i class="fas fa-plus me-1"></i>Thêm Mới</button>
</div>
<asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3" />

<!-- FORM -->
<div class="admin-card mb-4" id="formPanel" runat="server" style="display:none;">
    <div class="admin-card-title" id="formTitle" runat="server">Thêm Cơ Sở Lưu Trú</div>
    <asp:HiddenField ID="hfMaLT" runat="server" Value="0" />
    <div class="row g-3">
        <div class="col-md-8">
            <label class="form-label fw-600">Tên Cơ Sở <span class="text-danger">*</span></label>
            <asp:TextBox ID="txtTen" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-4">
            <label class="form-label fw-600">Loại</label>
            <asp:DropDownList ID="ddlLoai" runat="server" CssClass="form-select">
                <asp:ListItem>Resort</asp:ListItem>
                <asp:ListItem>Khách sạn</asp:ListItem>
                <asp:ListItem>Nhà nghỉ</asp:ListItem>
                <asp:ListItem>Homestay</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-6"><label class="form-label fw-600">Địa Chỉ</label><asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control" /></div>
        <div class="col-md-3"><label class="form-label fw-600">Điện Thoại</label><asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control" /></div>
        <div class="col-md-3"><label class="form-label fw-600">Giá Phòng</label><asp:TextBox ID="txtGia" runat="server" CssClass="form-control" placeholder="200k – 2tr/đêm" /></div>
        <div class="col-md-6"><label class="form-label fw-600">Hình Ảnh (tên file)</label><asp:TextBox ID="txtHinhAnh" runat="server" CssClass="form-control" /></div>
        <div class="col-md-2"><label class="form-label fw-600">Xếp Hạng (sao)</label><asp:TextBox ID="txtXepHang" runat="server" CssClass="form-control" TextMode="Number" Text="3" min="1" max="5" /></div>
        <div class="col-md-2"><label class="form-label fw-600">&nbsp;</label><div class="form-check form-switch mt-3"><asp:CheckBox ID="chkNoiBat" runat="server" CssClass="form-check-input" /><label class="form-check-label">Nổi Bật</label></div></div>
        <div class="col-12"><label class="form-label fw-600">Mô Tả</label><asp:TextBox ID="txtMoTa" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" /></div>
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
            <thead><tr><th>#</th><th>Tên Cơ Sở</th><th>Loại</th><th>Điện Thoại</th><th>Giá Phòng</th><th>Sao</th><th>Hành Động</th></tr></thead>
            <tbody id="tableBody" runat="server"><tr><td colspan="7" class="text-center text-muted py-4">Chưa có dữ liệu.</td></tr></tbody>
        </table>
    </div>
</div>

</asp:Content>
<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
<script>function showForm(){var fp=document.getElementById('<%=formPanel.ClientID%>');fp.style.display=fp.style.display==='none'?'block':'none';}</script>
</asp:Content>
