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
    public partial class frmReportKhachHang : Form
    {
        public frmReportKhachHang()
        {
            InitializeComponent();
        }

        private void frmReportKhachHang_Load(object sender, EventArgs e)
        {
            CrystalReportKhachHang cry = new CrystalReportKhachHang();
            DataTable table = new DataTable();
            table = KhachHang_BUS.getAllDataTable();
            cry.SetDataSource(table);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
