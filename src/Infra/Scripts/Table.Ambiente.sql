USE [DCV_PI]
GO


update Ambientes
set IdResponsavel = 1

/****** Object:  Table [dbo].[Ambientes]    Script Date: 04/10/2023 15:42:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE dbo.[Ambientes]
ADD IdNegocio int;

CREATE TABLE [dbo].[Ambientes](
	[Id] [int] NULL,
	[Ambiente] [varchar](15) NULL,
	[Branch] [varchar](255) NULL,
	[NumeroChamado] [varchar](50) NULL,
	[Descricao] [varchar](1000) NULL,
	[IdResponsavel] [int] NULL,
	[LinkDeAcesso] [varchar](1000) NULL,
	[IdNegocio] [int] NULL,
	[Situacao] [int] NULL
) ON [PRIMARY]
GO


INSERT INTO Ambientes(Id, Ambiente, Branch, NumeroChamado, Descricao, IdResponsavel, LinkDeAcesso, IdNegocio,Situacao)
VALUES (1, 'Stage Octopus', '', 1, '', '', 'http://sdaysp06d006:8080/', 1 , 1);

INSERT INTO Ambientes(Id, Ambiente, Branch, NumeroChamado, Descricao, IdResponsavel, LinkDeAcesso, IdNegocio,Situacao)
VALUES (2, 'Stage 1', '', 1, '', '', 'http://sdaysp06d006:8001/', 1,1);

-- Inserção do Item 2
INSERT INTO Ambientes (Id, Ambiente, Branch, NumeroChamado, Descricao, IdResponsavel, LinkDeAcesso, IdNegocio,Situacao)
VALUES (3, 'Stage 2', '', '', '', 7, 'http://sdaysp06d006:8082/', 7,1);

-- Inserção do Item 3
INSERT INTO Ambientes (Id, Ambiente, Branch, NumeroChamado, Descricao, IdResponsavel, LinkDeAcesso, IdNegocio,Situacao)
VALUES (4, 'Stage 3', 'feature/R22_07_08409_Convite_Abertura_Conta', 'R22 07 08409', 'Convite para abertura de contas via Portal de Investimentos', 2, 'http://sdaysp06d006:8083/', 3,1);

-- Inserção do Item 4
INSERT INTO Ambientes (Id, Ambiente, Branch, NumeroChamado, Descricao, IdResponsavel, LinkDeAcesso, IdNegocio,Situacao)
VALUES (5, 'Stage 4 - DMZ', '', 1, '', '', 'http://sdaysp06d006:8004/', 1,1);

-- Inserção do Item 5
INSERT INTO Ambientes (Id, Ambiente, Branch, NumeroChamado, Descricao, IdResponsavel, LinkDeAcesso, IdNegocio,Situacao)
VALUES (6, 'Stage 5', '', 1, '', '', 'http://sdaysp06d006:8085/', 1,1);

-- Inserção do Item 6
INSERT INTO Ambientes (Id, Ambiente, Branch, NumeroChamado, Descricao, IdResponsavel, LinkDeAcesso, IdNegocio,Situacao)
VALUES (7, 'Stage 6', 'feature/R23_04_01538_LiberacaoFlagWhatsApp_2', 'R23 04 01538', 'Liberação da flag para utilização do WhatsApp', 2, 'http://sdaysp06d006:8086/', 3,1);

-- Inserção do Item 7
INSERT INTO Ambientes (Id, Ambiente, Branch, NumeroChamado, Descricao, IdResponsavel, LinkDeAcesso, IdNegocio,Situacao)
VALUES (8, 'Stage 7', 'feature/upgrade-net6', 'R23 08 20007', 'Ambiente exclusivo de teste da versão .net6', 2, 'http://sdaysp06d006:8007/', 2,1);



