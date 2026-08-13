using iSoft.DatabaseServer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSF.Database.Entities
{
  [Table("I_DataFactories")]
  public class FactoryEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    #endregion

    #region Relations
    public List<MachineEntity>? DataMachines { get; set; }
    #endregion
  }
}
