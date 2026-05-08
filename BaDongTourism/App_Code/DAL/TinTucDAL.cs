using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BaDongTourism.App_Code;
using BaDongTourism.Models;

namespace BaDongTourism.DAL
{
    public static class TinTucDAL
    {
        private static TinTuc Map(DataRow r)
        {
            return new TinTuc
            {
                MaTinTuc   = DBHelper.ToInt(r["MaTinTuc"]),
                MaDanhMuc  = DBHelper.ToInt(r["MaDanhMuc"]),
                TenDanhMuc = DBHelper.ToStr(r.Table.Columns.Contains("TenDanhMuc") ? r["TenDanhMuc"] : null),
                MaTK       = DBHelper.ToInt(r["MaTK"]),
                TenTacGia  = DBHelper.ToStr(r.Table.Columns.Contains("HoTen") ? r["HoTen"] : null),
                TieuDe     = DBHelper.ToStr(r["TieuDe"]),
                TomTat     = DBHelper.ToStr(r["TomTat"]),
                NoiDung    = DBHelper.ToStr(r["NoiDung"]),
                HinhAnhDai = DBHelper.ToStr(r["HinhAnhDai"]),
                LuotXem    = DBHelper.ToInt(r["LuotXem"]),
                NoiBat     = DBHelper.ToBool(r["NoiBat"]),
                TrangThai  = DBHelper.ToBool(r["TrangThai"]),
                NgayDang   = DBHelper.ToDateTime(r["NgayDang"])
            };
        }

        public static List<TinTuc> GetAll(int? maDanhMuc = null, bool? noiBat = null, int top = 0)
        {
            string sql = @"SELECT t.*, dm.TenDanhMuc, tk.HoTen FROM TinTuc t
                           LEFT JOIN DanhMucTinTuc dm ON t.MaDanhMuc = dm.MaDanhMuc
                           LEFT JOIN TaiKhoan tk ON t.MaTK = tk.MaTK
                           WHERE t.TrangThai = 1";
            if (maDanhMuc.HasValue) sql += " AND t.MaDanhMuc = " + maDanhMuc.Value;
            if (noiBat.HasValue)   sql += " AND t.NoiBat = " + (noiBat.Value ? "1" : "0");
            sql += " ORDER BY t.NgayDang DESC";
            if (top > 0) sql = sql.Replace("SELECT t.*", "SELECT TOP " + top + " t.*");

            var list = new List<TinTuc>();
            foreach (DataRow r in DBHelper.GetDataTable(sql).Rows)
                list.Add(Map(r));
            return list;
        }

        public static TinTuc GetById(int id)
        {
            string sql = @"SELECT t.*, dm.TenDanhMuc, tk.HoTen FROM TinTuc t
                           LEFT JOIN DanhMucTinTuc dm ON t.MaDanhMuc = dm.MaDanhMuc
                           LEFT JOIN TaiKhoan tk ON t.MaTK = tk.MaTK
                           WHERE t.MaTinTuc = @id";
            DataRow r = DBHelper.GetDataRow(sql, new[] { new SqlParameter("@id", id) });
            return r != null ? Map(r) : null;
        }

        public static void TangLuotXem(int id)
        {
            DBHelper.ExecuteNonQuery("UPDATE TinTuc SET LuotXem = LuotXem + 1 WHERE MaTinTuc = @id",
                new[] { new SqlParameter("@id", id) });
        }

        public static int Insert(TinTuc t)
        {
            string sql = @"INSERT INTO TinTuc (MaDanhMuc, MaTK, TieuDe, TomTat, NoiDung,
                           HinhAnhDai, NoiBat, TrangThai)
                           VALUES (@MaDanhMuc, @MaTK, @TieuDe, @TomTat, @NoiDung,
                           @HinhAnhDai, @NoiBat, @TrangThai)";
            return DBHelper.ExecuteInsertReturnId(sql, BuildParams(t));
        }

        public static void Update(TinTuc t)
        {
            string sql = @"UPDATE TinTuc SET MaDanhMuc=@MaDanhMuc, MaTK=@MaTK, TieuDe=@TieuDe,
                           TomTat=@TomTat, NoiDung=@NoiDung, HinhAnhDai=@HinhAnhDai,
                           NoiBat=@NoiBat, TrangThai=@TrangThai WHERE MaTinTuc=@MaTinTuc";
            var p = new List<SqlParameter>(BuildParams(t)) { new SqlParameter("@MaTinTuc", t.MaTinTuc) };
            DBHelper.ExecuteNonQuery(sql, p.ToArray());
        }

        public static void Delete(int id)
        {
            DBHelper.ExecuteNonQuery("DELETE FROM TinTuc WHERE MaTinTuc = @id",
                new[] { new SqlParameter("@id", id) });
        }

        private static SqlParameter[] BuildParams(TinTuc t)
        {
            return new[]
            {
                new SqlParameter("@MaDanhMuc",  t.MaDanhMuc),
                new SqlParameter("@MaTK",       t.MaTK),
                new SqlParameter("@TieuDe",     t.TieuDe),
                new SqlParameter("@TomTat",     t.TomTat),
                new SqlParameter("@NoiDung",    t.NoiDung),
                new SqlParameter("@HinhAnhDai", t.HinhAnhDai),
                new SqlParameter("@NoiBat",     t.NoiBat),
                new SqlParameter("@TrangThai",  t.TrangThai)
            };
        }
    }
}
