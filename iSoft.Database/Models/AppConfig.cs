using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class AppConfig: BaseModel
  {
    public string? IpServer { get; set; }
    public int? PortServer { get; set; }
    public long? MachineId { get; set; }
    public string? MachineCode { get; set; }
    public string? JsonConfigLabelPrint { get; set; }
    public string? JsonConfigLabelPrintGeneral { get; set; }
    public string? NamePrinter { get; set; }
    public int? NumberLabelWeight { get; set; } = 1;
    public string? NamePrinterA4 { get; set; }
    public int? TimeDelayPrinter { get; set; } = 1000;
    public int? TimeDurationPrinter { get; set; } = 1000;

    public bool IsAutoSyncData { get; set; } = false;
    public int? TimeSyncData { get; set; } = 2000;
    public string? Version { get; set; }
  }
}
