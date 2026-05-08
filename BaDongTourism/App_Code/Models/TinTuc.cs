using System;

namespace BaDongTourism.Models
{
    public class TinTuc
    {
        public int      MaTinTuc    { get; set; }
        public int      MaDanhMuc   { get; set; }
        public string   TenDanhMuc  { get; set; }
        public int      MaTK        { get; set; }
        public string   TenTacGia   { get; set; }
        public string   TieuDe      { get; set; }
        public string   TomTat      { get; set; }
        public string   NoiDung     { get; set; }
        public string   HinhAnhDai  { get; set; }
        public int      LuotXem     { get; set; }
        public bool     NoiBat      { get; set; }
        public bool     TrangThai   { get; set; }
        public DateTime NgayDang    { get; set; }
    }
}
