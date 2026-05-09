<%@ Page Title="Trang Chủ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<!-- HERO SLIDER -->
<section class="hero-slider">
    <div class="swiper hero-swiper">
        <div class="swiper-wrapper" id="bannerWrapper" runat="server">
            <!-- Default slide neu khong co data -->
            <div class="swiper-slide hero-slide" style="background-image:url('Content/images/hero-default.jpg')">
                <div class="hero-content" data-aos="fade-up">
                    <div class="hero-badge"><i class="fas fa-star me-1"></i>Điểm đến lý tưởng</div>
                    <h1 class="hero-title">Khám Phá Vẻ Đẹp<br/>Bãi Biển Ba Động</h1>
                    <p class="hero-desc">Bãi biển hoang sơ dài hơn 10km – nơi cát trắng, sóng xanh và gió biển hòa quyện thành bức tranh thiên nhiên tuyệt đẹp</p>
                    <div class="d-flex gap-3 justify-content-center flex-wrap">
                        <a href="DiaDiem.aspx" class="btn btn-primary btn-lg"><i class="fas fa-compass me-2"></i>Khám Phá Ngay</a>
                        <a href="Tour.aspx" class="btn btn-outline-light btn-lg"><i class="fas fa-map me-2"></i>Xem Tour</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="swiper-pagination"></div>
    </div>
</section>

<!-- STATS BAR -->
<section class="stats-bar">
    <div class="container">
        <div class="row g-3 text-center">
            <div class="col-6 col-md-3">
                <div class="stat-number" data-target="<%=C("stat1_so","10")%>" data-suffix="<%=C("stat1_hauTo","km+")%>">0</div>
                <div class="stat-label"><%=C("stat1_nhan","Chiều dài bãi biển")%></div>
            </div>
            <div class="col-6 col-md-3">
                <div class="stat-number" data-target="<%=C("stat2_so","50")%>" data-suffix="<%=C("stat2_hauTo","+")%>">0</div>
                <div class="stat-label"><%=C("stat2_nhan","Tour du lịch")%></div>
            </div>
            <div class="col-6 col-md-3">
                <div class="stat-number" data-target="<%=C("stat3_so","30")%>" data-suffix="<%=C("stat3_hauTo","+")%>">0</div>
                <div class="stat-label"><%=C("stat3_nhan","Cơ sở lưu trú")%></div>
            </div>
            <div class="col-6 col-md-3">
                <div class="stat-number" data-target="<%=C("stat4_so","100000")%>" data-suffix="<%=C("stat4_hauTo","+")%>">0</div>
                <div class="stat-label"><%=C("stat4_nhan","Lượt khách/năm")%></div>
            </div>
        </div>
    </div>
</section>

<!-- GIOI THIEU NGAN -->
<section class="section-py">
    <div class="container">
        <div class="row align-items-center g-5">
            <div class="col-lg-6" data-aos="fade-right">
                <div class="position-relative">
                    <img src="<%=ImgTC("tc_hinh","about-main.jpg")%>" alt="Bãi biển Ba Động"
                         class="img-fluid rounded-4 shadow" style="height:400px;width:100%;object-fit:cover;" />
                    <div class="position-absolute bottom-0 end-0 p-3 m-3 bg-white rounded-3 shadow" style="min-width:160px;">
                        <div class="d-flex align-items-center gap-2">
                            <div style="width:42px;height:42px;background:linear-gradient(135deg,#0077b6,#00b4d8);border-radius:50%;display:flex;align-items:center;justify-content:center;">
                                <i class="fas fa-award text-white"></i>
                            </div>
                            <div>
                                <div style="font-weight:800;font-size:1.1rem;color:#0077b6;"><%=C("tc_badge_so","Top 10")%></div>
                                <div style="font-size:0.75rem;color:#666;"><%=C("tc_badge_ten","Bãi biển đẹp VN")%></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6" data-aos="fade-left">
                <div class="section-subtitle"><%=C("tc_subtitle","Về Chúng Tôi")%></div>
                <h2 class="section-title"><%=H("tc_tieude","Viên Ngọc Xanh<br/>Của Trà Vinh")%></h2>
                <div class="section-divider" style="margin:0 0 20px;"></div>
                <p class="mb-4"><%=C("tc_doan_1","Bãi biển Ba Động thuộc xã Trường Long Hòa, huyện Duyên Hải, tỉnh Trà Vinh – nằm cách TP. Trà Vinh khoảng 50km về phía Nam. Đây là một trong những bãi biển hoang sơ, đẹp và ít bị tác động nhất ở miền Tây Nam Bộ.")%></p>
                <p class="mb-4"><%=C("tc_doan_2","Với bờ biển dài hơn 10km, cát trắng mịn, sóng êm và không khí trong lành, Ba Động đang dần trở thành điểm đến hấp dẫn cho những du khách muốn tìm về thiên nhiên nguyên sơ.")%></p>
                <div class="row g-3 mb-4">
                    <div class="col-6">
                        <div class="d-flex gap-3 align-items-start">
                            <div style="color:#0077b6;font-size:1.3rem;margin-top:2px;"><i class="fas fa-water"></i></div>
                            <div><strong><%=C("tc_feat1_ten","Biển Sạch")%></strong><p class="mb-0 small text-muted"><%=C("tc_feat1_mo","Nước biển trong xanh, ít ô nhiễm")%></p></div>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="d-flex gap-3 align-items-start">
                            <div style="color:#0077b6;font-size:1.3rem;margin-top:2px;"><i class="fas fa-leaf"></i></div>
                            <div><strong><%=C("tc_feat2_ten","Sinh Thái")%></strong><p class="mb-0 small text-muted"><%=C("tc_feat2_mo","Rừng ngập mặn đa dạng")%></p></div>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="d-flex gap-3 align-items-start">
                            <div style="color:#0077b6;font-size:1.3rem;margin-top:2px;"><i class="fas fa-fish"></i></div>
                            <div><strong><%=C("tc_feat3_ten","Hải Sản")%></strong><p class="mb-0 small text-muted"><%=C("tc_feat3_mo","Cua Huỳnh Đế nổi tiếng")%></p></div>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="d-flex gap-3 align-items-start">
                            <div style="color:#0077b6;font-size:1.3rem;margin-top:2px;"><i class="fas fa-heart"></i></div>
                            <div><strong><%=C("tc_feat4_ten","Thân Thiện")%></strong><p class="mb-0 small text-muted"><%=C("tc_feat4_mo","Người dân hiếu khách")%></p></div>
                        </div>
                    </div>
                </div>
                <a href="GioiThieu.aspx" class="btn btn-primary">Xem Thêm <i class="fas fa-arrow-right ms-2"></i></a>
            </div>
        </div>
    </div>
</section>

<!-- DIA DIEM NOI BAT -->
<section class="section-py section-bg">
    <div class="container">
        <div class="section-header" data-aos="fade-up">
            <div class="section-subtitle">Địa Điểm</div>
            <h2 class="section-title">Điểm Tham Quan Nổi Bật</h2>
            <div class="section-divider"></div>
            <p class="section-desc">Khám phá những địa điểm hấp dẫn nhất tại vùng biển Ba Động</p>
        </div>
        <div class="row g-4" id="diaDiemList" runat="server">
            <!-- Render by code-behind -->
        </div>
        <div class="text-center mt-5" data-aos="fade-up">
            <a href="DiaDiem.aspx" class="btn btn-outline-primary btn-lg">
                Xem Tất Cả Địa Điểm <i class="fas fa-arrow-right ms-2"></i>
            </a>
        </div>
    </div>
</section>

<!-- TOUR NOI BAT -->
<section class="section-py">
    <div class="container">
        <div class="section-header" data-aos="fade-up">
            <div class="section-subtitle">Tour Du Lịch</div>
            <h2 class="section-title">Tour Hấp Dẫn Nhất</h2>
            <div class="section-divider"></div>
            <p class="section-desc">Những chuyến đi được yêu thích nhất tại Ba Động</p>
        </div>
        <div class="row g-4 justify-content-center" id="tourList" runat="server">
            <!-- Render by code-behind -->
        </div>
        <div class="text-center mt-5" data-aos="fade-up">
            <a href="Tour.aspx" class="btn btn-primary btn-lg">
                <i class="fas fa-map me-2"></i>Xem Tất Cả Tour
            </a>
        </div>
    </div>
</section>

<!-- AM THUC & LUU TRU BANNER -->
<section class="section-py section-bg">
    <div class="container">
        <div class="row g-4">
            <div class="col-md-6" data-aos="fade-right">
                <div class="position-relative rounded-4 overflow-hidden" style="height:280px;background:linear-gradient(135deg,#0077b6,#023e8a);">
                    <%if(!string.IsNullOrEmpty(ImgTC("at_hinh",""))){%>
                    <img src="<%=ImgTC("at_hinh","")%>" alt="Ẩm thực Ba Động"
                         style="width:100%;height:100%;object-fit:cover;position:absolute;inset:0;" />
                    <%}%>
                    <div style="position:absolute;inset:0;background:linear-gradient(135deg,rgba(0,30,60,0.7),rgba(0,119,182,0.3));"></div>
                    <div class="position-absolute bottom-0 start-0 p-4 text-white">
                        <h4 class="fw-bold mb-1"><%=C("at_tieude","Ẩm Thực Địa Phương")%></h4>
                        <p class="mb-3 opacity-75 small"><%=C("at_mota","Cua Huỳnh Đế, hải sản tươi ngon đặc trưng")%></p>
                        <a href="AmThuc.aspx" class="btn btn-sm btn-light"><%=C("at_btn","Khám Phá")%> <i class="fas fa-arrow-right ms-1"></i></a>
                    </div>
                </div>
            </div>
            <div class="col-md-6" data-aos="fade-left">
                <div class="position-relative rounded-4 overflow-hidden" style="height:280px;background:linear-gradient(135deg,#023e8a,#00b4d8);">
                    <%if(!string.IsNullOrEmpty(ImgTC("lt_hinh",""))){%>
                    <img src="<%=ImgTC("lt_hinh","")%>" alt="Lưu trú Ba Động"
                         style="width:100%;height:100%;object-fit:cover;position:absolute;inset:0;" />
                    <%}%>
                    <div style="position:absolute;inset:0;background:linear-gradient(135deg,rgba(0,30,60,0.7),rgba(0,180,216,0.3));"></div>
                    <div class="position-absolute bottom-0 start-0 p-4 text-white">
                        <h4 class="fw-bold mb-1"><%=C("lt_tieude","Lưu Trú Tiện Nghi")%></h4>
                        <p class="mb-3 opacity-75 small"><%=C("lt_mota","Resort, khách sạn, nhà nghỉ đa dạng giá tốt")%></p>
                        <a href="LuuTru.aspx" class="btn btn-sm btn-light"><%=C("lt_btn","Xem Ngay")%> <i class="fas fa-arrow-right ms-1"></i></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<!-- TIN TUC MOI NHAT -->
<section class="section-py">
    <div class="container">
        <div class="section-header" data-aos="fade-up">
            <div class="section-subtitle">Tin Tức</div>
            <h2 class="section-title">Tin Tức & Sự Kiện</h2>
            <div class="section-divider"></div>
        </div>
        <div class="row g-4" id="tinTucList" runat="server">
            <!-- Render by code-behind -->
        </div>
        <div class="text-center mt-5" data-aos="fade-up">
            <a href="TinTuc.aspx" class="btn btn-outline-primary">Xem Tất Cả Tin Tức</a>
        </div>
    </div>
</section>

<!-- CTA -->
<section style="background:linear-gradient(135deg,#0077b6,#00b4d8);padding:70px 0;">
    <div class="container text-center text-white" data-aos="zoom-in">
        <h2 class="mb-3" style="font-family:'Playfair Display',serif;font-size:2rem;"><%=C("cta_tieude","Sẵn Sàng Khám Phá Ba Động?")%></h2>
        <p class="mb-4 opacity-90"><%=C("cta_mota","Liên hệ ngay để được tư vấn và đặt tour với giá tốt nhất!")%></p>
        <div class="d-flex gap-3 justify-content-center flex-wrap">
            <a href="<%=C("cta_btn1_link","DatTour.aspx")%>" class="btn btn-accent btn-lg"><i class="fas fa-calendar-check me-2"></i><%=C("cta_btn1","Đặt Tour Ngay")%></a>
            <a href="<%=C("cta_btn2_link","LienHe.aspx")%>" class="btn btn-outline-light btn-lg"><i class="fas fa-phone me-2"></i><%=C("cta_btn2","Liên Hệ")%></a>
        </div>
    </div>
</section>

</asp:Content>
