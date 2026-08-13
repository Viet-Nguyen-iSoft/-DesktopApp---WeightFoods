using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  [Table("MaterialTares")]
  public class MaterialTare : BaseModel
  {
    public long? MaterialId { get; set; }
    public long? MaterialSubId { get; set; }

    public Guid? MaterialSrcId { get; set; }
    public Guid? MaterialSubSrcId { get; set; }

    public string? SerialCode { get; set; }
  }
}
