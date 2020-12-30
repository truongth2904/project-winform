using project_winform.CTO;
using project_winform.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace project_winform.BUS
{
    class NhanVien_BUS
    {
        public static LinkedList<NhanVien> getAllNhanVien()
        {
            LinkedList<NhanVien> list = new LinkedList<NhanVien>();
            DataTable datas = NhanVien_DB.getAllDataNhanVien();
            for (int i = 0; i < datas.Rows.Count; i++)
            {
                string _username = datas.Rows[i].ItemArray[0].ToString();
                string _password = datas.Rows[i].ItemArray[1].ToString();
                string MaNV = datas.Rows[i].ItemArray[2].ToString();
                string HoTen = datas.Rows[i].ItemArray[3].ToString();
                DateTime NgaySinh = Convert.ToDateTime(datas.Rows[i].ItemArray[4].ToString());
                string CMND = datas.Rows[i].ItemArray[5].ToString();
                string SDT = datas.Rows[i].ItemArray[6].ToString();
                string DiaChi = datas.Rows[i].ItemArray[7].ToString();
                int SoLanDangNhap = Convert.ToInt32(datas.Rows[i].ItemArray[8].ToString());
                int SoHoaDonDaLap = Convert.ToInt32(datas.Rows[i].ItemArray[9].ToString());
                double LuongCB = Convert.ToDouble(datas.Rows[i].ItemArray[10].ToString());
                string LoaiNV = datas.Rows[i].ItemArray[11].ToString();
                int TrangThai = Convert.ToInt32(datas.Rows[i].ItemArray[12].ToString().Trim());
                list.AddLast(new NhanVien(_username, _password, MaNV, HoTen, NgaySinh, CMND, SDT, DiaChi, SoLanDangNhap, SoHoaDonDaLap, LuongCB, LoaiNV, TrangThai));
            }
            return list;
        }
        public static DataTable getAllDataTable()
        {
            return NhanVien_DB.getAllDataNhanVien();
        }
        public static string createMaNV(string HotenNV)
        {
            HotenNV = HotenNV.Trim();
            string[] arr = HotenNV.Split();
            string HoTenTat = "";
            for (int i = 0; i < arr.Length; i++)
            {
                HoTenTat += arr[i][0];
            }
            return $"NV{DateTime.Now.Year}{HoTenTat}00{getAllNhanVien().Count + 1}";
        }
        public static bool InsertNhanVien(NhanVien nhanvien)
        {
            return NhanVien_DB.InsertDataNhanVien(nhanvien);
        }
        public static bool DeleteDataNhanVien(string MaNV)
        {
            return NhanVien_DB.DeleteDataNhanvien(MaNV);
        }
        public static DataTable SearchOnMaNV(string MaNV)
        {
            return NhanVien_DB.searchOnMaNV(MaNV);
        }
        public static bool UpdateNhanVienHoaDon(NhanVien nhanvien)
        {
            return NhanVien_DB.UpdateNhanVienHoaDon(nhanvien);
        }
        public static bool UpdateNhanVien(NhanVien nhanvien)
        {
            return NhanVien_DB.UpdateDataNhanVien(nhanvien);
        }
        public static DataTable LocNhanVien(string loainv)
        {
            return NhanVien_DB.getLoc(loainv);
        }
        public static NhanVien getNhanVienWithMaNV(string MaNV)
        {
            for(LinkedListNode<NhanVien> p = getAllNhanVien().First; p != null; p = p.Next)
            {
                if (p.Value.MaNV1 == MaNV)
                {
                    return p.Value;
                }
            }
            return null;
        }
    }
}
