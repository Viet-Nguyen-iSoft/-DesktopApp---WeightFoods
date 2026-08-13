using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DTO
{
  //public class GroupMaterialDTO
  //{
  //  public long? GroupId { get; set; }
  //  public MaterialGroup? MaterialGroup { get; set; }
  //  public List<Material>? Materials { get; set; }
  //}

  public class GroupMaterialDTO
  {
    public string? GroupStr { get; set; }
    public List<Product>? Materials { get; set; }
  }
}
