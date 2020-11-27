USE [master]
GO
/****** Object:  Database [GameCenterMVC]    Script Date: 11/27/2020 11:16:42 PM ******/
CREATE DATABASE [GameCenterMVC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GameCenterMVC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GameCenterMVC.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GameCenterMVC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GameCenterMVC_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GameCenterMVC] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GameCenterMVC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GameCenterMVC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GameCenterMVC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GameCenterMVC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GameCenterMVC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GameCenterMVC] SET ARITHABORT OFF 
GO
ALTER DATABASE [GameCenterMVC] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GameCenterMVC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GameCenterMVC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GameCenterMVC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GameCenterMVC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GameCenterMVC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GameCenterMVC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GameCenterMVC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GameCenterMVC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GameCenterMVC] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GameCenterMVC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GameCenterMVC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GameCenterMVC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GameCenterMVC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GameCenterMVC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GameCenterMVC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GameCenterMVC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GameCenterMVC] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GameCenterMVC] SET  MULTI_USER 
GO
ALTER DATABASE [GameCenterMVC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GameCenterMVC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GameCenterMVC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GameCenterMVC] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GameCenterMVC] SET DELAYED_DURABILITY = DISABLED 
GO
USE [GameCenterMVC]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 11/27/2020 11:16:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NULL,
	[ComputerID] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Total] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clients]    Script Date: 11/27/2020 11:16:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[PersonalID] [nvarchar](255) NOT NULL,
	[Adress] [nvarchar](255) NOT NULL,
	[Birthday] [date] NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Balance] [money] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ActiveDate] [date] NULL,
	[InsertBy] [varchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Computer]    Script Date: 11/27/2020 11:16:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Computer](
	[ComputerID] [int] IDENTITY(1,1) NOT NULL,
	[PartID] [int] NULL,
	[PricePerHour] [money] NOT NULL,
	[IsActive] [bit] NULL,
	[InsertBy] [varchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ComputerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ComputerParts]    Script Date: 11/27/2020 11:16:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ComputerParts](
	[PartID] [int] IDENTITY(1,1) NOT NULL,
	[Case] [nvarchar](255) NOT NULL,
	[Mouse] [nvarchar](255) NOT NULL,
	[Keyboard] [nvarchar](255) NOT NULL,
	[HeadSet] [nvarchar](255) NOT NULL,
	[Monitor] [nvarchar](255) NOT NULL,
	[MousePad] [nvarchar](255) NOT NULL,
	[CPU] [nvarchar](255) NOT NULL,
	[GPU] [nvarchar](255) NOT NULL,
	[Motherboard] [nvarchar](255) NOT NULL,
	[RAM] [nvarchar](255) NOT NULL,
	[SSD] [nvarchar](255) NOT NULL,
	[HDD] [nvarchar](255) NOT NULL,
	[PSU] [nvarchar](255) NOT NULL,
	[Cooler] [nvarchar](255) NOT NULL,
	[InsertBy] [varchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/27/2020 11:16:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[Name] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[PersonalID] [nvarchar](255) NOT NULL,
	[Adress] [nvarchar](255) NOT NULL,
	[Birthday] [date] NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[PayCheck] [money] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ActiveDate] [date] NULL,
	[InsertBy] [varchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/27/2020 11:16:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[BillID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/27/2020 11:16:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](255) NOT NULL,
	[ProductPrice] [money] NULL,
	[ProductQuantity] [int] NULL,
	[InsertBy] [varchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/27/2020 11:16:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[InsertBy] [varchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [RoleID], [Name], [LastName], [PersonalID], [Adress], [Birthday], [PhoneNumber], [Email], [UserName], [Password], [PayCheck], [IsActive], [ActiveDate], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (1, 1, N'Gentrit', N'Selimi', N'123123132', N'Prishtine', CAST(N'1999-10-14' AS Date), N'044352799', N'g@riinvest.net', N'admin', N'admin', 1.0000, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [RoleID], [Name], [LastName], [PersonalID], [Adress], [Birthday], [PhoneNumber], [Email], [UserName], [Password], [PayCheck], [IsActive], [ActiveDate], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (3, 1, N'Hasan', N'Selimi', N'123123', N'pristhine', CAST(N'1999-10-14' AS Date), N'123123123', N'g@riinvest.net', N'admin1', N'admin1', 12312312.0000, 1, CAST(N'2020-11-26' AS Date), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (1, N'admin', N'admin kryesor', N'admin', CAST(N'2020-11-26 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD FOREIGN KEY([ComputerID])
REFERENCES [dbo].[Computer] ([ComputerID])
GO
ALTER TABLE [dbo].[Computer]  WITH CHECK ADD FOREIGN KEY([PartID])
REFERENCES [dbo].[ComputerParts] ([PartID])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([BillID])
REFERENCES [dbo].[Bills] ([BillID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
/****** Object:  StoredProcedure [dbo].[GetALL_Employess]    Script Date: 11/27/2020 11:16:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetALL_Employess]
As
Select * from Employee
GO
USE [master]
GO
ALTER DATABASE [GameCenterMVC] SET  READ_WRITE 
GO
