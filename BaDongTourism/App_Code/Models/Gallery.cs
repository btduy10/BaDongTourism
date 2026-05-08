using System;

namespace BaDongTourism.Models
{
    public class Gallery
    {
        public int      MaAnh       { get; set; }
        public string   TieuDe      { get; set; }
        public string   MoTa        { get; set; }
        public string   DuongDanAnh { get; set; }
        public string   DanhMuc     { get; set; }
        public int      ThuTu       { get; set; }
        public bool     TrangThai   { get; set; }
        public DateTime NgayTao     { get; set; }
    }
}
