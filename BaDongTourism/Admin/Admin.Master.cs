using System;
using System.Web.UI;
using BaDongTourism.DAL;

public partial class Admin_AdminMaster : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Neu chua dang nhap, chuyen ve trang login
        if (Session["AdminID"] == null)
        {
            Response.Redirect("~/Admin/Login.aspx", true);
            return;
        }

        if (Session["AdminName"] != null)
            litAdmin.Text = Session["AdminName"].ToString();

        // Hien thi so tin nhan chua doc tren sidebar
        try
        {
            int chuaDoc = LienHeDAL.SoTinChuaDoc();
            litTinNhanBadge.Text = chuaDoc > 0
                ? " <span class='badge bg-danger ms-1' style='font-size:0.65rem;'>" + chuaDoc + "</span>"
                : "";
        }
        catch
        {
            litTinNhanBadge.Text = "";
        }
    }
}
