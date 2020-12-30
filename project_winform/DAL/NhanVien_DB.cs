using project_winform.CTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace project_winform.DAL
{
    class NhanVien_DB : DatabaseUtils
    {
        public static DataTable getAllDataNhanVien()
        {
            DataTable dta = new DataTable();
            string sql = $"select * from NHANVIEN";
            SqlCommand sqlComand = new SqlCommand(sql, connectDB);
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlComand);
            sqlData.Fill(dta);

            if (dta.Rows.Count <= 0) return null;
            return dta;
        }
        public static bool InsertDataNhanVien(NhanVien nhanvien)
        {
            string query = "spInsertNhanVien";
            SqlCommand comd = new SqlCommand(query, connectDB);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("@_username", nhanvien.Username));
            comd.Parameters.Add(new SqlParameter("@_password", nhanvien.Password));
            comd.Parameters.Add(new SqlParameter("@MaNV", nhanvien.MaNV1));
            comd.Parameters.Add(new SqlParameter("@HoTen", nhanvien.HoTen1));
            comd.Parameters.Add(new SqlParameter("@NgaySinh", nhanvien.NgaySinh1));
            comd.Parameters.Add(new SqlParameter("@CMND", nhanvien.CMND1));
            comd.Parameters.Add(new SqlParameter("@SDT", nhanvien.SDT1));
            comd.Parameters.Add(new SqlParameter("@DiaChi", nhanvien.DiaChi1));
            comd.Parameters.Add(new SqlParameter("@SoLanDangNhap", nhanvien.SoLanDangNhap1));
            comd.Parameters.Add(new SqlParameter("@SoHoaDonDaLap", nhanvien.SoHoaDonDaLap1));
            comd.Parameters.Add(new SqlParameter("@LuongCB", nhanvien.LuongCB1));
            comd.Parameters.Add(new SqlParameter("@LoaiNV", nhanvien.LoaiNV1));
            comd.Parameters.Add(new SqlParameter("@TrangThai", nhanvien.TrangThai1));
            int result = comd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static bool UpdateDataNhanVien(NhanVien nhanvien)
        {
            string query = "spUpdateNhanVien";
            SqlCommand comd = new SqlCommand(query, connectDB);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("@_password", nhanvien.Password));
            comd.Parameters.Add(new SqlParameter("@MaNV", nhanvien.MaNV1));
            comd.Parameters.Add(new SqlParameter("@HoTen", nhanvien.HoTen1));
            comd.Parameters.Add(new SqlParameter("@SDT", nhanvien.SDT1));
            comd.Parameters.Add(new SqlParameter("@DiaChi", nhanvien.DiaChi1));
            comd.Parameters.Add(new SqlParameter("@LuongCB", nhanvien.LuongCB1));
            comd.Parameters.Add(new SqlParameter("@LoaiNV", nhanvien.LoaiNV1));
            comd.Parameters.Add(new SqlParameter("@TrangThai", nhanvien.TrangThai1));
            int result = comd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static bool DeleteDataNhanvien(string MaNV)
        {
            try
            {
                string query = "spDeleteNhanVien";
                SqlCommand comd = new SqlCommand(query, connectDB);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.Add(new SqlParameter("@MaNV", MaNV));
                int result = comd.ExecuteNonQuery();
                if (result == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;

        }
        public static DataTable searchOnMaNV(string MaNV)
        {
            DataTable dta = new DataTable();
            String query = "sp_SearchOnMaNV";
            SqlCommand sqlComandSV = new SqlCommand(query, connectDB);
            sqlComandSV.CommandType = CommandType.StoredProcedure;
            sqlComandSV.Parameters.Add(new SqlParameter("@MaNV", MaNV));
            SqlDataAdapter sqlDataSV = new SqlDataAdapter(sqlComandSV);
            sqlDataSV.Fill(dta);
            return dta;
        }
        public static bool UpdateNhanVienHoaDon(NhanVien nhanvien)
        {
            string query = "spUpdateNhanVienHoaDon";
            SqlCommand comd = new SqlCommand(query, connectDB);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("@MaNV", nhanvien.MaNV1));
            comd.Parameters.Add(new SqlParameter("@SoLanDangNhap", nhanvien.SoLanDangNhap1));
            comd.Parameters.Add(new SqlParameter("@SoHoaDonDaLap", nhanvien.SoHoaDonDaLap1));
         
            int result = comd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static DataTable getLoc(string loaiNV )
        {
            string query = "spLocNhanVien";
            DataTable table = new DataTable();
            SqlCommand commd = new SqlCommand(query, connectDB);
            commd.CommandType = CommandType.StoredProcedure;
            commd.Parameters.Add(new SqlParameter("@LoaiNV", loaiNV));
            commd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(commd);
            adapter.Fill(table);
            return table;
        }
    }
}
