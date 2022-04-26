
/****** Object:  Database [LibraryConsoleAppDb]    Script Date: 4/25/2022 2:15:00 PM ******/

IF ((SELECT COUNT(*) FROM sys.databases WHERE [Name] = 'LibraryConsoleAppDb') > 0)
BEGIN
		DROP DATABASE [LibraryConsoleAppDb]
END

/****** Object:  Database [LibraryConsoleAppDb]    Script Date: 4/25/2022 2:15:00 PM ******/
CREATE DATABASE [LibraryConsoleAppDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryConsoleAppDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LibraryConsoleAppDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryConsoleAppDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LibraryConsoleAppDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

USE [LibraryConsoleAppDb]
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryConsoleAppDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [LibraryConsoleAppDb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET ARITHABORT OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET RECOVERY FULL 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET  MULTI_USER 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [LibraryConsoleAppDb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [LibraryConsoleAppDb] SET QUERY_STORE = OFF
GO

ALTER DATABASE [LibraryConsoleAppDb] SET  READ_WRITE 
GO

--ALTER TABLE [LibraryConsoleAppDb].[dbo].[USER_ROLE] DROP CONSTRAINT [FK__USER_ROLE__UserI__6754599E]
--GO

--ALTER TABLE [LibraryConsoleAppDb].[dbo].[USER_ROLE] DROP CONSTRAINT [FK__USER_ROLE__RoleI__68487DD7]
--GO

/****** Object:  Table [dbo].[USER_ROLE]    Script Date: 4/25/2022 2:17:51 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USER_ROLE]') AND type in (N'U'))
DROP TABLE [LibraryConsoleAppDb].[dbo].[USER_ROLE]
GO

--ALTER TABLE [LibraryConsoleAppDb].[dbo].[USER_MEDIA] DROP CONSTRAINT [FK__USER_MEDI__UserI__60A75C0F]
--GO

--ALTER TABLE [dbo].[USER_MEDIA] DROP CONSTRAINT [FK__USER_MEDI__Media__619B8048]
--GO

/****** Object:  Table [dbo].[USER_MEDIA]    Script Date: 4/25/2022 2:19:11 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USER_MEDIA]') AND type in (N'U'))
DROP TABLE [dbo].[USER_MEDIA]
GO


/****** Object:  Table [dbo].[ROLE]    Script Date: 4/25/2022 2:16:07 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ROLE]') AND type in (N'U'))
DROP TABLE [dbo].[ROLE]
GO

/****** Object:  Table [dbo].[ROLE]    Script Date: 4/25/2022 2:16:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ROLE](
	[RoleId] [int] NOT NULL,
	[Name] [nvarchar](24) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[USER]    Script Date: 4/25/2022 2:16:34 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USER]') AND type in (N'U'))
DROP TABLE [dbo].[USER]
GO

/****** Object:  Table [dbo].[USER]    Script Date: 4/25/2022 2:16:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[USER](
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](16) NOT NULL,
	[Password] [nvarchar](16) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[MEDIA]    Script Date: 4/25/2022 2:17:25 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MEDIA]') AND type in (N'U'))
DROP TABLE [dbo].[MEDIA]
GO

/****** Object:  Table [dbo].[MEDIA]    Script Date: 4/25/2022 2:17:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEDIA](
	[MediaId] [int] NOT NULL,
	[Type] [nvarchar](24) NOT NULL,
	[Name] [nvarchar](24) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MediaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[USER_ROLE]    Script Date: 4/25/2022 2:17:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[USER_ROLE](
	[UserRoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[USER_ROLE]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[MEDIA] ([MediaId])
GO

ALTER TABLE [dbo].[USER_ROLE]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO


/****** Object:  Table [dbo].[USER_MEDIA]    Script Date: 4/25/2022 2:19:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[USER_MEDIA](
	[UserMediaId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[MediaId] [int] NOT NULL,
	[CheckOutDate] [datetime] NOT NULL,
	[CheckInDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserMediaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[USER_MEDIA]  WITH CHECK ADD FOREIGN KEY([MediaId])
REFERENCES [dbo].[MEDIA] ([MediaId])
GO

ALTER TABLE [dbo].[USER_MEDIA]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO

USE [LibraryConsoleAppDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertRole]    Script Date: 4/25/2022 2:21:15 PM ******/
--DROP PROCEDURE [dbo].[sp_InsertRole]
--GO

/****** Object:  StoredProcedure [dbo].[sp_InsertRole]    Script Date: 4/25/2022 2:21:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertRole]
(
	@RoleId int,
	@Name nvarchar(24)
)
AS
	SET NOCOUNT OFF;
INSERT INTO [ROLE] ([RoleId], [Name]) VALUES (@RoleId, @Name)
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertUser]    Script Date: 4/25/2022 2:21:45 PM ******/
--DROP PROCEDURE [dbo].[sp_InsertUser]
--GO

/****** Object:  StoredProcedure [dbo].[sp_InsertUser]    Script Date: 4/25/2022 2:21:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertUser]
(
	@UserId int,
	@Name nvarchar(16),
	@Password nvarchar(16),
	@IsAdmin bit
)
AS
	SET NOCOUNT OFF;
INSERT INTO [USER] ([UserId], [Name], [Password], [IsAdmin]) VALUES (@UserId, @Name, @Password, @IsAdmin)
GO

/****** Object:  StoredProcedure [dbo].[sp_SelectRole]    Script Date: 4/25/2022 2:22:28 PM ******/
--DROP PROCEDURE [dbo].[sp_SelectRole]
--GO

/****** Object:  StoredProcedure [dbo].[sp_SelectRole]    Script Date: 4/25/2022 2:22:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_SelectRole]
(
	@RoleId int
)
AS
	SET NOCOUNT ON;
SELECT * FROM [ROLE]
WHERE RoleId = @RoleId;
GO

/****** Object:  StoredProcedure [dbo].[sp_SelectRoles]    Script Date: 4/25/2022 2:22:57 PM ******/
--DROP PROCEDURE [dbo].[sp_SelectRoles]
--GO

/****** Object:  StoredProcedure [dbo].[sp_SelectRoles]    Script Date: 4/25/2022 2:22:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_SelectRoles]
AS
	SET NOCOUNT ON;
SELECT * FROM [ROLE]
GO

/****** Object:  StoredProcedure [dbo].[sp_SelectUser]    Script Date: 4/25/2022 2:23:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_SelectUser]
(
	@UserId int
)
AS
	SET NOCOUNT ON;
SELECT * FROM [USER]
WHERE UserId = @UserId;
GO

/****** Object:  StoredProcedure [dbo].[sp_SelectUsers]    Script Date: 4/25/2022 2:23:49 PM ******/
--DROP PROCEDURE [dbo].[sp_SelectUsers]
--GO

/****** Object:  StoredProcedure [dbo].[sp_SelectUsers]    Script Date: 4/25/2022 2:23:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_SelectUsers]
AS
	SET NOCOUNT ON;
SELECT * FROM [USER]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateRole]    Script Date: 4/25/2022 2:24:14 PM ******/
--DROP PROCEDURE [dbo].[sp_UpdateRole]
--GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateRole]    Script Date: 4/25/2022 2:24:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_UpdateRole]
(
	@RoleId int,
	@Name nvarchar(16)
)
	
AS 
BEGIN 
 
UPDATE [dbo].[ROLE]
SET  Name = @Name
WHERE  RoleId = @RoleId
END
GO

CREATE PROC [dbo].[sp_UpdateUser]
(
    @UserId int,
	@Name nvarchar(16),
	@Password nvarchar(16),
	@IsAdmin bit
)
	
AS 
BEGIN 
 
UPDATE [dbo].[USER]
SET  Name = @Name, 
     Password = @Password,
     IsAdmin = @IsAdmin
WHERE  UserId = @UserId
END
GO

--- DML Section ---
INSERT INTO [dbo].[USER] VALUES(1,'user1','userPass1',0);
INSERT INTO [dbo].[USER] VALUES(2,'user2','userPass2',0);
INSERT INTO [dbo].[USER] VALUES(3,'user3','userPass3',0);
GO

INSERT INTO [dbo].[ROLE] VALUES(1,'Guest');
INSERT INTO [dbo].[ROLE]  VALUES(2,'Administrator');
INSERT INTO [dbo].[ROLE]  VALUES(3,'Librarian');
INSERT INTO [dbo].[ROLE]  VALUES(4,'Patron');
GO
-------------------