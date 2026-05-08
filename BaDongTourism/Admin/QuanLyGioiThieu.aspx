<%@ Page Title="Quản Lý Giới Thiệu" Language="C#" MasterPageFile="~/Admin/Admin.Master"
         AutoEventWireup="true" CodeFile="QuanLyGioiThieu.aspx.cs" Inherits="Admin_QuanLyGioiThieu" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="AdminContent" runat="server">

<div class="d-flex justify-content-between align-items-center mb-4">
    <div>
        <h4 class="mb-0 fw-800">Quản Lý Trang Giới Thiệu</h4>
        <small class="text-muted">Chỉnh sửa nội dung trang Giới Thiệu hiển thị trên website</small>
    </div>
    <a href="../GioiThieu.aspx" target="_blank" class="btn btn-outline-primary">
        <i class="fas fa-eye me-2"></i>Xem trang
    </a>
</div>

<asp:Literal ID="lblMsg" runat="server" />

<!-- TABS -->
<ul class="nav nav-tabs mb-4" id="gtTabs">
    <li class="nav-item">
        <a class="nav-link active" href="#tab1" data-bs-toggle="tab"><i class="fas fa-align-left me-2"></i>Nội Dung Chính</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="#tab2" data-bs-toggle="tab"><i class="fas fa-landmark me-2"></i>Văn Hóa & Lịch Sử</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="#tab3" data-bs-toggle="tab"><i class="fas fa-route me-2"></i>Hướng Dẫn Di Chuyển</a>
    </li>
</ul>

<div class="tab-content">

    <!-- TAB 1: NOI DUNG CHINH -->
    <div class="tab-pane fade show active" id="tab1">
        <div class="card border-0 shadow-sm rounded-4 p-4">
            <h5 class="fw-700 mb-4"><i class="fas fa-umbrella-beach me-2 text-primary"></i>Phần Tổng Quan</h5>
            <div class="row g-3">
                <div class="col-12">
                    <label class="form-label fw-600">Tiêu đề chính</label>
                    <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control"
                                 placeholder="VD: Bãi Biển Ba Động – Trà Vinh" />
                </div>
                <div class="col-12">
                    <label class="form-label fw-600">Đoạn văn 1 – Vị trí địa lý</label>
                    <asp:TextBox ID="txtDoan1" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
                <div class="col-12">
                    <label class="form-label fw-600">Đoạn văn 2 – Đặc điểm bãi biển</label>
                    <asp:TextBox ID="txtDoan2" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
                <div class="col-12">
                    <label class="form-label fw-600">Đoạn văn 3 – Đặc sản & điểm nổi bật</label>
                    <asp:TextBox ID="txtDoan3" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
                <div class="col-md-6">
                    <label class="form-label fw-600">Ảnh chính</label>
                    <asp:FileUpload ID="fuHinhChinh" runat="server" CssClass="form-control" />
                    <div class="form-text">Ảnh hiện tại: <asp:Literal ID="litHinhChinh" runat="server" /></div>
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-600">Số liệu 1 (VD: 10km+)</label>
                    <asp:TextBox ID="txtStat1So" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-600">Nhãn số liệu 1</label>
                    <asp:TextBox ID="txtStat1Ten" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-600">Số liệu 2 (VD: 50km)</label>
                    <asp:TextBox ID="txtStat2So" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-600">Nhãn số liệu 2</label>
                    <asp:TextBox ID="txtStat2Ten" runat="server" CssClass="form-control" />
                </div>
                <div class="col-12 text-end">
                    <asp:Button ID="btnLuuTab1" runat="server" Text="💾 Lưu Nội Dung Chính"
                                CssClass="btn btn-primary px-5" OnClick="btnLuuTab1_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- TAB 2: VAN HOA LICH SU -->
    <div class="tab-pane fade" id="tab2">
        <div class="card border-0 shadow-sm rounded-4 p-4">
            <h5 class="fw-700 mb-4"><i class="fas fa-landmark me-2 text-primary"></i>Phần Văn Hóa & Lịch Sử</h5>
            <div class="row g-3">
                <div class="col-12">
                    <label class="form-label fw-600">Tiêu đề phần này</label>
                    <asp:TextBox ID="txtVhlsTieuDe" runat="server" CssClass="form-control"
                                 placeholder="VD: Vùng Đất Con Người" />
                </div>
                <div class="col-12">
                    <label class="form-label fw-600">Đoạn văn 1</label>
                    <asp:TextBox ID="txtVhlsDoan1" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
                <div class="col-12">
                    <label class="form-label fw-600">Đoạn văn 2</label>
                    <asp:TextBox ID="txtVhlsDoan2" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
                <div class="col-12">
                    <label class="form-label fw-600">Đoạn văn 3</label>
                    <asp:TextBox ID="txtVhlsDoan3" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
                <div class="col-md-6">
                    <label class="form-label fw-600">Ảnh minh họa</label>
                    <asp:FileUpload ID="fuHinhVhls" runat="server" CssClass="form-control" />
                    <div class="form-text">Ảnh hiện tại: <asp:Literal ID="litHinhVhls" runat="server" /></div>
                </div>
                <div class="col-12 text-end">
                    <asp:Button ID="btnLuuTab2" runat="server" Text="💾 Lưu Văn Hóa & Lịch Sử"
                                CssClass="btn btn-primary px-5" OnClick="btnLuuTab2_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- TAB 3: HUONG DAN DI CHUYEN -->
    <div class="tab-pane fade" id="tab3">
        <div class="card border-0 shadow-sm rounded-4 p-4">
            <h5 class="fw-700 mb-4"><i class="fas fa-route me-2 text-primary"></i>Hướng Dẫn Di Chuyển</h5>
            <div class="row g-3">
                <div class="col-12">
                    <label class="form-label fw-600"><i class="fas fa-car me-2 text-primary"></i>Từ TP.HCM bằng Xe Ô Tô</label>
                    <asp:TextBox ID="txtDichuyOTo" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
                <div class="col-12">
                    <label class="form-label fw-600"><i class="fas fa-bus me-2 text-primary"></i>Xe Khách / Xe Buýt</label>
                    <asp:TextBox ID="txtDichuyXeKhach" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
                <div class="col-12">
                    <label class="form-label fw-600"><i class="fas fa-motorcycle me-2 text-primary"></i>Xe Máy / Phượt</label>
                    <asp:TextBox ID="txtDichuyXeMay" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
                <div class="col-12 text-end">
                    <asp:Button ID="btnLuuTab3" runat="server" Text="💾 Lưu Hướng Dẫn Di Chuyển"
                                CssClass="btn btn-primary px-5" OnClick="btnLuuTab3_Click" />
                </div>
            </div>
        </div>
    </div>

</div><!-- end tab-content -->

<!-- Giu tab hien tai khi postback -->
<asp:HiddenField ID="hfActiveTab" runat="server" Value="tab1" />
<script>
    // Khi chon tab, luu vao hidden field
    document.querySelectorAll('#gtTabs .nav-link').forEach(function(tab) {
        tab.addEventListener('shown.bs.tab', function(e) {
            document.getElementById('<%= hfActiveTab.ClientID %>').value =
                e.target.getAttribute('href').replace('#','');
        });
    });
    // Mo lai tab da chon sau postback
    window.addEventListener('DOMContentLoaded', function() {
        var activeTab = document.getElementById('<%= hfActiveTab.ClientID %>').value;
        if (activeTab) {
            var tabEl = document.querySelector('#gtTabs a[href="#' + activeTab + '"]');
            if (tabEl) new bootstrap.Tab(tabEl).show();
        }
    });
</script>

</asp:Content>
