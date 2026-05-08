<%@ Page Title="Quản Lý Tour" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeFile="QuanLyTour.aspx.cs" Inherits="Admin_QuanLyTour" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" runat="server">

<div class="d-flex justify-content-between align-items-center mb-4">
    <h5 class="fw-bold mb-0"><i class="fas fa-map me-2 text-primary"></i>Quản Lý Tour Du Lịch</h5>
    <button type="button" class="btn btn-primary btn-sm" onclick="showForm()"><i class="fas fa-plus me-1"></i>Thêm Mới</button>
</div>

<asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3" />

<!-- FORM -->
<div class="admin-card mb-4" id="formPanel" runat="server" style="display:none;">
    <div class="admin-card-title" id="formTitle" runat="server">Thêm Tour Mới</div>
    <asp:HiddenField ID="hfMaTour" runat="server" Value="0" />
    <div class="row g-3">
        <div class="col-md-8">
            <label class="form-label fw-600">Tên Tour <span class="text-danger">*</span></label>
            <asp:TextBox ID="txtTen" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-4">
            <label class="form-label fw-600">Thời Gian</label>
            <asp:TextBox ID="txtThoiGian" runat="server" CssClass="form-control" placeholder="1 ngày / 2N1Đ" />
        </div>
        <div class="col-md-6">
            <label class="form-label fw-600">Địa Điểm</label>
            <asp:TextBox ID="txtDiaDiem" runat="server" CssClass="form-control" placeholder="Ba Động, Trà Vinh" />
        </div>
        <div class="col-md-3">
            <label class="form-label fw-600">Giá Người Lớn (đ)</label>
            <asp:TextBox ID="txtGiaNL" runat="server" CssClass="form-control" TextMode="Number" Text="0" />
        </div>
        <div class="col-md-3">
            <label class="form-label fw-600">Giá Trẻ Em (đ)</label>
            <asp:TextBox ID="txtGiaTE" runat="server" CssClass="form-control" TextMode="Number" Text="0" />
        </div>
        <div class="col-md-3">
            <label class="form-label fw-600">Số Chỗ Tối Đa</label>
            <asp:TextBox ID="txtSoCho" runat="server" CssClass="form-control" TextMode="Number" Text="20" />
        </div>
        <div class="col-md-3">
            <label class="form-label fw-600">Hình Ảnh (tên file)</label>
            <asp:TextBox ID="txtHinhAnh" runat="server" CssClass="form-control" placeholder="tour1.jpg" />
        </div>
        <div class="col-md-3">
            <label class="form-label fw-600">&nbsp;</label>
            <div class="form-check form-switch mt-3">
                <asp:CheckBox ID="chkNoiBat" runat="server" CssClass="form-check-input" />
                <label class="form-check-label">Nổi Bật</label>
            </div>
        </div>
        <div class="col-md-3">
            <label class="form-label fw-600">&nbsp;</label>
            <div class="form-check form-switch mt-3">
                <asp:CheckBox ID="chkTrangThai" runat="server" CssClass="form-check-input" Checked="true" />
                <label class="form-check-label">Hiển Thị</label>
            </div>
        </div>
        <div class="col-12">
            <label class="form-label fw-600">Mô Tả Ngắn</label>
            <asp:TextBox ID="txtMoTaNgan" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" />
        </div>
        <div class="col-12">
            <label class="form-label fw-600">Mô Tả Chi Tiết</label>
            <asp:TextBox ID="txtMoTaChiTiet" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
        </div>
        <div class="col-md-4">
            <label class="form-label fw-600">Lịch Khởi Hành</label>
            <asp:TextBox ID="txtLich" runat="server" CssClass="form-control" placeholder="Thứ 7, Chủ nhật hàng tuần" />
        </div>
        <div class="col-md-4">
            <label class="form-label fw-600">Bao Gồm</label>
            <asp:TextBox ID="txtBaoGom" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
        </div>
        <div class="col-md-4">
            <label class="form-label fw-600">Không Bao Gồm</label>
            <asp:TextBox ID="txtKhongBaoGom" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
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
                <tr><th>#</th><th>Tên Tour</th><th>Thời Gian</th><th>Giá NL</th><th>Giá TE</th><th>Lượt Xem</th><th>Nổi Bật</th><th>Hành Động</th></tr>
            </thead>
            <tbody id="tableBody" runat="server">
                <tr><td colspan="8" class="text-center text-muted py-4">Chưa có tour nào.</td></tr>
            </tbody>
        </table>
    </div>
</div>

</asp:Content>
<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
<script>function showForm(){var fp=document.getElementById('<%=formPanel.ClientID%>');fp.style.display=fp.style.display==='none'?'block':'none';}</script>
</asp:Content>
