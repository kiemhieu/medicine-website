USE [Medical]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetWareHouseDetailForWareHouseOutput]    Script Date: 04/27/2013 00:59:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetWareHouseDetailForWareHouseOutput] 
	-- Add the parameters for the stored procedure here
	@date DateTime,
	@clinicID int,
	@medicineID int
	
AS
BEGIN
	SELECT     
	TOP (100) PERCENT 
	MedicineId, 
	CASE WHEN LotNo IS NULL THEN '' ELSE LotNo END AS LotNo, 
    ExpiredDate, 
    SUM(CurrentVolumn) AS Qty, 
    0 As Id, 
    0 AS InStockQty, ClinicId
FROM         
	VWarehouseDetailFull
WHERE ClinicId = @clinicID AND ( [Date] Is NULL OR [Date] <= @date) AND MedicineId = @medicineID
GROUP BY MedicineId, LotNo, ExpiredDate, ClinicId
ORDER BY MedicineId, ClinicId, LotNo, ExpiredDate

END


GO


