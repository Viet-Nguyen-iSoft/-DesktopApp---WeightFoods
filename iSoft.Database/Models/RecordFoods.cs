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
  public class RecordFoods:BaseModel
  {
    public double Net { get; set; }
    public double Tare { get; set; }


    #region Mapping
    public long? StationId { get; set; }
    public Station? Station { get; set; }

    public long? EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public long? ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public long? CategoryTareId { get; set; }
    public CategoryTare CategoryTare { get; set; } = null!;

    #endregion
  }

}
