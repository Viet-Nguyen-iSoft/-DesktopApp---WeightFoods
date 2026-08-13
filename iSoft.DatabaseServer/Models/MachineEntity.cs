using iSoft.Database.Models;
using iSoft.DatabaseServer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSF.Database.Entities
{
  [Table("I_DataMachines")]
  public class MachineEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public float? WeightDeviation { get; set; }
    #endregion

    #region Relations
    public Guid? DataFactoryId { get; set; }
    public FactoryEntity? DataFactory { get; set; }

    public List<LaborProductivityRecognitionEntity>? Recognitions { get; set; }
    public List<ConnectionEntity>? Connections { get; set; }
    public List<WeightTicketEntities>? WeightTickets { get; set; } = new List<WeightTicketEntities>();
    public List<UserEntity>? Users { get; set; }
    #endregion
  }


  public class Data
  {
    public Guid ProductionOrderId { get; set; }
    public Guid MaterialId { get; set; }

    public double SettingInKg { get; set; }   // Giá trị cài đặt quy ra Kg (bao gồm loss chế biến, loss phế phẩm). Không bao gồm sai số cân
    public double WasteLossInKg { get; set; } // Giá trị loss phế quy ra Kg (trọng lượng cân phế tối đa)

    public List<DataByDepartment>? DataNormalByDepartments { get; set; }
    public List<DataByDepartment>? DataLossByDepartments { get; set; }
  }

  public class DataByDepartment
  {
    public EnumTypeData EnumTypeData { get; set; }  // Kiểu data
    public Guid DepartmentId { get; set; }          // Id phòng ban
    public double Actual { get; set; }              // Tổng giá trị cân
    public double Deviation { get; set; }           // Tổng Sai số cân
  }

  public enum EnumTypeData
  {
    Import,
    Export,
    ImportInternal,
    ExportInternal,
  }


}
