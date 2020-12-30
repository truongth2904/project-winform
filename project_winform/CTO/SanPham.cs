using System;

namespace project_winform.CTO
{
    public class SanPham
    {
        private string maSP;
        private string tenSP;
        private int soLuong;
        private DateTime ngayNhap;
        private double giaNhap;
        private double giaBan;
        private double giamGia;
        private int soLuongBanRa;
        private string loaiSP;
        private int trangThai;

        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
        public double GiamGia { get => giamGia; set => giamGia = value; }
        public int SoLuongBanRa { get => soLuongBanRa; set => soLuongBanRa = value; }
        public string LoaiSP { get => loaiSP; set => loaiSP = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public double GiaNhap { get => giaNhap; set => giaNhap = value; }

        public SanPham()
        {
            this.maSP = "";
            this.tenSP = "";
            this.soLuong = 0;
            this.ngayNhap = new DateTime();
            this.giaNhap = 0;
            this.giaBan = 0;
            this.giamGia = 0;
            this.soLuongBanRa = 0;
            this.loaiSP = "";
            this.trangThai = -1;
        }
        public SanPham(string maSP, string tenSP, int soLuong, DateTime ngayNhap, double giaNhap, double giaBan, double giamGia, int soLuongBanRa, string loaiSP, int trangThai)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.soLuong = soLuong;
            this.ngayNhap = ngayNhap;
            this.giaNhap = giaNhap;
            this.giaBan = giaBan;
            this.giamGia = giamGia;
            this.soLuongBanRa = soLuongBanRa;
            this.loaiSP = loaiSP;
            this.trangThai = trangThai;
        }
    }
}
