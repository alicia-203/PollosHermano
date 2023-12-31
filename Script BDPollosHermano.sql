USE [master]
GO
/****** Object:  Database [PollosHermano]    Script Date: 18/10/2023 12:22:31 p. m. ******/
CREATE DATABASE [PollosHermano]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PollosHermano', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PollosHermano.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PollosHermano_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PollosHermano_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PollosHermano] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PollosHermano].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PollosHermano] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PollosHermano] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PollosHermano] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PollosHermano] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PollosHermano] SET ARITHABORT OFF 
GO
ALTER DATABASE [PollosHermano] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PollosHermano] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PollosHermano] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PollosHermano] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PollosHermano] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PollosHermano] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PollosHermano] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PollosHermano] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PollosHermano] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PollosHermano] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PollosHermano] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PollosHermano] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PollosHermano] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PollosHermano] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PollosHermano] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PollosHermano] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PollosHermano] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PollosHermano] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PollosHermano] SET  MULTI_USER 
GO
ALTER DATABASE [PollosHermano] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PollosHermano] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PollosHermano] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PollosHermano] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PollosHermano] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PollosHermano] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PollosHermano] SET QUERY_STORE = OFF
GO
USE [PollosHermano]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 18/10/2023 12:22:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientePlantilla]    Script Date: 18/10/2023 12:22:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientePlantilla](
	[ClientePlantillaID] [int] IDENTITY(1,1) NOT NULL,
	[ClienteID] [int] NOT NULL,
	[PlantillaID] [int] NOT NULL,
 CONSTRAINT [PK_ClientePlantilla] PRIMARY KEY CLUSTERED 
(
	[ClientePlantillaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plantilla]    Script Date: 18/10/2023 12:22:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plantilla](
	[PlantillaID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Body] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Plantilla] PRIMARY KEY CLUSTERED 
(
	[PlantillaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 18/10/2023 12:22:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[RegionID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[RegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegionTipoNotificacion]    Script Date: 18/10/2023 12:22:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionTipoNotificacion](
	[RegionTipoNotificacionID] [int] IDENTITY(1,1) NOT NULL,
	[RegionID] [int] NOT NULL,
	[TipoNotificacionID] [int] NOT NULL,
 CONSTRAINT [PK_RegionTipoNotificacion] PRIMARY KEY CLUSTERED 
(
	[RegionTipoNotificacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoNotificacion]    Script Date: 18/10/2023 12:22:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoNotificacion](
	[TipoNotificacionID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoNotificacion] PRIMARY KEY CLUSTERED 
(
	[TipoNotificacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteID], [Nombre]) VALUES (1, N'Cliente 1')
INSERT [dbo].[Cliente] ([ClienteID], [Nombre]) VALUES (2, N'Cliente2')
INSERT [dbo].[Cliente] ([ClienteID], [Nombre]) VALUES (3, N'Cliente3')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientePlantilla] ON 

INSERT [dbo].[ClientePlantilla] ([ClientePlantillaID], [ClienteID], [PlantillaID]) VALUES (1, 1, 4)
INSERT [dbo].[ClientePlantilla] ([ClientePlantillaID], [ClienteID], [PlantillaID]) VALUES (2, 2, 1)
INSERT [dbo].[ClientePlantilla] ([ClientePlantillaID], [ClienteID], [PlantillaID]) VALUES (3, 1, 1)
SET IDENTITY_INSERT [dbo].[ClientePlantilla] OFF
GO
SET IDENTITY_INSERT [dbo].[Plantilla] ON 

INSERT [dbo].[Plantilla] ([PlantillaID], [Nombre], [Body]) VALUES (1, N'Plantilla1', N'<html>
<head><h1>Plantilla 1 WELCOME<h1
</head>
<body>
<p>prueba</p>
</body>
</html>')
INSERT [dbo].[Plantilla] ([PlantillaID], [Nombre], [Body]) VALUES (4, N'Plantilla2', N'<html><head>Plantilla 2 WELCOME</head><body></body></html>')
SET IDENTITY_INSERT [dbo].[Plantilla] OFF
GO
SET IDENTITY_INSERT [dbo].[Region] ON 

INSERT [dbo].[Region] ([RegionID], [Nombre]) VALUES (1, N'Region 1')
SET IDENTITY_INSERT [dbo].[Region] OFF
GO
SET IDENTITY_INSERT [dbo].[RegionTipoNotificacion] ON 

INSERT [dbo].[RegionTipoNotificacion] ([RegionTipoNotificacionID], [RegionID], [TipoNotificacionID]) VALUES (1, 1, 1)
INSERT [dbo].[RegionTipoNotificacion] ([RegionTipoNotificacionID], [RegionID], [TipoNotificacionID]) VALUES (2, 1, 2)
INSERT [dbo].[RegionTipoNotificacion] ([RegionTipoNotificacionID], [RegionID], [TipoNotificacionID]) VALUES (3, 1, 3)
SET IDENTITY_INSERT [dbo].[RegionTipoNotificacion] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoNotificacion] ON 

INSERT [dbo].[TipoNotificacion] ([TipoNotificacionID], [Nombre]) VALUES (1, N'Email')
INSERT [dbo].[TipoNotificacion] ([TipoNotificacionID], [Nombre]) VALUES (2, N'Sms')
INSERT [dbo].[TipoNotificacion] ([TipoNotificacionID], [Nombre]) VALUES (3, N'Push')
SET IDENTITY_INSERT [dbo].[TipoNotificacion] OFF
GO
ALTER TABLE [dbo].[ClientePlantilla]  WITH CHECK ADD  CONSTRAINT [FK_ClientePlantilla_Cliente] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[ClientePlantilla] CHECK CONSTRAINT [FK_ClientePlantilla_Cliente]
GO
ALTER TABLE [dbo].[ClientePlantilla]  WITH CHECK ADD  CONSTRAINT [FK_ClientePlantilla_Plantilla] FOREIGN KEY([PlantillaID])
REFERENCES [dbo].[Plantilla] ([PlantillaID])
GO
ALTER TABLE [dbo].[ClientePlantilla] CHECK CONSTRAINT [FK_ClientePlantilla_Plantilla]
GO
ALTER TABLE [dbo].[RegionTipoNotificacion]  WITH CHECK ADD  CONSTRAINT [FK_RegionTipoNotificacion_Region] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Region] ([RegionID])
GO
ALTER TABLE [dbo].[RegionTipoNotificacion] CHECK CONSTRAINT [FK_RegionTipoNotificacion_Region]
GO
ALTER TABLE [dbo].[RegionTipoNotificacion]  WITH CHECK ADD  CONSTRAINT [FK_RegionTipoNotificacion_TipoNotificacion] FOREIGN KEY([TipoNotificacionID])
REFERENCES [dbo].[TipoNotificacion] ([TipoNotificacionID])
GO
ALTER TABLE [dbo].[RegionTipoNotificacion] CHECK CONSTRAINT [FK_RegionTipoNotificacion_TipoNotificacion]
GO
USE [master]
GO
ALTER DATABASE [PollosHermano] SET  READ_WRITE 
GO
