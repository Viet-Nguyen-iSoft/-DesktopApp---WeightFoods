using System.ComponentModel;

namespace iSoft.Database.Models
{
  public class Machine : BaseModel
  {
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public double? WeightDeviation { get; set; }
    #region Mapping
    [Browsable(false)]
    public long? FactoryId { get; set; }

    [Browsable(false)]
    public Factory? Factory { get; set; }


    public ICollection<DatalogWeight>? DatalogWeights { get; set; }
    public ICollection<DatalogDelivery>? DatalogDeliveries { get; set; }
    public ICollection<Connection>? Connections { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    #endregion
  }
}
