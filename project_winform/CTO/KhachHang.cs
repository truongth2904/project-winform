using System;

namespace project_winform.CTO
{
    public class KhachHang
    {
        private string _username;
        private string _password;
        private string MaKH;
        private string HoTen;
        private DateTime NgaySinh;
        private string CMND;
        private string SDT;
        private string DiaChi;
        private int Diem;
        private int SoLanDangNhap;
        private double SoTienDaChi;
        private int TongDonDaDat;
        private string LoaiKH;
        private int TrangThai;

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string MaKH1 { get => MaKH; set => MaKH = value; }
        public string HoTen1 { get => HoTen; set => HoTen = value; }
        public DateTime NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string CMND1 { get => CMND; set => CMND = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public int Diem1 { get => Diem; set => Diem = value; }
        public int SoLanDangNhap1 { get => SoLanDangNhap; set => SoLanDangNhap = value; }
        public double SoTienDaChi1 { get => SoTienDaChi; set => SoTienDaChi = value; }
        public int TongDonDaDat1 { get => TongDonDaDat; set => TongDonDaDat = value; }
        public string LoaiKH1 { get => LoaiKH; set => LoaiKH = value; }
        public int TrangThai1 { get => TrangThai; set => TrangThai = value; }


        public KhachHang()
        {
            this._username = "";
            this._password = "";
            this.MaKH = "";
            this.HoTen = "";
            this.NgaySinh = new DateTime();
            this.CMND = "";
            this.SDT = "";
            this.DiaChi = "";
            this.Diem = 0;
            this.SoLanDangNhap = 0;
            this.SoTienDaChi = 0;
            this.TongDonDaDat = 0;
            this.LoaiKH = "";
            this.TrangThai = 0;
        }
        public KhachHang(string _username, string _password, string MaKH, string HoTen, DateTime NgaySinh, string CMND, string SDT, string DiaChi, int Diem, int SoLanDangNhap, double SoTienDaChi, int TongDonDaDat, string LoaiKH, int TrangThai)
        {
            this._username = _username;
            this._password = _password;
            this.MaKH = MaKH;
            this.HoTen = HoTen;
            this.NgaySinh = NgaySinh;
            this.CMND = CMND;
            this.SDT = SDT;
            this.DiaChi = DiaChi;
            this.Diem = Diem;
            this.SoLanDangNhap = SoLanDangNhap;
            this.SoTienDaChi = SoTienDaChi;
            this.TongDonDaDat = TongDonDaDat;
            this.LoaiKH = LoaiKH;
            this.TrangThai = TrangThai;
        }
    }
}
