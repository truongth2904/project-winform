using project_winform.CTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace project_winform.DAL
{
    class KhachHang_DB : DatabaseUtils
    {
        public static DataTable getAllDataKhachHang()
        {
            DataTable dta = new DataTable();
            string sql = $"select * from KHACHHANG";
            SqlCommand sqlComand = new SqlCommand(sql, connectDB);
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlComand);
            sqlData.Fill(dta);

            if (dta.Rows.Count <= 0) return null;
            return dta;
        }
        public static bool InsertDataKhachHang(KhachHang khachhang)
        {
            string query = "spInsertDataKhachHang";
            SqlCommand comd = new SqlCommand(query, connectDB);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("@_username", khachhang.Username));
            comd.Parameters.Add(new SqlParameter("@_password", khachhang.Password));
            comd.Parameters.Add(new SqlParameter("@MaKH", khachhang.MaKH1));
            comd.Parameters.Add(new SqlParameter("@HoTen", khachhang.HoTen1));
            comd.Parameters.Add(new SqlParameter("@NgaySinh", khachhang.NgaySinh1));
            comd.Parameters.Add(new SqlParameter("@CMND", khachhang.CMND1));
            comd.Parameters.Add(new SqlParameter("@SDT", khachhang.SDT1));
            comd.Parameters.Add(new SqlParameter("@DiaChi", khachhang.DiaChi1));
            comd.Parameters.Add(new SqlParameter("@Diem", khachhang.Diem1));
            comd.Parameters.Add(new SqlParameter("@SoLanDangNhap", khachhang.SoLanDangNhap1));
            comd.Parameters.Add(new SqlParameter("@SoTienDaChi", khachhang.SoTienDaChi1));
            comd.Parameters.Add(new SqlParameter("@TongDonDaDat", khachhang.TongDonDaDat1));
            comd.Parameters.Add(new SqlParameter("@LoaiKH", khachhang.LoaiKH1));
            comd.Parameters.Add(new SqlParameter("@TrangThai", khachhang.TrangThai1));

            int result = comd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static bool UpdateDataKhachHang(KhachHang khachhang)
        {
            string query = "spUpdateDataKhachHang";
            SqlCommand comd = new SqlCommand(query, connectDB);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("@_password", khachhang.Password));
            comd.Parameters.Add(new SqlParameter("@MaKH", khachhang.MaKH1));
            comd.Parameters.Add(new SqlParameter("@HoTen", khachhang.HoTen1));
            comd.Parameters.Add(new SqlParameter("@NgaySinh", khachhang.NgaySinh1));
            comd.Parameters.Add(new SqlParameter("@CMND", khachhang.CMND1));
            comd.Parameters.Add(new SqlParameter("@SDT", khachhang.SDT1));
            comd.Parameters.Add(new SqlParameter("@DiaChi", khachhang.DiaChi1));
            comd.Parameters.Add(new SqlParameter("@LoaiKH", khachhang.LoaiKH1));
            comd.Parameters.Add(new SqlParameter("@TrangThai", khachhang.TrangThai1));
            int result = comd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static bool DeleteDataKhachHang(string MaKH)
        {
            string query = "spDeleteDataKhachHang";
            SqlCommand comd = new SqlCommand(query, connectDB);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("@MaKH", MaKH));
            int result = comd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static DataTable searchOnMaKH(string MaKH)
        {
            DataTable dta = new DataTable();
            String query = "sp_SearchOnMaKH";
            SqlCommand sqlComandSV = new SqlCommand(query, connectDB);
            sqlComandSV.CommandType = CommandType.StoredProcedure;
            sqlComandSV.Parameters.Add(new SqlParameter("@MaKH", MaKH));
            SqlDataAdapter sqlDataSV = new SqlDataAdapter(sqlComandSV);
            sqlDataSV.Fill(dta);
            return dta;
        }
        public static bool UpdateHoaDonKhachHang(KhachHang kh)
        {
            string query = "spUpdateKhachHangHoaDon";
            SqlCommand comd = new SqlCommand(query, connectDB);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("@MaKH", kh.MaKH1));
            comd.Parameters.Add(new SqlParameter("@Diem", kh.Diem1));
            comd.Parameters.Add(new SqlParameter("@SoLanDangNhap", kh.SoLanDangNhap1));
            comd.Parameters.Add(new SqlParameter("@SoTienDaChi", kh.SoTienDaChi1));
            comd.Parameters.Add(new SqlParameter("@TongDonDaDat", kh.TongDonDaDat1));
            comd.Parameters.Add(new SqlParameter("@LoaiKH", kh.LoaiKH1));
            int result = comd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static DataTable getLoc(string loaiKH)
        {
            string query = "spLocKhachHang";
            DataTable table = new DataTable();
            SqlCommand commd = new SqlCommand(query, connectDB);
            commd.CommandType = CommandType.StoredProcedure;
            commd.Parameters.Add(new SqlParameter("@LoaiKH", loaiKH));
            commd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(commd);
            adapter.Fill(table);
            return table;
        }
    }
}
