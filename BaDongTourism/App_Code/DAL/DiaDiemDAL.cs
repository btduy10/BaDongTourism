using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BaDongTourism.App_Code;
using BaDongTourism.Models;

namespace BaDongTourism.DAL
{
    public static class DiaDiemDAL
    {
        private static DiaDiem Map(DataRow r)
        {
            return new DiaDiem
            {
                MaDiaDiem   = DBHelper.ToInt(r["MaDiaDiem"]),
                MaDanhMuc   = DBHelper.ToInt(r["MaDanhMuc"]),
                TenDanhMuc  = DBHelper.ToStr(r.Table.Columns.Contains("TenDanhMuc") ? r["TenDanhMuc"] : null),
                TenDiaDiem  = DBHelper.ToStr(r["TenDiaDiem"]),
                MoTaNgan    = DBHelper.ToStr(r["MoTaNgan"]),
                MoTaChiTiet = DBHelper.ToStr(r["MoTaChiTiet"]),
                DiaChi      = DBHelper.ToStr(r["DiaChi"]),
                HinhAnhDai  = DBHelper.ToStr(r["HinhAnhDai"]),
                HinhAnhPhu  = DBHelper.ToStr(r["HinhAnhPhu"]),
                BanDo       = DBHelper.ToStr(r["BanDo"]),
                LuotXem     = DBHelper.ToInt(r["LuotXem"]),
                NoiBat      = DBHelper.ToBool(r["NoiBat"]),
                TrangThai   = DBHelper.ToBool(r["TrangThai"]),
                NgayTao     = DBHelper.ToDateTime(r["NgayTao"])
            };
        }

        public static List<DiaDiem> GetAll(bool? noiBat = null)
        {
            string sql = @"SELECT d.*, dm.TenDanhMuc FROM DiaDiem d
                           LEFT JOIN DanhMucDiaDiem dm ON d.MaDanhMuc = dm.MaDanhMuc
                           WHERE d.TrangThai = 1";
            if (noiBat.HasValue)
                sql += " AND d.NoiBat = " + (noiBat.Value ? "1" : "0");
            sql += " ORDER BY d.ThuTu, d.MaDiaDiem DESC";

            var list = new List<DiaDiem>();
            DataTable dt = DBHelper.GetDataTable(sql);
            foreach (DataRow r in dt.Rows)
                list.Add(Map(r));
            return list;
        }

        public static DiaDiem GetById(int id)
        {
            string sql = @"SELECT d.*, dm.TenDanhMuc FROM DiaDiem d
                           LEFT JOIN DanhMucDiaDiem dm ON d.MaDanhMuc = dm.MaDanhMuc
                           WHERE d.MaDiaDiem = @id";
            DataRow r = DBHelper.GetDataRow(sql, new[] { new SqlParameter("@id", id) });
            return r != null ? Map(r) : null;
        }

        public static List<DiaDiem> GetByDanhMuc(int maDanhMuc)
        {
            string sql = @"SELECT d.*, dm.TenDanhMuc FROM DiaDiem d
                           LEFT JOIN DanhMucDiaDiem dm ON d.MaDanhMuc = dm.MaDanhMuc
                           WHERE d.TrangThai = 1 AND d.MaDanhMuc = @maDanhMuc
                           ORDER BY d.ThuTu";
            var list = new List<DiaDiem>();
            DataTable dt = DBHelper.GetDataTable(sql, new[] { new SqlParameter("@maDanhMuc", maDanhMuc) });
            foreach (DataRow r in dt.Rows)
                list.Add(Map(r));
            return list;
        }

        public static void TangLuotXem(int id)
        {
            DBHelper.ExecuteNonQuery("UPDATE DiaDiem SET LuotXem = LuotXem + 1 WHERE MaDiaDiem = @id",
                new[] { new SqlParameter("@id", id) });
        }

        public static int Insert(DiaDiem d)
        {
            string sql = @"INSERT INTO DiaDiem (MaDanhMuc, TenDiaDiem, MoTaNgan, MoTaChiTiet,
                           DiaChi, HinhAnhDai, HinhAnhPhu, BanDo, ThuTu, NoiBat, TrangThai)
                           VALUES (@MaDanhMuc, @TenDiaDiem, @MoTaNgan, @MoTaChiTiet,
                           @DiaChi, @HinhAnhDai, @HinhAnhPhu, @BanDo, @ThuTu, @NoiBat, @TrangThai)";
            return DBHelper.ExecuteInsertReturnId(sql, BuildParams(d));
        }

        public static void Update(DiaDiem d)
        {
            string sql = @"UPDATE DiaDiem SET MaDanhMuc=@MaDanhMuc, TenDiaDiem=@TenDiaDiem,
                           MoTaNgan=@MoTaNgan, MoTaChiTiet=@MoTaChiTiet, DiaChi=@DiaChi,
                           HinhAnhDai=@HinhAnhDai, HinhAnhPhu=@HinhAnhPhu, BanDo=@BanDo,
                           ThuTu=@ThuTu, NoiBat=@NoiBat, TrangThai=@TrangThai
                           WHERE MaDiaDiem=@MaDiaDiem";
            var p = new List<SqlParameter>(BuildParams(d)) { new SqlParameter("@MaDiaDiem", d.MaDiaDiem) };
            DBHelper.ExecuteNonQuery(sql, p.ToArray());
        }

        public static void Delete(int id)
        {
            DBHelper.ExecuteNonQuery("DELETE FROM DiaDiem WHERE MaDiaDiem = @id",
                new[] { new SqlParameter("@id", id) });
        }

        private static SqlParameter[] BuildParams(DiaDiem d)
        {
            return new[]
            {
                new SqlParameter("@MaDanhMuc",   d.MaDanhMuc),
                new SqlParameter("@TenDiaDiem",  d.TenDiaDiem),
                new SqlParameter("@MoTaNgan",    d.MoTaNgan),
                new SqlParameter("@MoTaChiTiet", d.MoTaChiTiet),
                new SqlParameter("@DiaChi",      d.DiaChi),
                new SqlParameter("@HinhAnhDai",  d.HinhAnhDai),
                new SqlParameter("@HinhAnhPhu",  d.HinhAnhPhu),
                new SqlParameter("@BanDo",       d.BanDo),
                new SqlParameter("@ThuTu",       d.ThuTu),
                new SqlParameter("@NoiBat",      d.NoiBat),
                new SqlParameter("@TrangThai",   d.TrangThai)
            };
        }
    }
}
