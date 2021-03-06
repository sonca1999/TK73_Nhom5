CREATE DATABASE QLTV
USE [QLTV]
GO
/****** Object:  Table [dbo].[Ctmuontra]    Script Date: 6/16/2020 4:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ctmuontra](
	[MaSach] [int]  NOT NULL,
	[MaMT] [int] NOT NULL,
	[DaTra] [bit] NOT NULL,
	[Ngaytra] [date] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ctmuontra] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC,
	[MaMT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docgia]    Script Date: 6/16/2020 4:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docgia](
	[MaDG] INT IDENTITY(1,1) NOT NULL,
	[TenDG] [nvarchar](50) NOT NULL,
	[SDT] [nchar](10) NULL,
	[MaThe] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Muontra]    Script Date: 6/16/2020 4:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Muontra](
	[MaMT] INT IDENTITY(1,1) NOT NULL,
	[MaThe] [int] NULL,
	[Ngaymuon] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 6/16/2020 4:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] INT IDENTITY(1,1) NOT NULL,
	[TenSach] [nvarchar](50) NULL,
	[MaTG] [int] NULL,
	[MaTL] [int] NULL,
	[NamSX] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tacgia]    Script Date: 6/16/2020 4:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tacgia](
	[MaTG] INT IDENTITY(1,1) NOT NULL,
	[TenTG] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Theloai]    Script Date: 6/16/2020 4:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Theloai](
	[MaTL] INT IDENTITY(1,1) NOT NULL,
	[TenTL] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thethuvien]    Script Date: 6/16/2020 4:53:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thethuvien](
	[MaThe] INT IDENTITY(1,1) NOT NULL,
	[NgayBD] [date] NOT NULL,
	[NgayHH] [date] NOT NULL,
	[GhiChu] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Ctmuontra] ([MaSach], [MaMT], [DaTra], [Ngaytra], [GhiChu]) VALUES (1, 1, 1, CAST(N'2019-02-15' AS Date), NULL)
INSERT [dbo].[Ctmuontra] ([MaSach], [MaMT], [DaTra], [Ngaytra], [GhiChu]) VALUES (1, 6, 1, CAST(N'2020-06-01' AS Date), NULL)
INSERT [dbo].[Ctmuontra] ([MaSach], [MaMT], [DaTra], [Ngaytra], [GhiChu]) VALUES (2, 4, 0, CAST(N'2020-06-10' AS Date), NULL)
INSERT [dbo].[Ctmuontra] ([MaSach], [MaMT], [DaTra], [Ngaytra], [GhiChu]) VALUES (2, 6, 0, CAST(N'2020-06-11' AS Date), NULL)
INSERT [dbo].[Ctmuontra] ([MaSach], [MaMT], [DaTra], [Ngaytra], [GhiChu]) VALUES (3, 5, 0, CAST(N'2020-06-11' AS Date), NULL)
INSERT [dbo].[Ctmuontra] ([MaSach], [MaMT], [DaTra], [Ngaytra], [GhiChu]) VALUES (3, 6, 1, CAST(N'2020-06-06' AS Date), NULL)
INSERT [dbo].[Ctmuontra] ([MaSach], [MaMT], [DaTra], [Ngaytra], [GhiChu]) VALUES (4, 2, 1, CAST(N'2019-11-09' AS Date), NULL)
INSERT [dbo].[Ctmuontra] ([MaSach], [MaMT], [DaTra], [Ngaytra], [GhiChu]) VALUES (4, 3, 1, CAST(N'2019-11-21' AS Date), NULL)
GO
INSERT [dbo].[Docgia] ( [TenDG], [SDT], [MaThe]) VALUES ( N'Son Ca', N'1023456789', 1)
INSERT [dbo].[Docgia] ( [TenDG], [SDT], [MaThe]) VALUES ( N'Minh Anh', N'1203456789', 2)
INSERT [dbo].[Docgia] ( [TenDG], [SDT], [MaThe]) VALUES ( N'Kieu Phuong', N'1230456789', 3)
INSERT [dbo].[Docgia] ( [TenDG], [SDT], [MaThe]) VALUES ( N'Tra Mi', N'1234056789', 4)
INSERT [dbo].[Docgia] ( [TenDG], [SDT], [MaThe]) VALUES ( N'Thanh Truc', N'1234506789', 5)
GO
INSERT [dbo].[Muontra] ( [MaThe], [Ngaymuon]) VALUES ( 3, CAST(N'2019-01-02' AS Date))
INSERT [dbo].[Muontra] ( [MaThe], [Ngaymuon]) VALUES ( 3, CAST(N'2019-10-26' AS Date))
INSERT [dbo].[Muontra] ( [MaThe], [Ngaymuon]) VALUES ( 1, CAST(N'2019-11-07' AS Date))
INSERT [dbo].[Muontra] ( [MaThe], [Ngaymuon]) VALUES ( 2, CAST(N'2020-05-27' AS Date))
INSERT [dbo].[Muontra] ( [MaThe], [Ngaymuon]) VALUES ( 4, CAST(N'2020-05-28' AS Date))
INSERT [dbo].[Muontra] ( [MaThe], [Ngaymuon]) VALUES ( 2, CAST(N'2020-06-16' AS Date))
GO
INSERT [dbo].[Sach] ( [TenSach], [MaTG], [MaTL], [NamSX]) VALUES ( N'Su im lang cua bay cuu', 3, 1, CAST(N'1988-01-01' AS Date))
INSERT [dbo].[Sach] ( [TenSach], [MaTG], [MaTL], [NamSX]) VALUES ( N'Cho toi xin mot ve di tuoi tho', 1, 6, CAST(N'2008-01-01' AS Date))
INSERT [dbo].[Sach] ( [TenSach], [MaTG], [MaTL], [NamSX]) VALUES ( N'Sherlock Holmes', 2, 1, CAST(N'1987-01-01' AS Date))
INSERT [dbo].[Sach] ( [TenSach], [MaTG], [MaTL], [NamSX]) VALUES ( N'Phep mau cua tam tri', 5, 2, CAST(N'2016-01-01' AS Date))
INSERT [dbo].[Sach] ( [TenSach], [MaTG], [MaTL], [NamSX]) VALUES ( N'The origin of species', 4, 2, CAST(N'1859-01-01' AS Date))
GO
INSERT [dbo].[Tacgia] ( [TenTG], [GhiChu]) VALUES ( N'Nguyen Nhat Anh', NULL)
INSERT [dbo].[Tacgia] ( [TenTG], [GhiChu]) VALUES ( N'Conan Doyle', NULL)
INSERT [dbo].[Tacgia] ( [TenTG], [GhiChu]) VALUES ( N'Thomas Harris', NULL)
INSERT [dbo].[Tacgia] ( [TenTG], [GhiChu]) VALUES ( N'Charles Darwin', NULL)
INSERT [dbo].[Tacgia] ( [TenTG], [GhiChu]) VALUES ( N'Joseph Murphy', NULL)
INSERT [dbo].[Tacgia] ( [TenTG], [GhiChu]) VALUES ( N'To Hoai', Null)
GO
INSERT [dbo].[Theloai] ( [TenTL]) VALUES ( N'Trinh Tham')
INSERT [dbo].[Theloai] ( [TenTL]) VALUES ( N'Khoa Hoc')
INSERT [dbo].[Theloai] ( [TenTL]) VALUES ( N'Giao Duc')
INSERT [dbo].[Theloai] ( [TenTL]) VALUES ( N'Ngon Ngu')
INSERT [dbo].[Theloai] ( [TenTL]) VALUES ( N'Ngon tinh')
INSERT [dbo].[Theloai] ( [TenTL]) VALUES ( N'Thieu nhi')
GO
INSERT [dbo].[Thethuvien] ( [NgayBD], [NgayHH], [GhiChu]) VALUES ( CAST(N'2017-02-10' AS Date), CAST(N'2022-02-10' AS Date), NULL)
INSERT [dbo].[Thethuvien] ( [NgayBD], [NgayHH], [GhiChu]) VALUES ( CAST(N'2016-08-11' AS Date), CAST(N'2021-08-11' AS Date), NULL)
INSERT [dbo].[Thethuvien] ( [NgayBD], [NgayHH], [GhiChu]) VALUES ( CAST(N'2015-10-10' AS Date), CAST(N'2020-10-10' AS Date), NULL)
INSERT [dbo].[Thethuvien] ( [NgayBD], [NgayHH], [GhiChu]) VALUES ( CAST(N'2019-12-24' AS Date), CAST(N'2024-12-24' AS Date), NULL)
INSERT [dbo].[Thethuvien] ( [NgayBD], [NgayHH], [GhiChu]) VALUES ( CAST(N'2018-04-10' AS Date), CAST(N'2023-04-10' AS Date), NULL)
GO
ALTER TABLE [dbo].[Ctmuontra]  WITH CHECK ADD FOREIGN KEY([MaMT])
REFERENCES [dbo].[Muontra] ([MaMT])
GO
ALTER TABLE [dbo].[Ctmuontra]  WITH CHECK ADD FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[Docgia]  WITH CHECK ADD FOREIGN KEY([MaThe])
REFERENCES [dbo].[Thethuvien] ([MaThe])
GO
ALTER TABLE [dbo].[Muontra]  WITH CHECK ADD FOREIGN KEY([MaThe])
REFERENCES [dbo].[Thethuvien] ([MaThe])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([MaTG])
REFERENCES [dbo].[Tacgia] ([MaTG])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([MaTL])
REFERENCES [dbo].[Theloai] ([MaTL])
GO
