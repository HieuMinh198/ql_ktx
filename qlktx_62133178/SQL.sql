create database qlktx_62133178
go
use qlktx_62133178
go
create table Phong(
ma_phong VARCHAR(10) PRIMARY KEY,
ten_phong NVARCHAR(50) NOT NULL,
so_giuong INT NOT NULL,
loai_phong NVARCHAR(50)not null,
gia_phong DECIMAL(10,2)
);
CREATE TABLE sinh_vien (
  ma_sv varchar(10) PRIMARY KEY,
  ho_ten NVARCHAR(50) NOT NULL,
  gioi_tinh NVARCHAR(10) not null,
  anh varchar(20)not null,
  ngay_sinh DATE not null,
  que_quan NVARCHAR(50)not null,
  lop VARCHAR(50)not null,
  sdt VARCHAR(20)not null,
  email VARCHAR(50)not null,
  ngay_vao_o DATE not null,
  ma_phong VARCHAR(10)not null,
  FOREIGN KEY (ma_phong) REFERENCES Phong(ma_phong)
);
CREATE TABLE phieu_dat_phong (
  ma_phieu_dat_phong varchar(10) PRIMARY KEY,
  ngay_dat DATE NOT NULL,
  ngay_bat_dau DATE NOT NULL,
  ngay_ket_thuc DATE NOT NULL,
  tong_tien DECIMAL(10,2) NOT NULL,
  ma_phong varchar(10) not null,
  ma_sv varchar(10) not null,
  FOREIGN KEY (ma_phong) REFERENCES Phong(ma_phong),
  FOREIGN KEY (ma_sv) REFERENCES sinh_vien(ma_sv)
);
CREATE TABLE thanh_toan (
  ma_thanh_toan varchar(10) PRIMARY KEY,
  ngay_thanh_toan DATE NOT NULL,
  so_tien DECIMAL(10,2) NOT NULL,
  ma_phieu_dat_phong varchar(10),
  FOREIGN KEY (ma_phieu_dat_phong) REFERENCES phieu_dat_phong(ma_phieu_dat_phong)
);
CREATE TABLE dich_vu (
  ma_dich_vu varchar(10) PRIMARY KEY,
  ten_dich_vu NVARCHAR(50) NOT NULL,
  gia_dich_vu DECIMAL(10,2) NOT NULL
);
CREATE TABLE dich_vu_phong (
  ma_dich_vu_phong varchar(10) PRIMARY KEY,
  so_luong INT NOT NULL,
  ma_dich_vu varchar(10),
  ma_phong varchar(10),
  FOREIGN KEY (ma_dich_vu) REFERENCES dich_vu(ma_dich_vu),
  FOREIGN KEY (ma_phong) REFERENCES Phong(ma_phong)
);
CREATE TABLE quan_tri(
Email varchar(50) PRIMARY KEY,
Admin bit,
HoTen nvarchar(50),
Password nvarchar(50)
);
-- Sample data for table Phong
INSERT INTO Phong (ma_phong, ten_phong, so_giuong, loai_phong, gia_phong)
VALUES 
    ('P0101', N'Phòng 101', 4, N'Phòng tập thể', 400000),
    ('P0102', N'Phòng 102', 4, N'Phòng tập thể', 400000),
    ('P0103', N'Phòng 103', 6, N'Phòng tập thể', 600000),
	('P0104', N'Phòng 104', 4, N'Phòng tập thể', 400000),
	('P0105', N'Phòng 105', 4, N'Phòng tập thể', 400000),
	('P0106', N'Phòng 106', 2, N'Phòng đôi', 300000),
	('P0107', N'Phòng 107', 2, N'Phòng đôi', 300000),
	('P0108', N'Phòng 108', 6, N'Phòng tập thể', 600000),
	('P0201', N'Phòng 201', 4, N'Phòng tập thể', 400000),
	('P0202', N'Phòng 202', 4, N'Phòng tập thể', 400000),
	('P0203', N'Phòng 203', 6, N'Phòng tập thể', 600000),
	('P0204', N'Phòng 204', 6, N'Phòng tập thể', 600000),
	('P0205', N'Phòng 205', 4, N'Phòng tập thể', 400000),
	('P0206', N'Phòng 206', 4, N'Phòng tập thể', 400000),
	('P0207', N'Phòng 207', 2, N'Phòng đôi', 300000),
	('P0208', N'Phòng 208', 2, N'Phòng đôi', 300000),
	('P0301', N'Phòng 301', 2, N'Phòng đôi', 300000),
	('P0302', N'Phòng 302', 4, N'Phòng tập thể', 400000),
	('P0303', N'Phòng 303', 4, N'Phòng tập thể', 400000),
	('P0304', N'Phòng 304', 6, N'Phòng tập thể', 600000),
	('P0305', N'Phòng 305', 4, N'Phòng tập thể', 400000),
	('P0306', N'Phòng 306', 4, N'Phòng tập thể', 400000),
	('P0307', N'Phòng 307', 2, N'Phòng đôi', 300000),
	('P0308', N'Phòng 308', 6, N'Phòng tập thể', 600000),
	('P0401', N'Phòng 401', 4, N'Phòng tập thể', 400000),
	('P0402', N'Phòng 402', 4, N'Phòng tập thể', 400000),
	('P0403', N'Phòng 403', 4, N'Phòng tập thể', 400000),
	('P0404', N'Phòng 404', 4, N'Phòng tập thể', 400000),
	('P0405', N'Phòng 405', 4, N'Phòng tập thể', 400000),
	('P0406', N'Phòng 406', 4, N'Phòng tập thể', 400000),
	('P0407', N'Phòng 407', 4, N'Phòng tập thể', 400000),
	('P0408', N'Phòng 408', 4, N'Phòng tập thể', 400000);

-- Sample data for table sinh_vien
INSERT INTO sinh_vien (ma_sv, ho_ten, gioi_tinh, anh, ngay_sinh, que_quan, lop, sdt, email, ngay_vao_o, ma_phong)
VALUES 
('60135127', N'Nguyễn Văn Anh', N'Nam', 'employee.png', '2000-01-01', N'Hà Nội', '60.CNTT-1', '0987654321', 'anh.nv.60cntt@ntu.edu.vn', '2020-08-01', 'P0101'),
('61133458', N'Nguyễn Hoài Nam', N'Nam', 'employee.png', '2001-08-12', N'Khánh Hòa', '61.CNTT-2', '0977657724', 'nam.nh.61cntt@ntu.edu.vn', '2021-08-01', 'P0101'),
('62130587', N'Võ Văn Mạnh', N'Nam', 'employee.png', '2002-09-17', N'Phú Yên', '62.DDT-2', '0369758248', 'manh.vv.62ddt@ntu.edu.vn', '2021-08-01', 'P0101'),
('63134487', N'Võ Minh Tinh', N'Nam', 'employee.png', '2003-10-17', N'Bình Định', '63.CNTT-3', '0372895428', 'tinh.vm.63cntt@ntu.edu.vn', '2022-09-01', 'P0102'),
('62132542', N'Trần Trọng Lực', N'Nam', 'employee.png', '2002-11-22', N'Phú Yên', '62.CNTT-3', '0936821497', 'luc.tt.62cntt@ntu.edu.vn', '2022-09-01', 'P0102'),
('62131542', N'Lê Minh Kha', N'Nam', 'employee.png', '2002-09-30', N'Phú Yên', '62.DDT-1', '0385216974', 'kha.lm.62ddt@ntu.edu.vn', '2021-10-01', 'P0102'),
('60139753', N'Phạm Thị Bình', N'Nữ', 'employee.png', '2000-02-20', N'Hà Nam', '60.KT-1', '0987655320', 'binh.pt.60kt@ntu.edu.vn', '2021-08-01', 'P0201'),
('61132288', N'Lê Thị Hoa', N'Nữ', 'employee.png', '2001-05-12', N'Đà Nẵng', '61.QTKS-6', '0363630754', 'hoa.lt.61qtks@ntu.edu.vn', '2021-08-01', 'P0201'),
('62131658', N'Nguyễn Thị Hà', N'Nữ', 'employee.png', '2002-07-22', N'Phú Yên', '62.QTKS-2', '0363774857', 'ha.nt.62qtks@ntu.edu.vn', '2021-09-01', 'P0201'),
('62131117', N'Trần Thị Lệ', N'Nữ', 'employee.png', '2002-03-18', N'Phú Yên', '62.TTQL-2', '0983852527', 'le.tt.62ttql@ntu.edu.vn', '2021-09-01', 'P0202'),
('62131336', N'Phạm Thị Thanh Hằng', N'Nữ', 'employee.png', '2002-07-30', N'Đà Nẵng', '62.TTQL-2', '0981100478', 'hang.ptt.62ttql@ntu.edu.vn', '2021-08-01', 'P0202'),
('63132255', N'Nguyễn Thị Mê Ly', N'Nữ', 'employee.png', '2003-08-28', N'Hà Nam', '63.TTQL-1', '0397524085', 'ly.ntm.63ttql@ntu.edu.vn', '2022-10-01', 'P0203'),
('63131598', N'Trần Thị Phi', N'Nữ', 'employee.png', '2003-10-07', N'Đà Nẵng', '63.TTQL-1', '0388547770', 'phi.tt.63ttql@ntu.edu.vn', '2022-08-01', 'P0203'),
('62133287', N'Nguyễn Minh Nhi', N'Nữ', 'employee.png', '2002-09-09', N'Đà Nẵng', '62.CNTP-1', '0388555222', 'nhi.nm.62cntp@ntu.edu.vn', '2021-10-01', 'P0201'),
('61139513', N'Lê Thị Thu', N'Nữ', 'employee.png', '2001-04-05', N'Khánh Hòa', '61.CNTP-1', '0987820013', 'thu.lt.61cntp@ntu.edu.vn', '2021-08-01', 'P0203'),
('62138756', N'Hà Thị Thu Minh', N'Nữ', 'employee.png', '2002-06-15', N'Khánh Hòa', '62.CNTP-2', '0989999885', 'minh.htt.62cntp@ntu.edu.vn', '2021-11-01', 'P0203'),
('62131537', N'Nguyễn Thị Tường Vi', N'Nữ', 'employee.png', '2002-09-25', N'Bình Thuận', '62.KT-1', '0905037755', 'vi.ntt.62kt@ntu.edu.vn', '2021-08-01', 'P0203'),
('60139875', N'Trần Văn Chung', N'Nam', 'employee.png', '2000-03-03', N'Hải Phòng', '60.NTTS-1', '0989864023', 'chung.tv.60ntts@ntu.edu.vn', '2021-08-01', 'P0302'),
('61139875', N'Nguyễn Văn Nam', N'Nam', 'employee.png', '2001-04-03', N'Hải Phòng', '61.CNOT-2', '0333558774', 'nam.nv.61cnot@ntu.edu.vn', '2021-08-01', 'P0301'),
('62134875', N'Phạm Văn Khánh', N'Nam', 'employee.png', '2002-08-09', N'Đà Nẵng', '62.CNOT-1', '0322005541', 'khanh.pv.62cnot@ntu.edu.vn', '2021-08-01', 'P0302'),
('63139785', N'Phạm Hoài Ân', N'Nam', 'employee.png', '2003-11-03', N'Phú Yên', '63.CNOT-2', '0975953140', 'an.ph.63cnot@ntu.edu.vn', '2021-08-01', 'P0301'),
('60139828', N'Lý Văn Hòa', N'Nam', 'employee.png', '2000-07-05', N'Phú Yên', '60.CNOT-1', '0380855041', 'hoa.lv.60cnot@ntu.edu.vn', '2021-08-01', 'P0302'),
('60135032', N'Phạm Thị Mai', N'Nữ', 'employee.png', '2000-03-20', N'Hà Nam', '60.KT-1', '0987600320', 'mai.pt.60kt@ntu.edu.vn', '2021-08-01', 'P0401'),
('61130643', N'Nguyễn Thị Liên', N'Nữ', 'employee.png', '2001-05-22', N'Đà Nẵng', '61.QTKS-5', '0363030754', 'lien.nt.61qtks@ntu.edu.vn', '2021-08-01', 'P0401'),
('62133088', N'Nguyễn Thị Mai Hoa', N'Nữ', 'employee.png', '2002-07-20', N'Phú Yên', '62.QTKS-2', '0360774057', 'hoa.ntm.62qtks@ntu.edu.vn', '2021-09-01', 'P0401'),
('62130057', N'Trần Thị Mỹ', N'Nữ', 'employee.png', '2002-03-17', N'Phú Yên', '62.TTQL-2', '0983002007', 'my.tt.62ttql@ntu.edu.vn', '2021-09-01', 'P0401'),
('60139005', N'Trần Văn Chinh', N'Nam', 'employee.png', '2000-07-03', N'Hải Phòng', '60.NTTS-1', '0989064003', 'ching.tv.60ntts@ntu.edu.vn', '2021-08-01', 'P0402'),
('61139070', N'Nguyễn Văn Nhân', N'Nam', 'employee.png', '2001-03-03', N'Hải Phòng', '61.CNOT-2', '0333358074', 'nhan.nv.61cnot@ntu.edu.vn', '2021-08-01', 'P0402'),
('62130800', N'Phạm Văn Kha', N'Nam', 'employee.png', '2002-10-09', N'Đà Nẵng', '62.CNOT-1', '0323005041', 'kha.pv.62cnot@ntu.edu.vn', '2021-08-01', 'P0402'),
('63139000', N'Phạm Hoài Minh', N'Nam', 'employee.png', '2003-12-12', N'Phú Yên', '63.CNOT-2', '0970953040', 'minh.ph.63cnot@ntu.edu.vn', '2021-08-01', 'P0402');

-- Sample data for table phieu_dat_phong
INSERT INTO phieu_dat_phong (ma_phieu_dat_phong, ngay_dat, ngay_bat_dau, ngay_ket_thuc, tong_tien, ma_phong, ma_sv)
VALUES 
    ('PD0001', '2020-07-25', '2020-08-01', '2021-08-01', 1200000, 'P0101', '60135127'),
	('PD0002', '2020-07-27', '2020-08-01', '2021-08-01', 1200000, 'P0101', '61133458'),
    ('PD0003', '2020-07-20', '2021-08-01', '2022-08-01', 1200000, 'P0101', '62130587'),
    ('PD0004', '2020-08-25', '2021-09-01', '2022-09-01', 1200000, 'P0102', '63134487'),
	('PD0005', '2020-08-25', '2020-09-01', '2021-09-01', 1200000, 'P0102', '62132542'),
	('PD0006', '2020-08-20', '2020-09-01', '2021-09-01', 1200000, 'P0102', '62131542'),
    ('PD0007', '2020-08-23', '2021-09-01', '2022-09-01', 1200000, 'P0201', '60139753'),
    ('PD0008', '2020-09-25', '2020-10-01', '2021-10-01', 1200000, 'P0201', '61132288'),
    ('PD0009', '2020-09-27', '2021-10-01', '2022-10-01', 1200000, 'P0201', '62131658'),
    ('PD0010', '2020-09-21', '2020-10-01', '2021-10-01', 1200000, 'P0202', '62131117'),
	('PD0011', '2020-07-20', '2020-08-01', '2021-08-01', 1200000, 'P0202', '62131336'),
    ('PD0012', '2020-08-25', '2020-09-01', '2021-09-01', 1200000, 'P0203', '63132255'),
    ('PD0013', '2020-09-25', '2021-10-01', '2022-10-01', 1200000, 'P0203', '63131598'),
    ('PD0014', '2020-06-23', '2021-07-01', '2022-07-01', 1200000, 'P0201', '62133287'),
	('PD0015', '2020-08-20', '2021-09-01', '2022-09-01', 1200000, 'P0203', '61139513'),
	('PD0016', '2020-06-25', '2022-07-01', '2023-07-01', 1200000, 'P0203', '62138756'),
    ('PD0017', '2020-09-25', '2022-10-01', '2023-10-01', 1200000, 'P0203', '62131537'),
    ('PD0018', '2020-07-25', '2020-08-01', '2020-08-01', 1200000, 'P0302', '60139875'),
    ('PD0019', '2020-07-28', '2022-08-01', '2023-08-01', 1800000, 'P0301', '61139875'),
    ('PD0020', '2020-08-25', '2021-09-01', '2022-09-01', 1200000, 'P0302', '62134875'),
	('PD0021', '2020-08-26', '2021-09-01', '2022-09-01', 1800000, 'P0301', '63139785'),
    ('PD0022', '2020-08-25', '2022-09-01', '2023-09-01', 1200000, 'P0302', '60139828'),
	('PD0023', '2020-07-25', '2021-08-01', '2022-08-01', 1200000, 'P0401', '60135032'),
	('PD0024', '2020-07-23', '2021-08-01', '2022-08-01', 1200000, 'P0401', '61130643'),
    ('PD0025', '2020-08-25', '2021-09-01', '2022-09-01', 1200000, 'P0401', '62133088'),
    ('PD0026', '2020-08-26', '2020-09-01', '2021-09-01', 1200000, 'P0401', '62130057'),
    ('PD0027', '2020-07-25', '2022-08-01', '2023-08-01', 1200000, 'P0402', '60139005'),
    ('PD0028', '2020-07-29', '2021-08-01', '2022-08-01', 1200000, 'P0402', '61139070'),
	('PD0029', '2020-07-22', '2021-08-01', '2022-08-01', 1200000, 'P0402', '62130800'),
    ('PD0030', '2020-07-25', '2022-08-01', '2023-08-01', 1200000, 'P0402', '63139000');

-- Sample data for table thanh_toan
INSERT INTO thanh_toan (ma_thanh_toan, ngay_thanh_toan, so_tien, ma_phieu_dat_phong)
VALUES 
    ('TT0001', '2020-08-01', 1200000, 'PD0001'),
    ('TT0002', '2020-08-01', 1200000, 'PD0002'),
	('TT0003', '2021-08-01', 1200000, 'PD0003'),
    ('TT0004', '2021-09-01', 1200000, 'PD0004'),
    ('TT0005', '2020-09-01', 1200000, 'PD0005'),
	('TT0006', '2020-09-01', 1200000, 'PD0006'),
    ('TT0007', '2021-09-01', 1200000, 'PD0007'),
    ('TT0008', '2020-10-01', 1200000, 'PD0008'),
	('TT0009', '2021-10-01', 1200000, 'PD0009'),
    ('TT0010', '2020-10-01', 1200000, 'PD0010'),
    ('TT0011', '2020-08-01', 1200000, 'PD0011'),
	('TT0012', '2020-09-01', 1200000, 'PD0012'),
    ('TT0013', '2021-10-01', 1200000, 'PD0013'),
    ('TT0014', '2021-07-01', 1200000, 'PD0014'),
	('TT0015', '2021-09-01', 1200000, 'PD0015'),
    ('TT0016', '2022-07-01', 1200000, 'PD0016'),
    ('TT0017', '2022-10-01', 1200000, 'PD0017'),
	('TT0018', '2020-08-01', 1200000, 'PD0018'),
    ('TT0019', '2022-08-01', 1800000, 'PD0019'),
    ('TT0020', '2021-09-01', 1200000, 'PD0020'),
	('TT0021', '2021-09-01', 1800000, 'PD0021'),
	('TT0022', '2022-09-01', 1200000, 'PD0022'),
	('TT0023', '2022-08-01', 1200000, 'PD0023'),
    ('TT0024', '2022-08-01', 1200000, 'PD0024'),
    ('TT0025', '2022-09-01', 1200000, 'PD0025'),
	('TT0026', '2020-09-01', 1200000, 'PD0026'),
    ('TT0027', '2023-08-01', 1200000, 'PD0027'),
    ('TT0028', '2022-08-01', 1200000, 'PD0028'),
	('TT0029', '2022-08-01', 1200000, 'PD0029'),
	('TT0030', '2023-08-01', 1200000, 'PD0030');

-- Sample data for table dich_vu
INSERT INTO dich_vu (ma_dich_vu, ten_dich_vu, gia_dich_vu)
VALUES 
    ('DV01', N'Giặt ủi', 50000),
    ('DV02', N'Wifi', 20000),
    ('DV03', N'Dịch vụ thêm', 60000);
INSERT INTO dich_vu_phong (ma_dich_vu_phong, so_luong, ma_dich_vu, ma_phong) 
VALUES 
	('DV01-P0101', 2, 'DV01', 'P0101'),
	('DV02-P0101', 3, 'DV02', 'P0101'),
	('DV01-P0102', 3, 'DV01', 'P0102'),
	('DV02-P0102', 3, 'DV02', 'P0102'),
	('DV01-P0201', 1, 'DV01', 'P0201'),
	('DV02-P0201', 3, 'DV02', 'P0201'),
	('DV01-P0202', 1, 'DV01', 'P0202'),
	('DV02-P0202', 2, 'DV02', 'P0202'),
	('DV02-P0301', 2, 'DV02', 'P0301'),
	('DV02-P0302', 3, 'DV02', 'P0302'),
	('DV02-P0401', 4, 'DV02', 'P0401'),
	('DV02-P0402', 4, 'DV02', 'P0402');

INSERT INTO quan_tri
VALUES ('tuanta.62cntt@ntu.edu.vn',1,N'Trần Anh Tuấn','12345678')
 GO
CREATE PROCEDURE SinhVien_TimKiem
    @MaSV varchar(10)=NULL,
	@HoTen nvarchar(100)=NULL,
	@GioiTinh nvarchar(10)= NULL,
	@QueQuan nvarchar(100)=NULL,
	@Lop varchar(50)=NULL,
	@MaPB varchar(10)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM sinh_vien
       WHERE  (1=1)
       '
IF @MaSV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND ( ma_sv LIKE ''%'+@MaSV+'%'')
              '
IF @HoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (ho_ten LIKE ''%'+@HoTen+'%'')
              '
IF @GioiTinh IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND ( gioi_tinh LIKE ''%'+@GioiTinh+'%'')
             '
IF @QueQuan IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (que_quan LIKE ''%'+@QueQuan+'%'')
              '
IF @Lop IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (lop LIKE ''%'+@Lop+'%'')
              '
IF @MaPB IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (ma_phong LIKE ''%'+@MaPB+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END
GO
CREATE PROCEDURE CalculateServiceCost
AS
BEGIN
    -- Tạo bảng tạm để lưu trữ kết quả
    CREATE TABLE #TempServiceCost
    (
        dich_vu_phong_id VARCHAR(10),
        so_luong DECIMAL(18, 2),
        gia_dich_vu DECIMAL(18, 2),
        tong_tien DECIMAL(18, 2),
        ten_phong NVARCHAR(50),
        ten_dich_vu NVARCHAR(50)
    )

    -- Tính toán tổng tiền dịch vụ và lưu vào bảng tạm
    INSERT INTO #TempServiceCost (dich_vu_phong_id, so_luong, gia_dich_vu, tong_tien, ten_phong, ten_dich_vu)
    SELECT
        dp.ma_dich_vu_phong,
        dp.so_luong,
        dv.gia_dich_vu,
        dp.so_luong * dv.gia_dich_vu AS tong_tien,
        p.ten_phong,
        dv.ten_dich_vu
    FROM
        dich_vu_phong dp
        INNER JOIN dich_vu dv ON dp.ma_dich_vu = dv.ma_dich_vu
        INNER JOIN phong p ON dp.ma_phong = p.ma_phong

    -- Trả về kết quả
    SELECT * FROM #TempServiceCost

    -- Xóa bảng tạm
    DROP TABLE #TempServiceCost
END
GO
CREATE PROCEDURE Phong_TimKiem
    @MaPhong varchar(8)=NULL,
	@TenPhong nvarchar(30)=NULL,
	@GiaMin varchar(30)=NULL,
	@GiaMax varchar(30)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM Phong
       WHERE  (1=1)
       '
IF @MaPhong IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (ma_phong LIKE ''%'+@MaPhong+'%'')
              '
IF @TenPhong IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (ten_phong LIKE ''%'+@TenPhong+'%'')
              '
IF @GiaMin IS NOT NULL and @GiaMax IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (gia_phong Between Convert(int,'''+@GiaMin+''') AND Convert(int, '''+@GiaMax+'''))
             '
	EXEC SP_EXECUTESQL @SqlStr
END
