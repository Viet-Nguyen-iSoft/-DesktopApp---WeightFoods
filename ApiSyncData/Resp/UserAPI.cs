using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSyncData.Resp
{
  public class UserAPI
  {
    public string? Status { get; set; }
    public DataUser? Data { get; set; }
  }
  public class DataUser
  {
    public int TotalRecord { get; set; }
    public List<ListDatumUser>? ListData { get; set; }
  }

  public class ListDatumUser
  {
    public Guid? Id { get; set; }
    public string? DisplayName { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? EmployeeCode { get; set; }
    public string? IdCardCode { get; set; }
  }

  

}
