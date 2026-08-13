using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class MaterialGroup : BaseModel
  {
    public string? Name { get; set; }
    public int? MaterialType { get; set; }
    public string? TypeName { get; set; }
    public long? MaterialGroupParentId { get; set; }

    #region Mapping
    public MaterialGroup? MaterialGroupParent { get; set; }
    public ICollection<MaterialGroup> MaterialGroupChildren { get; set; }
        = new List<MaterialGroup>();


    public ICollection<Material> Materials { get; set; } = new List<Material>();
    #endregion
  }
}
