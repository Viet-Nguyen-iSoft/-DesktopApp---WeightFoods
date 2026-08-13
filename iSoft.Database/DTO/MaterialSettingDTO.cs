using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DTO
{
  public class MaterialSettingDTO
  {

    [DisplayName("Stt")]
    public int? No { get; set; }

    [DisplayName("Mã/Code")]
    public string? Code { get; set; }

    [DisplayName("Tên/Name")]
    public string? Name { get; set; }


    [DisplayName("Phân loại")]
    public string? TypeMaterial { get; set; }


    [DisplayName("Giá trị Loss (%)")]
    public double? Loss { get; set; }

    [DisplayName("Giá trị cài đặt (%)")]
    public double? Setting { get; set; }

    [DisplayName("DVT")]
    public string? Unit { get; set; }


    [DisplayName("Giá trị quy đổi")]
    public double? WeightConversion { get; set; }
  }
}
