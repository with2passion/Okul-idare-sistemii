USE [WFormDB]
GO
/****** Object:  Table [dbo].[DersTab]    Script Date: 8.12.2022 19:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DersTab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NULL,
	[Kredi] [int] NULL,
	[OkulYonetimId] [int] NULL,
 CONSTRAINT [PK_DersTab] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgrenciDersTab]    Script Date: 8.12.2022 19:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgrenciDersTab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DersId] [int] NULL,
	[OgrenciId] [int] NULL,
 CONSTRAINT [PK_OgrenciDersTab] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgrenciTab]    Script Date: 8.12.2022 19:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgrenciTab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [nvarchar](50) NULL,
	[KayitTarih] [nvarchar](50) NULL,
	[OgrenciNo] [int] NULL,
	[DTarih] [nvarchar](50) NULL,
	[Bolum] [nvarchar](50) NULL,
 CONSTRAINT [PK_OgrenciTab] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OkulYonetimTab]    Script Date: 8.12.2022 19:17:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OkulYonetimTab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [nvarchar](50) NULL,
	[Gorevi] [nvarchar](50) NULL,
	[YonetimTip] [int] NULL,
 CONSTRAINT [PK_OkulYonetimTab] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DersTab] ON 

INSERT [dbo].[DersTab] ([Id], [Ad], [Kredi], [OkulYonetimId]) VALUES (2, N'Yazılım', 2, 1)
SET IDENTITY_INSERT [dbo].[DersTab] OFF
GO
SET IDENTITY_INSERT [dbo].[OgrenciDersTab] ON 

INSERT [dbo].[OgrenciDersTab] ([Id], [DersId], [OgrenciId]) VALUES (1, 2, 2)
INSERT [dbo].[OgrenciDersTab] ([Id], [DersId], [OgrenciId]) VALUES (2, 2, 2)
INSERT [dbo].[OgrenciDersTab] ([Id], [DersId], [OgrenciId]) VALUES (3, 2, 1)
INSERT [dbo].[OgrenciDersTab] ([Id], [DersId], [OgrenciId]) VALUES (4, 2, 3)
SET IDENTITY_INSERT [dbo].[OgrenciDersTab] OFF
GO
SET IDENTITY_INSERT [dbo].[OgrenciTab] ON 

INSERT [dbo].[OgrenciTab] ([Id], [AdSoyad], [KayitTarih], [OgrenciNo], [DTarih], [Bolum]) VALUES (1, N'ayşegül kutlay', N'2020', 123456, N'2002', N'yazılım')
INSERT [dbo].[OgrenciTab] ([Id], [AdSoyad], [KayitTarih], [OgrenciNo], [DTarih], [Bolum]) VALUES (2, N'ahmet', N'2020', 234567, N'2003', N'yazılım')
INSERT [dbo].[OgrenciTab] ([Id], [AdSoyad], [KayitTarih], [OgrenciNo], [DTarih], [Bolum]) VALUES (3, N'Ali Demir', N'2021', 456789, N'2003', N'Hukuk')
SET IDENTITY_INSERT [dbo].[OgrenciTab] OFF
GO
SET IDENTITY_INSERT [dbo].[OkulYonetimTab] ON 

INSERT [dbo].[OkulYonetimTab] ([Id], [AdSoyad], [Gorevi], [YonetimTip]) VALUES (1, N'Emrah Sarı', N'Öğretmen', 12)
INSERT [dbo].[OkulYonetimTab] ([Id], [AdSoyad], [Gorevi], [YonetimTip]) VALUES (2, N'Can Yaman', N'idare', 11)
SET IDENTITY_INSERT [dbo].[OkulYonetimTab] OFF
GO
ALTER TABLE [dbo].[DersTab]  WITH CHECK ADD  CONSTRAINT [FK_DersTab_OkulYonetimTab] FOREIGN KEY([OkulYonetimId])
REFERENCES [dbo].[OkulYonetimTab] ([Id])
GO
ALTER TABLE [dbo].[DersTab] CHECK CONSTRAINT [FK_DersTab_OkulYonetimTab]
GO
ALTER TABLE [dbo].[OgrenciDersTab]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDersTab_DersTab] FOREIGN KEY([DersId])
REFERENCES [dbo].[DersTab] ([Id])
GO
ALTER TABLE [dbo].[OgrenciDersTab] CHECK CONSTRAINT [FK_OgrenciDersTab_DersTab]
GO
ALTER TABLE [dbo].[OgrenciDersTab]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDersTab_OgrenciTab] FOREIGN KEY([OgrenciId])
REFERENCES [dbo].[OgrenciTab] ([Id])
GO
ALTER TABLE [dbo].[OgrenciDersTab] CHECK CONSTRAINT [FK_OgrenciDersTab_OgrenciTab]
GO
