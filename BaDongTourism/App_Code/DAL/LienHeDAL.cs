using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BaDongTourism.App_Code;
using BaDongTourism.Models;

namespace BaDongTourism.DAL
{
    public static class LienHeDAL
    {
        private static LienHe Map(DataRow r)
        {
            return new LienHe
            {
                MaLienHe   = DBHelper.ToInt(r["MaLienHe"]),
                HoTen      = DBHelper.ToStr(r["HoTen"]),
                Email      = DBHelper.ToStr(r["Email"]),
                DienThoai  = DBHelper.ToStr(r["DienThoai"]),
                ChuDe      = DBHelper.ToStr(r["ChuDe"]),
                NoiDung    = DBHelper.ToStr(r["NoiDung"]),
                DaDoc      = DBHelper.ToBool(r["DaDoc"]),
                NgayGui    = DBHelper.ToDateTime(r["NgayGui"]),
                PhanHoi    = r.Table.Columns.Contains("PhanHoi")     ? DBHelper.ToStr(r["PhanHoi"])          : "",
                NgayPhanHoi = r.Table.Columns.Contains("NgayPhanHoi") ? DBHelper.ToDateTime(r["NgayPhanHoi"]) : DateTime.MinValue
            };
        }

        public static List<LienHe> GetAll()
        {
            string sql = "SELECT * FROM LienHe ORDER BY NgayGui DESC";
            var list = new List<LienHe>();
            foreach (DataRow r in DBHelper.GetDataTable(sql).Rows)
                list.Add(Map(r));
            return list;
        }

        public static int SoTinChuaDoc()
        {
            object result = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM LienHe WHERE DaDoc = 0");
            return DBHelper.ToInt(result);
        }

        public static int Insert(LienHe lh)
        {
            string sql = @"INSERT INTO LienHe (HoTen, Email, DienThoai, ChuDe, NoiDung)
                           VALUES (@HoTen, @Email, @DienThoai, @ChuDe, @NoiDung)";
            return DBHelper.ExecuteInsertReturnId(sql, new[]
            {
                new SqlParameter("@HoTen",     lh.HoTen),
                new SqlParameter("@Email",     lh.Email),
                new SqlParameter("@DienThoai", lh.DienThoai),
                new SqlParameter("@ChuDe",     lh.ChuDe),
                new SqlParameter("@NoiDung",   lh.NoiDung)
            });
        }

        public static LienHe GetById(int id)
        {
            string sql = "SELECT * FROM LienHe WHERE MaLienHe = @id";
            DataRow r = DBHelper.GetDataRow(sql, new[] { new SqlParameter("@id", id) });
            return r != null ? Map(r) : null;
        }

        public static void DanhDauDaDoc(int id)
        {
            DBHelper.ExecuteNonQuery("UPDATE LienHe SET DaDoc = 1 WHERE MaLienHe = @id",
                new[] { new SqlParameter("@id", id) });
        }

        public static void LuuPhanHoi(int id, string phanHoi)
        {
            string sql = "UPDATE LienHe SET PhanHoi = @ph, NgayPhanHoi = GETDATE(), DaDoc = 1 WHERE MaLienHe = @id";
            object phVal = string.IsNullOrEmpty(phanHoi) ? (object)DBNull.Value : (object)phanHoi;
            DBHelper.ExecuteNonQuery(sql, new[]
            {
                new SqlParameter("@ph",  phVal),
                new SqlParameter("@id",  id)
            });
        }

        public static void Delete(int id)
        {
            DBHelper.ExecuteNonQuery("DELETE FROM LienHe WHERE MaLienHe = @id",
                new[] { new SqlParameter("@id", id) });
        }
    }
}
