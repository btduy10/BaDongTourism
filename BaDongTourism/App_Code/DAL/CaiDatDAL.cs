using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BaDongTourism.App_Code;

namespace BaDongTourism.DAL
{
    public static class CaiDatDAL
    {
        // Lay tat ca cai dat theo nhom
        public static Dictionary<string, string> GetByNhom(string nhom)
        {
            string sql = "SELECT Khoa, GiaTri FROM CaiDat WHERE NhomCaiDat=@nhom";
            DataTable dt = DBHelper.GetDataTable(sql, new SqlParameter[] {
                new SqlParameter("@nhom", nhom)
            });
            var dict = new Dictionary<string, string>();
            foreach (DataRow r in dt.Rows)
                dict[DBHelper.ToStr(r["Khoa"])] = DBHelper.ToStr(r["GiaTri"]);
            return dict;
        }

        // Lay 1 gia tri theo khoa
        public static string Get(string khoa, string macDinh = "")
        {
            string sql = "SELECT GiaTri FROM CaiDat WHERE Khoa=@khoa";
            object val = DBHelper.ExecuteScalar(sql, new SqlParameter[] {
                new SqlParameter("@khoa", khoa)
            });
            if (val == null || val == System.DBNull.Value) return macDinh;
            string result = val.ToString();
            return result == "" ? macDinh : result;
        }

        // Luu (UPSERT) 1 cap khoa-gia tri
        public static void Set(string khoa, string giaTri, string nhom = "General")
        {
            string sql = @"
                IF EXISTS (SELECT 1 FROM CaiDat WHERE Khoa=@khoa)
                    UPDATE CaiDat SET GiaTri=@giaTri WHERE Khoa=@khoa
                ELSE
                    INSERT INTO CaiDat (Khoa, GiaTri, NhomCaiDat) VALUES (@khoa, @giaTri, @nhom)";
            DBHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("@khoa",   khoa),
                new SqlParameter("@giaTri", giaTri ?? ""),
                new SqlParameter("@nhom",   nhom)
            });
        }

        // Luu nhieu cap khoa-gia tri cung luc
        public static void SetMany(Dictionary<string, string> data, string nhom = "General")
        {
            foreach (var kv in data)
                Set(kv.Key, kv.Value, nhom);
        }
    }
}
