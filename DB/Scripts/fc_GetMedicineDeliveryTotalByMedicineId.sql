USE [Medical]
GO

/****** Object:  UserDefinedFunction [dbo].[fc_GetMedicineDeliveryTotalByMedicineId]    Script Date: 04/12/2013 14:29:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fc_GetMedicineDeliveryTotalByMedicineId] 
(
	@clinicId int, 
	@medicineId int,
	@createDate DateTime
)
RETURNS int
AS
BEGIN
	declare @sum as int
	set @sum = (
			SELECT 
				SUM(MedicineDeliveryDetail.Volumn) 
			FROM 
				MedicineDelivery, MedicineDeliveryDetail 
			WHERE
				MedicineDelivery.Id = MedicineDeliveryDetail.MedicineDeliveryId
				AND MedicineDelivery.ClinicId = @clinicId
				AND MedicineDelivery.CreatedDate >= @createDate
				AND MedicineDelivery.CreatedDate < @createDate + 1
				and MedicineDeliveryDetail.MedicineId = @medicineId
			)
	return isnull(@sum,0)	

END

GO

