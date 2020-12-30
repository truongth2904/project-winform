using project_winform.CTO;
using project_winform.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace project_winform.BUS
{
    class KhachHang_BUS
    {
        public static LinkedList<KhachHang> getAllKhachHang()
        {
            LinkedList<KhachHang> list = new LinkedList<KhachHang>();
            DataTable datas = KhachHang_DB.getAllDataKhachHang();
            for (int i = 0; i < datas.Rows.Count; i++)
            {
                string _username = datas.Rows[i].ItemArray[0].ToString();
                string _password = datas.Rows[i].ItemArray[1].ToString();
                string MaKH = datas.Rows[i].ItemArray[2].ToString();
                string HoTen = datas.Rows[i].ItemArray[3].ToString();
                DateTime NgaySinh = Convert.ToDateTime(datas.Rows[i].ItemArray[4].ToString());
                string CMND = datas.Rows[i].ItemArray[5].ToString();
                string SDT = datas.Rows[i].ItemArray[6].ToString();
                string DiaChi = datas.Rows[i].ItemArray[7].ToString();
                int Diem = Convert.ToInt32(datas.Rows[i].ItemArray[8].ToString());
                int SoLanDangNhap = Convert.ToInt32(datas.Rows[i].ItemArray[9].ToString());
                double SoTienDaChi = Convert.ToDouble(datas.Rows[i].ItemArray[10].ToString());
                int TongDonDaDat = Convert.ToInt32(datas.Rows[i].ItemArray[11].ToString());
                string LoaiKH = Convert.ToString(datas.Rows[i].ItemArray[12].ToString());
                int TrangThai = Convert.ToInt32(datas.Rows[i].ItemArray[13].ToString());
                list.AddLast(new KhachHang(_username, _password, MaKH, HoTen, NgaySinh, CMND, SDT, DiaChi, Diem, SoLanDangNhap, SoTienDaChi, TongDonDaDat, LoaiKH, TrangThai));
            }
            return list;
        }
        public static DataTable getAllDataTable()
        {
            return KhachHang_DB.getAllDataKhachHang();
        }
        public static string createMaKH(string HoTen)
        {
            string[] arr = HoTen.Split();
            string HoTenTat = "";
            for (int i = 0; i < arr.Length; i++)
            {
                HoTenTat += arr[i][0];
            }
            return $"KH{DateTime.Now.Year}{HoTenTat}00{getAllKhachHang().Count + 1}";
        }
        public static bool InsertKhachHang(KhachHang khachhang)
        {
            return KhachHang_DB.InsertDataKhachHang(khachhang);
        }
        public static bool DeleteDataKhachHang(string MaKH)
        {
            return KhachHang_DB.DeleteDataKhachHang(MaKH);
        }
        public static KhachHang searchKHWithMaKH(string MaKH)
        {
            for (LinkedListNode<KhachHang> p = getAllKhachHang().First; p != null; p = p.Next)
            {
                if (p.Value.MaKH1 == MaKH)
                {
                    return p.Value;
                }
            }
            return null;
        }
        public static DataTable SearchOnMaKH(string MaKH)
        {
            return KhachHang_DB.searchOnMaKH(MaKH);
        }
        public static bool UpdateKhachHangCoHoaDon(KhachHang khachhang)
        {
            return KhachHang_DB.UpdateHoaDonKhachHang(khachhang);
        }
        public static bool UpdateDataKhachHang(KhachHang khachang)
        {
            return KhachHang_DB.UpdateDataKhachHang(khachang);
        }
        public static DataTable LocKhachHang(string loaikh)
        {
            return KhachHang_DB.getLoc(loaikh);
        }
    }
}
