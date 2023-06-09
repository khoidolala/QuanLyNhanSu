USE [QuanLyNhanSu]
GO
/****** Object:  Table [dbo].[tblChamCong]    Script Date: 19/04/2023 12:20:13 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChamCong](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [nvarchar](15) NULL,
	[TenNV] [nvarchar](50) NULL,
	[Ngay] [date] NULL,
	[ThoiGianVao] [time](7) NULL,
	[ThoiGianRa] [time](7) NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblChamCong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHSL]    Script Date: 19/04/2023 12:20:14 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHSL](
	[MaHSL] [nvarchar](15) NOT NULL,
	[HSL] [float] NULL,
 CONSTRAINT [PK_tblHSL] PRIMARY KEY CLUSTERED 
(
	[MaHSL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLuong]    Script Date: 19/04/2023 12:20:14 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLuong](
	[MaLuong] [nvarchar](15) NOT NULL,
	[Thang] [int] NULL,
	[MaNV] [nvarchar](15) NULL,
	[SoNgayLamViec] [int] NULL,
	[SoGioLamViec] [int] NULL,
	[MaHSL] [nvarchar](15) NULL,
	[MaThuong] [nvarchar](15) NULL,
	[MaPhuCap] [nvarchar](15) NULL,
	[TienPhat] [float] NULL,
	[TamUng] [float] NULL,
 CONSTRAINT [PK_tblLuong] PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPhongs]    Script Date: 19/04/2023 12:20:14 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPhongs](
	[MaPhong] [nvarchar](15) NOT NULL,
	[TenPhong] [nvarchar](50) NULL,
	[TenTruongPhong] [nvarchar](50) NULL,
	[DienThoaiPhong] [nvarchar](15) NULL,
 CONSTRAINT [PK_tblPhongs] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPhuCap]    Script Date: 19/04/2023 12:20:14 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPhuCap](
	[MaPhuCap] [nvarchar](15) NOT NULL,
	[TienPhuCap] [float] NULL,
 CONSTRAINT [PK_tblPhuCap] PRIMARY KEY CLUSTERED 
(
	[MaPhuCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblQuyen]    Script Date: 19/04/2023 12:20:14 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQuyen](
	[Quyen] [int] NOT NULL,
	[TenQuyen] [nvarchar](50) NULL,
	[Mota] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblQuyen] PRIMARY KEY CLUSTERED 
(
	[Quyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblThongTinNV]    Script Date: 19/04/2023 12:20:14 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblThongTinNV](
	[MaNV] [nvarchar](15) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[CMT] [nvarchar](50) NULL,
	[GioiTinh] [nchar](3) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[TrinhDo] [nvarchar](50) NULL,
	[MaHSL] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[SDT] [nvarchar](15) NULL,
	[MaPhong] [nvarchar](15) NULL,
	[BHXH] [float] NULL,
	[DanToc] [nvarchar](50) NULL,
	[TonGiao] [nvarchar](50) NULL,
	[UrlAnh] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblThongTinNV] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblThuong]    Script Date: 19/04/2023 12:20:14 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblThuong](
	[MaThuong] [nvarchar](15) NOT NULL,
	[TienThuong] [float] NULL,
	[LoaiThuong] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblThuong] PRIMARY KEY CLUSTERED 
(
	[MaThuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 19/04/2023 12:20:14 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
	[UserName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Quyen] [int] NULL,
	[MaNV] [nvarchar](15) NULL,
	[TenNV] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
	[IDUser] [int] NOT NULL,
 CONSTRAINT [PK_tblUsers_1] PRIMARY KEY CLUSTERED 
(
	[IDUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblChamCong]  WITH CHECK ADD  CONSTRAINT [FK_tblChamCong_tblThongTinNV] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tblThongTinNV] ([MaNV])
GO
ALTER TABLE [dbo].[tblChamCong] CHECK CONSTRAINT [FK_tblChamCong_tblThongTinNV]
GO
ALTER TABLE [dbo].[tblLuong]  WITH CHECK ADD  CONSTRAINT [FK_tblLuong_tblHSL] FOREIGN KEY([MaHSL])
REFERENCES [dbo].[tblHSL] ([MaHSL])
GO
ALTER TABLE [dbo].[tblLuong] CHECK CONSTRAINT [FK_tblLuong_tblHSL]
GO
ALTER TABLE [dbo].[tblLuong]  WITH CHECK ADD  CONSTRAINT [FK_tblLuong_tblPhuCap] FOREIGN KEY([MaPhuCap])
REFERENCES [dbo].[tblPhuCap] ([MaPhuCap])
GO
ALTER TABLE [dbo].[tblLuong] CHECK CONSTRAINT [FK_tblLuong_tblPhuCap]
GO
ALTER TABLE [dbo].[tblLuong]  WITH CHECK ADD  CONSTRAINT [FK_tblLuong_tblThongTinNV] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tblThongTinNV] ([MaNV])
GO
ALTER TABLE [dbo].[tblLuong] CHECK CONSTRAINT [FK_tblLuong_tblThongTinNV]
GO
ALTER TABLE [dbo].[tblLuong]  WITH CHECK ADD  CONSTRAINT [FK_tblLuong_tblThuong1] FOREIGN KEY([MaThuong])
REFERENCES [dbo].[tblThuong] ([MaThuong])
GO
ALTER TABLE [dbo].[tblLuong] CHECK CONSTRAINT [FK_tblLuong_tblThuong1]
GO
ALTER TABLE [dbo].[tblThongTinNV]  WITH CHECK ADD  CONSTRAINT [FK_tblThongTinNV_tblHSL] FOREIGN KEY([MaHSL])
REFERENCES [dbo].[tblHSL] ([MaHSL])
GO
ALTER TABLE [dbo].[tblThongTinNV] CHECK CONSTRAINT [FK_tblThongTinNV_tblHSL]
GO
ALTER TABLE [dbo].[tblThongTinNV]  WITH CHECK ADD  CONSTRAINT [FK_tblThongTinNV_tblPhongs] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[tblPhongs] ([MaPhong])
GO
ALTER TABLE [dbo].[tblThongTinNV] CHECK CONSTRAINT [FK_tblThongTinNV_tblPhongs]
GO
ALTER TABLE [dbo].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblUsers_tblQuyen] FOREIGN KEY([Quyen])
REFERENCES [dbo].[tblQuyen] ([Quyen])
GO
ALTER TABLE [dbo].[tblUsers] CHECK CONSTRAINT [FK_tblUsers_tblQuyen]
GO
ALTER TABLE [dbo].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblUsers_tblThongTinNV] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tblThongTinNV] ([MaNV])
GO
ALTER TABLE [dbo].[tblUsers] CHECK CONSTRAINT [FK_tblUsers_tblThongTinNV]
GO
