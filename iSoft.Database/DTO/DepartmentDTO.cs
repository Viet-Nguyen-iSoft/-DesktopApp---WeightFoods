using System.ComponentModel;

namespace iSoft.Database.DTO
{
  public class DepartmentDTO
  {
    [Browsable(false)]
    public long Id { get; set; }

    [DisplayName("Stt")]
    public long No { get; set; }
    [DisplayName("Phòng ban")]
    public string? Name { get; set; }
    [DisplayName("Mô tả")]
    public string? Description { get; set; }

    [DisplayName("Ngày tạo")]
    public string? CreatedAt { get; set; }
    [DisplayName("Cập nhật")]
    public string? UpdatedAt { get; set; }
    [Browsable(false)]
    public bool Enable { get; set; }
  }

  public class DepartmentLabelDTO
  {
    [Browsable(false)]
    public long Id { get; set; }

    [DisplayName("Stt")]
    public long No { get; set; }
    [DisplayName("Phòng ban")]
    public string? Name { get; set; }
    [DisplayName("Mô tả")]
    public string? Description { get; set; }
   
    [DisplayName("Ngày tạo")]
    public string? CreatedAt { get; set; }
    [DisplayName("Cập nhật")]
    public string? UpdatedAt { get; set; }
  }
}
