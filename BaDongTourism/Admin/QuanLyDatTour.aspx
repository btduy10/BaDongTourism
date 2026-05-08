<%@ Page Title="Quản Lý Đặt Tour" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeFile="QuanLyDatTour.aspx.cs" Inherits="Admin_QuanLyDatTour" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" runat="server">

<div class="d-flex justify-content-between align-items-center mb-4">
    <h5 class="fw-bold mb-0"><i class="fas fa-calendar-check me-2 text-primary"></i>Quản Lý Đặt Tour</h5>
</div>
<asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3" />

<div class="admin-card">
    <div class="table-responsive">
        <table class="table table-admin table-hover">
            <thead>
                <tr>
                    <th>#</th><th>Khách Hàng</th><th>Tour</th><th>Số Người</th>
                    <th>Ngày KH</th><th>Tổng Tiền</th><th>Trạng Thái</th><th>Hành Động</th>
                </tr>
            </thead>
            <tbody id="tableBody" runat="server">
                <tr><td colspan="8" class="text-center text-muted py-4">Chưa có đơn đặt tour.</td></tr>
            </tbody>
        </table>
    </div>
</div>

</asp:Content>
