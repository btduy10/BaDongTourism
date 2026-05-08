using System;

namespace BaDongTourism.Models
{
    public class DiaDiem
    {
        public int    MaDiaDiem   { get; set; }
        public int    MaDanhMuc   { get; set; }
        public string TenDanhMuc  { get; set; }
        public string TenDiaDiem  { get; set; }
        public string MoTaNgan    { get; set; }
        public string MoTaChiTiet { get; set; }
        public string DiaChi      { get; set; }
        public string HinhAnhDai  { get; set; }
        public string HinhAnhPhu  { get; set; }
        public string BanDo       { get; set; }
        public int    ThuTu       { get; set; }
        public int    LuotXem     { get; set; }
        public bool   NoiBat      { get; set; }
        public bool   TrangThai   { get; set; }
        public DateTime NgayTao   { get; set; }
    }
}
