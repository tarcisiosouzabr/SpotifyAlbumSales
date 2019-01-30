USE [Spotify]
GO

/****** Object:  Table [dbo].[Genre]    Script Date: 30/01/2019 08:57:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Genre](
	[Id] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Spotify]
GO

/****** Object:  Table [dbo].[GenreCashback]    Script Date: 30/01/2019 08:57:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GenreCashback](
	[Id] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
	[DayOfWeek] [int] NOT NULL,
	[Cashback] [decimal](5, 2) NULL,
 CONSTRAINT [PK_GenreCashback] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[GenreCashback]  WITH CHECK ADD  CONSTRAINT [FK_GenreCashback_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
GO

ALTER TABLE [dbo].[GenreCashback] CHECK CONSTRAINT [FK_GenreCashback_Genre]
GO


USE [Spotify]
GO

/****** Object:  Table [dbo].[Album]    Script Date: 30/01/2019 08:58:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Album](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[GenreId] [int] NOT NULL,
	[Value] [decimal](6, 2) NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
GO

ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Genre]
GO

USE [Spotify]
GO

/****** Object:  Table [dbo].[Sale]    Script Date: 30/01/2019 08:58:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sale](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Spotify]
GO

/****** Object:  Table [dbo].[SaleItem]    Script Date: 30/01/2019 08:58:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SaleItem](
	[Id] [uniqueidentifier] NOT NULL,
	[AlbumId] [uniqueidentifier] NOT NULL,
	[SaleId] [uniqueidentifier] NOT NULL,
	[Cashback] [decimal](5, 2) NULL,
 CONSTRAINT [PK_SaleItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SaleItem]  WITH CHECK ADD  CONSTRAINT [FK_SaleItem_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([Id])
GO

ALTER TABLE [dbo].[SaleItem] CHECK CONSTRAINT [FK_SaleItem_Album]
GO

ALTER TABLE [dbo].[SaleItem]  WITH CHECK ADD  CONSTRAINT [FK_SaleItem_Sale] FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sale] ([Id])
GO

ALTER TABLE [dbo].[SaleItem] CHECK CONSTRAINT [FK_SaleItem_Sale]
GO




