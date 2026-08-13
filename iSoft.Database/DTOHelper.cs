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
    public static List<EmployeeDTO>? ConvertEmployeeToDTO(List<Employee>? employees)
    {
      var rsDto = new List<EmployeeDTO>();
      if (employees?.Count()>0)
      {
        rsDto = employees
          .Select((e, index) => new EmployeeDTO
          {
            Id = e.Id,
            No = index + 1, // STT bắt đầu từ 1
            FullName = e.FullName,
            Code = e.Code,
            Department = e?.Departments?.Where(x => x.DeletedFlag == false)?.FirstOrDefault()?.Name ?? "N/A",
            IdCardCode = e?.IdCardCode,
            CreatedAt = e?.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? "N/A",
            UpdatedAt = e?.UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? "N/A",
          })
          .OrderBy(e => e.Department).ThenBy(x => x.FullName)
          .ToList();

        if (rsDto?.Count() > 0)
        {
          for (int i = 0; i < rsDto.Count; i++)
          {
            rsDto[i].No = i + 1;
          }
        }
      }  
      return rsDto;
    }
    
    public static List<MaterialDTO> ConvertMaterialToDTO(List<Product>? materials)
    {
      var result = new List<MaterialDTO>();
      if (materials == null) return result;
      if (materials?.Count > 0)
      {
        materials = materials.OrderBy(x => x.MaterialType).ThenBy(x => x.Group).ToList();

        int stt = 1;
        foreach (var material in materials)
        {
          string typeMaterial = EnumHelper.GetEnumDescription((EnumMaterialType)(material?.MaterialType));

          var dto = new MaterialDTO
          {
            Id = material?.Id,
            No = stt.ToString(),
            Code = material?.Code,
            TypeMaterial = typeMaterial,
            Type = $"{material?.Name}",
            Grade = material?.Grade ?? "",
            Unit = material?.Unit ?? "",
            LOT = material?.LOT ?? "",
            LossPercent = material?.LossPercent ?? "",
            ExpiredDate = material?.ExpiredDate ?? "",
            Note = material?.Note ?? "",
            Supplier = material?.Supplier ?? "",

            WeightConversion = Math.Round(material?.WeightConversion??0.0,5),

            CreatedAt = material?.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
            UpdatedAt = material?.UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
            MaterialSrc = material,
          };
          result.Add(dto);
          stt++;
        }
      }
      return result;
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
    (List<RecordFoods> laborProductivityRecognitions, string textSearch = "")
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
