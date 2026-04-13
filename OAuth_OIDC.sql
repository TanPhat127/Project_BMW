CREATE DATABASE OAuthOIDCSystem;
GO

USE OAuthOIDCSystem;
GO

CREATE TABLE UserInfo (
    ID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính, tự tăng
    Email NVARCHAR(255) UNIQUE, -- Email người dùng (lấy từ Google hoặc đăng ký nội bộ)
    HoTen NVARCHAR(255), -- Tên hiển thị
    Hinh NVARCHAR(500), -- URL ảnh đại diện
    NgayTao DATETIME DEFAULT GETDATE(), -- Thời điểm tạo tài khoản
    TrangThai BIT DEFAULT 1 -- 1: hoạt động, 0: khóa
);

CREATE TABLE TaiKhoanNoiBo (
    ID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính
    ID_NguoiDung INT, -- Liên kết tới bảng NguoiDung
    Username NVARCHAR(100) UNIQUE NOT NULL, -- Username
    PassHash NVARCHAR(500) NOT NULL, -- Mật khẩu đã hash (KHÔNG lưu plaintext)
    LanDangNhapCuoi DATETIME, -- Lần đăng nhập gần nhất

    CONSTRAINT FK_TaiKhoan_NguoiDung
        FOREIGN KEY (ID_NguoiDung)
        REFERENCES UserInfo(ID)
        ON DELETE CASCADE
);

CREATE TABLE DangNhapNgoai (
    ID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính
    ID_NguoiDung INT, -- Liên kết người dùng hệ thống
    NhaCungCap NVARCHAR(50) NOT NULL, -- Google / Facebook
    MaNguoiDungNgoai NVARCHAR(255) NOT NULL, -- ID từ provider (sub trong ID Token)
    EmailNgoai NVARCHAR(255), -- Email từ provider
    NgayLienKet DATETIME DEFAULT GETDATE(), -- Ngày liên kết tài khoản

    CONSTRAINT FK_DangNhapNgoai_NguoiDung
        FOREIGN KEY (ID_NguoiDung)
        REFERENCES UserInfo(ID)
        ON DELETE CASCADE
);

CREATE TABLE PhienDangNhap (
    ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY, -- ID phiên
    ID_NguoiDung INT, -- Người dùng
    ThoiDiemDangNhap DATETIME DEFAULT GETDATE(), -- Thời điểm login
    ThoiDiemHetHan DATETIME, -- Hết hạn session
    DiaChiIP NVARCHAR(50), -- IP đăng nhập
    ThietBi NVARCHAR(255), -- Trình duyệt / thiết bị
    NhaCungCap NVARCHAR(50), -- Google / Facebook / Local

    CONSTRAINT FK_Phien_NguoiDung
        FOREIGN KEY (ID_NguoiDung)
        REFERENCES UserInfo(ID)
        ON DELETE CASCADE
);

CREATE TABLE TokenNguoiDung (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_NguoiDung INT,
    AccessToken NVARCHAR(MAX), -- Token truy cập (nên mã hóa nếu lưu)
    IdToken NVARCHAR(MAX), -- JWT token
    RefreshToken NVARCHAR(MAX), -- Token làm mới
    ThoiGianHetHan DATETIME,
    NhaCungCap NVARCHAR(50),

    CONSTRAINT FK_Token_NguoiDung
        FOREIGN KEY (ID_NguoiDung)
        REFERENCES UserInfo(ID)
        ON DELETE CASCADE
);

Select * From TaiKhoanNoiBo;
Select * From UserInfo;

DELETE FROM UserInfo
WHERE ID = 2;