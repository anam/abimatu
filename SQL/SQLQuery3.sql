USE [AbiMatuEnterpriseDB]
GO
/****** Object:  UserDefinedFunction [dbo].[getTotalTransactionAmount]    Script Date: 05/15/2014 12:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[getTotalTransactionAmountSUS](@CUSTID int,@TRANSDATE datetime)
returns decimal(10,2) AS
begin
declare @TotalAmount decimal(10,2)

Set @TotalAmount = (
SELECT SUM([TRANSTOTALAMOUNT]) 
  FROM [TRANS]
  where [CUSTID] =@CUSTID
  and TRANSDT >= DATEADD(day,-10,@TRANSDATE)
  )

if @TotalAmount is NULL 
BEGIN
	set @TotalAmount=0
END

return @TotalAmount
end
