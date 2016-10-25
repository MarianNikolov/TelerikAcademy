USE [master]
GO

CREATE DATABASE [TransactSQL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TransactSQL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TransactSQL.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TransactSQL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TransactSQL_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TransactSQL] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TransactSQL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TransactSQL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TransactSQL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TransactSQL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TransactSQL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TransactSQL] SET ARITHABORT OFF 
GO
ALTER DATABASE [TransactSQL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TransactSQL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TransactSQL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TransactSQL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TransactSQL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TransactSQL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TransactSQL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TransactSQL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TransactSQL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TransactSQL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TransactSQL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TransactSQL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TransactSQL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TransactSQL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TransactSQL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TransactSQL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TransactSQL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TransactSQL] SET RECOVERY FULL 
GO
ALTER DATABASE [TransactSQL] SET  MULTI_USER 
GO
ALTER DATABASE [TransactSQL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TransactSQL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TransactSQL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TransactSQL] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TransactSQL] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TransactSQL', N'ON'
GO
USE [TransactSQL]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[ufn_CalculateSumAfterMonths]
				(@sum money, @interestRate money, @months int)
		RETURNS money
AS
	BEGIN
	RETURN (((@interestRate / 12)* 10) * @months) + @sum
	END

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Balance] [money] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NOT NULL,
	[OldBalance] [money] NOT NULL,
	[NewBalance] [money] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[First Name] [nvarchar](50) NOT NULL,
	[Last Name] [nvarchar](50) NOT NULL,
	[SSN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (1, 1, 1000.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (2, 2, 971.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (3, 3, 121015.8330)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (4, 4, 1400.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (5, 5, 822.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (6, 6, -12000.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (7, 7, -1300.4100)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (8, 8, 6450.2300)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (9, 9, 632.2300)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (10, 10, 752.1200)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (11, 11, -0.3400)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (12, 12, 94624.3400)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (13, 13, 494590.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (14, 14, -3422.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (15, 15, 2344.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (16, 16, 100050.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (17, 17, 2344.0000)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([LogID], [AccountID], [OldBalance], [NewBalance]) VALUES (1, 5, 600.0000, 822.0000)
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (1, N'Ivan', N'Kostov', N'22212')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (2, N'Preslav', N'Prtrov', N'22213')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (3, N'Ignat', N'Pavlov', N'22214')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (4, N'Ivo', N'Kirilov', N'22215')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (5, N'Hristo', N'Jekov', N'22216')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (6, N'Georgi', N'Hristov', N'22217')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (7, N'Joro', N'Goergiev', N'22218')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (8, N'Ivan', N'Jainov', N'22219')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (9, N'Kamen', N'Ivanov', N'22220')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (10, N'Kiril', N'Kemenov', N'22221')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (11, N'Iordan', N'kirilov', N'22222')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (12, N'Mihail', N'Iordanov', N'22223')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (13, N'Meto', N'Mihailov', N'22224')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (14, N'Lubo', N'Metodiev', N'22225')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (15, N'Bobi', N'Lubomirov', N'22226')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (16, N'Maria', N'Borislavova', N'22227')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (17, N'Cvetka', N'Angelova', N'22228')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (18, N'Svetla', N'Cvetelinova', N'22229')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (19, N'Geri', N'Svetelinova', N'22230')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (20, N'Kamelia', N'Georgirva', N'22231')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (21, N'Ivana', N'Kirilova', N'22232')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (22, N'Radost', N'Kamenova', N'22233')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (23, N'Sashka', N'Petrova', N'22234')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (24, N'Aleksandar', N'Fikova', N'22235')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (25, N'Dobrei', N'Slavova', N'22236')
INSERT [dbo].[Persons] ([ID], [First Name], [Last Name], [SSN]) VALUES (26, N'Atanas', N'Aleksandrova', N'22237')
SET IDENTITY_INSERT [dbo].[Persons] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons1] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([ID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons1]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([ID])
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Accounts]
GO
/****** Object:  StoredProcedure [dbo].[usp_CalculateSumAfterMonths]    Script Date: 21/10/2015 00:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_CalculateSumAfterMonths]
				(@sum money, @interestRate money, @months int)
AS
	SELECT (((@interestRate / 12)* 10) * @months) + @sum AS [Your money]


GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Deposit](@id int, @money money)
AS
	DECLARE @personMoney money = (SELECT Balance FROM Accounts
							WHERE PersonID = @id)
	BEGIN TRANSACTION

	UPDATE Accounts
		SET Balance = Balance + @money
		WHERE PersonID = @id
	IF @@ROWCOUNT <> 1
	BEGIN
		ROLLBACK
		RAISERROR('Invalid ID', 16, 1);
		RETURN
	END
	COMMIT

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_FindAllPersonsThatHaveBalanceHigherThan]
				 (@balanceMoreThan money)
AS
	SELECT  p.[First Name], p.[Last Name], a.Balance
	FROM [Persons] p
	JOIN [Accounts] a ON p.ID = a.PersonID
	WHERE a.Balance > @balanceMoreThan

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_GivePersonInterasteRate]
			(@AccountID int ,@interestRate money)
AS
	 DECLARE @money int = (SELECT Balance FROM Accounts
					WHERE PersonID = @AccountID)

	UPDATE Accounts
	 SET Balance= dbo.ufn_CalculateSumAfterMonths(@money, @interestRate, 1)
	 WHERE PersonID = @AccountID

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_SelectFullNamesFromPersons]
AS 
	SELECT p.[First Name] + ' ' + p.[Last Name] AS [FullName]
	FROM [Persons] p

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_Withdraw](@id int, @money money)
AS
	DECLARE @personMoney money = (SELECT Balance FROM Accounts
							WHERE PersonID = @id)
	BEGIN TRANSACTION

	IF @personMoney <= @money
	BEGIN
		ROLLBACK
		RAISERROR('Not enough money!', 16, 1);
		RETURN
	END

	UPDATE Accounts
		SET Balance = Balance - @money
		WHERE PersonID = @id
	IF @@ROWCOUNT <> 1
	BEGIN
		ROLLBACK
		RAISERROR('Invalid ID', 16, 1);
		RETURN
	END
	COMMIT

GO
USE [master]
GO
ALTER DATABASE [TransactSQL] SET  READ_WRITE 
GO
