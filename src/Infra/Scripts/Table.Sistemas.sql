USE DCV_PI
GO

CREATE TABLE [dbo].[Sistemas] (
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Nome] NVARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Sistemas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_Sistemas_Nome] UNIQUE ([Nome])
)
GO

-- Inserir os três sistemas
INSERT INTO [dbo].[Sistemas] ([Nome]) 
VALUES 
    ('SGI'),
    ('API DE INVESTIMENTOS'),
    ('INVESTIMENTOS ADM')
GO