using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;

namespace iSoft.Database.Models
{
  public class ProductionOrder:BaseModel
  {
    [DisplayName("Tên")]
    public string? Name { get; set; }
    [DisplayName("Mã")]
    public string? Code { get; set; }

    [DisplayName("Mô tả")]
    public string? Description { get; set; }

    [DisplayName("Hiệu liệu từ")]
    public DateTime? EffectiveFrom { get; set; }
    [DisplayName("Hiệu liệu đến")]
    public DateTime? EffectiveTo { get; set; }

    public DateTime? EffectiveFromExternal { get; set; }
    public DateTime? EffectiveToExternal { get; set; }
    public int? ApproveStatus { get; set; }
    public int? WarningStatus { get; set; }

    public EnumProductionOrderType? ProductionOrderType { get; set; }
    public EnumProductionOrderCategory? ProductionOrderCategory { get; set; }

    public EnumProductionOrderType? eTypeOrderProduction { get; set; } = EnumProductionOrderType.None;
    public EnumProductionOrderCategory? eSubTypeProduction { get; set; } = EnumProductionOrderCategory.None;

    public EnumProcessing? EnumProcessing { get; set; }


    #region Mapping
    [Browsable(false)]
    public ICollection<Production> Productions { get; set; } = new List<Production>();


    [Browsable(false)]
    public ICollection<Material> Materials { get; set; } = new List<Material>();


    [Browsable(false)]
    public ICollection<MaterialSetting> MaterialSettings { get; set; } = new List<MaterialSetting>();
    [Browsable(false)]
    public ICollection<DatalogWeight> DatalogWeights { get; set; } = new List<DatalogWeight>();
    [Browsable(false)]
    public ICollection<DatalogDelivery> DatalogDeliveries { get; set; } = new List<DatalogDelivery>();
    #endregion
  }
}
