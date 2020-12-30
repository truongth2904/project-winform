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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            #region * Ke o cho lsv
            lvwHangHoa.GridLines = true;
            lvwHangHoa.View = View.Details;
            lvwHangHoa.FullRowSelect = true;
            lvwHangHoa.Columns.Add("MaHH", 117);
            lvwHangHoa.Columns.Add("Tên hàng", 117);
            lvwHangHoa.Columns.Add("Giá gốc", 102);
            lvwHangHoa.Columns.Add("Giảm giá %", 107);
            lvwHangHoa.Columns.Add("Giá tiền", 107);
            lvwHangHoa.Columns.Add("Số lượng", 102);
            lvwHangHoa.Columns.Add("Tổng tiền", 102);
            #endregion
            txtMaKH.Text = "";
            txtMaHH.Text = "";
            pictureBox1.BackColor = Color.White;
            lblHoTenKH.Text = "";
        }
        public static string makhachhang = "";
        private void btnGui_Click(object sender, EventArgs e)
        {
            KhachHang khachhang = KhachHang_BUS.searchKHWithMaKH(txtMaKH.Text);
            if (khachhang != null)
            {
                if (khachhang.TrangThai1 == 0)
                {
                    MessageBox.Show("Khách hàng này đã bị xóa !");
                }
                else
                {
                    Barcode barcode = new Barcode();
                    Color forecolor = Color.Black;
                    Color backcolor = Color.Transparent;
                    Image img = barcode.Encode(TYPE.CODE128, txtMaKH.Text, forecolor, backcolor, (int)(pictureBox1.Width * 0.8), (int)(pictureBox1.Height * 0.8));
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    lblHoTenKH.Text = khachhang.HoTen1;
                    makhachhang = khachhang.MaKH1;
                }
            }
            else
            {
                MessageBox.Show("Khách hàng này không có !", "Thông báo");
                txtMaKH.Text = "";
            }
        }
        public static double tong = 0;
        LinkedList<int> ListsoLuong = new LinkedList<int>();
        LinkedList<SanPham> listSPInHoaDon = new LinkedList<SanPham>();
        private void btnGuiMaHH_Click_1(object sender, EventArgs e)
        {
            SanPham sanpham = SanPham_BUS.getDataSanPhamWithMaSP(txtMaHH.Text);
            if (sanpham != null)
            {
                try
                {
                    listSPInHoaDon.AddLast(sanpham);
                    int soluong = Convert.ToInt32(txtSoLuong.Text);
                    double giatien = sanpham.GiaBan - (sanpham.GiamGia / 100) * sanpham.GiaBan;
                    double tongtien = giatien * soluong;
                    string[] arr = new string[7];
                    arr[0] = txtMaHH.Text;
                    arr[1] = sanpham.TenSP;
                    arr[2] = sanpham.GiaBan.ToString();
                    arr[3] = sanpham.GiamGia.ToString();
                    arr[4] = giatien.ToString();
                    arr[5] = soluong.ToString();
                    arr[6] = tongtien.ToString();
                    if (sanpham.TrangThai == 0)
                    {
                        MessageBox.Show("Sản phẩm này đã bị xóa !", "Thông báo");
                        txtMaHH.Text = "";
                        txtSoLuong.Text = "";
                    }
                    else
                    {
                        if (sanpham.SoLuong < sanpham.SoLuongBanRa + Convert.ToInt32(txtSoLuong.Text))
                        {
                            MessageBox.Show("Sản phẩm bạn chọn hiện không đủ hàng hoặc đã hết !");
                            txtMaHH.Text = "";
                            txtSoLuong.Text = "";
                        }
                        else
                        {
                            ListViewItem item = new ListViewItem(arr);
                            lvwHangHoa.Items.Add(item);
                            ListsoLuong.AddLast(soluong);
                            // Thêm sản phẩm là bán được 1 và sản phẩm còn trong kho
                            sanpham.SoLuongBanRa += soluong;
                            txtMaKH.Text = "";
                            txtSoLuong.Text = "";
                            tong = Convert.ToDouble(lblTongTienHang.Text) + tongtien;
                            lblTongTienHang.Text = tong.ToString();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số lượng !");
                    txtSoLuong.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Mã hàng này không tồn tại");
                txtMaKH.Text = "";
                txtSoLuong.Text = "";
            }
        }
        double doanhthu = 0;
        int sohoadon = 0;
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (KhachHang_BUS.searchKHWithMaKH(txtMaKH.Text) == null)
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng");
            }
            else
            {
                soLine = lvwHangHoa.Items.Count;
                new frmThanhToan().Show();
                HoaDon hoadon = new HoaDon(HoaDon_BUS.createMaHD(), frmMain.nhanvien.MaNV1, makhachhang, DateTime.Now, "", 1, tong);
                HoaDon_BUS.ThemHD(hoadon);
                // Them san pham vao hoa don:
                LinkedListNode<SanPham> p = listSPInHoaDon.First;
                LinkedListNode<int> q = ListsoLuong.First;
                for (int i = 0; p != null || q!=null; i++, p = p.Next, q = q.Next)
                {
                    string MaSP = p.Value.MaSP;
                    string MaHD = hoadon.MaHD1;
                    int s = q.Value;
                    HoaDon_SanPham sp = new HoaDon_SanPham(MaSP, MaHD, s);
                    HoaDon_SanPham_BUS.ThemSanPhamVaoHD(sp);
                }
                // Thêm khách hàng đó 1 hóa đơn:
                #region
                KhachHang khachhang = KhachHang_BUS.searchKHWithMaKH(txtMaKH.Text);
                khachhang.TongDonDaDat1++;
                khachhang.SoTienDaChi1 += tong;
                int diem = (int)tong / 10;
                khachhang.Diem1 += diem;
                if (khachhang.Diem1 > 500)
                {
                    khachhang.LoaiKH1 = "VIP";
                }
                else if (khachhang.Diem1 > 400)
                {
                    khachhang.LoaiKH1 = "Bạch kim";
                }
                else if (khachhang.Diem1 > 300)
                {
                    khachhang.LoaiKH1 = "Vàng";
                }
                else if (khachhang.Diem1 > 200)
                {
                    khachhang.LoaiKH1 = "Bạc";
                }
                else 
                {
                    khachhang.LoaiKH1 = "Đồng";
                }
                KhachHang_BUS.UpdateKhachHangCoHoaDon(khachhang);
                #endregion
                // Thêm nhân viên vào 1 hóa đơn:
                NhanVien nhanvien = frmMain.nhanvien;
                nhanvien.SoHoaDonDaLap1++;
                NhanVien_BUS.UpdateNhanVienHoaDon(nhanvien);
                // thêm sản phẩm vào mục bán được:
                LinkedListNode<int> sl = ListsoLuong.First;
                for (LinkedListNode<SanPham> s = listSPInHoaDon.First; s != null; s = s.Next, sl = sl.Next)
                {
                    s.Value.SoLuongBanRa += sl.Value;
                    s.Value.SoLuong += -s.Value.SoLuongBanRa;
                    SanPham_BUS.UpdateSanPhamHoaDon(s.Value);
                }
                sohoadon++;
                doanhthu += tong;
                lvwHangHoa.Items.Clear();
                lvwHangHoa.Columns.Clear();
                frmNhanVien_Load(sender, e);
                pictureBox1.Image = Image.FromFile("trang.png");
                lblTongTienHang.Text = "0";
            }
        }
        public static int soLine = 0;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show($"Ngày hôm nay bạn đã lập {sohoadon} hóa đơn, doanh thu hôm nay là {doanhthu} VNG","Thông báo");
                this.Close();
                new frmMain().Close();
                Application.Exit();
            }
        }
        private void btnChucNang_Click(object sender, EventArgs e)
        {
            new frmChucNangNV().Show();
        }
    }
}
