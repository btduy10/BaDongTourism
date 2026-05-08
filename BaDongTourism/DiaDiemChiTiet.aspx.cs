using System;
using System.Web.UI;
using BaDongTourism.DAL;

public partial class DiaDiemChiTiet : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id;
        if (!int.TryParse(Request.QueryString["id"], out id))
        { ShowNotFound(); return; }

        var d = DiaDiemDAL.GetById(id);
        if (d == null) { ShowNotFound(); return; }

        DiaDiemDAL.TangLuotXem(id);

        Page.Title           = d.TenDiaDiem;
        heroTitle.InnerText  = d.TenDiaDiem;
        breadTitle.InnerText = d.TenDiaDiem;
        lblTen.InnerText     = d.TenDiaDiem;
        lblDiaChi.InnerText  = d.DiaChi;
        lblDanhMuc.InnerText = d.TenDanhMuc;
        lblLuotXem.InnerText = d.LuotXem.ToString();
        lblMoTa.InnerHtml    = d.MoTaChiTiet;

        imgMain.Src = string.IsNullOrEmpty(d.HinhAnhDai)
            ? ResolveUrl("~/Content/images/no-image.jpg")
            : ResolveUrl("~/Content/images/uploads/" + d.HinhAnhDai);
        imgMain.Alt = d.TenDiaDiem;

        if (!string.IsNullOrEmpty(d.BanDo))
            mapContent.InnerHtml = d.BanDo;
        else
            pnlMap.Visible = false;

        LoadSidebar(id);
    }

    private void LoadSidebar(int currentId)
    {
        var list = DiaDiemDAL.GetAll();
        var sb = new System.Text.StringBuilder();
        int count = 0;
        foreach (var item in list)
        {
            if (item.MaDiaDiem == currentId || count >= 5) continue;
            count++;
            string img = string.IsNullOrEmpty(item.HinhAnhDai)
                ? ResolveUrl("~/Content/images/no-image.jpg")
                : ResolveUrl("~/Content/images/uploads/" + item.HinhAnhDai);
            sb.Append(
                "<div class='sidebar-news-item'>" +
                "  <img src='" + img + "' class='sidebar-news-img' alt='" + item.TenDiaDiem + "' />" +
                "  <div>" +
                "    <a href='DiaDiemChiTiet.aspx?id=" + item.MaDiaDiem + "' class='sidebar-news-title d-block'>" + item.TenDiaDiem + "</a>" +
                "    <div class='sidebar-news-date'><i class='fas fa-map-marker-alt me-1'></i>" + item.DiaChi + "</div>" +
                "  </div>" +
                "</div>");
        }
        sidebarDiaDiem.InnerHtml = sb.ToString();
    }

    private void ShowNotFound()
    {
        pnlContent.Visible  = false;
        lblNotFound.Visible = true;
    }
}
