using System;
using System.Text;
using System.Web.UI;
using BaDongTourism.DAL;
using BaDongTourism.Models;

public partial class Admin_QuanLyLuuTru : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTable();
            if (Request.QueryString["edit"] != null) LoadEdit(int.Parse(Request.QueryString["edit"]));
            if (Request.QueryString["delete"] != null)
            {
                LuuTruDAL.Delete(int.Parse(Request.QueryString["delete"]));
                lblMsg.Text = "<span class='text-success'>Đã xóa.</span>";
                LoadTable();
            }
        }
    }

    private void LoadTable()
    {
        var list = LuuTruDAL.GetAll();
        var sb = new StringBuilder();
        if (list.Count == 0)
        {
            sb.Append("<tr><td colspan='7' class='text-center text-muted py-4'>Chưa có dữ liệu.</td></tr>");
        }
        else
        {
            foreach (var lt in list)
            {
                string stars = "";
                for (int i = 0; i < lt.XepHang; i++) stars += "⭐";
                sb.Append(
                    "<tr>" +
                    "  <td>" + lt.MaLuuTru + "</td>" +
                    "  <td><strong>" + lt.TenLuuTru + "</strong></td>" +
                    "  <td>" + lt.LoaiLuuTru + "</td>" +
                    "  <td>" + lt.DienThoai + "</td>" +
                    "  <td><small>" + lt.GiaPhong + "</small></td>" +
                    "  <td>" + stars + "</td>" +
                    "  <td>" +
                    "    <a href='?edit=" + lt.MaLuuTru + "' class='btn btn-sm btn-outline-primary me-1'><i class='fas fa-edit'></i></a>" +
                    "    <a href='?delete=" + lt.MaLuuTru + "' class='btn btn-sm btn-outline-danger' onclick='return confirm(\"Xóa?\")'><i class='fas fa-trash'></i></a>" +
                    "  </td>" +
                    "</tr>");
            }
        }
        tableBody.InnerHtml = sb.ToString();
    }

    private void LoadEdit(int id)
    {
        var lt = LuuTruDAL.GetById(id);
        if (lt == null) return;
        hfMaLT.Value              = id.ToString();
        txtTen.Text               = lt.TenLuuTru;
        txtDiaChi.Text            = lt.DiaChi;
        txtDienThoai.Text         = lt.DienThoai;
        txtGia.Text               = lt.GiaPhong;
        txtHinhAnh.Text           = lt.HinhAnhDai;
        txtXepHang.Text           = lt.XepHang.ToString();
        txtMoTa.Text              = lt.MoTaNgan;
        chkNoiBat.Checked         = lt.NoiBat;
        formTitle.InnerText       = "Sửa Lưu Trú";
        formPanel.Style["display"] = "block";
        if (ddlLoai.Items.FindByValue(lt.LoaiLuuTru) != null)
            ddlLoai.SelectedValue = lt.LoaiLuuTru;
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTen.Text))
        { lblMsg.Text = "<span class='text-danger'>Vui lòng nhập tên.</span>"; return; }

        int xh, mid;
        var lt = new LuuTru
        {
            TenLuuTru  = txtTen.Text.Trim(),
            LoaiLuuTru = ddlLoai.SelectedValue,
            DiaChi     = txtDiaChi.Text.Trim(),
            DienThoai  = txtDienThoai.Text.Trim(),
            GiaPhong   = txtGia.Text.Trim(),
            HinhAnhDai = txtHinhAnh.Text.Trim(),
            XepHang    = int.TryParse(txtXepHang.Text, out xh) ? xh : 3,
            MoTaNgan   = txtMoTa.Text.Trim(),
            NoiBat     = chkNoiBat.Checked,
            TrangThai  = true
        };
        int id = int.TryParse(hfMaLT.Value, out mid) ? mid : 0;
        if (id == 0) { LuuTruDAL.Insert(lt); lblMsg.Text = "<span class='text-success'>Thêm thành công!</span>"; }
        else { lt.MaLuuTru = id; LuuTruDAL.Update(lt); lblMsg.Text = "<span class='text-success'>Cập nhật thành công!</span>"; }
        hfMaLT.Value = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
        LoadTable();
    }

    protected void btnHuy_Click(object sender, EventArgs e)
    {
        hfMaLT.Value = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
    }

    private void ClearForm()
    {
        txtTen.Text = txtDiaChi.Text = txtDienThoai.Text =
        txtGia.Text = txtHinhAnh.Text = txtMoTa.Text = "";
        txtXepHang.Text     = "3";
        chkNoiBat.Checked   = false;
        formTitle.InnerText = "Thêm Cơ Sở Lưu Trú";
    }
}
