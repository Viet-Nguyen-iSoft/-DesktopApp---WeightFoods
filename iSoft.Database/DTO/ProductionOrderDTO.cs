using System.ComponentModel;

namespace iSoft.Database.DTO
{
  public class ProductionOrderDTO
  {
    [Browsable(false)]
    public long? Id { get; set; }

    [DisplayName("Stt")]
    public int? No { get; set; }
    [DisplayName("Tên")]
    public string? Name { get; set; }
   

    [DisplayName("Loại")]
    public string? Type { get; set; }


    [DisplayName("Số NL-VT")]
    public int MaterialNumbers { get; set; } = 0;


    [DisplayName("Hiệu lực")]
    public string? Datetime { get; set; }


    [DisplayName("Cảnh báo")]
    public string? Warning { get; set; }

    [DisplayName("Trạng thái")]
    public string? Status { get; set; }


    [DisplayName("Cập nhật")]
    public string? UpdatedAt { get; set; }
  }

  public enum EnumStatusDataPO
  {
    None = 0,
    NotStarted,
    Active,
    Expired,
    NotAprove,
  }
}
