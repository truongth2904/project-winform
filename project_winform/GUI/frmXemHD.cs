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
    public partial class frmXemHD : Form
    {
        public frmXemHD()
        {
            InitializeComponent();
        }
        private void frmXemHD_Load(object sender, EventArgs e)
        {
            
            LinkedList<HoaDon_SanPham> listSP = HoaDon_SanPham_BUS.getAllSanPhamInHoaDon(frmAdmin.mahd.ToString());
            HoaDon hoadon = HoaDon_BUS.SearchHD(frmAdmin.mahd.ToString());
            NhanVien nhanvien = NhanVien_BUS.getNhanVienWithMaNV(hoadon.MaNV1.ToString());
            KhachHang khachhang = KhachHang_BUS.searchKHWithMaKH(hoadon.MaKH1);

            txtNgayLapHoaDon.Text = hoadon.NgayLap1.ToString();
            txtNhanVienLapHoaDon.Text = nhanvien.HoTen1;
            txtMaNhanVienLapHoaDon.Text = hoadon.MaNV1.ToString();
            listView1.Columns.Add("MaSP", 120);
            listView1.Columns.Add("Tên SP", 100);
            listView1.Columns.Add("Giá bán", 50);
            listView1.Columns.Add("Số lượng", 60);
            listView1.Columns.Add("Tổng tiền", 50);
            listView1.GridLines = true;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            for (LinkedListNode<HoaDon_SanPham> p = listSP.First; p != null; p = p.Next)
            {
                SanPham sp = SanPham_BUS.getDataSanPhamWithMaSP(p.Value.MaSP1);
                string[] arr = new string[5];
                arr[0] = p.Value.MaSP1.ToString();
                arr[1] = sp.TenSP;
                arr[2] = (sp.GiaBan - (sp.GiaBan * sp.GiamGia) / 100).ToString();
                arr[3] = p.Value.SoLuong1.ToString();
                arr[4] = (Convert.ToDouble(p.Value.SoLuong1) * Convert.ToDouble(arr[2])).ToString();
                ListViewItem item = new ListViewItem(arr);
                listView1.Items.Add(item);
            }
            txtTongTien.Text = hoadon.GiaTriHD1.ToString();
            txtSoLuongHang.Text = listSP.Count.ToString();
            txtMaKH.Text = khachhang.MaKH1;
            txtHoTenKhachHang.Text = khachhang.HoTen1;
            txtMaHD.Text = hoadon.MaHD1;
            Barcode barcode = new Barcode();
            Color forecolor = Color.Black;
            Color backcolor = Color.Transparent;
            Image img = barcode.Encode(TYPE.CODE128, txtMaHD.Text, forecolor, backcolor, (int)(pictureBox1.Width * 0.8), (int)(pictureBox1.Height * 0.8));
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
           
        }
    }
}