<%@ Page Title="Quản Lý Trang Chủ" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeFile="QuanLyTrangChu.aspx.cs" Inherits="Admin_QuanLyTrangChu" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" runat="server">

<asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-4" />
<asp:HiddenField ID="hfActiveTab" runat="server" Value="tab1" />

<!-- TABS -->
<ul class="nav nav-tabs mb-0" style="border-bottom:2px solid #dee2e6;">
    <li class="nav-item">
        <a class="nav-link" href="#" onclick="setTab('tab1');return false;" id="linkTab1">
            <i class="fas fa-info-circle me-1"></i>Về Chúng Tôi
        </a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="#" onclick="setTab('tab2');return false;" id="linkTab2">
            <i class="fas fa-chart-bar me-1"></i>Thống Kê
        </a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="#" onclick="setTab('tab3');return false;" id="linkTab3">
            <i class="fas fa-bullhorn me-1"></i>Lời Kêu Gọi (CTA)
        </a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="#" onclick="setTab('tab4');return false;" id="linkTab4">
            <i class="fas fa-image me-1"></i>Banner Ẩm Thực &amp; Lưu Trú
        </a>
    </li>
</ul>

<!-- ===== TAB 1: VE CHUNG TOI ===== -->
<div id="pnlTab1" class="admin-card" style="border-radius:0 8px 8px 8px;">
    <div class="admin-card-title"><i class="fas fa-info-circle me-2"></i>Phần "Về Chúng Tôi" trên Trang Chủ</div>

    <div class="row g-3">
        <div class="col-md-4">
            <label class="form-label fw-600">Nhãn phụ <small class="text-muted">(subtitle)</small></label>
            <asp:TextBox ID="txtSubtitle" runat="server" CssClass="form-control" placeholder="Về Chúng Tôi" />
        </div>
        <div class="col-md-8">
            <label class="form-label fw-600">Tiêu đề chính <small class="text-muted">(mỗi dòng = 1 dòng hiển thị)</small></label>
            <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"
                placeholder="Viên Ngọc Xanh&#10;Của Trà Vinh" />
        </div>
        <div class="col-12">
            <label class="form-label fw-600">Đoạn văn 1</label>
            <asp:TextBox ID="txtDoan1" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
        </div>
        <div class="col-12">
            <label class="form-label fw-600">Đoạn văn 2</label>
            <asp:TextBox ID="txtDoan2" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
        </div>
    </div>

    <!-- Badge & Hinh -->
    <div class="mt-3 pt-3" style="border-top:1px solid #eee;">
        <div class="fw-600 mb-2"><i class="fas fa-award text-warning me-1"></i>Badge góc ảnh</div>
        <div class="row g-3">
            <div class="col-md-3">
                <label class="form-label">Số / Tiêu đề badge</label>
                <asp:TextBox ID="txtBadgeSo" runat="server" CssClass="form-control" placeholder="Top 10" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Mô tả badge</label>
                <asp:TextBox ID="txtBadgeTen" runat="server" CssClass="form-control" placeholder="Bãi biển đẹp VN" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Hình ảnh chính</label>
                <asp:FileUpload ID="fuHinh" runat="server" CssClass="form-control" accept=".jpg,.jpeg,.png,.webp,.gif" />
                <div class="mt-1 small text-muted">Đang dùng: <asp:Literal ID="litHinh" runat="server" Text="about-main.jpg (mặc định)" /></div>
            </div>
        </div>
    </div>

    <!-- 4 dac diem -->
    <div class="mt-3 pt-3" style="border-top:1px solid #eee;">
        <div class="fw-600 mb-2"><i class="fas fa-th me-1"></i>4 Đặc Điểm Nổi Bật</div>
        <div class="row g-3">
            <div class="col-md-3">
                <label class="form-label small fw-600"><i class="fas fa-water text-primary me-1"></i>Đặc điểm 1</label>
                <asp:TextBox ID="txtFeat1Ten" runat="server" CssClass="form-control mb-1" placeholder="Biển Sạch" />
                <asp:TextBox ID="txtFeat1Mo" runat="server" CssClass="form-control form-control-sm text-muted" placeholder="Mô tả ngắn..." />
            </div>
            <div class="col-md-3">
                <label class="form-label small fw-600"><i class="fas fa-leaf text-primary me-1"></i>Đặc điểm 2</label>
                <asp:TextBox ID="txtFeat2Ten" runat="server" CssClass="form-control mb-1" placeholder="Sinh Thái" />
                <asp:TextBox ID="txtFeat2Mo" runat="server" CssClass="form-control form-control-sm text-muted" placeholder="Mô tả ngắn..." />
            </div>
            <div class="col-md-3">
                <label class="form-label small fw-600"><i class="fas fa-fish text-primary me-1"></i>Đặc điểm 3</label>
                <asp:TextBox ID="txtFeat3Ten" runat="server" CssClass="form-control mb-1" placeholder="Hải Sản" />
                <asp:TextBox ID="txtFeat3Mo" runat="server" CssClass="form-control form-control-sm text-muted" placeholder="Mô tả ngắn..." />
            </div>
            <div class="col-md-3">
                <label class="form-label small fw-600"><i class="fas fa-heart text-primary me-1"></i>Đặc điểm 4</label>
                <asp:TextBox ID="txtFeat4Ten" runat="server" CssClass="form-control mb-1" placeholder="Thân Thiện" />
                <asp:TextBox ID="txtFeat4Mo" runat="server" CssClass="form-control form-control-sm text-muted" placeholder="Mô tả ngắn..." />
            </div>
        </div>
    </div>

    <div class="mt-4">
        <asp:Button ID="btnLuuTab1" runat="server" CssClass="btn btn-primary px-5" Text="Lưu Thay Đổi" OnClick="btnLuuTab1_Click" />
    </div>
</div>

<!-- ===== TAB 2: THONG KE ===== -->
<div id="pnlTab2" class="admin-card" style="display:none;border-radius:0 8px 8px 8px;">
    <div class="admin-card-title"><i class="fas fa-chart-bar me-2"></i>Thanh Thống Kê (Stats Bar)</div>
    <p class="text-muted small mb-3">Hiển thị 4 con số thống kê nổi bật phía dưới slider. Con số sẽ chạy đếm ngược lên khi vào trang.</p>

    <div class="row g-4">
        <% string[] statNums = {"1","2","3","4"}; %>

        <!-- Stat 1 -->
        <div class="col-md-6">
            <div class="p-3 border rounded-3">
                <div class="fw-600 mb-2 text-primary">Stat 1</div>
                <div class="row g-2">
                    <div class="col-4">
                        <label class="form-label small">Số</label>
                        <asp:TextBox ID="txtStat1So" runat="server" CssClass="form-control" placeholder="10" />
                    </div>
                    <div class="col-4">
                        <label class="form-label small">Hậu tố</label>
                        <asp:TextBox ID="txtStat1HauTo" runat="server" CssClass="form-control" placeholder="km+" />
                    </div>
                    <div class="col-12">
                        <label class="form-label small">Nhãn</label>
                        <asp:TextBox ID="txtStat1Nhan" runat="server" CssClass="form-control" placeholder="Chiều dài bãi biển" />
                    </div>
                </div>
            </div>
        </div>
        <!-- Stat 2 -->
        <div class="col-md-6">
            <div class="p-3 border rounded-3">
                <div class="fw-600 mb-2 text-primary">Stat 2</div>
                <div class="row g-2">
                    <div class="col-4">
                        <label class="form-label small">Số</label>
                        <asp:TextBox ID="txtStat2So" runat="server" CssClass="form-control" placeholder="50" />
                    </div>
                    <div class="col-4">
                        <label class="form-label small">Hậu tố</label>
                        <asp:TextBox ID="txtStat2HauTo" runat="server" CssClass="form-control" placeholder="+" />
                    </div>
                    <div class="col-12">
                        <label class="form-label small">Nhãn</label>
                        <asp:TextBox ID="txtStat2Nhan" runat="server" CssClass="form-control" placeholder="Tour du lịch" />
                    </div>
                </div>
            </div>
        </div>
        <!-- Stat 3 -->
        <div class="col-md-6">
            <div class="p-3 border rounded-3">
                <div class="fw-600 mb-2 text-primary">Stat 3</div>
                <div class="row g-2">
                    <div class="col-4">
                        <label class="form-label small">Số</label>
                        <asp:TextBox ID="txtStat3So" runat="server" CssClass="form-control" placeholder="30" />
                    </div>
                    <div class="col-4">
                        <label class="form-label small">Hậu tố</label>
                        <asp:TextBox ID="txtStat3HauTo" runat="server" CssClass="form-control" placeholder="+" />
                    </div>
                    <div class="col-12">
                        <label class="form-label small">Nhãn</label>
                        <asp:TextBox ID="txtStat3Nhan" runat="server" CssClass="form-control" placeholder="Cơ sở lưu trú" />
                    </div>
                </div>
            </div>
        </div>
        <!-- Stat 4 -->
        <div class="col-md-6">
            <div class="p-3 border rounded-3">
                <div class="fw-600 mb-2 text-primary">Stat 4</div>
                <div class="row g-2">
                    <div class="col-4">
                        <label class="form-label small">Số</label>
                        <asp:TextBox ID="txtStat4So" runat="server" CssClass="form-control" placeholder="100000" />
                    </div>
                    <div class="col-4">
                        <label class="form-label small">Hậu tố</label>
                        <asp:TextBox ID="txtStat4HauTo" runat="server" CssClass="form-control" placeholder="+" />
                    </div>
                    <div class="col-12">
                        <label class="form-label small">Nhãn</label>
                        <asp:TextBox ID="txtStat4Nhan" runat="server" CssClass="form-control" placeholder="Lượt khách/năm" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="mt-4">
        <asp:Button ID="btnLuuTab2" runat="server" CssClass="btn btn-primary px-5" Text="Lưu Thống Kê" OnClick="btnLuuTab2_Click" />
    </div>
</div>

<!-- ===== TAB 3: CTA ===== -->
<div id="pnlTab3" class="admin-card" style="display:none;border-radius:0 8px 8px 8px;">
    <div class="admin-card-title"><i class="fas fa-bullhorn me-2"></i>Banner Lời Kêu Gọi (CTA) cuối trang</div>

    <div class="row g-3">
        <div class="col-12">
            <label class="form-label fw-600">Tiêu đề CTA</label>
            <asp:TextBox ID="txtCtaTieuDe" runat="server" CssClass="form-control" placeholder="Sẵn Sàng Khám Phá Ba Động?" />
        </div>
        <div class="col-12">
            <label class="form-label fw-600">Mô tả phụ</label>
            <asp:TextBox ID="txtCtaMoTa" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"
                placeholder="Liên hệ ngay để được tư vấn và đặt tour với giá tốt nhất!" />
        </div>
        <div class="col-md-6">
            <label class="form-label fw-600">Nút chính – Nội dung</label>
            <asp:TextBox ID="txtCtaBtn1" runat="server" CssClass="form-control" placeholder="Đặt Tour Ngay" />
        </div>
        <div class="col-md-6">
            <label class="form-label fw-600">Nút chính – Đường dẫn</label>
            <asp:TextBox ID="txtCtaBtn1Link" runat="server" CssClass="form-control" placeholder="DatTour.aspx" />
        </div>
        <div class="col-md-6">
            <label class="form-label fw-600">Nút phụ – Nội dung</label>
            <asp:TextBox ID="txtCtaBtn2" runat="server" CssClass="form-control" placeholder="Liên Hệ" />
        </div>
        <div class="col-md-6">
            <label class="form-label fw-600">Nút phụ – Đường dẫn</label>
            <asp:TextBox ID="txtCtaBtn2Link" runat="server" CssClass="form-control" placeholder="LienHe.aspx" />
        </div>
    </div>

    <div class="mt-4">
        <asp:Button ID="btnLuuTab3" runat="server" CssClass="btn btn-primary px-5" Text="Lưu CTA" OnClick="btnLuuTab3_Click" />
    </div>
</div>

<!-- ===== TAB 4: BANNER AM THUC & LUU TRU ===== -->
<div id="pnlTab4" class="admin-card" style="display:none;border-radius:0 8px 8px 8px;">
    <div class="admin-card-title"><i class="fas fa-image me-2"></i>Banner Ẩm Thực &amp; Lưu Trú (giữa trang chủ)</div>

    <!-- Am Thuc -->
    <div class="p-3 border rounded-3 mb-4">
        <div class="fw-600 mb-3 text-primary"><i class="fas fa-utensils me-1"></i>Ẩm Thực Địa Phương</div>
        <div class="row g-3">
            <div class="col-md-6">
                <label class="form-label">Tiêu đề</label>
                <asp:TextBox ID="txtAtTieuDe" runat="server" CssClass="form-control" placeholder="Ẩm Thực Địa Phương" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Mô tả</label>
                <asp:TextBox ID="txtAtMoTa" runat="server" CssClass="form-control" placeholder="Cua Huỳnh Đế, hải sản tươi ngon đặc trưng" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Nút – Nội dung</label>
                <asp:TextBox ID="txtAtBtn" runat="server" CssClass="form-control" placeholder="Khám Phá" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Hình ảnh nền</label>
                <asp:FileUpload ID="fuAtHinh" runat="server" CssClass="form-control" accept=".jpg,.jpeg,.png,.webp" />
                <div class="mt-1 small text-muted">Đang dùng: <asp:Literal ID="litAtHinh" runat="server" Text="food-banner.jpg (mặc định)" /></div>
            </div>
        </div>
    </div>

    <!-- Luu Tru -->
    <div class="p-3 border rounded-3 mb-4">
        <div class="fw-600 mb-3 text-primary"><i class="fas fa-hotel me-1"></i>Lưu Trú Tiện Nghi</div>
        <div class="row g-3">
            <div class="col-md-6">
                <label class="form-label">Tiêu đề</label>
                <asp:TextBox ID="txtLtTieuDe" runat="server" CssClass="form-control" placeholder="Lưu Trú Tiện Nghi" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Mô tả</label>
                <asp:TextBox ID="txtLtMoTa" runat="server" CssClass="form-control" placeholder="Resort, khách sạn, nhà nghỉ đa dạng giá tốt" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Nút – Nội dung</label>
                <asp:TextBox ID="txtLtBtn" runat="server" CssClass="form-control" placeholder="Xem Ngay" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Hình ảnh nền</label>
                <asp:FileUpload ID="fuLtHinh" runat="server" CssClass="form-control" accept=".jpg,.jpeg,.png,.webp" />
                <div class="mt-1 small text-muted">Đang dùng: <asp:Literal ID="litLtHinh" runat="server" Text="hotel-banner.jpg (mặc định)" /></div>
            </div>
        </div>
    </div>

    <div class="mt-2">
        <asp:Button ID="btnLuuTab4" runat="server" CssClass="btn btn-primary px-5" Text="Lưu Banner" OnClick="btnLuuTab4_Click" />
    </div>
</div>

</asp:Content>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
<script>
var activeTab = '<%=hfActiveTab.Value%>';
var hfId = '<%=hfActiveTab.ClientID%>';

function setTab(tab) {
    document.getElementById(hfId).value = tab;
    activeTab = tab;
    ['tab1','tab2','tab3','tab4'].forEach(function(t) {
        var num = t.replace('tab','');
        var panel = document.getElementById('pnlTab' + num);
        var link  = document.getElementById('linkTab' + num);
        if (panel) panel.style.display = (t === tab) ? '' : 'none';
        if (link)  link.classList.toggle('active', t === tab);
    });
}

document.addEventListener('DOMContentLoaded', function() {
    setTab(activeTab);
});
</script>
</asp:Content>
