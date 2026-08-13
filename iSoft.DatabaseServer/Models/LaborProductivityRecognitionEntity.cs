using iSoft.Database.Models;
using iSoft.DatabaseServer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;

namespace HSF.Database.Entities
{
  [Table("I_LaborProductivityRecognitions")]
  public class LaborProductivityRecognitionEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public float Net { get; set; }
    public float Tare { get; set; }
    public EnumMaterialType eTypeMaterial { get; set; }
    public EnumCheckData CheckData { get; set; }
    public int? ImportExportStatus { get; set; }
    public bool WasteFlag { get; set; }
    public long? IdSrc { get; set; }


    public EnumInternalExternalStatus? InternalExternalStatus { get; set; }
    public Guid? UserAllowWeightOverId { get; set; }
    #endregion

    #region Relations
    public Guid? DataMachineId { get; set; }
    public MachineEntity? DataMachine { get; set; }


    public Guid? UserId { get; set; }
    public UserEntity? User { get; set; }


    public Guid? ProductionOrderId { get; set; }
    public ProductionOrderEntity? ProductionOrder { get; set; } = null!;

    public Guid? ProductId { get; set; }
    public ProductEntity? Product { get; set; } = null!;


    public Guid? MaterialId { get; set; }
    public MaterialEntity? Material { get; set; }

    public Guid? MaterialLossId { get; set; }
    public MaterialEntity? MaterialLoss { get; set; }


    public Guid? WeightTicketId { get; set; }
    public WeightTicketEntities? WeightTicket { get; set; }

    public Guid? TareCategoryId { get; set; }
    public TareCategoryEntity? TareCategory { get; set; }

    public Guid? MaterialTareId { get; set; }
    public Guid? DeliveryScheduleId { get; set; }

    #endregion
  }
}
