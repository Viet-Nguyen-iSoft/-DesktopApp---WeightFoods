using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DTO
{
  public class CategoryTareDTO
  {
    [Browsable(false)]
    public long Id { get; set; }

    [DisplayName("Stt")]
    public long No { get; set; }

    [DisplayName("Tên")]
    public string? Name { get; set; }
    [DisplayName("Giá trị (gam)")]
    public double? Value { get; set; } = 0;


    [DisplayName("Ngày tạo")]
    public string? CreatedAt { get; set; }

    [DisplayName("Cập nhật")]
    public string? UpdateAt { get; set; }
  }
}
