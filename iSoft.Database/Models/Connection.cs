using static HelperManager.EnumData;

namespace iSoft.Database.Models
{
  public class Connection : BaseModel
  {
    public string? Name { get; set; }
    public string? Code { get; set; }
    public EnumDevice? EnumDevice { get; set; }
    public EnumCommunicationType?  EnumCommunicationType { get; set; }
    public string? JsonStrConfig { get; set; }


    #region Mapping
    public long? StationId { get; set; }
    public Station? Station { get; set; }
    #endregion
  }
}
