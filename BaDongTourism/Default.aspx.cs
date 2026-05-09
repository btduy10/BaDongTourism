using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BaDongTourism.DAL;

public partial class _Default : Page
{
    private Dictionary<string, string> _dtc;

    protected void Page_Load(object sender, EventArgs e)
    {
        _dtc = CaiDatDAL.GetByNhom("TrangChu");
        if (!IsPostBack)
        {
            LoadBanners();
            LoadDiaDiem();
            LoadTour();
            LoadTinTuc();
        }
    }

    // Lay gia tri CaiDat, fallback ve mac dinh
    protected string C(string key, string df = "")
    {
        if (_dtc != null && _dtc.ContainsKey(key) && _dtc[key] != "")
            return _dtc[key];
        return df;
    }

    // Lay gia tri co xuong dong -> <br/>
    protected string H(string key, string df = "")
    {
        return C(key, df).Replace("\r\n", "<br/>").Replace("\n", "<br/>");
    }

    // Thay dau cach cuoi cung bang &nbsp; de khong bi orphan syllable
    private string NoOrphan(string text)
    {
        if (string.IsNullOrEmpty(text)) return text;
        int lastSpace = text.LastIndexOf(' ');
        if (lastSpace < 0) return text;
        return text.Substring(0, lastSpace) + "&nbsp;" + text.Substring(lastSpace + 1);
    }

    // Resolve duong dan hinh anh
    protected string ImgTC(string key, string macDinh)
    {
        string val = C(key);
        if (string.IsNullOrEmpty(val))
            return ResolveUrl("~/Content/images/" + macDinh);
        if (!val.Contains("/") && !val.Contains("\\"))
            return ResolveUrl("~/Content/images/uploads/" + val);
        return ResolveUrl("~/Content/images/" + val);
    }

    private void LoadBanners()
    {
        var list = BannerDAL.GetAll(chiActive: true);
        if (list.Count == 0) return; // Giu slide mac dinh trong .aspx

        // Xoa slide mac dinh
        bannerWrapper.Controls.Clear();
        bannerWrapper.InnerHtml = "";

        foreach (var b in list)
        {
            string bgStyle = string.IsNullOrEmpty(b.HinhAnh)
                ? "background:linear-gradient(135deg,#0077b6,#023e8a);"
                : "background-image:url('" + ResolveUrl("~/Content/images/uploads/" + b.HinhAnh) + "');";

            string ctaLink = string.IsNullOrEmpty(b.LienKet) ? "Tour.aspx" : b.LienKet;

            var slide = new HtmlGenericControl("div");
            slide.Attributes["class"] = "swiper-slide hero-slide";
            slide.Attributes["style"] = bgStyle;
            slide.InnerHtml =
                "<div class='hero-content' data-aos='fade-up'>" +
                "  <div class='hero-badge'><i class='fas fa-star me-1'></i>Điểm đến lý tưởng</div>" +
                "  <h1 class='hero-title'>" + NoOrphan(b.TieuDe) + "</h1>" +
                (string.IsNullOrEmpty(b.MoTa) ? "" : "<p class='hero-desc'>" + b.MoTa + "</p>") +
                "  <div class='d-flex gap-3 justify-content-center flex-wrap'>" +
                "    <a href='" + ctaLink + "' class='btn btn-primary btn-lg'><i class='fas fa-compass me-2'></i>Khám Phá Ngay</a>" +
                "    <a href='Tour.aspx' class='btn btn-outline-light btn-lg'><i class='fas fa-map me-2'></i>Xem Tour</a>" +
                "  </div>" +
                "</div>";
            bannerWrapper.Controls.Add(slide);
        }
    }

    private void LoadDiaDiem()
    {
        var list = DiaDiemDAL.GetAll(noiBat: true);
        int count = 0;
        foreach (var d in list)
        {
            if (count++ >= 3) break;
            string imgSrc = string.IsNullOrEmpty(d.HinhAnhDai)
                ? ResolveUrl("~/Content/images/no-image.jpg")
                : ResolveUrl("~/Content/images/uploads/" + d.HinhAnhDai);

            var col = new HtmlGenericControl("div");
            col.Attributes["class"] = "col-lg-4 col-md-6";
            col.Attributes["data-aos"] = "fade-up";
            col.Attributes["data-aos-delay"] = (count * 100).ToString();
            col.InnerHtml =
                "<div class='card-place h-100'>" +
                "  <div class='card-img-wrap'>" +
                "    <img src='" + imgSrc + "' alt='" + d.TenDiaDiem + "' loading='lazy' />" +
                "    <span class='card-badge'>" + d.TenDanhMuc + "</span>" +
                "  </div>" +
                "  <div class='card-body'>" +
                "    <h5 class='card-title'>" + d.TenDiaDiem + "</h5>" +
                "    <p class='card-text'>" + TruncateText(d.MoTaNgan, 100) + "</p>" +
                "    <div class='d-flex align-items-center gap-2 mt-3' style='min-width:0;'>" +
                "      <small class='text-muted text-truncate flex-grow-1' style='min-width:0;'><i class='fas fa-map-marker-alt me-1'></i>" + d.DiaChi + "</small>" +
                "      <a href='DiaDiemChiTiet.aspx?id=" + d.MaDiaDiem + "' class='btn btn-sm btn-outline-primary flex-shrink-0'>Chi tiết</a>" +
                "    </div>" +
                "  </div>" +
                "</div>";
            diaDiemList.Controls.Add(col);
        }
    }

    private void LoadTour()
    {
        var list = TourDAL.GetAll(noiBat: true);
        int count = 0;
        foreach (var t in list)
        {
            if (count++ >= 3) break;
            string imgSrc = string.IsNullOrEmpty(t.HinhAnhDai)
                ? ResolveUrl("~/Content/images/no-image.jpg")
                : ResolveUrl("~/Content/images/uploads/" + t.HinhAnhDai);

            var col = new HtmlGenericControl("div");
            col.Attributes["class"] = "col-lg-4 col-md-6";
            col.Attributes["data-aos"] = "fade-up";
            col.Attributes["data-aos-delay"] = (count * 100).ToString();
            col.InnerHtml =
                "<div class='card-tour h-100'>" +
                "  <div class='card-img-wrap'>" +
                "    <img src='" + imgSrc + "' alt='" + t.TenTour + "' loading='lazy' />" +
                "    <span class='card-badge'><i class='fas fa-clock me-1'></i>" + t.ThoiGian + "</span>" +
                "  </div>" +
                "  <div class='card-body'>" +
                "    <h5 class='card-title'>" + t.TenTour + "</h5>" +
                "    <p class='card-text'>" + TruncateText(t.MoTaNgan, 90) + "</p>" +
                "    <div class='d-flex gap-3 mt-2'>" +
                "      <small class='text-muted'><i class='fas fa-users me-1'></i>Tối đa " + t.SoChoToiDa + " người</small>" +
                "    </div>" +
                "  </div>" +
                "  <div class='tour-price'>" +
                "    <div>" +
                "      <div class='price-label'>Giá từ</div>" +
                "      <div class='price-amount'>" + t.GiaNguoiLon.ToString("N0") + "đ</div>" +
                "    </div>" +
                "    <a href='TourChiTiet.aspx?id=" + t.MaTour + "' class='btn btn-primary btn-sm'>Đặt Tour</a>" +
                "  </div>" +
                "</div>";
            tourList.Controls.Add(col);
        }
    }

    private void LoadTinTuc()
    {
        var list = TinTucDAL.GetAll(top: 3);
        int count = 0;
        foreach (var tt in list)
        {
            if (count++ >= 3) break;
            string imgSrc = string.IsNullOrEmpty(tt.HinhAnhDai)
                ? ResolveUrl("~/Content/images/no-image.jpg")
                : ResolveUrl("~/Content/images/uploads/" + tt.HinhAnhDai);

            var col = new HtmlGenericControl("div");
            col.Attributes["class"] = "col-lg-4 col-md-6";
            col.Attributes["data-aos"] = "fade-up";
            col.Attributes["data-aos-delay"] = (count * 100).ToString();
            col.InnerHtml =
                "<div class='card-news h-100'>" +
                "  <div class='card-img-wrap'>" +
                "    <img src='" + imgSrc + "' alt='" + tt.TieuDe + "' loading='lazy' />" +
                "    <span class='card-badge'>" + tt.TenDanhMuc + "</span>" +
                "  </div>" +
                "  <div class='card-body'>" +
                "    <div class='detail-meta mb-2'>" +
                "      <span><i class='fas fa-calendar'></i>" + tt.NgayDang.ToString("dd/MM/yyyy") + "</span>" +
                "      <span><i class='fas fa-eye'></i>" + tt.LuotXem + " lượt xem</span>" +
                "    </div>" +
                "    <h5 class='card-title'><a href='TinTucChiTiet.aspx?id=" + tt.MaTinTuc + "' class='text-dark'>" + tt.TieuDe + "</a></h5>" +
                "    <p class='card-text'>" + TruncateText(tt.TomTat, 100) + "</p>" +
                "    <a href='TinTucChiTiet.aspx?id=" + tt.MaTinTuc + "' class='btn btn-sm btn-outline-primary mt-2'>Đọc thêm</a>" +
                "  </div>" +
                "</div>";
            tinTucList.Controls.Add(col);
        }
    }

    private string TruncateText(string text, int maxLen)
    {
        if (string.IsNullOrEmpty(text)) return "";
        return text.Length <= maxLen ? text : text.Substring(0, maxLen) + "...";
    }
}
