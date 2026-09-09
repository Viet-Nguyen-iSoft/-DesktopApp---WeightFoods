using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DTO
{
  public class DTOPrintLabel
  {
    public string? ProductGroup { get; set; } 
    public string? Product { get; set; } 
    public string? TypeTare { get; set; }
    public double Net { get; set; }
    public double Tare { get; set; } 
    public string? Datetime { get; set; }
    public string? Operator { get; set; }
  }
}
