USE [DCV_PI]
GO
/****** Object:  StoredProcedure [dbo].[P_Liberar_Ambiente_Qa]    Script Date: 18/08/2025 18:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[P_Liberar_Ambiente_Qa]
(
	@ID INT
)
AS

BEGIN

update Release
set Nome = '', Requisicao = '', DesenvolvedorId = 1 , NegocioId = 1 , DataImplantacao = GETDATE()
where Id = @ID;

delete ReleasePacote
WHERE ReleaseId = @ID

END

