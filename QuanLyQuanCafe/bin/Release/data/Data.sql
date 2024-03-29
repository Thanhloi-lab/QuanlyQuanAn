USE [master]
GO
/****** Object:  Database [QuanLy]    Script Date: 8/26/2020 5:02:47 PM ******/
CREATE DATABASE [QuanLy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLy', FILENAME = N'D:\SQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLy_log', FILENAME = N'D:\SQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLy] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLy] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLy] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLy] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLy] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLy] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLy] SET QUERY_STORE = OFF
GO
USE [QuanLy]
GO
/****** Object:  UserDefinedFunction [dbo].[fuconverttounsign]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuconverttounsign]
(
      @strInput NVARCHAR(4000)
)
RETURNS NVARCHAR(4000)
AS
BEGIN    

    IF @strInput IS NULL RETURN @strInput

    IF @strInput = '' RETURN @strInput

    DECLARE @RT NVARCHAR(4000)

    DECLARE @SIGN_CHARS NCHAR(136)

    DECLARE @UNSIGN_CHARS NCHAR (136)

    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế

                  ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý

                  ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ

                  ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'

                  +NCHAR(272)+ NCHAR(208)

    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee

                  iiiiiooooooooooooooouuuuuuuuuuyyyyy

                  AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII

                  OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'

    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
    SET @COUNTER = 1

    WHILE (@COUNTER <=LEN(@strInput))
    BEGIN  
      SET @COUNTER1 = 1
      --Tìm trong chuỗi mẫu
       WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
       BEGIN
     IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1))
            = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
     BEGIN          
          IF @COUNTER=1
              SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1)
              + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1)                  
          ELSE
              SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1)
              +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1)
              + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)
              BREAK
               END
             SET @COUNTER1 = @COUNTER1 +1
       END
      --Tìm tiếp
       SET @COUNTER = @COUNTER +1
    END
    SET @strInput = replace(@strInput,' ','-')
    RETURN @strInput

END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DislayName] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](200) NULL,
	[AccountType] [bit] NOT NULL,
	[Active] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TableID] [int] NOT NULL,
	[DateCheckIn] [date] NOT NULL,
	[DateCheckOut] [date] NULL,
	[BillStatus] [bit] NOT NULL,
	[Discount] [int] NULL,
	[TotalPrice] [float] NULL,
	[CheckOutByAccountID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BillID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[CountBill] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FoodName] [nvarchar](100) NOT NULL,
	[Price] [float] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Active] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FoodName] [nvarchar](100) NOT NULL,
	[Active] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tables]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](100) NOT NULL,
	[TableStatus] [bit] NOT NULL,
	[Active] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [DislayName], [UserName], [PassWord], [AccountType], [Active]) VALUES (1, N'staff', N'staff', N'1962026656160185351301320480154111117132155', 0, 1)
INSERT [dbo].[Account] ([ID], [DislayName], [UserName], [PassWord], [AccountType], [Active]) VALUES (2, N'staff', N'staff1', N'1962026656160185351301320480154111117132155', 0, 1)
INSERT [dbo].[Account] ([ID], [DislayName], [UserName], [PassWord], [AccountType], [Active]) VALUES (3, N'staff', N'staff2', N'1962026656160185351301320480154111117132155', 0, 1)
INSERT [dbo].[Account] ([ID], [DislayName], [UserName], [PassWord], [AccountType], [Active]) VALUES (4, N'staff', N'staff3', N'1962026656160185351301320480154111117132155', 0, 1)
INSERT [dbo].[Account] ([ID], [DislayName], [UserName], [PassWord], [AccountType], [Active]) VALUES (5, N'staff', N'staff4', N'1962026656160185351301320480154111117132155', 0, 1)
INSERT [dbo].[Account] ([ID], [DislayName], [UserName], [PassWord], [AccountType], [Active]) VALUES (6, N'staff', N'staff5', N'1962026656160185351301320480154111117132155', 0, 1)
INSERT [dbo].[Account] ([ID], [DislayName], [UserName], [PassWord], [AccountType], [Active]) VALUES (7, N'Boss', N'thanhloi', N'3244185981728979115075721453575112', 1, 1)
INSERT [dbo].[Account] ([ID], [DislayName], [UserName], [PassWord], [AccountType], [Active]) VALUES (8, N'Super staffffffff', N'staff6', N'1962026656160185351301320480154111117132155', 0, 1)
INSERT [dbo].[Account] ([ID], [DislayName], [UserName], [PassWord], [AccountType], [Active]) VALUES (10, N'super slave', N'staff7', N'1962026656160185351301320480154111117132155', 0, 1)
INSERT [dbo].[Account] ([ID], [DislayName], [UserName], [PassWord], [AccountType], [Active]) VALUES (15, N'Slave', N'staff8', N'1962026656160185351301320480154111117132155', 0, 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (1, 1, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-21' AS Date), 1, 17, 83000, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (2, 2, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-21' AS Date), 1, 15, 680000, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (3, 4, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), 1, 30, 7000000, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (4, 1, CAST(N'2020-08-21' AS Date), CAST(N'2020-08-21' AS Date), 1, 0, 100000, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (5, 1, CAST(N'2020-08-21' AS Date), CAST(N'2020-08-21' AS Date), 1, 15, 255000, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (6, 1, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 0, 100000, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (7, 2, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 0, 0, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (8, 3, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 0, 0, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (9, 2, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 0, 0, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (10, 7, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 0, 0, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (11, 1, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 0, 0, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (12, 9, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 0, 0, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (13, 7, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 0, 0, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (14, 6, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 50, 165000, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (15, 2, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 0, 100000, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (16, 3, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 20, 80000, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (17, 1, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 0, 100000, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (18, 4, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 20, 12000, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (19, 10, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 12, 13200, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (20, 2, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 90, 5000, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (21, 4, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 17, 12450, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (22, 5, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 15, 12750, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (23, 1, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-26' AS Date), 1, 0, 100000, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (24, 2, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-26' AS Date), 1, 0, 100000, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (25, 9, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 91, 9000, 6)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (26, 8, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-22' AS Date), 1, 35, 65000, 6)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (27, 5, CAST(N'2020-08-22' AS Date), CAST(N'2020-08-26' AS Date), 1, 0, 100000, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (28, 10, CAST(N'2020-08-26' AS Date), CAST(N'2020-08-26' AS Date), 1, 15, 595000, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (29, 8, CAST(N'2020-08-26' AS Date), CAST(N'2020-08-26' AS Date), 1, 0, 300000, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (30, 4, CAST(N'2020-08-26' AS Date), CAST(N'2020-08-26' AS Date), 1, 0, 500000, 7)
INSERT [dbo].[Bill] ([ID], [TableID], [DateCheckIn], [DateCheckOut], [BillStatus], [Discount], [TotalPrice], [CheckOutByAccountID]) VALUES (31, 3, CAST(N'2020-08-26' AS Date), CAST(N'2020-08-26' AS Date), 1, 0, 180000, 7)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (2, 2, 1, 8)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (3, 3, 2, 100)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (4, 4, 1, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (5, 5, 1, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (12, 6, 1, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (16, 14, 6, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (17, 15, 1, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (18, 16, 1, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (19, 17, 1, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (20, 14, 3, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (21, 18, 17, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (22, 19, 17, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (23, 20, 4, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (24, 21, 18, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (25, 22, 19, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (26, 23, 1, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (27, 24, 1, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (28, 25, 1, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (29, 26, 1, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (30, 27, 1, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (31, 28, 1, 7)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (32, 29, 1, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (33, 30, 2, 5)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [CountBill]) VALUES (34, 31, 5, 6)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (1, N'Catfish', 100000, 1, 1)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (2, N'Squid & Shrimp grill', 100000, 1, 1)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (3, N'BBQ beef', 300000, 5, 1)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (4, N'Fried spinach', 50000, 3, 1)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (5, N'Hamburger', 30000, 2, 1)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (6, N'Jackfruit', 30000, 4, 1)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (7, N'Milk & Ice', 12000, 6, 1)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (8, N'Coleslaw', 15000, 3, 1)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (9, N'Lemon Fruit', 15000, 6, 1)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (10, N'Orange', 15000, 4, 1)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (17, N'Orange1', 15000, 4, 0)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (18, N'Orange1', 15000, 4, 0)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (19, N'Orange1', 15000, 4, 0)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (20, N'Orange', 15000, 9, 0)
INSERT [dbo].[Food] ([ID], [FoodName], [Price], [CategoryID], [Active]) VALUES (21, N'Orange1', 15000, 9, 0)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([ID], [FoodName], [Active]) VALUES (1, N'Seafood', 1)
INSERT [dbo].[FoodCategory] ([ID], [FoodName], [Active]) VALUES (2, N'Fastfoods', 1)
INSERT [dbo].[FoodCategory] ([ID], [FoodName], [Active]) VALUES (3, N'Vegetables', 1)
INSERT [dbo].[FoodCategory] ([ID], [FoodName], [Active]) VALUES (4, N'Fruits', 1)
INSERT [dbo].[FoodCategory] ([ID], [FoodName], [Active]) VALUES (5, N'Meat', 1)
INSERT [dbo].[FoodCategory] ([ID], [FoodName], [Active]) VALUES (6, N'Dairy foods', 1)
INSERT [dbo].[FoodCategory] ([ID], [FoodName], [Active]) VALUES (7, N'Shit', 0)
INSERT [dbo].[FoodCategory] ([ID], [FoodName], [Active]) VALUES (8, N'shit1', 0)
INSERT [dbo].[FoodCategory] ([ID], [FoodName], [Active]) VALUES (9, N'shittttt', 0)
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Tables] ON 

INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (1, N'Table1', 0, 1)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (2, N'Table 2', 0, 1)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (3, N'Table 3', 0, 1)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (4, N'Table 4', 0, 1)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (5, N'Table 5', 0, 1)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (6, N'Table 6', 0, 1)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (7, N'Table 7', 0, 1)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (8, N'Table 8', 0, 1)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (9, N'Table 9', 0, 1)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (10, N'Table 10', 0, 1)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (11, N'Table 11', 0, 1)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (12, N'Table 12', 0, 0)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (13, N'Table 12', 0, 0)
INSERT [dbo].[Tables] ([ID], [TableName], [TableStatus], [Active]) VALUES (14, N'Table 12', 0, 0)
SET IDENTITY_INSERT [dbo].[Tables] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [U_UserName]    Script Date: 8/26/2020 5:02:47 PM ******/
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [U_UserName] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ('Non') FOR [DislayName]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [CT_DefaultPassword]  DEFAULT ('1962026656160185351301320480154111117132155') FOR [PassWord]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [AccountType]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [BillStatus]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [CountBill]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT ('Non') FOR [FoodName]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT ('Non') FOR [FoodName]
GO
ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Tables] ADD  DEFAULT ('Non') FOR [TableName]
GO
ALTER TABLE [dbo].[Tables] ADD  DEFAULT ((0)) FOR [TableStatus]
GO
ALTER TABLE [dbo].[Tables] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_BILL] FOREIGN KEY([TableID])
REFERENCES [dbo].[Tables] ([ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_BILL]
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD  CONSTRAINT [FK1_BillCategory] FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([ID])
GO
ALTER TABLE [dbo].[BillInfo] CHECK CONSTRAINT [FK1_BillCategory]
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD  CONSTRAINT [FK2_BillCategory] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Food] ([ID])
GO
ALTER TABLE [dbo].[BillInfo] CHECK CONSTRAINT [FK2_BillCategory]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_Food] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[FoodCategory] ([ID])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_Food]
GO
/****** Object:  StoredProcedure [dbo].[SelectAccount]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAccount] 
	@UserName nvarchar(100), 
	@password nvarchar(100)
AS
BEGIN
	SELECT *FROM Account 
	WHERE UserName = @UserName AND Password = @password AND active = 1
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetCountBillByDate]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetCountBillByDate]
@CheckIn date, @CheckOut date
AS
BEGIN
	select count(*)
	FROM Bill as b, Tables as t, Account as a
	WHERE DateCheckIn >= @CheckIn AND DateCheckOut <= @CheckOut and b.BillStatus = 1
	AND t.ID = b.TableID AND a.ID = b.CheckOutByAccountID
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDate]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDate]
@CheckIn date, @CheckOut date
AS
BEGIN
	select t.TableName, a.DislayName as CheckedBy , b.DateCheckIn, b.DateCheckOut, b.Discount, b.TotalPrice 
	FROM Bill as b, Tables as t, Account as a
	WHERE DateCheckIn >= @CheckIn AND DateCheckOut <= @CheckOut and b.BillStatus = 1
	AND t.ID = b.TableID AND a.ID = b.CheckOutByAccountID
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateAndPage]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDateAndPage]
@CheckIn date, @CheckOut date, @page int, @pageRows int
AS
BEGIN
	declare @selectRows int = @pageRows
	declare @exceptRows int = (@page-1) * @pageRows

	;with BillShow as (SELECT b.ID, t.TableName, a.DislayName as CheckedBy , b.DateCheckIn, b.DateCheckOut, b.Discount, b.TotalPrice 
	FROM Bill as b, Tables as t, Account as a
	WHERE DateCheckIn >= @CheckIn AND DateCheckOut <= @CheckOut and b.BillStatus = 1
	AND t.ID = b.TableID AND a.ID = b.CheckOutByAccountID)

	Select Top (@selectRows) * from BillShow WHERE ID not in (select Top (@exceptRows) ID from BillShow) 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListTable]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListTable]
AS Select * FROM dbo.Tables WHERE ACtive = 1
GO
/****** Object:  StoredProcedure [dbo].[USP_InserBill]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InserBill]
@TableID INT
AS
BEGIN
	INSERT Bill
		( DateCheckIn,
		  DateCheckOut,
		  TableID,
		  BillStatus,
		  Discount)
	 VALUES
		  ( GETDATE(),
			Null,
			@TableID,
			0,
			0)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InserBillInfo]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InserBillInfo]
@BillID INT, @FoodID int, @CountBill Float
AS
BEGIN
	DECLARE @isBillInfoExist INT
	DECLARE @Count INT = 1

	SELECT @isBillInfoExist = id, @Count = CountBill
	FROM dbo.BillInfo
	WHERE BillID = @BillID AND FoodID = @FoodID

	IF(@isBillInfoExist>0)
	BEGIN
		DECLARE @newCount INT = @Count + @CountBill
		IF(@newCount>0)
			UPDATE dbo.BillInfo SET CountBill = @Count + @CountBill WHERE BillID = @BillID AND FoodID = @FoodID
		ELSE
			DELETE dbo.BillInfo WHERE BillID = @BillID AND FoodID = @FoodID
	END

	ELSE
		IF(@CountBill>0)
		BEGIN
			BEGIN
			INSERT BillInfo
				( BillID,
				  FoodID,
				  CountBill)
			 VALUES
				  ( @BillID,
					@FoodID,
					@CountBill)
			END
		END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertAccount]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertAccount]
@UserName nvarchar(100), @DislayName nvarchar(100), @AccountType bit
AS
BEGIN
	INSERT Account (UserName,DislayName,AccountType,PassWord)
	VALUES (@UserName, @DislayName, @AccountType,N'1962026656160185351301320480154111117132155');
END 
GO
/****** Object:  StoredProcedure [dbo].[USP_SwitchTable]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_SwitchTable]
@id1 int, @id2 int
AS
BEGIN
	DECLARE @idBill1 int
	DECLARE @idBill2 int

	SELECT @idBill1 = id FROM dbo.Bill WHERE dbo.Bill.TableID = @id1 AND BillStatus = 0
	SELECT @idBill2 = id FROM dbo.Bill WHERE dbo.Bill.TableID = @id2 AND BillStatus = 0

	UPDATE dbo.Bill SET dbo.Bill.TableID = @id2 WHERE id = @idBill1
	UPDATE dbo.Bill SET dbo.Bill.TableID = @id1 WHERE id = @idBill2
	

	IF(@idBill1 is Null AND @idBill2 is NOT Null)
		BEGIN
			PRINT 'idbill1-1'
			PRINT @idBill1
			UPDATE Tables SET TableStatus = 0 WHERE ID = @id2
			UPDATE Tables SET TableStatus = 1 WHERE ID = @id1

			PRINT 'idbill1-2'
			PRINT @idBill1
		END

	ELSE IF(@idBill1 is NOT Null AND @idBill2 is Null)
		BEGIN
			PRINT 'idbill2-1'
			PRINT @idBill2
			UPDATE Tables SET TableStatus = 0 WHERE ID = @id1
			UPDATE Tables SET TableStatus = 1 WHERE ID = @id2
			PRINT 'idbill2-'
			PRINT @idBill2
		END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 8/26/2020 5:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateAccount]
@DislayName nvarchar(100), @UserName nvarchar(100), @PassWord nvarchar(200), @NewPassWord nvarchar(200)
AS
BEGIN
	DECLARE @isPassRight INT = 0
	SELECT @isPassRight = COUNT(*) FROM Account WHERE UserName = @UserName AND PassWord = @PassWord
	IF(@isPassRight = 1)
	BEGIN
		IF(@NewPassWord = NULL OR @NewPassWord ='')
			UPDATE dbo.Account SET DislayName = @DislayName WHERE UserName = @UserName
		ELSE
			UPDATE dbo.Account SET DislayName = @DislayName, PassWord = @NewPassWord WHERE UserName = @UserName
	END
END
GO
USE [master]
GO
ALTER DATABASE [QuanLy] SET  READ_WRITE 
GO
