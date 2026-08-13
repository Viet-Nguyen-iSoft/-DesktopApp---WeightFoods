using API;
using iSoft.Database.Models;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static HelperManager.EnumData;
using static LaborTrackPro.Helper.DTO;

namespace LaborTrackPro.Controls
{
  public partial class AppCore
  {
    private string _hostAPI;
    private string _baseAPI;
    private string _apiKey;
    public async Task<ResponMaxAllowedInternal> GetMaxWeightInternal(GetMaxAllowedInternal getMax)
    {
      try
      {
        using (var api = new ApiClient(_baseAPI, _apiKey))
        {
          //var result  = await api.PostJsonAsync<ResponMaxAllowedValueRequestModel>("v1/material/get-max-allowed-value", json);
         

          var formData = new Dictionary<string, string>
          {
              { "DataMachineId",getMax.DataMachineId.ToString() },
              { "ProductionOrderId", getMax.ProductionOrderId.ToString() },
              { "MaterialId", getMax.MaterialId.ToString() }
          };

          var result = await api.PostFormDataAsync(
              "v1/material/get-max-allowed-value-v3",
              formData);

          return JsonConvert.DeserializeObject<ResponMaxAllowedInternal>(result);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<ResponMaxAllowedExternal> GetMaxWeightExternal(GetMaxAllowedExternal getMax)
    {
      try
      {
        using (var api = new ApiClient(_baseAPI, _apiKey))
        {
          //var result  = await api.PostJsonAsync<ResponMaxAllowedValueRequestModel>("v1/material/get-max-allowed-value", json);


          var formData = new Dictionary<string, string>
          {
              { "DataMachineId",getMax.DataMachineId.ToString() },
              { "ProductionOrderId", getMax.ProductionOrderId.ToString() },
              { "MaterialId", getMax.MaterialId.ToString() },
              { "TypeData", getMax.TypeData.ToString() }
          };

          var result = await api.PostFormDataAsync(
              "v1/material/get-max-allowed-value-v3-for-external",
              formData);

          return JsonConvert.DeserializeObject<ResponMaxAllowedExternal>(result);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<RootDeliverySchedule> GetMaxWeightDeliverySchedule(GetMaxDeliverySchedule getMax)
    {
      try
      {
        using (var api = new ApiClient(_baseAPI, _apiKey))
        {
          //var result  = await api.PostJsonAsync<ResponMaxAllowedValueRequestModel>("v1/material/get-max-allowed-value", json);


          var formData = new Dictionary<string, string>
          {
              { "DataMachineId",getMax.DataMachineId.ToString() },
              { "DeliveryScheduleId", getMax.DeliveryScheduleId.ToString() },
              { "MaterialId", getMax.MaterialId.ToString() },
              { "TypeData", getMax.TypeData.ToString() }
          };

          var result = await api.PostFormDataAsync(
              "v1/material/get-max-allowed-value-v3-by-delivery-schedule",
              formData);

          return JsonConvert.DeserializeObject<RootDeliverySchedule>(result);
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public async Task<string> UploadWeightTicketPdf(
    Guid? poId,
    Guid? ticketId,
    string pdfFilePath)
    {
      if (!poId.HasValue || poId.Value == Guid.Empty)
        throw new ArgumentException(
            "poId không hợp lệ.",
            nameof(poId));

      if (!ticketId.HasValue || ticketId.Value == Guid.Empty)
        throw new ArgumentException(
            "ticketId không hợp lệ.",
            nameof(ticketId));

      if (string.IsNullOrWhiteSpace(pdfFilePath))
        throw new ArgumentException(
            "Đường dẫn file PDF không được để trống.",
            nameof(pdfFilePath));

      if (!File.Exists(pdfFilePath))
        throw new FileNotFoundException(
            "Không tìm thấy file PDF.",
            pdfFilePath);

      if (!string.Equals(
              Path.GetExtension(pdfFilePath),
              ".pdf",
              StringComparison.OrdinalIgnoreCase))
      {
        throw new ArgumentException(
            "File tải lên phải có định dạng PDF.",
            nameof(pdfFilePath));
      }

      if (string.IsNullOrWhiteSpace(_apiKey))
        throw new InvalidOperationException(
            "X-API-KEY chưa được cấu hình.");

      var apiUrl =
          $"{_baseAPI.TrimEnd('/')}/v1/WeightTicket/upload-pdf";

      using var httpClient = new HttpClient();
      using var formData = new MultipartFormDataContent();
      using var fileStream = File.OpenRead(pdfFilePath);
      using var fileContent = new StreamContent(fileStream);

      // Giống cấu hình Authorization trong Postman:
      // API Key, Key = X-API-KEY, Add to = Header
      httpClient.DefaultRequestHeaders.Add(
          "X-API-KEY",
          _apiKey.Trim());

      fileContent.Headers.ContentType =
          new MediaTypeHeaderValue("application/pdf");

      formData.Add(
          fileContent,
          "pdfFile",
          Path.GetFileName(pdfFilePath));

      formData.Add(
          new StringContent(poId.Value.ToString()),
          "poId");

      formData.Add(
          new StringContent(ticketId.Value.ToString()),
          "ticketId");

      using var response = await httpClient.PostAsync(
          apiUrl,
          formData);

      var responseContent =
          await response.Content.ReadAsStringAsync();

      if (!response.IsSuccessStatusCode)
      {
        throw new HttpRequestException(
            $"Upload PDF thất bại. " +
            $"URL: {apiUrl}. " +
            $"HTTP {(int)response.StatusCode} " +
            $"({response.ReasonPhrase}). " +
            $"Response: {responseContent}");
      }

      return responseContent;
    }



    ///
    public async Task<MaxValueCheckAlarm> GetMaxValueInternal(ProductionOrder? productionOrder, Machine? machine, Material? material,
                                                               Guid? departmentIdDelivery, Guid? departmentIdReceiving,
                                                               EnumTyCheckAlarm? enumTyCheck, bool mrDefect)
    {
      MaxValueCheckAlarm maxValueCheckAlarm = new MaxValueCheckAlarm();
      try
      {
        bool unvalid = productionOrder == null || machine == null || material == null;
        if (unvalid)
        {
          maxValueCheckAlarm.Status = EnumStatusCheckAlarm.LossInfor;
          return maxValueCheckAlarm;
        }

        GetMaxAllowedInternal getMaxAllowedInternal = new GetMaxAllowedInternal();
        getMaxAllowedInternal.ProductionOrderId = productionOrder?.IdSrc;
        getMaxAllowedInternal.DataMachineId = machine?.IdSrc;
        getMaxAllowedInternal.MaterialId = material?.IdSrc;

        var rs = await AppCore.Ins.GetMaxWeightInternal(getMaxAllowedInternal);

        double actual = 0.0;
        double actualReture = 0.0;
        double deviation = 0.0;
        double deviationReture = 0.0;
        bool checkalarm = false;

        if (rs.Status == "Success")
        {
          //PO có chế biến
          if (enumTyCheck == EnumTyCheckAlarm.PO_CheBien_Export)
          {
            // Giá trị cân được = Tổng cân dc - Sơ chế 
            //Phòng nhận hàng
            var departmentReceiving = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == departmentIdReceiving);
            var dataExport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Export).ToList();
            var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
            if (dataExport?.Count() > 0)
            {
              if (departmentReceiving?.EnumGroup != EnumGroup.SoChe)
              {
                foreach (var item in dataExport)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                  if (department?.EnumGroup != EnumGroup.SoChe)
                  {
                    actual += item.Actual;
                    deviation += item.Deviation;
                  }
                }
              }
              else
              {
                foreach (var item in dataExport)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                  if (department?.EnumGroup == EnumGroup.SoChe)
                  {
                    actual += item.Actual;
                    deviation += item.Deviation;
                  }
                }
              }
            }

            if (dataImport?.Count() > 0)
            {
              //Phòng nhận hàng
              if (departmentReceiving?.EnumGroup != EnumGroup.SoChe)
              {
                foreach (var item in dataImport)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                  if (department?.EnumGroup != EnumGroup.SoChe)
                  {
                    actualReture += item.Actual;
                    deviationReture += item.Deviation;
                  }
                }
              }
              else
              {
                foreach (var item in dataImport)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                  if (department?.EnumGroup == EnumGroup.SoChe)
                  {
                    actualReture += item.Actual;
                    deviationReture += item.Deviation;
                  }
                }
              }
            }

            checkalarm = (departmentReceiving?.EnumGroup != EnumGroup.SoChe);
          }
          else if (enumTyCheck == EnumTyCheckAlarm.PO_CheBien_Export_Internal)
          {
            var dataExportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ExportInternal).ToList();
            var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
            if (dataExportInternal?.Count() > 0)
            {
              foreach (var item in dataExportInternal)
              {
                var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                if (department?.IdSrc == departmentIdReceiving)
                {
                  actual += item.Actual;
                  deviation += item.Deviation;
                }
              }
            }
            if (dataImportInternal?.Count() > 0)
            {
              foreach (var item in dataImportInternal)
              {
                var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                if (department?.IdSrc == departmentIdDelivery)
                {
                  actualReture += item.Actual;
                  deviationReture += item.Deviation;
                }
              }
            }
          }
          else if (enumTyCheck == EnumTyCheckAlarm.PO_CheBien_Import)
          {
            if (!mrDefect)
            {
              var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
              var departmentDelivery = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == departmentIdDelivery);

              if (departmentDelivery?.EnumGroup != EnumGroup.SoChe && dataImport?.Count() > 0)
              {
                foreach (var item in dataImport)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                  if (department?.EnumGroup != EnumGroup.SoChe)
                  {
                    actual += item.Actual;
                    deviation += item.Deviation;
                  }
                }
              }
              else if (departmentDelivery?.EnumGroup == EnumGroup.SoChe && dataImport?.Count() > 0)
              {
                foreach (var item in dataImport)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                  if (department?.EnumGroup == EnumGroup.SoChe)
                  {
                    actual += item.Actual;
                    deviation += item.Deviation;
                  }
                }
              }
            }
            else
            {
              var dataImport = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
              var departmentDelivery = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == departmentIdDelivery);

              if (departmentDelivery?.EnumGroup != EnumGroup.SoChe && dataImport?.Count() > 0)
              {
                foreach (var item in dataImport)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                  if (department?.EnumGroup != EnumGroup.SoChe)
                  {
                    actual += item.Actual;
                    deviation += item.Deviation;
                  }
                }
              }
              else if (departmentDelivery?.EnumGroup == EnumGroup.SoChe && dataImport?.Count() > 0)
              {
                foreach (var item in dataImport)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                  if (department?.EnumGroup == EnumGroup.SoChe)
                  {
                    actual += item.Actual;
                    deviation += item.Deviation;
                  }
                }
              }

              checkalarm = departmentDelivery?.EnumGroup != EnumGroup.SoChe;
            }
          }
          else if (enumTyCheck == EnumTyCheckAlarm.PO_CheBien_Import_Internal)
          {
            if (!mrDefect)
            {
              var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
              if (dataImportInternal?.Count() > 0)
              {
                foreach (var item in dataImportInternal)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                  if (department?.IdSrc == departmentIdDelivery)
                  {
                    actual += item.Actual;
                    deviation += item.Deviation;
                  }
                }
              }
            }
            else
            {
              var dataImportInternal = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
              if (dataImportInternal?.Count() > 0)
              {
                foreach (var item in dataImportInternal)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                  if (department?.IdSrc == departmentIdDelivery)
                  {
                    actual += item.Actual;
                    deviation += item.Deviation;
                  }
                }
              }
            }
          }

          //PO ko chế biến
          if (enumTyCheck == EnumTyCheckAlarm.PO_SoChe_Export)
          {
            var dataExport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Export).ToList();
            var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
            if (dataExport?.Count() > 0)
            {
              foreach (var item in dataExport)
              {
                actual += item.Actual;
                deviation += item.Deviation;
              }
            }

            if (dataImport?.Count() > 0)
            {
              foreach (var item in dataImport)
              {
                actualReture += item.Actual;
                deviationReture += item.Deviation;
              }
            }

            checkalarm = true;
          }
          else if (enumTyCheck == EnumTyCheckAlarm.PO_SoChe_Export_Internal)
          {
            var dataExportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ExportInternal).ToList();
            var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
            if (dataExportInternal?.Count() > 0)
            {
              foreach (var item in dataExportInternal)
              {
                var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                if (department?.IdSrc == departmentIdReceiving)
                {
                  actual += item.Actual;
                  deviation += item.Deviation;
                }
              }
            }
            if (dataImportInternal?.Count() > 0)
            {
              foreach (var item in dataImportInternal)
              {
                var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                if (department?.IdSrc == departmentIdDelivery)
                {
                  actualReture += item.Actual;
                  deviationReture += item.Deviation;
                }
              }
            }
          }
          else if (enumTyCheck == EnumTyCheckAlarm.PO_SoChe_Import)
          {
            if (!mrDefect)
            {
              var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
              if (dataImport?.Count() > 0)
              {
                foreach (var item in dataImport)
                {
                  actual += item.Actual;
                  deviation += item.Deviation;
                }
              }
            }
            else
            {
              var dataImport = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
              if (dataImport?.Count() > 0)
              {
                foreach (var item in dataImport)
                {
                  actual += item.Actual;
                  deviation += item.Deviation;
                }
              }

              checkalarm = true;
            }
          }
          else if (enumTyCheck == EnumTyCheckAlarm.PO_SoChe_Import_Internal)
          {
            if (!mrDefect)
            {
              var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
              if (dataImportInternal?.Count() > 0)
              {
                foreach (var item in dataImportInternal)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                  if (department?.IdSrc == departmentIdDelivery)
                  {
                    actual += item.Actual;
                    deviation += item.Deviation;
                  }
                }
              }
            }
            else
            {
              var dataImportInternal = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
              if (dataImportInternal?.Count() > 0)
              {
                foreach (var item in dataImportInternal)
                {
                  var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                  if (department?.IdSrc == departmentIdDelivery)
                  {
                    actual += item.Actual;
                    deviation += item.Deviation;
                  }
                }
              }
            }
          }

          maxValueCheckAlarm.Status = EnumStatusCheckAlarm.Success;
          maxValueCheckAlarm.TolerancePerTon = rs?.Data?.DeviationOver1Ton ?? 0.0;
          maxValueCheckAlarm.ToleranceBelowTon = rs?.Data?.DeviationOver1Ton ?? 0.0;
          maxValueCheckAlarm.SettingInKg = mrDefect == false ? (rs?.Data?.SettingInKg ?? 0.0) : (rs?.Data?.WasteLossInKg ?? 0.0);
          maxValueCheckAlarm.TotalActualInKg = actual - actualReture;
          maxValueCheckAlarm.MaxValue = mrDefect == false ? Math.Round(((rs?.Data?.SettingInKg ?? 0.0) + (deviation + deviationReture) - (actual - actualReture)), 3) :
                                                            Math.Round(((double)(rs?.Data?.WasteLossInKg ?? 0.0) + (double)(deviation + deviationReture) - (double)(actual - actualReture)), 3);

          maxValueCheckAlarm.CheckAlarm = checkalarm;
          return maxValueCheckAlarm;
        }
        else
        {
          maxValueCheckAlarm.Status = EnumStatusCheckAlarm.Fail;
          return maxValueCheckAlarm;
        }
      }
      catch (Exception)
      {
        maxValueCheckAlarm.Status = EnumStatusCheckAlarm.Fail;
        return maxValueCheckAlarm;
      }
    }

    public async Task<MaxValueCheckAlarm> GetMaxValueExternal(ProductionOrder? productionOrder, Machine? machine, Material? material,
                                                             EnumExportImport? enumExportImport)
    {
      MaxValueCheckAlarm maxValueCheckAlarm = new MaxValueCheckAlarm();
      bool unvalid = productionOrder == null || machine == null || material == null || enumExportImport == null;
      if (unvalid)
      {
        maxValueCheckAlarm.Status = EnumStatusCheckAlarm.LossInfor;
        return maxValueCheckAlarm;
      }

      GetMaxAllowedExternal getMaxAllowedExternal = new GetMaxAllowedExternal();
      getMaxAllowedExternal.ProductionOrderId = productionOrder?.IdSrc;
      getMaxAllowedExternal.DataMachineId = machine?.IdSrc;
      getMaxAllowedExternal.MaterialId = material?.IdSrc;
      getMaxAllowedExternal.TypeData = enumExportImport;

      var rs = await AppCore.Ins.GetMaxWeightExternal(getMaxAllowedExternal);
      if (rs.Status == "Success")
      {
        maxValueCheckAlarm.Status = EnumStatusCheckAlarm.Success;
        maxValueCheckAlarm.TolerancePerTon = rs?.Data?.DeviationOver1Ton ?? 0.0;
        maxValueCheckAlarm.ToleranceBelowTon = rs?.Data?.DeviationOver1Ton ?? 0.0;
        maxValueCheckAlarm.SettingInKg = rs?.Data?.SettingInKg ?? 0.0;
        maxValueCheckAlarm.TotalActualInKg = rs?.Data?.Actual ?? 0.0;
        maxValueCheckAlarm.MaxValue = Math.Round(((rs?.Data?.SettingInKg ?? 0.0) - (rs?.Data?.Actual ?? 0.0)), 3);
        maxValueCheckAlarm.CheckAlarm = true;
      }
      else
      {
        maxValueCheckAlarm.Status = EnumStatusCheckAlarm.Fail;
        maxValueCheckAlarm.CheckAlarm = true;
      }
      return maxValueCheckAlarm;
    }
  }

  public class GetMaxAllowedInternal
  {
    public Guid? ProductionOrderId { get; set; }

    public Guid? MaterialId { get; set; }

    public Guid? DataMachineId { get; set; }
  }

  public class ResponMaxAllowedInternal
  {
    public string? Status { get; set; }
    public DataInternal? Data { get; set; }
  }

  public class DataInternal
  {
    public DateTime ExecuteAt { get; set; }
    public Guid ProductionOrderId { get; set; }
    public Guid MaterialId { get; set; }
    public Guid DataMachineId { get; set; }
    public double DeviationOver1Ton { get; set; }
    public double DeviationUnder1Ton { get; set; }
    public double SettingInKg { get; set; }
    public double WasteLossInKg { get; set; }
    public List<DataByDepartment>? DataNormalByDepartments { get; set; }
    public List<DataByDepartment>? DataLossByDepartments { get; set; }
    public Guid msgId { get; set; }
  }

  public class DataByDepartment
  {
    public EnumTypeData EnumTypeData { get; set; }
    public Guid? ReceiveDepartmentId { get; set; }
    public Guid? DeliverDepartmentId { get; set; }
    public double Actual { get; set; }
    public double Deviation { get; set; }
  }

  public enum EnumTypeData
  {
    Import = 1,
    Export,
    ImportInternal,
    ExportInternal,
  }



  ///// Ngoaij vi
  public class GetMaxAllowedExternal
  {
    public Guid? ProductionOrderId { get; set; }

    public Guid? MaterialId { get; set; }

    public Guid? DataMachineId { get; set; }
    public EnumExportImport? TypeData { get; set; }
  }

  public class GetMaxDeliverySchedule
  {
    public Guid? DeliveryScheduleId { get; set; }

    public Guid? MaterialId { get; set; }

    public Guid? DataMachineId { get; set; }

    public EnumExportImport? TypeData { get; set; }
  }

  public class ResponMaxAllowedExternal
  {
    public string? Status { get; set; }
    public DataExternal? Data { get; set; }
  }

  public class DataExternal
  {
    public DateTime ExecuteAt { get; set; }
    public Guid ProductionOrderId { get; set; }
    public Guid MaterialId { get; set; }
    public Guid DataMachineId { get; set; }
    public EnumExportImport TypeData { get; set; }
    public double DeviationOver1Ton { get; set; }
    public double DeviationUnder1Ton { get; set; }
    public double SettingInKg { get; set; }
    public double Actual { get; set; }
    public double Deviation { get; set; }
    public Guid msgId { get; set; }
  }



  // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
  public class DataDeliverySchedule
  {
    public DateTime? ExecuteAt { get; set; }
    public Guid? ProductionOrderId { get; set; }
    public Guid? DeliveryScheduleId { get; set; }
    public Guid? MaterialId { get; set; }
    public Guid? DataMachineId { get; set; }
    public double DeviationOver1Ton { get; set; }
    public double DeviationUnder1Ton { get; set; }
    public double SettingInKg { get; set; }
    public double WasteLossInKg { get; set; }
    public List<DataByDepartment>? DataNormalByDepartments { get; set; }
    public List<DataByDepartment>? DataLossByDepartments { get; set; }
    public Guid? msgId { get; set; }
  }

  public class RootDeliverySchedule
  {
    public string? Status { get; set; }
    public DataDeliverySchedule? Data { get; set; }
  }



}
