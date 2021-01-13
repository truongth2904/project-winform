using BarcodeLib;
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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        KhachHang khachhang = frmMain.khachhang;
        private void btnCapNhatThongTin_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text.Trim().Length == 0 || txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Không được để trống địa chỉ hoặc số điện thoại !", "Thông báo");
            }
            else
            {
                khachhang.DiaChi1 = txtDiaChi.Text;
                khachhang.SDT1 = txtSDT.Text;
                KhachHang_BUS.UpdateDataKhachHang(khachhang);
                MessageBox.Show("Cập nhật thành công !");
                frmKhachHang_Load(sender, e);
            }
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            Barcode barcode = new Barcode();
            Color forecolor = Color.Black;
            Color backcolor = Color.Transparent;
            Image img = barcode.Encode(TYPE.CODE128, khachhang.MaKH1, forecolor, backcolor, (int)(pictureBox1.Width * 0.8), (int)(pictureBox1.Height * 0.8));
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            txtMaKH.Text = khachhang.MaKH1;
            txtHoTen.Text = khachhang.HoTen1;
            txtNgaySinh.Text = khachhang.NgaySinh1.ToString("dd/MM/yyyy");
            txtCMND.Text = khachhang.CMND1;
            txtSDT.Text = khachhang.SDT1;
            txtDiaChi.Text = khachhang.DiaChi1;
            txtDiem.Text = khachhang.Diem1.ToString();
            txtSoLanDangNhap.Text = khachhang.SoLanDangNhap1.ToString();
            txtTongTienDaChi.Text = khachhang.SoTienDaChi1.ToString();
            txtTongDonDaDat.Text = khachhang.TongDonDaDat1.ToString();
            txtLoaiKH.Text = khachhang.LoaiKH1;
            this.Controls.Add(btnThayDoiMatKhau);
            this.Controls.Remove(grThayDoiMatKhau);
            this.Controls.Remove(btnLuuMatKhau);
            txtMatKhauHienTai.Text = "";
            txtNhapLaiMatKhauMoi.Text = "";
            txtNhapMatKhauMoi.Text = "";

            txtMatKhauHienTai.PasswordChar = '*';
            txtNhapLaiMatKhauMoi.PasswordChar = '*';
            txtNhapMatKhauMoi.PasswordChar = '*';
        }
        private void btnThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(btnThayDoiMatKhau);
            this.Controls.Add(grThayDoiMatKhau);
            this.Controls.Add(btnLuuMatKhau);
        }
        private void btnLuuMatKhau_Click(object sender, EventArgs e)
        {
            if (txtNhapMatKhauMoi.Text.Trim().Length == 0)
            {
                MessageBox.Show("vui lòng nhập mật khẩu mới !");
            }
            else
            {
                if (txtNhapMatKhauMoi.Text == txtNhapLaiMatKhauMoi.Text)
                {
                    khachhang.Password = txtNhapMatKhauMoi.Text;
                    KhachHang_BUS.UpdateDataKhachHang(khachhang);
                    MessageBox.Show("Thay đổi thông tin thành công !");
                    frmKhachHang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu mới không chính xác !");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
    }
}
