using System;
using System.Web.UI;
using BaDongTourism.DAL;

public partial class TinTucChiTiet : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id;
        if (!int.TryParse(Request.QueryString["id"], out id))
        { ShowNotFound(); return; }

        var tt = TinTucDAL.GetById(id);
        if (tt == null) { ShowNotFound(); return; }

        TinTucDAL.TangLuotXem(id);

        Page.Title           = tt.TieuDe;
        lblTieuDe.InnerText  = tt.TieuDe;
        lblDanhMuc.InnerText = tt.TenDanhMuc;
        lblNgay.InnerText    = tt.NgayDang.ToString("dd/MM/yyyy");
        lblTacGia.InnerText  = tt.TenTacGia;
        lblLuotXem.InnerText = tt.LuotXem.ToString();
        lblNoiDung.InnerHtml = tt.NoiDung;

        imgMain.Src = string.IsNullOrEmpty(tt.HinhAnhDai)
            ? ResolveUrl("~/Content/images/no-image.jpg")
            : ResolveUrl("~/Content/images/uploads/" + tt.HinhAnhDai);
        imgMain.Alt = tt.TieuDe;

        LoadSidebar(id);
    }

    private void LoadSidebar(int currentId)
    {
        var list = TinTucDAL.GetAll(top: 6);
        var sb = new System.Text.StringBuilder();
        foreach (var item in list)
        {
            if (item.MaTinTuc == currentId) continue;
            string img = string.IsNullOrEmpty(item.HinhAnhDai)
                ? ResolveUrl("~/Content/images/no-image.jpg")
                : ResolveUrl("~/Content/images/uploads/" + item.HinhAnhDai);
            sb.Append(
                "<div class='sidebar-news-item'>" +
                "  <img src='" + img + "' class='sidebar-news-img' alt='" + item.TieuDe + "' />" +
                "  <div>" +
                "    <a href='TinTucChiTiet.aspx?id=" + item.MaTinTuc + "' class='sidebar-news-title d-block'>" + item.TieuDe + "</a>" +
                "    <div class='sidebar-news-date'><i class='fas fa-calendar me-1'></i>" + item.NgayDang.ToString("dd/MM/yyyy") + "</div>" +
                "  </div>" +
                "</div>");
        }
        sidebarTinTuc.InnerHtml = sb.ToString();
    }

    private void ShowNotFound()
    {
        pnlContent.Visible  = false;
        lblNotFound.Visible = true;
    }
}
