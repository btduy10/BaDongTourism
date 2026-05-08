using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BaDongTourism.DAL;

public partial class TourPage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadTours();
    }

    private void LoadTours()
    {
        var list = TourDAL.GetAll();
        if (list.Count == 0) { lblNoData.Visible = true; return; }

        int delay = 0;
        foreach (var t in list)
        {
            string imgSrc = string.IsNullOrEmpty(t.HinhAnhDai)
                ? ResolveUrl("~/Content/images/no-image.jpg")
                : ResolveUrl("~/Content/images/uploads/" + t.HinhAnhDai);

            var col = new HtmlGenericControl("div");
            col.Attributes["class"] = "col-lg-4 col-md-6";
            col.Attributes["data-aos"] = "fade-up";
            col.Attributes["data-aos-delay"] = delay.ToString();
            col.InnerHtml =
                "<div class='card-tour h-100'>" +
                "  <div class='card-img-wrap'>" +
                "    <img src='" + imgSrc + "' alt='" + t.TenTour + "' loading='lazy' />" +
                "    <span class='card-badge'><i class='fas fa-clock me-1'></i>" + t.ThoiGian + "</span>" +
                "  </div>" +
                "  <div class='card-body'>" +
                "    <h5 class='card-title'>" + t.TenTour + "</h5>" +
                "    <p class='card-text'>" + Truncate(t.MoTaNgan, 100) + "</p>" +
                "    <div class='d-flex gap-3 mt-2 flex-wrap'>" +
                "      <small class='text-muted'><i class='fas fa-map-marker-alt me-1'></i>" + t.DiaDiem + "</small>" +
                "      <small class='text-muted'><i class='fas fa-users me-1'></i>Tối đa " + t.SoChoToiDa + " người</small>" +
                "    </div>" +
                "  </div>" +
                "  <div class='tour-price'>" +
                "    <div>" +
                "      <div class='price-label'>Người lớn từ</div>" +
                "      <div class='price-amount'>" + t.GiaNguoiLon.ToString("N0") + "đ</div>" +
                "    </div>" +
                "    <a href='TourChiTiet.aspx?id=" + t.MaTour + "' class='btn btn-primary btn-sm'>Xem &amp; Đặt</a>" +
                "  </div>" +
                "</div>";
            tourList.Controls.Add(col);
            delay = (delay + 100) % 400;
        }
    }

    private string Truncate(string s, int n)
    {
        if (string.IsNullOrEmpty(s)) return "";
        return s.Length <= n ? s : s.Substring(0, n) + "...";
    }
}
