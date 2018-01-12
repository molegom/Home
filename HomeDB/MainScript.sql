USE [master]
GO
/****** Object:  Database [Flat]    Script Date: 13.01.2018 1:09:25 ******/
CREATE DATABASE [Flat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Flat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Flat.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Flat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Flat_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Flat] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Flat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Flat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Flat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Flat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Flat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Flat] SET ARITHABORT OFF 
GO
ALTER DATABASE [Flat] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Flat] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Flat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Flat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Flat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Flat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Flat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Flat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Flat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Flat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Flat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Flat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Flat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Flat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Flat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Flat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Flat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Flat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Flat] SET RECOVERY FULL 
GO
ALTER DATABASE [Flat] SET  MULTI_USER 
GO
ALTER DATABASE [Flat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Flat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Flat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Flat] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Flat', N'ON'
GO
USE [Flat]
GO
/****** Object:  Table [dbo].[FlatList]    Script Date: 13.01.2018 1:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlatList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ComplexName] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[NumberFlat] [int] NULL,
	[BuyDate] [datetime] NULL,
	[PhotoId] [int] NULL,
	[Status] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_FlatList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 13.01.2018 1:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FlatId] [int] NOT NULL,
	[ImageData] [varbinary](max) NULL,
	[ImageStatusId] [int] NOT NULL,
	[CreatedData] [datetime] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ImageStatus]    Script Date: 13.01.2018 1:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageStatus](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StatusHelper] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Keys]    Script Date: 13.01.2018 1:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Keys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](10) NULL,
	[Description] [nvarchar](250) NULL,
	[UpdatedTime] [datetime] NOT NULL,
 CONSTRAINT [pk_Keys_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[FlatList] ON 

INSERT [dbo].[FlatList] ([Id], [Name], [ComplexName], [Address], [NumberFlat], [BuyDate], [PhotoId], [Status], [CreatedDate]) VALUES (3, N'Akcent1', N'Akcent', N'Glushkova,  9B', 314, CAST(0x0000A80900000000 AS DateTime), NULL, N'Buying', CAST(0x0000A96C00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[FlatList] OFF
SET IDENTITY_INSERT [dbo].[Keys] ON 

INSERT [dbo].[Keys] ([Id], [Name], [Value], [Description], [UpdatedTime]) VALUES (1, N'StartIncomeMonth', N'3000', N'How much income by month on 2018', CAST(0x0000A86401762BEF AS DateTime))
INSERT [dbo].[Keys] ([Id], [Name], [Value], [Description], [UpdatedTime]) VALUES (2, N'MinStorage', N'2000', N'Minimus of storage to just in case', CAST(0x0000A864017EE217 AS DateTime))
INSERT [dbo].[Keys] ([Id], [Name], [Value], [Description], [UpdatedTime]) VALUES (3, N'Price1Flat', N'25000', N'Price for one room of flat', CAST(0x0000A864017F0473 AS DateTime))
INSERT [dbo].[Keys] ([Id], [Name], [Value], [Description], [UpdatedTime]) VALUES (4, N'Price1FlatRepair', N'12000', N'Price for repair of flat with one room', CAST(0x0000A864017F350E AS DateTime))
INSERT [dbo].[Keys] ([Id], [Name], [Value], [Description], [UpdatedTime]) VALUES (5, N'Price2Flat', N'36000', N'Price for two rooms of flat', CAST(0x0000A864017F0473 AS DateTime))
INSERT [dbo].[Keys] ([Id], [Name], [Value], [Description], [UpdatedTime]) VALUES (6, N'Price2FlatRepair', N'15000', N'Price for repair of flat with two rooms', CAST(0x0000A864017F350E AS DateTime))
INSERT [dbo].[Keys] ([Id], [Name], [Value], [Description], [UpdatedTime]) VALUES (11, N'Price3Flat', N'48000', N'Price for three rooms of flat', CAST(0x0000A86401805595 AS DateTime))
INSERT [dbo].[Keys] ([Id], [Name], [Value], [Description], [UpdatedTime]) VALUES (12, N'Price3FlatRepair', N'18000', N'Price for repair of flat with three rooms', CAST(0x0000A86401806FC2 AS DateTime))
INSERT [dbo].[Keys] ([Id], [Name], [Value], [Description], [UpdatedTime]) VALUES (13, N'PriceCredit', N'15000', N'Price of Credit which need to pay', CAST(0x0000A8640180EAE7 AS DateTime))
SET IDENTITY_INSERT [dbo].[Keys] OFF
/****** Object:  Index [UQ__ImageStatus_Id_Unique]    Script Date: 13.01.2018 1:09:26 ******/
ALTER TABLE [dbo].[ImageStatus] ADD  CONSTRAINT [UQ__ImageStatus_Id_Unique] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [U_Keys_Name]    Script Date: 13.01.2018 1:09:26 ******/
ALTER TABLE [dbo].[Keys] ADD  CONSTRAINT [U_Keys_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Images] ADD  CONSTRAINT [DF_Images_CreatedData]  DEFAULT (getdate()) FOR [CreatedData]
GO
ALTER TABLE [dbo].[Keys] ADD  DEFAULT (getdate()) FOR [UpdatedTime]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Flats] FOREIGN KEY([FlatId])
REFERENCES [dbo].[FlatList] ([Id])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Flats]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_ImagesStatus] FOREIGN KEY([ImageStatusId])
REFERENCES [dbo].[ImageStatus] ([Id])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_ImagesStatus]
GO
USE [master]
GO
ALTER DATABASE [Flat] SET  READ_WRITE 
GO
