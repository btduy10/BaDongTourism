using System;
using System.Text;
using System.Web.UI;
using BaDongTourism.DAL;

public partial class Admin_QuanLyDatTour : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["status"] != null && Request.QueryString["id"] != null)
                UpdateStatus();
            if (Request.QueryString["delete"] != null)
                DoDelete(int.Parse(Request.QueryString["delete"]));
            LoadTable();
        }
    }

    private void UpdateStatus()
    {
        int id = int.Parse(Request.QueryString["id"]);
        string status = Request.QueryString["status"];
        DatTourDAL.CapNhatTrangThai(id, status);
        lblMsg.Text = "<span class='text-success'>Đã cập nhật trạng thái.</span>";
    }

    private void LoadTable()
    {
        var list = DatTourDAL.GetAll();
        var sb = new StringBuilder();
        if (list.Count == 0)
        {
            sb.Append("<tr><td colspan='8' class='text-center text-muted py-4'>Chưa có đơn đặt tour.</td></tr>");
        }
        else
        {
            foreach (var d in list)
            {
                string bc = d.TrangThai.Contains("Xác nhận") ? "bg-success" :
                            d.TrangThai.Contains("Hủy") ? "bg-danger" : "bg-warning text-dark";
                string ngayKH = d.NgayKhoiHanh == DateTime.MinValue ? "–" : d.NgayKhoiHanh.ToString("dd/MM/yyyy");
                sb.Append(
                    "<tr>" +
                    "  <td>#" + d.MaDatTour + "</td>" +
                    "  <td><strong>" + d.HoTen + "</strong><br/><small class='text-muted'>" + d.DienThoai + "</small></td>" +
                    "  <td><small>" + d.TenTour + "</small></td>" +
                    "  <td>" + d.SoNguoiLon + " NL / " + d.SoTreEm + " TE</td>" +
                    "  <td>" + ngayKH + "</td>" +
                    "  <td class='text-warning fw-bold'>" + d.TongTien.ToString("N0") + "đ</td>" +
                    "  <td><span class='badge " + bc + " badge-status'>" + d.TrangThai + "</span></td>" +
                    "  <td>" +
                    "    <a href='?id=" + d.MaDatTour + "&status=Đã xác nhận' class='btn btn-sm btn-success me-1' title='Xác nhận'><i class='fas fa-check'></i></a>" +
                    "    <a href='?id=" + d.MaDatTour + "&status=Đã hủy' class='btn btn-sm btn-warning me-1' title='Hủy'><i class='fas fa-times'></i></a>" +
                    "    <a href='?delete=" + d.MaDatTour + "' class='btn btn-sm btn-outline-danger' onclick='return confirm(\"Xóa đơn này?\");'><i class='fas fa-trash'></i></a>" +
                    "  </td>" +
                    "</tr>");
            }
        }
        tableBody.InnerHtml = sb.ToString();
    }

    private void DoDelete(int id)
    {
        DatTourDAL.Delete(id);
        lblMsg.Text = "<span class='text-success'>Đã xóa đơn.</span>";
    }
}
