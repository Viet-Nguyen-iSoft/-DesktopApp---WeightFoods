using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Database.EnumData;

namespace iSoft.Database.Models
{
  public class RecordTruck : BaseModel
  {
    public string? NoLabelAuto { get; set; }
    public string? NoLabelManual { get; set; }

    public double NetTimeTemp { get; set; } = 0.0;
    public double TareTimeTemp { get; set; } = 0.0;
    public double NetTime01 { get; set; } = 0.0;
    public double TareTime01 { get; set; } = 0.0;
    public double NetTime02 { get; set; } = 0.0;
    public double TareTime02 { get; set; } = 0.0;
    public EnumTypeDataTruck EnumTypeDataTruck { get; set; } = EnumTypeDataTruck.None;

    public string? NameDriver { get; set; }
    public string? IdCard { get; set; }
    public string? LicensePlate { get; set; }
    public string? Document { get; set; }

    #region Mapping
    public long? ClientId { get; set; }
    public Client? Client { get; set; }

    public long? TypeGoodsId { get; set; }
    public TypeGoods? TypeGoods { get; set; }

    public long? WarehouseId { get; set; }
    public Warehouse? Warehouse { get; set; }
    #endregion
  }
}
