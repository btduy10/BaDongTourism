<%@ Page Title="Quản Lý Địa Điểm" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeFile="QuanLyDiaDiem.aspx.cs" Inherits="Admin_QuanLyDiaDiem" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" runat="server">

<div class="d-flex justify-content-between align-items-center mb-4">
    <h5 class="fw-bold mb-0"><i class="fas fa-map-pin me-2 text-primary"></i>Quản Lý Địa Điểm</h5>
    <button type="button" class="btn btn-primary btn-sm" onclick="showForm()" id="btnShowForm">
        <i class="fas fa-plus me-1"></i>Thêm Mới
    </button>
</div>

<asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3" />

<!-- FORM THEM/SUA -->
<div class="admin-card mb-4" id="formPanel" runat="server" style="display:none;">
    <div class="admin-card-title" id="formTitle" runat="server">Thêm Địa Điểm Mới</div>
    <asp:HiddenField ID="hfMaDiaDiem" runat="server" Value="0" />
    <div class="row g-3">
        <div class="col-md-8">
            <label class="form-label fw-600">Tên Địa Điểm <span class="text-danger">*</span></label>
            <asp:TextBox ID="txtTen" runat="server" CssClass="form-control" placeholder="VD: Bãi Biển Ba Động" />
        </div>
        <div class="col-md-4">
            <label class="form-label fw-600">Danh Mục</label>
            <asp:DropDownList ID="ddlDanhMuc" runat="server" CssClass="form-select" />
        </div>
        <div class="col-12">
            <label class="form-label fw-600">Địa Chỉ</label>
            <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control" placeholder="Xã Trường Long Hòa, Duyên Hải, Trà Vinh" />
        </div>
        <div class="col-12">
            <label class="form-label fw-600">Mô Tả Ngắn</label>
            <asp:TextBox ID="txtMoTaNgan" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" />
        </div>
        <div class="col-12">
            <label class="form-label fw-600">Mô Tả Chi Tiết</label>
            <asp:TextBox ID="txtMoTaChiTiet" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
        </div>
        <div class="col-md-6">
            <label class="form-label fw-600">Hình Ảnh Đại Diện (tên file)</label>
            <asp:TextBox ID="txtHinhAnh" runat="server" CssClass="form-control" placeholder="badong.jpg" />
        </div>
        <div class="col-md-3">
            <label class="form-label fw-600">Thứ Tự</label>
            <asp:TextBox ID="txtThuTu" runat="server" CssClass="form-control" TextMode="Number" Text="0" />
        </div>
        <div class="col-md-3">
            <label class="form-label fw-600 d-block">&nbsp;</label>
            <div class="form-check form-switch mt-2">
                <asp:CheckBox ID="chkNoiBat" runat="server" CssClass="form-check-input" />
                <label class="form-check-label">Nổi Bật</label>
            </div>
        </div>
        <div class="col-12 d-flex gap-3">
            <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary px-4" OnClick="btnLuu_Click" />
            <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn btn-secondary px-4" OnClick="btnHuy_Click" CausesValidation="false" />
        </div>
    </div>
</div>

<!-- DANH SACH -->
<div class="admin-card">
    <div class="table-responsive">
        <table class="table table-admin table-hover">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Tên Địa Điểm</th>
                    <th>Danh Mục</th>
                    <th>Địa Chỉ</th>
                    <th>Lượt Xem</th>
                    <th>Nổi Bật</th>
                    <th>Hành Động</th>
                </tr>
            </thead>
            <tbody id="tableBody" runat="server">
                <tr><td colspan="7" class="text-center text-muted py-4">Chưa có dữ liệu.</td></tr>
            </tbody>
        </table>
    </div>
</div>

</asp:Content>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
<script>
function showForm() {
    var fp = document.getElementById('<%=formPanel.ClientID%>');
    fp.style.display = fp.style.display === 'none' ? 'block' : 'none';
}
</script>
</asp:Content>
