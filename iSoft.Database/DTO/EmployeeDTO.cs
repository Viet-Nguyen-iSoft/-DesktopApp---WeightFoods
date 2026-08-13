using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DTO
{
  public class EmployeeDTO
  {
    [Browsable(false)]
    public long Id { get; set; }
    [DisplayName("Stt")]
    public long No { get; set; }
    [DisplayName("Họ và tên")]
    public string? FullName { get; set; }
    [DisplayName("Mã nhân viên")]
    public string? Code { get; set; }
    [DisplayName("Phòng ban")]
    public string? Department { get; set; }

    [DisplayName("Mã thẻ RFID")]
    public string? IdCardCode { get; set; }
    [DisplayName("Ngày tạo")]
    public string? CreatedAt { get; set; }
    [DisplayName("Cập nhật")]
    public string? UpdatedAt { get; set; }
  }
}
