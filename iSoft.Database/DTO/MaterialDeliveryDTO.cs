using iSoft.Database.Models;
using Newtonsoft.Json;
using System.ComponentModel;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;

namespace iSoft.Database.DTO
{
  public class MaterialDeliveryDTO
  {
    [Browsable(false)]
    public RecordWeight? DatalogWeight { get; set; }

    [Browsable(false)]
    public string? Operator { get; set; }

    [Browsable(false)]
    [DisplayName("Lệnh sản xuất")]
    public string? ProductionOrder { get; set; }

    [Browsable(false)]
    public Product? Material { get; set; }
    [Browsable(false)]
    public Product? MaterialDefect { get; set; }

    [Browsable(false)]
    public string? MaterialType { get; set; }


    [DisplayName("Mã")]
    public string? CodeMaterial { get; set; }

    [DisplayName("Tên NL-VT")]
    public string? NameMaterial { get; set; }

    [DisplayName("Net (Kg)")]
    public string? Net { get; set; }


    [Browsable(false)]
    public string? DescriptionMaterial { get; set; }


    [DisplayName("Số lượng")]
    public string? Quality { get; set; }
    [Browsable(false)]
    public double? QualityValue { get; set; }


    [DisplayName("ĐVT")]
    public string? Unit { get; set; }


    [Browsable(false)]
    [DisplayName("Hình thức")]
    public string? ImportExportStatus { get; set; }
    [Browsable(false)]
    public EnumExportImport eExportImport { get; set; }

    [Browsable(false)]
    [DisplayName("Gross")]
    public double? GrossValue { get; set; }

    [Browsable(false)]
    public string? Gross { get; set; }


    [Browsable(false)]
    public double? NetValue { get; set; }

    [Browsable(false)]
    public string? Tare { get; set; }

    [DisplayName("Thời gian")]
    public string? CreatedAtStr { get; set; }

    [Browsable(false)]
    public DateTime? CreatedAt { get; set; }

    //[Browsable(false)]
    public bool? Check { get; set; } = false;
  }

  public class MaterialSummaryDTO
  {
    public Product? Material { get; set; }
    public Product? MaterialDefect { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public double TotalWeight { get; set; }
    public List<MaterialDeliveryDTO>? MaterialDeliveryDTOs { get; set; }
  }

  public class DeliverySummaryDTO
  {
    [DisplayName("Mã")]
    public string? CodeMaterial { get; set; }


    [Browsable(false)]
    [DisplayName("Tên NL-VT")]
    public string? NameMaterial { get; set; }


    [DisplayName("Tối đa")]
    public string TargetStr => $"{Target} {Unit}".Trim();


    [DisplayName("Thực tế")]
    public string ActualStr => $"{Actual} {Unit}".Trim();


    [Browsable(false)]
    public Product? Material { get; set; }
    [Browsable(false)]
    public Product? MaterialDefect { get; set; }
    [Browsable(false)]
    public double Target { get; set; }
    [Browsable(false)]
    public double Actual { get; set; }
    [Browsable(false)]
    public string? Unit { get; set; }
  }
}
