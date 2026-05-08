using System;
using System.IO;
using System.Text;
using System.Web.UI;
using BaDongTourism.DAL;
using BaDongTourism.Models;

public partial class Admin_QuanLyGallery : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["delete"] != null) DoDelete(int.Parse(Request.QueryString["delete"]));
            LoadGallery();
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (!fuAnh.HasFile)
        {
            lblMsg.Text = "<span class='text-danger'>Vui lòng chọn file ảnh.</span>";
            return;
        }

        string ext = Path.GetExtension(fuAnh.FileName).ToLower();
        string[] allowedExts = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        bool valid = false;
        foreach (string ae in allowedExts)
            if (ext == ae) { valid = true; break; }

        if (!valid)
        {
            lblMsg.Text = "<span class='text-danger'>Chỉ cho phép file ảnh (jpg, png, gif, webp).</span>";
            return;
        }

        string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fuAnh.FileName;
        string uploadPath = Server.MapPath("~/Content/images/uploads/");
        if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

        fuAnh.SaveAs(Path.Combine(uploadPath, fileName));

        int tt;
        var g = new Gallery
        {
            TieuDe      = txtTieuDe.Text.Trim(),
            MoTa        = "",
            DuongDanAnh = fileName,
            DanhMuc     = txtDanhMuc.Text.Trim(),
            ThuTu       = int.TryParse(txtThuTu.Text, out tt) ? tt : 0,
            TrangThai   = true
        };

        GalleryDAL.Insert(g);
        lblMsg.Text = "<span class='text-success'><i class='fas fa-check-circle me-1'></i>Upload ảnh thành công!</span>";
        txtTieuDe.Text = txtDanhMuc.Text = "";
        txtThuTu.Text = "0";
        LoadGallery();
    }

    private void LoadGallery()
    {
        var list = GalleryDAL.GetAll();
        var sb = new StringBuilder();
        foreach (var g in list)
        {
            string imgSrc = ResolveUrl("~/Content/images/uploads/" + g.DuongDanAnh);
            string tieuDeBar = string.IsNullOrEmpty(g.TieuDe) ? ""
                : "<div style='position:absolute;bottom:0;left:0;right:0;background:rgba(0,0,0,0.55);color:white;font-size:0.75rem;padding:4px 8px;'>" + g.TieuDe + "</div>";
            sb.Append(
                "<div class='col-md-3 col-sm-4 col-6'>" +
                "  <div class='position-relative rounded-3 overflow-hidden' style='height:160px;'>" +
                "    <img src='" + imgSrc + "' style='width:100%;height:100%;object-fit:cover;' alt='" + g.TieuDe + "' />" +
                "    <div style='position:absolute;top:8px;right:8px;'>" +
                "      <a href='?delete=" + g.MaAnh + "' class='btn btn-sm btn-danger'" +
                "         onclick='return confirm(\"Xóa ảnh này?\");'><i class='fas fa-trash'></i></a>" +
                "    </div>" +
                tieuDeBar +
                "  </div>" +
                "</div>");
        }
        galleryList.InnerHtml = sb.Length > 0 ? sb.ToString() : "<p class='text-muted'>Chưa có ảnh nào.</p>";
    }

    private void DoDelete(int id)
    {
        GalleryDAL.Delete(id);
        lblMsg.Text = "<span class='text-success'>Đã xóa ảnh.</span>";
    }
}
