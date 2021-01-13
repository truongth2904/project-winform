using project_winform.BUS;
using project_winform.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_winform
{
    public partial class frmReportDoanhThuSanPham : Form
    {
        public frmReportDoanhThuSanPham()
        {
            InitializeComponent();
        }

        private void frmReportDoanhThuSanPham_Load(object sender, EventArgs e)
        {
            CrystalReport1 cry = new CrystalReport1();
            DataTable table = new DataTable();
            table = SanPham_BUS.getDoanhThuLoaiSP();
            cry.SetDataSource(table);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
