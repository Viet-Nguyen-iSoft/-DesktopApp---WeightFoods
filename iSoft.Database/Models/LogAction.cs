using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class LogAction:BaseModel
  {
    public string? Name { get; set; }
    public eAction? eAction { get; set; }
  }

  public enum eAction
  {
    AllAction,
    [Description("Phần mềm khởi động")]
    StartApp,
    [Description("Phần mềm tắt")]
    StopApp,
    [Description("Các lỗi Try catch")]
    Error,
    [Description("Thao tác người dùng")]
    Action,
  }
}
