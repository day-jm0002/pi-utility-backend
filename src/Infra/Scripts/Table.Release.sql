USE [DCV_PI]
GO

/****** Object:  Table [dbo].[Release]    Script Date: 22/03/2024 16:54:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Release](
	[Id] [int] NOT NULL,
	[Nome] [varchar](100) NULL,
	[Requisicao] [varchar](max) NULL,
	[DesenvolvedorId] [int] NULL,
	[NegocioId] [int] NULL,
	[DataImplantacao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


