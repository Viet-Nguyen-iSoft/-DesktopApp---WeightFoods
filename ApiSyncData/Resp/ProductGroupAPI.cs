using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSyncData.Resp
{
  public class DataProductGroup
  {
    public int? TotalRecord { get; set; }
    public List<ListDatumProductGroup>? ListData { get; set; }
  }

  public class ListDatumProductGroup : IServerRecord
  {
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool? IsDelete { get; set; }
  }

  public class ProductGroupAPI
  {
    public string? Status { get; set; }
    public DataProductGroup? Data { get; set; }
  }

}
