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
    class ThanhToan_BUS
    {
        public static DataTable getAllData()
        {
            return ThanhToan_DB.getAllData();
        }
        public static bool insertPTTT(ThanhToan thanhtoan)
        {
            return ThanhToan_DB.insertThanhToan(thanhtoan);
        }
        public static bool updatePTTT(ThanhToan thanhtoan)
        {
            return ThanhToan_DB.updateThanhToan(thanhtoan);
        }
        public static string createMaTT()
        {
            return $"TT{getAllData().Rows.Count + 1}";
        }
    }
}
