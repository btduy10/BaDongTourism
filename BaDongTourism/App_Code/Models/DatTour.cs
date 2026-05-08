using System;

namespace BaDongTourism.Models
{
    public class DatTour
    {
        public int      MaDatTour     { get; set; }
        public int      MaTour        { get; set; }
        public string   TenTour       { get; set; }
        public string   HoTen         { get; set; }
        public string   Email         { get; set; }
        public string   DienThoai     { get; set; }
        public int      SoNguoiLon    { get; set; }
        public int      SoTreEm       { get; set; }
        public DateTime NgayKhoiHanh  { get; set; }
        public decimal  TongTien      { get; set; }
        public string   GhiChu        { get; set; }
        public string   TrangThai     { get; set; }
        public DateTime NgayDat       { get; set; }
    }
}
