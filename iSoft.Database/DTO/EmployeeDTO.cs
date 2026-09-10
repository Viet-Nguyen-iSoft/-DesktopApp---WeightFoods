using iSoft.Database.Models;
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
    public Employee Employee { get; set; }

    [DisplayName("Stt")]
    public long No { get; set; }
    [DisplayName("Mã nhân viên")]
    public string? Code { get; set; }
    [DisplayName("Họ và tên")]
    public string? FullName { get; set; }
    
    //[DisplayName("Phòng ban")]
    //public string? Department { get; set; }

    [DisplayName("Mã thẻ RFID")]
    public string? IdCardCode { get; set; }

    [DisplayName("Cập nhật")]
    public string? UpdatedAt { get; set; }
  }
}
