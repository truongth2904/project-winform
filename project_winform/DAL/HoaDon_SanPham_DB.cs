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
    class HoaDon_SanPham_DB : DatabaseUtils
    {
        public static DataTable getAllData()
        {
            DataTable dta = new DataTable();
            string sql = $"select * from HOADON_SANPHAM";
            SqlCommand sqlComand = new SqlCommand(sql, connectDB);
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlComand);
            sqlData.Fill(dta);
            if (dta.Rows.Count <= 0) return null;
            return dta;
        }
        public static LinkedList<HoaDon_SanPham> getAll()
        {
            LinkedList<HoaDon_SanPham> list = new LinkedList<HoaDon_SanPham>();
            DataTable datas = getAllData();
            if (datas != null)
            {
                for (int i = 0; i < datas.Rows.Count; i++)
                {
                    string MaSP = datas.Rows[i].ItemArray[0].ToString();
                    string MaHD = datas.Rows[i].ItemArray[1].ToString();
                    int SoLuong = Convert.ToInt32(datas.Rows[i].ItemArray[2].ToString());
                    list.AddLast(new HoaDon_SanPham(MaSP, MaHD, SoLuong));
                }
            }
            return list;
        }
        public static bool addHoaDon_SanPham(HoaDon_SanPham sp)
        {
            bool check = false; int soluong = 0;
            for (LinkedListNode<HoaDon_SanPham> p = getAll().First; p != null; p = p.Next)
            {
                if (p.Value.MaSP1 == sp.MaSP1 && p.Value.MaHD1 == sp.MaHD1)
                {
                    check = true;
                    soluong = p.Value.SoLuong1;
                }
            }
            if (check == true)
            {
                sp.SoLuong1 += soluong;
                string query = "sp_UpdateSanPhamHoaDon";
                SqlCommand comd = new SqlCommand(query, connectDB);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.Add(new SqlParameter("@MaSP", sp.MaSP1));
                comd.Parameters.Add(new SqlParameter("@MaHD", sp.MaHD1));
                comd.Parameters.Add(new SqlParameter("@SoLuong", sp.SoLuong1));

                int result = comd.ExecuteNonQuery();
                if (result == 1)
                {
                    return true;
                }
            }
            else
            {
                string query = "sp_ThemSanPhamHoaDon";
                SqlCommand comd = new SqlCommand(query, connectDB);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.Add(new SqlParameter("@MaSP", sp.MaSP1));
                comd.Parameters.Add(new SqlParameter("@MaHD", sp.MaHD1));
                comd.Parameters.Add(new SqlParameter("@SoLuong", sp.SoLuong1));

                int result = comd.ExecuteNonQuery();
                if (result == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public static LinkedList<HoaDon_SanPham> getAllSanPhamInHoaDon(string MaHD)
        {
            LinkedList<HoaDon_SanPham> listSP = new LinkedList<HoaDon_SanPham>();
            for (LinkedListNode<HoaDon_SanPham> p = getAll().First; p != null; p = p.Next)
            {
                if (p.Value.MaHD1 == MaHD)
                {
                    listSP.AddLast(p.Value);
                }
            }
            return listSP;
        }
    }
}
