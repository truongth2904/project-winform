using project_winform.CTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project_winform.DAL
{
    class SanPham_DB : DatabaseUtils
    {
        public static DataTable getAllDataSanPham()
        {
            DataTable dta = new DataTable();
            string sqlSV = $"select * from SANPHAM";
            SqlCommand sqlComandSV = new SqlCommand(sqlSV, connectDB);
            SqlDataAdapter sqlDataSV = new SqlDataAdapter(sqlComandSV);
            sqlDataSV.Fill(dta);

            if (dta.Rows.Count <= 0) return null;
            return dta;
        }
        public static bool insertDataSanPham(SanPham sanpham)
        {
            string query = "spThemDataOnSanPham";
            SqlCommand comand = new SqlCommand(query, connectDB);
            comand.CommandType = CommandType.StoredProcedure;
            comand.Parameters.Add(new SqlParameter("@MaSP", sanpham.MaSP));
            comand.Parameters.Add(new SqlParameter("@TenSP", sanpham.TenSP));
            comand.Parameters.Add(new SqlParameter("@SoLuong", sanpham.SoLuong));
            comand.Parameters.Add(new SqlParameter("@NgayNhap", sanpham.NgayNhap));
            comand.Parameters.Add(new SqlParameter("@GiaNhap", sanpham.GiaNhap));
            comand.Parameters.Add(new SqlParameter("@GiaBan", sanpham.GiaBan));
            comand.Parameters.Add(new SqlParameter("@GiamGia", sanpham.GiamGia));
            comand.Parameters.Add(new SqlParameter("@SoLuongBanRa", sanpham.SoLuongBanRa));
            comand.Parameters.Add(new SqlParameter("@LoaiSP", sanpham.LoaiSP));
            comand.Parameters.Add(new SqlParameter("@TrangThai", sanpham.TrangThai));
            int result = comand.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static bool deleteDataSanPham(string MaSP)
        {
            string query = "spDeleteSanPham";
            SqlCommand commad = new SqlCommand(query, connectDB);
            commad.CommandType = CommandType.StoredProcedure;
            commad.Parameters.Add(new SqlParameter("@MaSP", MaSP));
            int result = commad.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static bool changeDataSanPham(SanPham sanpham)
        {
            string query = "spUpdateSanPham";
            SqlCommand commd = new SqlCommand(query, connectDB);
            commd.CommandType = CommandType.StoredProcedure;
            commd.Parameters.Add(new SqlParameter("@MaSP", sanpham.MaSP));
            commd.Parameters.Add(new SqlParameter("@TenSP", sanpham.TenSP));
            commd.Parameters.Add(new SqlParameter("@GiaBan", sanpham.GiaBan));
            commd.Parameters.Add(new SqlParameter("@GiamGia", sanpham.GiamGia));
            commd.Parameters.Add(new SqlParameter("@LoaiSP", sanpham.LoaiSP));
            int result = commd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static bool insertSanPham(string MaSP, int SoLuong)
        {
            string query = "spNhapHangSanPham";
            SqlCommand commd = new SqlCommand(query, connectDB);
            commd.CommandType = CommandType.StoredProcedure;
            commd.Parameters.Add(new SqlParameter("@MaSP", MaSP));
            commd.Parameters.Add(new SqlParameter("@SoLuong", SoLuong));
            int result = commd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static DataTable searchOnMaSP(string MaSP)
        {
            DataTable dta = new DataTable();
            String query = "sp_SearchOnMaSP";
            SqlCommand sqlComandSV = new SqlCommand(query, connectDB);
            sqlComandSV.CommandType = CommandType.StoredProcedure;
            sqlComandSV.Parameters.Add(new SqlParameter("@MaSP", MaSP));
            SqlDataAdapter sqlDataSV = new SqlDataAdapter(sqlComandSV);
            sqlDataSV.Fill(dta);
            return dta;
        }
        public static bool updateSanPhamHoaDon(SanPham sp)
        {
            string query = "spUpdateSanPhamHoaDon";
            SqlCommand commd = new SqlCommand(query, connectDB);
            commd.CommandType = CommandType.StoredProcedure;
            commd.Parameters.Add(new SqlParameter("@MaSP", sp.MaSP));
            commd.Parameters.Add(new SqlParameter("@SoLuong", sp.SoLuong));
            commd.Parameters.Add(new SqlParameter("@SoLuongBanRa", sp.SoLuongBanRa));

            int result = commd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static DataTable getLoc(string LoaiSP)
        {
            string query = "spLocSanPham";
            DataTable table = new DataTable();
            SqlCommand commd = new SqlCommand(query, connectDB);
            commd.CommandType = CommandType.StoredProcedure;
            commd.Parameters.Add(new SqlParameter("@LoaiSP", LoaiSP));
            commd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(commd);
            adapter.Fill(table);
            return table;
        }
    }
}
