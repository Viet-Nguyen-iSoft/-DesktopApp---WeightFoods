using HelperManager;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.Generic;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;


namespace iSoft.Database
{
  public static class DTOHelper
  {
    public static List<ClientDTO>? ConvertClientDTO(List<Client>? clients)
    {
      var rsDto = new List<ClientDTO>();
      if (clients?.Count()>0)
      {
        clients = clients.OrderBy(e => e.Name).ToList();
        rsDto = clients
          .Select((e, index) => new ClientDTO
          {
            Client = e,
            No = index + 1, // STT bắt đầu từ 1
            Name = e.Name,
            Description = e.Description,
          })
          .OrderBy(e => e.Name)
          .ToList();
      }  
      return rsDto;
    }
    
    

    public static List<DepartmentDTO> ConvertDepartmentToDTO(List<Department> departments)
    {
      try
      {
        return departments
             .Select((e, index) => new DepartmentDTO
             {
               Id = e.Id,
               No = index + 1,
               Name = e.Name,
               Description = e.Description,
               CreatedAt = e.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
               UpdatedAt = e.UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
               Enable = e.EnableFlag
             })
             .ToList();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    


    public static List<DatalogOperationGroupDTO> ConvertDatalogOperationGroup
    (List<RecordWeight> laborProductivityRecognitions, string textSearch = "")
    {
      textSearch = TextHelper.RemoveDiacritics(textSearch).Trim().ToLower();

      var dto = laborProductivityRecognitions
              .GroupBy(r => new
              {
                r.Employee,
                //MaterialKey = r.MaterialId ?? r.MaterialId,
                //MaterialGroup = r.Material.MaterialType switch
                //{
                //  0 => "N/A",
                //  1 => " Nguyên liệu",
                //  2 => " Vật tư",
                //},
                //MaterialType = r.Material != null ? r.Material.Group : r.Material?.Group,
                //MaterialName = r.Material != null ? r.Material.Type : r.Material?.Type
              })
              .Select(g => new
              {
                RangeTimeStr = $"{((DateTime)g.Min(x => x.CreatedAt)).ToString("dd/MM/yyyy HH:mm:ss")} - {((DateTime)g.Max(x => x.CreatedAt)).ToString("dd/MM/yyyy HH:mm:ss")}",
                g.Key.Employee?.FullName,
                //g.Key.MaterialType,
                //g.Key.MaterialGroup,
                //g.Key.MaterialName,
                TotalWeight = (float)Math.Round(g.Sum(x => Math.Round( x.Net,2)),2),
              })
              .ToList();
      return dto.Where(x =>
            string.IsNullOrEmpty(textSearch) ||
            TextHelper.RemoveDiacritics(x.FullName).Trim().ToLower().Contains(textSearch) //||
            //TextHelper.RemoveDiacritics(x.MaterialGroup).Trim().ToLower().Contains(textSearch) 
            )
            .OrderBy(x => x.FullName)
            .Select((e, index) => new DatalogOperationGroupDTO
            {
              No = index + 1, // STT bắt đầu từ 1
              RangeTime = e.RangeTimeStr,
              Employee = e.FullName,
              //MaterialGroup = e.MaterialGroup,
              //MaterialType = e.MaterialType,
              //MaterialName = e.MaterialName,
              Total = (float)Math.Round(e.TotalWeight, 2),
            })
            .ToList();
    }


    



    
  }
}
