namespace project_winform
{
    partial class frmNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVien));
            this.lvwHangHoa = new System.Windows.Forms.ListView();
            this.pnlBackGround = new System.Windows.Forms.Panel();
            this.btnGuiMaHH = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblHoTenKH = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnGuiMaKH = new System.Windows.Forms.Button();
            this.txtMaHH = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblNhap = new System.Windows.Forms.Label();
            this.lblTongTienHang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnChucNang = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBackGround.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvwHangHoa
            // 
            this.lvwHangHoa.ForeColor = System.Drawing.Color.Black;
            this.lvwHangHoa.HideSelection = false;
            this.lvwHangHoa.Location = new System.Drawing.Point(110, 19);
            this.lvwHangHoa.Name = "lvwHangHoa";
            this.lvwHangHoa.Size = new System.Drawing.Size(1048, 323);
            this.lvwHangHoa.TabIndex = 42;
            this.lvwHangHoa.UseCompatibleStateImageBehavior = false;
            // 
            // pnlBackGround
            // 
            this.pnlBackGround.Controls.Add(this.btnGuiMaHH);
            this.pnlBackGround.Controls.Add(this.label7);
            this.pnlBackGround.Controls.Add(this.label5);
            this.pnlBackGround.Controls.Add(this.txtSoLuong);
            this.pnlBackGround.Controls.Add(this.lblHoTenKH);
            this.pnlBackGround.Controls.Add(this.btnThanhToan);
            this.pnlBackGround.Controls.Add(this.btnGuiMaKH);
            this.pnlBackGround.Controls.Add(this.txtMaHH);
            this.pnlBackGround.Controls.Add(this.txtMaKH);
            this.pnlBackGround.Controls.Add(this.lblNhap);
            this.pnlBackGround.Location = new System.Drawing.Point(110, 351);
            this.pnlBackGround.Name = "pnlBackGround";
            this.pnlBackGround.Size = new System.Drawing.Size(658, 221);
            this.pnlBackGround.TabIndex = 41;
            // 
            // btnGuiMaHH
            // 
            this.btnGuiMaHH.Location = new System.Drawing.Point(498, 78);
            this.btnGuiMaHH.Name = "btnGuiMaHH";
            this.btnGuiMaHH.Size = new System.Drawing.Size(75, 23);
            this.btnGuiMaHH.TabIndex = 10;
            this.btnGuiMaHH.Text = "Gửi";
            this.btnGuiMaHH.UseVisualStyleBackColor = true;
            this.btnGuiMaHH.Click += new System.EventHandler(this.btnGuiMaHH_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Nhập mã hàng hóa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(416, 81);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(34, 22);
            this.txtSoLuong.TabIndex = 7;
            // 
            // lblHoTenKH
            // 
            this.lblHoTenKH.AutoSize = true;
            this.lblHoTenKH.Location = new System.Drawing.Point(10, 192);
            this.lblHoTenKH.Name = "lblHoTenKH";
            this.lblHoTenKH.Size = new System.Drawing.Size(13, 17);
            this.lblHoTenKH.TabIndex = 6;
            this.lblHoTenKH.Text = "*";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThanhToan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThanhToan.Location = new System.Drawing.Point(473, 155);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(182, 38);
            this.btnThanhToan.TabIndex = 5;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnGuiMaKH
            // 
            this.btnGuiMaKH.Location = new System.Drawing.Point(246, 152);
            this.btnGuiMaKH.Name = "btnGuiMaKH";
            this.btnGuiMaKH.Size = new System.Drawing.Size(89, 29);
            this.btnGuiMaKH.TabIndex = 2;
            this.btnGuiMaKH.Text = "Gửi";
            this.btnGuiMaKH.UseVisualStyleBackColor = true;
            this.btnGuiMaKH.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // txtMaHH
            // 
            this.txtMaHH.Location = new System.Drawing.Point(13, 81);
            this.txtMaHH.Name = "txtMaHH";
            this.txtMaHH.Size = new System.Drawing.Size(292, 22);
            this.txtMaHH.TabIndex = 1;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(13, 155);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(204, 22);
            this.txtMaKH.TabIndex = 1;
            // 
            // lblNhap
            // 
            this.lblNhap.AutoSize = true;
            this.lblNhap.Location = new System.Drawing.Point(10, 127);
            this.lblNhap.Name = "lblNhap";
            this.lblNhap.Size = new System.Drawing.Size(147, 17);
            this.lblNhap.TabIndex = 0;
            this.lblNhap.Text = "Nhập mã khách hàng:";
            // 
            // lblTongTienHang
            // 
            this.lblTongTienHang.AutoSize = true;
            this.lblTongTienHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienHang.Location = new System.Drawing.Point(924, 392);
            this.lblTongTienHang.Name = "lblTongTienHang";
            this.lblTongTienHang.Size = new System.Drawing.Size(19, 20);
            this.lblTongTienHang.TabIndex = 48;
            this.lblTongTienHang.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(781, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Tổng tiền hàng:";
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThoat.Location = new System.Drawing.Point(976, 577);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(208, 32);
            this.btnThoat.TabIndex = 44;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnChucNang
            // 
            this.btnChucNang.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChucNang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChucNang.Location = new System.Drawing.Point(110, 578);
            this.btnChucNang.Name = "btnChucNang";
            this.btnChucNang.Size = new System.Drawing.Size(182, 32);
            this.btnChucNang.TabIndex = 43;
            this.btnChucNang.Text = "Chức năng";
            this.btnChucNang.UseVisualStyleBackColor = false;
            this.btnChucNang.Click += new System.EventHandler(this.btnChucNang_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(453, 581);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(413, 32);
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 639);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lvwHangHoa);
            this.Controls.Add(this.pnlBackGround);
            this.Controls.Add(this.lblTongTienHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnChucNang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNhanVien";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            this.pnlBackGround.ResumeLayout(false);
            this.pnlBackGround.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwHangHoa;
        private System.Windows.Forms.Panel pnlBackGround;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnGuiMaKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblNhap;
        private System.Windows.Forms.Label lblTongTienHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnChucNang;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblHoTenKH;
        private System.Windows.Forms.TextBox txtMaHH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnGuiMaHH;
    }
}