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
    public partial class frmReportHoaDon : Form
    {
        public frmReportHoaDon()
        {
            InitializeComponent();
        }

        private void frmReportHoaDon_Load(object sender, EventArgs e)
        {
            CrystalReportHoaDon cry = new CrystalReportHoaDon();
            DataTable table = new DataTable();
            table = HoaDon_BUS.getAllData();
            cry.SetDataSource(table);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
