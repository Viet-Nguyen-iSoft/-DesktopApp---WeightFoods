using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
  public class EnumData
  {
    public enum EnumCommunication
    {
      None = 0,
      [Description("TCP Client")]
      TcpClient = 1,
      [Description("RS 232")]
      RS232,
    }

    public enum EnumImageMsg
    {
      None = 0,
      Confirm,
      Question,
      Warning,
      Information,
    }
    public enum EnumTypeMsg
    {
      None = 0,
      Confirm,
      MessageManualClose,
      MessageAutoClose,
    }
    public enum EnumResponsible
    {
      None = 0,
      Confirm,
      Cancel,
    }

    public enum EnumTypeData
    {
      None = 0,
      Client,
      TypeGoods,
      Warehouse,
      Information,
    }
  }
}
