USE DCV_PI
GO
  
CREATE PROCEDURE dbo.P_OBTER_LISTA_USUARIOS_PI  
AS  
BEGIN  
  
SELECT   
CodUsuario,  
CASE   
 WHEN CodTipoUsuario = 1 THEN (SELECT Nome FROM TipoUsuario WHERE CodTipoUsuario = 1)   
  WHEN CodTipoUsuario = 2 THEN (SELECT Nome FROM TipoUsuario WHERE CodTipoUsuario = 2)   
   WHEN CodTipoUsuario = 3 THEN (SELECT Nome FROM TipoUsuario WHERE CodTipoUsuario = 3)   
    WHEN CodTipoUsuario = 4 THEN (SELECT Nome FROM TipoUsuario WHERE CodTipoUsuario = 4)  
     WHEN CodTipoUsuario = 5 THEN (SELECT Nome FROM TipoUsuario WHERE CodTipoUsuario = 5)   
ELSE 'Não identificado'   
END AS TIPOUSUARIO,  
CASE   
 WHEN CodTipoAutenticacao = 1 THEN (SELECT Nome FROM TipoAutenticacao WHERE CodTipoAutenticacao = 1)   
  WHEN CodTipoAutenticacao = 2 THEN (SELECT Nome FROM TipoAutenticacao WHERE CodTipoAutenticacao = 2)   
   WHEN CodTipoAutenticacao = 3 THEN (SELECT Nome FROM TipoAutenticacao WHERE CodTipoAutenticacao = 3)   
    WHEN CodTipoAutenticacao = 4 THEN (SELECT Nome FROM TipoAutenticacao WHERE CodTipoAutenticacao = 4)   
     WHEN CodTipoAutenticacao = 5 THEN (SELECT Nome FROM TipoAutenticacao WHERE CodTipoAutenticacao = 5)   
      WHEN CodTipoAutenticacao = 6 THEN (SELECT Nome FROM TipoAutenticacao WHERE CodTipoAutenticacao = 6)   
       WHEN CodTipoAutenticacao = 7 THEN (SELECT Nome FROM TipoAutenticacao WHERE CodTipoAutenticacao = 7)   
ELSE 'Não identificado'  
END AS TIPOAUTENTICACAO,  
CASE   
 WHEN CodRole = 125 THEN  'Agente'  
 WHEN CodRole = 126 THEN  'Gerente Agente'  
 WHEN CodRole = 127 THEN  'Gerente Daycoval'  
 WHEN CodRole = 236 THEN  'Gerente Daycoval AAI'  
 WHEN CodRole = 2933 THEN 'Gestor de Fundos'   
 WHEN CodRole = 2983 THEN 'Operador de Fundos'   
ELSE 'Não identificado'  
END AS ROLE,  
CodExterno,  
Nome,  
Cpf,  
Login,  
Email,  
CASE  
 WHEN Ativo = 1 THEN 'ATIVADO'  
 WHEN Ativo = 0 THEN 'DESATIVADO'  
ELSE 'Não identificado'  
END AS ATIVO  
from  
Usuario  
END