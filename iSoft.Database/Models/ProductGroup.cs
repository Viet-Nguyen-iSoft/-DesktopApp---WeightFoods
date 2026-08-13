using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class ProductGroup : BaseModel
  {
    public string? Name { get; set; }
    public int? MaterialType { get; set; }
    public string? TypeName { get; set; }
    public long? MaterialGroupParentId { get; set; }

    #region Mapping
    public ProductGroup? MaterialGroupParent { get; set; }
    public ICollection<ProductGroup> MaterialGroupChildren { get; set; }
        = new List<ProductGroup>();


    public ICollection<Product> Materials { get; set; } = new List<Product>();
    #endregion
  }
}
