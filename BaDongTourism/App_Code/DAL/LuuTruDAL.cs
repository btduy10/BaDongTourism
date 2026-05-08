using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BaDongTourism.App_Code;
using BaDongTourism.Models;

namespace BaDongTourism.DAL
{
    public static class LuuTruDAL
    {
        private static LuuTru Map(DataRow r)
        {
            return new LuuTru
            {
                MaLuuTru    = DBHelper.ToInt(r["MaLuuTru"]),
                TenLuuTru   = DBHelper.ToStr(r["TenLuuTru"]),
                LoaiLuuTru  = DBHelper.ToStr(r["LoaiLuuTru"]),
                MoTaNgan    = DBHelper.ToStr(r["MoTaNgan"]),
                MoTaChiTiet = DBHelper.ToStr(r["MoTaChiTiet"]),
                DiaChi      = DBHelper.ToStr(r["DiaChi"]),
                DienThoai   = DBHelper.ToStr(r["DienThoai"]),
                Email       = DBHelper.ToStr(r["Email"]),
                Website     = DBHelper.ToStr(r["Website"]),
                GiaPhong    = DBHelper.ToStr(r["GiaPhong"]),
                TienNghi    = DBHelper.ToStr(r["TienNghi"]),
                HinhAnhDai  = DBHelper.ToStr(r["HinhAnhDai"]),
                HinhAnhPhu  = DBHelper.ToStr(r["HinhAnhPhu"]),
                BanDo       = DBHelper.ToStr(r["BanDo"]),
                XepHang     = DBHelper.ToInt(r["XepHang"]),
                NoiBat      = DBHelper.ToBool(r["NoiBat"]),
                TrangThai   = DBHelper.ToBool(r["TrangThai"]),
                NgayTao     = DBHelper.ToDateTime(r["NgayTao"])
            };
        }

        public static List<LuuTru> GetAll(bool? noiBat = null)
        {
            string sql = "SELECT * FROM LuuTru WHERE TrangThai = 1";
            if (noiBat.HasValue)
                sql += " AND NoiBat = " + (noiBat.Value ? "1" : "0");
            sql += " ORDER BY XepHang DESC, MaLuuTru";
            var list = new List<LuuTru>();
            foreach (DataRow r in DBHelper.GetDataTable(sql).Rows)
                list.Add(Map(r));
            return list;
        }

        public static LuuTru GetById(int id)
        {
            DataRow r = DBHelper.GetDataRow("SELECT * FROM LuuTru WHERE MaLuuTru = @id",
                new[] { new SqlParameter("@id", id) });
            return r != null ? Map(r) : null;
        }

        public static int Insert(LuuTru lt)
        {
            string sql = @"INSERT INTO LuuTru (TenLuuTru, LoaiLuuTru, MoTaNgan, MoTaChiTiet,
                           DiaChi, DienThoai, Email, Website, GiaPhong, TienNghi,
                           HinhAnhDai, HinhAnhPhu, BanDo, XepHang, NoiBat, TrangThai)
                           VALUES (@TenLuuTru, @LoaiLuuTru, @MoTaNgan, @MoTaChiTiet,
                           @DiaChi, @DienThoai, @Email, @Website, @GiaPhong, @TienNghi,
                           @HinhAnhDai, @HinhAnhPhu, @BanDo, @XepHang, @NoiBat, @TrangThai)";
            return DBHelper.ExecuteInsertReturnId(sql, BuildParams(lt));
        }

        public static void Update(LuuTru lt)
        {
            string sql = @"UPDATE LuuTru SET TenLuuTru=@TenLuuTru, LoaiLuuTru=@LoaiLuuTru,
                           MoTaNgan=@MoTaNgan, MoTaChiTiet=@MoTaChiTiet, DiaChi=@DiaChi,
                           DienThoai=@DienThoai, Email=@Email, Website=@Website,
                           GiaPhong=@GiaPhong, TienNghi=@TienNghi, HinhAnhDai=@HinhAnhDai,
                           HinhAnhPhu=@HinhAnhPhu, BanDo=@BanDo, XepHang=@XepHang,
                           NoiBat=@NoiBat, TrangThai=@TrangThai WHERE MaLuuTru=@MaLuuTru";
            var p = new List<SqlParameter>(BuildParams(lt)) { new SqlParameter("@MaLuuTru", lt.MaLuuTru) };
            DBHelper.ExecuteNonQuery(sql, p.ToArray());
        }

        public static void Delete(int id)
        {
            DBHelper.ExecuteNonQuery("DELETE FROM LuuTru WHERE MaLuuTru = @id",
                new[] { new SqlParameter("@id", id) });
        }

        private static SqlParameter[] BuildParams(LuuTru lt)
        {
            return new[]
            {
                new SqlParameter("@TenLuuTru",   lt.TenLuuTru),
                new SqlParameter("@LoaiLuuTru",  lt.LoaiLuuTru),
                new SqlParameter("@MoTaNgan",    lt.MoTaNgan),
                new SqlParameter("@MoTaChiTiet", lt.MoTaChiTiet),
                new SqlParameter("@DiaChi",      lt.DiaChi),
                new SqlParameter("@DienThoai",   lt.DienThoai),
                new SqlParameter("@Email",       lt.Email),
                new SqlParameter("@Website",     lt.Website),
                new SqlParameter("@GiaPhong",    lt.GiaPhong),
                new SqlParameter("@TienNghi",    lt.TienNghi),
                new SqlParameter("@HinhAnhDai",  lt.HinhAnhDai),
                new SqlParameter("@HinhAnhPhu",  lt.HinhAnhPhu),
                new SqlParameter("@BanDo",       lt.BanDo),
                new SqlParameter("@XepHang",     lt.XepHang),
                new SqlParameter("@NoiBat",      lt.NoiBat),
                new SqlParameter("@TrangThai",   lt.TrangThai)
            };
        }
    }
}
