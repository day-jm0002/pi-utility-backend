USE DCV_PI
GO

CREATE PROCEDURE  dbo.P_ATUALIZAR_USUARIOS_PI 
(
@CodigoUsuario int,  
@CodigoExterno Varchar(7),  
@Nome Varchar(50),  
@Cpf Varchar(15),  
@Ativo bit  
 ) 
As  
  
UPDATE Usuario  
SET CodExterno = @CodigoExterno,   
 Cpf = @Cpf ,   
 Nome = @Nome,   
 Ativo = @Ativo  
Where CodUsuario = @CodigoUsuario
