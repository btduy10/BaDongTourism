<%@ Page Title="Liên Hệ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="LienHe.aspx.cs" Inherits="LienHePage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-hero">
    <div class="container">
        <h1><i class="fas fa-envelope me-3"></i>Liên Hệ Với Chúng Tôi</h1>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx"><i class="fas fa-home"></i> Trang chủ</a></li>
                <li class="breadcrumb-item active">Liên Hệ</li>
            </ol>
        </nav>
    </div>
</div>

<section class="section-py">
    <div class="container">
        <div class="row g-5 align-items-start">

            <!-- Form -->
            <div class="col-lg-7" data-aos="fade-right">
                <h4 class="fw-bold mb-4">Gửi Tin Nhắn Cho Chúng Tôi</h4>
                <div class="contact-form">
                    <div class="row g-3">
                        <div class="col-md-6">
                            <label class="form-label fw-600">Họ và tên <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" placeholder="Nguyễn Văn A" required="required" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label fw-600">Điện thoại</label>
                            <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control" placeholder="0901 234 567" />
                        </div>
                        <div class="col-md-12">
                            <label class="form-label fw-600">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="email@example.com" />
                        </div>
                        <div class="col-md-12">
                            <label class="form-label fw-600">Chủ đề</label>
                            <asp:TextBox ID="txtChuDe" runat="server" CssClass="form-control" placeholder="Đặt tour / Hỏi thông tin / ..." />
                        </div>
                        <div class="col-md-12">
                            <label class="form-label fw-600">Nội dung <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtNoiDung" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Nhập nội dung..." required="required" />
                        </div>
                        <div class="col-12">
                            <asp:Button ID="btnGui" runat="server" Text="Gửi Tin Nhắn" CssClass="btn btn-primary px-5" OnClick="btnGui_Click" />
                            <asp:Label ID="lblMsg" runat="server" CssClass="d-block mt-3" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Info -->
            <div class="col-lg-5" data-aos="fade-left">
                <div class="contact-info-card">
                    <h5 class="fw-bold mb-4"><i class="fas fa-info-circle me-2"></i>Thông Tin Liên Hệ</h5>
                    <div class="contact-info-item">
                        <div class="contact-info-icon"><i class="fas fa-map-marker-alt"></i></div>
                        <div>
                            <strong>Địa chỉ</strong>
                            <p class="mb-0 opacity-85 small">Xã Trường Long Hòa, huyện Duyên Hải, tỉnh Trà Vinh</p>
                        </div>
                    </div>
                    <div class="contact-info-item">
                        <div class="contact-info-icon"><i class="fas fa-phone-alt"></i></div>
                        <div>
                            <strong>Điện thoại</strong>
                            <p class="mb-0 opacity-85 small">0294 1234 567 – 0901 234 567</p>
                        </div>
                    </div>
                    <div class="contact-info-item">
                        <div class="contact-info-icon"><i class="fas fa-envelope"></i></div>
                        <div>
                            <strong>Email</strong>
                            <p class="mb-0 opacity-85 small">info@badong.com</p>
                        </div>
                    </div>
                    <div class="contact-info-item">
                        <div class="contact-info-icon"><i class="fas fa-clock"></i></div>
                        <div>
                            <strong>Giờ làm việc</strong>
                            <p class="mb-0 opacity-85 small">Thứ 2 – Chủ nhật: 7:00 – 18:00</p>
                        </div>
                    </div>
                </div>

                <!-- Map -->
                <div class="mt-4 rounded-4 overflow-hidden" style="height:220px;">
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d15727.63!2d106.58!3d9.58!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x0!2zOcKwMzQnNDgiLjBOIDEwNsKwMzQnNDguMEU!5e0!3m2!1svi!2svn!4v1"
                            width="100%" height="220" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
                </div>
            </div>
        </div>
    </div>
</section>

</asp:Content>
