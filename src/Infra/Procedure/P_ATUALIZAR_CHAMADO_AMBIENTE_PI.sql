USE [DCV_PI]
GO
/****** Object:  StoredProcedure [dbo].[P_ATUALIZAR_AMBIENTE]    Script Date: 29/04/2024 18:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[P_ATUALIZAR_CHAMADO_AMBIENTE_PI]      
    @ChamadoId INT,        
    @NegocioTesteId INT,      
    @SituacaoId INT
AS      
BEGIN      
    UPDATE ReleasePacote      
    SET       
        NegocioId = @NegocioTesteId,      
        SituacaoId = @SituacaoId     
    WHERE ChamadoId = @ChamadoId;      
END

