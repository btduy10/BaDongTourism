<%@ Page Title="Quản Lý Liên Hệ" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeFile="QuanLyLienHe.aspx.cs" Inherits="Admin_QuanLyLienHe" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" runat="server">

<asp:HiddenField ID="hfViewId"  runat="server" Value="0" />
<asp:HiddenField ID="hfFilter"  runat="server" Value="all" />
<asp:Button ID="btnPostback" runat="server" Text="" Style="display:none;" CausesValidation="false" OnClick="btnPostback_Click" />

<!-- PAGE HEADER -->
<div class="d-flex justify-content-between align-items-center mb-4">
    <h5 class="fw-bold mb-0">
        <i class="fas fa-envelope me-2 text-primary"></i>Tin Nhắn Liên Hệ
        <asp:Label ID="lblBadge" runat="server" CssClass="badge bg-danger ms-2" Visible="false" />
    </h5>
</div>

<asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3" />

<!-- FILTER TABS -->
<ul class="nav nav-tabs mb-3" id="filterTabs">
    <li class="nav-item">
        <a class="nav-link" id="tabAll"    href="javascript:void(0)" onclick="setFilter('all')">Tất Cả</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" id="tabUnread" href="javascript:void(0)" onclick="setFilter('unread')">Chưa Đọc</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" id="tabReplied" href="javascript:void(0)" onclick="setFilter('replied')">Đã Phản Hồi</a>
    </li>
</ul>

<!-- TABLE -->
<div class="admin-card">
    <div class="table-responsive">
        <table class="table table-admin table-hover align-middle">
            <thead>
                <tr>
                    <th style="width:40px;">#</th>
                    <th>Người Gửi</th>
                    <th>Email / SĐT</th>
                    <th>Chủ Đề</th>
                    <th>Ngày Gửi</th>
                    <th style="width:130px;">Trạng Thái</th>
                    <th style="width:100px;">Thao Tác</th>
                </tr>
            </thead>
            <tbody id="tableBody" runat="server">
                <tr><td colspan="7" class="text-center text-muted py-4">Chưa có tin nhắn.</td></tr>
            </tbody>
        </table>
    </div>
</div>

<!-- MODAL XEM & PHAN HOI -->
<div class="modal fade" id="modalXem" tabindex="-1" aria-labelledby="modalXemLabel" aria-hidden="true" data-bs-backdrop="static">
    <div class="modal-dialog modal-lg modal-dialog-scrollable">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title fw-bold" id="modalXemLabel">
                    <i class="fas fa-envelope-open-text me-2 text-primary"></i>Nội Dung Tin Nhắn
                </h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body">

                <!-- Sender info -->
                <div class="row g-3 mb-4 p-3 rounded-3" style="background:#f8f9fa;">
                    <div class="col-md-4">
                        <div class="text-muted small mb-1"><i class="fas fa-user me-1"></i>Họ và tên</div>
                        <asp:Label ID="lblHoTen" runat="server" CssClass="fw-bold" />
                    </div>
                    <div class="col-md-4">
                        <div class="text-muted small mb-1"><i class="fas fa-envelope me-1"></i>Email</div>
                        <asp:Label ID="lblEmail" runat="server" />
                    </div>
                    <div class="col-md-4">
                        <div class="text-muted small mb-1"><i class="fas fa-phone me-1"></i>Điện thoại</div>
                        <asp:Label ID="lblDienThoai" runat="server" />
                    </div>
                    <div class="col-md-8">
                        <div class="text-muted small mb-1"><i class="fas fa-tag me-1"></i>Chủ đề</div>
                        <asp:Label ID="lblChuDe" runat="server" CssClass="fw-semibold" />
                    </div>
                    <div class="col-md-4">
                        <div class="text-muted small mb-1"><i class="fas fa-clock me-1"></i>Ngày gửi</div>
                        <asp:Label ID="lblNgayGui" runat="server" CssClass="small" />
                    </div>
                </div>

                <!-- Message content -->
                <div class="mb-4">
                    <div class="fw-semibold mb-2"><i class="fas fa-comment-dots me-1 text-primary"></i>Nội Dung Tin Nhắn</div>
                    <div class="p-3 rounded-3 border" style="white-space:pre-wrap;min-height:80px;background:#fff;">
                        <asp:Label ID="lblNoiDung" runat="server" />
                    </div>
                </div>

                <!-- Previous reply (if any) -->
                <asp:Panel ID="pnlDaPhanHoi" runat="server" Visible="false" CssClass="mb-4">
                    <div class="fw-semibold mb-2 text-success"><i class="fas fa-check-circle me-1"></i>Phản Hồi Trước Đó</div>
                    <div class="p-3 rounded-3" style="background:#d1f5d3;border:1px solid #b2dfdb;white-space:pre-wrap;">
                        <asp:Label ID="lblPhanHoiCu" runat="server" />
                    </div>
                    <div class="text-muted small mt-1">
                        <i class="fas fa-clock me-1"></i>Đã phản hồi lúc: <asp:Label ID="lblNgayPhanHoi" runat="server" />
                    </div>
                </asp:Panel>

                <!-- Reply form -->
                <div>
                    <div class="fw-semibold mb-2"><i class="fas fa-reply me-1 text-primary"></i>Ghi Chú / Phản Hồi Của Admin</div>
                    <asp:TextBox ID="txtPhanHoi" runat="server" TextMode="MultiLine" Rows="5"
                        CssClass="form-control" placeholder="Nhập nội dung phản hồi hoặc ghi chú nội bộ..." />
                    <div class="form-text text-muted mt-1">
                        <i class="fas fa-info-circle me-1"></i>Phản hồi được lưu trong hệ thống để quản lý nội bộ.
                    </div>
                </div>

            </div>
            <div class="modal-footer d-flex justify-content-between align-items-center flex-wrap gap-2">
                <!-- Nut gui email (hien sau khi da co phan hoi) -->
                <asp:Label ID="lblMailtoBtn" runat="server" />

                <div class="d-flex gap-2">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Đóng</button>
                    <asp:Button ID="btnLuuPhanHoi" runat="server" Text="💾 Lưu Phản Hồi"
                        CssClass="btn btn-primary" OnClick="btnLuuPhanHoi_Click" />
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    var hfViewId   = '<%=hfViewId.ClientID%>';
    var hfFilter   = '<%=hfFilter.ClientID%>';
    var btnPostback = '<%=btnPostback.ClientID%>';

    function doPostback() {
        document.getElementById(btnPostback).click();
    }

    // Filter tab switching
    function setFilter(f) {
        document.getElementById(hfFilter).value = f;
        document.getElementById(hfViewId).value = '0';
        doPostback();
    }

    // Open view modal
    function openXem(id) {
        document.getElementById(hfViewId).value = id;
        doPostback();
    }

    // Chay sau khi Bootstrap JS da load xong
    window.addEventListener('load', function () {
        // Highlight active filter tab
        var f = document.getElementById(hfFilter).value || 'all';
        var map = { all: 'tabAll', unread: 'tabUnread', replied: 'tabReplied' };
        var el = document.getElementById(map[f]);
        if (el) el.classList.add('active');

        // Tu dong mo modal neu co tin nhan duoc chon
        var id = parseInt(document.getElementById(hfViewId).value, 10);
        if (id > 0) {
            var m = document.getElementById('modalXem');
            if (m) new bootstrap.Modal(m).show();
        }
    });

</script>

</asp:Content>
