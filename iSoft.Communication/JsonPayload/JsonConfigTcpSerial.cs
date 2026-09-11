using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Communication.JsonPayload
{
  public class JsonConfigTcpSerial
  {
    [Browsable(false)]
    [DisplayName("Mã kết nối")]
    public Guid Id { get; set; }

    [DisplayName("Tên thiết bị")]
    public string? NameDevice { get; set; }


    [DisplayName("COM")]
    public string? COM { get; set; }


    [DisplayName("Tự động kết nối")]
    public bool AutoConnect { get; set; } = false;


    [DisplayName("Gửi lệnh lấy data")]
    public bool Request { get; set; } = false;


    [DisplayName("Thời gian Gửi lệnh")]
    public int TimeRequest { get; set; } = 200;
  }
}
