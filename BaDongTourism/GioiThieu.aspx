<%@ Page Title="Giới Thiệu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="GioiThieu.aspx.cs" Inherits="GioiThieuPage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-hero">
    <div class="container">
        <h1><i class="fas fa-umbrella-beach me-3"></i>Giới Thiệu Ba Động</h1>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx"><i class="fas fa-home"></i> Trang chủ</a></li>
                <li class="breadcrumb-item active">Giới Thiệu</li>
            </ol>
        </nav>
    </div>
</div>

<!-- GIOI THIEU CHINH -->
<section class="section-py">
    <div class="container">
        <div class="row g-5 align-items-center">
            <div class="col-lg-6" data-aos="fade-right">
                <div class="section-subtitle">Tổng Quan</div>
                <h2 class="section-title"><%=C("gt_tieude_chinh","Bãi Biển Ba Động – Trà Vinh")%></h2>
                <div class="section-divider" style="margin:0 0 20px;"></div>
                <p class="mb-3"><%=C("gt_doan_1","Bãi biển Ba Động thuộc xã Trường Long Hòa, huyện Duyên Hải, tỉnh Trà Vinh.")%></p>
                <p class="mb-3"><%=C("gt_doan_2","Bãi biển dài hơn 10km với bãi cát trắng phẳng lì, sóng êm và nước biển trong xanh.")%></p>
                <p class="mb-4"><%=C("gt_doan_3","Ngoài vẻ đẹp thiên nhiên, Ba Động còn nổi tiếng với những đặc sản biển phong phú.")%></p>
                <div class="row g-3">
                    <div class="col-6">
                        <div class="p-3 rounded-3" style="background:#f0f8ff;text-align:center;">
                            <div style="font-size:2rem;font-weight:800;color:#0077b6;"><%=C("gt_stat_1_so","10km+")%></div>
                            <div style="font-size:0.85rem;color:#666;"><%=C("gt_stat_1_ten","Chiều dài bờ biển")%></div>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="p-3 rounded-3" style="background:#f0f8ff;text-align:center;">
                            <div style="font-size:2rem;font-weight:800;color:#0077b6;"><%=C("gt_stat_2_so","50km")%></div>
                            <div style="font-size:0.85rem;color:#666;"><%=C("gt_stat_2_ten","Từ TP. Trà Vinh")%></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6" data-aos="fade-left">
                <img src="<%=Img("gt_hinh_chinh","about-main.jpg")%>" alt="Bãi biển Ba Động"
                     class="img-fluid rounded-4 shadow" style="height:430px;width:100%;object-fit:cover;" />
            </div>
        </div>
    </div>
</section>

<!-- HIGHLIGHTS (giu nguyen hardcode vi complex) -->
<section class="section-py section-bg">
    <div class="container">
        <div class="section-header" data-aos="fade-up">
            <div class="section-subtitle">Điểm Nổi Bật</div>
            <h2 class="section-title">Tại Sao Chọn Ba Động?</h2>
            <div class="section-divider"></div>
        </div>
        <div class="row g-4">
            <% string[] icons  = {"water","leaf","fish","sun","users","camera"}; %>
            <% string[] titles = {"Biển Sạch Hoang Sơ","Sinh Thái Phong Phú","Hải Sản Tươi Ngon","Khí Hậu Trong Lành","Người Dân Thân Thiện","Phong Cảnh Đẹp"}; %>
            <% string[] descs  = {
                "Bãi biển chưa bị khai thác quá mức, giữ nguyên vẻ đẹp tự nhiên",
                "Rừng ngập mặn đa dạng, hệ sinh thái ven biển phong phú",
                "Cua Huỳnh Đế, ghẹ, sò huyết... đặc sản biển nổi tiếng",
                "Không khí biển trong lành, ít ô nhiễm, lý tưởng nghỉ dưỡng",
                "Người dân địa phương hiếu khách, văn hóa Khmer đặc sắc",
                "Bình minh và hoàng hôn tuyệt đẹp, lý tưởng cho nhiếp ảnh"
            }; %>
            <% for (int i = 0; i < titles.Length; i++) { %>
            <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="<%=i*80%>">
                <div class="p-4 bg-white rounded-4 shadow-sm h-100 text-center">
                    <div class="mb-3" style="width:64px;height:64px;background:linear-gradient(135deg,#0077b6,#00b4d8);border-radius:50%;display:flex;align-items:center;justify-content:center;margin:0 auto;">
                        <i class="fas fa-<%=icons[i]%> text-white" style="font-size:1.5rem;"></i>
                    </div>
                    <h6 class="fw-bold mb-2"><%=titles[i]%></h6>
                    <p class="text-muted small mb-0"><%=descs[i]%></p>
                </div>
            </div>
            <% } %>
        </div>
    </div>
</section>

<!-- VAN HOA LICH SU -->
<section class="section-py">
    <div class="container">
        <div class="row g-5 align-items-center">
            <div class="col-lg-6" data-aos="fade-right">
                <img src="<%=Img("vhls_hinh","culture.jpg")%>" alt="Văn hóa Khmer"
                     class="img-fluid rounded-4 shadow" style="height:380px;width:100%;object-fit:cover;" />
            </div>
            <div class="col-lg-6" data-aos="fade-left">
                <div class="section-subtitle">Văn Hóa & Lịch Sử</div>
                <h2 class="section-title"><%=C("vhls_tieude","Vùng Đất Con Người")%></h2>
                <div class="section-divider" style="margin:0 0 20px;"></div>
                <p class="mb-3"><%=C("vhls_doan_1","Trà Vinh là tỉnh có đông đồng bào Khmer sinh sống.")%></p>
                <p class="mb-3"><%=C("vhls_doan_2","Lễ hội Nghinh Ông được tổ chức hằng năm vào tháng 5 âm lịch.")%></p>
                <p class="mb-0"><%=C("vhls_doan_3","Làng nghề đan lát từ lá buông, nghề làm bánh tét truyền thống...")%></p>
            </div>
        </div>
    </div>
</section>

<!-- HUONG DAN DI LAI -->
<section class="section-py section-bg">
    <div class="container">
        <div class="section-header" data-aos="fade-up">
            <div class="section-subtitle">Hướng Dẫn</div>
            <h2 class="section-title">Cách Di Chuyển Đến Ba Động</h2>
            <div class="section-divider"></div>
        </div>
        <div class="row g-4">
            <div class="col-md-4" data-aos="fade-up" data-aos-delay="0">
                <div class="p-4 bg-white rounded-4 shadow-sm h-100">
                    <div class="text-center mb-3" style="color:#0077b6;font-size:2.5rem;"><i class="fas fa-car"></i></div>
                    <h6 class="fw-bold text-center mb-3">Từ TP. Hồ Chí Minh</h6>
                    <p class="text-muted small"><%=C("dichuy_o_to","Đi xe ô tô theo hướng QL1A → Vĩnh Long → Trà Vinh → Duyên Hải → Ba Động.")%></p>
                </div>
            </div>
            <div class="col-md-4" data-aos="fade-up" data-aos-delay="100">
                <div class="p-4 bg-white rounded-4 shadow-sm h-100">
                    <div class="text-center mb-3" style="color:#0077b6;font-size:2.5rem;"><i class="fas fa-bus"></i></div>
                    <h6 class="fw-bold text-center mb-3">Xe Khách / Xe Buýt</h6>
                    <p class="text-muted small"><%=C("dichuy_xe_khach","Từ bến xe Miền Tây đi xe khách đến TP. Trà Vinh, sau đó đi xe ôm ~50km.")%></p>
                </div>
            </div>
            <div class="col-md-4" data-aos="fade-up" data-aos-delay="200">
                <div class="p-4 bg-white rounded-4 shadow-sm h-100">
                    <div class="text-center mb-3" style="color:#0077b6;font-size:2.5rem;"><i class="fas fa-motorcycle"></i></div>
                    <h6 class="fw-bold text-center mb-3">Xe Máy / Phượt</h6>
                    <p class="text-muted small"><%=C("dichuy_xe_may","Rất phù hợp cho những ai thích phượt. Đường đẹp, phong cảnh tuyệt vời.")%></p>
                </div>
            </div>
        </div>
    </div>
</section>

</asp:Content>
