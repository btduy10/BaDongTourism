using System;
using System.Text;
using System.Web.UI;
using BaDongTourism.DAL;
using BaDongTourism.Models;

public partial class Admin_QuanLyTour : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTable();
            if (Request.QueryString["edit"] != null) LoadEdit(int.Parse(Request.QueryString["edit"]));
            if (Request.QueryString["delete"] != null) DoDelete(int.Parse(Request.QueryString["delete"]));
        }
    }

    private void LoadTable()
    {
        var list = TourDAL.GetAll();
        var sb = new StringBuilder();
        if (list.Count == 0)
        {
            sb.Append("<tr><td colspan='8' class='text-center text-muted py-4'>Chưa có tour nào.</td></tr>");
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
                    "  <td>" + t.MaTour + "</td>" +
                    "  <td><strong>" + t.TenTour + "</strong></td>" +
                    "  <td>" + t.ThoiGian + "</td>" +
                    "  <td class='text-warning fw-bold'>" + t.GiaNguoiLon.ToString("N0") + "đ</td>" +
                    "  <td class='text-warning fw-bold'>" + t.GiaTreEm.ToString("N0") + "đ</td>" +
                    "  <td>" + t.LuotXem + "</td>" +
                    "  <td>" + nb + "</td>" +
                    "  <td>" +
                    "    <a href='?edit=" + t.MaTour + "' class='btn btn-sm btn-outline-primary me-1'><i class='fas fa-edit'></i></a>" +
                    "    <a href='?delete=" + t.MaTour + "' class='btn btn-sm btn-outline-danger' onclick='return confirm(\"Xóa tour này?\");'><i class='fas fa-trash'></i></a>" +
                    "  </td>" +
                    "</tr>");
            }
        }
        tableBody.InnerHtml = sb.ToString();
    }

    private void LoadEdit(int id)
    {
        var t = TourDAL.GetById(id);
        if (t == null) return;
        hfMaTour.Value             = id.ToString();
        txtTen.Text                = t.TenTour;
        txtThoiGian.Text           = t.ThoiGian;
        txtDiaDiem.Text            = t.DiaDiem;
        txtGiaNL.Text              = t.GiaNguoiLon.ToString();
        txtGiaTE.Text              = t.GiaTreEm.ToString();
        txtSoCho.Text              = t.SoChoToiDa.ToString();
        txtHinhAnh.Text            = t.HinhAnhDai;
        txtMoTaNgan.Text           = t.MoTaNgan;
        txtMoTaChiTiet.Text        = t.MoTaChiTiet;
        txtLich.Text               = t.LichKhoiHanh;
        txtBaoGom.Text             = t.BaoGom;
        txtKhongBaoGom.Text        = t.KhongBaoGom;
        chkNoiBat.Checked          = t.NoiBat;
        chkTrangThai.Checked       = t.TrangThai;
        formTitle.InnerText        = "Sửa Tour";
        formPanel.Style["display"] = "block";
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTen.Text))
        { lblMsg.Text = "<span class='text-danger'>Vui lòng nhập tên tour.</span>"; return; }

        decimal gnl, gte;
        int sc, mid;
        var t = new Tour
        {
            TenTour      = txtTen.Text.Trim(),
            ThoiGian     = txtThoiGian.Text.Trim(),
            DiaDiem      = txtDiaDiem.Text.Trim(),
            GiaNguoiLon  = decimal.TryParse(txtGiaNL.Text, out gnl) ? gnl : 0,
            GiaTreEm     = decimal.TryParse(txtGiaTE.Text, out gte) ? gte : 0,
            SoChoToiDa   = int.TryParse(txtSoCho.Text, out sc) ? sc : 20,
            HinhAnhDai   = txtHinhAnh.Text.Trim(),
            MoTaNgan     = txtMoTaNgan.Text.Trim(),
            MoTaChiTiet  = txtMoTaChiTiet.Text.Trim(),
            LichKhoiHanh = txtLich.Text.Trim(),
            BaoGom       = txtBaoGom.Text.Trim(),
            KhongBaoGom  = txtKhongBaoGom.Text.Trim(),
            NoiBat       = chkNoiBat.Checked,
            TrangThai    = chkTrangThai.Checked
        };
        int id = int.TryParse(hfMaTour.Value, out mid) ? mid : 0;
        if (id == 0) { TourDAL.Insert(t); lblMsg.Text = "<span class='text-success'>Thêm tour thành công!</span>"; }
        else { t.MaTour = id; TourDAL.Update(t); lblMsg.Text = "<span class='text-success'>Cập nhật thành công!</span>"; }
        hfMaTour.Value = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
        LoadTable();
    }

    protected void btnHuy_Click(object sender, EventArgs e)
    {
        hfMaTour.Value = "0";
        formPanel.Style["display"] = "none";
        ClearForm();
    }

    private void DoDelete(int id)
    {
        TourDAL.Delete(id);
        lblMsg.Text = "<span class='text-success'>Đã xóa tour.</span>";
        LoadTable();
    }

    private void ClearForm()
    {
        txtTen.Text = txtThoiGian.Text = txtDiaDiem.Text = txtHinhAnh.Text =
        txtMoTaNgan.Text = txtMoTaChiTiet.Text = txtLich.Text =
        txtBaoGom.Text = txtKhongBaoGom.Text = "";
        txtGiaNL.Text = txtGiaTE.Text = "0";
        txtSoCho.Text = "20";
        chkNoiBat.Checked = false;
        chkTrangThai.Checked = true;
        formTitle.InnerText = "Thêm Tour Mới";
    }
}
