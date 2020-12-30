using project_winform.CTO;
using project_winform.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_winform.BUS
{
    class HoaDon_SanPham_BUS
    {
        public static bool ThemSanPhamVaoHD(HoaDon_SanPham sp)
        {
            return HoaDon_SanPham_DB.addHoaDon_SanPham(sp);
        }
        public static LinkedList<HoaDon_SanPham> getAllSanPhamInHoaDon(string MaHD)
        {
            return HoaDon_SanPham_DB.getAllSanPhamInHoaDon(MaHD);
        }
    }
}
