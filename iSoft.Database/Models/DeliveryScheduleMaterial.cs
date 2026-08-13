using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class DeliveryScheduleMaterial : BaseModel
  {
    #region Properties
    public double? Weight { get; set; }
    public double? Quantity { get; set; }
    #endregion


    #region Relations
    public long? DeliveryScheduleId { get; set; }
    public DeliverySchedule? DeliverySchedule { get; set; } = null!;

    public long? MaterialId { get; set; }
    public Material? Material { get; set; } = null!;
    #endregion
  }
}
