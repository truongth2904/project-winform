using project_winform.BUS;
using project_winform.CTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace project_winform
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        // Cac bien dang nhap:
        public static LinkedList<Admin> listAD = Admin_BUS.getAllAdmin();
        public static Admin admin;
        public static LinkedList<NhanVien> listNV = NhanVien_BUS.getAllNhanVien();
        public static NhanVien nhanvien;
        public static LinkedList<KhachHang> listKH = KhachHang_BUS.getAllKhachHang();
        public static KhachHang khachhang;
        private void frmMain_Load(object sender, EventArgs e)
        {
            #region * Tô màu lấy hình ảnh 
            this.BackColor = Color.FromArgb(36, 37, 39);
            btnDangNhap.BackColor = Color.FromArgb(95, 180, 4);
            btnDangNhap.ForeColor = Color.Black;
            btnThoat.BackColor = Color.FromArgb(95, 180, 4);
            btnThoat.ForeColor = Color.Black;
            txtMatKhau.UseSystemPasswordChar = false;
            pictureBox1.Image = Image.FromFile(@"adsds.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            panel1.BackColor = Color.FromArgb(0, 255, 128);
            this.ForeColor = Color.White;
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            lblPasswordNull.Text = "";
            lblUsernameNull.Text = "";
            #endregion
            
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (KT_Rong(txtTaiKhoan.Text) == false && KT_Rong(txtMatKhau.Text) == false)
            {
                lblUsernameNull.Text = "";
                lblPasswordNull.Text = "";

                #region *  Khi admin dang nhap:
                admin = KT_Admin(txtTaiKhoan.Text, listAD);
                if (admin != null)
                {
                    if (admin.Username == txtTaiKhoan.Text && admin.Password == txtMatKhau.Text)
                    {
                        new frmAdmin().Show();
                        this.Hide();
                    }
                }
                else
                {
                    lblUsernameNull.Text = "Sai thông tin đăng nhập !";
                }
                #endregion

                #region * Khi nhan vien dang nhap:
                nhanvien = KT_NhanVien(txtTaiKhoan.Text, listNV);
                if (nhanvien != null)
                {
                    if (nhanvien.TrangThai1 == 0)
                    {
                        MessageBox.Show("Nhân viên này đã bị xóa !");
                        frmMain_Load(sender, e);
                    }
                    else
                    {
                        if (nhanvien.Username == txtTaiKhoan.Text && nhanvien.Password == txtMatKhau.Text)
                        {
                            nhanvien.SoLanDangNhap1++;
                            NhanVien_BUS.UpdateNhanVienHoaDon(nhanvien);
                            new frmNhanVien().Show();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    lblUsernameNull.Text = "Sai thông tin đăng nhập !";
                }
                #endregion

                #region * Khi khach hang dang nhap
                khachhang = KT_KhachHang(txtTaiKhoan.Text, listKH);
                if (khachhang != null)
                {
                    if (khachhang.TrangThai1 == 0)
                    {
                        MessageBox.Show("Khách hàng này đã bị xóa !");
                        frmMain_Load(sender, e);
                    }
                    else
                    {
                        if (khachhang.Username == txtTaiKhoan.Text && khachhang.Password == txtMatKhau.Text)
                        {
                            khachhang.SoLanDangNhap1++;
                            KhachHang_BUS.UpdateKhachHangCoHoaDon(khachhang);
                            new frmKhachHang().Show();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    lblUsernameNull.Text = "Sai thông tin đăng nhập !";
                }
                #endregion
            }
            else
            {
                if (KT_Rong(txtTaiKhoan.Text) == true)
                {
                    if (KT_Rong(txtMatKhau.Text) == true)
                    {
                        Ca2Null();
                    }
                    else
                    {
                        lblUsernameNull.Text = "Không được để trống !";
                    }
                }
                else if (KT_Rong(txtMatKhau.Text) == true)
                {
                    lblPasswordNull.Text = "Không được để trống !";
                }
            }
        }
        public bool KT_Rong(string a)
        {
            if (a.Trim().Length == 0)
            {
                return true;
            }
            return false;
        }
        public void Ca2Null()
        {
            lblUsernameNull.Text = "Không được để trống !";
            lblPasswordNull.Text = "Không được để trống !";
        }
        public Admin KT_Admin(string MaAD, LinkedList<Admin> list)
        {
            int i = 0;
            for (LinkedListNode<Admin> p = list.First; i < list.Count; i++, p = p.Next)
            {
                if (p.Value.MaAD1 == MaAD)
                {
                    return p.Value;
                }
            }
            return null;
        }
        public NhanVien KT_NhanVien(string MaNV, LinkedList<NhanVien> list)
        {
            int i = 0;
            for (LinkedListNode<NhanVien> p = list.First; i < list.Count; i++, p = p.Next)
            {
                if (p.Value.MaNV1 == MaNV)
                {
                    return p.Value;
                }
            }
            return null;
        }
        public KhachHang KT_KhachHang(string MaKH, LinkedList<KhachHang> list)
        {
            int i = 0;
            for (LinkedListNode<KhachHang> p = list.First; i < list.Count; i++, p = p.Next)
            {
                if (p.Value.MaKH1 == MaKH)
                {
                    return p.Value;
                }
            }
            return null;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public static void close()
        {

        }

    }
}