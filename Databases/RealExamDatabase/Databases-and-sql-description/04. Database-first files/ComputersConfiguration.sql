USE [master]
GO
/****** Object:  Database [ComputerConfigurationsSystem]    Script Date: 11/8/2016 3:58:07 PM ******/
CREATE DATABASE [ComputerConfigurationsSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComputerDonfigurationsSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ComputerDonfigurationsSystem.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ComputerDonfigurationsSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ComputerDonfigurationsSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComputerConfigurationsSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET  MULTI_USER 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ComputerConfigurationsSystem', N'ON'
GO
USE [ComputerConfigurationsSystem]
GO
/****** Object:  Table [dbo].[Computers]    Script Date: 11/8/2016 3:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComputerTypeId] [int] NOT NULL,
	[Vendor] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[CpuId] [int] NOT NULL,
 CONSTRAINT [PK_Computers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComputerStorageDivice]    Script Date: 11/8/2016 3:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComputerStorageDivice](
	[ComputerId] [int] NOT NULL,
	[StorageDeviceId] [int] NOT NULL,
 CONSTRAINT [PK_ComputerStorageDivice] PRIMARY KEY CLUSTERED 
(
	[ComputerId] ASC,
	[StorageDeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompyterTypes]    Script Date: 11/8/2016 3:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompyterTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_CompyterTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComutersGpus]    Script Date: 11/8/2016 3:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComutersGpus](
	[ComputerId] [int] NOT NULL,
	[GpuId] [int] NOT NULL,
 CONSTRAINT [PK_ComutersGpus] PRIMARY KEY CLUSTERED 
(
	[ComputerId] ASC,
	[GpuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cpus]    Script Date: 11/8/2016 3:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cpus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Vendor] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[NumberOfCorse] [int] NOT NULL,
	[ClockCycles] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cpus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gpus]    Script Date: 11/8/2016 3:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gpus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Vendor] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Memory] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Gpu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GpuTypes]    Script Date: 11/8/2016 3:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GpuTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GpuTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StorageDevices]    Script Date: 11/8/2016 3:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageDevices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Vendor] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Size] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StorageDevices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StorageDeviceTypes]    Script Date: 11/8/2016 3:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageDeviceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StorageDeviceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Computers]  WITH CHECK ADD  CONSTRAINT [FK_Computers_CompyterTypes] FOREIGN KEY([ComputerTypeId])
REFERENCES [dbo].[CompyterTypes] ([Id])
GO
ALTER TABLE [dbo].[Computers] CHECK CONSTRAINT [FK_Computers_CompyterTypes]
GO
ALTER TABLE [dbo].[Computers]  WITH CHECK ADD  CONSTRAINT [FK_Computers_Cpus] FOREIGN KEY([CpuId])
REFERENCES [dbo].[Cpus] ([Id])
GO
ALTER TABLE [dbo].[Computers] CHECK CONSTRAINT [FK_Computers_Cpus]
GO
ALTER TABLE [dbo].[ComputerStorageDivice]  WITH CHECK ADD  CONSTRAINT [FK_ComputerStorageDivice_Computers] FOREIGN KEY([ComputerId])
REFERENCES [dbo].[Computers] ([Id])
GO
ALTER TABLE [dbo].[ComputerStorageDivice] CHECK CONSTRAINT [FK_ComputerStorageDivice_Computers]
GO
ALTER TABLE [dbo].[ComputerStorageDivice]  WITH CHECK ADD  CONSTRAINT [FK_ComputerStorageDivice_StorageDevices] FOREIGN KEY([StorageDeviceId])
REFERENCES [dbo].[StorageDevices] ([Id])
GO
ALTER TABLE [dbo].[ComputerStorageDivice] CHECK CONSTRAINT [FK_ComputerStorageDivice_StorageDevices]
GO
ALTER TABLE [dbo].[ComutersGpus]  WITH CHECK ADD  CONSTRAINT [FK_ComutersGpus_Computers] FOREIGN KEY([ComputerId])
REFERENCES [dbo].[Computers] ([Id])
GO
ALTER TABLE [dbo].[ComutersGpus] CHECK CONSTRAINT [FK_ComutersGpus_Computers]
GO
ALTER TABLE [dbo].[ComutersGpus]  WITH CHECK ADD  CONSTRAINT [FK_ComutersGpus_Gpus] FOREIGN KEY([GpuId])
REFERENCES [dbo].[Gpus] ([Id])
GO
ALTER TABLE [dbo].[ComutersGpus] CHECK CONSTRAINT [FK_ComutersGpus_Gpus]
GO
ALTER TABLE [dbo].[Gpus]  WITH CHECK ADD  CONSTRAINT [FK_Gpus_GpuTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[GpuTypes] ([Id])
GO
ALTER TABLE [dbo].[Gpus] CHECK CONSTRAINT [FK_Gpus_GpuTypes]
GO
ALTER TABLE [dbo].[StorageDevices]  WITH CHECK ADD  CONSTRAINT [FK_StorageDevices_StorageDeviceTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[StorageDeviceTypes] ([Id])
GO
ALTER TABLE [dbo].[StorageDevices] CHECK CONSTRAINT [FK_StorageDevices_StorageDeviceTypes]
GO
USE [master]
GO
ALTER DATABASE [ComputerConfigurationsSystem] SET  READ_WRITE 
GO
