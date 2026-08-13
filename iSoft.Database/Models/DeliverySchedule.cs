using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HelperManager.EnumData;

namespace iSoft.Database.Models
{
  public class DeliverySchedule : BaseModel
  {
    #region Properties
    public EnumExportImport? ImportExport { get; set; }
    public string? TicketCode { get; set; }
    public DateTime? DeliveryTimeMaterial { get; set; }
    public DateTime? DeliveryTimeRawMaterial { get; set; }
    public DateTime? DeliveryTimeSemiFinished { get; set; }
    public DateTime? DeliveryTimeYield { get; set; }

    #endregion

    #region Relations
    public long? ProductionOrderId { get; set; }
    public ProductionOrder? ProductionOrder { get; set; } = null!;

    public List<DeliveryScheduleMaterial>? DeliveryScheduleMaterials { get; set; }
    #endregion
  }
}
