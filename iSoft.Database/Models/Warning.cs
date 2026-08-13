using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class Warning : BaseModel
  {
    public float? Weight { get; set; }
    public bool? IsConfirmed { get; set; }


    #region Mapping
    [Browsable(false)]
    public long? ProductionOrderId { get; set; }

    [Browsable(false)]
    public ProductionOrder? ProductionOrder { get; set; }



    [Browsable(false)]
    public long? ProductionId { get; set; }

    [Browsable(false)]
    public Production? Production { get; set; }



    [Browsable(false)]
    public long? MaterialId { get; set; }

    [Browsable(false)]
    public Material? Material { get; set; }
    #endregion

  }
}
