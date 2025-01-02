USE [master]
GO
/****** Object:  Database [file_database]    Script Date: 1/2/2025 11:07:04 AM ******/
CREATE DATABASE [file_database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'file_database_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER1\MSSQL\DATA\file_database.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'file_database_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER1\MSSQL\DATA\file_database.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [file_database] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [file_database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [file_database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [file_database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [file_database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [file_database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [file_database] SET ARITHABORT OFF 
GO
ALTER DATABASE [file_database] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [file_database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [file_database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [file_database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [file_database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [file_database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [file_database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [file_database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [file_database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [file_database] SET  DISABLE_BROKER 
GO
ALTER DATABASE [file_database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [file_database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [file_database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [file_database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [file_database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [file_database] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [file_database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [file_database] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [file_database] SET  MULTI_USER 
GO
ALTER DATABASE [file_database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [file_database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [file_database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [file_database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [file_database] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [file_database] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [file_database] SET QUERY_STORE = ON
GO
ALTER DATABASE [file_database] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [file_database]
GO
/****** Object:  Table [dbo].[CHATLIEU]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHATLIEU](
	[MaCL] [varchar](10) NOT NULL,
	[Tenchatlieu] [nvarchar](50) NULL,
 CONSTRAINT [PK_CHATLIEU] PRIMARY KEY CLUSTERED 
(
	[MaCL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHOADON]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHOADON](
	[MaHD] [varchar](10) NOT NULL,
	[MaSP] [varchar](10) NOT NULL,
	[Soluong] [int] NULL,
	[Dongia] [float] NULL,
	[Giamgia] [float] NULL,
	[Thanhtien] [float] NULL,
 CONSTRAINT [PK_CTHOADON_1] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTNHAP]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTNHAP](
	[MaHD] [varchar](10) NOT NULL,
	[MaSP] [varchar](10) NOT NULL,
	[Soluong] [int] NULL,
	[Dongia] [float] NULL,
	[Giamgia] [float] NULL,
	[Thanhtien] [float] NULL,
 CONSTRAINT [PK_MAHD_MASP] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOANHTHU]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOANHTHU](
	[Banhang] [float] NULL,
	[Nhaphang] [float] NULL,
	[Loinhuan] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONHANG]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONHANG](
	[MaHD] [varchar](10) NOT NULL,
	[MaNV] [varchar](10) NULL,
	[NgayHD] [datetime] NULL,
	[MaKH] [varchar](10) NULL,
	[Trigia] [float] NULL,
 CONSTRAINT [PK_DONHANG] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [varchar](10) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[Gioitinh] [nchar](10) NULL,
	[Ngaysinh] [datetime] NULL,
	[Diachi] [nvarchar](50) NULL,
	[SDT] [varchar](10) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAISANPHAM]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISANPHAM](
	[Maloai] [varchar](10) NOT NULL,
	[TenLSP] [nvarchar](50) NULL,
 CONSTRAINT [PK_LOAISANPHAM] PRIMARY KEY CLUSTERED 
(
	[Maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MaNCC] [varchar](10) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[SDT] [varchar](10) NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [varchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[Gioitinh] [nchar](10) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Dienthoai] [varchar](50) NULL,
	[Ngaysinh] [datetime] NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHAPHANG]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAPHANG](
	[MaHD] [varchar](10) NOT NULL,
	[MaNV] [varchar](10) NULL,
	[NgayHD] [datetime] NULL,
	[MaNCC] [varchar](10) NULL,
	[Trigia] [float] NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MaSP] [varchar](10) NOT NULL,
	[TenSP] [nvarchar](50) NULL,
	[MaLoai] [varchar](10) NULL,
	[MaNCC] [varchar](10) NULL,
	[Giaban] [float] NULL,
	[Giagoc] [float] NULL,
	[Tonkho] [int] NULL,
	[Size] [char](3) NULL,
	[MaCL] [varchar](10) NULL,
	[FilePath] [text] NULL,
 CONSTRAINT [PK_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THONGTINTAIKHOAN]    Script Date: 1/2/2025 11:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THONGTINTAIKHOAN](
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[Ten] [nvarchar](100) NOT NULL,
	[SDT] [char](10) NOT NULL,
	[Gioitinh] [nchar](10) NOT NULL,
	[Ngaysinh] [date] NOT NULL,
	[Matkhau] [char](10) NULL,
 CONSTRAINT [PK__THONGTIN__55F68FC100BF6020] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CHATLIEU] ([MaCL], [Tenchatlieu]) VALUES (N'CL001', N'Bông')
INSERT [dbo].[CHATLIEU] ([MaCL], [Tenchatlieu]) VALUES (N'CL002', N'Polyester')
INSERT [dbo].[CHATLIEU] ([MaCL], [Tenchatlieu]) VALUES (N'CL003', N'Lụa')
INSERT [dbo].[CHATLIEU] ([MaCL], [Tenchatlieu]) VALUES (N'CL004', N'Len')
INSERT [dbo].[CHATLIEU] ([MaCL], [Tenchatlieu]) VALUES (N'CL005', N'Denim')
INSERT [dbo].[CHATLIEU] ([MaCL], [Tenchatlieu]) VALUES (N'CL006', N'Da')
INSERT [dbo].[CHATLIEU] ([MaCL], [Tenchatlieu]) VALUES (N'CL007', N'Kaki')
GO
INSERT [dbo].[CTHOADON] ([MaHD], [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'HD001', N'SP001', 2, 800000, 50000, 1618000)
INSERT [dbo].[CTHOADON] ([MaHD], [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'HD001', N'SP005', 1, 300000, 20000, 334000)
INSERT [dbo].[CTHOADON] ([MaHD], [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'HD002', N'SP002', 3, 420000, 60000, 1410000)
INSERT [dbo].[CTHOADON] ([MaHD], [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'HD002', N'SP008', 2, 420000, 50000, 890000)
INSERT [dbo].[CTHOADON] ([MaHD], [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'HD003', N'SP003', 1, 850000, 70000, 827000)
INSERT [dbo].[CTHOADON] ([MaHD], [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'HD003', N'SP007', 4, 100000, 5000, 575000)
INSERT [dbo].[CTHOADON] ([MaHD], [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'HD004', N'SP004', 2, 600000, 80000, 1210000)
INSERT [dbo].[CTHOADON] ([MaHD], [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'HD004', N'SP006', 1, 685000, 35000, 700000)
INSERT [dbo].[CTHOADON] ([MaHD], [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'HD005', N'SP001', 1, 800000, 50000, 784000)
INSERT [dbo].[CTHOADON] ([MaHD], [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'HD005', N'SP003', 3, 850000, 150000, 2541000)
GO
INSERT [dbo].CTNHAP(MaHD, [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'NH001', N'SP003', 10, 550000, 0, 5500000)
INSERT [dbo].CTNHAP(MaHD, [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'NH002', N'SP004', 10, 400000, 100000, 3900000)
INSERT [dbo].CTNHAP (MaHD, [MaSP], [Soluong], [Dongia], [Giamgia], [Thanhtien]) VALUES (N'NH003', N'SP007', 20, 50000, 50000, 950000)
GO
INSERT [dbo].[DONHANG] ([MaHD], [MaNV], [NgayHD], [MaKH], [Trigia]) VALUES (N'HD001', N'NV001', CAST(N'2024-12-01T00:00:00.000' AS DateTime), N'23520001', 500000)
INSERT [dbo].[DONHANG] ([MaHD], [MaNV], [NgayHD], [MaKH], [Trigia]) VALUES (N'HD002', N'NV002', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'23520004', 750000)
INSERT [dbo].[DONHANG] ([MaHD], [MaNV], [NgayHD], [MaKH], [Trigia]) VALUES (N'HD003', N'NV003', CAST(N'2024-12-03T00:00:00.000' AS DateTime), N'23520003', 300000)
INSERT [dbo].[DONHANG] ([MaHD], [MaNV], [NgayHD], [MaKH], [Trigia]) VALUES (N'HD004', N'NV004', CAST(N'2024-12-04T00:00:00.000' AS DateTime), N'23520006', 1500000)
INSERT [dbo].[DONHANG] ([MaHD], [MaNV], [NgayHD], [MaKH], [Trigia]) VALUES (N'HD005', N'NV005', CAST(N'2024-12-05T00:00:00.000' AS DateTime), N'23520008', 2000000)
INSERT [dbo].[DONHANG] ([MaHD], [MaNV], [NgayHD], [MaKH], [Trigia]) VALUES (N'HD006', N'NV001', CAST(N'2024-12-06T00:00:00.000' AS DateTime), N'23520014', 1800000)
INSERT [dbo].[DONHANG] ([MaHD], [MaNV], [NgayHD], [MaKH], [Trigia]) VALUES (N'HD007', N'NV002', CAST(N'2024-12-07T00:00:00.000' AS DateTime), N'23520009', 400000)
INSERT [dbo].[DONHANG] ([MaHD], [MaNV], [NgayHD], [MaKH], [Trigia]) VALUES (N'HD008', N'NV003', CAST(N'2024-12-08T00:00:00.000' AS DateTime), N'23520007', 2500000)
INSERT [dbo].[DONHANG] ([MaHD], [MaNV], [NgayHD], [MaKH], [Trigia]) VALUES (N'HD009', N'NV004', CAST(N'2024-12-09T00:00:00.000' AS DateTime), N'23520011', 1200000)
INSERT [dbo].[DONHANG] ([MaHD], [MaNV], [NgayHD], [MaKH], [Trigia]) VALUES (N'HD010', N'NV005', CAST(N'2024-12-10T00:00:00.000' AS DateTime), N'23520015', 800000)
	GO
	INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Gioitinh], [Ngaysinh], [Diachi], [SDT]) VALUES (N'KH001', N'Nguyễn Thành Tiến', N'Nam       ', CAST(N'1976-02-06T00:00:00.000' AS DateTime), N'Bình Định', N'0893727328')
	INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Gioitinh], [Ngaysinh], [Diachi], [SDT]) VALUES (N'KH002', N'Trần Thị Yến Nhi', N'Nữ        ', CAST(N'1999-08-16T00:00:00.000' AS DateTime), N'Bến Tre', N'0893753548')
	INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Gioitinh], [Ngaysinh], [Diachi], [SDT]) VALUES (N'KH003', N'Nguyễn Văn Thành', N'Nam       ', CAST(N'1985-03-19T00:00:00.000' AS DateTime), N'Long An', N'0876327344')
	INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Gioitinh], [Ngaysinh], [Diachi], [SDT]) VALUES (N'KH004', N'Đỗ Văn Đức', N'Nam       ', CAST(N'1996-10-06T00:00:00.000' AS DateTime), N'Vĩnh Long', N'0867327328')
	INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Gioitinh], [Ngaysinh], [Diachi], [SDT]) VALUES (N'KH005', N'Trần Bảo Quốc', N'Nam       ', CAST(N'1989-07-09T00:00:00.000' AS DateTime), N'An Giang', N'0893475928')
	INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Gioitinh], [Ngaysinh], [Diachi], [SDT]) VALUES (N'KH006', N'Hồ Mỹ Hà', N'Nữ        ', CAST(N'1920-10-25T00:00:00.000' AS DateTime), N'Đồng Tháp', N'0935727328')
	INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Gioitinh], [Ngaysinh], [Diachi], [SDT]) VALUES (N'KH007', N'Trần Thùy Dương', N'Nữ        ', CAST(N'2002-06-06T00:00:00.000' AS DateTime), N'Huế', N'0736839223')
	INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Gioitinh], [Ngaysinh], [Diachi], [SDT]) VALUES (N'KH008', N'Nguyễn Xuân Hảo', N'Nam       ', CAST(N'1995-03-17T00:00:00.000' AS DateTime), N'Hậu Giang', N'0828363843')
	INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Gioitinh], [Ngaysinh], [Diachi], [SDT]) VALUES (N'KH009', N'Võ Văn Vương', N'Nam       ', CAST(N'2001-01-06T00:00:00.000' AS DateTime), N'Cà Mau', N'0749494223')
	INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [Gioitinh], [Ngaysinh], [Diachi], [SDT]) VALUES (N'KH010', N'Nguyễn Thị My', N'Nữ        ', CAST(N'2000-06-02T00:00:00.000' AS DateTime), N'Bến Tre', N'0935764023')
GO
INSERT [dbo].[LOAISANPHAM] ([Maloai], [TenLSP]) VALUES (N'LSP01', N'Quần')
INSERT [dbo].[LOAISANPHAM] ([Maloai], [TenLSP]) VALUES (N'LSP02', N'Áo')
INSERT [dbo].[LOAISANPHAM] ([Maloai], [TenLSP]) VALUES (N'LSP03', N'Đầm')
INSERT [dbo].[LOAISANPHAM] ([Maloai], [TenLSP]) VALUES (N'LSP04', N'Váy')
INSERT [dbo].[LOAISANPHAM] ([Maloai], [TenLSP]) VALUES (N'LSP05', N'Giày')
INSERT [dbo].[LOAISANPHAM] ([Maloai], [TenLSP]) VALUES (N'LSP06', N'Nón')
INSERT [dbo].[LOAISANPHAM] ([Maloai], [TenLSP]) VALUES (N'LSP07', N'Áo Khoác')
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [SDT]) VALUES (N'NCC01', N'Trần Đức', N'0976589654')
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [SDT]) VALUES (N'NCC02', N'Thành Danh', N'0548776397')
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [SDT]) VALUES (N'NCC03', N'Nguyên Khang', N'0753375195')
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [SDT]) VALUES (N'NCC04', N'Quốc Cường', N'0745365123')
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [SDT]) VALUES (N'NCC05', N'Sapo', N'0453946523')
GO
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [Gioitinh], [Diachi], [Dienthoai], [Ngaysinh]) VALUES (N'NV001', N'Nguyễn Văn Chí', N'Nam       ', N'Hà Nội', N'0912345678', CAST(N'1990-05-15T00:00:00.000' AS DateTime))
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [Gioitinh], [Diachi], [Dienthoai], [Ngaysinh]) VALUES (N'NV002', N'Trần Thị Bình', N'Nữ        ', N'TP. Hồ Chí Minh', N'0938765432', CAST(N'1985-08-20T00:00:00.000' AS DateTime))
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [Gioitinh], [Diachi], [Dienthoai], [Ngaysinh]) VALUES (N'NV003', N'Phạm Văn Cường', N'Nam       ', N'Đà Nẵng', N'0923456789', CAST(N'1992-12-10T00:00:00.000' AS DateTime))
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [Gioitinh], [Diachi], [Dienthoai], [Ngaysinh]) VALUES (N'NV004', N'Lê Thị Dung', N'Nữ        ', N'Hải Phòng', N'0945678901', CAST(N'1988-07-25T00:00:00.000' AS DateTime))
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [Gioitinh], [Diachi], [Dienthoai], [Ngaysinh]) VALUES (N'NV005', N'Hoàng Văn Bảo', N'Nam       ', N'Cần Thơ', N'0956789012', CAST(N'1995-11-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[NHAPHANG] ([MaHD], [MaNV], [NgayHD], [MaNCC], [Trigia]) VALUES (N'NH001', N'NV001', CAST(N'2025-01-01T00:00:00.000' AS DateTime), N'NCC02', 5500000)
INSERT [dbo].[NHAPHANG] ([MaHD], [MaNV], [NgayHD], [MaNCC], [Trigia]) VALUES (N'NH002', N'NV002', CAST(N'2025-01-02T00:00:00.000' AS DateTime), N'NCC02', 3900000)
INSERT [dbo].[NHAPHANG] ([MaHD], [MaNV], [NgayHD], [MaNCC], [Trigia]) VALUES (N'NH003', N'NV003', CAST(N'2025-01-03T00:00:00.000' AS DateTime), N'NCC01', 1000000)
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [MaLoai], [MaNCC], [Giaban], [Giagoc], [Tonkho], [Size], [MaCL], [FilePath]) VALUES (N'SP001', N'Đầm ren', N'LSP03', N'NCC01', 834000, 510000, 50, N'S  ', N'CL001', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [MaLoai], [MaNCC], [Giaban], [Giagoc], [Tonkho], [Size], [MaCL], [FilePath]) VALUES (N'SP002', N'Áo sơ mi', N'LSP02', N'NCC03', 490000, 220000, 80, N'M  ', N'CL002', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [MaLoai], [MaNCC], [Giaban], [Giagoc], [Tonkho], [Size], [MaCL], [FilePath]) VALUES (N'SP003', N'Váy lụa', N'LSP04', N'NCC02', 897000, 550000, 30, N'L  ', N'CL003', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [MaLoai], [MaNCC], [Giaban], [Giagoc], [Tonkho], [Size], [MaCL], [FilePath]) VALUES (N'SP004', N'Áo len', N'LSP02', N'NCC02', 645000, 400000, 40, N'S  ', N'CL004', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [MaLoai], [MaNCC], [Giaban], [Giagoc], [Tonkho], [Size], [MaCL], [FilePath]) VALUES (N'SP005', N'Quần jean', N'LSP01', N'NCC04', 354000, 100000, 60, N'M  ', N'CL005', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [MaLoai], [MaNCC], [Giaban], [Giagoc], [Tonkho], [Size], [MaCL], [FilePath]) VALUES (N'SP006', N'Giày da', N'LSP05', N'NCC05', 735000, 495000, 50, N'L  ', N'CL006', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [MaLoai], [MaNCC], [Giaban], [Giagoc], [Tonkho], [Size], [MaCL], [FilePath]) VALUES (N'SP007', N'Nón lưỡi trai', N'LSP06', N'NCC01', 145000, 50000, 40, N'M  ', N'CL001', N'')
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [MaLoai], [MaNCC], [Giaban], [Giagoc], [Tonkho], [Size], [MaCL], [FilePath]) VALUES (N'SP008', N'Áo khoác kaki', N'LSP07', N'NCC03', 470000, 250000, 50, N'L  ', N'CL007', N'')
GO
INSERT [dbo].[THONGTINTAIKHOAN] ([TenDangNhap], [Ten], [SDT], [Gioitinh], [Ngaysinh], [Matkhau]) VALUES (N'DANH', N'Nguyễn Thành Danh', N'0898246826', N'Nam       ', CAST(N'2005-08-16' AS Date), N'danh      ')
INSERT [dbo].[THONGTINTAIKHOAN] ([TenDangNhap], [Ten], [SDT], [Gioitinh], [Ngaysinh], [Matkhau]) VALUES (N'HUUDUC', N'Trần Hữu Đức', N'0934567890', N'Nam       ', CAST(N'2005-08-20' AS Date), N'duc       ')
INSERT [dbo].[THONGTINTAIKHOAN] ([TenDangNhap], [Ten], [SDT], [Gioitinh], [Ngaysinh], [Matkhau]) VALUES (N'KHANG', N'Lê Nguyên Khang', N'0923456789', N'Nam       ', CAST(N'2005-12-10' AS Date), N'khang     ')
GO
ALTER TABLE [dbo].[CTHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CTHOADON_DONHANG] FOREIGN KEY([MaHD])
REFERENCES [dbo].[DONHANG] ([MaHD])
GO
ALTER TABLE [dbo].[CTHOADON] CHECK CONSTRAINT [FK_CTHOADON_DONHANG]
GO
ALTER TABLE [dbo].[CTHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CTHOADON_SANPHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[CTHOADON] CHECK CONSTRAINT [FK_CTHOADON_SANPHAM]
GO
ALTER TABLE [dbo].[CTNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CTNHAP_NHAPHANG] FOREIGN KEY([MaHD])
REFERENCES [dbo].[NHAPHANG] ([MaHD])
GO
ALTER TABLE [dbo].[CTNHAP] CHECK CONSTRAINT [FK_CTNHAP_NHAPHANG]
GO
ALTER TABLE [dbo].[CTNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CTNHAP_SANPHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[CTNHAP] CHECK CONSTRAINT [FK_CTNHAP_SANPHAM]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DONHANG_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DONHANG_KHACHHANG]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DONHANG_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DONHANG_NHANVIEN]
GO
ALTER TABLE [dbo].[NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[NHAPHANG] CHECK CONSTRAINT [FK_HOADON_NHANVIEN]
GO
ALTER TABLE [dbo].[NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_NHAPHANG_NHACUNGCAP] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NHACUNGCAP] ([MaNCC])
GO
ALTER TABLE [dbo].[NHAPHANG] CHECK CONSTRAINT [FK_NHAPHANG_NHACUNGCAP]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_CHATLIEU] FOREIGN KEY([MaCL])
REFERENCES [dbo].[CHATLIEU] ([MaCL])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_CHATLIEU]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_LOAISANPHAM] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LOAISANPHAM] ([Maloai])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_LOAISANPHAM]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_NHACUNGCAP] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NHACUNGCAP] ([MaNCC])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_NHACUNGCAP]
GO
USE [master]
GO
ALTER DATABASE [file_database] SET  READ_WRITE 
GO
--///////
--  delete from CTHOADON
-- delete from CTNHAP
-- delete from DONHANG
--  delete from NHAPHANG
-- delete from KHACHHANG
-- delete from SANPHAM
-- delete from CHATLIEU
-- delete from LOAISANPHAM
-- delete from DOANHTHU
-- delete from NHACUNGCAP
-- delete from NHANVIEN
--  delete from THONGTINTAIKHOAN
--//////////