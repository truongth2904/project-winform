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
    class ThanhToan_DB : DatabaseUtils
    {
        public static DataTable getAllData()
        {
            DataTable dta = new DataTable();
            string sql = $"select * from THANHTOAN";
            SqlCommand sqlComand = new SqlCommand(sql, connectDB);
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlComand);
            sqlData.Fill(dta);

            if (dta.Rows.Count <= 0) return null;
            return dta;
        }
        public static bool insertThanhToan(ThanhToan thanhtoan)
        {
            string query = "sp_ThemPTTT";
            SqlCommand comand = new SqlCommand(query, connectDB);
            comand.CommandType = CommandType.StoredProcedure;
            comand.Parameters.Add(new SqlParameter("@MaTT", thanhtoan.MaTT1));
            comand.Parameters.Add(new SqlParameter("@TenTT", thanhtoan.TenTT1));
            int result = comand.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public static bool updateThanhToan(ThanhToan thanhtoan)
        {
            string query = "sp_SuaPTTT";
            SqlCommand comand = new SqlCommand(query, connectDB);
            comand.CommandType = CommandType.StoredProcedure;
            comand.Parameters.Add(new SqlParameter("@MaTT", thanhtoan.MaTT1));
            comand.Parameters.Add(new SqlParameter("@TenTT", thanhtoan.TenTT1));
            int result = comand.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
       
    }
}
