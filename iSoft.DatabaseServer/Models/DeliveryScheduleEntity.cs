using HSF.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HelperManager.EnumData;

namespace iSoft.DatabaseServer.Models
{
  [Table("I_DeliverySchedules")]
  public class DeliveryScheduleEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public EnumExportImport? eTypeDeliverySchedule { get; set; }
    public string? TicketCode { get; set; }
    public DateTime? DeliveryTimeMaterial { get; set; }
    public DateTime? DeliveryTimeRawMaterial { get; set; }
    public DateTime? DeliveryTimeSemiFinished { get; set; }
    public DateTime? DeliveryTimeYield { get; set; }

    #endregion

    #region Relations
    public Guid? ProductionOrderId { get; set; }
    public ProductionOrderEntity? ProductionOrder { get; set; } = null!;

    public List<DeliveryScheduleMaterialEntity>? DeliveryScheduleMaterials { get; set; }
    #endregion
  }
}
