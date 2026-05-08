<%@ Page Title="Quản Lý Banner" Language="C#" MasterPageFile="~/Admin/Admin.Master"
         AutoEventWireup="true" CodeFile="QuanLyBanner.aspx.cs" Inherits="Admin_QuanLyBanner" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="AdminContent" runat="server">

<div class="d-flex justify-content-between align-items-center mb-4">
    <div>
        <h4 class="mb-0 fw-800">Quản Lý Banner Trang Chủ</h4>
        <small class="text-muted">Quản lý slider ảnh hiển thị trên trang chủ</small>
    </div>
    <button class="btn btn-primary" onclick="document.getElementById('formPanel').style.display='block';return false;">
        <i class="fas fa-plus me-2"></i>Thêm Banner
    </button>
</div>

<!-- Thong bao -->
<asp:Literal ID="lblMsg" runat="server" />

<!-- FORM THEM / SUA -->
<div id="formPanel" runat="server" style="display:none;" class="card border-0 shadow-sm rounded-4 mb-4">
    <div class="card-body p-4">
        <h5 class="fw-700 mb-3" id="formTitle" runat="server">Thêm Banner Mới</h5>
        <asp:HiddenField ID="hfMaBanner" runat="server" Value="0" />
        <div class="row g-3">
            <div class="col-md-8">
                <label class="form-label fw-600">Tiêu đề banner</label>
                <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control" placeholder="VD: Khám Phá Bãi Biển Ba Động" />
            </div>
            <div class="col-md-4">
                <label class="form-label fw-600">Thứ tự hiển thị</label>
                <asp:TextBox ID="txtThuTu" runat="server" CssClass="form-control" Text="0" />
            </div>
            <div class="col-12">
                <label class="form-label fw-600">Mô tả ngắn (hiển thị dưới tiêu đề)</label>
                <asp:TextBox ID="txtMoTa" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"
                             placeholder="VD: Bãi biển hoang sơ dài hơn 10km – nơi cát trắng, sóng xanh..." />
            </div>
            <div class="col-md-8">
                <label class="form-label fw-600">Tên file ảnh nền</label>
                <asp:TextBox ID="txtHinhAnh" runat="server" CssClass="form-control"
                             placeholder="VD: banner1.jpg (ảnh phải upload vào Content/images/uploads/)" />
                <div class="form-text">Ảnh nên có tỷ lệ 16:9, kích thước tối thiểu 1920×700px</div>
            </div>
            <div class="col-md-4">
                <label class="form-label fw-600">Đường dẫn nút CTA</label>
                <asp:TextBox ID="txtLienKet" runat="server" CssClass="form-control" placeholder="VD: Tour.aspx hoặc DatTour.aspx" />
            </div>
            <div class="col-md-6">
                <label class="form-label fw-600">Upload ảnh banner</label>
                <asp:FileUpload ID="fuAnh" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-6 d-flex align-items-end">
                <div class="form-check">
                    <asp:CheckBox ID="chkTrangThai" runat="server" CssClass="form-check-input" Checked="true" />
                    <label class="form-check-label fw-600">Hiển thị banner này</label>
                </div>
            </div>
        </div>
        <div class="mt-4 d-flex gap-2">
            <asp:Button ID="btnLuu" runat="server" Text="Lưu Banner" CssClass="btn btn-primary px-4" OnClick="btnLuu_Click" />
            <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn btn-outline-secondary px-4" OnClick="btnHuy_Click" />
        </div>
    </div>
</div>

<!-- PREVIEW BANNER HIEN TAI -->
<div class="card border-0 shadow-sm rounded-4">
    <div class="card-body p-4">
        <h5 class="fw-700 mb-3"><i class="fas fa-images me-2 text-primary"></i>Danh Sách Banner</h5>
        <div class="row g-3" id="bannerList" runat="server">
        </div>
    </div>
</div>

</asp:Content>
