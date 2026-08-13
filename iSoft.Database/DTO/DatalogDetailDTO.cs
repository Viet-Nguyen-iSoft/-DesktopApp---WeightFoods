using iSoft.Database.Models;
using System.ComponentModel;

namespace iSoft.Database.DTO
{
  public class DatalogDetailDTO
  {
    [Browsable(false)]
    public long Id { get; set; }

    [Browsable(false)]
    public DatalogWeight? DatalogWeight{ get; set; }


    [DisplayName("Stt")]
    public long? No { get; set; }

    [DisplayName("Lệnh sản xuất")]
    public string? ProductionOrder { get; set; }

    [DisplayName("Nhóm")]
    public string? MaterialGroup { get; set; }
    [DisplayName("Loại vật tư")]
    public string? MaterialType { get; set; }
    [DisplayName("Tên vật tư")]
    public string? MaterialName { get; set; }
    [DisplayName("Gross (kg)")]
    public float Gross { get; set; }
    [DisplayName("Net (kg)")]
    public float Net { get; set; }
    [DisplayName("Tare (kg)")]
    public float Tare { get; set; }
    [DisplayName("Người cân")]
    public string? Employee { get; set; }
    [DisplayName("Thời gian")]
    public string? Created { get; set; }
  }

  public class DatalogDetailDeleteDTO
  {
    [Browsable(false)]
    public long Id { get; set; }

    [DisplayName("Stt")]
    public long? No { get; set; }

    [DisplayName("Lệnh sản xuất")]
    public string? ProductionOrder { get; set; }
    [DisplayName("Nhóm")]
    public string? MaterialGroup { get; set; }
    [DisplayName("Loại vật tư")]
    public string? MaterialType { get; set; }
    [DisplayName("Tên vật tư")]
    public string? MaterialName { get; set; }
    [DisplayName("Gross (kg)")]
    public float Gross { get; set; }
    [DisplayName("Net (kg)")]
    public float Net { get; set; }
    [DisplayName("Tare (kg)")]
    public float Tare { get; set; }
    [DisplayName("Người cân")]
    public string? Employee { get; set; }
    [DisplayName("Thời gian")]
    public string? Created { get; set; }

    [DisplayName("Thời gian xoá")]
    public string? Updated { get; set; }
    [DisplayName("Người xoá")]
    public string? UpdatedbyName { get; set; }
    [Browsable(false)]
    public long? Updatedby { get; set; }
  }
}
