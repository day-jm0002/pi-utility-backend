USE [DCV_PI]
GO
/****** Object:  StoredProcedure [dbo].[P_OBTER_AMBIENTES]    Script Date: 09/05/2024 16:37:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[P_OBTER_AMBIENTES]  
AS  
BEGIN  
  
SELECT    
a.Id  
,Ambiente AS 'Nome'  
,Branch as 'Branch'  
,NumeroChamado as 'NumeroChamado'  
,a.Descricao as 'Descricao'  
,IdResponsavel as 'DevId'  
,dev.Nome as 'Desenvolvedor'
,IdNegocio as 'NegId'
,neg.Nome as 'Negocio'
,LinkDeAcesso as 'Link'
,AMS.Id as 'SituacaoId'
,AMS.Descricao as 'Situacao'
from dbo.ambientes a Inner Join  
desenvolvedores as dev  
on a.IdResponsavel = dev.Id  
Inner Join Negocio as neg
on a.IdNegocio = neg.id
Inner join AmbienteStatus AMS
on a.Situacao = AMS.id
order by a.Id  
  
END