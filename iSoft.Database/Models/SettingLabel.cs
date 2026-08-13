using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class SettingLabel : BaseModel
  {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? NumberCopy { get; set; } = 1;
    public eTypeLabel eTypeLabel { get; set; }
  }

  public enum eTypeLabel
  {
    None = 0,
    Weight,
    Delivery
  }
}
