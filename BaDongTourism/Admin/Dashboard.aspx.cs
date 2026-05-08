using System;
using System.Text;
using System.Web.UI;
using BaDongTourism.DAL;
using BaDongTourism.App_Code;

public partial class Admin_Dashboard : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadStats();
    }

    private void LoadStats()
    {
        soDD.InnerText      = DBHelper.ToInt(DBHelper.ExecuteScalar("SELECT COUNT(*) FROM DiaDiem WHERE TrangThai=1")).ToString();
        soTour.InnerText    = DBHelper.ToInt(DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Tour WHERE TrangThai=1")).ToString();
        soDatTour.InnerText = DBHelper.ToInt(DBHelper.ExecuteScalar("SELECT COUNT(*) FROM DatTour")).ToString();
        soLienHe.InnerText  = LienHeDAL.SoTinChuaDoc().ToString();

        var datList = DatTourDAL.GetAll();
        if (datList.Count > 0)
        {
            var sb = new StringBuilder();
            int count = 0;
            foreach (var d in datList)
            {
                if (count++ >= 5) break;
                string badgeClass = d.TrangThai.Contains("Xác nhận") ? "bg-success" :
                                    d.TrangThai.Contains("Hủy") ? "bg-danger" : "bg-warning text-dark";
                sb.Append(
                    "<tr>" +
                    "  <td>#" + d.MaDatTour + "</td>" +
                    "  <td><strong>" + d.HoTen + "</strong><br/><small class='text-muted'>" + d.DienThoai + "</small></td>" +
                    "  <td><small>" + d.TenTour + "</small></td>" +
                    "  <td class='text-warning fw-bold'>" + d.TongTien.ToString("N0") + "đ</td>" +
                    "  <td><span class='badge " + badgeClass + " badge-status'>" + d.TrangThai + "</span></td>" +
                    "</tr>");
            }
            datTourTable.InnerHtml = sb.ToString();
        }

        var lhList = LienHeDAL.GetAll();
        var sb2 = new StringBuilder();
        int count2 = 0;
        foreach (var lh in lhList)
        {
            if (lh.DaDoc || count2++ >= 5) continue;
            string preview = lh.NoiDung.Length > 60 ? lh.NoiDung.Substring(0, 60) + "..." : lh.NoiDung;
            sb2.Append(
                "<div class='d-flex align-items-start gap-3 mb-3 p-3 rounded-3' style='background:#f0f8ff;'>" +
                "  <div style='width:40px;height:40px;background:#0077b6;border-radius:50%;display:flex;align-items:center;justify-content:center;color:white;flex-shrink:0;'>" +
                "    <i class='fas fa-user'></i>" +
                "  </div>" +
                "  <div>" +
                "    <strong>" + lh.HoTen + "</strong> <small class='text-muted ms-2'>" + lh.NgayGui.ToString("dd/MM/yyyy HH:mm") + "</small>" +
                "    <p class='mb-0 small text-muted mt-1'>" + preview + "</p>" +
                "  </div>" +
                "</div>");
        }
        if (sb2.Length > 0)
            lienHeList.InnerHtml = sb2.ToString();
    }
}
