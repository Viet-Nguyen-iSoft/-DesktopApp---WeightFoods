using iSoft.DatabaseServer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSF.Database.Entities
{
  [Table("I_Users")]
  public class UserEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public string? FullName { get; set; }
    public string? EmployeeCode { get; set; }

    public string? IdCardCode { get; set; }
    public bool? IsAllowOverWeight { get; set; }
    #endregion

    #region Relations
    public List<LaborProductivityRecognitionEntity>? Recognitions { get; set; }

    public List<WeightTicketEntities>? WeightTicketDeliveries { get; set; } = new List<WeightTicketEntities>();
    public List<WeightTicketEntities>? WeightTicketReceives { get; set; } = new List<WeightTicketEntities>();
    public List<WeightTicketEntities>? WeightTicketQCes { get; set; } = new List<WeightTicketEntities>();

    public List<UserGroupEntity>? UserGroups { get; set; }
    public List<MachineEntity>? Machines { get; set; }
    #endregion
  }

}
