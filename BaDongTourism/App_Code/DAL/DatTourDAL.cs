using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BaDongTourism.App_Code;
using BaDongTourism.Models;

namespace BaDongTourism.DAL
{
    public static class DatTourDAL
    {
        private static DatTour Map(DataRow r)
        {
            return new DatTour
            {
                MaDatTour    = DBHelper.ToInt(r["MaDatTour"]),
                MaTour       = DBHelper.ToInt(r["MaTour"]),
                TenTour      = DBHelper.ToStr(r.Table.Columns.Contains("TenTour") ? r["TenTour"] : null),
                HoTen        = DBHelper.ToStr(r["HoTen"]),
                Email        = DBHelper.ToStr(r["Email"]),
                DienThoai    = DBHelper.ToStr(r["DienThoai"]),
                SoNguoiLon   = DBHelper.ToInt(r["SoNguoiLon"]),
                SoTreEm      = DBHelper.ToInt(r["SoTreEm"]),
                NgayKhoiHanh = DBHelper.ToDateTime(r["NgayKhoiHanh"]),
                TongTien     = DBHelper.ToDecimal(r["TongTien"]),
                GhiChu       = DBHelper.ToStr(r["GhiChu"]),
                TrangThai    = DBHelper.ToStr(r["TrangThai"]),
                NgayDat      = DBHelper.ToDateTime(r["NgayDat"])
            };
        }

        public static List<DatTour> GetAll()
        {
            string sql = @"SELECT dt.*, t.TenTour FROM DatTour dt
                           LEFT JOIN Tour t ON dt.MaTour = t.MaTour
                           ORDER BY dt.NgayDat DESC";
            var list = new List<DatTour>();
            foreach (DataRow r in DBHelper.GetDataTable(sql).Rows)
                list.Add(Map(r));
            return list;
        }

        public static DatTour GetById(int id)
        {
            string sql = @"SELECT dt.*, t.TenTour FROM DatTour dt
                           LEFT JOIN Tour t ON dt.MaTour = t.MaTour
                           WHERE dt.MaDatTour = @id";
            DataRow r = DBHelper.GetDataRow(sql, new[] { new SqlParameter("@id", id) });
            return r != null ? Map(r) : null;
        }

        public static int Insert(DatTour d)
        {
            string sql = @"INSERT INTO DatTour (MaTour, HoTen, Email, DienThoai,
                           SoNguoiLon, SoTreEm, NgayKhoiHanh, TongTien, GhiChu, TrangThai)
                           VALUES (@MaTour, @HoTen, @Email, @DienThoai,
                           @SoNguoiLon, @SoTreEm, @NgayKhoiHanh, @TongTien, @GhiChu, N'Chờ xác nhận')";
            return DBHelper.ExecuteInsertReturnId(sql, new[]
            {
                new SqlParameter("@MaTour",       d.MaTour),
                new SqlParameter("@HoTen",        d.HoTen),
                new SqlParameter("@Email",        d.Email),
                new SqlParameter("@DienThoai",    d.DienThoai),
                new SqlParameter("@SoNguoiLon",   d.SoNguoiLon),
                new SqlParameter("@SoTreEm",      d.SoTreEm),
                new SqlParameter("@NgayKhoiHanh", d.NgayKhoiHanh == DateTime.MinValue ? (object)DBNull.Value : (object)d.NgayKhoiHanh),
                new SqlParameter("@TongTien",     d.TongTien),
                new SqlParameter("@GhiChu",       d.GhiChu)
            });
        }

        public static void CapNhatTrangThai(int id, string trangThai)
        {
            DBHelper.ExecuteNonQuery(
                "UPDATE DatTour SET TrangThai = @tt WHERE MaDatTour = @id",
                new[]
                {
                    new SqlParameter("@tt", trangThai),
                    new SqlParameter("@id", id)
                });
        }

        public static void Delete(int id)
        {
            DBHelper.ExecuteNonQuery("DELETE FROM DatTour WHERE MaDatTour = @id",
                new[] { new SqlParameter("@id", id) });
        }
    }
}
