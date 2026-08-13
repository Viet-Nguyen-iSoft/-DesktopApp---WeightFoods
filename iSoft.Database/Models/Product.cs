using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Models
{
  public class Product:BaseModel
  {
    [DisplayName("Nhóm")]
    public string? Group { get; set; }

    [DisplayName("Tên")]
    public string? Name { get; set; }

    [DisplayName("Quy cách")]
    public string? Grade { get; set; }

    [DisplayName("Mã/Code")]
    public string? Code { get; set; }

    [DisplayName("DVT")]
    public string? Unit { get; set; }

    [DisplayName("Lotcode")]
    public string? LOT { get; set; }

    [DisplayName("Nhà cung cấp")]
    public string? Supplier { get; set; }

    [DisplayName("Hết hạn")]
    public string? ExpiredDate { get; set; }

    [DisplayName("Ghi chú")]
    public string? Note { get; set; }
    [DisplayName("% loss")]
    public string? LossPercent { get; set; }
    [DisplayName("Mã phế phẩm")]
    public string? CodeLoss { get; set; }

    public float? WeightConversion { get; set; }
    public string? UnitConversion { get; set; }
    public double? StockTaking { get; set; }


    [DisplayName("Tare")]
    public bool? TareFlag { get; set; } = false;
    public double? ValueTare { get; set; }

    [DisplayName("Tare")]
    public string? Description { get; set; }

    public string? TargetUnit { get; set; }


    [Browsable(false)]
    public string? PathImage { get; set; }

    public int? MaterialType { get; set; }



    #region Mapping
    public long? MaterialGroupId { get; set; }
    public ProductGroup? MaterialGroup { get; set; }

    public ICollection<RecordFoods> DatalogWeights { get; set; } = new List<RecordFoods>();
    public ICollection<RecordFoods> DatalogWeightDefects { get; set; } = new List<RecordFoods>();
    public ICollection<CategoryTare> CategoryTares { get; set; } = new List<CategoryTare>();
    #endregion
  }

  
  
}
