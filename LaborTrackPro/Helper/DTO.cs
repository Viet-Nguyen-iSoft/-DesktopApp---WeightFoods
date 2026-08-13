using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Database.EnumData;

namespace LaborTrackPro.Helper
{
  public class DTO
  {
    public class GroupData
    {
      public string? NameVI { get; set; }
      public string? NameEN { get; set; }
      public string? PathImage { get; set; }
      public EnumMaterialType? eMaterialType { get; set; }
      public List<Object>? Obj { get; set; }
    }

    public class ItemMaterial
    {
      public Material? Material { get; set; }
      public List<Production>? Productions { get; set; }
    }

    public class MaxValueCheckAlarm
    {
      public EnumStatusCheckAlarm? Status { get; set; } = EnumStatusCheckAlarm.NoneCheck;
      public double? MaxValue { get; set; }

      public double? TotalActualInKg { get; set; }
      public double? SettingInKg { get; set; }
      
      public double? TolerancePerTon { get; set; }
      public double? ToleranceBelowTon { get; set; }
      public bool CheckAlarm { get; set; } = false;
    }

    public enum EnumStatusCheckAlarm
    { 
      Fail = 0,
      Success = 1,
      LossInfor = 2,
      NoneCheck = 3,

    }

    public enum EnumTyCheckAlarm
    {
      None = 0,
      PO_CheBien_Import = 1,
      PO_CheBien_Export,
      PO_CheBien_Import_Internal,
      PO_CheBien_Export_Internal,

      PO_SoChe_Import,
      PO_SoChe_Export,
      PO_SoChe_Import_Internal,
      PO_SoChe_Export_Internal,

    }
  }
}
