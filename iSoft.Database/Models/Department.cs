using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HelperManager.EnumData;

namespace iSoft.Database.Models
{
  public class Department : BaseModel
  {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public EnumGroup EnumGroup { get; set; }

    #region Mapping
    [Browsable(false)]
    public ICollection<Employee>? Employees { get; set; } = new List<Employee>();
    #endregion
  }
}
