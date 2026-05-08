using System;
using System.Text;
using System.Web.UI;
using BaDongTourism.DAL;
using BaDongTourism.Models;

public partial class Admin_QuanLyAmThuc : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTable();
            if (Request.QueryString["edit"] != null) LoadEdit(int.Parse(Request.QueryString["edit"]));
            if (Request.QueryString["delete"] != null)
            {
                AmThucDAL.Delete(int.Parse(Request.QueryString["delete"]));
                lblMsg.Text = "<span class='text-success'>Đã xóa.</span>";
                LoadTable();
            }
        }
    }

    private void LoadTable()
    {
        var list = AmThucDAL.GetAll();
        var sb = new StringBuilder();
        if (list.Count == 0)
        {
            sb.Append("<tr><td colspan='7' class='text-center text-muted py-4'>Chưa có dữ liệu.</td></tr>");
        }
        else
        {
            foreach (var at in list)
            {
                string nb = at.NoiBat
                    ? "<span class='badge bg-success'>Có</span>"
                    : "<span class='badge bg-secondary'>Không</span>";
                sb.Append(
                    "<tr>" +
                    "  <td>" + at.MaAmThuc + "</td>" +
                    "  <td><strong>" + at.TenAmThuc + "</strong></td>" +
                    "  <td>" + at.LoaiAmThuc + "</td>" +
                    "  <td><small>" + at.DiaChi + "</small></td>" +
                    "  <td><small>" + at.KhoangGia + "</small></td>" +
                    "  <td>" + nb + "</td>" +
                    "  <td>" +
                    "    <a href='?edit=" + at.MaAmThuc + "' class='btn btn-sm btn-outline-primary me-1'><i class='fas fa-edit'></i></a>" +
                    "    <a href='?delete=" + at.MaAmThuc + "' class='btn btn-sm btn-outline-danger' onclick='return confirm(\"Xóa?\")'><i class='fas fa-trash'></i></a>" +
                    "  </td>" +
                    "</tr>");
            }
        }
        tableBody.InnerHtml = sb.ToString();
    }

    private void LoadEdit(int id)
    {
        var at = AmThucDAL.GetById(id);
        if (at == null) return;
        hfMaAT.Value              = id.ToString();
        txtTen.Text               = at.TenAmThuc;
        txtDiaChi.Text            = at.DiaChi;
        txtGia.Text               = at.KhoangGia;
        txtGio.Text               = at.GioMoCua;
        txtHinhAnh.Text           = at.HinhAnhDai;
        txtMoTa.Text              = at.MoTaNgan;
        chkNoiBat.Checked         = at.NoiBat;
        formTitle.InnerText       = "Sửa Ẩm Thực";
        formPanel.Style["display"] = "block";
        if (ddlLoai.Items.FindByValue(at.LoaiAmThuc) != null)
            ddlLoai.SelectedValue = at.LoaiAmThuc;
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTen.Text))
        { lblMsg.Text = "<span class='text-danger'>Vui lòng nhập tên.</span>"; return; }

        int mid;
        var at = new AmThuc
        {
            TenAmThuc  = txtTen.Text.Trim(),
            LoaiAmThuc = ddlLoai.SelectedValue,
            DiaChi     = txtDiaChi.Text.Trim(),
            KhoangGia  = txtGia.Text.Trim(),
            GioMoCua   = txtGio.Text.Trim(),
            HinhAnhDai = txtHinhAnh.Text.Trim(),
            MoTaNgan   = txtMoTa.Text.Trim(),
            NoiBat     = chkNoiBat.Checked,
            TrangThai  = true
        };
        int id = int.TryParse(hfMaAT.Value, out mid) ? mid : 0;
        if (id == 0) { AmThucDAL.Insert(at); lblMsg.Text = "<span class='text-success'>Thêm thành công!</span>"; }
        else { at.MaAmThuc = id; AmThucDAL.Update(at); lblMsg.Text = "<span class='text-success'>Cập nhật thành công!</span>"; }
        hfMaAT.Value = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
        LoadTable();
    }

    protected void btnHuy_Click(object sender, EventArgs e)
    {
        hfMaAT.Value = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
    }

    private void ClearForm()
    {
        txtTen.Text = txtDiaChi.Text = txtGia.Text =
        txtGio.Text = txtHinhAnh.Text = txtMoTa.Text = "";
        chkNoiBat.Checked   = false;
        formTitle.InnerText = "Thêm Ẩm Thực";
    }
}
