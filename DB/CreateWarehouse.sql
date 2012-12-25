INSERT INTO [Medical].[dbo].[WareHouse]
           ([ClinicId]
           ,[MedicineId]
           ,[Volumn]
           ,[MinAllowed]
           ,[LastUpdatedUser]
           ,[LastUpdatedDate]
           ,[Version])
SELECT 1, Id, 100, 0, 1, GETDATE(), 0 FROM Medicine
GO


