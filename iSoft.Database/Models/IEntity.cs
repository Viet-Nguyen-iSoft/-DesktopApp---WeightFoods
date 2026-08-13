using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public interface IEntity
  {
    [DisplayName("ID")]
    public abstract long Id { get; set; }

    [DisplayName("Mô tả")]
    public abstract string Description { get; set; }

    [DisplayName("Ngày tạo")]
    public abstract DateTime? Created { get; set; }
    [Browsable(false)]
    public abstract DateTime? Inserted { get; set; }

    [DisplayName("Cập nhật")]
    public abstract DateTime? Updated { get; set; }

    [Browsable(false)]
    public abstract bool IsDeleted { get; set; }
  }
}
