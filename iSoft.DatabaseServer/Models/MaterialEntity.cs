using iSoft.DatabaseServer.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSF.Database.Entities
{
  [Table("I_Materials")]
  public class MaterialEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public string? PathImage { get; set; }
    public int? MaterialType { get; set; }
    public string? Description { get; set; }
    public float? WeightConversion { get; set; }
    public string? DVT { get; set; }
    public string? LOT { get; set; }
    public string? TargetUnit { get; set; }
    public float? StockTaking { get; set; }
    //public string? MaterialSize { get; set; }

    public string? ExpiredDate { get; set; }


    public string? Group { get; set; }
    public string? Name { get; set; }
    public string? SerialCode { get; set; }
    public string? Note { get; set; }
    public string? Specs { get; set; }
    public string? Supplier { get; set; }
    public bool? TareFlag { get; set; }
    public float? ValueTare { get; set; }
    #endregion

    #region Relations
    public Guid? MaterialGroupId { get; set; }
    public MaterialGroupEntity MaterialGroup { get; set; } = null!;

    public List<ProductEntity> Productions { get; set; } = new List<ProductEntity>();
    public List<ProductionOrderEntity>?  ProductionOrders { get; set; } = new List<ProductionOrderEntity>();
    public List<LaborProductivityRecognitionEntity> Recognitions { get; set; } = new List<LaborProductivityRecognitionEntity>();
    public List<LaborProductivityRecognitionEntity> RecognitionLosss { get; set; } = new List<LaborProductivityRecognitionEntity>();
    //public List<MaterialEntityTrans>? MaterialEntityTrans { get; set; } = new List<MaterialEntityTrans>();
    public List<TareCategoryEntity>? TareCategories { get; set; }
    #endregion
  }


}