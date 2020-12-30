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
    public partial class frmReportNhanVien : Form
    {
        public frmReportNhanVien()
        {
            InitializeComponent();
        }

        private void frmReportNhanVien_Load(object sender, EventArgs e)
        {
            CrystalReportNhanVien cry = new CrystalReportNhanVien();
            DataTable table = new DataTable();
            table = NhanVien_BUS.getAllDataTable();
            cry.SetDataSource(table);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
