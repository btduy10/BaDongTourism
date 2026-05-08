using System;
using System.Text;
using System.Web.UI;
using BaDongTourism.DAL;

public partial class GalleryPage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadGallery();
    }

    private void LoadGallery()
    {
        var list = GalleryDAL.GetAll();
        if (list.Count == 0) { lblNoData.Visible = true; return; }

        var sb = new StringBuilder();
        foreach (var g in list)
        {
            string imgSrc = string.IsNullOrEmpty(g.DuongDanAnh)
                ? ResolveUrl("~/Content/images/no-image.jpg")
                : ResolveUrl("~/Content/images/uploads/" + g.DuongDanAnh);

            sb.Append("<div class='gallery-item' title='" + g.TieuDe + "'>" +
                      "  <img src='" + imgSrc + "' alt='" + g.TieuDe + "' loading='lazy' />" +
                      "</div>");
        }
        galleryGrid.InnerHtml = sb.ToString();
    }
}
