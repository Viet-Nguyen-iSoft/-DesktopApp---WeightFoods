using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DTO
{
  public class SettingLabelDTO
  {
    [Browsable(false)]
    public long Id { get; set; }
    [Browsable(false)]
    public SettingLabel? SettingLabel { get; set; }

    [DisplayName("Stt")]
    public long? No { get; set; }


    [DisplayName("Tiêu đề")]
    public string? Name { get; set; }


    [DisplayName("Số lượng")]
    public int? NumverCopy { get; set; }

    [DisplayName("Ngày tạo")]
    public string? CreatedAt { get; set; }

    [DisplayName("Cập nhật")]
    public string? UpdatedAt { get; set; }
  }
}
