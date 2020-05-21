USE [master]
GO
/****** Object:  Database [Kanban]    Script Date: 5/21/2020 11:22:07 PM ******/
CREATE DATABASE [Kanban]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kanban', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kanban.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Kanban_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kanban_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Kanban] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kanban].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Kanban] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Kanban] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Kanban] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Kanban] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Kanban] SET ARITHABORT OFF 
GO
ALTER DATABASE [Kanban] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Kanban] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Kanban] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Kanban] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Kanban] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Kanban] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Kanban] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Kanban] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Kanban] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Kanban] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Kanban] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Kanban] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Kanban] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Kanban] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Kanban] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Kanban] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Kanban] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Kanban] SET RECOVERY FULL 
GO
ALTER DATABASE [Kanban] SET  MULTI_USER 
GO
ALTER DATABASE [Kanban] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Kanban] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Kanban] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Kanban] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Kanban] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Kanban', N'ON'
GO
ALTER DATABASE [Kanban] SET QUERY_STORE = OFF
GO
USE [Kanban]
GO
/****** Object:  Table [dbo].[Board]    Script Date: 5/21/2020 11:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BoardName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 5/21/2020 11:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](100) NULL,
	[isfinished] [bit] NULL,
	[todoid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Todo]    Script Date: 5/21/2020 11:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Todo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TodoName] [nvarchar](100) NOT NULL,
	[Deadline] [date] NULL,
	[DeadlineStatus] [bit] NULL,
	[BoardId] [int] NULL,
	[Prio] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD FOREIGN KEY([todoid])
REFERENCES [dbo].[Todo] ([Id])
GO
ALTER TABLE [dbo].[Todo]  WITH CHECK ADD FOREIGN KEY([BoardId])
REFERENCES [dbo].[Board] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[getboards]    Script Date: 5/21/2020 11:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getboards]
AS
BEGIN
select * from dbo.Board 
END
GO
/****** Object:  StoredProcedure [dbo].[getitems]    Script Date: 5/21/2020 11:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getitems]
@Id int
as
begin
    select * from dbo.Item where todoid = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[gettodos]    Script Date: 5/21/2020 11:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[gettodos]
AS
BEGIN
select* from dbo.Todo 
END
GO
/****** Object:  StoredProcedure [dbo].[NewBoard]    Script Date: 5/21/2020 11:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NewBoard]
@name nvarchar(50)
as
begin
    -- Insert rows into table 'Board' in schema '[dbo]'
    insert into dbo.Board(BoardName)
    Values (@name)

    select * from dbo.Board where Id = SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[NewItem]    Script Date: 5/21/2020 11:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NewItem]
@TodoId int,
@Name nvarchar(100)
as
begin
    insert into [dbo].[Item] (ItemName,isfinished,todoid)
    values (@Name,0,@TodoId)

    select * from [dbo].[item] where Id = SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[NewTodo]    Script Date: 5/21/2020 11:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NewTodo]
@BoardId int,
@Name nvarchar(100)
as
begin
    insert into dbo.Todo (TodoName, Prio ,BoardId)
    values (@name, 0,@BoardId)

    select * from dbo.Todo where Id = SCOPE_IDENTITY()
end
GO
USE [master]
GO
ALTER DATABASE [Kanban] SET  READ_WRITE 
GO
