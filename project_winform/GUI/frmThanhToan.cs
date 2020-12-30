using project_winform.BUS;
using project_winform.CTO;
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
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblTienKhachPhaiTra.Text = $"Số tiền khách phải trả là: {frmNhanVien.tong}";
        }
        public static double tienthoilai;
        public static double tienkhachdua;
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                tienkhachdua = Convert.ToDouble(txtTienKhachDua.Text);
                if (tienkhachdua >= frmNhanVien.tong)
                {
                    tienthoilai = tienkhachdua - frmNhanVien.tong;
                    MessageBox.Show($"Thối lại cho khách {tienthoilai} VNG");
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Khách còn nợ {tienkhachdua - frmNhanVien.tong} VNG, vui lòng nhập thêm tiền");
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số tiền !");
            }
        }
    }
}
