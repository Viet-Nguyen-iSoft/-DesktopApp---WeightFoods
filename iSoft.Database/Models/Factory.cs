using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class Factory:BaseModel
  {
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }

    #region Mapping
    [Browsable(false)]
    public ICollection<Machine>? Machines { get; set; } = new List<Machine>();


    //[Browsable(false)]
    //public ICollection<ProductionOrder>? OrderProducts { get; set; }
    #endregion
  }
}
