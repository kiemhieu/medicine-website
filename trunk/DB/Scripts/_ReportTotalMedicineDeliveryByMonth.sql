USE [Medical]
GO

/****** Object:  Table [dbo].[_ReportTotalMedicineDeliveryByMonth]    Script Date: 04/12/2013 14:27:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[_ReportTotalMedicineDeliveryByMonth](
	[ClinicId] [int] NOT NULL,
	[MedicineId] [int] NOT NULL,
	[YearMonth] [int] NOT NULL,
	[MedicineName] [varchar](200) NULL,
	[Qty1] [int] NULL,
	[Qty2] [int] NULL,
	[Qty3] [int] NULL,
	[Qty4] [int] NULL,
	[Qty5] [int] NULL,
	[Qty6] [int] NULL,
	[Qty7] [int] NULL,
	[Qty8] [int] NULL,
	[Qty9] [int] NULL,
	[Qty10] [int] NULL,
	[Qty11] [int] NULL,
	[Qty12] [int] NULL,
	[Qty13] [int] NULL,
	[Qty14] [int] NULL,
	[Qty15] [int] NULL,
	[Qty16] [int] NULL,
	[Qty17] [int] NULL,
	[Qty18] [int] NULL,
	[Qty19] [int] NULL,
	[Qty20] [int] NULL,
	[Qty21] [int] NULL,
	[Qty22] [int] NULL,
	[Qty23] [int] NULL,
	[Qty24] [int] NULL,
	[Qty25] [int] NULL,
	[Qty26] [int] NULL,
	[Qty27] [int] NULL,
	[Qty28] [int] NULL,
	[Qty29] [int] NULL,
	[Qty30] [int] NULL,
	[Qty31] [int] NULL,
	[QtyTC] [int] NULL
 CONSTRAINT [PK__ReportTotalMedicineDeliveryByMonth] PRIMARY KEY CLUSTERED 
(
	[ClinicId] ASC,
	[MedicineId] ASC,
	[YearMonth] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


