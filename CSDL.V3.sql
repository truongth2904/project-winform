CREATE DATABASE QLSieuThi_;

CREATE TABLE ADMIN_(
_username nvarchar(50) NOT NULL,
_password nvarchar(50) NOT NULL,
MaAD nvarchar(20) NOT NULL,
HoTen nvarchar(100),
NgaySinh date,
CMND nvarchar(20),
SDT nvarchar(10),
DiaChi nvarchar(300),
TrangThai tinyint
PRIMARY KEY (MaAD)
)
CREATE TABLE NHANVIEN(
_username nvarchar(50) NOT NULL,
_password nvarchar(50) NOT NULL,
MaNV nvarchar(20) NOT NULL,
HoTen nvarchar(100),
NgaySinh date,
CMND nvarchar(20),
SDT nvarchar(10),
DiaChi nvarchar(300),
SoLanDangNhap int,
SoHoaDonDaLap int,
LuongCB real,
LoaiNV nvarchar(20),
TrangThai tinyint
PRIMARY KEY (MaNV)
)
CREATE TABLE KHACHHANG(
_username nvarchar(50) NOT NULL,
_password nvarchar(50) NOT NULL,
MaKH nvarchar(20) NOT NULL,
HoTen nvarchar(100),
NgaySinh date,
CMND nvarchar(20),
SDT nvarchar(10),
DiaChi nvarchar(300),
Diem int,
SoLanDangNhap int,
SoTienDaChi real,
TongDonDaDat int,
LoaiKH nvarchar(20),
TrangThai tinyint
PRIMARY KEY (MaKH)
)
CREATE TABLE HOADON(
MaHD nvarchar(20)NOT NULL,
MaNV nvarchar(20)NOT NULL,
MaKH nvarchar(20),
NgayLap date,
GhiChu nvarchar(200),
TrangThai tinyint,
GiaTriHD real,
PRIMARY KEY (MaHD)
)
CREATE TABLE SANPHAM(
MaSP nvarchar(20)NOT NULL,
TenSP nvarchar(50),
SoLuong int,
NgayNhap date,
GiaNhap real,
GiaBan real,
GiamGia real,
SoLuongBanRa int,
LoaiSP nvarchar(50),
TrangThai tinyint
PRIMARY KEY (MaSP)
)
CREATE TABLE HOADON_SANPHAM(
MaSP nvarchar(20)NOT NULL,
MaHD nvarchar(20)NOT NULL,
SoLuong int
PRIMARY KEY (MaSP,MaHD)
)
ALTER TABLE HOADON
ADD CONSTRAINT PK_01 FOREIGN KEY (MaKH)REFERENCES KHACHHANG;
ALTER TABLE HOADON
ADD CONSTRAINT PK_02 FOREIGN KEY (MaNV)REFERENCES NHANVIEN;
ALTER TABLE HOADON_SANPHAM
ADD CONSTRAINT PK_05 FOREIGN KEY (MaHD)REFERENCES HOADON;
ALTER TABLE HOADON_SANPHAM
ADD CONSTRAINT PK_06 FOREIGN KEY (MaSP)REFERENCES SANPHAM;
INSERT INTO SANPHAM(MaSP,TenSP,GiaBan,GiaNhap,GiamGia,NgayNhap,SoLuong,SoLuongBanRa,LoaiSP,TrangThai) 
VALUES ('SP2020000001',N'Thịt bò',400000,330000,0.00,'2020-01-01',1000,0,N'Tươi sống',1),
 ('SP2020000002',N'Cua Hoàng Đế',1000000,800000,0.00,'2020-01-02',10000,0,N'Tươi sống',1),
 ('SP2020000003',N'Tôm càng xanh',500000,400000,0.00,'2020-01-01',10000,0,N'Tươi sống',1),
 ('SP2020000004',N'Mực ống',600000,450000,0.00,'2020-01-03',1000,0,N'Tươi sống',1),
 ('SP2020000005',N'Tôm hùng',900000,700000,0.00,'2020-01-03',10000,0,N'Tươi sống',1),
 ('SP2020000006',N'Cá chim',200000,150000,0.00,'2020-01-03',1000,0,N'Tươi sống',1),
 ('SP2020000007',N'Ốc bưu',60000,45000,0.00,'2020-01-02',10000,0,N'Tươi sống',1),
 ('SP2020000008',N'Ghẹ',300000,250000,0.00,'2020-01-03',10000,0,N'Tươi sống',1),
 ('SP2020000009',N'Hàu',100000,80000,0.00,'2020-01-03',1000,0,N'Tươi sống',1),
 ('SP2020000010',N'Ếch',150000,120000,0.00,'2020-01-03',1000,0,N'Tươi sống',1),
 ('SP2020000011',N'Điều Hòa Tosiba',6000000,5500000,0.00,'2020-01-04',1000,0,N'Công Nghệ',1),
 ('SP2020000012',N'Điều Hòa Daikin',5500000,4500000,0.00,'2020-01-04',1000,0,N'Công Nghệ',1),
 ('SP2020000013',N'TV Samsung',1200000,1000000,0.00,'2020-01-04',10000,0,N'Công Nghệ',1),
 ('SP2020000014',N'TV Sony',1500000,1200000,0.00,'2020-01-04',10000,0,N'Công Nghệ',1),
 ('SP2020000015',N'Quạt hơi nước Dakin',600000,450000,0.00,'2020-01-04',1000,0,N'Công Nghệ',1),
 ('SP2020000016',N'Quạt hơi nước Senko',500000,400000,0.00,'2020-01-04',10000,0,N'Công Nghệ',1),
 ('SP2020000017',N'laptop dell',12000000,11000000,0.00,'2020-01-04',10000,0,N'Công Nghệ',1),
 ('SP2020000018',N'laptop HP',16000000,14500000,0.00,'2020-01-04',1000,0,N'Công Nghệ',1),
 ('SP2020000019',N'Máy ảnh Canon',6000000,4500000,0.00,'2020-01-04',10000,0,N'Công Nghệ',1),
 ('SP2020000020',N'Máy ảnh Sony',7000000,6000000,0.00,'2020-01-04',1000,0,N'Công Nghệ',1),
 ('SP2020000021',N'Trà Xanh 0 độ',10000,8000,0.00,'2020-01-04',10000,0,N'Thực Phẩm',1),
 ('SP2020000022',N'Number 1',10000,8500,0.00,'2020-01-04',10000,0,N'Thực Phẩm',1),
 ('SP2020000023',N'Sữa TH truemilk',12000,10000,0.00,'2020-01-04',1000,0,N'Thực Phẩm',1),
 ('SP2020000024',N'Sữa Milo',15000,12000,0.00,'2020-01-04',1000,0,N'Thực Phẩm',1),
 ('SP2020000025',N'Xúc xính',9000,7000,0.00,'2020-01-04',10000,0,N'Thực Phẩm',1),
 ('SP2020000026',N'Cá hộp',20000,15000,0.00,'2020-01-04',100,0,N'Thực Phẩm',1),
 ('SP2020000027',N'Bánh mỳ',5000,3000,0.00,'2020-01-04',1000,0,N'Thực Phẩm',1),
 ('SP2020000028',N'Trứng gà',3000,2000,0.00,'2020-01-04',100,0,N'Thực Phẩm',1),
 ('SP2020000029',N'Trứng vịt',2500,1500,0.00,'2020-01-04',1000,0,N'Thực Phẩm',1),
 ('SP2020000030',N'Sữa Vinamilk',20000,18000,0.00,'2020-01-04',1000,0,N'Thực Phẩm',1),
 ('SP2020000031',N'Bếp gas',1200000,1000000,0.00,'2020-01-04',1000,0,N'Gia dụng',1),
 ('SP2020000032',N'Nước lau sàn',50000,45000,0.00,'2020-01-04',100,0,N'Gia dụng',1),
 ('SP2020000033',N'Chén Nhựa',3000,2000,0.00,'2020-01-04',100000,0,N'Gia dụng',1),
 ('SP2020000034',N'Nồi cơm điện',500000,480000,0.00,'2020-01-04',100,0,N'Gia dụng',1),
 ('SP2020000035',N'Bàn gỗ',450000,400000,0.00,'2020-01-04',1000,0,N'Gia dụng',1),
 ('SP2020000036',N'Ghế gỗ',80000,50000,0.00,'2020-01-04',10000,0,N'Gia dụng',1),
 ('SP2020000037',N'Đũa',10000,8000,0.00,'2020-01-04',1000,0,N'Gia dụng',1),
 ('SP2020000038',N'Chảo chống dính',200000,180000,0.00,'2020-01-04',100,0,N'Gia dụng',1),
 ('SP2020000039',N'Nồi cỡ nhỏ',50000,45000,0.00,'2020-01-04',1000,0,N'Gia dụng',1),
 ('SP2020000040',N'Bếp điện',450000,400000,0.00,'2020-01-04',1000,0,N'Gia dụng',1),
 ('SP2020000041',N'Nho',40000,35000,0.00,'2020-01-04',10000,0,N'Trái cây',1),
 ('SP2020000042',N'Táo',45000,40000,0.00,'2020-01-04',10000,0,N'Trái cây',1),
 ('SP2020000043',N'Cam',12000,10000,0.00,'2020-01-04',1000,0,N'Trái cây',1),
 ('SP2020000044',N'Bưởi',15000,12000,0.00,'2020-01-04',1000,0,N'Trái cây',1),
 ('SP2020000045',N'Ổi',9000,7000,0.00,'2020-01-04',10000,0,N'Trái cây',1),
 ('SP2020000046',N'Quýt',50000,45000,0.00,'2020-01-04',100,0,N'Trái cây',1),
 ('SP2020000047',N'Lựu',15000,13000,0.00,'2020-01-04',1000,0,N'Trái cây',1),
 ('SP2020000048',N'mận',30000,20000,0.00,'2020-01-04',100,0,N'Trái cây',1),
 ('SP2020000049',N'Xoài',15000,10000,0.00,'2020-01-04',1000,0,N'Trái cây',1),
 ('SP2020000050',N'Cóc',20000,18000,0.00,'2020-01-04',1000,0,N'Trái cây',1)
INSERT INTO NHANVIEN(MaNV,HoTen,CMND,NgaySinh,SDT,DiaChi,_username,_password,LoaiNV,LuongCB,SoHoaDonDaLap,SoLanDangNhap,TrangThai) 
VALUES ('NV2020NNT001',N'NGUYỄN NGỌC TRƯỜNG','456741258','2001-01-15','0392876666',N'THỦ ĐỨC','NV2020NNT001','123',N'Chính thức',4000000,0,0,1),
('NV2020PNM002',N'PHẠM NGỌC MINH','456741258','2001-02-15','0392965666',N'THỦ ĐỨC','NV2020PNM002','123',N'Chính thức',5000000,0,0,1),
('NV2020NQV003',N'NGUYỄN QUANG VINH','456741258','2001-03-15','0392874566',N'THỦ ĐỨC','NV2020NQV003','123',N'Thời vụ',3500000,0,0,1)
INSERT INTO KHACHHANG(MaKH,HoTen,CMND,SDT,NgaySinh,DiaChi,_username,_password,Diem,LoaiKH,SoLanDangNhap,SoTienDaChi,TongDonDaDat,TrangThai)
VALUES ('KH2020NNT001',N'NGUYỄN NGỌC TRƯỜNG','567854125','0392875555','2001-01-15',N'THỦ ĐỨC','KH2020NNT001','123',0,N'Đồng',0,0,0,1),
('KH2020PNM002',N'PHẠM NGỌC MINH','567854125','0392875555','2001-01-15',N'THỦ ĐỨC','KH2020PNM002','123',0,N'Vàng',0,0,0,1),
('KH2020NQV003',N'NGUYỄN QUANG VINH','567854125','0392875555','2001-01-15',N'THỦ ĐỨC','KH2020NQV003','123',0,N'Bạch kim',0,0,0,1)
INSERT INTO ADMIN_(MaAD,HoTen,CMND,DiaChi,NgaySinh,SDT,TrangThai,_username,_password)
VALUES 
('AD202001',N'NGUYỄN NGỌC TRƯỜNG','261581457',N'THỦ ĐỨC','2001-01-15','0392584551',1,'AD202001','123'),
('AD202002',N'PHẠM NGỌC MINH','261581457',N'THỦ ĐỨC','2001-01-12','0392584552',1,'AD202002','123'),
('AD202003',N'NGUYỄN QUANG VINH','261581457',N'THỦ ĐỨC','2001-01-18','0392584553',1,'AD202003','123'),
('AD202099',N'NGUYỄN QUANG VINH','',N'THỦ ĐỨC','2001-01-18','',1,'AD202003','')

go
--- Chinh sua thong tin cho Admin
CREATE PROCEDURE spChangeInFoAdmin
@MaAD nvarchar(20) ,
@_password nvarchar(50) ,
@HoTen nvarchar(100),
@NgaySinh date,
@CMND nvarchar(20),
@SDT nvarchar(10),
@DiaChi nvarchar(300),
@TrangThai tinyint AS
BEGIN
	update ADMIN_ 
	set _password = @_password,
	HoTen=	@HoTen ,
	NgaySinh	=@NgaySinh ,
	CMND	=@CMND ,
	SDT	=@SDT ,
	DiaChi=	@DiaChi,
	TrangThai=	@TrangThai 
	where MaAD=@MaAD
END 
GO
--- Thêm dữ liệu cho sản phẩm:
CREATE PROCEDURE spThemDataOnSanPham
@MaSP nvarchar(20),
@TenSP nvarchar(50),
@SoLuong int,
@NgayNhap date,
@GiaNhap real,
@GiaBan real,
@GiamGia real,
@SoLuongBanRa int,
@LoaiSP nvarchar(50),
@TrangThai tinyint as
begin
	INSERT INTO SANPHAM(MaSP,TenSP,GiaBan,GiaNhap,GiamGia,NgayNhap,SoLuong,SoLuongBanRa,LoaiSP,TrangThai) 
	VALUES    (@MaSP,@TenSP,@GiaBan,@GiaNhap,@GiamGia,@NgayNhap,@SoLuong,@SoLuongBanRa,@LoaiSP,@TrangThai)
end 
GO
--- Xóa dữ liệu cho sản phẩm:
CREATE PROCEDURE spDeleteSanPham
@MaSP nvarchar(20) as
begin 
	Update SANPHAM set 
	TrangThai = 0
	where MaSP=@MaSP;
end 
go
---Sửa dữ liệu cho sản phẩm:
CREATE PROCEDURE spUpdateSanPham
@MaSP nvarchar(20),
@TenSP nvarchar(50),
@GiaBan real,
@GiamGia real,
@LoaiSP nvarchar(50) as
begin
	Update SANPHAM set 
	TenSP= @TenSP,
	GiaBan= @GiaBan,
	GiamGia= @GiamGia,
	LoaiSP= @LoaiSP
	where MaSP=@MaSP;
end 
go
--- Update thêm cho sản phẩm:
CREATE PROCEDURE spNhapHangSanPham
@MaSP  nvarchar(20),
@SoLuong int as
begin
	Update SANPHAM set SoLuong = @SoLuong + SoLuong where MaSP = @MaSP
end 
GO
--- Thêm nhân viên:
CREATE PROCEDURE spInsertNhanVien
@_username nvarchar(50) ,
@_password nvarchar(50),
@MaNV nvarchar(20) ,
@HoTen nvarchar(100),
@NgaySinh date,
@CMND nvarchar(20),
@SDT nvarchar(10),
@DiaChi nvarchar(300),
@SoLanDangNhap int,
@SoHoaDonDaLap int,
@LuongCB real,
@LoaiNV nvarchar(20),
@TrangThai tinyint as
begin
	INSERT INTO NHANVIEN(MaNV,HoTen,CMND,NgaySinh,SDT,DiaChi,_username,_password,LoaiNV,LuongCB,SoHoaDonDaLap,SoLanDangNhap,TrangThai) 
				VALUES (@MaNV,@HoTen,@CMND,@NgaySinh,@SDT,@DiaChi,@_username,@_password,@LoaiNV,@LuongCB,@SoHoaDonDaLap,@SoLanDangNhap,@TrangThai)
end 
GO
--- Cập nhật Nhân viên
CREATE PROCEDURE spUpdateNhanVien
@MaNV nvarchar(20),
@_password nvarchar(50),
@HoTen nvarchar(100),
@SDT nvarchar(10),
@DiaChi nvarchar(300),
@LuongCB real,
@LoaiNV nvarchar(20),
@TrangThai tinyint as
begin
	update NHANVIEN set 
	_password = @_password,
	HoTen=@HoTen,
	SDT = @SDT,
	DiaChi=@DiaChi,
	LuongCB = @LuongCB,
	LoaiNV = @LoaiNV,
	TrangThai  = @TrangThai
	where MaNV = @MaNV
end 
GO
--- Xóa nhân viên
CREATE PROCEDURE spDeleteNhanVien
@MaNV nvarchar(20) as
begin 
update NHANVIEN set 
TrangThai = 0
where MaNV =@MaNV
end 
GO
---Thêm khách hàng: 
CREATE PROCEDURE spInsertDataKhachHang
@_username nvarchar(50) ,
@_password nvarchar(50) ,
@MaKH nvarchar(20) ,
@HoTen nvarchar(100),
@NgaySinh date,
@CMND nvarchar(20),
@SDT nvarchar(10),
@DiaChi nvarchar(300),
@Diem int,
@SoLanDangNhap int,
@SoTienDaChi real,
@TongDonDaDat int,
@LoaiKH nvarchar(20),
@TrangThai tinyint as
begin
	INSERT INTO KHACHHANG(MaKH,HoTen,CMND,SDT,NgaySinh,DiaChi,_username,_password,Diem,LoaiKH,SoLanDangNhap,SoTienDaChi,TongDonDaDat,TrangThai)
	VALUES (@MaKH,@HoTen,@CMND,@SDT,@NgaySinh,@DiaChi,@_username,@_password,@Diem,@LoaiKH,@SoLanDangNhap,@SoTienDaChi,@TongDonDaDat,@TrangThai)
end 
GO
--- Xoa khach hang:
CREATE PROCEDURE spDeleteDataKhachHang
@MaKH nvarchar(20) as
begin 
	update KHACHHANG set TrangThai = 0 where MaKH=@MaKH
end 
GO
--- Update khách hàng
CREATE PROCEDURE spUpdateDataKhachHang
@_password nvarchar(50) ,
@MaKH nvarchar(20) ,
@HoTen nvarchar(100),
@NgaySinh date,
@CMND nvarchar(20),
@SDT nvarchar(10),
@DiaChi nvarchar(300),
@LoaiKH nvarchar(20),
@TrangThai tinyint as
begin
	update KHACHHANG set
	_password=@_password,
	HoTen = @HoTen,
	NgaySinh=@NgaySinh,
	CMND  =@CMND,
	SDT=@SDT,
	DiaChi=@DiaChi,
	LoaiKH=@LoaiKH,
	TrangThai=@TrangThai
	where MaKH=@MaKH
end 
GO
--- Tìm kiếm sản phẩm:
CREATE PROCEDURE sp_SearchOnMaSP
@MaSP nvarchar(20) AS
BEGIN
	SELECT * FROM SANPHAM WHERE SANPHAM.TenSP LIKE @MaSP + '%'
END 
GO
--- Tìm kiếm hóa đơn
CREATE PROCEDURE sp_SearchOnMaHD
@MaHD nvarchar(20) as
BEGIN 
	SELECT * FROM HOADON WHERE HOADON.MaHD LIKE @MaHD + '%'
END 
GO
---Tìm kiếm nhân viên:
CREATE PROCEDURE sp_SearchOnMaNV
@MaNV nvarchar(20) as
BEGIN 
	SELECT * FROM NHANVIEN WHERE NHANVIEN.HoTen LIKE @MaNV + '%'
END 
GO
---Tìm kiếm khách hàng
CREATE PROCEDURE sp_SearchOnMaKH
@MaKH nvarchar(20) as
BEGIN 
	SELECT * FROM KHACHHANG WHERE KHACHHANG.HoTen LIKE @MaKH + '%'
END 
GO
--- Thêm hóa đơn:
CREATE PROCEDURE sp_ThemHoaDon
@MaHD nvarchar(20),
@MaNV nvarchar(20),
@MaKH nvarchar(20),
@NgayLap date,
@GhiChu nvarchar(200),
@TrangThai tinyint,
@GiaTriHD real as
begin
	insert into HOADON(GhiChu,GiaTriHD,MaHD,MaKH,MaNV,NgayLap,TrangThai)
	values (@GhiChu,@GiaTriHD,@MaHD,@MaKH,@MaNV,@NgayLap,@TrangThai)
end 
GO
--- thêm sản phẩm vào hóa đơn:
CREATE PROCEDURE sp_ThemSanPhamHoaDon
@MaSP nvarchar(20),
@MaHD nvarchar(20),
@SoLuong int as
begin 
	insert into HOADON_SANPHAM(MaHD,MaSP,SoLuong) values (@MaHD,@MaSP,@SoLuong)
end 
GO
--- xoa san pham trong hoa don:
CREATE PROCEDURE sp_XoaSanPhamHoaDon
@MaSP nvarchar(20),
@MaHD nvarchar(20) as
begin 
	delete  from HOADON_SANPHAM where MaHD=@MaHD and MaSP=@MaSP
end 
GO
--- update số lượng sản phaamt trong hóa đơn:
CREATE PROCEDURE sp_UpdateSanPhamHoaDon
@MaSP nvarchar(20),
@MaHD nvarchar(20),
@SoLuong int as
begin 
	update HOADON_SANPHAM set  SoLuong=@SoLuong where MaSP=@MaSP and MaHD=@MaHD
end 
GO
--- update khach hang thêm 1 hóa đơn:
CREATE PROCEDURE spUpdateKhachHangHoaDon
@MaKH nvarchar(20) ,
@Diem int,
@SoLanDangNhap int,
@SoTienDaChi real,
@TongDonDaDat int,
@LoaiKH nvarchar(20) as
begin
	update KHACHHANG set
	Diem = @Diem,
	SoLanDangNhap=@SoLanDangNhap,
	SoTienDaChi=@SoTienDaChi,
	TongDonDaDat=@TongDonDaDat,
	LoaiKH=@LoaiKH
	where MaKH=@MaKH
end 
GO
---update nhân viên thêm 1 hóa đơn 
CREATE PROCEDURE spUpdateNhanVienHoaDon
@MaNV nvarchar(20) ,
@SoLanDangNhap int,
@SoHoaDonDaLap int as
begin
	update NHANVIEN set SoLanDangNhap=@SoLanDangNhap,SoHoaDonDaLap=@SoHoaDonDaLap
	where MaNV=@MaNV
end 
GO
--- update san phảm thêm mục bán được
CREATE PROCEDURE spUpdateSanPhamHoaDon
@MaSP nvarchar(20),
@SoLuong int,
@SoLuongBanRa int as
begin
	update SANPHAM set
	 SoLuong=@SoLuong,
	 SoLuongBanRa =@SoLuongBanRa
	 where MaSP=@MaSP
end 
GO
--- Lọc các sản phẩm theo loại hàng:
CREATE PROCEDURE spLocSanPham
@LoaiSP nvarchar(50) as
begin
	select * from SANPHAM where SANPHAM.LoaiSP=@LoaiSP
end 
GO
---Lọc các hóa đơn theo ngày:
CREATE PROCEDURE spLocHoaDon
@NgayLap date as
begin
	select * from HOADON where HOADON.NgayLap=@NgayLap
end 
GO
---Lọc các nhân vien theo loại nhân viên
CREATE PROCEDURE spLocNhanVien
@LoaiNV nvarchar(20) as
begin
	select * from NHANVIEN where NHANVIEN.LoaiNV=@LoaiNV
end 
GO
--- Lọc các khách hàng the loại khách hàng
CREATE PROCEDURE spLocKhachHang
@LoaiKH nvarchar(20) as
begin
	select * from KHACHHANG where KHACHHANG.LoaiKH=@LoaiKH
end 
GO
--- Xóa hóa đơn theo mã hóa đơn: Update hóa đơn trạng thái ==0
CREATE PROCEDURE spXoaHoaDon
@MaHD nvarchar(20) as
begin
	update HOADON set TrangThai=0 where MaHD=@MaHD
end
go
--- Báo cáo tổng sản phẩm đã bán:
CREATE PROCEDURE spBaoCaoDoanhThuTuCacSP
as begin
SELECT LoaiSP, SUM(GiaBan*SoLuongBanRa) AS 'Tong' FROM  SANPHAM WHERE SANPHAM.SoLuongBanRa > 0 GROUP BY SANPHAM.LoaiSP
end