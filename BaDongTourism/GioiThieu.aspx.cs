using System;
using System.Collections.Generic;
using System.Web.UI;
using BaDongTourism.DAL;

public partial class GioiThieuPage : Page
{
    protected Dictionary<string, string> D;

    protected void Page_Load(object sender, EventArgs e)
    {
        D = CaiDatDAL.GetByNhom("GioiThieu");
    }

    // Lay gia tri tu dictionary, fallback mac dinh
    protected string C(string key, string df = "")
    {
        if (D != null && D.ContainsKey(key) && D[key] != "")
            return D[key];
        return df;
    }

    // Resolve duong dan anh
    protected string Img(string key, string macDinh)
    {
        string val = C(key);
        if (string.IsNullOrEmpty(val))
            return ResolveUrl("~/Content/images/" + macDinh);
        // Neu la ten file don gian (khong co slash) -> lay tu uploads
        if (!val.Contains("/") && !val.Contains("\\"))
            return ResolveUrl("~/Content/images/uploads/" + val);
        return ResolveUrl("~/Content/images/" + val);
    }
}
