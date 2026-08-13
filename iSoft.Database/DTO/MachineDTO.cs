using System.ComponentModel;

namespace iSoft.Database.DTO
{
  public class MachineDTO
  {
    [Browsable(false)]
    public long Id { get; set; }

    [DisplayName("Stt")]
    public long No { get; set; }
    [DisplayName("Máy")]
    public string? Name { get; set; }

    [DisplayName("Mã máy")]
    public string? MachineName { get; set; }

    [DisplayName("Ngày tạo")]
    public string? CreatedAt { get; set; }

    [DisplayName("Cập nhật")]
    public string? UpdatedAt { get; set; }
    [Browsable(false)]
    public bool Enable { get; set; }


    public string DisplayText
    {
      get
      {
        return $"{MachineName} - {Name}";
      }
    }

  }
}
