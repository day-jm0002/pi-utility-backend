USE [DCV_PI]
GO

/****** Object:  Table [dbo].[ReleasePacote]    Script Date: 22/03/2024 16:54:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReleasePacote](
	[ReleaseId] [int] NULL,
	[Branch] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ReleasePacote]  WITH CHECK ADD FOREIGN KEY([ReleaseId])
REFERENCES [dbo].[Release] ([Id])
GO


