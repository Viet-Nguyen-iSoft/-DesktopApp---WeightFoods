using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSyncData.Resp
{
  public class StationAPI
  {
    public string? Status { get; set; }
    public DataStation? Data { get; set; }
  }
  public class DataStation
  {
    public int? TotalRecord { get; set; }
    public List<ListDatumStation>? ListData { get; set; }
  }

  public class ListDatumStation : IServerRecord
  {
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool? IsDelete { get; set; }
    public string? Description { get; set; }
  }
}
