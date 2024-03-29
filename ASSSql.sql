USE [master]
GO
/****** Object:  Database [AccommodationSearchSystem]    Script Date: 3/11/2024 12:55:41 AM ******/
CREATE DATABASE [AccommodationSearchSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AccommodationSearchSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.HUYVU\MSSQL\DATA\AccommodationSearchSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AccommodationSearchSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.HUYVU\MSSQL\DATA\AccommodationSearchSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AccommodationSearchSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AccommodationSearchSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AccommodationSearchSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AccommodationSearchSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AccommodationSearchSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AccommodationSearchSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AccommodationSearchSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [AccommodationSearchSystem] SET  MULTI_USER 
GO
ALTER DATABASE [AccommodationSearchSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AccommodationSearchSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AccommodationSearchSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AccommodationSearchSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AccommodationSearchSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AccommodationSearchSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AccommodationSearchSystem', N'ON'
GO
ALTER DATABASE [AccommodationSearchSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [AccommodationSearchSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AccommodationSearchSystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/11/2024 12:55:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/11/2024 12:55:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](10) NULL,
	[RoleID] [int] NOT NULL,
	[Gender] [bit] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[deleteAt] [date] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Convenient]    Script Date: 3/11/2024 12:55:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Convenient](
	[ConvenientID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK_Convenient] PRIMARY KEY CLUSTERED 
(
	[ConvenientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facility]    Script Date: 3/11/2024 12:55:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facility](
	[MotelID] [int] NOT NULL,
	[Covenient] [int] NOT NULL,
 CONSTRAINT [PK_Facility_1] PRIMARY KEY CLUSTERED 
(
	[MotelID] ASC,
	[Covenient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motel]    Script Date: 3/11/2024 12:55:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motel](
	[MotelID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NULL,
	[Tittle] [nvarchar](255) NULL,
	[Description] [nvarchar](2500) NULL,
	[Address] [nvarchar](1000) NULL,
	[Price] [money] NULL,
	[QuantityEmptyRooms] [int] NULL,
	[Contact] [nvarchar](255) NULL,
	[Province] [nvarchar](255) NULL,
	[District] [nvarchar](255) NULL,
	[Ward] [nvarchar](255) NULL,
	[Status] [nvarchar](200) NULL,
	[deleteAt] [datetime] NULL,
 CONSTRAINT [PK_Motel] PRIMARY KEY CLUSTERED 
(
	[MotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 3/11/2024 12:55:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] NOT NULL,
	[AccountID] [int] NULL,
	[RoomID] [int] NULL,
	[PaymentDate] [date] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/11/2024 12:55:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomImage]    Script Date: 3/11/2024 12:55:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomImage](
	[RoomImageID] [int] NOT NULL,
	[MotelID] [int] NOT NULL,
	[imageDetail] [nvarchar](255) NULL,
	[pathImageDetail] [nvarchar](255) NULL,
 CONSTRAINT [PK_RoomImage] PRIMARY KEY CLUSTERED 
(
	[RoomImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vote]    Script Date: 3/11/2024 12:55:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vote](
	[AccountID] [int] NOT NULL,
	[MotelID] [int] NOT NULL,
	[ReviewStar] [varchar](1) NULL,
 CONSTRAINT [PK_Vote] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC,
	[MotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountID], [Email], [Username], [Password], [Phone], [RoleID], [Gender], [FirstName], [LastName], [deleteAt]) VALUES (1, N'vuduchuy1120@gmail.com', N'vuduchuy1120', N'123465789', N'0879110156', 1, 1, N'Vu Duc ', N'Huy', NULL)
INSERT [dbo].[Account] ([AccountID], [Email], [Username], [Password], [Phone], [RoleID], [Gender], [FirstName], [LastName], [deleteAt]) VALUES (2, N'lecut@gmail.com', N'lele1120', N'123456', N'0879110158', 2, 0, N'Nguyễn Thị ', N'Nhật Lệ', NULL)
INSERT [dbo].[Account] ([AccountID], [Email], [Username], [Password], [Phone], [RoleID], [Gender], [FirstName], [LastName], [deleteAt]) VALUES (3, N'huyvu@gmail.com', N'huyvu1120', N'123456', N'0879110111', 3, 1, N'Huy', N'Vu', NULL)
INSERT [dbo].[Account] ([AccountID], [Email], [Username], [Password], [Phone], [RoleID], [Gender], [FirstName], [LastName], [deleteAt]) VALUES (5, N'string', N'string', N'string', NULL, 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([AccountID], [Email], [Username], [Password], [Phone], [RoleID], [Gender], [FirstName], [LastName], [deleteAt]) VALUES (10, N'huyvdhe160866@fpt.edu.vn', NULL, N'123456', NULL, 3, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Convenient] ON 

INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (1, N'Wifi mi?n phí', N'Wifi Free')
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (2, N'Phòng gia đình', N'')
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (3, N'Phòng không hút thuốc', N'')
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (4, N'Lễ tân 24 giờ', N'')
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (5, N'An ninh tốt', N'')
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (6, N'Điện nước đầy đủ', N'')
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (7, N'chỗ để xe', N'')
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (8, N'Tủ lạnh', N'')
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (9, N'Máy giặt', N'')
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (10, N'Máy sấy', NULL)
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (11, N'Máy lọc nước', NULL)
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (12, N'Bình nóng lạnh', NULL)
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (13, N'Tủ quần áo', NULL)
INSERT [dbo].[Convenient] ([ConvenientID], [Name], [Description]) VALUES (14, N'Điều hoà', NULL)
SET IDENTITY_INSERT [dbo].[Convenient] OFF
GO
SET IDENTITY_INSERT [dbo].[Motel] ON 

INSERT [dbo].[Motel] ([MotelID], [AccountID], [Tittle], [Description], [Address], [Price], [QuantityEmptyRooms], [Contact], [Province], [District], [Ward], [Status], [deleteAt]) VALUES (1, 1, N'Trọ Tâm Lê', N'Trọ tâm lê đầy đủ tiện nghi, giá rẻ phù hợp với sinh viên', N'Thôn 4', 1000.0000, 12, N'0923572111', N'Hà Nội', N'Thạch Thất', N'Thạch Hoà', N'Processing', NULL)
INSERT [dbo].[Motel] ([MotelID], [AccountID], [Tittle], [Description], [Address], [Price], [QuantityEmptyRooms], [Contact], [Province], [District], [Ward], [Status], [deleteAt]) VALUES (2, 1, N'Trọ Hà Minh', N'Trọ hà Minh đầy đủ tiện nghi', N'Thôn 4 ', 10000.0000, 1, N'0363685214', N'Hà Nội', N'Thạch Thất', N'Thạch Hoà', N'Accepted', NULL)
SET IDENTITY_INSERT [dbo].[Motel] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [Description]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleID], [Description]) VALUES (2, N'User')
INSERT [dbo].[Role] ([RoleID], [Description]) VALUES (3, N'MotelManager')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Account]    Script Date: 3/11/2024 12:55:41 AM ******/
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [IX_Account] UNIQUE NONCLUSTERED 
(
	[Username] ASC,
	[Phone] ASC,
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Facility]  WITH CHECK ADD  CONSTRAINT [FK_Facility_Convenient] FOREIGN KEY([Covenient])
REFERENCES [dbo].[Convenient] ([ConvenientID])
GO
ALTER TABLE [dbo].[Facility] CHECK CONSTRAINT [FK_Facility_Convenient]
GO
ALTER TABLE [dbo].[Facility]  WITH CHECK ADD  CONSTRAINT [FK_Facility_Motel] FOREIGN KEY([MotelID])
REFERENCES [dbo].[Motel] ([MotelID])
GO
ALTER TABLE [dbo].[Facility] CHECK CONSTRAINT [FK_Facility_Motel]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Account]
GO
ALTER TABLE [dbo].[RoomImage]  WITH CHECK ADD  CONSTRAINT [FK_RoomImage_Motel] FOREIGN KEY([MotelID])
REFERENCES [dbo].[Motel] ([MotelID])
GO
ALTER TABLE [dbo].[RoomImage] CHECK CONSTRAINT [FK_RoomImage_Motel]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_Account]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_Motel] FOREIGN KEY([MotelID])
REFERENCES [dbo].[Motel] ([MotelID])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_Motel]
GO
USE [master]
GO
ALTER DATABASE [AccommodationSearchSystem] SET  READ_WRITE 
GO
