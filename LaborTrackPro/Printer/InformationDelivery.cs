using iSoft.Database.DTO;
using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.Helper.DTO;

namespace LaborTrackPro.Printer
{
  public class InformationDelivery
  {
    public EnumExportImport? EnumExportImport { get;set; }
    public EnumInternalExternalStatus? EnumInternalExternal { get; set; }
    [JsonIgnore]
    //public ProductionOrder? ProductionOrder { get;set; }
    public string? PO { get;set; }
    public DateTime Datetime { get;set; }
    [JsonIgnore]
    public Employee? DeliveryEmployee { get;set; }
    [JsonIgnore]
    public Employee? ReceivingEmployee { get;set; }
    [JsonIgnore]
    public Employee? QCEmployee { get;set; }
    public string[]? DepartmentList { get; set; }

    [JsonIgnore]
    public List<RecordWeight>? LaborProductivityRecognitions { get; set; }

    [JsonIgnore]
    public Station? Machine { get; set; }


    [JsonIgnore]
    public Product? Material { get; set; }

    //[JsonIgnore]
    //public MaxValueCheckAlarm? MaxValueCheckAlarm { get; set; }

    [JsonIgnore]
    public EnumTyCheckAlarm? EnumTyCheckAlarm { get; set; }
    [JsonIgnore]
    public bool? IsCheckAlarm { get; set; }
  }

  public class RecordDelivery
  {
    public double ValueNet { get; set; }



    public bool IsInternal { get; set; } = true;
    public string? PO { get; set; }
    public DateTime Datetime { get; set; }
    public string? DeliveryDepartment { get; set; }
    public string? DeliveryName { get; set; }
    public string? ReceivingDepartment { get; set; }
    public string? ReceivingName { get; set; }
    public string? QCName { get; set; }
    public string[]? DepartmentList { get; set; }
  }
}
