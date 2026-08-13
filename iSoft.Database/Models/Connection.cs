using static HelperManager.EnumData;

namespace iSoft.Database.Models
{
  public class Connection : BaseModel
  {
    public string? Name { get; set; }
    public string? Code { get; set; }
    public eDevice? eDevice { get; set; }
    public eCommunicationType? eCommunicationType { get; set; }
    public string? JsonStrConfig { get; set; }


    #region Mapping
    public long? MachineId { get; set; }
    public Station? Machine { get; set; }
    #endregion
  }
}
