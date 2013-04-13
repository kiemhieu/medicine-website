alter proc ReportMedicineIOByMonth
@ClinicId as int,
@Month as datetime	
as 
begin
	declare @NgayDauKy as datetime
	set @NgayDauKy = DATEADD(dd, 0, DATEDIFF(dd, 0, DATEADD(dd,-(DAY(@Month)-1),@Month)))
	
	declare @NgayCuoiKy as datetime
	set @NgayCuoiKy = DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@Month)+1, 0))
	
	--if @NgayCuoiKy > GETDATE() 
	--begin
	--	set @ngayCuoiKy = GETDATE()
	--end	
	
	-- Delete 
	Delete from _ReportMedicineIOByMonth where ClinicId = @ClinicId and MonthYear = @Month
	
	-- Insert MedicineId
	insert into _ReportMedicineIOByMonth(ClinicId,MedicineId,MonthYear,MedicineVolumn)
	select distinct @ClinicId, MedicineId,@Month,Volumn from WareHouse
	where ClinicId = @ClinicId
 
	-- Update Medicine Name, Unit, Volumn
	update _ReportMedicineIOByMonth
	set MedicineName = Medicine.Name,
	MedicineUnit = Medicine.Unit,
	MedicineVolumn = Medicine.Content
	from _ReportMedicineIOByMonth
	inner join Medicine on _ReportMedicineIOByMonth.MedicineId = Medicine.Id
	where _ReportMedicineIOByMonth.ClinicId = @ClinicId

	
	-- Update Medicine Price
	update _ReportMedicineIOByMonth
	set MedicineUnitPriceId = (select top 1 ID from MedicineUnitPrice a where a.MedicineId = _ReportMedicineIOByMonth.MedicineId
				and @Month between a.StartDate and ISNULL(a.EndDate,'4000-01-01')  Order by EndDate desc)
				
	-- Update UnitPrice
	update _ReportMedicineIOByMonth
	set MedicineUnitPrice = MedicineUnitPrice.UnitPrice,
	MedicinePrice = MedicineVolumn * MedicineUnitPrice.UnitPrice
	from _ReportMedicineIOByMonth
	inner join MedicineUnitPrice on _ReportMedicineIOByMonth.MedicineId = MedicineUnitPrice.Id
	
	--	Update MedicineInput
	Update _ReportMedicineIOByMonth
	set MedicineInputVolumn = (select SUM(whIODetail.Qty) from WareHouseIO whIO inner join WareHouseIODetail whIODetail on whIO.Id = whIODetail.WareHouseIOId 
								where  _ReportMedicineIOByMonth.ClinicId = whIO.ClinicId
									and whIO.ClinicId = @ClinicId
									and _ReportMedicineIOByMonth.MedicineId = whIODetail.MedicineId
									and whIO.Date between @NgayDauKy and @ngayCuoiKy 
									and whIO.Type = '0'),
	
	MedicineInputPrice = (select SUM(whIODetail.Amount) from WareHouseIO whIO inner join WareHouseIODetail whIODetail on whIO.Id = whIODetail.WareHouseIOId 
								where _ReportMedicineIOByMonth.ClinicId = whIO.ClinicId
									and whIO.ClinicId = @ClinicId
									and _ReportMedicineIOByMonth.MedicineId = whIODetail.MedicineId
									and whIO.Date between @NgayDauKy and @ngayCuoiKy 
									and whIO.Type = '0'),
	SumVolumnInput = (select SUM(whIODetail.Qty) from WareHouseIO whIO inner join WareHouseIODetail whIODetail on whIO.Id = whIODetail.WareHouseIOId 
								where _ReportMedicineIOByMonth.ClinicId = whIO.ClinicId
									and _ReportMedicineIOByMonth.MedicineId = whIODetail.MedicineId
									and whIO.Date <= @ngayCuoiKy 
									and whIO.Type = '0')
																
	--	Update MedicineOutput
	Update _ReportMedicineIOByMonth
	set MedicineOutputVolumn = (select SUM(whIODetail.Qty) from WareHouseIO whIO inner join WareHouseIODetail whIODetail on whIO.Id = whIODetail.WareHouseIOId 
								where _ReportMedicineIOByMonth.ClinicId = whIO.ClinicId
									and whIO.ClinicId = @ClinicId
									and _ReportMedicineIOByMonth.MedicineId = whIODetail.MedicineId
									and whIO.Date between @NgayDauKy and @ngayCuoiKy 
									and whIO.Type = '1'),
	
	MedicineOutputPrice = (select SUM(whIODetail.Amount) from WareHouseIO whIO inner join WareHouseIODetail whIODetail on whIO.Id = whIODetail.WareHouseIOId 
								where _ReportMedicineIOByMonth.ClinicId = whIO.ClinicId
									and whIO.ClinicId = @ClinicId
									and _ReportMedicineIOByMonth.MedicineId = whIODetail.MedicineId
									and whIO.Date between @NgayDauKy and @ngayCuoiKy 
									and whIO.Type = '1'),	
	
	 SumVolumnOutput = (select SUM(whIODetail.Qty) from WareHouseIO whIO inner join WareHouseIODetail whIODetail on whIO.Id = whIODetail.WareHouseIOId 
								where _ReportMedicineIOByMonth.ClinicId = whIO.ClinicId
									and whIO.ClinicId = @ClinicId
									and _ReportMedicineIOByMonth.MedicineId = whIODetail.MedicineId
									and whIO.Date <= @ngayCuoiKy 
									and whIO.Type = '1')
									
	select * from 	_ReportMedicineIOByMonth where ClinicId = @ClinicId and MonthYear = @Month														
end


