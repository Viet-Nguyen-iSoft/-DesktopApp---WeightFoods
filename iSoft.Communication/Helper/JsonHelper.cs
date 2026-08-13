using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Communication.JsonPayload.ConfigSerialPort;

namespace iSoft.Communication.Helper
{
  public static class JsonHelper
  {
    public static string ToJson<T>(T payload)
    {
      return JsonConvert.SerializeObject(payload, Formatting.Indented);
    }
    public static T? FromJson<T>(string json)
    {
      return JsonConvert.DeserializeObject<T>(json);
    }
  }
}
