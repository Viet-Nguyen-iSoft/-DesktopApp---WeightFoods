using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSyncData.Resp
{
  public class DataClient
  {
    public int? TotalRecord { get; set; }
    public List<ListDatumClient>? ListData { get; set; }
  }

  public class ListDatumClient : IServerRecord
  {
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool? IsDelete { get; set; }
  }

  public class ClientAPI
  {
    public string? Status { get; set; }
    public DataClient? Data { get; set; }
  }
}
