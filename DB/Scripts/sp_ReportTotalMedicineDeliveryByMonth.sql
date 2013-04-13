USE [Medical]
GO
/****** Object:  StoredProcedure [dbo].[sp_ReportTotalMedicineDeliveryByMonth]    Script Date: 04/13/2013 15:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER Proc [dbo].[sp_ReportTotalMedicineDeliveryByMonth]
@ClinicId as int,
@Month as datetime
AS
BEGIN
	-- Khai bao ngay dau thang, cuoi thang	
	Declare @NgayDauThang as datetime =CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@Month)-1),@Month),101) 
	Declare @NgayCuoiThang as datetime =  CONVERT(VARCHAR(25),DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@Month)+1, 0)),101)
	
	
	
	-- tao YearMonth xem bao cao
	Declare @YearMonth as int
	if MONTH(@month) < 10
		set @YearMonth =  CAST((cast(YEAR(@Month) as varchar(4)) + '0' +  cast(MONTH(@Month) as varchar(2))) as int)
	else
		set @YearMonth =  CAST((cast(YEAR(@Month) as varchar(4)) + cast(MONTH(@Month) as varchar(2))) as int)

	-- Xoa du lieu bao cao cu
	delete _ReportTotalMedicineDeliveryByMonth 
	where ClinicId = @ClinicId and YearMonth = @YearMonth
	
	
	-- innsert medicineId phat trong thang	
	insert into _ReportTotalMedicineDeliveryByMonth(ClinicId,MedicineID,YearMonth)
	select distinct @ClinicId,mddetail.MedicineId, @YearMonth  from MedicineDeliveryDetail mddetail
	inner join MedicineDelivery md on md.Id= mddetail.MedicineDeliveryId
	where md.ClinicId = @ClinicId
	and md.CreatedDate between @NgayDauThang and @NgayCuoiThang
	
	
	-- Update MedicineName
	Update _ReportTotalMedicineDeliveryByMonth
	set MedicineName = Medicine.Name
	from _ReportTotalMedicineDeliveryByMonth
	inner join Medicine on Medicine.Id = _ReportTotalMedicineDeliveryByMonth.MedicineId
	where ClinicId=@ClinicId
	and YearMonth = @YearMonth
	
	-- Update Sum Volumn on day
	
	Update _ReportTotalMedicineDeliveryByMonth
	set Qty1 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang),
	Qty2 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+1),
	Qty3 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+2),
	Qty4 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+3),
	Qty5 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+4),
	Qty6 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+5),
	Qty7 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+6),
	Qty8 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+7),
	Qty9 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+8),
	Qty10 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+9),
	Qty11 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+10),
	Qty12 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+11),					
	Qty13 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+12),
	Qty14 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+13),
	Qty15 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+14),
	Qty16 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+15),
	Qty17 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+16),
	Qty18 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+17),
	Qty19 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+18),
	Qty20 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+19),
	Qty21 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+20),
	Qty22 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+21),
	Qty23 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+22),
	Qty24 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+23),
	Qty25 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+24),
	Qty26 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+25),
	Qty27 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+26),
	Qty28 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+27)
	where Clinicid = @ClinicId and YearMonth = @YearMonth
	
	if @NgayCuoiThang >= @NgayDauThang + 28
	update _ReportTotalMedicineDeliveryByMonth
	set	Qty29 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+28)
	where Clinicid = @ClinicId and YearMonth = @YearMonth
	
	if @NgayCuoiThang >= @NgayDauThang + 29
	update _ReportTotalMedicineDeliveryByMonth
	set Qty30 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+29)
	where Clinicid = @ClinicId and YearMonth = @YearMonth
	
	if @NgayCuoiThang = @NgayDauThang + 30
	update _ReportTotalMedicineDeliveryByMonth
	set Qty31 = dbo.fc_GetMedicineDeliveryTotalByMedicineId(@ClinicId,_ReportTotalMedicineDeliveryByMonth.MedicineId,@NgayDauThang+30)
	where Clinicid = @ClinicId and YearMonth = @YearMonth
	
	-- Update QTyTC
	Update _ReportTotalMedicineDeliveryByMonth
	set QTyTC = isnull(Qty1,0) + isnull(Qty2,0) + isnull(Qty3,0) + isnull(Qty4,0) + isnull(Qty5,0) + isnull(Qty6,0) + isnull(Qty7,0) + isnull(Qty8,0) + isnull(Qty9,0)
				 + isnull(Qty10,0) + isnull(Qty11,0) + isnull(Qty12,0) + isnull(Qty13,0) + isnull(Qty14,0) + isnull(Qty15,0) + isnull(Qty16,0) + isnull(Qty17,0) + isnull(Qty18,0) + isnull(Qty19,0) 
				 + isnull(Qty20,0) + isnull(Qty21,0) + isnull(Qty22,0) + isnull(Qty23,0) + isnull(Qty24,0) + isnull(Qty25,0) + isnull(Qty26,0) + isnull(Qty27,0) + isnull(Qty28,0) + isnull(Qty29,0) 
				 + isnull(Qty30,0) + isnull(Qty31,0)
	where Clinicid = @ClinicId and YearMonth = @YearMonth
	
	-- Export data to report
	select  cast(ROW_NUMBER() OVER(ORDER BY a.MedicineId asc) as int) AS STT, a.*, b.Name ClinicName from _ReportTotalMedicineDeliveryByMonth a
	inner join Clinic b on a.ClinicId = b.Id
	where Clinicid = @ClinicId and YearMonth = @YearMonth
	ORDER BY STT asc
	
END
