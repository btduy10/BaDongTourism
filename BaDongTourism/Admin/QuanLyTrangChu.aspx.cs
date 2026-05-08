using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using BaDongTourism.DAL;

public partial class Admin_QuanLyTrangChu : Page
{
    private const string NHOM = "TrangChu";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadAll();
    }

    private void LoadAll()
    {
        var d = CaiDatDAL.GetByNhom(NHOM);

        // Tab 1 – Ve chung toi (fallback = gia tri hien dang hien thi)
        txtSubtitle.Text  = Val(d, "tc_subtitle",  "Về Chúng Tôi");
        txtTieuDe.Text    = Val(d, "tc_tieude",    "Viên Ngọc Xanh\nCủa Trà Vinh");
        txtDoan1.Text     = Val(d, "tc_doan_1",    "Bãi biển Ba Động thuộc xã Trường Long Hòa, huyện Duyên Hải, tỉnh Trà Vinh – nằm cách TP. Trà Vinh khoảng 50km về phía Nam. Đây là một trong những bãi biển hoang sơ, đẹp và ít bị tác động nhất ở miền Tây Nam Bộ.");
        txtDoan2.Text     = Val(d, "tc_doan_2",    "Với bờ biển dài hơn 10km, cát trắng mịn, sóng êm và không khí trong lành, Ba Động đang dần trở thành điểm đến hấp dẫn cho những du khách muốn tìm về thiên nhiên nguyên sơ.");
        txtBadgeSo.Text   = Val(d, "tc_badge_so",  "Top 10");
        txtBadgeTen.Text  = Val(d, "tc_badge_ten", "Bãi biển đẹp VN");
        litHinh.Text      = Val(d, "tc_hinh",      "chưa có (dùng about-main.jpg mặc định)");
        txtFeat1Ten.Text  = Val(d, "tc_feat1_ten", "Biển Sạch");
        txtFeat1Mo.Text   = Val(d, "tc_feat1_mo",  "Nước biển trong xanh, ít ô nhiễm");
        txtFeat2Ten.Text  = Val(d, "tc_feat2_ten", "Sinh Thái");
        txtFeat2Mo.Text   = Val(d, "tc_feat2_mo",  "Rừng ngập mặn đa dạng");
        txtFeat3Ten.Text  = Val(d, "tc_feat3_ten", "Hải Sản");
        txtFeat3Mo.Text   = Val(d, "tc_feat3_mo",  "Cua Huỳnh Đế nổi tiếng");
        txtFeat4Ten.Text  = Val(d, "tc_feat4_ten", "Thân Thiện");
        txtFeat4Mo.Text   = Val(d, "tc_feat4_mo",  "Người dân hiếu khách");

        // Tab 2 – Thong ke
        txtStat1So.Text    = Val(d, "stat1_so",    "10");
        txtStat1HauTo.Text = Val(d, "stat1_hauTo", "km+");
        txtStat1Nhan.Text  = Val(d, "stat1_nhan",  "Chiều dài bãi biển");
        txtStat2So.Text    = Val(d, "stat2_so",    "50");
        txtStat2HauTo.Text = Val(d, "stat2_hauTo", "+");
        txtStat2Nhan.Text  = Val(d, "stat2_nhan",  "Tour du lịch");
        txtStat3So.Text    = Val(d, "stat3_so",    "30");
        txtStat3HauTo.Text = Val(d, "stat3_hauTo", "+");
        txtStat3Nhan.Text  = Val(d, "stat3_nhan",  "Cơ sở lưu trú");
        txtStat4So.Text    = Val(d, "stat4_so",    "100000");
        txtStat4HauTo.Text = Val(d, "stat4_hauTo", "+");
        txtStat4Nhan.Text  = Val(d, "stat4_nhan",  "Lượt khách/năm");

        // Tab 3 – CTA
        txtCtaTieuDe.Text   = Val(d, "cta_tieude",    "Sẵn Sàng Khám Phá Ba Động?");
        txtCtaMoTa.Text     = Val(d, "cta_mota",      "Liên hệ ngay để được tư vấn và đặt tour với giá tốt nhất!");
        txtCtaBtn1.Text     = Val(d, "cta_btn1",      "Đặt Tour Ngay");
        txtCtaBtn1Link.Text = Val(d, "cta_btn1_link", "DatTour.aspx");
        txtCtaBtn2.Text     = Val(d, "cta_btn2",      "Liên Hệ");
        txtCtaBtn2Link.Text = Val(d, "cta_btn2_link", "LienHe.aspx");

        // Tab 4 – Banner Am Thuc & Luu Tru
        txtAtTieuDe.Text = Val(d, "at_tieude");
        txtAtMoTa.Text   = Val(d, "at_mota");
        txtAtTieuDe.Text = Val(d, "at_tieude", "Ẩm Thực Địa Phương");
        txtAtMoTa.Text   = Val(d, "at_mota",   "Cua Huỳnh Đế, hải sản tươi ngon đặc trưng");
        txtAtBtn.Text    = Val(d, "at_btn",    "Khám Phá");
        litAtHinh.Text   = Val(d, "at_hinh",   "chưa có (dùng màu nền mặc định)");
        txtLtTieuDe.Text = Val(d, "lt_tieude", "Lưu Trú Tiện Nghi");
        txtLtMoTa.Text   = Val(d, "lt_mota",   "Resort, khách sạn, nhà nghỉ đa dạng giá tốt");
        txtLtBtn.Text    = Val(d, "lt_btn",    "Xem Ngay");
        litLtHinh.Text   = Val(d, "lt_hinh",   "chưa có (dùng màu nền mặc định)");
    }

    protected void btnLuuTab1_Click(object sender, EventArgs e)
    {
        hfActiveTab.Value = "tab1";

        string hinh = CaiDatDAL.Get("tc_hinh");
        if (fuHinh.HasFile)
        {
            hinh = UploadAnh(fuHinh);
            if (hinh == null) return;
        }

        var data = new Dictionary<string, string>
        {
            { "tc_subtitle",  txtSubtitle.Text.Trim()  },
            { "tc_tieude",    txtTieuDe.Text.Trim()    },
            { "tc_doan_1",    txtDoan1.Text.Trim()     },
            { "tc_doan_2",    txtDoan2.Text.Trim()     },
            { "tc_badge_so",  txtBadgeSo.Text.Trim()   },
            { "tc_badge_ten", txtBadgeTen.Text.Trim()  },
            { "tc_hinh",      hinh != null ? hinh : "" },
            { "tc_feat1_ten", txtFeat1Ten.Text.Trim()  },
            { "tc_feat1_mo",  txtFeat1Mo.Text.Trim()   },
            { "tc_feat2_ten", txtFeat2Ten.Text.Trim()  },
            { "tc_feat2_mo",  txtFeat2Mo.Text.Trim()   },
            { "tc_feat3_ten", txtFeat3Ten.Text.Trim()  },
            { "tc_feat3_mo",  txtFeat3Mo.Text.Trim()   },
            { "tc_feat4_ten", txtFeat4Ten.Text.Trim()  },
            { "tc_feat4_mo",  txtFeat4Mo.Text.Trim()   }
        };
        CaiDatDAL.SetMany(data, NHOM);
        ShowMsg("success", "Da luu phan Ve Chung Toi thanh cong!");
        litHinh.Text = string.IsNullOrEmpty(hinh) ? "about-main.jpg (mac dinh)" : hinh;
    }

    protected void btnLuuTab2_Click(object sender, EventArgs e)
    {
        hfActiveTab.Value = "tab2";

        var data = new Dictionary<string, string>
        {
            { "stat1_so",    txtStat1So.Text.Trim()    },
            { "stat1_hauTo", txtStat1HauTo.Text.Trim() },
            { "stat1_nhan",  txtStat1Nhan.Text.Trim()  },
            { "stat2_so",    txtStat2So.Text.Trim()    },
            { "stat2_hauTo", txtStat2HauTo.Text.Trim() },
            { "stat2_nhan",  txtStat2Nhan.Text.Trim()  },
            { "stat3_so",    txtStat3So.Text.Trim()    },
            { "stat3_hauTo", txtStat3HauTo.Text.Trim() },
            { "stat3_nhan",  txtStat3Nhan.Text.Trim()  },
            { "stat4_so",    txtStat4So.Text.Trim()    },
            { "stat4_hauTo", txtStat4HauTo.Text.Trim() },
            { "stat4_nhan",  txtStat4Nhan.Text.Trim()  }
        };
        CaiDatDAL.SetMany(data, NHOM);
        ShowMsg("success", "Da luu thong ke thanh cong!");
    }

    protected void btnLuuTab3_Click(object sender, EventArgs e)
    {
        hfActiveTab.Value = "tab3";

        var data = new Dictionary<string, string>
        {
            { "cta_tieude",   txtCtaTieuDe.Text.Trim()   },
            { "cta_mota",     txtCtaMoTa.Text.Trim()     },
            { "cta_btn1",     txtCtaBtn1.Text.Trim()     },
            { "cta_btn1_link",txtCtaBtn1Link.Text.Trim() },
            { "cta_btn2",     txtCtaBtn2.Text.Trim()     },
            { "cta_btn2_link",txtCtaBtn2Link.Text.Trim() }
        };
        CaiDatDAL.SetMany(data, NHOM);
        ShowMsg("success", "Da luu CTA thanh cong!");
    }

    protected void btnLuuTab4_Click(object sender, EventArgs e)
    {
        hfActiveTab.Value = "tab4";

        string atHinh = CaiDatDAL.Get("at_hinh");
        if (fuAtHinh.HasFile)
        {
            atHinh = UploadAnh(fuAtHinh);
            if (atHinh == null) return;
        }

        string ltHinh = CaiDatDAL.Get("lt_hinh");
        if (fuLtHinh.HasFile)
        {
            ltHinh = UploadAnh(fuLtHinh);
            if (ltHinh == null) return;
        }

        var data = new Dictionary<string, string>
        {
            { "at_tieude", txtAtTieuDe.Text.Trim() },
            { "at_mota",   txtAtMoTa.Text.Trim()   },
            { "at_btn",    txtAtBtn.Text.Trim()     },
            { "at_hinh",   atHinh != null ? atHinh : "" },
            { "lt_tieude", txtLtTieuDe.Text.Trim() },
            { "lt_mota",   txtLtMoTa.Text.Trim()   },
            { "lt_btn",    txtLtBtn.Text.Trim()     },
            { "lt_hinh",   ltHinh != null ? ltHinh : "" }
        };
        CaiDatDAL.SetMany(data, NHOM);
        ShowMsg("success", "Da luu banner Am Thuc & Luu Tru thanh cong!");
        litAtHinh.Text = string.IsNullOrEmpty(atHinh) ? "food-banner.jpg (mac dinh)" : atHinh;
        litLtHinh.Text = string.IsNullOrEmpty(ltHinh) ? "hotel-banner.jpg (mac dinh)" : ltHinh;
    }

    // -------------------------------------------------------
    private string UploadAnh(System.Web.UI.WebControls.FileUpload fu)
    {
        string ext = Path.GetExtension(fu.FileName).ToLower();
        string[] ok = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        bool valid = false;
        foreach (string ae in ok) if (ext == ae) { valid = true; break; }
        if (!valid) { ShowMsg("danger", "Chi cho phep file anh (jpg, png, gif, webp)."); return null; }

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
        lblMsg.Text = "<div class='alert alert-" + type + " alert-dismissible rounded-3 mb-0'>" +
                      "<i class='fas fa-check-circle me-2'></i>" + msg +
                      "<button type='button' class='btn-close' data-bs-dismiss='alert'></button></div>";
    }
}
