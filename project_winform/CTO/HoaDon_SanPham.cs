namespace project_winform.CTO
{
    class HoaDon_SanPham
    {
        private string MaSP;
        private string MaHD;
        private int SoLuong;

        public string MaSP1 { get => MaSP; set => MaSP = value; }
        public string MaHD1 { get => MaHD; set => MaHD = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public HoaDon_SanPham()
        {
            this.MaSP = "";
            this.MaHD = "";
            this.SoLuong = 0;
        }
        public HoaDon_SanPham(string MaSP, string MaHD, int SoLuong)
        {
            this.MaSP = MaSP;
            this.MaHD = MaHD;
            this.SoLuong = SoLuong;
        }
    }
}
