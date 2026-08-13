using iSoft.DatabaseServer.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;

namespace HSF.Database.Entities
{
  [Table("I_ProductionOrders")]
  public class ProductionOrderEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public string? Name { get; set; }
    //public EnumTypeProductionOrder? eTypeProductionOrder { get; set; }
    public DateTime? EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
    public DateTime? EffectiveFromExternal { get; set; }
    public DateTime? EffectiveToExternal { get; set; }
    //public eSubTypeProductionOrder? eSubTypeProductionOrder { get; set; }
    public int? ApproveStatus { get; set; }
    public int? WarningStatus { get; set; }

    public EnumProductionOrderType? ProductionOrderType { get; set; }
    public EnumProductionOrderCategory? ProductionOrderCategory { get; set; }

    public bool? IsProcessing { get; set; }

    #endregion


    #region Relations
    public List<ProductEntity> Productions { get; set; } = new List<ProductEntity>();
    public List<MaterialEntity>  Materials { get; set; } = new List<MaterialEntity>();
    public List<MaterialSettingEntity> MaterialSettings  { get; set; } = new List<MaterialSettingEntity>();
    public List<LaborProductivityRecognitionEntity> Recognitions { get; set; } = new List<LaborProductivityRecognitionEntity>();
    public List<WeightTicketEntities>? WeightTickets { get; set; } = new List<WeightTicketEntities>();
    public List<WarningEntity>? Warnings { get; set; } = new List<WarningEntity>();
    #endregion
  }

  
}
