USE [DCV_PI]
GO
/****** Object:  StoredProcedure [dbo].[P_AtualizarAmbientePacoteNovoQa]    Script Date: 09/05/2024 16:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[P_AtualizarAmbientePacoteNovoQa]

 @ReleaseId INT,
 @Branch NVARCHAR(100), 
 @ChamadoId INT, 
 @NegocioId INT, 
 @SituacaoId INT
AS

BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

		IF( @ChamadoId > 0)
		BEGIN
		UPDATE releasepacote
		SET 
		    Branch = @Branch ,
		    NegocioId = @NegocioId ,
		    SituacaoId = @SituacaoId
		WHERE
		    ChamadoId  = @ChamadoId
		END
		ELSE
		BEGIN

		INSERT INTO ReleasePacote
		(ReleaseId, Branch, NegocioId, SituacaoId)
		VALUES
		(@ReleaseId, @Branch, @NegocioId, @SituacaoId)

		END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END