using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BaDongTourism.DAL;

public partial class AmThucPage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadAmThuc();
    }

    private void LoadAmThuc()
    {
        var list = AmThucDAL.GetAll();
        if (list.Count == 0) { lblNoData.Visible = true; return; }

        int delay = 0;
        foreach (var at in list)
        {
            string imgSrc = string.IsNullOrEmpty(at.HinhAnhDai)
                ? ResolveUrl("~/Content/images/no-image.jpg")
                : ResolveUrl("~/Content/images/uploads/" + at.HinhAnhDai);

            string diaChiHtml = string.IsNullOrEmpty(at.DiaChi) ? ""
                : "<li><i class='fas fa-map-marker-alt me-2 text-primary'></i>" + at.DiaChi + "</li>";
            string gioHtml = string.IsNullOrEmpty(at.GioMoCua) ? ""
                : "<li><i class='fas fa-clock me-2 text-primary'></i>" + at.GioMoCua + "</li>";
            string giaHtml = string.IsNullOrEmpty(at.KhoangGia) ? ""
                : "<li><i class='fas fa-tag me-2 text-primary'></i>" + at.KhoangGia + "</li>";

            var col = new HtmlGenericControl("div");
            col.Attributes["class"] = "col-lg-4 col-md-6";
            col.Attributes["data-aos"] = "fade-up";
            col.Attributes["data-aos-delay"] = delay.ToString();
            col.InnerHtml =
                "<div class='card-food h-100'>" +
                "  <div class='card-img-wrap'>" +
                "    <img src='" + imgSrc + "' alt='" + at.TenAmThuc + "' loading='lazy' />" +
                "    <span class='card-badge'>" + at.LoaiAmThuc + "</span>" +
                "  </div>" +
                "  <div class='card-body'>" +
                "    <h5 class='card-title'>" + at.TenAmThuc + "</h5>" +
                "    <p class='card-text'>" + Truncate(at.MoTaNgan, 100) + "</p>" +
                "    <ul class='list-unstyled mt-2' style='font-size:0.85rem;color:#666;'>" +
                diaChiHtml + gioHtml + giaHtml +
                "    </ul>" +
                "  </div>" +
                "</div>";
            amThucList.Controls.Add(col);
            delay = (delay + 100) % 400;
        }
    }

    private string Truncate(string s, int n)
    {
        if (string.IsNullOrEmpty(s)) return "";
        return s.Length <= n ? s : s.Substring(0, n) + "...";
    }
}
