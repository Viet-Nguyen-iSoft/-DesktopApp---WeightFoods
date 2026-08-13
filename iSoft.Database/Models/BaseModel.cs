using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class BaseModel
  {
    [Browsable(false)]
    [DisplayName("Id")]
    public long Id { get; set; }


    [DisplayName("Ngày tạo")]
    public DateTime? CreatedAt { get; set; } 
    [DisplayName("Tạo bởi")]
    public long? CreatedBy { get; set; }



    [DisplayName("Cập nhật")]
    public DateTime? UpdatedAt { get; set; }
    [DisplayName("Cập nhật")]
    public long? UpdatedBy { get; set; }



    [Browsable(false)]
    public bool DeletedFlag { get; set; } = false;

    [Browsable(false)]
    public bool EnableFlag { get; set; }

    [Browsable(false)]
    public bool SyncFlag { get; set; } = false ;
    [Browsable(false)]
    public Guid? IdSrc { get; set; }
  }
}
