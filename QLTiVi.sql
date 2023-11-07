Create table HangSX (  
	MaHangSX nvarchar(10) NOT NULL PRIMARY KEY,
	TenHangSX nvarchar(200) NOT NULL
)
go

create table MauSac(
	MaMau nvarchar(10) NOT NULL PRIMARY KEY,
	TenMau nvarchar(100) NOT NULL
)
go

create table CoManHinh(
	MaCo nvarchar(10) NOT NULL PRIMARY KEY,
	TenCo nvarchar(200) NOT NULL
)
go

create table ManHinh(
	MaMH nvarchar(10) NOT NULL PRIMARY KEY,
	TenManHinh nvarchar(100) NOT NULL
)


create table NuocSX(
	MaNuocSX nvarchar(10) NOT NULL PRIMARY KEY,
	TenNuocSX nvarchar(100) NOT NULL
)
go

create table KieuDang(
	MaKieu nvarchar(10) NOT NULL PRIMARY KEY,
	TenKieu nvarchar(255) NOT NULL
)
go

create table DMTivi(
	 MaTV nvarchar(10) NOT NULL PRIMARY KEY,
	 TenTv nvarchar(50) NOT NULL,
	 DonGiaNhap int NOT NULL,
	 DonGiaBan int NOT NULL,
	 SoLuong int NOT NULL,
	 ThoiGianBH datetime NOT NULL,
	 MaHangSX nvarchar(10) NOT NULL,
	 MaKieu nvarchar(10) NOT NULL,
	 MaMau nvarchar(10) NOT NULL,
	 MaMH nvarchar(10) NOT NULL,
	 MaCo nvarchar(10) NOT NULL,
	 MaNuocSX nvarchar(10) NOT NULL
)
go

alter table DMTiVi 
ADD CONSTRAINT FK_MaHangSX
FOREIGN KEY (MaHangSX) REFERENCES HangSX(MaHangSX)

alter table DMTivi
ADD CONSTRAINT FK_MaKieu
foreign key (MaKieu) references KieuDang(MaKieu)


alter table DMTivi
ADD CONSTRAINT FK_MaMau
foreign key (MaMau) references MauSac(MaMau)


alter table DMTivi
ADD CONSTRAINT FK_MaMH
foreign key (MaMH) references ManHinh(MaMH)

alter table DMTivi
ADD CONSTRAINT FK_MaCo
foreign key (MaCo) references CoManHinh(MaCo)

alter table DMTivi
ADD CONSTRAINT FK_MaNuocSX
foreign key (MaNuocSX) references NuocSX(MaNuocSX)


create table CaLam(
	MaCa nvarchar(10) PRIMARY KEY NOT NULL,
	TenCa nvarchar(255) NOT NULL
)

create table CongViec(
	MaCV nvarchar(10) PRIMARY KEY NOT NULL,
	TenCV nvarchar(255) NOT NULL
)


create table KhachHang(
	MaKhach nvarchar(10) PRIMARY KEY NOT NULL,
	TenKhach nvarchar(255) NOT NULL,
	DiaChi nvarchar(255) NOT NULL,
	DienThoai varchar(11) NOT NULL
)

create table NhaCungCap(
	MaNCC nvarchar(10) PRIMARY KEY NOT NULL,
	TenNCC nvarchar(255) NOT NULL,
	Diachi nvarchar(255) NOT NULL,
	DienThoai varchar(11) NOT NULL
)

create table NhanVien(
	MaNV nvarchar(10) PRIMARY KEY NOT NULL,
	TenNV nvarchar(255) NOT NULL,
	GioiTinh nvarchar(10) NOT NULL,
	NgaySinh datetime NOT NULL,
	DienThoai varchar(11) NOT NULL,
	MaCa nvarchar(10) NOT NULL,
	MaCV nvarchar(10) NOT NULL,
	DiaChi nvarchar(255) NOT NULL
)


alter table NhanVien 
ADD CONSTRAINT FK_MaCa
FOREIGN KEY (Maca) REFERENCES CaLam(MaCa)


alter table NhanVien 
ADD CONSTRAINT FK_MaCV
FOREIGN KEY (MaCV) REFERENCES CongViec(MaCV)

create table HoaDonNhap(
	SoHDN nvarchar(10) PRIMARY KEY NOT NULL,
	MaNV nvarchar(10) NOT NULL,
	NgayNhap datetime NOT NULL,
	MaNCC nvarchar(10) NOT NULL,
	TongTien int 
)



alter table HoaDonNhap
ADD CONSTRAINT FK_MaNV
FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)


alter table HoaDonNhap
ADD CONSTRAINT FK_MaNCC
FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)


CREATE TABLE ChiTietHDN(
	SoHDN nvarchar(10) NOT NULL,
	MaTV nvarchar(10) NOT NULL,
	SoLuong int NOT NULL,
	DonGia int,
	GiamGia float NOT NULL,
	ThanhTien int,
    CONSTRAINT [PK_tChiTietHDN] PRIMARY KEY CLUSTERED 
(
	[SoHDN] ASC,
	[MaTV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


create table HoaDonBan(
	SoHDB nvarchar(10) PRIMARY KEY NOT NULL,
	MaNV nvarchar(10) NOT NULL ,
	MaKhach nvarchar(10) NOT NULL,
	NgayBan datetime NOT NULL,
	Thue float NOT NULL,
	TongTien int
)

alter table HoaDonBan
ADD CONSTRAINT FK_MaNV1
FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)

create table ChiTietHDB(
	SoHDB nvarchar(10) NOT NULL,
	MaTV nvarchar(10) NOT NULL,
	SoLuong int NOT NULL,
	GiamGia float NOT NULL,
	ThanhTien int,
	CONSTRAINT [PK_tChiTietHDB] PRIMARY KEY CLUSTERED 
(
	[SoHDB] ASC,
	[MaTV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

alter table CHiTietHDB
ADD CONSTRAINT FK_MaTV1
FOREIGN KEY (MaTV) REFERENCES DMTiVi(MaTV)


alter table CHiTietHDB
ADD CONSTRAINT FK_HDB
FOREIGN KEY (SoHDB) REFERENCES HoaDonBan(SoHDB)

alter table CHiTietHDN
ADD CONSTRAINT FK_MaTV2
FOREIGN KEY (MaTV) REFERENCES DMTiVi(MaTV)


alter table CHiTietHDN
ADD CONSTRAINT FK_HDN1
FOREIGN KEY (SoHDN) REFERENCES HoaDonNhap(SoHDN)

alter table HoaDonBan
ADD CONSTRAINT FK_MaKhach
FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach)


Insert into HangSX (MaHangSX,TenHangSX)
values 
	('HSX01','SAMSUNG'),
	('HSX02','LG'),
	('HSX03','SONY'),
	('HSX04','TOSHIBA')

insert into KieuDang (MaKieu, TenKieu)
values
	('MK01',N'Tivi Màn hình phẳng'),
	('MK02',N'Tivi Màn hình cong'),
	('MK03',N'Tivi Siêu mỏng'),
	('MK04',N'Tivi Không viền'),
	('MK05',N'Tivi Mini')

insert into NuocSX(MaNuocSX, TenNuocSX)
values
	('MN01',N'Việt Nam'),
	('MN02',N'Hàn Quốc'),
	('MN03',N'Trung Quốc'),
	('MN04',N'Nhật Bản'),
	('MN05',N'Mỹ'),
	('MN06',N'Pháp')

insert into CoManHinh(MaCo,TenCo)
values 
	('MC01','32 inch'),
	('MC02','43 inch'),
	('MC03','49 inch'),
	('MC04','55 inch'),
	('MC05','60 inch'),
	('MC06','65 inch'),
	('MC07','70 inch'),
	('MC08','75 inch'),
	('MC09','80 inch'),
	('MC10','85 inch')
insert into MauSac(MaMau,TenMau)
values
	('MM01',N'Đen'),
	('MM02',N'Trắng'),
	('MM03',N'Bạc'),
	('MM04',N'Hồng Gold'),
	('MM05',N'Đỏ'),
	('MM06',N'Lục'),
	('MM07',N'Vàng Gold'),
	('MM08',N'Tím'),
	('MM09',N'Xanh pastel')

insert into ManHinh(MaMH,TenManHinh)
values 
	('MH01','4K UHD'),
	('MH02','QLED'),
	('MH03','OLED'),
	('MH04','LCD'),
	('MH05','PLASMA'),
	('MH06','LED'),
	('MH07','HD')

insert into DMTivi(MaTV,TenTv,DonGiaNhap,DonGiaBan,SoLuong,ThoiGianBH,MaHangSX,MaKieu,MaMau,MaMH,MaCo,MaNuocSX)
values ('TV01','SS UHD',7650000,7950000,10,2020-08-21,'HSX01','MK01','MM05','MH01','MC02','MN01'),
	('TV02','SS SmartTV',12650000,12950000,5,2023-10-18,'HSX01','MK02','MM02','MH03','MC01','MN04'),
	('TV03','SS Led',10150000,10350000,15,2021-05-22,'HSX01','MK03','MM05','MH06','MC09','MN01'),
	('TV04','SS Qled',13050000,13250000	,11,2023-06-12,'HSX01','MK02','MM08','MH02','MC10','MN06'),
	('TV05','SS UA55',8750000,9010000,21,2022-09-20,'HSX01','MK02','MM09','MH01','MC02','MN04'),
	('TV06','SS NEO',11250000,11510000,18,2023-07-28,'HSX01','MK05','MM04','MH07','MC08','MN02'),
	('TV07','SS QA55',25750000,26199000,5,2023-12-21,'HSX01','MK04','MM02','MH07','MC10','MN01'),
	('TV08','SS 43AU',6480000,5199000,14,2022-12-15,'HSX01','MK04','MM05','MH02','MC04','MN06'),
	('TV09','LG QNED80',20900000,21990000,6,2023-06-18,'HSX02','MK01','MM01','MH05','MC06','MN01'),
	('TV10','LG UHD',18950000,19990000,3,2023-02-10,'HSX02','MK03','MM04','MH02','MC04','MN01'),
	('TV11','LG SmartTV',25110000,26990000,1,2022-05-01	,'HSX02','MK01','MM03','MH01','MC02','MN05'),
	('TV12','LG QLED',16550000,17690000,10,2023-06-22,'HSX02','MK02','MM05','MH03','MC06','MN04'),
	('TV13','SN QNED80',20900000,21990000,6,2023-06-18,'HSX03','MK05','MM01','MH05','MC04','MN01'),
	('TV14','SN UA55',9990000,1099000,6,2023-07-21,'HSX03','MK01','MM02','MH03','MC03','MN04'),	
	('TV15','SN UHD',19290000,20790000,4,2023-01-19,'HSX03','MK03','MM01','MH05','MC02','MN03'),
	('TV16','SN NEO',12950000,13990000,7,2023-12-02,'HSX03','MK05','MM05','MH01','MC04','MN02'),
	('TV17','SN Crystal',14910000,16190000,2,2022-10-25,'HSX03','MK03','MM04','MH02','MC03','MN05'),
	('TV18','TSB Casper',43900000,59900000,12,2023-07-15,'HSX04','MK05','MM03','MH05','MC06','MN01')




insert into CongViec(MaCV,TenCV)
values 
	('NVBH',N'Nhân viên bán hàng'),
	('NVKHO',N'Nhân viên nhập kho'),
	('NVTN',N'Nhân viên thu ngân')

insert into CaLam(MaCa,TenCa)
values 
	('ca1',N'Ca sáng'),
	('ca2',N'Ca chiều'),
	('ca3',N'Ca tối')


insert into NhaCungCap(MaNCC,TenNCC,Diachi,DienThoai)
values
	('NCC01','SamSung',N'99 Nguyễn Chí Thanh, Đống Đa, Hà Nội','0495729752'),
	('NCC02','SM smartLG',N'1 Bùi Xương Trạch, Thanh Xuân, Hà Nội','0379593721'),
	('NCC03','SONY SmartTiVi',N'23 Tạ Quang Bửu, Trần Đại Nghĩa,Hà Nội','0483846125'),
	('NCC04','TOSHIBA',N'6 Mỗ Lao, Hà Đông, Hà Nội','0989898582')

insert into KhachHang(MaKhach,TenKhach,DiaChi,DienThoai)
values
	('MK01',N'Bùi Thị Lan',N'Hà Nội','0865546382'),
	('MK02',N'Trần Minh Thu',N'	Hải Phòng','0894758244'),
	('MK03',N'Đinh Tiến Dũng',N'Hà Nội','0100284753'),
	('MK04',N'Mã Thị Mến',N'Thanh Hóa','0237400202'),
	('MK05',N'Đặng Đức Dũng',N'Hải Dương','0472759214'),
	('MK06',N'Dương Minh Phượng',N'Hà Nội','0583752771'),
	('MK07',N'Nguyễn Minh Đức',N'Đà Lạt','0347886428'),
	('MK08',N'Đặng Thái Hà',N'Sơn La','0357628711')

insert into NhanVien(MaNV,TenNV,GioiTinh,NgaySinh,DienThoai,MaCa,MaCV,DiaChi)
values
	('NV01',N'Trần Thị Hồng Hạnh',N'Nữ',2003-15-07,'0865564397','ca1','NVBH',N'Hà Nội'),
	('NV02',N'Lương Mỹ Thành','Nam',2006-02-03,'0911202567','ca2','NVBH',N'Hà Nội'),
	('NV03',N'Bùi Quang Anh','Nam',1998-12-02,'0845638191','ca1','NVKHO',N'Hưng Yên'),
	('NV04',N'Đinh Tiến Tùng','Nam',2001-01-17,'0495792648','ca3','NVBH',N'Thanh Hóa'),
	('NV05',N'Đặng Văn Lâm','Nam',2000-10-04,'0374821003','ca2','NVTN',N'Hải Dương'),
	('NV06',N'Nguyễn Hoài Lâm','Nam',2000-09-23,'0648292700','ca2','NVBH',N'Hà Nội'),
	('NV07',N'Phạm Đức Minh',N'Nữ',1997-03-16,'0563000371','ca1','NVTN',N'Hưng Yên'),
	('NV08',N'Bùi Tiến Đạt','Nam',1999-04-30,'0642926828','ca3','NVKHO',N'Hà Nội'),
	('NV09',N'Dương Minh Anh',N'Nữ',2003-05-05,'0994628411','ca3','NVBH',N'Thanh Hóa'),
	('NV10',N'Hà Văn San',N'Nữ',2004-07-24,'0862947104','ca2','NVBH',N'Bắc Ninh'),
	('NV11',N'Nguyễn Hữu Đức','Nam',2005-06-29,'0942749001','ca1','NVBH',N'Hải Dương'),
	('NV12',N'Đỗ Thu Thảo',N'Nữ',2001-12-23,'0783472811','ca3','NVTN',N'Bình Định'),
	('NV13',N'Trần Minh Tú',N'Nữ',1997-01-26,'0238472849','ca2','NVBH',N'Hải Phòng'),
	('NV14',N'Triệu Tiểu Vân',N'Nữ',1999-07-30,'0452846519','ca3','NVKHO',N'Hà Nội')


insert into HoaDonNhap(SoHDN,MaNV,NgayNhap,MaNCC,TongTien)
values
	('HDN01','NV03',2023-02-12,'NCC01',NULL),
	('HDN02','NV03',2023-02-12,'NCC02',NULL),
	('HDN03','NV08',2021-12-02,'NCC02',NULL),
	('HDN04','NV08',2021-12-02,'NCC03',NULL),
	('HDN05','NV14',2020-04-24,'NCC01',NULL),
	('HDN06','NV03',2020-07-19,'NCC03',NULL),
	('HDN07','NV14',2022-12-04,'NCC04',NULL),
	('HDN08','NV08',2024-03-15,'NCC03',NULL),
	('HDN09','NV14',2021-03-04,'NCC04',NULL)


insert into ChiTietHDN(SoHDN,MaTV,SoLuong,DonGia,GiamGia,ThanhTien)
values	
	('HDN01','TV01',10,NULL,0.1,NULL),
	('HDN01','TV02',20,NULL,0.2,NULL),
	('HDN01','TV03',15,NULL,0.15,NULL),
	('HDN01','TV04',16,NULL,0.15,NULL),
	('HDN02','TV10',10,NULL,0.1,NULL),
	('HDN02','TV11',10,NULL,0.1,NULL),
	('HDN03','TV12',5,NULL,0,NULL),
	('HDN03','TV10',5,NULL,0,NULL),
	('HDN04','TV13',10,NULL,0,NULL),
	('HDN04','TV14',4,NULL,0.1,NULL),
	('HDN04','TV15',13,NULL,0.05,NULL),
	('HDN05','TV05',12,NULL,0.1,NULL),
	('HDN05','TV06',15,NULL,0.15,NULL),
	('HDN05','TV07',10,NULL,0.1,NULL),
	('HDN06','TV17',10,NULL,0,NULL),
	('HDN07','TV18',20,NULL,0.1,NULL),
	('HDN08','TV16',10,NULL,0,NULL),
	('HDN08','TV15',10,NULL,0,NULL),
	('HDN08','TV17',5,NULL,0,NULL),
	('HDN09','TV18',15,NULL,0,NULL)
	
	

insert into HoaDonBan(SoHDB,MaNV,MaKhach,NgayBan,Thue,TongTien)
values
	('HD01','NV01','MK01',2023-02-23,0.1,NULL),
	('HD02','NV02','MK01',2023-04-02,0.1,NULL),
	('HD03','NV04','MK03',2021-04-09,0.1,NULL),
	('HD04','NV06','MK04',2022-12-05,0.1,NULL),
	('HD05','NV04','MK02',2023-06-26,0.1,NULL),
	('HD06','NV09','MK08',2022-01-23,0.1,NULL),
	('HD07','NV06','MK05',2022-05-28,0.1,NULL),
	('HD08','NV02','MK01',2020-12-09,0.1,NULL),
	('HD09','NV09','MK06',2020-04-04,0.1,NULL),
	('HD10','NV10','MK05',2021-09-03,0.1,NULL),
	('HD11','NV01','MK07',2023-12-09,0.1,NULL)

insert into ChiTietHDB(SoHDB,MaTV,SoLuong,GiamGia,ThanhTien)
values
	('HD01','TV01',2,0,NULL),
	('HD01','TV02',1,0,NULL),
	('HD01','TV03',1,0,NULL),
	('HD02','TV08',2,0,NULL),
	('HD02','TV02',4,0.1,NULL),
	('HD03','TV05',6,0.15,NULL),
	('HD04','TV06',2,0,NULL),
	('HD04','TV04',5,0.15,NULL),
	('HD05','TV08',1,0,NULL),
	('HD06','TV09',3,0,NULL),
	('HD07','TV07',7,0.2,NULL),
	('HD07','TV04',3,0,NULL),
	('HD07','TV15',4,0.1,NULL),
	('HD08','TV17',1,0,NULL),
	('HD08','TV11',4,0.1,NULL),
	('HD09','TV01',8,0.2,NULL),
	('HD10','TV18',2,0,NULL),
	('HD11','TV12',1,0,NULL)