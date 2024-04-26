USE [DCV_PI]
GO

/****** Object:  Table [dbo].[AmbienteStatus]    Script Date: 22/03/2024 16:31:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AmbienteStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
