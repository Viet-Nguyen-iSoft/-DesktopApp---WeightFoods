using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HelperManager.EnumData;

namespace iSoft.Database.Models
{
  public class MaterialSetting : BaseModel
  {
    public float? Setting { get; set; }
    public float? Loss { get; set; }
    public EnumInternalExternalStatus? InternalExternalStatus { get; set; }
    public EnumExportImport? ImportExportStatus { get; set; }


    #region Mapping

    [Browsable(false)]
    public long? MaterialId { get; set; }

    [Browsable(false)]
    public Material? Material { get; set; }


    [Browsable(false)]
    public long? ProductionOrderId { get; set; }

    [Browsable(false)]
    public ProductionOrder? ProductionOrder { get; set; }
    #endregion
  }
}
