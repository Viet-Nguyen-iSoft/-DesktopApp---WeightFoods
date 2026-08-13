using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DTO
{
  public class ProductionDTO
  {
    [DisplayName("Stt")]
    public int? No { get; set; }


    [DisplayName("Tên")]
    public string? Name { get; set; }


    [DisplayName("Mã")]
    public string? Code { get; set; }



    [DisplayName("Số nguyên liệu - vật tư")]
    public int MaterialNumbers { get; set; } = 0;



    [DisplayName("Mô tả")]
    public string? Description { get; set; }


    [DisplayName("Ngày tạo")]
    public string? CreatedAt { get; set; }

    [DisplayName("Cập nhật")]
    public string? UpdatedAt { get; set; }


    [Browsable(false)]
    public long? Id { get; set; }
  }
}
