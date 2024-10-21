use DCV_PI
GO

CREATE PROCEDURE DBO.P_Liberar_Ambiente_Qa
AS

BEGIN

update Release
set Nome = '', Requisicao = '', DesenvolvedorId = 1 , NegocioId = 1 , DataImplantacao = GETDATE()

delete ReleasePacote

END