USE [DCV_PI]
GO
/****** Object:  StoredProcedure [dbo].[P_AtualizarAmbienteNovoQa]    Script Date: 09/05/2024 16:44:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[P_AtualizarAmbienteNovoQa]
    @Id int,
    @Nome varchar(100),
    @Requisicao varchar(max),
    @DesenvolvedorId int,
    @NegocioId int,
	@DataImplantacao Datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE dbo.Release 
        SET 
            Nome = @Nome, 
            Requisicao = @Requisicao, 
            DesenvolvedorId = @DesenvolvedorId, 
            NegocioId = @NegocioId,
			DataImplantacao = @DataImplantacao
        WHERE Id = @Id;
     
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END