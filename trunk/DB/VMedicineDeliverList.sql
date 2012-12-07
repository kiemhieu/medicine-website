USE [Medical]
GO

/****** Object:  View [dbo].[VMedicineDeliverList]    Script Date: 12/08/2012 02:52:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VMedicineDeliverList]
AS
SELECT     dbo.Prescription.Id, dbo.Prescription.ClinicId, dbo.Prescription.PatientId, dbo.Prescription.DoctorId, dbo.Prescription.Date, dbo.Prescription.RecheckDate, 
                      dbo.MedicineDelivery.Id AS DeliverId, dbo.MedicineDelivery.Date AS DeliverDate, dbo.MedicineDelivery.CreatedDate AS DeliverTime, 
                      dbo.[User].Name AS DoctorName, dbo.Prescription.CreatedDate AS CheckTime
FROM         dbo.Prescription INNER JOIN
                      dbo.[User] ON dbo.Prescription.DoctorId = dbo.[User].Id LEFT OUTER JOIN
                      dbo.MedicineDelivery ON dbo.Prescription.Id = dbo.MedicineDelivery.PrescriptionId

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[35] 4[28] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Prescription"
            Begin Extent = 
               Top = 35
               Left = 44
               Bottom = 272
               Right = 192
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "MedicineDelivery"
            Begin Extent = 
               Top = 8
               Left = 584
               Bottom = 218
               Right = 784
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 126
               Left = 319
               Bottom = 337
               Right = 483
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1440
         Table = 1695
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VMedicineDeliverList'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VMedicineDeliverList'
GO

