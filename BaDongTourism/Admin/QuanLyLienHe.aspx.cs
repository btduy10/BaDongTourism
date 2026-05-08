using System;
using System.Text;
using System.Web.UI;
using BaDongTourism.DAL;
using BaDongTourism.Models;

public partial class Admin_QuanLyLienHe : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Handle ?delete=id GET request
            if (!string.IsNullOrEmpty(Request.QueryString["delete"]))
            {
                int delId;
                if (int.TryParse(Request.QueryString["delete"], out delId))
                    LienHeDAL.Delete(delId);
                Response.Redirect("QuanLyLienHe.aspx");
                return;
            }
            LoadTable();
            UpdateBadge();
        }
        else
        {
            // A postback was triggered — check what action is needed
            int viewId = 0;
            int.TryParse(hfViewId.Value, out viewId);

            if (viewId > 0)
            {
                // Mark as read and load detail into modal fields
                LienHeDAL.DanhDauDaDoc(viewId);
                LoadDetail(viewId);
            }

            LoadTable();
            UpdateBadge();
        }
    }

    // -------------------------------------------------------
    private void LoadTable()
    {
        var list = LienHeDAL.GetAll();
        string filter = hfFilter.Value;

        var sb = new StringBuilder();
        int count = 0;

        foreach (var lh in list)
        {
            bool daPhanHoi = !string.IsNullOrEmpty(lh.PhanHoi);

            // Apply filter
            if (filter == "unread"  && lh.DaDoc)      continue;
            if (filter == "replied" && !daPhanHoi)     continue;

            count++;

            string rowCss = !lh.DaDoc ? "style='background:#f0f8ff;'" : "";

            // Status badge
            string trangThai;
            if (daPhanHoi)
                trangThai = "<span class='badge bg-success'><i class='fas fa-check me-1'></i>Đã phản hồi</span>";
            else if (lh.DaDoc)
                trangThai = "<span class='badge bg-secondary'>Đã đọc</span>";
            else
                trangThai = "<span class='badge bg-danger'>Chưa đọc</span>";

            // Subject preview (truncate)
            string chuDe = lh.ChuDe.Length > 35 ? lh.ChuDe.Substring(0, 35) + "…" : lh.ChuDe;

            // Buttons
            string btnXem = "<button type='button' class='btn btn-sm btn-primary' title='Xem & Phản hồi' onclick='openXem(" + lh.MaLienHe + ")'><i class='fas fa-envelope-open-text'></i></button>";
            string btnXoa = "<a href='?delete=" + lh.MaLienHe + "' class='btn btn-sm btn-outline-danger' title='Xóa' onclick='return confirm(\"Xóa tin nhắn này?\")'><i class='fas fa-trash'></i></a>";

            sb.Append(
                "<tr " + rowCss + ">" +
                "  <td class='text-muted small'>" + lh.MaLienHe + "</td>" +
                "  <td><span class='fw-semibold'>" + EscHtml(lh.HoTen) + "</span></td>" +
                "  <td><small class='d-block'>" + EscHtml(lh.Email) + "</small>" +
                      "<small class='text-muted'>" + EscHtml(lh.DienThoai) + "</small></td>" +
                "  <td><small>" + EscHtml(chuDe) + "</small></td>" +
                "  <td><small>" + lh.NgayGui.ToString("dd/MM/yyyy") + "<br/><span class='text-muted'>" + lh.NgayGui.ToString("HH:mm") + "</span></small></td>" +
                "  <td>" + trangThai + "</td>" +
                "  <td><div class='d-flex gap-1 flex-nowrap'>" + btnXem + btnXoa + "</div></td>" +
                "</tr>"
            );
        }

        if (count == 0)
            sb.Append("<tr><td colspan='7' class='text-center text-muted py-4'><i class='fas fa-inbox me-2'></i>Không có tin nhắn nào.</td></tr>");

        tableBody.InnerHtml = sb.ToString();
    }

    private void LoadDetail(int id)
    {
        LienHe lh = LienHeDAL.GetById(id);
        if (lh == null) return;

        lblHoTen.Text     = EscHtml(lh.HoTen);
        lblEmail.Text     = EscHtml(lh.Email);
        lblDienThoai.Text = EscHtml(lh.DienThoai);
        lblChuDe.Text     = EscHtml(lh.ChuDe);
        lblNgayGui.Text   = lh.NgayGui.ToString("dd/MM/yyyy HH:mm");
        lblNoiDung.Text   = EscHtml(lh.NoiDung);

        if (!string.IsNullOrEmpty(lh.PhanHoi))
        {
            pnlDaPhanHoi.Visible = true;
            lblPhanHoiCu.Text    = EscHtml(lh.PhanHoi);
            lblNgayPhanHoi.Text  = lh.NgayPhanHoi != DateTime.MinValue
                                   ? lh.NgayPhanHoi.ToString("dd/MM/yyyy HH:mm")
                                   : "--";
            txtPhanHoi.Text      = lh.PhanHoi;

            // Tao nut gui email neu co dia chi email
            if (!string.IsNullOrEmpty(lh.Email))
            {
                string subject = "Re: " + lh.ChuDe;
                string body    = "Kính gửi " + lh.HoTen + ",\n\n" + lh.PhanHoi +
                                 "\n\n---\nBa Động Tourism\nĐịa chỉ: Trường Long Hòa, Duyên Hải, Trà Vinh";
                string mailto  = "mailto:" + lh.Email
                                 + "?subject=" + Uri.EscapeDataString(subject)
                                 + "&body="    + Uri.EscapeDataString(body);
                lblMailtoBtn.Text = "<a href='" + mailto + "' class='btn btn-success' target='_blank'>" +
                                    "<i class='fas fa-paper-plane me-2'></i>Gửi Email Cho Khách</a>";
            }
            else
            {
                lblMailtoBtn.Text = "";
            }
        }
        else
        {
            pnlDaPhanHoi.Visible = false;
            txtPhanHoi.Text      = "";
            lblMailtoBtn.Text    = "";
        }
    }

    protected void btnPostback_Click(object sender, EventArgs e)
    {
        // Postback trigger thu cong — xu ly trong Page_Load
    }

    protected void btnLuuPhanHoi_Click(object sender, EventArgs e)
    {
        int id = 0;
        int.TryParse(hfViewId.Value, out id);
        if (id <= 0) return;

        string phanHoi = txtPhanHoi.Text.Trim();
        LienHeDAL.LuuPhanHoi(id, phanHoi);

        // Giu nguyen hfViewId de modal tu mo lai voi nut "Gui Email"
        // LoadDetail se duoc goi trong Page_Load -> hien thi nut mailto
        ShowMsg("success", "Đã lưu phản hồi! Bấm <b>Gửi Email Cho Khách</b> để gửi qua email.");
    }

    private void UpdateBadge()
    {
        int chuaDoc = LienHeDAL.SoTinChuaDoc();
        if (chuaDoc > 0)
        {
            lblBadge.Text    = chuaDoc.ToString();
            lblBadge.Visible = true;
        }
        else
        {
            lblBadge.Visible = false;
        }
    }

    // -------------------------------------------------------
    private static string EscHtml(string s)
    {
        if (string.IsNullOrEmpty(s)) return "";
        return System.Web.HttpUtility.HtmlEncode(s);
    }

    private void ShowMsg(string type, string msg)
    {
        lblMsg.Text = "<div class='alert alert-" + type + " alert-dismissible rounded-3 mb-0'>" +
                      "<i class='fas fa-check-circle me-2'></i>" + msg +
                      "<button type='button' class='btn-close' data-bs-dismiss='alert'></button></div>";
    }
}
