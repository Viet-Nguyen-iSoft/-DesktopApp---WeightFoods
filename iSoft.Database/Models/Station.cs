using System.ComponentModel;

namespace iSoft.Database.Models
{
  public class Station : BaseModel
  {
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public double? WeightDeviation { get; set; }


    #region Mapping
    public ICollection<RecordWeight>? RecordFoods { get; set; }
    #endregion
  }
}
