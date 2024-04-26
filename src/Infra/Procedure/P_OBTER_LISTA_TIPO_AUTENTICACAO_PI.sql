USE DCV_PI
GO

CREATE PROCEDURE dbo.P_OBTER_LISTA_TIPO_AUTENTICACAO_PI
AS

SELECT 
	CodTipoAutenticacao,
	Nome,
	Ativo
FROM TipoAutenticacao
ORDER BY CodTipoAutenticacao

GO