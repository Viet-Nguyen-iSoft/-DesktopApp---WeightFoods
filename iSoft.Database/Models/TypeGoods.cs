namespace iSoft.Database.Models
{
  public class TypeGoods : BaseModel
  {
    public string? Name { get; set; }
    public string? Description { get; set; }

    #region Mapping
    public ICollection<RecordTruck> RecordTrucks { get; set; } = new List<RecordTruck>();
    #endregion
  }
}
