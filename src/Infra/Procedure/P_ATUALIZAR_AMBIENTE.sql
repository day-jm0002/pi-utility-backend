USE [DCV_PI]
GO
/****** Object:  StoredProcedure [dbo].[P_ATUALIZAR_AMBIENTE]    Script Date: 09/05/2024 16:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[P_ATUALIZAR_AMBIENTE]      
    @Id INT,        
    @Branch NVARCHAR(200),      
    @NumeroChamado NVARCHAR(200),      
    @Descricao NVARCHAR(500),      
    @DevId INT,
	@NegId INT,
	@SitId INT
AS      
BEGIN      
    UPDATE Ambientes      
    SET       
        Branch = @Branch,      
        NumeroChamado = @NumeroChamado,      
        Descricao = @Descricao,      
        IdResponsavel = @DevId,
		IdNegocio = @NegId,
		Situacao = @SitId
    WHERE Id = @Id;      
END
