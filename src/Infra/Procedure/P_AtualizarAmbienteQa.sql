USE DCV_PI
GO

CREATE PROCEDURE dbo.P_AtualizarAmbienteQa
    @Id int,
    @Nome varchar(100),
    @Requisicao varchar(max),
    @DesenvolvedorId int,
    @NegocioId int,
	@DataImplantacao Datetime,
    @Branches BranchTableType READONLY
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

        DELETE FROM dbo.ReleasePacote WHERE ReleaseId = @Id;

        INSERT INTO dbo.ReleasePacote (ReleaseId, Branch)
        SELECT ReleaseId, Branch
        FROM @Branches;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END