using System;

namespace BaDongTourism.Models
{
    public class AmThuc
    {
        public int    MaAmThuc    { get; set; }
        public string TenAmThuc   { get; set; }
        public string LoaiAmThuc  { get; set; }
        public string MoTaNgan    { get; set; }
        public string MoTaChiTiet { get; set; }
        public string DiaChi      { get; set; }
        public string DienThoai   { get; set; }
        public string GioMoCua    { get; set; }
        public string KhoangGia   { get; set; }
        public string HinhAnhDai  { get; set; }
        public string HinhAnhPhu  { get; set; }
        public bool   NoiBat      { get; set; }
        public bool   TrangThai   { get; set; }
        public DateTime NgayTao   { get; set; }
    }
}
