using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DTO
{
  public class DatalogPOGroupDTO
  {
    [DisplayName("Stt")]
    public long? No { get; set; }


    [DisplayName("Khoảng thời gian")]
    public string? RangeTime { get; set; }

    [DisplayName("Lệnh sản xuất")]
    public string? ProductionOrder { get; set; }
    //[DisplayName("Loại vật tư")]
    //public string? MaterialType { get; set; }
    //[DisplayName("Nhóm vật tư")]
    //public string? MaterialGroup { get; set; }

    //[DisplayName("Tên vật tư")]
    //public string? MaterialName { get; set; }

    [DisplayName("Tổng khối lượng (Kg)")]
    public float Total { get; set; }

    [DisplayName("Thời gian")]
    [Browsable(false)]
    public string? Time  { get; set; }
  }
}
