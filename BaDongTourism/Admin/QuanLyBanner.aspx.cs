using System;
using System.IO;
using System.Text;
using System.Web.UI;
using BaDongTourism.DAL;
using BaDongTourism.Models;

public partial class Admin_QuanLyBanner : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["edit"] != null)   LoadEdit(int.Parse(Request.QueryString["edit"]));
            if (Request.QueryString["delete"] != null) DoDelete(int.Parse(Request.QueryString["delete"]));
            LoadBanners();
        }
    }

    private void LoadBanners()
    {
        var list = BannerDAL.GetAll();
        var sb = new StringBuilder();

        if (list.Count == 0)
        {
            sb.Append("<div class='col-12'><div class='text-center text-muted py-5'>" +
                      "<i class='fas fa-images fa-3x mb-3 d-block opacity-25'></i>" +
                      "<p>Chưa có banner nào. Nhấn <strong>Thêm Banner</strong> để bắt đầu.</p></div></div>");
        }
        else
        {
            foreach (var b in list)
            {
                string imgSrc = string.IsNullOrEmpty(b.HinhAnh)
                    ? ResolveUrl("~/Content/images/no-image.jpg")
                    : ResolveUrl("~/Content/images/uploads/" + b.HinhAnh);

                string badgeHtml = b.TrangThai
                    ? "<span class='badge bg-success'>Hiển thị</span>"
                    : "<span class='badge bg-secondary'>Ẩn</span>";

                string tieuDeHtml = string.IsNullOrEmpty(b.TieuDe) ? "<em class='text-muted'>Chưa có tiêu đề</em>" : b.TieuDe;

                sb.Append(
                    "<div class='col-md-6 col-lg-4'>" +
                    "  <div class='card border-0 shadow-sm rounded-3 overflow-hidden h-100'>" +
                    "    <div style='position:relative;height:160px;overflow:hidden;'>" +
                    "      <img src='" + imgSrc + "' style='width:100%;height:100%;object-fit:cover;' alt='" + b.TieuDe + "' />" +
                    "      <div style='position:absolute;top:8px;left:8px;'>" + badgeHtml + "</div>" +
                    "      <div style='position:absolute;top:8px;right:8px;background:rgba(0,0,0,0.5);color:white;border-radius:6px;padding:2px 8px;font-size:0.8rem;'>" +
                    "        <i class='fas fa-sort me-1'></i>#" + b.ThuTu +
                    "      </div>" +
                    "    </div>" +
                    "    <div class='card-body p-3'>" +
                    "      <h6 class='fw-700 mb-1'>" + tieuDeHtml + "</h6>" +
                    "      <p class='small text-muted mb-2' style='display:-webkit-box;-webkit-line-clamp:2;-webkit-box-orient:vertical;overflow:hidden;'>" +
                           (string.IsNullOrEmpty(b.MoTa) ? "<em>Chưa có mô tả</em>" : b.MoTa) +
                    "      </p>" +
                    "      <div class='d-flex gap-2'>" +
                    "        <a href='?edit=" + b.MaBanner + "' class='btn btn-sm btn-outline-primary flex-fill'><i class='fas fa-edit me-1'></i>Sửa</a>" +
                    "        <a href='?delete=" + b.MaBanner + "' class='btn btn-sm btn-outline-danger'" +
                    "           onclick='return confirm(\"Xóa banner này?\")'><i class='fas fa-trash'></i></a>" +
                    "      </div>" +
                    "    </div>" +
                    "  </div>" +
                    "</div>");
            }
        }
        bannerList.InnerHtml = sb.ToString();
    }

    private void LoadEdit(int id)
    {
        var b = BannerDAL.GetById(id);
        if (b == null) return;

        hfMaBanner.Value           = id.ToString();
        txtTieuDe.Text             = b.TieuDe;
        txtMoTa.Text               = b.MoTa;
        txtHinhAnh.Text            = b.HinhAnh;
        txtLienKet.Text            = b.LienKet;
        txtThuTu.Text              = b.ThuTu.ToString();
        chkTrangThai.Checked       = b.TrangThai;
        formTitle.InnerText        = "Sửa Banner";
        formPanel.Style["display"] = "block";
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        // Upload anh neu co chon file
        string fileName = txtHinhAnh.Text.Trim();
        if (fuAnh.HasFile)
        {
            string ext = Path.GetExtension(fuAnh.FileName).ToLower();
            string[] allowed = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            bool valid = false;
            foreach (string ae in allowed) if (ext == ae) { valid = true; break; }

            if (!valid)
            {
                ShowMsg("danger", "Chỉ cho phép file ảnh (jpg, png, gif, webp).");
                return;
            }

            fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fuAnh.FileName;
            string uploadPath = Server.MapPath("~/Content/images/uploads/");
            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
            fuAnh.SaveAs(Path.Combine(uploadPath, fileName));
        }

        int thu, mid;
        var b = new Banner
        {
            TieuDe    = txtTieuDe.Text.Trim(),
            MoTa      = txtMoTa.Text.Trim(),
            HinhAnh   = fileName,
            LienKet   = txtLienKet.Text.Trim(),
            ThuTu     = int.TryParse(txtThuTu.Text, out thu) ? thu : 0,
            TrangThai = chkTrangThai.Checked
        };

        int id = int.TryParse(hfMaBanner.Value, out mid) ? mid : 0;
        if (id == 0)
        {
            BannerDAL.Insert(b);
            ShowMsg("success", "<i class='fas fa-check-circle me-2'></i>Thêm banner thành công!");
        }
        else
        {
            b.MaBanner = id;
            BannerDAL.Update(b);
            ShowMsg("success", "<i class='fas fa-check-circle me-2'></i>Cập nhật banner thành công!");
        }

        hfMaBanner.Value           = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
        LoadBanners();
    }

    protected void btnHuy_Click(object sender, EventArgs e)
    {
        hfMaBanner.Value           = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
    }

    private void DoDelete(int id)
    {
        BannerDAL.Delete(id);
        ShowMsg("success", "Đã xóa banner.");
        LoadBanners();
    }

    private void ClearForm()
    {
        txtTieuDe.Text = txtMoTa.Text = txtHinhAnh.Text = txtLienKet.Text = "";
        txtThuTu.Text = "0";
        chkTrangThai.Checked = true;
        formTitle.InnerText = "Thêm Banner Mới";
    }

    private void ShowMsg(string type, string msg)
    {
        lblMsg.Text = "<div class='alert alert-" + type + " alert-dismissible rounded-3 mb-4'>" +
                      msg +
                      "<button type='button' class='btn-close' data-bs-dismiss='alert'></button></div>";
    }
}
