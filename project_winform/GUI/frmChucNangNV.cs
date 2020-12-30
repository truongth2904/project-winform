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
    public partial class frmChucNangNV : Form
    {
        public frmChucNangNV()
        {
            InitializeComponent();
        }
        NhanVien nhanvien = frmMain.nhanvien;
        private void frmChucNangNV_Load(object sender, EventArgs e)
        {
            Barcode barcode = new Barcode();
            Color forecolor = Color.Black;
            Color backcolor = Color.Transparent;
            Image img = barcode.Encode(TYPE.CODE128, nhanvien.MaNV1, forecolor, backcolor, (int)(pictureBox1.Width * 0.8), (int)(pictureBox1.Height * 0.8));
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Remove(grThayDoiMatKhau);
            this.Controls.Remove(btnLuuMatKhau);
            this.Controls.Add(btnThayDoiMatKhau);
            txtMaNV.Text = nhanvien.MaNV1;
            txtHoTen.Text = nhanvien.HoTen1;
            txtNgaySinh.Text = nhanvien.NgaySinh1.ToString("dd/MM/yyyy");
            txtCMND.Text = nhanvien.CMND1;
            txtSDT.Text = nhanvien.SDT1;
            txtDiaChi.Text = nhanvien.DiaChi1;
            txtSoLanDangNhap.Text = nhanvien.SoLanDangNhap1.ToString();
            txtSoHoaDonDaLap.Text = nhanvien.SoHoaDonDaLap1.ToString();
            txtLuongCB.Text = nhanvien.LuongCB1.ToString();
            txtLoaiNV.Text = nhanvien.LoaiNV1;
        }
        private void btnThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(btnThayDoiMatKhau);
            this.Controls.Add(grThayDoiMatKhau);
            this.Controls.Add(btnLuuMatKhau);
        }
        private void btnCapNhatThongTin_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text.Trim().Length == 0 || txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Không được để trống địa chỉ hoặc số điện thoại !", "Thông báo");
            }
            else
            {
                nhanvien.DiaChi1 = txtDiaChi.Text;
                nhanvien.SDT1 = txtSDT.Text;
                NhanVien_BUS.UpdateNhanVien(nhanvien);
                MessageBox.Show("Cập nhật thành công !");
                frmChucNangNV_Load(sender, e);
            }
        }
        private void txtMatKhauHienTai_Leave(object sender, EventArgs e)
        {
            if (txtMatKhauHienTai.Text != nhanvien.Password )
            {
                MessageBox.Show("Sai mật khẩu hiện tại !");
                txtMatKhauHienTai.Text = "";
            }
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
                    nhanvien.Password = txtNhapMatKhauMoi.Text;
                    NhanVien_BUS.UpdateNhanVien(nhanvien);
                    MessageBox.Show("Thay đổi thông tin thành công !");
                    frmChucNangNV_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu mới không chính xác !");
                }
            }
        }
    }
}
