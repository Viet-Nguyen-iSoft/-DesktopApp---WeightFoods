using iSoft.Database.Models;
using System.ComponentModel;

namespace iSoft.Database.DTO
{
  public class RecordWeightDTO
  {
    [Browsable(false)]
    public RecordWeight? RecordWeight { get; set; }

    [DisplayName("Stt")]
    public int No { get; set; }

    [DisplayName("Thời gian")]
    public string? Datetime { get; set; }
    [DisplayName("Biển số xe")]
    public string? LicensePlate { get; set; }

    [DisplayName("Nhóm SP")]
    public string? ProductGroup { get; set; }

    [DisplayName("Sản phẩm")]
    public string? Product { get; set; }

    [DisplayName("Loại bì")]
    public string? CategoryTare { get; set; }

    [DisplayName("Net (Kg)")]
    public string? Net { get; set; }

    [DisplayName("Tare (Kg)")]
    public string? Tare { get; set; }
  }
}
