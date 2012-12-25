DECLARE @warehouseId int;
DECLARE @medicineId int;
DECLARE @unitId int;

DECLARE db_cursor CURSOR FOR SELECT id FROM Warehouse 
OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @warehouseId   

WHILE @@FETCH_STATUS = 0   
BEGIN   
       -- SET @warehouseId = 11;
		Select @medicineId = medicineId from WareHouse Where Id = @warehouseId;
		Select @unitId = Unit from Medicine Where Id = @medicineId;

		INSERT INTO [Medical].[dbo].[WareHouseDetail]
		([WareHouseId], [MedicineId], [LotNo], [ExpiredDate], [OriginalVolumn], [CurrentVolumn], [BadVolumn], [Unit], [UnitPrice], [CreatedDate], [CreatedUser], [LastUpdatedDate], [LastUpdatedUser], [Version])
		VALUES (@warehouseId, @medicineId, NULL, '12/12/2014', 10, 10, 0, @unitId, 50000, GETDATE(), 1, GETDATE(), 1, 0);

		INSERT INTO [Medical].[dbo].[WareHouseDetail]
		([WareHouseId], [MedicineId], [LotNo], [ExpiredDate], [OriginalVolumn], [CurrentVolumn], [BadVolumn], [Unit], [UnitPrice], [CreatedDate], [CreatedUser], [LastUpdatedDate], [LastUpdatedUser], [Version])
		VALUES (@warehouseId, @medicineId, 'A', '12/12/2014', 10, 10, 0, @unitId, 50000, GETDATE(), 1, GETDATE(), 1, 0);

		INSERT INTO [Medical].[dbo].[WareHouseDetail]
		([WareHouseId], [MedicineId], [LotNo], [ExpiredDate], [OriginalVolumn], [CurrentVolumn], [BadVolumn], [Unit], [UnitPrice], [CreatedDate], [CreatedUser], [LastUpdatedDate], [LastUpdatedUser], [Version])
		VALUES (@warehouseId, @medicineId, 'B', '12/12/2014', 10, 10, 0, @unitId, 50000, GETDATE(), 1, GETDATE(), 1, 0);

		INSERT INTO [Medical].[dbo].[WareHouseDetail]
		([WareHouseId], [MedicineId], [LotNo], [ExpiredDate], [OriginalVolumn], [CurrentVolumn], [BadVolumn], [Unit], [UnitPrice], [CreatedDate], [CreatedUser], [LastUpdatedDate], [LastUpdatedUser], [Version])
		VALUES (@warehouseId, @medicineId, 'C', '12/12/2014', 10, 10, 0, @unitId, 50000, GETDATE(), 1, GETDATE(), 1, 0);

		INSERT INTO [Medical].[dbo].[WareHouseDetail]
		([WareHouseId], [MedicineId], [LotNo], [ExpiredDate], [OriginalVolumn], [CurrentVolumn], [BadVolumn], [Unit], [UnitPrice], [CreatedDate], [CreatedUser], [LastUpdatedDate], [LastUpdatedUser], [Version])
		VALUES (@warehouseId, @medicineId, 'D', '12/12/2014', 10, 10, 0, @unitId, 50000, GETDATE(), 1, GETDATE(), 1, 0);

		INSERT INTO [Medical].[dbo].[WareHouseDetail]
		([WareHouseId], [MedicineId], [LotNo], [ExpiredDate], [OriginalVolumn], [CurrentVolumn], [BadVolumn], [Unit], [UnitPrice], [CreatedDate], [CreatedUser], [LastUpdatedDate], [LastUpdatedUser], [Version])
		VALUES (@warehouseId, @medicineId, 'E', '12/12/2014', 10, 10, 0, @unitId, 50000, GETDATE(), 1, GETDATE(), 1, 0);

		INSERT INTO [Medical].[dbo].[WareHouseDetail]
		([WareHouseId], [MedicineId], [LotNo], [ExpiredDate], [OriginalVolumn], [CurrentVolumn], [BadVolumn], [Unit], [UnitPrice], [CreatedDate], [CreatedUser], [LastUpdatedDate], [LastUpdatedUser], [Version])
		VALUES (@warehouseId, @medicineId, 'F', '12/12/2014', 10, 10, 0, @unitId, 50000, GETDATE(), 1, GETDATE(), 1, 0);

		INSERT INTO [Medical].[dbo].[WareHouseDetail]
		([WareHouseId], [MedicineId], [LotNo], [ExpiredDate], [OriginalVolumn], [CurrentVolumn], [BadVolumn], [Unit], [UnitPrice], [CreatedDate], [CreatedUser], [LastUpdatedDate], [LastUpdatedUser], [Version])
		VALUES (@warehouseId, @medicineId, 'G', '12/12/2014', 10, 10, 0, @unitId, 50000, GETDATE(), 1, GETDATE(), 1, 0);

		INSERT INTO [Medical].[dbo].[WareHouseDetail]
		([WareHouseId], [MedicineId], [LotNo], [ExpiredDate], [OriginalVolumn], [CurrentVolumn], [BadVolumn], [Unit], [UnitPrice], [CreatedDate], [CreatedUser], [LastUpdatedDate], [LastUpdatedUser], [Version])
		VALUES (@warehouseId, @medicineId, 'H', '12/12/2014', 10, 10, 0, @unitId, 50000, GETDATE(), 1, GETDATE(), 1, 0);

		INSERT INTO [Medical].[dbo].[WareHouseDetail]
		([WareHouseId], [MedicineId], [LotNo], [ExpiredDate], [OriginalVolumn], [CurrentVolumn], [BadVolumn], [Unit], [UnitPrice], [CreatedDate], [CreatedUser], [LastUpdatedDate], [LastUpdatedUser], [Version])
		VALUES (@warehouseId, @medicineId, 'I', '12/12/2014', 10, 10, 0, @unitId, 50000, GETDATE(), 1, GETDATE(), 1, 0);

       FETCH NEXT FROM db_cursor INTO @warehouseId   
END   

CLOSE db_cursor   
DEALLOCATE db_cursor









