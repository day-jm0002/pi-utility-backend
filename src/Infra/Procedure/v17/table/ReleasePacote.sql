USE [DCV_PI]
GO

/****** Object:  Table [dbo].[ReleasePacote]    Script Date: 05/09/2025 17:39:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReleasePacote](
	[ReleaseId] [int] NULL,
	[Branch] [varchar](max) NULL,
	[ChamadoId] [int] IDENTITY(1,1) NOT NULL,
	[NegocioId] [int] NULL,
	[SituacaoId] [int] NULL,
	[Dependencia] [nvarchar](20) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ReleasePacote] ADD  DEFAULT ((0)) FOR [NegocioId]
GO

ALTER TABLE [dbo].[ReleasePacote] ADD  DEFAULT ((0)) FOR [SituacaoId]
GO

ALTER TABLE [dbo].[ReleasePacote]  WITH CHECK ADD FOREIGN KEY([ReleaseId])
REFERENCES [dbo].[Release] ([Id])
GO


