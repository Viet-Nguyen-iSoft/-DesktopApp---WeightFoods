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
    public static List<ProductionOrderDTO> ConvertPOToDTO(List<ProductionOrder> productionOrders)
    {
      //DateTime now = DateTime.Now;
      //return productionOrders
      //    .Select((e, index) => new ProductionOrderDTO
      //    {
      //      Id = e?.Id,
      //      No = index + 1,
      //      Name = e?.Name,
      //      Type = e?.eTypeOrderProduction == EnumTypeProductionOrder.ProductionOrder ? "Lệnh sản xuất" : "Khác",
      //      Warning = e?.WarningStatus switch
      //                {
      //                  1 => "Bình thường",
      //                  2 => "Cảnh báo",
      //                  _ => "N/A"
      //                },
      //      MaterialNumbers = e?.Materials.Count()??0,
      //      Datetime = e?.EffectiveFrom?.ToString("dd/MM/yyyy") + " - " + e?.EffectiveTo?.ToString("dd/MM/yyyy"),
      //      UpdatedAt = e?.UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss"),

      //      Status = e?.ApproveStatus switch
      //      {
      //        1 => "Chưa duyệt",
      //        2 => "Đã duyệt",
      //        3 => "Từ chối",
      //        _ => "N/A"
      //      },
      //    })
      //    .ToList();

      return null;
    }

    public static List<ProductionDTO> ConvertProductionToDTO(List<Production>? productions)
    {
      if (productions == null) return new List<ProductionDTO>();
      return productions
          .Select((e, index) => new ProductionDTO
          {
            No = index + 1,
            Name = e.Name,
            Code = e.Code,
            Description = e.Description,
            MaterialNumbers = e.Materials.Count,
            CreatedAt = e.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"),
            UpdatedAt = e.UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss"),
            Id = e.Id
          })
          .ToList();
    }

    public static EnumStatusDataPO StatusPO(ProductionOrder? productionOrder, DateTime now)
    {
      if (productionOrder!=null)
      {
        if (productionOrder.ApproveStatus != 2) return EnumStatusDataPO.NotAprove;
        if (productionOrder.EffectiveFrom == null || productionOrder.EffectiveTo == null) return EnumStatusDataPO.None;

        if (now < productionOrder.EffectiveFrom.Value) return EnumStatusDataPO.NotStarted;
        if (now >= productionOrder.EffectiveFrom.Value && now <= productionOrder.EffectiveTo.Value) return EnumStatusDataPO.Active;
        return EnumStatusDataPO.Expired;
      }  
      return EnumStatusDataPO.None;
    }



    public static List<MaterialDTO> ConvertMaterialToDTO(List<Material>? materials)
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

    public static List<DatalogDetailDTO> ConvertDatalogDetailDTO
      (List<DatalogWeight> laborProductivityRecognitions, string textSearch = "")
    {
      textSearch = TextHelper.RemoveDiacritics(textSearch.Trim().ToLower());
      var rs = laborProductivityRecognitions
          .Select((e, index) => new DatalogDetailDTO
          {
            Id = e.Id,
            DatalogWeight = e,
            Gross = (float)Math.Round(e.Tare + e.Net, 2),
            Net = (float)Math.Round(e.Net, 2),
            Tare = (float)Math.Round(e.Tare, 2),
            ProductionOrder = e?.ProductionOrder?.Name ?? "",
            MaterialGroup = e?.Material?.MaterialType switch
            {
              0 => "N/A",
              1 => "Nguyên Liệu",
              2 => "Vật tư",
              3 => "Thành phẩm",
              4 => "Bán thành phẩm",
              5 => "Gia vị",
              6=> "Hóa chất",
              7=> "Phế phẩm",
              8=> "TS CCDC",
              _ => "N/A",
            },
            MaterialName = e?.Material?.Group??"" ,
            MaterialType = e?.Material?.Name ?? "",

            Employee = e?.Employee?.FullName ?? "",
            Created = e?.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"),

          })
          .Where(x =>
            string.IsNullOrEmpty(textSearch) ||
            TextHelper.RemoveDiacritics(x.Employee).ToLower().Contains(textSearch) ||
            TextHelper.RemoveDiacritics(x.MaterialGroup).Trim().ToLower().Contains(textSearch) ||
            TextHelper.RemoveDiacritics(x.MaterialType).Trim().ToLower().Contains(textSearch) ||
            TextHelper.RemoveDiacritics(x.MaterialName).Trim().ToLower().Contains(textSearch) ||
            TextHelper.RemoveDiacritics(x.ProductionOrder).Trim().ToLower().Contains(textSearch)
          )
          .OrderByDescending(x=>x.Created)
          .ToList();
      for (int i = 0; i < rs.Count; i++)
      {
        rs[i].No = i + 1;
      }
      return rs;
    }

    public static List<DatalogDetailDeleteDTO> ConvertDatalogDetailDeleteDTO
      (List<DatalogWeight> laborProductivityRecognitions, string textSearch = "")
    {
      textSearch = TextHelper.RemoveDiacritics(textSearch.Trim().ToLower());
      var rs = laborProductivityRecognitions
          .Select((e, index) => new DatalogDetailDeleteDTO
          {
            Id = e.Id,
            Gross = (float)Math.Round(e.Tare + e.Net, 2),
            Net = (float)Math.Round(e.Net, 2),
            Tare = (float)Math.Round(e.Tare, 2),
            ProductionOrder = e?.ProductionOrder?.Name ?? "N/A",
            MaterialGroup = e?.Material?.MaterialType switch
            {
              0 => "N/A",
              1 => "Nguyên Liệu",
              2 => "Vật tư",
            },
            MaterialName = e?.Material?.Group ?? "N/A",
            MaterialType = e?.Material?.Name ?? "N/A",

            Employee = e?.Employee?.FullName ?? "N/A",
            Created = e.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"),
            Updated = e.UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss"),
            Updatedby = e.UpdatedBy,

          })
          .Where(x =>
            string.IsNullOrEmpty(textSearch) ||
            TextHelper.RemoveDiacritics(x.Employee).ToLower().Contains(textSearch) ||
            TextHelper.RemoveDiacritics(x.MaterialGroup).Trim().ToLower().Contains(textSearch) ||
            TextHelper.RemoveDiacritics(x.MaterialType).Trim().ToLower().Contains(textSearch) ||
            TextHelper.RemoveDiacritics(x.MaterialName).Trim().ToLower().Contains(textSearch) ||
            TextHelper.RemoveDiacritics(x.ProductionOrder).Trim().ToLower().Contains(textSearch)
          )
          .ToList();
      for (int i = 0; i < rs.Count; i++)
      {
        rs[i].No = i + 1;
      }
      return rs;
    }




    public static List<DatalogOperationGroupDTO> ConvertDatalogOperationGroup
    (List<DatalogWeight> laborProductivityRecognitions, string textSearch = "")
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


    public static List<DatalogPOGroupDTO> ConvertDatalogProductionOrder
    (List<DatalogWeight> laborProductivityRecognitions, string textSearch)
    {
      textSearch = TextHelper.RemoveDiacritics(textSearch).Trim().ToLower();
      var dto = laborProductivityRecognitions
              .GroupBy(r => new
              {
                r.ProductionOrder,
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
                g.Key.ProductionOrder,
                //g.Key.MaterialType,
                //g.Key.MaterialGroup,
                //g.Key.MaterialName,

                //MaterialKey = g.MaterialId ?? r.MaterialId,
                //MaterialGroup = r.Material.MaterialType switch
                //{
                //  0 => "N/A",
                //  1 => " Nguyên liệu",
                //  2 => " Vật tư",
                //},
                //MaterialType = r.Material != null ? r.Material.Group : r.Material?.Group,
                //MaterialName = r.Material != null ? r.Material.Type : r.Material?.Type
                TotalWeight = (float)Math.Round(g.Sum(x => x.Net), 2),
              })
              .ToList();
      return dto
            .Where(x =>
            string.IsNullOrEmpty(textSearch) ||
            TextHelper.RemoveDiacritics(x.ProductionOrder.Name).Trim().ToLower().Contains(textSearch) //||
            //TextHelper.RemoveDiacritics(x.MaterialGroup).Trim().ToLower().Contains(textSearch)||
            //TextHelper.RemoveDiacritics(x.MaterialType).Trim().ToLower().Contains(textSearch) ||
            //TextHelper.RemoveDiacritics(x.MaterialName).Trim().ToLower().Contains(textSearch)
            )
            .OrderBy(x => x.ProductionOrder.Name)
            .Select((e, index) => new DatalogPOGroupDTO
            {
              No = index + 1, // STT bắt đầu từ 1
              ProductionOrder = e.ProductionOrder.Name,
              //MaterialGroup = e.MaterialGroup,
              //MaterialType = e.MaterialType,
              //MaterialName = e.MaterialName,
              RangeTime = e.RangeTimeStr,
              Total = e.TotalWeight,
            })
            .ToList();
    }

    public static List<MachineDTO> ConvertMachineToDTO(List<Machine> Machine)
    {
      var rs= Machine
          .Select((e, index) => new MachineDTO
          {
            Id = e.Id,
            No = index + 1,
            Name = e.Name,
            MachineName = e.Factory?.Name??"N/A",
            CreatedAt = e.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? "N/A",
            UpdatedAt = e.UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? "N/A",
            Enable = e.EnableFlag
          })
          .OrderBy(x => x.MachineName).ThenBy(x => x.Name)
          .ToList();

      for (int i = 0; i < rs.Count; i++)
      {
        rs[i].No = i + 1;
      }
      return rs;
    }
    
    public static List<MaterialDeliveryDTO> ConvertRecordToDeliveryDTO(List<DatalogWeight>? records)
    {
      List<MaterialDeliveryDTO> materialDeliveryDTOs = new List<MaterialDeliveryDTO>();
      if (records?.Count>0)
      {
        records = records.OrderBy(x=>x.MaterialId).ThenBy(x=>x.CreatedAt).ToList();
        int index = 1;
        EnumInternalExternalStatus? enumInternalExternal = records.FirstOrDefault()?.InternalExternalStatus;
        foreach (var record in records)
        {
          string name = "";
          string code = "";
          string description = "";
          string unit = "";
          string materialType = "";
          if (record.Material != null)
          {
            if (record.eTypeRecord == eTypeRecord.Defective)
            {
              if (record?.MaterialDefect!=null)
              {
                materialType = "Phế phẩm";
                name = (record?.MaterialDefect?.Name ?? "");// + " " + (record?.MaterialDefect?.Grade ?? "");
                code = record?.MaterialDefect?.Code ?? "";
                description = record?.MaterialDefect?.Grade ?? "";
                unit = record?.MaterialDefect?.Unit ?? "";
              }
            }
            else
            {
              if (record?.Material.MaterialType == (int)EnumMaterialType.RawMaterial)
              {
                materialType = "Nguyên liệu";
              }
              else if (record?.Material.MaterialType == (int)EnumMaterialType.Material)
              {
                materialType = "Vật tư";
              }
              else if (record?.Material.MaterialType == (int)EnumMaterialType.SemiFinishedGoods)
              {
                materialType = "Bán thành phẩm";
              }
              else if (record?.Material.MaterialType == (int)EnumMaterialType.FinshGoods)
              {
                materialType = "Thành phẩm";
              }

              name = (record?.Material?.Name ?? ""); // + " " +(record?.Material?.Grade?? "");
              code = record?.Material?.Code ?? "";
              description = record?.Material?.Grade ?? "";
              unit = record?.Material?.Unit ?? "";
            }  
          }
          else if (record.Production != null)
          {
            materialType = "Thành phẩm";
            name = (record?.Production?.Name ?? "");
            code = record?.Production?.Code ?? "";
            unit = "Kg";
          }

          string importExportStatus =  string.Empty;
          if (enumInternalExternal == EnumInternalExternalStatus.Internal)
          {
            importExportStatus = record?.eExportImport == EnumExportImport.Import ? "Trả hàng" : "Nhận hàng";
          }
          else if (enumInternalExternal == EnumInternalExternalStatus.External)
          {
            importExportStatus = record?.eExportImport == EnumExportImport.Import ? "Nhập hàng" : "Xuất hàng";
          }

          double conversion = record?.Material?.WeightConversion ?? 0.0;
          double quality = conversion > 0 ? ((record?.Net ?? 0.0) / conversion) : 0.0;
          quality = Math.Round(quality, 0, MidpointRounding.AwayFromZero);

          MaterialDeliveryDTO deliveryDTO = new MaterialDeliveryDTO
            {
              DatalogWeight = record,
              Material = record?.Material,
              MaterialDefect = record?.MaterialDefect,
              CreatedAtStr = record?.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
              CreatedAt = record?.CreatedAt,
              Operator = record?.Employee?.FullName ?? "",
              ProductionOrder = record?.ProductionOrder?.Name ?? "",
              MaterialType = materialType ?? "",
              NameMaterial = name,
              CodeMaterial = code,
              DescriptionMaterial = description,
              Unit = unit,
              Quality = quality.ToString(),
              QualityValue = quality,
              ImportExportStatus = importExportStatus,
              eExportImport = record?.eExportImport ?? EnumExportImport.None,
              Gross = Math.Round((record?.Net ?? 0.0) + (record?.Tare ?? 0.0), 3).ToString("F3"),
              Net = Math.Round(record?.Net ?? 0.0, 3).ToString("F3"),
              GrossValue = Math.Round((record?.Net ?? 0.0) + (record?.Tare ?? 0.0), 3),
              NetValue = Math.Round(record?.Net ?? 0.0, 3),
              Tare = Math.Round(record?.Tare ?? 0.0, 3).ToString("F3"),
            };
          materialDeliveryDTOs.Add(deliveryDTO);
        }  
      }  
      return materialDeliveryDTOs;
    }

    public static List<SettingLabelDTO>? ConvertSettingLabelDTO(List<SettingLabel>? settingLabels)
    {
      var rs = new List<SettingLabelDTO>();
      if (settingLabels?.Count()>0)
      {
        settingLabels = settingLabels?.OrderBy(x => x.Name).ToList();
        rs = settingLabels?
            .Select((e, index) => new SettingLabelDTO
            {
              Id = e.Id,
              SettingLabel = e,
              No = index + 1,
              Name = e.Name,
              NumverCopy = e?.NumberCopy ?? 0,
              CreatedAt = e?.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? "N/A",
              UpdatedAt = e?.UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? "N/A",
            })
            .ToList();
      }
      return rs;
    }

    
  }
}
