﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.EntitiyExtend;

namespace Medical.Data
{
    /// <summary>
    /// Definication
    /// </summary>
    public class Definication
    {
        public const int ContentUnit = 1;
        public const int Unit = 2;
        public const int MedicinePlanningStatus = 3;
        
    }

    /// <summary>
    /// MedicinePlaningStatus
    /// </summary>
    public class MedicinePlaningStatus
    {
        public const int New = 0;
        public const int Approved = 1;
        public const int NotApproved = 2;
        public const int ReEdited = 3;

        public static List<Item> GetPlanningStatus()
        {
            return new List<Item>(new Item[] {
                                          new Item(0, "Mới"), 
                                          new Item(1, "Duyệt"), 
                                          new Item(2, "Không duyệt"), 
                                          new Item(3, "Đã sửa lại")
                                 });
        }
    }

    /// <summary>
    /// MedicineRoles
    /// </summary>
    public class MedicineRoles
    {
        public const int Admin = 0;
        public const int SupperManager = 1;
        public const int Doctor = 2;
        public const int Pharmacists = 3;
    }

    /// <summary>
    /// WarehouseIOType
    /// </summary>
    public class WarehouseIOType
    {
        public const String Input = "I";
        public const String Output = "O";
    }

    /// <summary>
    /// Role
    /// </summary>
    public class Role
    {
        public const int Administrator = 0;
        public const int Doctor = 1;
        public const int Pharmacist = 2;
        public const int Manager = 3;

    }
}
