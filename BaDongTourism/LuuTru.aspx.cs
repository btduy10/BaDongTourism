using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BaDongTourism.DAL;

public partial class LuuTruPage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadLuuTru();
    }

    private void LoadLuuTru()
    {
        var list = LuuTruDAL.GetAll();
        if (list.Count == 0) { lblNoData.Visible = true; return; }

        int delay = 0;
        foreach (var lt in list)
        {
            string imgSrc = string.IsNullOrEmpty(lt.HinhAnhDai)
                ? ResolveUrl("~/Content/images/no-image.jpg")
                : ResolveUrl("~/Content/images/uploads/" + lt.HinhAnhDai);

            string stars = "";
            for (int i = 0; i < lt.XepHang; i++) stars += "<i class='fas fa-star'></i>";

            var col = new HtmlGenericControl("div");
            col.Attributes["class"] = "col-lg-4 col-md-6";
            col.Attributes["data-aos"] = "fade-up";
            col.Attributes["data-aos-delay"] = delay.ToString();
            col.InnerHtml =
                "<div class='card-hotel h-100'>" +
                "  <div class='card-img-wrap'>" +
                "    <img src='" + imgSrc + "' alt='" + lt.TenLuuTru + "' loading='lazy' />" +
                "    <span class='card-badge'>" + lt.LoaiLuuTru + "</span>" +
                "  </div>" +
                "  <div class='card-body'>" +
                "    <div class='stars mb-1'>" + stars + "</div>" +
                "    <h5 class='card-title'>" + lt.TenLuuTru + "</h5>" +
                "    <p class='card-text'>" + Truncate(lt.MoTaNgan, 90) + "</p>" +
                "    <ul class='list-unstyled mt-2' style='font-size:0.85rem;color:#666;'>" +
                "      <li><i class='fas fa-map-marker-alt me-2 text-primary'></i>" + Truncate(lt.DiaChi, 45) + "</li>" +
                "      <li><i class='fas fa-phone me-2 text-primary'></i>" + lt.DienThoai + "</li>" +
                "      <li><i class='fas fa-tag me-2 text-primary'></i>" + lt.GiaPhong + "</li>" +
                "    </ul>" +
                "  </div>" +
                "</div>";
            luuTruList.Controls.Add(col);
            delay = (delay + 100) % 400;
        }
    }

    private string Truncate(string s, int n)
    {
        if (string.IsNullOrEmpty(s)) return "";
        return s.Length <= n ? s : s.Substring(0, n) + "...";
    }
}
