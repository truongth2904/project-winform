using project_winform.CTO;
using project_winform.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_winform.BUS
{
    class HoaDon_BUS
    {
        public static DataTable getAllData()
        {
            return HoaDon_DB.getAllDataHoaDon();
        }
        public static DataTable SearchOnMaHD(string MaHD)
        {
            return HoaDon_DB.searchOnMaHD(MaHD);
        }
        public static string createMaHD()
        {
            if (getAllData() == null)
            {
                return $"HD00";
            }
            else
            {
                return $"HD0{getAllData().Rows.Count}";
            }

        }
        public static bool ThemHD(HoaDon hoadon)
        {
            return HoaDon_DB.addHoaDon(hoadon);
        }
        public static LinkedList<HoaDon> getAllHoaDon()
        {
            LinkedList<HoaDon> list = new LinkedList<HoaDon>();
            DataTable datas = HoaDon_DB.getAllDataHoaDon();
            if (datas != null)
            {
                for (int i = 0; i < datas.Rows.Count; i++)
                {
                    string MaHD = datas.Rows[i].ItemArray[0].ToString();
                    string MaNV = datas.Rows[i].ItemArray[1].ToString();
                    string MaKH = datas.Rows[i].ItemArray[2].ToString();
                    DateTime NgayLap = Convert.ToDateTime(datas.Rows[i].ItemArray[3].ToString());
                    string GhiChu = datas.Rows[i].ItemArray[4].ToString();
                    int TrangThai = Convert.ToInt32(datas.Rows[i].ItemArray[5].ToString());
                    double GiaTriHD = Convert.ToDouble(datas.Rows[i].ItemArray[6].ToString());
                    list.AddLast(new HoaDon(MaHD, MaNV, MaKH, NgayLap, GhiChu, TrangThai, GiaTriHD));
                }
            }
            return list;
        }
        public static DataTable LocHoaDon(DateTime ngaylap)
        {
            return HoaDon_DB.getLoc(ngaylap);
        }
        public static HoaDon SearchHD(string MaHD)
        {
            for(LinkedListNode<HoaDon> p = getAllHoaDon().First; p != null; p = p.Next)
            {
                if (p.Value.MaHD1 == MaHD)
                {
                    return p.Value;
                }
            }
            return null;
        }
        public static bool XoaHoaDon(string MaHD)
        {
            if (HoaDon_DB.XoaHoaDon(MaHD) == 1)
            {
                return true;
            }
            return false;
        }
    }
}