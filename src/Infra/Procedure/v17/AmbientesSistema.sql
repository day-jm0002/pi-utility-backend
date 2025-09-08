USE [DCV_PI]
GO

/****** Object:  Table [dbo].[AmbientesSistema]    Script Date: 05/09/2025 16:17:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AmbientesSistema](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSistema] [int] NULL,
	[NumeroChamado] [varchar](50) NULL,
	[Descricao] [varchar](1000) NULL,
	[IdResponsavel] [int] NULL,
	[IdNegocio] [int] NULL,
	[Situacao] [int] NULL,
	[Dependencia] [varchar](100) NULL
) ON [PRIMARY]
GO


