using HSF.Database.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using static HelperManager.EnumData;

namespace iSoft.DatabaseServer.Models
{
  [Table("I_MasterDataWeights")]
  public class MaterialSettingEntity : BaseConnectivityCRUDEntity
  {
    public float? Weight { get; set; }
    public float? Loss { get; set; }
    public float? LossV2 { get; set; }

    public EnumInternalExternalStatus? InternalExternalStatus { get; set; }
    public EnumExportImport? ImportExportStatus { get; set; }

    #region Mapping
    [Browsable(false)]
    public Guid? MaterialId { get; set; }

    [Browsable(false)]
    public MaterialEntity? Material { get; set; }



    [Browsable(false)]
    public Guid? ProductionOrderId { get; set; }

    [Browsable(false)]
    public ProductionOrderEntity? ProductionOrder { get; set; }
    #endregion
  }
}
