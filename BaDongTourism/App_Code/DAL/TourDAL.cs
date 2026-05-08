using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BaDongTourism.App_Code;
using BaDongTourism.Models;

namespace BaDongTourism.DAL
{
    public static class TourDAL
    {
        private static Tour Map(DataRow r)
        {
            return new Tour
            {
                MaTour       = DBHelper.ToInt(r["MaTour"]),
                TenTour      = DBHelper.ToStr(r["TenTour"]),
                MoTaNgan     = DBHelper.ToStr(r["MoTaNgan"]),
                MoTaChiTiet  = DBHelper.ToStr(r["MoTaChiTiet"]),
                ThoiGian     = DBHelper.ToStr(r["ThoiGian"]),
                DiaDiem      = DBHelper.ToStr(r["DiaDiem"]),
                GiaNguoiLon  = DBHelper.ToDecimal(r["GiaNguoiLon"]),
                GiaTreEm     = DBHelper.ToDecimal(r["GiaTreEm"]),
                SoChoToiDa   = DBHelper.ToInt(r["SoChoToiDa"]),
                LichKhoiHanh = DBHelper.ToStr(r["LichKhoiHanh"]),
                BaoGom       = DBHelper.ToStr(r["BaoGom"]),
                KhongBaoGom  = DBHelper.ToStr(r["KhongBaoGom"]),
                LuuY         = DBHelper.ToStr(r["LuuY"]),
                HinhAnhDai   = DBHelper.ToStr(r["HinhAnhDai"]),
                HinhAnhPhu   = DBHelper.ToStr(r["HinhAnhPhu"]),
                NoiBat       = DBHelper.ToBool(r["NoiBat"]),
                LuotXem      = DBHelper.ToInt(r["LuotXem"]),
                TrangThai    = DBHelper.ToBool(r["TrangThai"]),
                NgayTao      = DBHelper.ToDateTime(r["NgayTao"])
            };
        }

        public static List<Tour> GetAll(bool? noiBat = null)
        {
            string sql = "SELECT * FROM Tour WHERE TrangThai = 1";
            if (noiBat.HasValue)
                sql += " AND NoiBat = " + (noiBat.Value ? "1" : "0");
            sql += " ORDER BY MaTour DESC";

            var list = new List<Tour>();
            foreach (DataRow r in DBHelper.GetDataTable(sql).Rows)
                list.Add(Map(r));
            return list;
        }

        public static Tour GetById(int id)
        {
            string sql = "SELECT * FROM Tour WHERE MaTour = @id";
            DataRow r = DBHelper.GetDataRow(sql, new[] { new SqlParameter("@id", id) });
            return r != null ? Map(r) : null;
        }

        public static void TangLuotXem(int id)
        {
            DBHelper.ExecuteNonQuery("UPDATE Tour SET LuotXem = LuotXem + 1 WHERE MaTour = @id",
                new[] { new SqlParameter("@id", id) });
        }

        public static int Insert(Tour t)
        {
            string sql = @"INSERT INTO Tour (TenTour, MoTaNgan, MoTaChiTiet, ThoiGian, DiaDiem,
                           GiaNguoiLon, GiaTreEm, SoChoToiDa, LichKhoiHanh, BaoGom,
                           KhongBaoGom, LuuY, HinhAnhDai, HinhAnhPhu, NoiBat, TrangThai)
                           VALUES (@TenTour, @MoTaNgan, @MoTaChiTiet, @ThoiGian, @DiaDiem,
                           @GiaNguoiLon, @GiaTreEm, @SoChoToiDa, @LichKhoiHanh, @BaoGom,
                           @KhongBaoGom, @LuuY, @HinhAnhDai, @HinhAnhPhu, @NoiBat, @TrangThai)";
            return DBHelper.ExecuteInsertReturnId(sql, BuildParams(t));
        }

        public static void Update(Tour t)
        {
            string sql = @"UPDATE Tour SET TenTour=@TenTour, MoTaNgan=@MoTaNgan,
                           MoTaChiTiet=@MoTaChiTiet, ThoiGian=@ThoiGian, DiaDiem=@DiaDiem,
                           GiaNguoiLon=@GiaNguoiLon, GiaTreEm=@GiaTreEm, SoChoToiDa=@SoChoToiDa,
                           LichKhoiHanh=@LichKhoiHanh, BaoGom=@BaoGom, KhongBaoGom=@KhongBaoGom,
                           LuuY=@LuuY, HinhAnhDai=@HinhAnhDai, HinhAnhPhu=@HinhAnhPhu,
                           NoiBat=@NoiBat, TrangThai=@TrangThai WHERE MaTour=@MaTour";
            var p = new List<SqlParameter>(BuildParams(t)) { new SqlParameter("@MaTour", t.MaTour) };
            DBHelper.ExecuteNonQuery(sql, p.ToArray());
        }

        public static void Delete(int id)
        {
            DBHelper.ExecuteNonQuery("DELETE FROM Tour WHERE MaTour = @id",
                new[] { new SqlParameter("@id", id) });
        }

        private static SqlParameter[] BuildParams(Tour t)
        {
            return new[]
            {
                new SqlParameter("@TenTour",      t.TenTour),
                new SqlParameter("@MoTaNgan",     t.MoTaNgan),
                new SqlParameter("@MoTaChiTiet",  t.MoTaChiTiet),
                new SqlParameter("@ThoiGian",     t.ThoiGian),
                new SqlParameter("@DiaDiem",      t.DiaDiem),
                new SqlParameter("@GiaNguoiLon",  t.GiaNguoiLon),
                new SqlParameter("@GiaTreEm",     t.GiaTreEm),
                new SqlParameter("@SoChoToiDa",   t.SoChoToiDa),
                new SqlParameter("@LichKhoiHanh", t.LichKhoiHanh),
                new SqlParameter("@BaoGom",       t.BaoGom),
                new SqlParameter("@KhongBaoGom",  t.KhongBaoGom),
                new SqlParameter("@LuuY",         t.LuuY),
                new SqlParameter("@HinhAnhDai",   t.HinhAnhDai),
                new SqlParameter("@HinhAnhPhu",   t.HinhAnhPhu),
                new SqlParameter("@NoiBat",       t.NoiBat),
                new SqlParameter("@TrangThai",    t.TrangThai)
            };
        }
    }
}
