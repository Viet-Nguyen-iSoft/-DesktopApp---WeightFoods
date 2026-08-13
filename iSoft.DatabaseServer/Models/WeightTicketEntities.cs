using HSF.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSoft.DatabaseServer.Models
{
  [Table("I_WeightTickets")]
  public class WeightTicketEntities : BaseConnectivityCRUDEntity
  {
    #region Properties
    public string? Name { get; set; }
    public EnumWeightTicketType? TypeWeight { get; set; }
    public bool? IsAccept { get; set; } = true;
    public string? Reason { get; set; }
    public long? IdSrc { get; set; }
    #endregion


    #region Relations
    public Guid? ProductionOrderId { get; set; }
    public ProductionOrderEntity ProductionOrder { get; set; } = null!;


    public Guid? UserQCId { get; set; }
    public UserEntity? UserQC { get; set; }


    public Guid? UserDeliverId { get; set; }
    public UserEntity? UserDeliver { get; set; }


    public Guid? UserReceiveId { get; set; }
    public UserEntity? UserReceive { get; set; }


    public Guid? DataMachineId { get; set; }
    public MachineEntity? DataMachine { get; set; }

    public Guid? DeliveryScheduleId { get; set; }


    public List<LaborProductivityRecognitionEntity>? LaborProductivityRecognitionEntities { get; set; } = new List<LaborProductivityRecognitionEntity>();
    #endregion
  }

  public enum EnumWeightTicketType
  {
    In = 1,
    Out = 2,
  }
}
