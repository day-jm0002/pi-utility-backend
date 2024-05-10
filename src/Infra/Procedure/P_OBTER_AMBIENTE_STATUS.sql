USE [DCV_PI]
GO
/****** Object:  StoredProcedure [dbo].[P_OBTER_AMBIENTE_STATUS]    Script Date: 09/05/2024 16:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[P_OBTER_AMBIENTE_STATUS]
as
BEGIN

	SELECT * FROM AmbienteStatus
	ORDER BY id

END