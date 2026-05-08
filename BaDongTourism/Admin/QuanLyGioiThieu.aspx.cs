using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using BaDongTourism.DAL;

public partial class Admin_QuanLyGioiThieu : Page
{
    private const string NHOM = "GioiThieu";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadAll();
    }

    private void LoadAll()
    {
        var d = CaiDatDAL.GetByNhom(NHOM);

        // Tab 1
        txtTieuDe.Text  = Val(d, "gt_tieude_chinh");
        txtDoan1.Text   = Val(d, "gt_doan_1");
        txtDoan2.Text   = Val(d, "gt_doan_2");
        txtDoan3.Text   = Val(d, "gt_doan_3");
        txtStat1So.Text = Val(d, "gt_stat_1_so");
        txtStat1Ten.Text= Val(d, "gt_stat_1_ten");
        txtStat2So.Text = Val(d, "gt_stat_2_so");
        txtStat2Ten.Text= Val(d, "gt_stat_2_ten");
        litHinhChinh.Text = Val(d, "gt_hinh_chinh", "chưa có");

        // Tab 2
        txtVhlsTieuDe.Text = Val(d, "vhls_tieude");
        txtVhlsDoan1.Text  = Val(d, "vhls_doan_1");
        txtVhlsDoan2.Text  = Val(d, "vhls_doan_2");
        txtVhlsDoan3.Text  = Val(d, "vhls_doan_3");
        litHinhVhls.Text   = Val(d, "vhls_hinh", "chưa có");

        // Tab 3
        txtDichuyOTo.Text     = Val(d, "dichuy_o_to");
        txtDichuyXeKhach.Text = Val(d, "dichuy_xe_khach");
        txtDichuyXeMay.Text   = Val(d, "dichuy_xe_may");
    }

    protected void btnLuuTab1_Click(object sender, EventArgs e)
    {
        hfActiveTab.Value = "tab1";

        string hinhChinh = CaiDatDAL.Get("gt_hinh_chinh");
        if (fuHinhChinh.HasFile)
        {
            hinhChinh = UploadAnh(fuHinhChinh, "gt_hinh_chinh");
            if (hinhChinh == null) return;
        }

        var data = new Dictionary<string, string>
        {
            { "gt_tieude_chinh", txtTieuDe.Text.Trim()  },
            { "gt_doan_1",       txtDoan1.Text.Trim()   },
            { "gt_doan_2",       txtDoan2.Text.Trim()   },
            { "gt_doan_3",       txtDoan3.Text.Trim()   },
            { "gt_stat_1_so",    txtStat1So.Text.Trim() },
            { "gt_stat_1_ten",   txtStat1Ten.Text.Trim()},
            { "gt_stat_2_so",    txtStat2So.Text.Trim() },
            { "gt_stat_2_ten",   txtStat2Ten.Text.Trim()},
            { "gt_hinh_chinh",   hinhChinh              }
        };
        CaiDatDAL.SetMany(data, NHOM);
        ShowMsg("success", "Đã lưu nội dung chính thành công!");
        litHinhChinh.Text = hinhChinh;
    }

    protected void btnLuuTab2_Click(object sender, EventArgs e)
    {
        hfActiveTab.Value = "tab2";

        string hinhVhls = CaiDatDAL.Get("vhls_hinh");
        if (fuHinhVhls.HasFile)
        {
            hinhVhls = UploadAnh(fuHinhVhls, "vhls_hinh");
            if (hinhVhls == null) return;
        }

        var data = new Dictionary<string, string>
        {
            { "vhls_tieude", txtVhlsTieuDe.Text.Trim() },
            { "vhls_doan_1", txtVhlsDoan1.Text.Trim()  },
            { "vhls_doan_2", txtVhlsDoan2.Text.Trim()  },
            { "vhls_doan_3", txtVhlsDoan3.Text.Trim()  },
            { "vhls_hinh",   hinhVhls                  }
        };
        CaiDatDAL.SetMany(data, NHOM);
        ShowMsg("success", "Đã lưu phần Văn Hóa & Lịch Sử thành công!");
        litHinhVhls.Text = hinhVhls;
    }

    protected void btnLuuTab3_Click(object sender, EventArgs e)
    {
        hfActiveTab.Value = "tab3";

        var data = new Dictionary<string, string>
        {
            { "dichuy_o_to",      txtDichuyOTo.Text.Trim()     },
            { "dichuy_xe_khach",  txtDichuyXeKhach.Text.Trim() },
            { "dichuy_xe_may",    txtDichuyXeMay.Text.Trim()   }
        };
        CaiDatDAL.SetMany(data, NHOM);
        ShowMsg("success", "Đã lưu hướng dẫn di chuyển thành công!");
    }

    // -------------------------------------------------------
    private string UploadAnh(System.Web.UI.WebControls.FileUpload fu, string key)
    {
        string ext = Path.GetExtension(fu.FileName).ToLower();
        string[] ok = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        bool valid = false;
        foreach (string ae in ok) if (ext == ae) { valid = true; break; }
        if (!valid)
        {
            ShowMsg("danger", "Chỉ cho phép file ảnh (jpg, png, gif, webp).");
            return null;
        }
        string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fu.FileName;
        string path = Server.MapPath("~/Content/images/uploads/");
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        fu.SaveAs(Path.Combine(path, fileName));
        return fileName;
    }

    private string Val(Dictionary<string, string> d, string key, string df = "")
    {
        return d.ContainsKey(key) ? d[key] : df;
    }

    private void ShowMsg(string type, string msg)
    {
        lblMsg.Text = "<div class='alert alert-" + type + " alert-dismissible rounded-3 mb-4'>" +
                      "<i class='fas fa-check-circle me-2'></i>" + msg +
                      "<button type='button' class='btn-close' data-bs-dismiss='alert'></button></div>";
    }
}
