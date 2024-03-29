USE [master]
GO
/****** Object:  Database [HarshDB]    Script Date: 17-09-2019 11:25:11 AM ******/
CREATE DATABASE [HarshDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HarshDB_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HarshDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HarshDB_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HarshDB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HarshDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HarshDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HarshDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HarshDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HarshDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HarshDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HarshDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HarshDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HarshDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HarshDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HarshDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HarshDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HarshDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HarshDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HarshDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HarshDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HarshDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HarshDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HarshDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HarshDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HarshDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HarshDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HarshDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HarshDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HarshDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HarshDB] SET  MULTI_USER 
GO
ALTER DATABASE [HarshDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HarshDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HarshDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HarshDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HarshDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HarshDB] SET QUERY_STORE = OFF
GO
USE [HarshDB]
GO
/****** Object:  Table [dbo].[Booking_Table]    Script Date: 17-09-2019 11:25:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking_Table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[C_Id] [int] NULL,
	[M_Id] [int] NULL,
	[issued_Date] [varchar](50) NULL,
	[Return_Date] [varchar](50) NULL,
 CONSTRAINT [PK_Booking_Table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_Booking]    Script Date: 17-09-2019 11:25:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Id] [int] NULL,
	[Booking] [int] NULL,
 CONSTRAINT [PK_Customer_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_Table]    Script Date: 17-09-2019 11:25:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Name] [varchar](50) NULL,
	[Customer_LName] [varchar](50) NULL,
	[Customer_PhNo] [varchar](50) NULL,
	[Customer_Address] [varchar](50) NULL,
 CONSTRAINT [PK_Customer_Table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Table]    Script Date: 17-09-2019 11:25:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Video_title] [varchar](50) NULL,
	[Video_Ratting] [varchar](50) NULL,
	[Video_Year] [int] NULL,
	[Video_Cost] [int] NULL,
	[Video_Copies] [int] NULL,
	[Video_Plot] [varchar](50) NULL,
	[Video_Genre] [varchar](50) NULL,
 CONSTRAINT [PK_Movie_Table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [HarshDB] SET  READ_WRITE 
GO
