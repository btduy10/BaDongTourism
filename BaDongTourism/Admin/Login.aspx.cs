using System;
using System.Data;
using System.Web.UI;
using BaDongTourism.DAL;
using BaDongTourism.App_Code;

public partial class Admin_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Xu ly logout
        if (Request.QueryString["action"] == "logout")
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx", true);
            return;
        }

        // Neu da dang nhap roi thi chuyen thang vao Dashboard
        // Chi redirect neu KHONG phai dang o trang login de tranh loop
        if (!IsPostBack && Session["AdminID"] != null)
        {
            Response.Redirect("~/Admin/Dashboard.aspx", true);
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string user = txtUser.Text.Trim();
        string pass = txtPass.Text;

        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
        {
            ShowError("Vui lòng nhập đầy đủ thông tin.");
            return;
        }

        DataRow row = TaiKhoanDAL.DangNhap(user, pass);
        if (row != null)
        {
            Session["AdminID"]   = DBHelper.ToInt(row["MaTK"]);
            Session["AdminName"] = DBHelper.ToStr(row["HoTen"]);
            Session["AdminRole"] = DBHelper.ToStr(row["VaiTro"]);
            Response.Redirect("~/Admin/Dashboard.aspx", true);
        }
        else
        {
            ShowError("Tên đăng nhập hoặc mật khẩu không đúng!");
        }
    }

    private void ShowError(string msg)
    {
        lblMsg.Text    = "<i class='fas fa-exclamation-circle me-2'></i>" + msg;
        lblMsg.Visible = true;
    }
}
