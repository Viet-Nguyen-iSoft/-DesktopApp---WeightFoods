using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class Employee: BaseModel
  {
    public string? FullName { get; set; }
    public string? Code { get; set; }

    public string? Account { get; set; }
    public string? Passwords { get; set; }

    public string? IdCardName { get; set; }
    public string? IdCardCode { get; set; }

    public bool? IsAllowOverWeight { get; set; }


    #region Mapping
    [Browsable(false)]
    public ICollection<RecordFoods>? Recognitions { get; set; }
    public ICollection<Department> Departments { get; set; } = new List<Department>();
    public ICollection<Station> Machines { get; set; } = new List<Station>();

    #endregion
  }
}
