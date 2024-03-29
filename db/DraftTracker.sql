USE [master]
GO
/****** Object:  Database [DraftTracker]    Script Date: 08/24/2011 06:43:26 ******/
CREATE DATABASE [DraftTracker] ON  PRIMARY 
( NAME = N'DraftTracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\DraftTracker.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DraftTracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\DraftTracker_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DraftTracker] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DraftTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DraftTracker] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DraftTracker] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DraftTracker] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DraftTracker] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DraftTracker] SET ARITHABORT OFF
GO
ALTER DATABASE [DraftTracker] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [DraftTracker] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DraftTracker] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DraftTracker] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DraftTracker] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DraftTracker] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DraftTracker] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DraftTracker] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DraftTracker] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DraftTracker] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DraftTracker] SET  DISABLE_BROKER
GO
ALTER DATABASE [DraftTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DraftTracker] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DraftTracker] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DraftTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DraftTracker] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DraftTracker] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DraftTracker] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DraftTracker] SET  READ_WRITE
GO
ALTER DATABASE [DraftTracker] SET RECOVERY FULL
GO
ALTER DATABASE [DraftTracker] SET  MULTI_USER
GO
ALTER DATABASE [DraftTracker] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DraftTracker] SET DB_CHAINING OFF
GO
USE [DraftTracker]
GO
/****** Object:  User [drafttracker]    Script Date: 08/24/2011 06:43:26 ******/
CREATE USER [drafttracker] FOR LOGIN [drafttracker] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Leagues]    Script Date: 08/24/2011 06:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leagues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Leagues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 08/24/2011 06:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 08/24/2011 06:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LeagueId] [int] NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 08/24/2011 06:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Players](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[Team] [nvarchar](10) NOT NULL,
	[PositionId] [int] NOT NULL,
	[MyFantasyLeagueId] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LeagueRules]    Script Date: 08/24/2011 06:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeagueRules](
	[LeagueId] [int] NOT NULL,
	[PassingYards] [decimal](10, 2) NULL,
	[PassingTD] [decimal](10, 2) NULL,
	[IntThrown] [decimal](10, 2) NULL,
	[RushingYards] [decimal](10, 2) NULL,
	[RushingTD] [decimal](10, 2) NULL,
	[ReceivingYards] [decimal](10, 2) NULL,
	[ReceivingTD] [decimal](10, 2) NULL,
	[FieldGoal] [decimal](10, 2) NULL,
	[FieldGoal50Plus] [decimal](10, 2) NULL,
	[FieldGoalMissed] [decimal](10, 2) NULL,
	[PAT] [decimal](10, 2) NULL,
	[PATMissed] [decimal](10, 2) NULL,
	[Sack] [decimal](10, 2) NULL,
	[Block] [decimal](10, 2) NULL,
	[Interception] [decimal](10, 2) NULL,
	[Fumble] [decimal](10, 2) NULL,
	[Safety] [decimal](10, 2) NULL,
	[Touchdown] [decimal](10, 2) NULL,
 CONSTRAINT [PK_LeagueRules] PRIMARY KEY CLUSTERED 
(
	[LeagueId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Teams_Leagues]    Script Date: 08/24/2011 06:43:27 ******/
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Leagues] FOREIGN KEY([LeagueId])
REFERENCES [dbo].[Leagues] ([Id])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Leagues]
GO
/****** Object:  ForeignKey [FK_Players_Positions]    Script Date: 08/24/2011 06:43:27 ******/
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Positions] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Positions]
GO
/****** Object:  ForeignKey [FK_LeagueRules_Leagues]    Script Date: 08/24/2011 06:43:27 ******/
ALTER TABLE [dbo].[LeagueRules]  WITH CHECK ADD  CONSTRAINT [FK_LeagueRules_Leagues] FOREIGN KEY([LeagueId])
REFERENCES [dbo].[Leagues] ([Id])
GO
ALTER TABLE [dbo].[LeagueRules] CHECK CONSTRAINT [FK_LeagueRules_Leagues]
GO
