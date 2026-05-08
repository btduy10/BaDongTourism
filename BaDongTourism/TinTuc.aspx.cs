using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BaDongTourism.DAL;

public partial class TinTucPage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadTinTuc();
    }

    private void LoadTinTuc()
    {
        var list = TinTucDAL.GetAll();
        if (list.Count == 0) { lblNoData.Visible = true; return; }

        int delay = 0;
        foreach (var tt in list)
        {
            string imgSrc = string.IsNullOrEmpty(tt.HinhAnhDai)
                ? ResolveUrl("~/Content/images/no-image.jpg")
                : ResolveUrl("~/Content/images/uploads/" + tt.HinhAnhDai);

            var col = new HtmlGenericControl("div");
            col.Attributes["class"] = "col-lg-4 col-md-6";
            col.Attributes["data-aos"] = "fade-up";
            col.Attributes["data-aos-delay"] = delay.ToString();
            col.InnerHtml =
                "<div class='card-news h-100'>" +
                "  <div class='card-img-wrap'>" +
                "    <img src='" + imgSrc + "' alt='" + tt.TieuDe + "' loading='lazy' />" +
                "    <span class='card-badge'>" + tt.TenDanhMuc + "</span>" +
                "  </div>" +
                "  <div class='card-body'>" +
                "    <div class='detail-meta mb-2'>" +
                "      <span><i class='fas fa-calendar'></i>" + tt.NgayDang.ToString("dd/MM/yyyy") + "</span>" +
                "      <span><i class='fas fa-eye'></i>" + tt.LuotXem + "</span>" +
                "    </div>" +
                "    <h5 class='card-title'><a href='TinTucChiTiet.aspx?id=" + tt.MaTinTuc + "' class='text-dark'>" + tt.TieuDe + "</a></h5>" +
                "    <p class='card-text'>" + Truncate(tt.TomTat, 110) + "</p>" +
                "    <a href='TinTucChiTiet.aspx?id=" + tt.MaTinTuc + "' class='btn btn-sm btn-outline-primary mt-2'>Đọc thêm <i class='fas fa-arrow-right ms-1'></i></a>" +
                "  </div>" +
                "</div>";
            tinTucList.Controls.Add(col);
            delay = (delay + 100) % 400;
        }
    }

    private string Truncate(string s, int n)
    {
        if (string.IsNullOrEmpty(s)) return "";
        return s.Length <= n ? s : s.Substring(0, n) + "...";
    }
}
