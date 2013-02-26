USE [Medical]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetMedicineDeliveryTotal]    Script Date: 02/27/2013 02:54:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetMedicineDeliveryTotal] 
	-- Add the parameters for the stored procedure here
	@clinicId int, 
	@startDate DateTime,
	@endDate DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		MedicineDeliveryDetail.MedicineId,
		SUM(MedicineDeliveryDetail.Volumn) AS Quantity
	FROM 
		MedicineDelivery, MedicineDeliveryDetail 
	WHERE
		MedicineDelivery.Id = MedicineDeliveryDetail.MedicineDeliveryId
		AND MedicineDelivery.ClinicId = @clinicId
		AND MedicineDelivery.CreatedDate >= @startDate
		AND MedicineDelivery.CreatedDate <= @endDate
	GROUP BY MedicineDeliveryDetail.MedicineId
END

GO


