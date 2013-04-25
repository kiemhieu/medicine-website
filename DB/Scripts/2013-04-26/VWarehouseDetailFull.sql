USE [Medical]
GO

/****** Object:  View [dbo].[VWarehouseDetailFull]    Script Date: 04/26/2013 02:39:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VWarehouseDetailFull]
AS
SELECT     dbo.WareHouseIO.Date, dbo.WareHouseIO.ClinicId, dbo.WareHouseDetail.Id, dbo.WareHouseDetail.WareHouseId, dbo.WareHouseDetail.WareHouseIODetailId, dbo.WareHouseDetail.MedicineId, 
                      dbo.WareHouseDetail.LotNo, dbo.WareHouseDetail.ExpiredDate, dbo.WareHouseDetail.OriginalVolumn, dbo.WareHouseDetail.CurrentVolumn, dbo.WareHouseDetail.BadVolumn, 
                      dbo.WareHouseDetail.Unit, dbo.WareHouseDetail.UnitPrice, dbo.WareHouseDetail.CreatedDate, dbo.WareHouseDetail.CreatedUser, dbo.WareHouseDetail.LastUpdatedDate, 
                      dbo.WareHouseDetail.LastUpdatedUser, dbo.WareHouseDetail.Version
FROM         dbo.WareHouseDetail LEFT OUTER JOIN
                      dbo.WareHouseIODetail ON dbo.WareHouseDetail.WareHouseIODetailId = dbo.WareHouseIODetail.Id LEFT OUTER JOIN
                      dbo.WareHouseIO ON dbo.WareHouseIO.Id = dbo.WareHouseIODetail.WareHouseIOId

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[28] 4[33] 2[11] 3) )"
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
         Begin Table = "WareHouseDetail"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 118
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WareHouseIODetail"
            Begin Extent = 
               Top = 6
               Left = 262
               Bottom = 118
               Right = 421
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WareHouseIO"
            Begin Extent = 
               Top = 6
               Left = 459
               Bottom = 118
               Right = 611
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
      Begin ColumnWidths = 19
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VWarehouseDetailFull'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VWarehouseDetailFull'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VWarehouseDetailFull'
GO


