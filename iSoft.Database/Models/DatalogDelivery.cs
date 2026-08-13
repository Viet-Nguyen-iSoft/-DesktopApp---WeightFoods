using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class DatalogDelivery : BaseModel
  {
    public int AreaInternalOrExternal { get; set; }
    public string? PathFile { get; set; }
    public string? JsonInforFill { get; set; }
    #region Mapping
    public long? MachineId { get; set; }
    public Machine? Machine { get; set; }

    public long? ProductionOrderId { get; set; }
    public ProductionOrder ProductionOrder { get; set; } = null!;


    [ForeignKey(nameof(EmployeeDeliverId))]
    public long? EmployeeDeliverId { get; set; }
    public Employee? EmployeeDeliver { get; set; }


    [ForeignKey(nameof(EmployeeReceiveId))]
    public long? EmployeeReceiveId { get; set; }
    public Employee? EmployeeReceive { get; set; }


    [ForeignKey(nameof(EmployeeQCId))]
    public long? EmployeeQCId { get; set; }
    public Employee? EmployeeQC { get; set; }

    public long? DeliveryScheduleId { get; set; }
    public DeliverySchedule? DeliverySchedule { get; set; }


    [Browsable(false)]
    public ICollection<DatalogWeight>? DatalogWeights { get; set; } = new HashSet<DatalogWeight>();
    #endregion
  }

}
