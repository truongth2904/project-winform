namespace project_winform.CTO
{
    class ThanhToan
    {
        private string MaTT;
        private string TenTT;

        public string MaTT1 { get => MaTT; set => MaTT = value; }
        public string TenTT1 { get => TenTT; set => TenTT = value; }
        public ThanhToan()
        {
            this.MaTT = "";
            this.TenTT = "";
        }
        public ThanhToan(string MaTT, string TenTT)
        {
            this.MaTT = MaTT;
            this.TenTT = TenTT;
        }
    }
}
