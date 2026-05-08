-- =============================================
-- DATABASE: BaDongTourism
-- SQL Server 2022
-- =============================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'BaDongTourism')
    DROP DATABASE BaDongTourism;
GO

CREATE DATABASE BaDongTourism;
GO

USE BaDongTourism;
GO

-- =============================================
-- BANG: TaiKhoan (Admin accounts)
-- =============================================
CREATE TABLE TaiKhoan (
    MaTK       INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50)  NOT NULL UNIQUE,
    MatKhau    NVARCHAR(255) NOT NULL,
    HoTen      NVARCHAR(100) NOT NULL,
    Email      NVARCHAR(100),
    VaiTro     NVARCHAR(20)  NOT NULL DEFAULT 'Admin',
    NgayTao    DATETIME      DEFAULT GETDATE(),
    TrangThai  BIT           DEFAULT 1
);

-- =============================================
-- BANG: Banner (Slideshow trang chu)
-- =============================================
CREATE TABLE Banner (
    MaBanner  INT IDENTITY(1,1) PRIMARY KEY,
    TieuDe    NVARCHAR(200),
    MoTa      NVARCHAR(500),
    HinhAnh   NVARCHAR(300),
    LienKet   NVARCHAR(300),
    ThuTu     INT           DEFAULT 0,
    TrangThai BIT           DEFAULT 1
);

-- =============================================
-- BANG: DanhMucDiaDiem
-- =============================================
CREATE TABLE DanhMucDiaDiem (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL,
    MoTa       NVARCHAR(500),
    TrangThai  BIT DEFAULT 1
);

-- =============================================
-- BANG: DiaDiem (Tourist attractions)
-- =============================================
CREATE TABLE DiaDiem (
    MaDiaDiem   INT IDENTITY(1,1) PRIMARY KEY,
    MaDanhMuc   INT,
    TenDiaDiem  NVARCHAR(200) NOT NULL,
    MoTaNgan    NVARCHAR(500),
    MoTaChiTiet NTEXT,
    DiaChi      NVARCHAR(300),
    HinhAnhDai  NVARCHAR(300),
    HinhAnhPhu  NVARCHAR(1000),
    BanDo       NVARCHAR(500),
    ThuTu       INT           DEFAULT 0,
    LuotXem     INT           DEFAULT 0,
    NoiBat      BIT           DEFAULT 0,
    TrangThai   BIT           DEFAULT 1,
    NgayTao     DATETIME      DEFAULT GETDATE(),
    FOREIGN KEY (MaDanhMuc) REFERENCES DanhMucDiaDiem(MaDanhMuc)
);

-- =============================================
-- BANG: Tour
-- =============================================
CREATE TABLE Tour (
    MaTour      INT IDENTITY(1,1) PRIMARY KEY,
    TenTour     NVARCHAR(200) NOT NULL,
    MoTaNgan    NVARCHAR(500),
    MoTaChiTiet NTEXT,
    ThoiGian    NVARCHAR(50),
    DiaDiem     NVARCHAR(200),
    GiaNguoiLon DECIMAL(18,0) DEFAULT 0,
    GiaTreEm    DECIMAL(18,0) DEFAULT 0,
    SoChoToiDa  INT           DEFAULT 20,
    LichKhoiHanh NVARCHAR(300),
    BaoGom      NTEXT,
    KhongBaoGom NTEXT,
    LuuY        NTEXT,
    HinhAnhDai  NVARCHAR(300),
    HinhAnhPhu  NVARCHAR(1000),
    NoiBat      BIT           DEFAULT 0,
    LuotXem     INT           DEFAULT 0,
    TrangThai   BIT           DEFAULT 1,
    NgayTao     DATETIME      DEFAULT GETDATE()
);

-- =============================================
-- BANG: DatTour (Tour bookings)
-- =============================================
CREATE TABLE DatTour (
    MaDatTour  INT IDENTITY(1,1) PRIMARY KEY,
    MaTour     INT,
    HoTen      NVARCHAR(100) NOT NULL,
    Email      NVARCHAR(100),
    DienThoai  NVARCHAR(20)  NOT NULL,
    SoNguoiLon INT           DEFAULT 1,
    SoTreEm    INT           DEFAULT 0,
    NgayKhoiHanh DATE,
    TongTien   DECIMAL(18,0) DEFAULT 0,
    GhiChu     NVARCHAR(500),
    TrangThai  NVARCHAR(50)  DEFAULT N'Chờ xác nhận',
    NgayDat    DATETIME      DEFAULT GETDATE(),
    FOREIGN KEY (MaTour) REFERENCES Tour(MaTour)
);

-- =============================================
-- BANG: LuuTru (Accommodations)
-- =============================================
CREATE TABLE LuuTru (
    MaLuuTru    INT IDENTITY(1,1) PRIMARY KEY,
    TenLuuTru   NVARCHAR(200) NOT NULL,
    LoaiLuuTru  NVARCHAR(50),
    MoTaNgan    NVARCHAR(500),
    MoTaChiTiet NTEXT,
    DiaChi      NVARCHAR(300),
    DienThoai   NVARCHAR(50),
    Email       NVARCHAR(100),
    Website     NVARCHAR(200),
    GiaPhong    NVARCHAR(200),
    TienNghi    NVARCHAR(500),
    HinhAnhDai  NVARCHAR(300),
    HinhAnhPhu  NVARCHAR(1000),
    BanDo       NVARCHAR(500),
    XepHang     INT           DEFAULT 3,
    NoiBat      BIT           DEFAULT 0,
    TrangThai   BIT           DEFAULT 1,
    NgayTao     DATETIME      DEFAULT GETDATE()
);

-- =============================================
-- BANG: AmThuc (Food & Restaurants)
-- =============================================
CREATE TABLE AmThuc (
    MaAmThuc    INT IDENTITY(1,1) PRIMARY KEY,
    TenAmThuc   NVARCHAR(200) NOT NULL,
    LoaiAmThuc  NVARCHAR(50),
    MoTaNgan    NVARCHAR(500),
    MoTaChiTiet NTEXT,
    DiaChi      NVARCHAR(300),
    DienThoai   NVARCHAR(50),
    GioMoCua    NVARCHAR(100),
    KhoangGia   NVARCHAR(100),
    HinhAnhDai  NVARCHAR(300),
    HinhAnhPhu  NVARCHAR(1000),
    NoiBat      BIT           DEFAULT 0,
    TrangThai   BIT           DEFAULT 1,
    NgayTao     DATETIME      DEFAULT GETDATE()
);

-- =============================================
-- BANG: DanhMucTinTuc
-- =============================================
CREATE TABLE DanhMucTinTuc (
    MaDanhMuc  INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL,
    TrangThai  BIT DEFAULT 1
);

-- =============================================
-- BANG: TinTuc (News & Events)
-- =============================================
CREATE TABLE TinTuc (
    MaTinTuc    INT IDENTITY(1,1) PRIMARY KEY,
    MaDanhMuc   INT,
    MaTK        INT,
    TieuDe      NVARCHAR(300) NOT NULL,
    TomTat      NVARCHAR(500),
    NoiDung     NTEXT,
    HinhAnhDai  NVARCHAR(300),
    LuotXem     INT           DEFAULT 0,
    NoiBat      BIT           DEFAULT 0,
    TrangThai   BIT           DEFAULT 1,
    NgayDang    DATETIME      DEFAULT GETDATE(),
    FOREIGN KEY (MaDanhMuc) REFERENCES DanhMucTinTuc(MaDanhMuc),
    FOREIGN KEY (MaTK) REFERENCES TaiKhoan(MaTK)
);

-- =============================================
-- BANG: Gallery (Photo gallery)
-- =============================================
CREATE TABLE Gallery (
    MaAnh      INT IDENTITY(1,1) PRIMARY KEY,
    TieuDe     NVARCHAR(200),
    MoTa       NVARCHAR(500),
    DuongDanAnh NVARCHAR(300) NOT NULL,
    DanhMuc    NVARCHAR(100),
    ThuTu      INT           DEFAULT 0,
    TrangThai  BIT           DEFAULT 1,
    NgayTao    DATETIME      DEFAULT GETDATE()
);

-- =============================================
-- BANG: LienHe (Contact messages)
-- =============================================
CREATE TABLE LienHe (
    MaLienHe  INT IDENTITY(1,1) PRIMARY KEY,
    HoTen     NVARCHAR(100) NOT NULL,
    Email     NVARCHAR(100),
    DienThoai NVARCHAR(20),
    ChuDe     NVARCHAR(200),
    NoiDung   NVARCHAR(2000) NOT NULL,
    DaDoc     BIT           DEFAULT 0,
    NgayGui   DATETIME      DEFAULT GETDATE()
);

-- =============================================
-- DATA MAU
-- =============================================

-- Admin mac dinh (mat khau: admin123)
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, Email, VaiTro)
VALUES ('admin', 'admin123', N'Quản Trị Viên', 'admin@badong.com', 'Admin');

-- Danh muc dia diem
INSERT INTO DanhMucDiaDiem (TenDanhMuc) VALUES
(N'Bãi biển'), (N'Di tích lịch sử'), (N'Làng nghề'), (N'Khu vui chơi');

-- Danh muc tin tuc
INSERT INTO DanhMucTinTuc (TenDanhMuc) VALUES
(N'Tin tức'), (N'Sự kiện'), (N'Lễ hội'), (N'Khám phá'), (N'Ẩm thực');

-- Banner mau
INSERT INTO Banner (TieuDe, MoTa, HinhAnh, ThuTu) VALUES
(N'Chào mừng đến với Ba Động', N'Bãi biển đẹp nhất tỉnh Trà Vinh', 'banner1.jpg', 1),
(N'Khám phá thiên nhiên hoang sơ', N'Cát trắng, sóng xanh, gió mát', 'banner2.jpg', 2),
(N'Trải nghiệm văn hóa địa phương', N'Ẩm thực phong phú, con người thân thiện', 'banner3.jpg', 3);

-- Dia diem mau
INSERT INTO DiaDiem (MaDanhMuc, TenDiaDiem, MoTaNgan, DiaChi, NoiBat) VALUES
(1, N'Bãi Biển Ba Động', N'Bãi biển nguyên sơ dài hơn 10km với cát trắng mịn và sóng biển êm đềm.', N'Xã Trường Long Hòa, huyện Duyên Hải, Trà Vinh', 1),
(2, N'Chùa Hang', N'Ngôi chùa cổ kính được xây dựng trong hang đá tự nhiên, là điểm tâm linh nổi tiếng.', N'Huyện Duyên Hải, Trà Vinh', 1),
(3, N'Làng nghề đan lát', N'Làng nghề truyền thống với những sản phẩm thủ công tinh xảo từ lá buông.', N'Huyện Duyên Hải, Trà Vinh', 0),
(1, N'Rừng phòng hộ ven biển', N'Khu rừng ngập mặn xanh mát, lý tưởng cho các tour sinh thái.', N'Xã Trường Long Hòa, Trà Vinh', 1);

-- Tour mau
INSERT INTO Tour (TenTour, MoTaNgan, ThoiGian, DiaDiem, GiaNguoiLon, GiaTreEm, NoiBat) VALUES
(N'Tour Ba Động 1 ngày', N'Khám phá bãi biển Ba Động trong ngày với đầy đủ dịch vụ.', N'1 ngày', N'Ba Động, Trà Vinh', 350000, 200000, 1),
(N'Tour Ba Động 2 ngày 1 đêm', N'Trải nghiệm trọn vẹn vẻ đẹp biển Ba Động, nghỉ đêm tại resort.', N'2 ngày 1 đêm', N'Ba Động, Trà Vinh', 850000, 500000, 1),
(N'Tour khám phá rừng ngập mặn', N'Chèo thuyền kayak khám phá hệ sinh thái rừng ngập mặn độc đáo.', N'Nửa ngày', N'Ba Động, Trà Vinh', 250000, 150000, 0);

-- Luu tru mau
INSERT INTO LuuTru (TenLuuTru, LoaiLuuTru, MoTaNgan, DiaChi, DienThoai, GiaPhong, XepHang, NoiBat) VALUES
(N'Resort Ba Động Beach', N'Resort', N'Resort 4 sao ngay sát biển với đầy đủ tiện nghi hiện đại.', N'Trường Long Hòa, Duyên Hải, Trà Vinh', '0294 1234 567', N'800.000 - 2.500.000đ/đêm', 4, 1),
(N'Nhà Nghỉ Biển Xanh', N'Nhà nghỉ', N'Nhà nghỉ bình dân, sạch sẽ, cách biển 200m.', N'Duyên Hải, Trà Vinh', '0909 123 456', N'200.000 - 400.000đ/đêm', 2, 0),
(N'Khách Sạn Duyên Hải', N'Khách sạn', N'Khách sạn 3 sao tại trung tâm huyện Duyên Hải.', N'TT. Duyên Hải, Trà Vinh', '0294 2345 678', N'400.000 - 900.000đ/đêm', 3, 1);

-- Am thuc mau
INSERT INTO AmThuc (TenAmThuc, LoaiAmThuc, MoTaNgan, DiaChi, KhoangGia, NoiBat) VALUES
(N'Cua Huỳnh Đế', N'Đặc sản', N'Loại cua biển đặc sản nổi tiếng của vùng biển Duyên Hải, thịt chắc ngọt.', N'Chợ Duyên Hải, Trà Vinh', N'200.000 - 500.000đ/kg', 1),
(N'Bánh Tét Trà Cuôn', N'Đặc sản', N'Bánh tét đặc trưng của người Khmer Trà Vinh, nhân đậu và thịt đậm đà.', N'Khắp các chợ Trà Vinh', N'15.000 - 25.000đ/đòn', 1),
(N'Nhà hàng Hải Sản Ba Động', N'Nhà hàng', N'Nhà hàng chuyên hải sản tươi sống ngay tại cảng, giá bình dân.', N'Cảng cá Duyên Hải, Trà Vinh', N'150.000 - 400.000đ/người', 1);

-- Tin tuc mau
INSERT INTO TinTuc (MaDanhMuc, MaTK, TieuDe, TomTat, NoiBat) VALUES
(1, 1, N'Ba Động vào mùa du lịch hè 2024', N'Mùa hè năm nay, Ba Động đón hàng nghìn du khách đến tham quan và nghỉ dưỡng.', 1),
(2, 1, N'Lễ hội Nghinh Ông tại Duyên Hải', N'Lễ hội truyền thống của ngư dân được tổ chức long trọng với nhiều hoạt động văn hóa.', 1),
(4, 1, N'Khám phá vẻ đẹp hoang sơ của Ba Động', N'Bãi biển Ba Động vẫn giữ được vẻ đẹp nguyên sơ hiếm có giữa thời đại phát triển.', 0);

-- Gallery mau
INSERT INTO Gallery (TieuDe, DuongDanAnh, DanhMuc, ThuTu) VALUES
(N'Bình minh trên biển Ba Động', 'gallery1.jpg', N'Phong cảnh', 1),
(N'Cua Huỳnh Đế đặc sản', 'gallery2.jpg', N'Ẩm thực', 2),
(N'Chèo kayak khám phá rừng ngập mặn', 'gallery3.jpg', N'Hoạt động', 3),
(N'Hoàng hôn Ba Động', 'gallery4.jpg', N'Phong cảnh', 4),
(N'Làng chài Duyên Hải', 'gallery5.jpg', N'Văn hóa', 5),
(N'Bãi cát trắng Ba Động', 'gallery6.jpg', N'Phong cảnh', 6);

GO
PRINT N'Database BaDongTourism tao thanh cong!';
