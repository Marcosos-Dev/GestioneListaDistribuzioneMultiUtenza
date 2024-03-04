USE [master]
GO
/****** Object:  Database [DistribuzioneMultiUtenza]    Script Date: 04/03/2024 12:33:37 ******/
CREATE DATABASE [DistribuzioneMultiUtenza]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DistribuzioneMultiUtenza', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DistribuzioneMultiUtenza.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DistribuzioneMultiUtenza_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DistribuzioneMultiUtenza_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DistribuzioneMultiUtenza].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET ARITHABORT OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET RECOVERY FULL 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET  MULTI_USER 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DistribuzioneMultiUtenza', N'ON'
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET QUERY_STORE = ON
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DistribuzioneMultiUtenza]
GO
/****** Object:  User [paradigmi]    Script Date: 04/03/2024 12:33:37 ******/
CREATE USER [paradigmi] FOR LOGIN [paradigmi] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [paradigmi]
GO
/****** Object:  Table [dbo].[Destinatari]    Script Date: 04/03/2024 12:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinatari](
	[IdDestinatario] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDestinatario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Liste_Destinatari]    Script Date: 04/03/2024 12:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Liste_Destinatari](
	[IdListaDestinatari] [int] IDENTITY(1,1) NOT NULL,
	[IdLista] [int] NULL,
	[IdDestinatario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdListaDestinatari] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListeDistribuzione]    Script Date: 04/03/2024 12:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListeDistribuzione](
	[IdLista] [int] IDENTITY(1,1) NOT NULL,
	[IdProprietario] [int] NULL,
	[NomeLista] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 04/03/2024 12:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[IdUtente] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Cognome] [varchar](255) NOT NULL,
	[Password] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUtente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Destinatari] ON 
GO
INSERT [dbo].[Destinatari] ([IdDestinatario], [Email]) VALUES (1, N'first@gmail.com')
GO
INSERT [dbo].[Destinatari] ([IdDestinatario], [Email]) VALUES (2, N'second@gmail.com')
GO
INSERT [dbo].[Destinatari] ([IdDestinatario], [Email]) VALUES (3, N'third@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Destinatari] OFF
GO
SET IDENTITY_INSERT [dbo].[Liste_Destinatari] ON 
GO
INSERT [dbo].[Liste_Destinatari] ([IdListaDestinatari], [IdLista], [IdDestinatario]) VALUES (1, 1, 1)
GO
INSERT [dbo].[Liste_Destinatari] ([IdListaDestinatari], [IdLista], [IdDestinatario]) VALUES (2, 1, 2)
GO
INSERT [dbo].[Liste_Destinatari] ([IdListaDestinatari], [IdLista], [IdDestinatario]) VALUES (3, 1, 3)
GO
INSERT [dbo].[Liste_Destinatari] ([IdListaDestinatari], [IdLista], [IdDestinatario]) VALUES (4, 2, 2)
GO
INSERT [dbo].[Liste_Destinatari] ([IdListaDestinatari], [IdLista], [IdDestinatario]) VALUES (5, 3, 1)
GO
INSERT [dbo].[Liste_Destinatari] ([IdListaDestinatari], [IdLista], [IdDestinatario]) VALUES (6, 3, 2)
GO
SET IDENTITY_INSERT [dbo].[Liste_Destinatari] OFF
GO
SET IDENTITY_INSERT [dbo].[ListeDistribuzione] ON 
GO
INSERT [dbo].[ListeDistribuzione] ([IdLista], [IdProprietario], [NomeLista]) VALUES (1, 1, N'viva_bus')
GO
INSERT [dbo].[ListeDistribuzione] ([IdLista], [IdProprietario], [NomeLista]) VALUES (2, 1, N'acqua viva')
GO
INSERT [dbo].[ListeDistribuzione] ([IdLista], [IdProprietario], [NomeLista]) VALUES (3, 2, N'I catechisti')
GO
SET IDENTITY_INSERT [dbo].[ListeDistribuzione] OFF
GO
SET IDENTITY_INSERT [dbo].[Utenti] ON 
GO
INSERT [dbo].[Utenti] ([IdUtente], [Email], [Nome], [Cognome], [Password]) VALUES (1, N'pino@gmail.com', N'pino', N'pino', N'Pino123!')
GO
INSERT [dbo].[Utenti] ([IdUtente], [Email], [Nome], [Cognome], [Password]) VALUES (2, N'gino@gmail.com', N'gino', N'gino', N'Gino123!')
GO
SET IDENTITY_INSERT [dbo].[Utenti] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Destinat__A9D10534310849D9]    Script Date: 04/03/2024 12:33:38 ******/
ALTER TABLE [dbo].[Destinatari] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Utenti__A9D10534C676B640]    Script Date: 04/03/2024 12:33:38 ******/
ALTER TABLE [dbo].[Utenti] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Liste_Destinatari]  WITH CHECK ADD FOREIGN KEY([IdDestinatario])
REFERENCES [dbo].[Destinatari] ([IdDestinatario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Liste_Destinatari]  WITH CHECK ADD FOREIGN KEY([IdLista])
REFERENCES [dbo].[ListeDistribuzione] ([IdLista])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListeDistribuzione]  WITH CHECK ADD FOREIGN KEY([IdProprietario])
REFERENCES [dbo].[Utenti] ([IdUtente])
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [DistribuzioneMultiUtenza] SET  READ_WRITE 
GO