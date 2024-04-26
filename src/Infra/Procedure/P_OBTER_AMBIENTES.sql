USE DCV_PI
GO

CREATE PROCEDURE [dbo].[P_OBTER_AMBIENTES]  
AS  
BEGIN  
  
SELECT    
a.Id  
,Ambiente AS 'Nome'  
,Branch as 'Branch'  
,NumeroChamado as 'NumeroChamado'  
,Descricao as 'Descricao'  
,IdResponsavel as 'DevId'  
,dev.Nome as 'Desenvolvedor'
,IdNegocio as 'NegId'
,neg.Nome as 'Negocio'
,LinkDeAcesso as 'Link'  
from dbo.ambientes a Inner Join  
desenvolvedores as dev  
on a.IdResponsavel = dev.Id  
Inner Join Negocio as neg
on a.idNegocio = neg.id
order by a.Id  
  
END

