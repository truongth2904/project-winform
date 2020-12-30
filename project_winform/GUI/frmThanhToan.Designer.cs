namespace project_winform
{
    partial class frmThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThanhToan));
            this.lblTienKhachPhaiTra = new System.Windows.Forms.Label();
            this.lblTienKhachDua = new System.Windows.Forms.Label();
            this.txtTienKhachDua = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTienKhachPhaiTra
            // 
            this.lblTienKhachPhaiTra.AutoSize = true;
            this.lblTienKhachPhaiTra.Location = new System.Drawing.Point(24, 33);
            this.lblTienKhachPhaiTra.Name = "lblTienKhachPhaiTra";
            this.lblTienKhachPhaiTra.Size = new System.Drawing.Size(46, 17);
            this.lblTienKhachPhaiTra.TabIndex = 0;
            this.lblTienKhachPhaiTra.Text = "label1";
            // 
            // lblTienKhachDua
            // 
            this.lblTienKhachDua.AutoSize = true;
            this.lblTienKhachDua.Location = new System.Drawing.Point(24, 73);
            this.lblTienKhachDua.Name = "lblTienKhachDua";
            this.lblTienKhachDua.Size = new System.Drawing.Size(126, 17);
            this.lblTienKhachDua.TabIndex = 0;
            this.lblTienKhachDua.Text = "Số tiền khách đưa:";
            // 
            // txtTienKhachDua
            // 
            this.txtTienKhachDua.Location = new System.Drawing.Point(180, 70);
            this.txtTienKhachDua.Name = "txtTienKhachDua";
            this.txtTienKhachDua.Size = new System.Drawing.Size(202, 22);
            this.txtTienKhachDua.TabIndex = 1;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(271, 131);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(111, 23);
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 198);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.txtTienKhachDua);
            this.Controls.Add(this.lblTienKhachDua);
            this.Controls.Add(this.lblTienKhachPhaiTra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThanhToan";
            this.Load += new System.EventHandler(this.frmThanhToan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTienKhachPhaiTra;
        private System.Windows.Forms.Label lblTienKhachDua;
        private System.Windows.Forms.TextBox txtTienKhachDua;
        private System.Windows.Forms.Button btnThanhToan;
    }
}