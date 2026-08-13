using iSoft.DatabaseServer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using static HelperManager.EnumData;

namespace HSF.Database.Entities
{
  [Table("I_UserGroups")]
  public class UserGroupEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public string? Name { get; set; }
    public string? Description { get; set; }
    public EnumGroup Group { get; set; }
    #endregion

    #region Mapping
    public List<UserEntity>? Users { get; set; }
    #endregion
  }
}
