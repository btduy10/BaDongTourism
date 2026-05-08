using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BaDongTourism.App_Code;
using BaDongTourism.Models;

namespace BaDongTourism.DAL
{
    public static class BannerDAL
    {
        public static List<Banner> GetAll(bool chiActive = false)
        {
            string sql = chiActive
                ? "SELECT * FROM Banner WHERE TrangThai=1 ORDER BY ThuTu ASC"
                : "SELECT * FROM Banner ORDER BY ThuTu ASC";
            DataTable dt = DBHelper.GetDataTable(sql);
            var list = new List<Banner>();
            foreach (DataRow r in dt.Rows)
                list.Add(Map(r));
            return list;
        }

        public static Banner GetById(int id)
        {
            string sql = "SELECT * FROM Banner WHERE MaBanner=@id";
            DataRow r = DBHelper.GetDataRow(sql, new SqlParameter[] {
                new SqlParameter("@id", id)
            });
            return r != null ? Map(r) : null;
        }

        public static int Insert(Banner b)
        {
            string sql = @"INSERT INTO Banner (TieuDe,MoTa,HinhAnh,LienKet,ThuTu,TrangThai)
                           VALUES (@TieuDe,@MoTa,@HinhAnh,@LienKet,@ThuTu,@TrangThai)";
            return DBHelper.ExecuteNonQuery(sql, Params(b));
        }

        public static int Update(Banner b)
        {
            string sql = @"UPDATE Banner SET TieuDe=@TieuDe, MoTa=@MoTa, HinhAnh=@HinhAnh,
                           LienKet=@LienKet, ThuTu=@ThuTu, TrangThai=@TrangThai
                           WHERE MaBanner=@MaBanner";
            var p = Params(b);
            Array.Resize(ref p, p.Length + 1);
            p[p.Length - 1] = new SqlParameter("@MaBanner", b.MaBanner);
            return DBHelper.ExecuteNonQuery(sql, p);
        }

        public static int Delete(int id)
        {
            return DBHelper.ExecuteNonQuery("DELETE FROM Banner WHERE MaBanner=@id",
                new SqlParameter[] { new SqlParameter("@id", id) });
        }

        private static SqlParameter[] Params(Banner b)
        {
            return new SqlParameter[] {
                new SqlParameter("@TieuDe",    b.TieuDe    ?? ""),
                new SqlParameter("@MoTa",      b.MoTa      ?? ""),
                new SqlParameter("@HinhAnh",   b.HinhAnh   ?? ""),
                new SqlParameter("@LienKet",   b.LienKet   ?? ""),
                new SqlParameter("@ThuTu",     b.ThuTu),
                new SqlParameter("@TrangThai", b.TrangThai)
            };
        }

        private static Banner Map(DataRow r)
        {
            return new Banner
            {
                MaBanner  = DBHelper.ToInt(r["MaBanner"]),
                TieuDe    = DBHelper.ToStr(r["TieuDe"]),
                MoTa      = DBHelper.ToStr(r["MoTa"]),
                HinhAnh   = DBHelper.ToStr(r["HinhAnh"]),
                LienKet   = DBHelper.ToStr(r["LienKet"]),
                ThuTu     = DBHelper.ToInt(r["ThuTu"]),
                TrangThai = DBHelper.ToBool(r["TrangThai"])
            };
        }
    }
}
