using System;

namespace project_winform.CTO
{
    public class Admin
    {
        private string _username;
        private string _password;
        private string MaAD;
        private string HoTen;
        private DateTime NgaySinh;
        private string CMND;
        private string SDT;
        private string DiaChi;
        private int TrangThai;


        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string MaAD1 { get => MaAD; set => MaAD = value; }
        public string HoTen1 { get => HoTen; set => HoTen = value; }
        public DateTime NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string CMND1 { get => CMND; set => CMND = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public int TrangThai1 { get => TrangThai; set => TrangThai = value; }
        public Admin(string _username, string _password, string MaAD, string HoTen, DateTime NgaySinh, string CMND, string SDT, string DiaChi, int TrangThai)
        {
            this.Username = _username;
            this.Password = _password;
            this.MaAD1 = MaAD;
            this.HoTen1 = HoTen;
            this.NgaySinh1 = NgaySinh;
            this.CMND1 = CMND;
            this.SDT1 = SDT;
            this.DiaChi1 = DiaChi;
            this.TrangThai1 = TrangThai;
        }
        public Admin()
        {
            this.Username = "";
            this.Password = "";
            this.MaAD1 = "";
            this.HoTen1 = "";
            this.NgaySinh1 = new DateTime();
            this.CMND1 = "";
            this.SDT1 = "";
            this.DiaChi1 = "";
            this.TrangThai1 = -1;
        }
    }
}
