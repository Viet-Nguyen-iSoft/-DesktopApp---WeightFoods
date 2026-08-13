using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class CategoryTare:BaseModel
  {
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Value { get; set; } = 0;
    public int? TareGroup { get; set; }

    #region Mapping
    public ICollection<RecordFoods>?  DatalogWeights { get; set; } = new HashSet<RecordFoods>();
    public ICollection<Product>?  Materials { get; set; } = new HashSet<Product>();
    #endregion
  }
}
