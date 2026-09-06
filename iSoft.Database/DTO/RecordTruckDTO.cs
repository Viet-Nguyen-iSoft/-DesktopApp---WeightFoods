using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Database.EnumData;

namespace iSoft.Database.DTO
{
  public class RecordTruckDTO
  {
    [Browsable(false)]
    public RecordTruck? RecordTruck { get; set; }
    [DisplayName("Stt")]
    public int No { get; set; }
    [DisplayName("Số phiếu")]
    public string? NoLabelAuto { get; set; }
    [DisplayName("Số phiếu nhà máy")]
    public string? NoLabelManual { get; set; }

    [DisplayName("Biển số xe")]
    public string? LicensePlate { get; set; }
    [DisplayName("Tên tài xế")]
    public string? NameDriver { get; set; }
    [DisplayName("CCCD")]
    public string? IdCard { get; set; }



    [DisplayName("Cân lần 1 (Kg)")]
    public string? NetTime01 { get; set; }

    [DisplayName("Cân lần 2 (Kg)")]
    public string? NetTime02 { get; set; }

    [DisplayName("Trạng thái")]
    public string? Status { get; set; }
    [Browsable(false)]
    public EnumTypeDataTruck EnumTypeDataTruck { get; set; } = EnumTypeDataTruck.None;


    [DisplayName("Khách hàng")]

    public string? Client { get; set; }
    [DisplayName("Loại hàng")]
    public string? TypeGoods { get; set; }
    [DisplayName("Kho hàng")]
    public string? Warehouse { get; set; }
    
    [DisplayName("Chứng từ")]
    public string? Document { get; set; }

    [DisplayName("Thời gian")]
    public string? Datetime { get; set; }
  }
}
