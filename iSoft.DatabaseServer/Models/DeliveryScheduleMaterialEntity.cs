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
  [Table("I_DeliveryScheduleMaterials")]
  public class DeliveryScheduleMaterialEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public double? Weight { get; set; }
    public double? Quantity { get; set; }
    #endregion

    #region Relations
    public Guid? DeliveryScheduleId { get; set; }
    public DeliveryScheduleEntity? DeliverySchedule { get; set; } = null!;

    public Guid? MaterialId { get; set; }
    public MaterialEntity? Material { get; set; } = null!;
    #endregion
  }
}
