USE [DCV_PI]
GO
/****** Object:  StoredProcedure [dbo].[P_AtualizarAmbientePacoteNovoQa]    Script Date: 30/08/2024 15:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[P_AtualizarAmbientePacoteNovoQa]

 @ReleaseId INT,
 @Branch NVARCHAR(100), 
 @ChamadoId INT, 
 @NegocioId INT, 
 @SituacaoId INT,
 @Dependencia NVARCHAR(20)
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
		    SituacaoId = @SituacaoId,
			Dependencia = @Dependencia
		WHERE
		    ChamadoId  = @ChamadoId
		END
		ELSE
		BEGIN

		INSERT INTO ReleasePacote
		(ReleaseId, Branch, NegocioId, SituacaoId,Dependencia)
		VALUES
		(@ReleaseId, @Branch, @NegocioId, @SituacaoId,@Dependencia)

		END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END