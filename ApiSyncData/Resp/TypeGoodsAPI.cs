using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSyncData.Resp
{
  public class TypeGoodsAPI
  {
    public string? Status { get; set; }
    public DataTypeGoods? Data { get; set; }
  }
  public class DataTypeGoods
  {
    public int ?TotalRecord { get; set; }
    public List<ListDatumTypeGoods>? ListData { get; set; }
  }

  public class ListDatumTypeGoods : IServerRecord
  {
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool? IsDelete { get; set; }
  }


}
