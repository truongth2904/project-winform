using project_winform.CTO;
using project_winform.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace project_winform.BUS
{
    class SanPham_BUS
    {
        public static string createMaSP(LinkedList<SanPham> list)
        {
            return $"SP{DateTime.Now.Year}0000{list.Count + 1}";
        }
        public static LinkedList<SanPham> getAllSanPham()
        {
            LinkedList<SanPham> list = new LinkedList<SanPham>();
            DataTable datas = SanPham_DB.getAllDataSanPham();
            for (int i = 0; i < datas.Rows.Count; i++)
            {
                string MaSP = datas.Rows[i].ItemArray[0].ToString();
                string TenSP = datas.Rows[i].ItemArray[1].ToString();
                int SoLuong = Convert.ToInt32(datas.Rows[i].ItemArray[2].ToString());
                DateTime NgayNhap = Convert.ToDateTime(datas.Rows[i].ItemArray[3].ToString());
                double GiaNhap = Convert.ToDouble(datas.Rows[i].ItemArray[4].ToString());
                double GiaBan = Convert.ToDouble(datas.Rows[i].ItemArray[5].ToString());
                double GiamGia = Convert.ToDouble(datas.Rows[i].ItemArray[6].ToString());
                int SoLuongBanRa = Convert.ToInt32(datas.Rows[i].ItemArray[7].ToString());
                string LoaiSP = datas.Rows[i].ItemArray[8].ToString();
                int TrangThai = Convert.ToInt32(datas.Rows[i].ItemArray[9].ToString());
                list.AddLast(new SanPham(MaSP, TenSP, SoLuong, NgayNhap, GiaNhap, GiaBan, GiamGia, SoLuongBanRa, LoaiSP, TrangThai));
            }
            return list;
        }
        public static DataTable getAllDataTable()
        {
            return SanPham_DB.getAllDataSanPham();
        }
        public static SanPham getDataSanPhamWithMaSP(string MaSP)
        {
            LinkedList<SanPham> list = getAllSanPham();
            for (LinkedListNode<SanPham> p = list.First; p != null; p = p.Next)
            {
                if (p.Value.MaSP == MaSP)
                {
                    return p.Value;
                }
            }
            return null;
        }
        public static bool InsertSanPham(SanPham sanpham)
        {
            bool check = SanPham_DB.insertDataSanPham(sanpham);
            return check;
        }
        public static bool DeleteSanPham(string MaSP)
        {
            return SanPham_DB.deleteDataSanPham(MaSP);
        }
        public static bool ChangeSanPham(SanPham sanpham)
        {
            return SanPham_DB.changeDataSanPham(sanpham);
        }
        public static bool InsertSoLuongSanPham(string MaSP, int SoLuong)
        {
            return SanPham_DB.insertSanPham(MaSP, SoLuong);
        }
        public static DataTable SearchOnMaSP(string MaSP)
        {
            return SanPham_DB.searchOnMaSP(MaSP);
        }
        public static bool UpdateSanPhamHoaDon(SanPham sp)
        {
            return SanPham_DB.updateSanPhamHoaDon(sp);
        }
        public static DataTable LocSanPham(string LoaiSP)
        {
            return SanPham_DB.getLoc(LoaiSP);
        }
        public static DataTable getDoanhThuLoaiSP()
        {
            return SanPham_DB.getDoanhThu();
        }
    }
}
