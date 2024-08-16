use DCV_PI
GO

ALTER TABLE Ambientes
ADD Dependencia varchar(100);

UPDATE Ambientes
SET DEPENDENCIA = ''

