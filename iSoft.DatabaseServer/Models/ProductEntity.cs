using HSF.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSoft.DatabaseServer.Models
{
  [Table("I_Products")]
  public class ProductEntity : BaseConnectivityCRUDEntity
  {
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? SerialCode { get; set; }
    public string? Description { get; set; }
    public bool? SyncFlag { get; set; } = false;

    #region Mapping
    public List<MaterialEntity> Materials { get; set; } = new List<MaterialEntity>();
    public List<ProductionOrderEntity>?  ProductionOrders { get; set; } = new List<ProductionOrderEntity>();
    public List<LaborProductivityRecognitionEntity> Recognitions { get; set; } = new List<LaborProductivityRecognitionEntity>();
    #endregion

  }
}
