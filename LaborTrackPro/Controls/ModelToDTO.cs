using HelperManager;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Printer;

namespace LaborTrackPro.Controls
{
  public static class MapperDTO
  {
    public static LogActionDTO ToDTO(this LogAction? entity)
    {
      if (entity == null) return new LogActionDTO();
      return new LogActionDTO
      {
        Name = entity.Name,
        Description = EnumHelper.GetDescription(entity.eAction),
        DateTime = entity.CreatedAt?.ToString("dd/MM/yyyy HH:mm:ss")
      };
    }

    public static InformationDelivery ConvertManagerDataToInformationDelivery(ManagerData? managerData, string[] listDepartment)
    {
      try
      {
        if (managerData != null)
        {
          return new InformationDelivery
          {
            EnumExportImport = managerData?.EnumExportImport,
            EnumInternalExternal = managerData?.EnumInternalExternalStatus,
            ProductionOrder = managerData?.ProductionOrder,
            PO = managerData?.ProductionOrder?.Name ?? "Yêu cầu khác",
            Datetime = DateTime.Now,
            DeliveryEmployee = managerData?.DataLogDelivery?.EmployeeDelivery,
            ReceivingEmployee = managerData?.DataLogDelivery?.EmployeeReceiving,
            QCEmployee = managerData?.DataLogDelivery?.EmployeeQC,
            DepartmentList = listDepartment,
            LaborProductivityRecognitions = managerData?.DataLogDelivery?.DatalogWeights,
            MaterialDelivaryDTOs = managerData?.DataLogDelivery?.MaterialDelivaryDTOs,
            Machine = managerData?.Machine,
            Material = managerData?.DataLogDelivery?.DatalogWeights?.FirstOrDefault()?.Material ?? null
          };
        }
        return new InformationDelivery();
      }
      catch (Exception)
      {
        throw;
      }
    }

  }
}
