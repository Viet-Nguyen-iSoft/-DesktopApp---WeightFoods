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
