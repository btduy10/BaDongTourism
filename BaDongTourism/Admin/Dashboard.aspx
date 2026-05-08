<%@ Page Title="Tổng Quan" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Admin_Dashboard" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" runat="server">

<div class="row g-4 mb-4">
    <div class="col-lg-3 col-md-6">
        <div class="stat-card">
            <div class="stat-card-icon blue"><i class="fas fa-map-pin"></i></div>
            <div>
                <div class="stat-card-value" id="soDD" runat="server">0</div>
                <div class="stat-card-label">Địa Điểm</div>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-6">
        <div class="stat-card">
            <div class="stat-card-icon orange"><i class="fas fa-map"></i></div>
            <div>
                <div class="stat-card-value" id="soTour" runat="server">0</div>
                <div class="stat-card-label">Tour Du Lịch</div>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-6">
        <div class="stat-card">
            <div class="stat-card-icon green"><i class="fas fa-calendar-check"></i></div>
            <div>
                <div class="stat-card-value" id="soDatTour" runat="server">0</div>
                <div class="stat-card-label">Đơn Đặt Tour</div>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-6">
        <div class="stat-card">
            <div class="stat-card-icon purple"><i class="fas fa-envelope"></i></div>
            <div>
                <div class="stat-card-value" id="soLienHe" runat="server">0</div>
                <div class="stat-card-label">Tin Nhắn Mới</div>
            </div>
        </div>
    </div>
</div>

<div class="row g-4">
    <!-- Don dat tour gan nhat -->
    <div class="col-lg-7">
        <div class="admin-card">
            <div class="admin-card-title"><i class="fas fa-calendar-check me-2 text-primary"></i>Đơn Đặt Tour Gần Nhất</div>
            <div class="table-responsive">
                <table class="table table-admin table-hover">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Khách Hàng</th>
                            <th>Tour</th>
                            <th>Tổng Tiền</th>
                            <th>Trạng Thái</th>
                        </tr>
                    </thead>
                    <tbody id="datTourTable" runat="server">
                        <tr><td colspan="5" class="text-center text-muted py-4">Chưa có đơn đặt tour.</td></tr>
                    </tbody>
                </table>
            </div>
            <a href="QuanLyDatTour.aspx" class="btn btn-sm btn-outline-primary">Xem tất cả</a>
        </div>
    </div>

    <!-- Tin nhan lien he -->
    <div class="col-lg-5">
        <div class="admin-card">
            <div class="admin-card-title"><i class="fas fa-envelope me-2 text-primary"></i>Tin Nhắn Mới</div>
            <div id="lienHeList" runat="server">
                <p class="text-muted text-center py-3">Không có tin nhắn mới.</p>
            </div>
            <a href="QuanLyLienHe.aspx" class="btn btn-sm btn-outline-primary">Xem tất cả</a>
        </div>
    </div>
</div>

<!-- Quick links -->
<div class="row g-3 mt-2">
    <div class="col-12">
        <div class="admin-card">
            <div class="admin-card-title"><i class="fas fa-plus me-2 text-primary"></i>Thêm Nhanh</div>
            <div class="d-flex gap-3 flex-wrap">
                <a href="QuanLyDiaDiem.aspx?action=add" class="btn btn-outline-primary btn-sm"><i class="fas fa-map-pin me-1"></i>Thêm Địa Điểm</a>
                <a href="QuanLyTour.aspx?action=add" class="btn btn-outline-primary btn-sm"><i class="fas fa-map me-1"></i>Thêm Tour</a>
                <a href="QuanLyTinTuc.aspx?action=add" class="btn btn-outline-primary btn-sm"><i class="fas fa-newspaper me-1"></i>Thêm Tin Tức</a>
                <a href="QuanLyLuuTru.aspx?action=add" class="btn btn-outline-primary btn-sm"><i class="fas fa-hotel me-1"></i>Thêm Lưu Trú</a>
                <a href="QuanLyGallery.aspx" class="btn btn-outline-primary btn-sm"><i class="fas fa-images me-1"></i>Upload Ảnh</a>
            </div>
        </div>
    </div>
</div>

</asp:Content>
