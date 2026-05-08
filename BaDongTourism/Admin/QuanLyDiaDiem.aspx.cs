using System;
using System.Data;
using System.Text;
using System.Web.UI;
using BaDongTourism.App_Code;
using BaDongTourism.DAL;
using BaDongTourism.Models;

public partial class Admin_QuanLyDiaDiem : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDanhMuc();
            LoadTable();

            if (Request.QueryString["edit"] != null)
                LoadEdit(int.Parse(Request.QueryString["edit"]));
            if (Request.QueryString["delete"] != null)
                DoDelete(int.Parse(Request.QueryString["delete"]));
        }
    }

    private void LoadDanhMuc()
    {
        DataTable dt = DBHelper.GetDataTable("SELECT * FROM DanhMucDiaDiem WHERE TrangThai=1");
        ddlDanhMuc.DataSource     = dt;
        ddlDanhMuc.DataTextField  = "TenDanhMuc";
        ddlDanhMuc.DataValueField = "MaDanhMuc";
        ddlDanhMuc.DataBind();
        ddlDanhMuc.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Chọn danh mục --", "0"));
    }

    private void LoadTable()
    {
        var list = DiaDiemDAL.GetAll();
        var sb = new StringBuilder();
        if (list.Count == 0)
        {
            sb.Append("<tr><td colspan='7' class='text-center text-muted py-4'>Chưa có địa điểm nào.</td></tr>");
        }
        else
        {
            foreach (var d in list)
            {
                string noiBat = d.NoiBat
                    ? "<span class='badge bg-success'>Có</span>"
                    : "<span class='badge bg-secondary'>Không</span>";
                sb.Append(
                    "<tr>" +
                    "  <td>" + d.MaDiaDiem + "</td>" +
                    "  <td><strong>" + d.TenDiaDiem + "</strong></td>" +
                    "  <td>" + d.TenDanhMuc + "</td>" +
                    "  <td><small class='text-muted'>" + d.DiaChi + "</small></td>" +
                    "  <td>" + d.LuotXem + "</td>" +
                    "  <td>" + noiBat + "</td>" +
                    "  <td>" +
                    "    <a href='?edit=" + d.MaDiaDiem + "' class='btn btn-sm btn-outline-primary me-1'><i class='fas fa-edit'></i></a>" +
                    "    <a href='?delete=" + d.MaDiaDiem + "' class='btn btn-sm btn-outline-danger'" +
                    "       onclick='return confirm(\"Xóa địa điểm này?\");'><i class='fas fa-trash'></i></a>" +
                    "  </td>" +
                    "</tr>");
            }
        }
        tableBody.InnerHtml = sb.ToString();
    }

    private void LoadEdit(int id)
    {
        var d = DiaDiemDAL.GetById(id);
        if (d == null) return;

        hfMaDiaDiem.Value          = id.ToString();
        txtTen.Text                = d.TenDiaDiem;
        txtDiaChi.Text             = d.DiaChi;
        txtMoTaNgan.Text           = d.MoTaNgan;
        txtMoTaChiTiet.Text        = d.MoTaChiTiet;
        txtHinhAnh.Text            = d.HinhAnhDai;
        txtThuTu.Text              = d.ThuTu.ToString();
        chkNoiBat.Checked          = d.NoiBat;
        formTitle.InnerText        = "Sửa Địa Điểm";
        formPanel.Style["display"] = "block";

        if (ddlDanhMuc.Items.FindByValue(d.MaDanhMuc.ToString()) != null)
            ddlDanhMuc.SelectedValue = d.MaDanhMuc.ToString();
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTen.Text))
        {
            lblMsg.Text = "<span class='text-danger'>Vui lòng nhập tên địa điểm.</span>";
            return;
        }

        int dm, tt;
        var d = new DiaDiem
        {
            MaDanhMuc   = int.TryParse(ddlDanhMuc.SelectedValue, out dm) ? dm : 0,
            TenDiaDiem  = txtTen.Text.Trim(),
            DiaChi      = txtDiaChi.Text.Trim(),
            MoTaNgan    = txtMoTaNgan.Text.Trim(),
            MoTaChiTiet = txtMoTaChiTiet.Text.Trim(),
            HinhAnhDai  = txtHinhAnh.Text.Trim(),
            ThuTu       = int.TryParse(txtThuTu.Text, out tt) ? tt : 0,
            NoiBat      = chkNoiBat.Checked,
            TrangThai   = true
        };

        int id, mid;
        id = int.TryParse(hfMaDiaDiem.Value, out mid) ? mid : 0;
        if (id == 0)
        {
            DiaDiemDAL.Insert(d);
            lblMsg.Text = "<span class='text-success'><i class='fas fa-check-circle me-1'></i>Thêm địa điểm thành công!</span>";
        }
        else
        {
            d.MaDiaDiem = id;
            DiaDiemDAL.Update(d);
            lblMsg.Text = "<span class='text-success'><i class='fas fa-check-circle me-1'></i>Cập nhật thành công!</span>";
        }

        hfMaDiaDiem.Value          = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
        LoadTable();
    }

    protected void btnHuy_Click(object sender, EventArgs e)
    {
        hfMaDiaDiem.Value          = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
    }

    private void DoDelete(int id)
    {
        DiaDiemDAL.Delete(id);
        lblMsg.Text = "<span class='text-success'>Đã xóa địa điểm.</span>";
        LoadTable();
    }

    private void ClearForm()
    {
        txtTen.Text = txtDiaChi.Text = txtMoTaNgan.Text =
        txtMoTaChiTiet.Text = txtHinhAnh.Text = "";
        txtThuTu.Text            = "0";
        chkNoiBat.Checked        = false;
        ddlDanhMuc.SelectedIndex = 0;
        formTitle.InnerText      = "Thêm Địa Điểm Mới";
    }
}
