//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static iSoft.Database.EnumData;

//namespace iSoft.Database.Models
//{
//  public class MaterialTrans:BaseModel
//  {
//    [DisplayName("Nhóm")]
//    public string? Group { get; set; }

//    [DisplayName("Tên loại")]
//    public string? Type { get; set; }

//    [DisplayName("Cấp bậc")]
//    public string? Grade { get; set; }

//    [DisplayName("Mã/Code")]
//    public string Code { get; set; } = "N/A";


//    [DisplayName("DVT")]
//    public string? Unit { get; set; }

//    [DisplayName("Lotcode")]
//    public string? LOT { get; set; }

//    [DisplayName("Nhà cung cấp")]
//    public string? Supplier { get; set; }

//    [DisplayName("Hết hạn")]
//    public string? ExpiredDate { get; set; }

//    [DisplayName("Ghi chú")]
//    public string? Note { get; set; }
//    [DisplayName("% loss")]
//    public string? LossPercent { get; set; }
//    [DisplayName("Mã phế phẩm")]
//    public string? CodeLoss { get; set; }

//    public string? WeightConversion { get; set; }
//    public string? UnitConversion { get; set; }
//    public string? Stocktaking { get; set; }


//    public int? MaterialType { get; set; }

//    public string? Lang { get; set; } = eLang.en.ToString();

//    #region Mapping
//    [Browsable(false)]
//    public long? MaterialId { get; set; }

//    [Browsable(false)]
//    public Material? Material { get; set; }
//    #endregion
//  }
//}
