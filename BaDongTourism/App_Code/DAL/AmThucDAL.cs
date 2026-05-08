using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BaDongTourism.App_Code;
using BaDongTourism.Models;

namespace BaDongTourism.DAL
{
    public static class AmThucDAL
    {
        private static AmThuc Map(DataRow r)
        {
            return new AmThuc
            {
                MaAmThuc    = DBHelper.ToInt(r["MaAmThuc"]),
                TenAmThuc   = DBHelper.ToStr(r["TenAmThuc"]),
                LoaiAmThuc  = DBHelper.ToStr(r["LoaiAmThuc"]),
                MoTaNgan    = DBHelper.ToStr(r["MoTaNgan"]),
                MoTaChiTiet = DBHelper.ToStr(r["MoTaChiTiet"]),
                DiaChi      = DBHelper.ToStr(r["DiaChi"]),
                DienThoai   = DBHelper.ToStr(r["DienThoai"]),
                GioMoCua    = DBHelper.ToStr(r["GioMoCua"]),
                KhoangGia   = DBHelper.ToStr(r["KhoangGia"]),
                HinhAnhDai  = DBHelper.ToStr(r["HinhAnhDai"]),
                HinhAnhPhu  = DBHelper.ToStr(r["HinhAnhPhu"]),
                NoiBat      = DBHelper.ToBool(r["NoiBat"]),
                TrangThai   = DBHelper.ToBool(r["TrangThai"]),
                NgayTao     = DBHelper.ToDateTime(r["NgayTao"])
            };
        }

        public static List<AmThuc> GetAll(bool? noiBat = null)
        {
            string sql = "SELECT * FROM AmThuc WHERE TrangThai = 1";
            if (noiBat.HasValue)
                sql += " AND NoiBat = " + (noiBat.Value ? "1" : "0");
            sql += " ORDER BY MaAmThuc";
            var list = new List<AmThuc>();
            foreach (DataRow r in DBHelper.GetDataTable(sql).Rows)
                list.Add(Map(r));
            return list;
        }

        public static AmThuc GetById(int id)
        {
            DataRow r = DBHelper.GetDataRow("SELECT * FROM AmThuc WHERE MaAmThuc = @id",
                new[] { new SqlParameter("@id", id) });
            return r != null ? Map(r) : null;
        }

        public static int Insert(AmThuc at)
        {
            string sql = @"INSERT INTO AmThuc (TenAmThuc, LoaiAmThuc, MoTaNgan, MoTaChiTiet,
                           DiaChi, DienThoai, GioMoCua, KhoangGia, HinhAnhDai, HinhAnhPhu, NoiBat, TrangThai)
                           VALUES (@TenAmThuc, @LoaiAmThuc, @MoTaNgan, @MoTaChiTiet,
                           @DiaChi, @DienThoai, @GioMoCua, @KhoangGia, @HinhAnhDai, @HinhAnhPhu, @NoiBat, @TrangThai)";
            return DBHelper.ExecuteInsertReturnId(sql, BuildParams(at));
        }

        public static void Update(AmThuc at)
        {
            string sql = @"UPDATE AmThuc SET TenAmThuc=@TenAmThuc, LoaiAmThuc=@LoaiAmThuc,
                           MoTaNgan=@MoTaNgan, MoTaChiTiet=@MoTaChiTiet, DiaChi=@DiaChi,
                           DienThoai=@DienThoai, GioMoCua=@GioMoCua, KhoangGia=@KhoangGia,
                           HinhAnhDai=@HinhAnhDai, HinhAnhPhu=@HinhAnhPhu,
                           NoiBat=@NoiBat, TrangThai=@TrangThai WHERE MaAmThuc=@MaAmThuc";
            var p = new List<SqlParameter>(BuildParams(at)) { new SqlParameter("@MaAmThuc", at.MaAmThuc) };
            DBHelper.ExecuteNonQuery(sql, p.ToArray());
        }

        public static void Delete(int id)
        {
            DBHelper.ExecuteNonQuery("DELETE FROM AmThuc WHERE MaAmThuc = @id",
                new[] { new SqlParameter("@id", id) });
        }

        private static SqlParameter[] BuildParams(AmThuc at)
        {
            return new[]
            {
                new SqlParameter("@TenAmThuc",   at.TenAmThuc),
                new SqlParameter("@LoaiAmThuc",  at.LoaiAmThuc),
                new SqlParameter("@MoTaNgan",    at.MoTaNgan),
                new SqlParameter("@MoTaChiTiet", at.MoTaChiTiet),
                new SqlParameter("@DiaChi",      at.DiaChi),
                new SqlParameter("@DienThoai",   at.DienThoai),
                new SqlParameter("@GioMoCua",    at.GioMoCua),
                new SqlParameter("@KhoangGia",   at.KhoangGia),
                new SqlParameter("@HinhAnhDai",  at.HinhAnhDai),
                new SqlParameter("@HinhAnhPhu",  at.HinhAnhPhu),
                new SqlParameter("@NoiBat",      at.NoiBat),
                new SqlParameter("@TrangThai",   at.TrangThai)
            };
        }
    }
}
