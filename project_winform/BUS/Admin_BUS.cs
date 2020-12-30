using project_winform.CTO;
using project_winform.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace project_winform.BUS
{
    class Admin_BUS
    {
        public static LinkedList<Admin> getAllAdmin()
        {
            LinkedList<Admin> list = new LinkedList<Admin>();
            DataTable datas = Admin_DB.getDataTable();
            for (int i = 0; i < datas.Rows.Count; i++)
            {
                string _username = datas.Rows[i].ItemArray[0].ToString();
                string _password = datas.Rows[i].ItemArray[1].ToString();
                string MaAD = datas.Rows[i].ItemArray[2].ToString();
                string HoTen = datas.Rows[i].ItemArray[3].ToString();
                DateTime NgaySinh = Convert.ToDateTime(datas.Rows[i].ItemArray[4].ToString());
                string CMND = datas.Rows[i].ItemArray[5].ToString();
                string SDT = datas.Rows[i].ItemArray[6].ToString();
                string DiaChi = datas.Rows[i].ItemArray[7].ToString();
                int TrangThai = Convert.ToInt32(datas.Rows[i].ItemArray[8].ToString());
                list.AddLast(new Admin(_username, _password, MaAD, HoTen, NgaySinh, CMND, SDT, DiaChi, TrangThai));
            }
            return list;
        }
        public static bool changeInFo(Admin admin)
        {
            return Admin_DB.changeInFoAdmin(admin);
        }
    }
}
