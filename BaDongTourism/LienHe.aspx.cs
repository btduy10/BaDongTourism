using System;
using System.Web.UI;
using BaDongTourism.DAL;
using BaDongTourism.Models;

public partial class LienHePage : Page
{
    protected void Page_Load(object sender, EventArgs e) { }

    protected void btnGui_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtNoiDung.Text))
        {
            lblMsg.Text = "<span class='text-danger'><i class='fas fa-exclamation-circle me-1'></i>Vui lòng điền đầy đủ thông tin bắt buộc.</span>";
            return;
        }

        var lh = new LienHe
        {
            HoTen     = txtHoTen.Text.Trim(),
            Email     = txtEmail.Text.Trim(),
            DienThoai = txtDienThoai.Text.Trim(),
            ChuDe     = txtChuDe.Text.Trim(),
            NoiDung   = txtNoiDung.Text.Trim()
        };

        int id = LienHeDAL.Insert(lh);
        if (id > 0)
        {
            lblMsg.Text = "<span class='text-success'><i class='fas fa-check-circle me-1'></i>Tin nhắn đã được gửi! Chúng tôi sẽ phản hồi trong thời gian sớm nhất.</span>";
            txtHoTen.Text = txtEmail.Text = txtDienThoai.Text = txtChuDe.Text = txtNoiDung.Text = "";
        }
        else
        {
            lblMsg.Text = "<span class='text-danger'><i class='fas fa-exclamation-circle me-1'></i>Có lỗi xảy ra, vui lòng thử lại.</span>";
        }
    }
}
