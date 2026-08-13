using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class Production : BaseModel
  {
    [DisplayName("Tên")]
    public string? Name { get; set; }
    [DisplayName("Mã")]
    public string? Code { get; set; }

    [DisplayName("Mô tả")]
    public string? Description { get; set; }

    [Browsable(false)]
    public string? PathImage { get; set; }

    #region Mapping
    public ICollection<Material> Materials { get; set; } = new List<Material>();
    public ICollection<ProductionOrder> ProductionOrders { get; set; } = new List<ProductionOrder>();
    public ICollection<DatalogWeight> DatalogWeights { get; set; } = new List<DatalogWeight>();
    #endregion

  }
}
