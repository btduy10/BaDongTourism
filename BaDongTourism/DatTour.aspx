<%@ Page Title="Đặt Tour" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DatTour.aspx.cs" Inherits="DatTourPage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-hero">
    <div class="container">
        <h1><i class="fas fa-calendar-check me-3"></i>Đặt Tour Du Lịch</h1>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx"><i class="fas fa-home"></i> Trang chủ</a></li>
                <li class="breadcrumb-item active">Đặt Tour</li>
            </ol>
        </nav>
    </div>
</div>

<section class="section-py">
    <div class="container">
        <div class="row g-5">

            <!-- FORM DAT TOUR -->
            <div class="col-lg-7" data-aos="fade-right">
                <div class="booking-card">
                    <h5 class="fw-bold mb-4" style="color:#0077b6;">
                        <i class="fas fa-calendar-alt me-2"></i>Thông Tin Đặt Tour
                    </h5>

                    <asp:Panel ID="pnlSuccess" runat="server" Visible="false"
                               CssClass="p-4 rounded-3 mb-4 text-center"
                               style="background:linear-gradient(135deg,#d4edda,#c3e6cb);border:1px solid #b1dfbb;">
                        <i class="fas fa-check-circle text-success" style="font-size:3rem;"></i>
                        <h5 class="text-success mt-3 fw-bold">Đặt Tour Thành Công!</h5>
                        <p class="mb-2">Cảm ơn bạn đã đặt tour tại <strong>Ba Động Travel</strong>.</p>
                        <p class="mb-3">Chúng tôi sẽ liên hệ xác nhận trong vòng <strong>2 giờ</strong>.</p>
                        <p class="mb-0">Mã đặt tour của bạn: <asp:Label ID="lblMaDat" runat="server" CssClass="fw-bold text-primary" /></p>
                        <div class="mt-4">
                            <a href="Tour.aspx" class="btn btn-success me-2"><i class="fas fa-map me-1"></i>Xem Thêm Tour</a>
                            <a href="Default.aspx" class="btn btn-outline-secondary"><i class="fas fa-home me-1"></i>Trang Chủ</a>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="pnlForm" runat="server">
                        <div class="mb-4">
                            <label class="form-label fw-600">Chọn Tour <span class="text-danger">*</span></label>
                            <asp:DropDownList ID="ddlTour" runat="server" CssClass="form-select" />
                        </div>

                        <!-- Hien thi gia tour -->
                        <div id="tourInfo" style="display:none; background:#f0f8ff; border-radius:10px; padding:14px; margin-bottom:16px;">
                            <div style="display:flex; gap:12px;">
                                <div style="flex:1; text-align:center; background:#fff; border:1px solid #dee2e6; border-radius:8px; padding:10px;">
                                    <small class="text-muted d-block mb-1"><i class="fas fa-user me-1"></i>Người lớn</small>
                                    <div id="spnGiaNL" style="font-weight:700; color:#f77f00; font-size:1.1rem;">—</div>
                                </div>
                                <div style="flex:1; text-align:center; background:#fff; border:1px solid #dee2e6; border-radius:8px; padding:10px;">
                                    <small class="text-muted d-block mb-1"><i class="fas fa-child me-1"></i>Trẻ em</small>
                                    <div id="spnGiaTE" style="font-weight:700; color:#f77f00; font-size:1.1rem;">—</div>
                                </div>
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-md-6">
                                <label class="form-label fw-600">Họ và Tên <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" placeholder="Nguyễn Văn A" />
                            </div>
                            <div class="col-md-6">
                                <label class="form-label fw-600">Điện Thoại <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control" placeholder="0901 234 567" />
                            </div>
                            <div class="col-md-12">
                                <label class="form-label fw-600">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="email@example.com" />
                            </div>
                            <div class="col-md-4">
                                <label class="form-label fw-600">Số Người Lớn</label>
                                <asp:TextBox ID="SoNguoiLon" runat="server" CssClass="form-control"
                                             TextMode="Number" Text="0" min="0" />
                            </div>
                            <div class="col-md-4">
                                <label class="form-label fw-600">Số Trẻ Em</label>
                                <asp:TextBox ID="SoTreEm" runat="server" CssClass="form-control"
                                             TextMode="Number" Text="0" min="0" />
                            </div>
                            <div class="col-md-4">
                                <label class="form-label fw-600">Ngày Khởi Hành</label>
                                <asp:TextBox ID="txtNgayKH" runat="server" CssClass="form-control" TextMode="Date" />
                            </div>
                            <div class="col-12">
                                <label class="form-label fw-600">Ghi Chú / Yêu Cầu Đặc Biệt</label>
                                <asp:TextBox ID="txtGhiChu" runat="server" CssClass="form-control"
                                             TextMode="MultiLine" Rows="3"
                                             placeholder="VD: cần xe lăn, ăn chay, trẻ nhỏ dưới 2 tuổi..." />
                            </div>
                            <div class="col-12">
                                <!-- Tong tien uoc tinh -->
                                <div class="p-3 rounded-3 mb-3" style="background:#fff3e0;border:1px solid #f77f00;">
                                    <div class="d-flex justify-content-between align-items-center">
                                        <span class="fw-600">Tổng tiền ước tính:</span>
                                        <span id="TongTienDisplay" style="font-size:1.4rem;font-weight:800;color:#f77f00;"
                                              data-gianguoilon="0" data-giatreem="0">0đ</span>
                                    </div>
                                    <small class="text-muted">(Tổng tiền chính xác sẽ được xác nhận khi liên hệ)</small>
                                </div>
                                <asp:HiddenField ID="TongTien" runat="server" Value="0" />
                            </div>
                            <div class="col-12">
                                <asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3" />
                                <asp:Button ID="btnDat" runat="server" Text="Đặt Tour Ngay"
                                            CssClass="btn btn-primary btn-lg w-100"
                                            OnClick="btnDat_Click" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>

            <!-- THONG TIN BEN PHAI -->
            <div class="col-lg-5" data-aos="fade-left">

                <!-- Luu y khi dat tour -->
                <div class="sidebar-card mb-4">
                    <div class="sidebar-card-header">
                        <i class="fas fa-info-circle me-2"></i>Lưu Ý Khi Đặt Tour
                    </div>
                    <div class="sidebar-card-body">
                        <ul class="list-unstyled mb-0" style="font-size:0.9rem;">
                            <li class="mb-2"><i class="fas fa-check-circle text-success me-2"></i>Đặt trước ít nhất <strong>2 ngày</strong></li>
                            <li class="mb-2"><i class="fas fa-check-circle text-success me-2"></i>Nhân viên liên hệ xác nhận trong <strong>2 giờ</strong></li>
                            <li class="mb-2"><i class="fas fa-check-circle text-success me-2"></i>Thanh toán khi hướng dẫn viên đón</li>
                            <li class="mb-2"><i class="fas fa-check-circle text-success me-2"></i>Hủy tour miễn phí trước <strong>24 giờ</strong></li>
                            <li class="mb-0"><i class="fas fa-check-circle text-success me-2"></i>Trẻ em dưới <strong>3 tuổi</strong> miễn phí</li>
                        </ul>
                    </div>
                </div>

                <!-- Lien he nhanh -->
                <div class="contact-info-card">
                    <h6 class="fw-bold mb-3"><i class="fas fa-headset me-2"></i>Hỗ Trợ 24/7</h6>
                    <div class="contact-info-item">
                        <div class="contact-info-icon"><i class="fas fa-phone-alt"></i></div>
                        <div>
                            <strong>Hotline đặt tour</strong>
                            <p class="mb-0 small opacity-85">0294 1234 567</p>
                        </div>
                    </div>
                    <div class="contact-info-item mb-0">
                        <div class="contact-info-icon"><i class="fab fa-facebook-messenger"></i></div>
                        <div>
                            <strong>Nhắn tin Zalo/Messenger</strong>
                            <p class="mb-0 small opacity-85">0901 234 567</p>
                        </div>
                    </div>
                </div>

                <!-- Danh sach tour noi bat -->
                <div class="sidebar-card mt-4">
                    <div class="sidebar-card-header"><i class="fas fa-star me-2"></i>Tour Nổi Bật</div>
                    <div class="sidebar-card-body" id="sidebarTour" runat="server"></div>
                </div>
            </div>
        </div>
    </div>
</section>

</asp:Content>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
<script>
document.addEventListener('DOMContentLoaded', function () {
    var ddlTour = document.getElementById('<%=ddlTour.ClientID%>');
    if (!ddlTour) return;

    function fmtTien(n) {
        return n.toLocaleString('vi-VN') + 'đ';
    }

    // Load gia khi chon tour
    ddlTour.addEventListener('change', function () {
        var opt = ddlTour.options[ddlTour.selectedIndex];
        var gnl  = parseFloat(opt.dataset.giaNl || 0);
        var gte  = parseFloat(opt.dataset.giaTe || 0);
        var disp = document.getElementById('TongTienDisplay');
        disp.dataset.gianguoilon = gnl;
        disp.dataset.giatreem    = gte;

        var info = document.getElementById('tourInfo');
        if (opt.value && opt.value !== '0') {
            info.style.display = 'block';
            document.getElementById('spnGiaNL').innerText = fmtTien(gnl) + '/người';
            document.getElementById('spnGiaTE').innerText = fmtTien(gte) + '/người';
        } else {
            info.style.display = 'none';
        }
        calcTotal();
    });

    function calcTotal() {
        var disp = document.getElementById('TongTienDisplay');
        var gnl   = parseFloat(disp.dataset.gianguoilon || 0);
        var gte   = parseFloat(disp.dataset.giatreem    || 0);
        var nl    = parseInt(document.getElementById('<%=SoNguoiLon.ClientID%>').value) || 0;
        var te    = parseInt(document.getElementById('<%=SoTreEm.ClientID%>').value)    || 0;
        var total = nl * gnl + te * gte;
        disp.innerText = fmtTien(total);
        document.getElementById('<%=TongTien.ClientID%>').value = total;
    }

    document.getElementById('<%=SoNguoiLon.ClientID%>').addEventListener('input', calcTotal);
    document.getElementById('<%=SoTreEm.ClientID%>').addEventListener('input', calcTotal);
});
</script>
</asp:Content>
