using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.RabbitMq
{
  public class Message
  {
    public class WeightLoggingMessage
    {
      public Guid? msgId { get; set; } = NewGUID();
      public Guid? DataMachineId { get; set; }
      public Guid? LaborProductivityRecognitionId { get; set; }
      public float? WeightValue { get; set; }
      public string? IdCardCode { get; set; }

      [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss.fffZ}")]
      public DateTime ExecuteAt { get; set; } = DateTime.UtcNow;
    }

    public class WeightRealtimeMessage
    {
      public Guid? msgId { get; set; } = NewGUID();
      public Guid? DataMachineId { get; set; }
      public float WeightValue { get; set; }

      [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss.fffZ}")]
      public DateTime ExecuteAt { get; set; } = DateTime.UtcNow;
    }

    public static Guid NewGUID()
    {
      byte[] ticksBytes = BitConverter.GetBytes(DateTime.UtcNow.Ticks);
      byte[] randomBytes = new byte[8];
      new Random().NextBytes(randomBytes);

      byte[] combinedBytes = new byte[16];
      Array.Copy(randomBytes, combinedBytes, 4);
      Array.Copy(ticksBytes, 0, combinedBytes, 4, 8);
      Array.Copy(randomBytes, 4, combinedBytes, 12, 4);

      return new Guid(combinedBytes);
    }
  }
}
