using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BaDongTourism.App_Code;
using BaDongTourism.Models;

namespace BaDongTourism.DAL
{
    public static class GalleryDAL
    {
        private static Gallery Map(DataRow r)
        {
            return new Gallery
            {
                MaAnh       = DBHelper.ToInt(r["MaAnh"]),
                TieuDe      = DBHelper.ToStr(r["TieuDe"]),
                MoTa        = DBHelper.ToStr(r["MoTa"]),
                DuongDanAnh = DBHelper.ToStr(r["DuongDanAnh"]),
                DanhMuc     = DBHelper.ToStr(r["DanhMuc"]),
                ThuTu       = DBHelper.ToInt(r["ThuTu"]),
                TrangThai   = DBHelper.ToBool(r["TrangThai"]),
                NgayTao     = DBHelper.ToDateTime(r["NgayTao"])
            };
        }

        public static List<Gallery> GetAll()
        {
            string sql = "SELECT * FROM Gallery WHERE TrangThai = 1 ORDER BY ThuTu, MaAnh";
            var list = new List<Gallery>();
            foreach (DataRow r in DBHelper.GetDataTable(sql).Rows)
                list.Add(Map(r));
            return list;
        }

        public static int Insert(Gallery g)
        {
            string sql = @"INSERT INTO Gallery (TieuDe, MoTa, DuongDanAnh, DanhMuc, ThuTu, TrangThai)
                           VALUES (@TieuDe, @MoTa, @DuongDanAnh, @DanhMuc, @ThuTu, @TrangThai)";
            return DBHelper.ExecuteInsertReturnId(sql, new[]
            {
                new SqlParameter("@TieuDe",      (object)(g.TieuDe      ?? "") ),
                new SqlParameter("@MoTa",        (object)(g.MoTa        ?? "") ),
                new SqlParameter("@DuongDanAnh", (object)(g.DuongDanAnh ?? "") ),
                new SqlParameter("@DanhMuc",     (object)(g.DanhMuc     ?? "") ),
                new SqlParameter("@ThuTu",       g.ThuTu),
                new SqlParameter("@TrangThai",   g.TrangThai)
            });
        }

        public static void Delete(int id)
        {
            DBHelper.ExecuteNonQuery("DELETE FROM Gallery WHERE MaAnh = @id",
                new[] { new SqlParameter("@id", id) });
        }
    }
}
