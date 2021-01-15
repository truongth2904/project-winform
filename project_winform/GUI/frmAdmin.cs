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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            frmAdmin_Load(sender, e);
        }
        #region * Admin
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            #region * Giao dien khi load form
            picHome.Image = Image.FromFile(@"icon_home.png");
            picHome.SizeMode = PictureBoxSizeMode.StretchImage;
            picSanPham.Image = Image.FromFile(@"icon_product.png");
            picSanPham.SizeMode = PictureBoxSizeMode.StretchImage;
            picHoaDon.Image = Image.FromFile(@"icon_hoadon.png");
            picHoaDon.SizeMode = PictureBoxSizeMode.StretchImage;
            picNhanVien.Image = Image.FromFile(@"icon_nhanvien.png");
            picNhanVien.SizeMode = PictureBoxSizeMode.StretchImage;
            picKhachHang.Image = Image.FromFile(@"icon_khachhang.png");
            picKhachHang.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogoAdmin.Image = Image.FromFile(@"myadmin.png");
            picLogoAdmin.SizeMode = PictureBoxSizeMode.StretchImage;
            picXemDS.Image = Image.FromFile(@"xemds.png");
            picXemDS.SizeMode = PictureBoxSizeMode.StretchImage;
            #endregion

            #region * Ke o cho Listview
            listView1.GridLines = true;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            this.Controls.Remove(listView1);
            #endregion

            #region * Ghi cac thong tin admin
            txtMaAD.Text = frmMain.admin.MaAD1;
            txtHoTenAD.Text = frmMain.admin.HoTen1;
            txtNgaySinhAD.Text = frmMain.admin.NgaySinh1.ToString("MM/dd/yyy");
            txtCMNDAD.Text = frmMain.admin.CMND1;
            txtDiaChi.Text = frmMain.admin.DiaChi1;
            txtTrangThaiAD.Text = frmMain.admin.TrangThai1.ToString();
            txtSDTAdmin.Text = frmMain.admin.SDT1;
            lblWelcomeAdmin.Text = frmMain.admin.HoTen1;
            if (Convert.ToInt32(txtTrangThaiAD.Text) == 1)
            {
                txtTrangThaiAD.Text = "Đang sử dụng";
            }
            else if (Convert.ToInt32(txtTrangThaiAD.Text) == 0)
            {
                txtTrangThaiAD.Text = "";
            }
            #endregion

            #region * Xoa cac gr
            grThongTinAdmin.Controls.Remove(grThayDoiMatKhauAD);
            this.Controls.Remove(grFullSanPham);
            this.Controls.Remove(grFullNhanVien);
            this.Controls.Remove(grFullKhachHang);
            this.Controls.Add(grThongTinAdmin);
            this.Controls.Remove(grXemDS);
            this.Controls.Remove(grFullHoaDon);
            grThongTinAdmin.Controls.Add(btnThayDoiMtKhauAD);

            #endregion

            //Cho pass các kí hiệu:
            txtMatKhauHienTaiAD.PasswordChar = '*';
            txtMatKhauMoiAD.PasswordChar = '*';
            txtXacNhanMatKhauMoi.PasswordChar = '*';
        }
        private void btnThayDoiMtKhauAD_Click(object sender, EventArgs e)
        {
            grThongTinAdmin.Controls.Remove(btnThayDoiMtKhauAD);
            grThongTinAdmin.Controls.Add(grThayDoiMatKhauAD);
        }
        private void btnLuuThongTinAD_Click(object sender, EventArgs e)
        {
            if (KT_ThongtinNhapVao())
            {
                string password = frmMain.admin.Password;
                if (changePassWord())
                {
                    if (txtXacNhanMatKhauMoi.Text.Trim().Length != 0)
                    {
                        password = txtXacNhanMatKhauMoi.Text;
                    }

                    Admin admin = new Admin(frmMain.admin.Username, password, frmMain.admin.MaAD1, txtHoTenAD.Text, Convert.ToDateTime(txtNgaySinhAD.Text), txtCMNDAD.Text, txtSDTAdmin.Text, txtDiaChi.Text, 1);
                    if (KT_SDT(admin.SDT1) == false)
                    {
                        MessageBox.Show("Vui long nhap dung sdt");
                    }
                    else
                    {
                        if (Admin_BUS.changeInFo(admin))
                        {
                            MessageBox.Show("Thay đổi thông tin thành công !");
                            lblMatKhauLoi.Text = "";
                            lblThongTinAdminLoi.Text = "";
                            grThongTinAdmin.Controls.Remove(grThayDoiMatKhauAD);
                            grThongTinAdmin.Controls.Add(btnThayDoiMtKhauAD);
                            txtMatKhauHienTaiAD.Text = "";
                            txtMatKhauMoiAD.Text = "";
                            txtXacNhanMatKhauMoi.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Thay đổi không thành công !");
                        }
                    }
                }
            }
            else
            {
                lblThongTinAdminLoi.Text = "Vui lòng nhập đúng định dạng";
            }
        }
        public bool changePassWord()
        {

            if (txtMatKhauHienTaiAD.Text.Length == 0 && txtMatKhauMoiAD.Text.Length == 0 && txtXacNhanMatKhauMoi.Text.Length == 0)
            {
                return true;
            }
            else
            {
                if (txtMatKhauHienTaiAD.Text != frmMain.admin.Password)
                {
                    lblMatKhauLoi.Text = "Sai mật khẩu hiện tại !";
                    return false;
                }
                else
                {
                    if (txtMatKhauMoiAD.Text.Trim().Length != 0 || txtXacNhanMatKhauMoi.Text.Trim().Length != 0)
                    {
                        if (txtMatKhauMoiAD.Text != txtXacNhanMatKhauMoi.Text)
                        {
                            lblMatKhauLoi.Text = "Xác nhận mật khẩu mới không đúng !";
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        lblMatKhauLoi.Text = "Vui lòng nhập đầy đủ thông tin";
                        return false;
                    }

                }
            }
        }
        public bool KT_ThongtinNhapVao()
        {
            try
            {
                Convert.ToDateTime(txtNgaySinhAD.Text);
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region * San Pham
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(grFullHoaDon);
            lblDanhSachCacSP.Text = "THÔNG TIN SẢN PHẨM";
            this.Controls.Remove(grThongTinAdmin);
            this.Controls.Add(grFullSanPham);
            this.Controls.Remove(grFullNhanVien);
            this.Controls.Remove(grFullKhachHang);
            this.Controls.Remove(grFullHoaDon);
            this.Controls.Remove(grXemDS);
            grNhapHang.Controls.Remove(listView1);
            grFullSanPham.Controls.Remove(listView1);
        }
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            lblthemSanPhamMoiLoi.Text = "";
            grFullSanPham.Controls.Add(grThemSanPham);
            grFullSanPham.Controls.Remove(grXoaSanPham);
            grFullSanPham.Controls.Remove(grSuaThongTinSanPham);
            grFullSanPham.Controls.Remove(grNhapHang);
            grFullSanPham.Controls.Remove(listView1);
            txtTenSanPhamMoi.Text = "";
            txtGiaNhapSanPhamMoi.Text = "";
            txtGiaBanSanPhamMoi.Text = "";
            txtSoLuongSanPhamMoi.Text = "";
            txtLoaiSanPhamMoi.Text = "";
        }
        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            lblXoaSanPhamLoi.Text = "";
            grFullSanPham.Controls.Remove(grThemSanPham);
            grFullSanPham.Controls.Add(grXoaSanPham);
            grFullSanPham.Controls.Remove(grNhapHang);
            grFullSanPham.Controls.Remove(grSuaThongTinSanPham);
            grFullSanPham.Controls.Remove(listView1);
            txtMaSanPhamXoa.Text = "";
        }
        private void btnSuaThongTinSanPham_Click(object sender, EventArgs e)
        {
            grFullSanPham.Controls.Remove(grThemSanPham);
            grFullSanPham.Controls.Remove(grXoaSanPham);
            grFullSanPham.Controls.Add(grSuaThongTinSanPham);
            grFullSanPham.Controls.Remove(grNhapHang);
            grFullSanPham.Controls.Remove(listView1);
            txtMaSanPhamCanSua.Text = "";
            txtTenSanPhamCanSua.Text = "";
            txtGiaBanSanPhamCanSua.Text = "";
            txtGiamGiaSanPhamCanSua.Text = "";
            txtLoaiSanPhamCanSua.Text = "";
        }
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            grFullSanPham.Controls.Remove(grThemSanPham);
            grFullSanPham.Controls.Remove(grXoaSanPham);
            grFullSanPham.Controls.Remove(grSuaThongTinSanPham);
            grFullSanPham.Controls.Add(grNhapHang);
            grFullSanPham.Controls.Remove(listView1);
            txtMaHangHoaNhapVe.Text = "";
            txtTenSanPhamNhapHang.Text = "";
            txtSoHangHienDangCo.Text = "";
            txtNhapThemSoLuongSanPham.Text = "";
        }
        private void btnSanPhamKhongBanDuoc_Click(object sender, EventArgs e)
        {
            grFullSanPham.Controls.Add(listView1);
            grFullSanPham.Controls.Remove(grThemSanPham);
            grFullSanPham.Controls.Remove(grXoaSanPham);
            grFullSanPham.Controls.Remove(grSuaThongTinSanPham);
            grFullSanPham.Controls.Remove(grNhapHang);
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("MaSP", 120);
            listView1.Columns.Add("Tên", 120);
            listView1.Columns.Add("Giá nhập", 120);
            listView1.Columns.Add("Giá bán", 120);
            listView1.Columns.Add("Giảm giá", 120);
            string[] arr = new string[5];
            LinkedList<SanPham> list = SanPham_BUS.getAllSanPham();
            for (LinkedListNode<SanPham> p = list.First; p != list.Last; p = p.Next)
            {
                if (p.Value.TrangThai == 1)
                {
                    if (p.Value.SoLuongBanRa == 0)
                    {
                        arr[0] = p.Value.MaSP;
                        arr[1] = p.Value.TenSP;
                        arr[2] = p.Value.GiaNhap.ToString();
                        arr[3] = p.Value.GiaBan.ToString();
                        arr[4] = p.Value.GiamGia.ToString();
                        ListViewItem item = new ListViewItem(arr);
                        listView1.Items.Add(item);
                    }
                }
            }
        }
        private void btnGrThemSanPhamMoi_Click(object sender, EventArgs e)
        {
            if (txtTenSanPhamMoi.Text.Trim().Length == 0 || txtGiaNhapSanPhamMoi.Text.Trim().Length == 0 || txtGiaBanSanPhamMoi.Text.Trim().Length == 0 || txtSoLuongSanPhamMoi.Text.Trim().Length == 0 || txtLoaiSanPhamMoi.Text.Trim().Length == 0)
            {
                lblthemSanPhamMoiLoi.Text = "Vui lòng nhập đầy đủ thông tin !";
            }
            else
            {
                if (KT_ThongTinThemSanPhamMoi())
                {
                    SanPham sanphamNew = new SanPham(SanPham_BUS.createMaSP(SanPham_BUS.getAllSanPham()), txtTenSanPhamMoi.Text, Convert.ToInt32(txtSoLuongSanPhamMoi.Text), DateTime.Now, Convert.ToDouble(txtGiaNhapSanPhamMoi.Text), Convert.ToDouble(txtGiaBanSanPhamMoi.Text), 0, 0, txtLoaiSanPhamMoi.Text, 1);
                    if (SanPham_BUS.InsertSanPham(sanphamNew))
                    {
                        MessageBox.Show("Thêm thành công !");
                        txtTenSanPhamMoi.Text = "";
                        txtSoLuongSanPhamMoi.Text = "";
                        txtGiaNhapSanPhamMoi.Text = "";
                        txtGiaBanSanPhamMoi.Text = "";
                        txtLoaiSanPhamMoi.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công !");
                    }
                }
                else
                {
                    lblthemSanPhamMoiLoi.Text = "Vui lòng nhập đúng định dạng thông tin !";
                }
            }
        }
        private void btnXoaSanPhamWithMaSP_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (txtMaSanPhamXoa.Text.Trim().Length != 0)
            {
                LinkedList<SanPham> list = SanPham_BUS.getAllSanPham();
                for (LinkedListNode<SanPham> p = list.First; p != null; p = p.Next)
                {
                    if (txtMaSanPhamXoa.Text == p.Value.MaSP)
                    {
                        if (p.Value.TrangThai == 0)
                        {
                            MessageBox.Show("Sản phẩm này đã bị xóa !");
                            txtMaSanPhamXoa.Text = "";
                            check = true;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show($"Bạn thật sự muốn xóa : {p.Value.TenSP}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                if (SanPham_BUS.DeleteSanPham(txtMaSanPhamXoa.Text))
                                {
                                    MessageBox.Show("Xóa thành công !");
                                    txtMaSanPhamXoa.Text = "";
                                }
                            }
                            check = true;
                            break;
                        }
                    }
                }
                if (check == false)
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm {txtMaSanPhamXoa.Text}");
                    txtMaSanPhamXoa.Text = "";
                }
            }
            else
            {
                lblXoaSanPhamLoi.Text = "Vui lòng nhập thông tin !";
            }
        }
        private void btnOKSearchSanPhamSua_Click(object sender, EventArgs e)
        {

            SanPham sanphamcansua = KT_SanPhamTonTai(SanPham_BUS.getAllSanPham(), txtMaSanPhamCanSua.Text);
            if (sanphamcansua == null)
            {
                MessageBox.Show($"{txtMaSanPhamCanSua.Text} không tìm thấy !");
            }
            else
            {
                txtTenSanPhamCanSua.Text = sanphamcansua.TenSP;
                txtGiaBanSanPhamCanSua.Text = sanphamcansua.GiaBan.ToString();
                txtGiamGiaSanPhamCanSua.Text = sanphamcansua.GiamGia.ToString();
                txtLoaiSanPhamCanSua.Text = sanphamcansua.LoaiSP;
                btnXacNhanSuaThongTinXanPham.Enabled = true;
            }
        }
        private void btnXacNhanSuaThongTinXanPham_Click(object sender, EventArgs e)
        {
            SanPham sanpham = KT_SanPhamTonTai(SanPham_BUS.getAllSanPham(), txtMaSanPhamCanSua.Text);
            if (getDataOnChangeSanPham())
            {
                sanpham.TenSP = txtTenSanPhamCanSua.Text;
                sanpham.GiaBan = Convert.ToDouble(txtGiaBanSanPhamCanSua.Text);
                sanpham.GiamGia = Convert.ToDouble(txtGiamGiaSanPhamCanSua.Text);
                sanpham.LoaiSP = txtLoaiSanPhamCanSua.Text;
                if (SanPham_BUS.ChangeSanPham(sanpham))
                {
                    MessageBox.Show("Thay đổi thông tin thành công !");
                    txtMaSanPhamCanSua.Text = "";
                    txtTenSanPhamCanSua.Text = "";
                    txtGiaBanSanPhamCanSua.Text = "";
                    txtGiamGiaSanPhamCanSua.Text = "";
                    txtLoaiSanPhamCanSua.Text = "";
                }
                else
                {
                    MessageBox.Show("Thay đổi thất bại !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng đập đúng định dạng thông tin !");
            }
        }
        private void btnXacNhanNhapSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(txtNhapThemSoLuongSanPham.Text);
                if (SanPham_BUS.InsertSoLuongSanPham(txtMaHangHoaNhapVe.Text, Convert.ToInt32(txtNhapThemSoLuongSanPham.Text)))
                {
                    MessageBox.Show($"Đã thêm {txtNhapThemSoLuongSanPham.Text} cho {SanPham_BUS.getDataSanPhamWithMaSP(txtMaHangHoaNhapVe.Text).TenSP}," +
                        $"Số lượng {SanPham_BUS.getDataSanPhamWithMaSP(txtMaHangHoaNhapVe.Text).TenSP} = {SanPham_BUS.getDataSanPhamWithMaSP(txtMaHangHoaNhapVe.Text).SoLuong}");
                    txtNhapThemSoLuongSanPham.Text = "";
                    txtMaHangHoaNhapVe.Text = "";
                    txtTenSanPhamNhapHang.Text = "";
                    txtSoHangHienDangCo.Text = "";
                }
                else
                {
                    MessageBox.Show("Nhập hàng thất bại !");
                }
            }
            catch
            {
                MessageBox.Show("Thông tin không đúng định dạng hoặc sai mã sản phẩm !");
            }
        }
        private void txtMaHangHoaNhapVe_Leave(object sender, EventArgs e)
        {
            SanPham sanpham = KT_SanPhamTonTai(SanPham_BUS.getAllSanPham(), txtMaHangHoaNhapVe.Text);
            if (sanpham == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại !");
                txtMaHangHoaNhapVe.Text = "";
            }
            else
            {
                txtTenSanPhamNhapHang.Text = sanpham.TenSP;
                txtSoHangHienDangCo.Text = sanpham.SoLuong.ToString();
            }
        }
        public SanPham KT_SanPhamTonTai(LinkedList<SanPham> list, string maSP)
        {
            for (LinkedListNode<SanPham> p = list.First; p != null; p = p.Next)
            {
                if (p.Value.MaSP == maSP && p.Value.TrangThai != 0)
                {
                    return p.Value;
                }
            }
            return null;
        }
        public bool getDataOnChangeSanPham()
        {
            try
            {
                Convert.ToDouble(txtGiaBanSanPhamCanSua.Text);
                Convert.ToDouble(txtGiamGiaSanPhamCanSua.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool KT_ThongTinThemSanPhamMoi()
        {
            try
            {
                Convert.ToDouble(txtGiaBanSanPhamMoi.Text);
                Convert.ToDouble(txtGiaNhapSanPhamMoi.Text);
                Convert.ToInt32(txtSoLuongSanPhamMoi.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region * Nhan Vien
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(grFullHoaDon);
            lblDanhSachCacSP.Text = "THÔNG TIN NHÂN VIÊN";
            this.Controls.Remove(grThongTinAdmin);
            this.Controls.Remove(grFullSanPham);
            this.Controls.Add(grFullNhanVien);
            this.Controls.Remove(grFullKhachHang);
            this.Controls.Remove(grXemDS);
        }
        private void btnThemNhanVienThem_Click(object sender, EventArgs e)
        {
            if (KT_ThongTinThemNV())
            {
                NhanVien nhanvien = new NhanVien(NhanVien_BUS.createMaNV(txtHoTenNhanVienThem.Text), "123", NhanVien_BUS.createMaNV(txtHoTenNhanVienThem.Text), txtHoTenNhanVienThem.Text, Convert.ToDateTime(txtNgaySinhNhanVienThem.Text), txtCMNDNhanVienThem.Text, txtSDTNhanVienThem.Text, txtDiaChiNhanVienThem.Text, 0, 0, Convert.ToInt32(txtLuongCBNhanVienThem.Text), txtLoaiNVNhanVienThem.Text, 1);
                if (NhanVien_BUS.InsertNhanVien(nhanvien))
                {
                    MessageBox.Show($"Đã thêm {nhanvien.HoTen1} với MaNV: {nhanvien.MaNV1} mật khẩu mặc định là: 123");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng !", "Thông báo");
            }
        }
        private void btnXacNhanXoaNhanVien_Click(object sender, EventArgs e)
        {
            NhanVien nv = LayNVTuMaNV(txtMaNhanVienCanXoa.Text);
            if (nv == null)
            {
                MessageBox.Show($"Nhân viên {txtMaNhanVienCanXoa.Text} không tồn tại !");
                txtMaNhanVienCanXoa.Text = "";
            }
            else
            {
                if (LayNVTuMaNV(txtMaNhanVienCanXoa.Text).TrangThai1 == 0)
                {
                    MessageBox.Show("Nhân viên này đã bị xóa !");
                }
                else
                {
                    DialogResult dia = MessageBox.Show($"Bạn chắc chắn muốn xóa {nv.HoTen1}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dia == DialogResult.Yes)
                    {
                        if (NhanVien_BUS.DeleteDataNhanVien(txtMaNhanVienCanXoa.Text))
                        {
                            MessageBox.Show("Đã xóa thành công !");
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công");
                        }
                    }
                }
            }
        }
        private void btnXemNhanVien_Click(object sender, EventArgs e)
        {
            if (LayNVTuMaNV(txtMaNhanVienCanXem.Text) == null)
            {
                MessageBox.Show("Nhân viên không tồn tại !");
                txtMaNhanVienCanXem.Text = "";
            }
            else
            {
                NhanVien nv = LayNVTuMaNV(txtMaNhanVienCanXem.Text);
                MessageBox.Show($"Họ tên: {nv.HoTen1} \n" + "\n" +
                    $"Ngày sinh: {nv.NgaySinh1} \n " + "\n" +
                    $"CMND: {nv.CMND1} \n " + "\n" +
                    $"SDT: {nv.SDT1} \n " + "\n" +
                    $"Địa chỉ: {nv.DiaChi1} \n " + "\n" +
                    $"Số lần đăng nhập: {nv.SoLanDangNhap1} \n " + "\n" +
                    $"Số hóa đơn đã lập: {nv.SoHoaDonDaLap1} \n " + "\n" +
                    $"Lương CB: {nv.LuongCB1} \n " + "\n" +
                    $"Loại NV: {nv.LoaiNV1} \n ", "Thông tin nhân viên");
            }
        }
        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            grFullNhanVien.Controls.Add(grThemNhanVien);
            grFullNhanVien.Controls.Remove(grXoaNhanVien);
            grFullNhanVien.Controls.Remove(grXemThongTinNhanVien);
            txtHoTenNhanVienThem.Text = "";
            txtNgaySinhNhanVienThem.Text = "";
            txtCMNDNhanVienThem.Text = "";
            txtSDTNhanVienThem.Text = "";
            txtDiaChiNhanVienThem.Text = "";
            txtLoaiNVNhanVienThem.Text = "";
            txtLuongCBNhanVienThem.Text = "";
        }
        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            grFullNhanVien.Controls.Remove(grThemNhanVien);
            grFullNhanVien.Controls.Add(grXoaNhanVien);
            grFullNhanVien.Controls.Remove(grXemThongTinNhanVien);
            txtMaNhanVienCanXoa.Text = "";
        }
        private void btnXemThongTinNhanVien_Click(object sender, EventArgs e)
        {
            grFullNhanVien.Controls.Remove(grThemNhanVien);
            grFullNhanVien.Controls.Remove(grXoaNhanVien);
            grFullNhanVien.Controls.Add(grXemThongTinNhanVien);
            txtMaNhanVienCanXem.Text = "";
        }
        public NhanVien LayNVTuMaNV(string MaNV)
        {
            LinkedList<NhanVien> list = NhanVien_BUS.getAllNhanVien();
            for (LinkedListNode<NhanVien> p = list.First; p != null; p = p.Next)
            {
                if (p.Value.MaNV1 == MaNV && p.Value.TrangThai1 != 0)
                {
                    return p.Value;
                }
            }
            return null;
        }
        public bool KT_ThongTinThemNV()
        {
            try
            {
                Convert.ToDateTime(txtNgaySinhNhanVienThem.Text);
                Convert.ToDouble(txtLuongCBNhanVienThem.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region * Khach hang
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            grFullKhachHang.Controls.Add(grThemKhachHang);
            grFullKhachHang.Controls.Remove(grXoaKhachHang);
            grFullKhachHang.Controls.Remove(grXemThongTinKhachHang);
            txtHoTenKhachHangMoi.Text = "";
            txtNgaySinhKhachHangMoi.Text = "";
            txtCMNDKhachHangMoi.Text = "";
            txtSDTKhachHangMoi.Text = "";
            txtDiaChiKhachHangMoi.Text = "";

        }
        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            grFullKhachHang.Controls.Remove(grXemThongTinKhachHang);
            grFullKhachHang.Controls.Remove(grThemKhachHang);
            grFullKhachHang.Controls.Add(grXoaKhachHang);
            txtNhapMaKhachHangCanXoa.Text = "";
        }
        private void btnXemThongTinKhachHang_Click(object sender, EventArgs e)
        {
            grFullKhachHang.Controls.Add(grXemThongTinKhachHang);
            grFullKhachHang.Controls.Remove(grThemKhachHang);
            grFullKhachHang.Controls.Remove(grXoaKhachHang);
            txtMaKhachHangCanXemThongTin.Text = "";
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(grFullHoaDon);
            lblDanhSachCacSP.Text = "THÔNG TIN KHÁCH HÀNG";
            this.Controls.Remove(grThongTinAdmin);
            this.Controls.Remove(grFullSanPham);
            this.Controls.Remove(grFullNhanVien);
            this.Controls.Add(grFullKhachHang);
            this.Controls.Remove(grXemDS);
        }
        private void btnTaoKhachHangMoi_Click(object sender, EventArgs e)
        {
            txtHoTenKhachHangMoi.Text = txtHoTenKhachHangMoi.Text.Trim();
            if (txtHoTenKhachHangMoi.Text.Trim().Length == 0 || txtCMNDKhachHangMoi.Text.Trim().Length == 0 || txtSDTKhachHangMoi.Text.Trim().Length == 0 || txtDiaChiKhachHangMoi.Text.Trim().Length == 0)
            { MessageBox.Show("Vui lòng nhập đầy đủ thông tin !"); }
            else
            {
                try
                {
                    DateTime ngaysinh = Convert.ToDateTime(txtNgaySinhKhachHangMoi.Text);
                    KhachHang khachhang = new KhachHang(KhachHang_BUS.createMaKH(txtHoTenKhachHangMoi.Text), "123", KhachHang_BUS.createMaKH(txtHoTenKhachHangMoi.Text), txtHoTenKhachHangMoi.Text, ngaysinh, txtCMNDKhachHangMoi.Text, txtSDTKhachHangMoi.Text, txtDiaChiKhachHangMoi.Text, 0, 0, 0, 0, "Đồng", 1);
                    if (KhachHang_BUS.InsertKhachHang(khachhang))
                    {
                        MessageBox.Show($"Đã tạo thành công ! với mã khách hàng : {khachhang.MaKH1} và mật khẩu mặc định là 123");
                        txtHoTenKhachHangMoi.Text = "";
                        txtCMNDKhachHangMoi.Text = "";
                        txtSDTKhachHangMoi.Text = "";
                        txtDiaChiKhachHangMoi.Text = "";
                        txtNgaySinhKhachHangMoi.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Tạo thất bại !");
                    }
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng !");
                }
            }
        }
        private void btnNhapMaKhachHangCanXoa_Click(object sender, EventArgs e)
        {
            if (txtNhapMaKhachHangCanXoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin !");
            }
            else
            {
                if (KhachHang_BUS.searchKHWithMaKH(txtNhapMaKhachHangCanXoa.Text) == null)
                {
                    MessageBox.Show($"Mã khách hàng {txtNhapMaKhachHangCanXoa.Text} không tồn tại !");
                    txtNhapMaKhachHangCanXoa.Text = "";
                }
                else if (KhachHang_BUS.searchKHWithMaKH(txtNhapMaKhachHangCanXoa.Text).TrangThai1 == 0)
                {
                    MessageBox.Show("Khách hàng này đã bị xóa !");
                    txtNhapMaKhachHangCanXoa.Text = "";
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Bạn chắc chắn muốn xóa KH {KhachHang_BUS.searchKHWithMaKH(txtNhapMaKhachHangCanXoa.Text).HoTen1}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (KhachHang_BUS.DeleteDataKhachHang(txtNhapMaKhachHangCanXoa.Text))
                        {
                            MessageBox.Show("Xóa thành công !");
                            txtNhapMaKhachHangCanXoa.Text = "";
                            KhachHang_BUS.getAllKhachHang();
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công !");
                        }
                    }
                }
            }
        }
        private void txtXacNhanXemThongTinKhachHang_Click(object sender, EventArgs e)
        {
            if (txtMaKhachHangCanXemThongTin.Text.Trim().Length != 0)
            {
                KhachHang khachhang = KhachHang_BUS.searchKHWithMaKH(txtMaKhachHangCanXemThongTin.Text.Trim());
                if (khachhang != null && khachhang.TrangThai1 == 0)
                {
                    MessageBox.Show("Khách hàng này đã bị xóa hoặc không tồn tại !");
                    txtMaKhachHangCanXemThongTin.Text = "";
                }
                else
                {
                    MessageBox.Show($"Mã khách hàng: {khachhang.MaKH1} \n\n" +
                        $"Họ tên: {khachhang.HoTen1}\n\n" +
                        $"Ngày sinh: {khachhang.NgaySinh1}\n\n" +
                        $"CMND: {khachhang.CMND1}\n\n" +
                        $"SDT: {khachhang.SDT1}\n\n" +
                        $"Địa chỉ: {khachhang.DiaChi1}\n\n" +
                        $"Điểm: {khachhang.Diem1}\n\n" +
                        $"Số lần đã đăng nhập: {khachhang.SoLanDangNhap1}\n\n" +
                        $"Tổng đơn hàng đã đặt: {khachhang.TongDonDaDat1}\n\n" +
                        $"Tổng số tiền đã chi: {khachhang.SoTienDaChi1}\n\n" +
                        $"Loại KH: {khachhang.LoaiKH1}\n\n");
                }
            }
        }
        #endregion

        #region * Xem DS
        private void btnXemDS_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(grFullHoaDon);
            lblDanhSachCacSP.Text = "THÔNG TIN CÁC DANH SÁCH";
            this.Controls.Remove(grThongTinAdmin);
            this.Controls.Remove(grFullSanPham);
            this.Controls.Remove(grFullNhanVien);
            this.Controls.Remove(grFullKhachHang);
            this.Controls.Add(grXemDS);
            dgvDanhSach.DataSource = null;
            cboLoc.Items.Clear();
            cboLoc.Text = "";
        }
        int loai = 0;
        private void btnDanhSachSanPham_Click(object sender, EventArgs e)
        {
            loai = 1;
            dgvDanhSach.DataSource = SanPham_BUS.getAllDataTable();
            cboLoc.Items.Clear(); cboLoc.Text = "";
            LinkedList<SanPham> listSanpham = SanPham_BUS.getAllSanPham();
            if (listSanpham != null)
            {
                for (LinkedListNode<SanPham> p = listSanpham.First; p != null; p = p.Next)
                {
                    if (KT_TrungCbo(p.Value.LoaiSP.ToString()) == false)
                    {
                        cboLoc.Items.Add(p.Value.LoaiSP);
                    }
                }
            }
        }
        private void btnDanhSachHoaDon_Click(object sender, EventArgs e)
        {
            loai = 2;
            dgvDanhSach.DataSource = HoaDon_BUS.getAllData();
            cboLoc.Items.Clear(); cboLoc.Text = "";
            LinkedList<HoaDon> listHoaDon = HoaDon_BUS.getAllHoaDon();
            if (listHoaDon != null)
            {
                for (LinkedListNode<HoaDon> p = listHoaDon.First; p != null; p = p.Next)
                {
                    if (KT_TrungCbo(p.Value.NgayLap1.ToString("dd/MM/yyyy").ToString()) == false)
                    {
                        cboLoc.Items.Add(p.Value.NgayLap1.ToString("MM/dd/yyyy").ToString());
                    }
                }
            }
        }
        private void btnDanhSachNhanVien_Click(object sender, EventArgs e)
        {
            loai = 3;
            dgvDanhSach.DataSource = NhanVien_BUS.getAllDataTable();
            cboLoc.Items.Clear(); cboLoc.Text = "";
            LinkedList<NhanVien> listNV = NhanVien_BUS.getAllNhanVien();
            if (listNV != null)
            {
                for (LinkedListNode<NhanVien> p = listNV.First; p != null; p = p.Next)
                {
                    if (KT_TrungCbo(p.Value.LoaiNV1.ToString()) == false)
                    {
                        cboLoc.Items.Add(p.Value.LoaiNV1.ToString());
                    }
                }
            }
        }
        private void btnDanhSachKhachHang_Click(object sender, EventArgs e)
        {
            loai = 4;
            dgvDanhSach.DataSource = KhachHang_BUS.getAllDataTable();
            cboLoc.Items.Clear(); cboLoc.Text = "";
            LinkedList<KhachHang> listKH = KhachHang_BUS.getAllKhachHang();
            if (listKH != null)
            {
                for (LinkedListNode<KhachHang> p = listKH.First; p != null; p = p.Next)
                {
                    if (KT_TrungCbo(p.Value.LoaiKH1) == false)
                    {
                        cboLoc.Items.Add(p.Value.LoaiKH1);
                    }
                }
            }
        }
        public bool KT_TrungCbo(string ma)
        {
            if (cboLoc.Items.Count == 0) return false;
            for (int i = 0; i < cboLoc.Items.Count; i++)
            {
                string maCbo = "";
                try
                {
                    maCbo = Convert.ToDateTime(cboLoc.Items[i].ToString()).ToString("dd/MM/yyyy");
                }
                catch
                {
                    maCbo = cboLoc.Items[i].ToString();
                }
                if (String.Compare(ma, maCbo) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (loai == 1) // Tìm kiếm theo sản phẩm:
            {
                dgvDanhSach.DataSource = SanPham_BUS.SearchOnMaSP(txtTimKiem.Text);
            }
            else if (loai == 2)//Tìm kiếm theo hóa đơn:
            {
                dgvDanhSach.DataSource = HoaDon_BUS.SearchOnMaHD(txtTimKiem.Text);
            }
            else if (loai == 3)//Tìm kiếm theo nhân viên:
            {
                dgvDanhSach.DataSource = NhanVien_BUS.SearchOnMaNV(txtTimKiem.Text);
            }
            else if (loai == 4) // Tìm kiếm theo khách hàng:
            {
                dgvDanhSach.DataSource = KhachHang_BUS.SearchOnMaKH(txtTimKiem.Text);
            }
        }
        private void btnXoaTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            if (loai == 1) // Tìm kiếm theo sản phẩm:
            {
                dgvDanhSach.DataSource = SanPham_BUS.getAllDataTable();
            }
            else if (loai == 2) // Tìm kiếm theo hóa đơn:
            {
                dgvDanhSach.DataSource = HoaDon_BUS.getAllData();
            }
            else if (loai == 3)//Tìm kiếm theo nhân viên:
            {
                dgvDanhSach.DataSource = NhanVien_BUS.getAllDataTable();
            }
            else if (loai == 4) // Tìm kiếm theo khách hàng:
            {
                dgvDanhSach.DataSource = KhachHang_BUS.getAllDataTable();
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
        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loai == 1) // Tìm kiếm theo sản phẩm:
            {
                dgvDanhSach.DataSource = SanPham_BUS.LocSanPham(cboLoc.Text);
            }
            else if (loai == 2)//Tìm kiếm theo hóa đơn:
            {
                dgvDanhSach.DataSource = HoaDon_BUS.LocHoaDon(Convert.ToDateTime(cboLoc.Text));
            }
            else if (loai == 3)//Tìm kiếm theo nhân viên:
            {
                dgvDanhSach.DataSource = NhanVien_BUS.LocNhanVien(cboLoc.Text);
            }
            else if (loai == 4) // Tìm kiếm theo khách hàng:
            {
                dgvDanhSach.DataSource = KhachHang_BUS.LocKhachHang(cboLoc.Text);
            }
        }
        #endregion

        #region * Hoa don
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            this.Controls.Add(grFullHoaDon);
            lblDanhSachCacSP.Text = "THÔNG TIN HÓA ĐƠN";
            this.Controls.Remove(grThongTinAdmin);
            this.Controls.Remove(grFullSanPham);
            this.Controls.Remove(grFullNhanVien);
            this.Controls.Remove(grFullKhachHang);
            this.Controls.Remove(grXemDS);
        }
        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            grFullHoaDon.Controls.Remove(grXoaHoaDon);
            grFullHoaDon.Controls.Add(grXemHoaDon);
            txtMaHoaDonCanXem.Text = "";
        }
        public static string mahd;
        public static LinkedList<string> listStringSP;
        private void btnNhapMaHoaDonCanXem_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDonCanXem.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn !", "Thông báo");
            }
            else
            {
                if (HoaDon_BUS.SearchHD(txtMaHoaDonCanXem.Text) != null)
                {
                    if (HoaDon_BUS.SearchHD(txtMaHoaDonCanXem.Text).TrangThai1 == 0)
                    {
                        MessageBox.Show("Hóa đơn này đã bị hủy !");
                        txtMaHoaDonCanXem.Text = "";
                    }
                    else
                    {
                        mahd = txtMaHoaDonCanXem.Text;
                        new frmXemHD().Show();
                        txtMaHoaDonCanXem.Text = "";
                    }


                }
                else
                {
                    MessageBox.Show("Hóa đơn không tồn tại !", "Thông báo");
                    txtMaHoaDonCanXem.Text = "";
                }
            }
        }
        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            grFullHoaDon.Controls.Remove(grXemHoaDon);
            grFullHoaDon.Controls.Add(grXoaHoaDon);
            txtMaHoaDonXoa.Text = "";
        }
        private void btnXacNhanXoaHoaDon_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDonXoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn", "Thông báo");
            }
            else
            {
                HoaDon hdXoa = HoaDon_BUS.SearchHD(txtMaHoaDonXoa.Text);
                if (hdXoa == null)
                {
                    MessageBox.Show("Hóa đơn không tồn tại !");
                    txtMaHoaDonXoa.Text = "";
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Bạn chắc chắn muốn xóa hóa đơn {hdXoa.MaHD1}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                    if (result == DialogResult.Yes)
                    {
                        if (HoaDon_BUS.XoaHoaDon(txtMaHoaDonXoa.Text))
                        {
                            if (hdXoa.TrangThai1 == 0)
                            {
                                MessageBox.Show("Đã xóa hóa đơn này vào lần trước !", "Thông báo");
                            }
                            else
                            {
                                MessageBox.Show("Xóa thành công ");
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region * Report
        private void btnreportSanPham_Click(object sender, EventArgs e)
        {
            new frmReportSanPham().Show();
        }
        private void btnreportHoaDon_Click(object sender, EventArgs e)
        {
            new frmReportHoaDon().Show();
        }
        private void btnreportNhanVien_Click(object sender, EventArgs e)
        {
            new frmReportNhanVien().Show();
        }
        private void btnreportKhachHang_Click(object sender, EventArgs e)
        {
            new frmReportKhachHang().Show();
        }
        #endregion

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (loai == 1) // Tìm kiếm theo sản phẩm:
            {
                dgvDanhSach.DataSource = SanPham_BUS.SearchOnMaSP(txtTimKiem.Text);
            }
            else if (loai == 2)//Tìm kiếm theo hóa đơn:
            {
                dgvDanhSach.DataSource = HoaDon_BUS.SearchOnMaHD(txtTimKiem.Text);
            }
            else if (loai == 3)//Tìm kiếm theo nhân viên:
            {
                dgvDanhSach.DataSource = NhanVien_BUS.SearchOnMaNV(txtTimKiem.Text);
            }
            else if (loai == 4) // Tìm kiếm theo khách hàng:
            {
                dgvDanhSach.DataSource = KhachHang_BUS.SearchOnMaKH(txtTimKiem.Text);
            }
        }

        private void btnBaoCaoDoanhThuCuaTungLoaiSanPham_Click(object sender, EventArgs e)
        {
            new frmReportDoanhThuSanPham().Show();
        }
        public bool KT_SDT(string sdt)
        {
            bool isNumeric = true;
            foreach (char c in sdt)
            {
                if (!Char.IsNumber(c))
                {
                    isNumeric = false;
                    break;
                }
            }
            return isNumeric;
        }
    }
}