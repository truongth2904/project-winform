using System;

namespace project_winform.CTO
{
    public class NhanVien
    {
        private string _username;
        private string _password;
        private string MaNV;
        private string HoTen;
        private DateTime NgaySinh;
        private string CMND;
        private string SDT;
        private string DiaChi;
        private int SoLanDangNhap;
        private int SoHoaDonDaLap;
        private double LuongCB;
        private string LoaiNV;
        private int TrangThai;

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string MaNV1 { get => MaNV; set => MaNV = value; }
        public string HoTen1 { get => HoTen; set => HoTen = value; }
        public DateTime NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string CMND1 { get => CMND; set => CMND = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public int SoLanDangNhap1 { get => SoLanDangNhap; set => SoLanDangNhap = value; }
        public int SoHoaDonDaLap1 { get => SoHoaDonDaLap; set => SoHoaDonDaLap = value; }
        public double LuongCB1 { get => LuongCB; set => LuongCB = value; }
        public string LoaiNV1 { get => LoaiNV; set => LoaiNV = value; }
        public int TrangThai1 { get => TrangThai; set => TrangThai = value; }

        public NhanVien()
        {
            this._username = "";
            this._password = "";
            this.MaNV = "";
            this.HoTen = "";
            this.NgaySinh = new DateTime();
            this.CMND = "";
            this.SDT = "";
            this.DiaChi = "";
            this.SoLanDangNhap = 0;
            this.SoHoaDonDaLap = 0;
            this.LuongCB = 0;
            this.LoaiNV = "";
            this.TrangThai = 0;
        }
        public NhanVien(string _username, string _password, string MaNV, string HoTen, DateTime NgaySinh, string CMND, string SDT, string DiaChi, int SoLanDangNhap, int SoHoaDonDaLap, double LuongCB, string LoaiNV, int TrangThai)
        {
            this._username = _username;
            this._password = _password;
            this.MaNV = MaNV;
            this.HoTen = HoTen;
            this.NgaySinh = NgaySinh;
            this.CMND = CMND;
            this.SDT = SDT;
            this.DiaChi = DiaChi;
            this.SoLanDangNhap = SoLanDangNhap;
            this.SoHoaDonDaLap = SoHoaDonDaLap;
            this.LuongCB = LuongCB;
            this.LoaiNV = LoaiNV;
            this.TrangThai = TrangThai;
        }
    }
}
