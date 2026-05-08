<%@ Page Title="Chi Tiết Tour" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TourChiTiet.aspx.cs" Inherits="TourChiTiet" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-hero">
    <div class="container">
        <h1 id="tourTitle" runat="server">Chi Tiết Tour</h1>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx"><i class="fas fa-home"></i> Trang chủ</a></li>
                <li class="breadcrumb-item"><a href="Tour.aspx">Tour Du Lịch</a></li>
                <li class="breadcrumb-item active" id="breadTour" runat="server">Chi Tiết</li>
            </ol>
        </nav>
    </div>
</div>

<section class="section-py">
    <div class="container">
        <asp:Panel ID="pnlContent" runat="server">
            <div class="row g-5">
                <!-- LEFT -->
                <div class="col-lg-8">
                    <img id="imgTour" runat="server" src="" alt="" class="detail-img mb-4" />
                    <div class="detail-meta mb-3">
                        <span><i class="fas fa-clock"></i><strong id="lblThoiGian" runat="server"></strong></span>
                        <span><i class="fas fa-map-marker-alt"></i><span id="lblDiaDiem" runat="server"></span></span>
                        <span><i class="fas fa-users"></i>Tối đa <span id="lblSoCho" runat="server"></span> người</span>
                        <span><i class="fas fa-eye"></i><span id="lblLuotXem" runat="server"></span> lượt xem</span>
                    </div>

                    <h2 id="lblTenTour" runat="server" class="mb-4" style="font-family:'Playfair Display',serif;color:#1a1a2e;"></h2>

                    <ul class="nav nav-tabs mb-4" id="tourTab" role="tablist">
                        <li class="nav-item"><button class="nav-link active" data-bs-toggle="tab" data-bs-target="#tab-mota">Mô tả</button></li>
                        <li class="nav-item"><button class="nav-link" data-bs-toggle="tab" data-bs-target="#tab-baogom">Bao gồm</button></li>
                        <li class="nav-item"><button class="nav-link" data-bs-toggle="tab" data-bs-target="#tab-luuy">Lưu ý</button></li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane fade show active" id="tab-mota">
                            <div class="detail-content" id="lblMoTa" runat="server"></div>
                        </div>
                        <div class="tab-pane fade" id="tab-baogom">
                            <div class="row g-3">
                                <div class="col-md-6">
                                    <h6 class="text-success"><i class="fas fa-check-circle me-2"></i>Bao gồm</h6>
                                    <div id="lblBaoGom" runat="server" class="detail-content"></div>
                                </div>
                                <div class="col-md-6">
                                    <h6 class="text-danger"><i class="fas fa-times-circle me-2"></i>Không bao gồm</h6>
                                    <div id="lblKhongBaoGom" runat="server" class="detail-content"></div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="tab-luuy">
                            <div id="lblLuuY" runat="server" class="detail-content"></div>
                        </div>
                    </div>
                </div>

                <!-- RIGHT: Booking -->
                <div class="col-lg-4">
                    <div class="booking-card sticky-top" style="top:90px;">
                        <h5 class="fw-bold mb-4" style="color:#0077b6;"><i class="fas fa-calendar-check me-2"></i>Đặt Tour</h5>
                        <div style="display:flex;gap:10px;margin-bottom:16px;padding:14px;background:#f0f8ff;border-radius:10px;">
                            <div style="flex:1;text-align:center;background:#fff;border:1px solid #dee2e6;border-radius:8px;padding:10px;">
                                <div style="font-size:0.78rem;color:#666;margin-bottom:4px;">Người lớn</div>
                                <div id="spnGiaNL" style="font-size:1.15rem;font-weight:800;color:#f77f00;font-family:'Inter',sans-serif;">—</div>
                            </div>
                            <div style="flex:1;text-align:center;background:#fff;border:1px solid #dee2e6;border-radius:8px;padding:10px;">
                                <div style="font-size:0.78rem;color:#666;margin-bottom:4px;">Trẻ em</div>
                                <div id="spnGiaTE" style="font-size:1.15rem;font-weight:800;color:#f77f00;font-family:'Inter',sans-serif;">—</div>
                            </div>
                        </div>

                        <form method="post" class="needs-validation" novalidate>
                            <div class="mb-3">
                                <label class="form-label fw-600">Họ và tên <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" placeholder="Nguyễn Văn A" required="required" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label fw-600">Điện thoại <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control" placeholder="0901 234 567" required="required" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label fw-600">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="email@example.com" />
                            </div>
                            <div class="row g-2 mb-3">
                                <div class="col-6">
                                    <label class="form-label fw-600">Người lớn</label>
                                    <asp:TextBox ID="SoNguoiLon" runat="server" CssClass="form-control" TextMode="Number" Text="0" min="0" />
                                </div>
                                <div class="col-6">
                                    <label class="form-label fw-600">Trẻ em</label>
                                    <asp:TextBox ID="SoTreEm" runat="server" CssClass="form-control" TextMode="Number" Text="0" min="0" />
                                </div>
                            </div>
                            <div class="mb-3">
                                <label class="form-label fw-600">Ngày khởi hành</label>
                                <asp:TextBox ID="txtNgayKH" runat="server" CssClass="form-control" TextMode="Date" />
                            </div>
                            <div class="mb-3 p-3 rounded-3" style="background:#fff3e0;border:1px solid #f77f00;">
                                <div style="font-size:0.82rem;color:#666;">Tổng tiền dự tính</div>
                                <asp:HiddenField ID="TongTien" runat="server" Value="0" />
                                <div id="TongTienDisplay" style="font-size:1.5rem;font-weight:800;color:#f77f00;">0đ</div>
                            </div>
                            <div class="mb-3">
                                <label class="form-label fw-600">Ghi chú</label>
                                <asp:TextBox ID="txtGhiChu" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Yêu cầu đặc biệt..." />
                            </div>
                            <asp:Button ID="btnDatTour" runat="server" Text="Đặt Tour Ngay" CssClass="btn btn-primary w-100 btn-lg" OnClick="btnDatTour_Click" />
                            <asp:Label ID="lblMsg" runat="server" CssClass="d-block mt-3 text-center" />
                        </form>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Label ID="lblNotFound" runat="server" Text="Không tìm thấy tour." CssClass="text-muted" Visible="false" />
    </div>
</section>

</asp:Content>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
<script>
(function () {
    var inpNL  = document.getElementById('<%=SoNguoiLon.ClientID%>');
    var inpTE  = document.getElementById('<%=SoTreEm.ClientID%>');
    var disp   = document.getElementById('TongTienDisplay');
    var hidden = document.getElementById('<%=TongTien.ClientID%>');

    function fmtTien(n) {
        return n.toLocaleString('vi-VN') + 'đ';
    }

    function calcTotal() {
        var gnl   = parseFloat(disp.dataset.gianguoilon || 0);
        var gte   = parseFloat(disp.dataset.giatreem    || 0);
        var nl    = parseInt(inpNL.value)  || 0;
        var te    = parseInt(inpTE.value)  || 0;
        var total = nl * gnl + te * gte;
        disp.innerText   = fmtTien(total);
        if (hidden) hidden.value = total;
    }

    if (inpNL) inpNL.addEventListener('input', calcTotal);
    if (inpTE) inpTE.addEventListener('input', calcTotal);
})();
</script>
</asp:Content>
