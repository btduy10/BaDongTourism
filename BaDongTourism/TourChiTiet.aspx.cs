using System;
using System.Web.UI;
using BaDongTourism.DAL;
using BaDongTourism.Models;

public partial class TourChiTiet : Page
{
    private int _maTour;
    private Tour _tour;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!int.TryParse(Request.QueryString["id"], out _maTour))
        { ShowNotFound(); return; }

        if (!IsPostBack)
        {
            _tour = TourDAL.GetById(_maTour);
            if (_tour == null) { ShowNotFound(); return; }
            TourDAL.TangLuotXem(_maTour);
            BindTour(_tour);
        }
    }

    private void BindTour(Tour t)
    {
        Page.Title            = t.TenTour;
        tourTitle.InnerText   = t.TenTour;
        breadTour.InnerText   = t.TenTour;
        lblTenTour.InnerText  = t.TenTour;
        lblThoiGian.InnerText = t.ThoiGian;
        lblDiaDiem.InnerText  = t.DiaDiem;
        lblSoCho.InnerText    = t.SoChoToiDa.ToString();
        lblLuotXem.InnerText  = t.LuotXem.ToString();
        lblMoTa.InnerHtml     = t.MoTaChiTiet;

        string baoGom = t.BaoGom != null ? t.BaoGom.Replace("\n", "<br/>") : "";
        string khongBaoGom = t.KhongBaoGom != null ? t.KhongBaoGom.Replace("\n", "<br/>") : "";
        string luuY = t.LuuY != null ? t.LuuY.Replace("\n", "<br/>") : "";

        lblBaoGom.InnerHtml      = baoGom;
        lblKhongBaoGom.InnerHtml = khongBaoGom;
        lblLuuY.InnerHtml        = luuY;
        imgTour.Src = string.IsNullOrEmpty(t.HinhAnhDai)
            ? ResolveUrl("~/Content/images/no-image.jpg")
            : ResolveUrl("~/Content/images/uploads/" + t.HinhAnhDai);
        imgTour.Alt = t.TenTour;

        TongTien.Value = "0";
        string giaNL = t.GiaNguoiLon.ToString("N0") + "đ/người";
        string giaTE = t.GiaTreEm.ToString("N0") + "đ/người";
        ScriptManager.RegisterStartupScript(this, GetType(), "priceData",
            "document.getElementById('spnGiaNL').innerText='" + giaNL + "';" +
            "document.getElementById('spnGiaTE').innerText='" + giaTE + "';" +
            "document.getElementById('TongTienDisplay').dataset.gianguoilon='" + t.GiaNguoiLon + "';" +
            "document.getElementById('TongTienDisplay').dataset.giatreem='" + t.GiaTreEm + "';", true);
    }

    protected void btnDatTour_Click(object sender, EventArgs e)
    {
        _tour = TourDAL.GetById(_maTour);
        if (_tour == null) return;

        int soNL, soTE;
        soNL = int.TryParse(SoNguoiLon.Text, out soNL) ? soNL : 0;
        soTE = int.TryParse(SoTreEm.Text,    out soTE) ? soTE : 0;

        if (soNL <= 0 && soTE <= 0)
        {
            lblMsg.Text = "<span class='text-danger'><i class='fas fa-exclamation-circle me-1'></i>Vui lòng chọn ít nhất 1 người lớn hoặc 1 trẻ em.</span>";
            return;
        }

        decimal tong = soNL * _tour.GiaNguoiLon + soTE * _tour.GiaTreEm;

        DateTime ngayKH;
        if (!DateTime.TryParse(txtNgayKH.Text, out ngayKH) || ngayKH < DateTime.Today)
            ngayKH = DateTime.MinValue; // se xu ly o DAL thanh NULL

        var dat = new DatTour
        {
            MaTour       = _maTour,
            HoTen        = txtHoTen.Text.Trim(),
            Email        = txtEmail.Text.Trim(),
            DienThoai    = txtDienThoai.Text.Trim(),
            SoNguoiLon   = soNL,
            SoTreEm      = soTE,
            NgayKhoiHanh = ngayKH,
            TongTien     = tong,
            GhiChu       = txtGhiChu.Text.Trim()
        };

        int id = DatTourDAL.Insert(dat);
        if (id > 0)
        {
            lblMsg.Text = "<span class='text-success'><i class='fas fa-check-circle me-1'></i>Đặt tour thành công! Mã đặt: <strong>#" + id + "</strong>. Chúng tôi sẽ liên hệ sớm.</span>";
            txtHoTen.Text = txtDienThoai.Text = txtEmail.Text = txtGhiChu.Text = "";
        }
        else
        {
            lblMsg.Text = "<span class='text-danger'><i class='fas fa-exclamation-circle me-1'></i>Có lỗi xảy ra, vui lòng thử lại.</span>";
        }
    }

    private void ShowNotFound()
    {
        pnlContent.Visible  = false;
        lblNotFound.Visible = true;
    }
}
