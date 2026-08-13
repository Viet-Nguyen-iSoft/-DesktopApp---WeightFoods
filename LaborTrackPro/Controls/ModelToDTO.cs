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

   

  }
}
