using HSF.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSoft.DatabaseServer.Models
{
  [Table("I_Warnings")]
  public class WarningEntity : BaseConnectivityCRUDEntity
  {
    public float? Weight { get; set; }
    public bool? IsConfirmed { get; set; }
    public bool? SyncFlag { get; set; } = false;

    #region Mapping
    public Guid? ProductionOrderId { get; set; }
    public ProductionOrderEntity? ProductionOrder { get; set; } = null!;


    public Guid? ProductId { get; set; }
    public ProductEntity? Product { get; set; } = null!;


    public Guid? MaterialId { get; set; }
    public MaterialEntity? Material { get; set; }
    #endregion
  }
}
