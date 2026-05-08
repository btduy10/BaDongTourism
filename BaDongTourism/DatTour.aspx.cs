using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaDongTourism.DAL;
using BaDongTourism.Models;

public partial class DatTourPage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTourDropDown();
            LoadSidebarTour();

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string maTour = Request.QueryString["id"];
                ListItem item = ddlTour.Items.FindByValue(maTour);
                if (item != null) ddlTour.SelectedValue = maTour;
            }
        }
    }

    private void LoadTourDropDown()
    {
        var list = TourDAL.GetAll();
        ddlTour.Items.Clear();
        ddlTour.Items.Add(new ListItem("-- Chọn tour muốn đặt --", "0"));
        foreach (var t in list)
        {
            var li = new ListItem(t.TenTour + "  (" + t.ThoiGian + ")", t.MaTour.ToString());
            li.Attributes["data-gia-nl"] = t.GiaNguoiLon.ToString();
            li.Attributes["data-gia-te"] = t.GiaTreEm.ToString();
            ddlTour.Items.Add(li);
        }
    }

    private void LoadSidebarTour()
    {
        var list = TourDAL.GetAll(noiBat: true);
        var sb   = new StringBuilder();
        int count = 0;
        foreach (var t in list)
        {
            if (count++ >= 4) break;
            sb.Append(
                "<div class='sidebar-news-item'>" +
                "  <div>" +
                "    <a href='TourChiTiet.aspx?id=" + t.MaTour + "' class='sidebar-news-title d-block'>" + t.TenTour + "</a>" +
                "    <div class='sidebar-news-date'>" +
                "      <i class='fas fa-clock me-1'></i>" + t.ThoiGian + " &nbsp;|&nbsp;" +
                "      <span class='text-warning fw-bold'>" + t.GiaNguoiLon.ToString("N0") + "đ</span>" +
                "    </div>" +
                "  </div>" +
                "</div>");
        }
        sidebarTour.InnerHtml = sb.Length > 0 ? sb.ToString()
                                              : "<p class='text-muted small mb-0'>Chưa có tour.</p>";
    }

    protected void btnDat_Click(object sender, EventArgs e)
    {
        int maTour;
        if (!int.TryParse(ddlTour.SelectedValue, out maTour) || maTour == 0)
        { ShowError("Vui lòng chọn tour."); return; }

        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        { ShowError("Vui lòng nhập họ tên."); return; }

        if (string.IsNullOrWhiteSpace(txtDienThoai.Text))
        { ShowError("Vui lòng nhập số điện thoại."); return; }

        var tour = TourDAL.GetById(maTour);
        if (tour == null) { ShowError("Tour không tồn tại."); return; }

        int soNL, soTE;
        soNL = int.TryParse(SoNguoiLon.Text, out soNL) ? soNL : 0;
        soTE = int.TryParse(SoTreEm.Text,    out soTE) ? soTE : 0;

        if (soNL <= 0 && soTE <= 0)
        { ShowError("Vui lòng chọn ít nhất 1 người lớn hoặc 1 trẻ em."); return; }

        decimal tongTien = soNL * tour.GiaNguoiLon + soTE * tour.GiaTreEm;

        DateTime ngayKH;
        if (!DateTime.TryParse(txtNgayKH.Text, out ngayKH) || ngayKH < DateTime.Today)
            ngayKH = DateTime.MinValue; // se xu ly o DAL thanh NULL

        var dat = new DatTour
        {
            MaTour       = maTour,
            HoTen        = txtHoTen.Text.Trim(),
            Email        = txtEmail.Text.Trim(),
            DienThoai    = txtDienThoai.Text.Trim(),
            SoNguoiLon   = soNL,
            SoTreEm      = soTE,
            NgayKhoiHanh = ngayKH,
            TongTien     = tongTien,
            GhiChu       = txtGhiChu.Text.Trim()
        };

        int id = DatTourDAL.Insert(dat);
        if (id > 0)
        {
            pnlForm.Visible    = false;
            pnlSuccess.Visible = true;
            lblMaDat.Text      = "#BD" + id.ToString("D5");
        }
        else
        {
            ShowError("Có lỗi xảy ra. Vui lòng thử lại hoặc gọi hotline 0294 1234 567.");
        }
    }

    private void ShowError(string msg)
    {
        lblMsg.Text = "<div class='alert alert-danger'><i class='fas fa-exclamation-circle me-2'></i>" + msg + "</div>";
    }
}
