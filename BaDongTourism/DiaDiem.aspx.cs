using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BaDongTourism.DAL;

public partial class DiaDiemPage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadDiaDiem();
    }

    private void LoadDiaDiem()
    {
        var list = DiaDiemDAL.GetAll();
        if (list.Count == 0) { lblNoData.Visible = true; return; }

        int delay = 0;
        foreach (var d in list)
        {
            string imgSrc = string.IsNullOrEmpty(d.HinhAnhDai)
                ? ResolveUrl("~/Content/images/no-image.jpg")
                : ResolveUrl("~/Content/images/uploads/" + d.HinhAnhDai);

            var col = new HtmlGenericControl("div");
            col.Attributes["class"] = "col-lg-4 col-md-6";
            col.Attributes["data-aos"] = "fade-up";
            col.Attributes["data-aos-delay"] = delay.ToString();
            col.InnerHtml =
                "<div class='card-place h-100'>" +
                "  <div class='card-img-wrap'>" +
                "    <img src='" + imgSrc + "' alt='" + d.TenDiaDiem + "' loading='lazy' />" +
                "    <span class='card-badge'>" + d.TenDanhMuc + "</span>" +
                "  </div>" +
                "  <div class='card-body'>" +
                "    <h5 class='card-title'>" + d.TenDiaDiem + "</h5>" +
                "    <p class='card-text'>" + Truncate(d.MoTaNgan, 100) + "</p>" +
                "    <div class='d-flex justify-content-between align-items-center mt-3'>" +
                "      <small class='text-muted'><i class='fas fa-map-marker-alt me-1'></i>" + Truncate(d.DiaChi, 40) + "</small>" +
                "      <a href='DiaDiemChiTiet.aspx?id=" + d.MaDiaDiem + "' class='btn btn-sm btn-outline-primary'>Chi tiết</a>" +
                "    </div>" +
                "  </div>" +
                "</div>";
            diaDiemList.Controls.Add(col);
            delay = (delay + 100) % 400;
        }
    }

    private string Truncate(string s, int n)
    {
        if (string.IsNullOrEmpty(s)) return "";
        return s.Length <= n ? s : s.Substring(0, n) + "...";
    }
}
