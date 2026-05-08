using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace BaDongTourism.App_Code
{
    public static class DBHelper
    {
        private static readonly string _connStr =
            ConfigurationManager.ConnectionStrings["BaDongDB"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }

        // Chuyen null thanh DBNull.Value cho tat ca parameters truoc khi truyen vao SQL
        private static void AddParamsSafe(SqlCommand cmd, SqlParameter[] parameters)
        {
            if (parameters == null) return;
            foreach (SqlParameter p in parameters)
            {
                if (p.Value == null) p.Value = DBNull.Value;
                cmd.Parameters.Add(p);
            }
        }

        // Tra ve DataTable
        public static DataTable GetDataTable(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                AddParamsSafe(cmd, parameters);
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
            }
            return dt;
        }

        // Tra ve DataRow dau tien
        public static DataRow GetDataRow(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = GetDataTable(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Tra ve gia tri don (scalar)
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                AddParamsSafe(cmd, parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        // Thuc thi INSERT/UPDATE/DELETE, tra ve so dong bi anh huong
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                AddParamsSafe(cmd, parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // INSERT va tra ve ID vua tao
        public static int ExecuteInsertReturnId(string query, SqlParameter[] parameters = null)
        {
            query += "; SELECT SCOPE_IDENTITY();";
            object result = ExecuteScalar(query, parameters);
            return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        // Helper: chuyen null/DBNull thanh string rong
        public static string ToStr(object val)
        {
            return (val == null || val == DBNull.Value) ? "" : val.ToString().Trim();
        }

        // Helper: chuyen null/DBNull thanh int
        public static int ToInt(object val, int defaultVal = 0)
        {
            if (val == null || val == DBNull.Value) return defaultVal;
            int r;
            return int.TryParse(val.ToString(), out r) ? r : defaultVal;
        }

        // Helper: chuyen null/DBNull thanh decimal
        public static decimal ToDecimal(object val, decimal defaultVal = 0)
        {
            if (val == null || val == DBNull.Value) return defaultVal;
            decimal r;
            return decimal.TryParse(val.ToString(), out r) ? r : defaultVal;
        }

        // Helper: chuyen null/DBNull thanh bool
        public static bool ToBool(object val, bool defaultVal = false)
        {
            if (val == null || val == DBNull.Value) return defaultVal;
            return val.ToString() == "1" || val.ToString().ToLower() == "true";
        }

        // Helper: chuyen null/DBNull thanh DateTime
        public static DateTime ToDateTime(object val)
        {
            if (val == null || val == DBNull.Value) return DateTime.MinValue;
            DateTime r;
            return DateTime.TryParse(val.ToString(), out r) ? r : DateTime.MinValue;
        }

        // Format tien VND
        public static string FormatMoney(decimal amount)
        {
            return String.Format("{0:N0}đ", amount);
        }
    }
}