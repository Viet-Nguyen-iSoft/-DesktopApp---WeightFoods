using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;

namespace iSoft.Database.Models
{
  public class DatalogWeight:BaseModel
  {
    public float Net { get; set; }
    public float Tare { get; set; }
    public eTypeRecord eTypeRecord { get; set; } = eTypeRecord.Normal;
    public EnumExportImport eExportImport { get; set; }
    public EnumTypePO EnumTypePO { get; set; }
    public EnumCheckData EnumCheckData { get; set; }
    public bool WasteFlag { get; set; } = false;

    public EnumInternalExternalStatus? InternalExternalStatus { get; set; }
    public long? UserAllowWeightOverId { get; set; }
    public long? MaterialTareId { get; set; }

    #region Mapping
    public long? MachineId { get; set; }
    public Machine? Machine { get; set; }


    public long? EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public long? ProductionOrderId { get; set; }
    public ProductionOrder ProductionOrder { get; set; } = null!;

    public long? ProductionId { get; set; }
    public Production Production { get; set; } = null!;

    public long? MaterialId { get; set; }
    public Material? Material { get; set; }

    public long? MaterialDefectId { get; set; }
    public Material? MaterialDefect { get; set; }

    public long? DatalogDeliveryId { get; set; }
    public DatalogDelivery? DatalogDelivery { get; set; }

    public long? TareCategoryId { get; set; }
    public CategoryTare? TareCategory { get; set; }

    public long? DeliveryScheduleId { get; set; }
    public DeliverySchedule? DeliverySchedule { get; set; }


    #endregion
  }

  public enum eTypeRecord
  {
    Normal = 0,
    Defective = 1
  }

  
}
