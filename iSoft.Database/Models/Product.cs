using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class Product : BaseModel
  {
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }


    #region Mapping
    public Guid? ProductGroupId { get; set; }
    public ProductGroup? ProductGroup { get; set; }

    public ICollection<RecordWeight>? RecordWeights { get; set; }
    #endregion
  }



}
