USE [master]
GO
/****** Object:  Database [GameCenterMVC]    Script Date: 02-Dec-20 11:01:06 ******/
CREATE DATABASE [GameCenterMVC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GameCenterMVC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GameCenterMVC.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GameCenterMVC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GameCenterMVC_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[Bills]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
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
/****** Object:  Table [dbo].[Clients]    Script Date: 02-Dec-20 11:01:06 ******/
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
	[IsActive] [bit] NULL,
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
/****** Object:  Table [dbo].[Computer]    Script Date: 02-Dec-20 11:01:06 ******/
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
/****** Object:  Table [dbo].[ComputerParts]    Script Date: 02-Dec-20 11:01:06 ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
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
	[IsActive] [bit] NULL,
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
/****** Object:  Table [dbo].[Orders]    Script Date: 02-Dec-20 11:01:06 ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 02-Dec-20 11:01:06 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 02-Dec-20 11:01:06 ******/
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
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ClientID], [Name], [LastName], [PersonalID], [Adress], [Birthday], [PhoneNumber], [Email], [UserName], [Password], [Balance], [IsActive], [ActiveDate], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (1, N'syl', N'sylani', N'12345678911', N'Pej', CAST(N'2000-12-01' AS Date), N'1234567898', N'syl@hotmail.com', N'syl', N'1234', 200.0000, 0, NULL, N'admin', CAST(N'2020-12-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Clients] OFF
SET IDENTITY_INSERT [dbo].[Computer] ON 

INSERT [dbo].[Computer] ([ComputerID], [PartID], [PricePerHour], [IsActive], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (10, 2, 1.0000, 0, N'admin', CAST(N'2020-12-01 00:00:00.000' AS DateTime), N'admin', CAST(N'2020-12-01 00:00:00.000' AS DateTime))
INSERT [dbo].[Computer] ([ComputerID], [PartID], [PricePerHour], [IsActive], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (15, 2, 1.0000, NULL, N'admin', CAST(N'2020-12-01 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Computer] ([ComputerID], [PartID], [PricePerHour], [IsActive], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (16, 2, 1.5000, NULL, N'admin', CAST(N'2020-12-01 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Computer] ([ComputerID], [PartID], [PricePerHour], [IsActive], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (17, 2, 2.0000, NULL, N'admin', CAST(N'2020-12-01 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Computer] ([ComputerID], [PartID], [PricePerHour], [IsActive], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (18, 2, 4.0000, NULL, N'admin', CAST(N'2020-12-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Computer] OFF
SET IDENTITY_INSERT [dbo].[ComputerParts] ON 

INSERT [dbo].[ComputerParts] ([PartID], [Case], [Mouse], [Keyboard], [HeadSet], [Monitor], [MousePad], [CPU], [GPU], [Motherboard], [RAM], [SSD], [HDD], [PSU], [Cooler], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (2, N'sas', N'asdas', N'dasdasd', N'asdas', N'asda', N'a', N'sa', N'as', N'aa', N'TestRAM', N's', N's', N's', N's', N's', CAST(N'2020-11-30 00:00:00.000' AS DateTime), N'admin', CAST(N'2020-12-01 00:00:00.000' AS DateTime))
INSERT [dbo].[ComputerParts] ([PartID], [Case], [Mouse], [Keyboard], [HeadSet], [Monitor], [MousePad], [CPU], [GPU], [Motherboard], [RAM], [SSD], [HDD], [PSU], [Cooler], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (3, N'LogiTech', N'LogiTech', N'LogiTech', N'LogiTech', N'LogiTech', N'LogiTech', N'LogiTech', N'LogiTech', N'LogiTech', N'LogiTech', N'LogiTech', N'LogiTech', N'LogiTech', N'LogiTech', N'admin', CAST(N'2020-12-01 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[ComputerParts] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [RoleID], [Name], [LastName], [PersonalID], [Adress], [Birthday], [PhoneNumber], [Email], [UserName], [Password], [PayCheck], [IsActive], [ActiveDate], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (1, 1, N'admin', N'admin', N'11111111111', N'Prishtina', CAST(N'2000-12-02' AS Date), N'1233333333', N'admin@hotmail.com', N'admin', N'admin', 0.0000, 0, CAST(N'2020-12-02' AS Date), N'admin', CAST(N'2020-12-02 00:00:00.000' AS DateTime), N'admin', CAST(N'2020-12-02 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductPrice], [ProductQuantity], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (1, N'Coca Cola', 2.0000, 200, N'admin', CAST(N'2020-12-01 00:00:00.000' AS DateTime), N'admin', CAST(N'2020-12-01 00:00:00.000' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductPrice], [ProductQuantity], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (3, N'test', 1.0000, 22, N'admin', CAST(N'2020-12-01 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [InsertBy], [InsertDate], [UpdateBy], [UpdateDate]) VALUES (1, N'admin', N'veq admin', N'admin', CAST(N'2020-11-26 00:00:00.000' AS DateTime), N'admin', CAST(N'2020-12-02 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Roles] OFF
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD FOREIGN KEY([ComputerID])
REFERENCES [dbo].[Computer] ([ComputerID])
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_Clients]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_Computer] FOREIGN KEY([ComputerID])
REFERENCES [dbo].[Computer] ([ComputerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_Computer]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_Employee]
GO
ALTER TABLE [dbo].[Computer]  WITH CHECK ADD FOREIGN KEY([PartID])
REFERENCES [dbo].[ComputerParts] ([PartID])
GO
ALTER TABLE [dbo].[Computer]  WITH CHECK ADD  CONSTRAINT [FK_Computer_ComputerParts] FOREIGN KEY([PartID])
REFERENCES [dbo].[ComputerParts] ([PartID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Computer] CHECK CONSTRAINT [FK_Computer_ComputerParts]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Roles]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([BillID])
REFERENCES [dbo].[Bills] ([BillID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Bills] FOREIGN KEY([BillID])
REFERENCES [dbo].[Bills] ([BillID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Bills]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products]
GO
/****** Object:  StoredProcedure [dbo].[Add_Clients]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_Clients]
@name NVARCHAR(255),
@lastName NVARCHAR(255),
@personalID NVARCHAR(255),
@address NVARCHAR(255),
@birthday DATE,
@phoneNumber NVARCHAR(50),
@email NVARCHAR(50),
@userName NVARCHAR(255),
@password NVARCHAR(255),
@balance MONEY,
@insertBy NVARCHAR(50),
@insertDate NVARCHAR(50)
AS
INSERT INTO dbo.Clients(Name,LastName,PersonalID,Adress,Birthday,PhoneNumber,Email,UserName,[Password],Balance,InsertBy,InsertDate) 
VALUES (@name,@lastName,@personalID,@address,@birthday,@phoneNumber,@email,@userName,@password,@balance,@insertBy,@insertDate)



GO
/****** Object:  StoredProcedure [dbo].[Add_Computer]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_Computer]
@partID INT,
@pricePerHour MONEY,
@insertBy VARCHAR(50),
@insertDate DATETIME
AS
INSERT INTO dbo.Computer(PartID,PricePerHour,InsertBy,InsertDate)
VALUES (@partID,@pricePerHour,@insertBy,@insertDate)





GO
/****** Object:  StoredProcedure [dbo].[Add_ComputerParts]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Add_ComputerParts]
@case nvarchar(255),
@mouse nvarchar(255),
@keyboard nvarchar(255),
@headset nvarchar(255),
@monitor nvarchar(255),
@mousepad nvarchar(255),
@cpu nvarchar(255),
@gpu nvarchar(255),
@motherboard nvarchar(255),
@ram nvarchar(255),
@ssd nvarchar(255),
@hdd nvarchar(255),
@psu nvarchar(255),
@cooler nvarchar(255),
@insertby varchar(50),
@insertdate datetime
AS
INSERT INTO ComputerParts
(
    --PartID - column value is auto-generated
    [Case],
    Mouse,
    Keyboard,
    HeadSet,
    Monitor,
    MousePad,
    CPU,
    gpu,
    MotherBoard,
    RAM,
    SSD,
    HDD,
    PSU,
    Cooler,
    InsertBy,
    InsertDate
 
)
VALUES
(
@case,@mouse,@keyboard,@headset,@monitor,@mousepad,@cpu,@gpu,@motherboard,@ram,@ssd,@hdd,@psu,@cooler,@insertby,@insertdate
)







GO
/****** Object:  StoredProcedure [dbo].[Add_Employee]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_Employee]
@name NVARCHAR(255),
@lastName NVARCHAR(255),
@personalID NVARCHAR(255),
@adress NVARCHAR(255),
@birthday DATE,
@phoneNumber NVARCHAR(50),
@email NVARCHAR(50),
@userName NVARCHAR(255),
@password NVARCHAR(255),
@roleID int,
@payCheck NVARCHAR(255),
@insertBy NVARCHAR(50),
@insertDate DATETIME
AS
INSERT INTO dbo.Employee(Name,LastName,PersonalID,Adress,Birthday,PhoneNumber,Email,UserName,[Password],RoleID,PayCheck,InsertBy,InsertDate)
VALUES (@name,@lastName,@personalID,@adress,@birthday,@phoneNumber,@email,@userName,@password,@roleID,@payCheck,@insertBy,@insertDate)





GO
/****** Object:  StoredProcedure [dbo].[Add_Product]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_Product]
@productName NVARCHAR(255),
@productPrice MONEY,
@productQuantity INT,
@insertBy VARCHAR(50),
@insertDate DATETIME
AS
INSERT INTO dbo.Products(ProductName,ProductPrice,ProductQuantity,InsertBy,InsertDate)
VALUES (@productName,@productPrice,@productQuantity,@insertBy,@insertDate)





GO
/****** Object:  StoredProcedure [dbo].[Add_Roles]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_Roles]
@roleName NVARCHAR(50),
@description NVARCHAR(255),
@insertBy NVARCHAR(50),
@inserDate DATETIME
AS
INSERT INTO dbo.Roles(RoleName,[Description],InsertBy,InsertDate)
VALUES (@roleName,@description,@insertBy,@inserDate)



GO
/****** Object:  StoredProcedure [dbo].[Delete_Computer]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Delete_Computer]
@computerID INT
AS
DELETE FROM dbo.Computer
WHERE ComputerID=@computerID





GO
/****** Object:  StoredProcedure [dbo].[Delete_ComputerParts]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Delete_ComputerParts]
@partID INT
AS
DELETE FROM dbo.ComputerParts
WHERE PartID=@partID
	





GO
/****** Object:  StoredProcedure [dbo].[Delete_Employee]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Delete_Employee]
@employeeID INT
AS
DELETE FROM dbo.Employee
Where EmployeeID=@employeeID





GO
/****** Object:  StoredProcedure [dbo].[Delete_Product]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Delete_Product]
@productID INT
AS
DELETE FROM dbo.Products
WHERE ProductID=@productID





GO
/****** Object:  StoredProcedure [dbo].[Delete_roles]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Delete_roles]
@roleid int
as
Delete from Roles
where RoleID = @roleid

GO
/****** Object:  StoredProcedure [dbo].[Edit_Client1]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Edit_Client1]
@clientID int,
@name varchar(50),
@lastname varchar(50),
@personalID varchar(50),
@adress varchar(50),
@birthday date,
@phonenumber varchar(50),
@email varchar(50),
@username varchar(50),
@password varchar(50),
@balance money,
@updateby varchar(50),
@updatedate date
as
begin
update Clients
Set Name = @name, LastName = @lastname, PersonalID = @personalID, Adress = @adress, Birthday = @birthday, PhoneNumber = @phonenumber,
Email = @email, UserName = @username, Password = @password, Balance = @balance, UpdateBy = @updateby, UpdateDate = @updatedate
where ClientID = @clientID
end


GO
/****** Object:  StoredProcedure [dbo].[Edit_Computer]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Edit_Computer]
@computerID INT,
@partID INT,
@pricePerHour MONEY,
@updateBy VARCHAR(50),
@updateDate DATETIME
AS
UPDATE dbo.Computer
SET PartID=@partID, PricePerHour=@pricePerHour, UpdateBy=@updateBy, UpdateDate=@updateDate
WHERE ComputerID=@computerID





GO
/****** Object:  StoredProcedure [dbo].[Edit_ComputerParts]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Edit_ComputerParts]
@partID INT,
@case nvarchar(255),
@mouse nvarchar(255),
@keyboard nvarchar(255),
@headset nvarchar(255),
@monitor nvarchar(255),
@mousepad nvarchar(255),
@cpu nvarchar(255),
@gpu nvarchar(255),
@motherboard nvarchar(255),
@ram nvarchar(255),
@ssd nvarchar(255),
@hdd nvarchar(255),
@psu nvarchar(255),
@cooler nvarchar(255),
@updatebBy varchar(50),
@updateDate datetime
AS
UPDATE ComputerParts
SET [Case]=@case, Mouse=@mouse, Keyboard=@keyboard,HeadSet=@headset,Monitor=@monitor,MousePad=@mousepad,CPU=@cpu,GPU=@gpu,Motherboard=@motherboard,RAM=@ram,SSD=@ssd,HDD=@hdd,PSU=@psu,Cooler=@cooler,UpdateBy=@updatebBy, UpdateDate=@updateDate
	WHERE PartID=@partID
	





GO
/****** Object:  StoredProcedure [dbo].[Edit_Employee]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Edit_Employee]
@employeeID INT,
@name NVARCHAR(255),
@lastName NVARCHAR(255),
@personalID NVARCHAR(255),
@adress NVARCHAR(255),
@birthday DATE,
@phoneNumber NVARCHAR(50),
@email NVARCHAR(50),
@userName NVARCHAR(255),
@password NVARCHAR(255),
@roleID int,
@payCheck NVARCHAR(255),
@updateBy NVARCHAR(50),
@updateDate DATETIME
AS
UPDATE dbo.Employee
SET Name=@name, LastName=@lastName, PersonalID=@personalID, Adress=@adress,Birthday=@birthday, PhoneNumber=@phoneNumber, Email=@email, UserName=@userName, [Password]=@password, PayCheck=@payCheck, RoleID=@roleID, UpdateBy=@updateBy, UpdateDate=@updateDate
WHERE EmployeeID=@employeeID





GO
/****** Object:  StoredProcedure [dbo].[Edit_Product]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Edit_Product]
@productID INT,
@productName NVARCHAR(255),
@productPrice MONEY,
@productQuantity INT,
@updateBy VARCHAR(50),
@updateDate DATETIME
AS
UPDATE dbo.Products
SET ProductName=@productName, ProductPrice=@productPrice, ProductQuantity=@productQuantity, UpdateBy=@updateBy, UpdateDate=@updateDate
WHERE ProductID=@productID





GO
/****** Object:  StoredProcedure [dbo].[Edit_Roles]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Edit_Roles]
@roleid int,
@rolename varchar (50),
@description varchar(255),
@updateby varchar(50),
@updatedate date
as
begin
Update Roles
Set RoleName = @rolename, Description = @description, UpdateBy = @updateby, UpdateDate = @updatedate
where RoleID = @roleid
end

GO
/****** Object:  StoredProcedure [dbo].[Get_ALLComputers]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Get_ALLComputers]
as
Select * from Computer



GO
/****** Object:  StoredProcedure [dbo].[Get_allRoles]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Get_allRoles]
as
Select * from Roles



GO
/****** Object:  StoredProcedure [dbo].[GetAll_Client]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAll_Client]
AS
SELECT * FROM dbo.Clients



GO
/****** Object:  StoredProcedure [dbo].[GetAll_ComputerParts]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAll_ComputerParts]
AS
SELECT * FROM dbo.ComputerParts



GO
/****** Object:  StoredProcedure [dbo].[GetALL_Employess]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetALL_Employess]
As
Select * from Employee





GO
/****** Object:  StoredProcedure [dbo].[GetAll_Products]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAll_Products]
AS
SELECT * FROM dbo.Products


GO
/****** Object:  StoredProcedure [dbo].[getClientByID]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[getClientByID]
@clientId int

As Select * from Clients
where ClientID = @clientId

GO
/****** Object:  StoredProcedure [dbo].[getEmployeByID]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[getEmployeByID]
@employeid int

As Select * from Employee
where EmployeeID = @employeid

GO
/****** Object:  StoredProcedure [dbo].[getPcByID]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getPcByID]
@computerID int
as
Select * from Computer
where ComputerID = @computerID

GO
/****** Object:  StoredProcedure [dbo].[getPcPartsByID]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[getPcPartsByID]
@partID int

As Select * from ComputerParts
where PartID = @partID

GO
/****** Object:  StoredProcedure [dbo].[GetProductByID]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetProductByID]
@productid int
as
select * from Products
where ProductID = @productid

GO
/****** Object:  StoredProcedure [dbo].[GetRoleByID]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[GetRoleByID]
@roleid int
as
Select * from Roles
where RoleID = @roleid

GO
/****** Object:  StoredProcedure [dbo].[Remove_Client]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Remove_Client]
@clientId int
as
Delete From Clients
where ClientID = @clientId

GO
/****** Object:  StoredProcedure [dbo].[Remove_Employee]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Remove_Employee]
@employeid int
as
Delete From Employee
where EmployeeID =@employeid

GO
/****** Object:  StoredProcedure [dbo].[Remove_PcParts]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Remove_PcParts]
@partID int
as
Delete From ComputerParts
where PartID = @partID

GO
/****** Object:  StoredProcedure [dbo].[Remove_Products]    Script Date: 02-Dec-20 11:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Remove_Products]
@productid int
as
Delete from Products
where ProductID = @productid

GO
USE [master]
GO
ALTER DATABASE [GameCenterMVC] SET  READ_WRITE 
GO
