using iSoft.Database;
using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Database.EnumData;

namespace ApiSyncData.Record
{
  public class RecordTruckSync
  {
    public Guid Id { get; set; }
    public string? NoLabelAuto { get; set; }
    public string? NoLabelManual { get; set; }
    public double NetTime01 { get; set; } = 0.0;
    public double NetTime02 { get; set; } = 0.0;
    public EnumTypeDataTruck EnumTypeDataTruck { get; set; } = EnumTypeDataTruck.None;

    public string? NameDriver { get; set; }
    public string? IdCard { get; set; }
    public string? LicensePlate { get; set; }
    public string? Document { get; set; }
    public Guid? StationId { get; set; }
    public Guid? ClientId { get; set; }
    public Guid? TypeGoodsId { get; set; }
    public Guid? WarehouseId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
  }
}
