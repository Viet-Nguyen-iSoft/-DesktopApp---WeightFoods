using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DTO
{
  public class MaterialDTO
  {
    [Browsable(false)]
    public long? Id { get; set; }

    [DisplayName("Stt")]
    public string? No { get; set; }

    [DisplayName("Mã")]
    public string? Code { get; set; }

    [DisplayName("Phân loại")]
    public string? TypeMaterial { get; set; }

    [DisplayName("Tên loại")]
    public string? Type { get; set; }

    [Browsable(false)]

    [DisplayName("Quy cách")]
    public string? Grade { get; set; }

    [DisplayName("DVT")]
    public string? Unit { get; set; }

    [DisplayName("Giá trị quy đổi")]
    public double? WeightConversion { get; set; }


    [Browsable(false)]
    [DisplayName("LOT")]
    public string? LOT { get; set; }


    [Browsable(false)]
    [DisplayName("Nhà cung cấp")]
    public string? Supplier { get; set; }


    [Browsable(false)]
    [DisplayName("Hết hạn")]
    public string? ExpiredDate { get; set; }


    [Browsable(false)]
    [DisplayName("Ghi chú")]
    public string? Note { get; set; }

    [Browsable(false)]
    [DisplayName("% loss")]
    public string? LossPercent { get; set; }

    [DisplayName("Ngày tạo")]
    public string? CreatedAt { get; set; }
    [DisplayName("Cập nhật")]
    public string? UpdatedAt { get; set; }


    [Browsable(false)]
    public Material? MaterialSrc { get; set; } = new Material();
  }

  public class MaterialWeightDTO
  {
    [Browsable(false)]
    public long? Id { get; set; }

    [DisplayName("Stt")]
    public string? No { get; set; }

    [DisplayName("Mã/Code")]
    public string? Code { get; set; }

    [DisplayName("Phân loại")]
    public string? TypeMaterial { get; set; }
    [DisplayName("Nhóm (VN / EN)")]
    public string? Group { get; set; }

    [DisplayName("Tên loại (VN / EN)")]
    public string? Type { get; set; }

    [DisplayName("Quy cách")]
    public string? Grade { get; set; }

    [DisplayName("DVT")]
    public string? Unit { get; set; }

   
    [DisplayName("KL tối đa (kg)")]
    public double? WeightMax { get; set; } = 0;

    [DisplayName("Ngày tạo")]
    public string? CreatedAt { get; set; }
    [DisplayName("Cập nhật")]
    public string? UpdatedAt { get; set; }
  }
}
