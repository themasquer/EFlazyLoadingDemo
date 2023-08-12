use master
go
if exists (select name from sys.databases where name = 'KursAdvancedDB')
begin
	alter database KursAdvancedDB set single_user with rollback immediate -- veritabanı bağlantısını koparmak için özel sorgu
	drop database KursAdvancedDB -- veritabanını silen esas sorgu
end
go
create database KursAdvancedDB
go
USE [KursAdvancedDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[Bolum]    Script Date: 21.06.2023 01:30:14 ******/
CREATE TABLE [dbo].[Bolum](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Bolum] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ders]    Script Date: 21.06.2023 01:30:14 ******/
CREATE TABLE [dbo].[Ders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [varchar](75) NOT NULL,
	[Icerik] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrenci]    Script Date: 21.06.2023 01:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenci](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](100) NOT NULL,
	[Soyadi] [varchar](100) NOT NULL,
	[OgrenciNo] int NULL,
	[BolumId] int NOT NULL,
	[MezunMu] bit NOT NULL,
	[Cinsiyeti] int NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgrenciDers]    Script Date: 21.06.2023 01:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgrenciDers](
	[Id] int IDENTITY(1,1) NOT NULL,
	[OgrenciId] [int] NOT NULL,
	[DersId] [int] NOT NULL,
 CONSTRAINT [PK_OgrenciDers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bolum] ON 
GO
INSERT [dbo].[Bolum] ([Id], [Adi]) VALUES (1, N'1. Grup')
GO
INSERT [dbo].[Bolum] ([Id], [Adi]) VALUES (2, N'2. Grup')
GO
SET IDENTITY_INSERT [dbo].[Bolum] OFF
GO
SET IDENTITY_INSERT [dbo].[Ders] ON 
GO
INSERT [dbo].[Ders] ([Id], [Adi], [Icerik]) VALUES (1, N'Matematik', NULL)
GO
INSERT [dbo].[Ders] ([Id], [Adi], [Icerik]) VALUES (2, N'Türkçe', NULL)
GO
INSERT [dbo].[Ders] ([Id], [Adi], [Icerik]) VALUES (3, N'Fen', N'Fizik, Kimya ve Biyoloji')
GO
SET IDENTITY_INSERT [dbo].[Ders] OFF
GO
SET IDENTITY_INSERT [dbo].[Ogrenci] ON 
GO
INSERT [dbo].[Ogrenci] ([Id], [Adi], [Soyadi], [OgrenciNo], [BolumId], [MezunMu], [Cinsiyeti]) VALUES (1, N'Çağıl', N'Alsaç', 10000, 2, 1, 1)
GO
INSERT [dbo].[Ogrenci] ([Id], [Adi], [Soyadi], [OgrenciNo], [BolumId], [MezunMu], [Cinsiyeti]) VALUES (2, N'Yasemin', N'Kaya', 10001, 1, 0, 2)
GO
SET IDENTITY_INSERT [dbo].[Ogrenci] OFF
GO
SET IDENTITY_INSERT [dbo].[OgrenciDers] ON 
GO
INSERT [dbo].[OgrenciDers] ([Id], [OgrenciId], [DersId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[OgrenciDers] ([Id], [OgrenciId], [DersId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[OgrenciDers] ([Id], [OgrenciId], [DersId]) VALUES (3, 1, 3)
GO
INSERT [dbo].[OgrenciDers] ([Id], [OgrenciId], [DersId]) VALUES (4, 2, 1)
GO
INSERT [dbo].[OgrenciDers] ([Id], [OgrenciId], [DersId]) VALUES (5, 2, 3)
GO
SET IDENTITY_INSERT [dbo].[OgrenciDers] OFF
GO
ALTER TABLE [dbo].[OgrenciDers]  WITH CHECK ADD FOREIGN KEY([DersId])
REFERENCES [dbo].[Ders] ([Id])
GO
ALTER TABLE [dbo].[OgrenciDers]  WITH CHECK ADD FOREIGN KEY([OgrenciId])
REFERENCES [dbo].[Ogrenci] ([Id])
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD FOREIGN KEY([BolumId])
REFERENCES [dbo].[Bolum] ([Id])
GO
