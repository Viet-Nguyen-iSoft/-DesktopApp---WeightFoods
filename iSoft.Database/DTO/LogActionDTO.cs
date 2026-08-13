using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DTO
{
  public class LogActionDTO
  {
    [DisplayName("Thời gian")]
    public string? DateTime { get; set; }
    [DisplayName("Tên")]
    public string? Name { get; set; }
    [DisplayName("Mô tả")]
    public string? Description { get; set; }
    
  }




}
