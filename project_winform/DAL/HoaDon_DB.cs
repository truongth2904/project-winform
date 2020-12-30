using project_winform.CTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_winform.DAL
{
    class HoaDon_DB : DatabaseUtils
    {
        public static DataTable getAllDataHoaDon()
        {
            DataTable dta = new DataTable();
            string sql = $"select * from HOADON";
            SqlCommand sqlComand = new SqlCommand(sql, connectDB);
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlComand);
            sqlData.Fill(dta);

            if (dta.Rows.Count <= 0) return null;
            return dta;
        }
        public static DataTable searchOnMaHD(string MaHD)
        {
            DataTable dta = new DataTable();
            String query = "sp_SearchOnMaHD";
            SqlCommand sqlComandSV = new SqlCommand(query, connectDB);
            sqlComandSV.CommandType = CommandType.StoredProcedure;
            sqlComandSV.Parameters.Add(new SqlParameter("@MaHD", MaHD));
            SqlDataAdapter sqlDataSV = new SqlDataAdapter(sqlComandSV);
            sqlDataSV.Fill(dta);
            return dta;
        }
        public static bool addHoaDon(HoaDon hoadon)
        {

            string query = "sp_ThemHoaDon";
            SqlCommand comd = new SqlCommand(query, connectDB);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("@MaHD", hoadon.MaHD1));
            comd.Parameters.Add(new SqlParameter("@MaNV", hoadon.MaNV1));
            comd.Parameters.Add(new SqlParameter("@MaKH", hoadon.MaKH1));
            comd.Parameters.Add(new SqlParameter("@NgayLap", hoadon.NgayLap1));
            comd.Parameters.Add(new SqlParameter("@GhiChu", hoadon.GhiChu1));
            comd.Parameters.Add(new SqlParameter("@TrangThai", hoadon.TrangThai1));
            comd.Parameters.Add(new SqlParameter("@GiaTriHD", hoadon.GiaTriHD1));

            int result = comd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static DataTable getLoc(DateTime ngaylap)
        {
            string query = "spLocHoaDon";
            DataTable table = new DataTable();
            SqlCommand commd = new SqlCommand(query, connectDB);
            commd.CommandType = CommandType.StoredProcedure;
            commd.Parameters.Add(new SqlParameter("@NgayLap", ngaylap));
            commd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(commd);
            adapter.Fill(table);
            return table;
        }
        public static int XoaHoaDon(string MaHD)
        {
            string query = "spXoaHoaDon";
            SqlCommand commd = new SqlCommand(query, connectDB);
            commd.CommandType = CommandType.StoredProcedure;
            commd.Parameters.Add(new SqlParameter("@MaHD", MaHD));
            return commd.ExecuteNonQuery();
        }
    }
}
