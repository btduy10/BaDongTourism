using System;
using System.Data;
using System.Text;
using System.Web.UI;
using BaDongTourism.App_Code;
using BaDongTourism.DAL;
using BaDongTourism.Models;

public partial class Admin_QuanLyTinTuc : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDanhMuc();
            LoadTable();
            if (Request.QueryString["edit"] != null) LoadEdit(int.Parse(Request.QueryString["edit"]));
            if (Request.QueryString["delete"] != null)
            {
                TinTucDAL.Delete(int.Parse(Request.QueryString["delete"]));
                lblMsg.Text = "<span class='text-success'>Đã xóa bài viết.</span>";
                LoadTable();
            }
        }
    }

    private void LoadDanhMuc()
    {
        DataTable dt = DBHelper.GetDataTable("SELECT * FROM DanhMucTinTuc WHERE TrangThai=1");
        ddlDanhMuc.DataSource     = dt;
        ddlDanhMuc.DataTextField  = "TenDanhMuc";
        ddlDanhMuc.DataValueField = "MaDanhMuc";
        ddlDanhMuc.DataBind();
        ddlDanhMuc.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Chọn --", "0"));
    }

    private void LoadTable()
    {
        var list = TinTucDAL.GetAll();
        var sb = new StringBuilder();
        if (list.Count == 0)
        {
            sb.Append("<tr><td colspan='7' class='text-center text-muted py-4'>Chưa có bài viết.</td></tr>");
        }
        else
        {
            foreach (var t in list)
            {
                string nb = t.NoiBat
                    ? "<span class='badge bg-success'>Có</span>"
                    : "<span class='badge bg-secondary'>Không</span>";
                sb.Append(
                    "<tr>" +
                    "  <td>" + t.MaTinTuc + "</td>" +
                    "  <td><strong>" + t.TieuDe + "</strong></td>" +
                    "  <td>" + t.TenDanhMuc + "</td>" +
                    "  <td>" + t.NgayDang.ToString("dd/MM/yyyy") + "</td>" +
                    "  <td>" + t.LuotXem + "</td>" +
                    "  <td>" + nb + "</td>" +
                    "  <td>" +
                    "    <a href='?edit=" + t.MaTinTuc + "' class='btn btn-sm btn-outline-primary me-1'><i class='fas fa-edit'></i></a>" +
                    "    <a href='?delete=" + t.MaTinTuc + "' class='btn btn-sm btn-outline-danger' onclick='return confirm(\"Xóa?\")'><i class='fas fa-trash'></i></a>" +
                    "  </td>" +
                    "</tr>");
            }
        }
        tableBody.InnerHtml = sb.ToString();
    }

    private void LoadEdit(int id)
    {
        var t = TinTucDAL.GetById(id);
        if (t == null) return;
        hfMaTT.Value               = id.ToString();
        txtTieuDe.Text             = t.TieuDe;
        txtHinhAnh.Text            = t.HinhAnhDai;
        txtTomTat.Text             = t.TomTat;
        txtNoiDung.Text            = t.NoiDung;
        chkNoiBat.Checked          = t.NoiBat;
        formTitle.InnerText        = "Sửa Bài Viết";
        formPanel.Style["display"] = "block";
        if (ddlDanhMuc.Items.FindByValue(t.MaDanhMuc.ToString()) != null)
            ddlDanhMuc.SelectedValue = t.MaDanhMuc.ToString();
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
        { lblMsg.Text = "<span class='text-danger'>Vui lòng nhập tiêu đề.</span>"; return; }

        int dm, mid;
        var t = new TinTuc
        {
            MaDanhMuc  = int.TryParse(ddlDanhMuc.SelectedValue, out dm) ? dm : 0,
            MaTK       = (int)Session["AdminID"],
            TieuDe     = txtTieuDe.Text.Trim(),
            HinhAnhDai = txtHinhAnh.Text.Trim(),
            TomTat     = txtTomTat.Text.Trim(),
            NoiDung    = txtNoiDung.Text.Trim(),
            NoiBat     = chkNoiBat.Checked,
            TrangThai  = true
        };
        int id = int.TryParse(hfMaTT.Value, out mid) ? mid : 0;
        if (id == 0) { TinTucDAL.Insert(t); lblMsg.Text = "<span class='text-success'>Thêm thành công!</span>"; }
        else { t.MaTinTuc = id; TinTucDAL.Update(t); lblMsg.Text = "<span class='text-success'>Cập nhật thành công!</span>"; }
        hfMaTT.Value = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
        LoadTable();
    }

    protected void btnHuy_Click(object sender, EventArgs e)
    {
        hfMaTT.Value = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
    }

    private void ClearForm()
    {
        txtTieuDe.Text = txtHinhAnh.Text = txtTomTat.Text = txtNoiDung.Text = "";
        chkNoiBat.Checked   = false;
        formTitle.InnerText = "Thêm Bài Viết";
    }
}
