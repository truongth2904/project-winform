using System;

namespace project_winform.CTO
{
    class HoaDon
    {
        private string MaHD;
        private string MaNV;
        private string MaKH;
        private DateTime NgayLap;
        private string GhiChu;
        private int TrangThai;
        private string MaVC_PT;
        private string MaVC_GT;
        private double GiaTriHD;

        public string MaHD1 { get => MaHD; set => MaHD = value; }
        public string MaNV1 { get => MaNV; set => MaNV = value; }
        public string MaKH1 { get => MaKH; set => MaKH = value; }
        public DateTime NgayLap1 { get => NgayLap; set => NgayLap = value; }
        public string GhiChu1 { get => GhiChu; set => GhiChu = value; }
        public int TrangThai1 { get => TrangThai; set => TrangThai = value; }
        public string MaVC_PT1 { get => MaVC_PT; set => MaVC_PT = value; }
        public string MaVC_GT1 { get => MaVC_GT; set => MaVC_GT = value; }
        public double GiaTriHD1 { get => GiaTriHD; set => GiaTriHD = value; }
        public HoaDon()
        {
            this.MaHD = "";
            this.MaNV = "";
            this.MaKH = "";
            this.NgayLap = new DateTime();
            this.GhiChu = "";
            this.TrangThai = -1;
            this.GiaTriHD = 0;
        }
        public HoaDon(string MaHD, string MaNV, string MaKH, DateTime NgayLap, string GhiChu, int TrangThai,  double GiaTriHD)
        {
            this.MaHD = MaHD;
            this.MaNV = MaNV;
            this.MaKH = MaKH;
            this.NgayLap = NgayLap;
            this.GhiChu = GhiChu;
            this.TrangThai = TrangThai;
         
            this.GiaTriHD = GiaTriHD;
        }
    }
}
