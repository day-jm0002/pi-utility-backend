use dcv_pi
go

CREATE PROCEDURE dbo.P_OBTER_DATA_GIRO
as
BEGIN

SELECT MAX(dtsaldo_girorenda) as DataGiro FROM INFOTREASURY..Giro_renda

END