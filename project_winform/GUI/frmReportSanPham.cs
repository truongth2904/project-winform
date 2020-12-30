﻿using project_winform.BUS;
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
    public partial class frmReportSanPham : Form
    {
        public frmReportSanPham()
        {
            InitializeComponent();
        }

        private void frmReportSanPham_Load(object sender, EventArgs e)
        {
            CrystalReportSanPham cry = new CrystalReportSanPham();
            DataTable table = new DataTable();
            table = SanPham_BUS.getAllDataTable();
            cry.SetDataSource(table);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
