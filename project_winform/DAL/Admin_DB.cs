using project_winform.CTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace project_winform.DAL
{
    class Admin_DB : DatabaseUtils
    {
        public static DataTable getDataTable()
        {
            DataTable dta = new DataTable();
            String sqlSV = $"select * from ADMIN_";
            SqlCommand sqlComandSV = new SqlCommand(sqlSV, connectDB);
            SqlDataAdapter sqlDataSV = new SqlDataAdapter(sqlComandSV);
            sqlDataSV.Fill(dta);
            if (dta.Rows.Count <= 0) return null;
            return dta;
        }

        public static bool changeInFoAdmin(Admin admin)
        {
            string query = "spChangeInFoAdmin";
            SqlCommand comand = new SqlCommand(query, connectDB);
            comand.CommandType = CommandType.StoredProcedure;
            comand.Parameters.Add(new SqlParameter("@MaAD", admin.MaAD1));
            comand.Parameters.Add(new SqlParameter("@_password", admin.Password));
            comand.Parameters.Add(new SqlParameter("@HoTen", admin.HoTen1));
            comand.Parameters.Add(new SqlParameter("@NgaySinh", admin.NgaySinh1));
            comand.Parameters.Add(new SqlParameter("@CMND", admin.CMND1));
            comand.Parameters.Add(new SqlParameter("@SDT", admin.SDT1));
            comand.Parameters.Add(new SqlParameter("@DiaChi", admin.DiaChi1));
            comand.Parameters.Add(new SqlParameter("@TrangThai", admin.TrangThai1));

            int re = comand.ExecuteNonQuery();
            if (re == 1)
            {
                return true;
            }
            return false;
        }

    }
}
