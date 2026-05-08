using System;
using System.Data;
using System.Data.SqlClient;
using BaDongTourism.App_Code;

namespace BaDongTourism.DAL
{
    public static class TaiKhoanDAL
    {
        public static DataRow DangNhap(string tenDangNhap, string matKhau)
        {
            string sql = @"SELECT * FROM TaiKhoan
                           WHERE TenDangNhap = @TenDangNhap
                             AND MatKhau = @MatKhau
                             AND TrangThai = 1";
            return DBHelper.GetDataRow(sql, new[]
            {
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhau",     matKhau)
            });
        }

        public static void DoiMatKhau(int maTK, string matKhauMoi)
        {
            DBHelper.ExecuteNonQuery(
                "UPDATE TaiKhoan SET MatKhau = @mk WHERE MaTK = @id",
                new[]
                {
                    new SqlParameter("@mk", matKhauMoi),
                    new SqlParameter("@id", maTK)
                });
        }
    }
}
