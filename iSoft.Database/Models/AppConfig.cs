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
    public Guid? MachineId { get; set; }
    public string? Version { get; set; }

    public string? Key { get; set; }
  }
}
