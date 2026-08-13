using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DTO
{
  public class DatalogDeliveryDTO
  {
    [Browsable(false)]
    public long Id { get; set; }

    [DisplayName("Stt")]
    public long No { get; set; }

    [DisplayName("Hình thức giao nhận")]
    public string? TypeRange { get; set; }


    [DisplayName("Lệnh sản xuất")]
    public string? PO { get; set; }


    [DisplayName("Bên giao")]
    public string? EmployeeDelivery { get; set; }

    [DisplayName("Bên nhận")]
    public string? EmployeeReceive { get; set; }

    [DisplayName("Chất lượng")]
    public string? EmployeeQC { get; set; }


    [DisplayName("Ngày tạo")]
    public string? CreatedAt { get; set; }

    [Browsable(false)]
    public List<MaterialDeliveryDTO>? MaterialDelivaryDTOs { get; set; }

    [Browsable(false)]
    public string? JsonFill { get; set; }
  }
}
