using System;

namespace BaDongTourism.Models
{
    public class LienHe
    {
        public int      MaLienHe  { get; set; }
        public string   HoTen     { get; set; }
        public string   Email     { get; set; }
        public string   DienThoai { get; set; }
        public string   ChuDe     { get; set; }
        public string   NoiDung   { get; set; }
        public bool     DaDoc       { get; set; }
        public DateTime NgayGui     { get; set; }
        public string   PhanHoi     { get; set; }
        public DateTime NgayPhanHoi { get; set; }
    }
}
