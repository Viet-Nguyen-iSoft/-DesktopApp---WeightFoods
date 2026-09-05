using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class ProductGroup : BaseModel
  {
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    #region Mapping
    public ICollection<Product> Products { get; set; } = new List<Product>();
    #endregion
  }
}
