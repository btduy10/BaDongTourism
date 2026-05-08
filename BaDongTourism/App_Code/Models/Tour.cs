using System;

namespace BaDongTourism.Models
{
    public class Tour
    {
        public int     MaTour        { get; set; }
        public string  TenTour       { get; set; }
        public string  MoTaNgan      { get; set; }
        public string  MoTaChiTiet   { get; set; }
        public string  ThoiGian      { get; set; }
        public string  DiaDiem       { get; set; }
        public decimal GiaNguoiLon   { get; set; }
        public decimal GiaTreEm      { get; set; }
        public int     SoChoToiDa    { get; set; }
        public string  LichKhoiHanh  { get; set; }
        public string  BaoGom        { get; set; }
        public string  KhongBaoGom   { get; set; }
        public string  LuuY          { get; set; }
        public string  HinhAnhDai    { get; set; }
        public string  HinhAnhPhu    { get; set; }
        public bool    NoiBat        { get; set; }
        public int     LuotXem       { get; set; }
        public bool    TrangThai     { get; set; }
        public DateTime NgayTao      { get; set; }
    }
}
