using ApiSyncData.Resp;
using Newtonsoft.Json;

namespace ApiSyncData
{
  public class ApiService
  {
    public async Task<StationAPI> Station(bool isContainDelete = false)
    {
      try
      {
        string baseAPI = Environment.GetEnvironmentVariable("URL_API");
        string apiKey = Environment.GetEnvironmentVariable("API_KEY");

        var apiUrl =
          $"{baseAPI.TrimEnd('/')}/v1/Station/get-list-simplify?IsDeleted={isContainDelete}";

        using var httpClient = new HttpClient();

        // Giống cấu hình Authorization trong Postman:
        // API Key, Key = X-API-KEY, Add to = Header
        httpClient.DefaultRequestHeaders.Add(
            "X-API-KEY",
            apiKey.Trim());

        using var response = await httpClient.GetAsync(apiUrl);

        var responseContent =
            await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
          throw new HttpRequestException(
              $"Station. " +
              $"URL: {apiUrl}. " +
              $"HTTP {(int)response.StatusCode} " +
              $"({response.ReasonPhrase}). " +
              $"Response: {responseContent}");
        }

        return JsonConvert.DeserializeObject<StationAPI>(responseContent);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<WarehouseAPI> Warehouse(bool isContainDelete = false)
    {
      try
      {
        string baseAPI = Environment.GetEnvironmentVariable("URL_API");
        string apiKey = Environment.GetEnvironmentVariable("API_KEY");

        var apiUrl =
          $"{baseAPI.TrimEnd('/')}/v1/Warehouse/get-list-simplify?IsDeleted={isContainDelete}";

        using var httpClient = new HttpClient();

        // Giống cấu hình Authorization trong Postman:
        // API Key, Key = X-API-KEY, Add to = Header
        httpClient.DefaultRequestHeaders.Add(
            "X-API-KEY",
            apiKey.Trim());

        using var response = await httpClient.GetAsync(apiUrl);

        var responseContent =
            await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
          throw new HttpRequestException(
              $"Warehouse. " +
              $"URL: {apiUrl}. " +
              $"HTTP {(int)response.StatusCode} " +
              $"({response.ReasonPhrase}). " +
              $"Response: {responseContent}");
        }

        return JsonConvert.DeserializeObject<WarehouseAPI>(responseContent);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<TypeGoodsAPI> TypeGoods(bool isContainDelete = false)
    {
      try
      {
        string baseAPI = Environment.GetEnvironmentVariable("URL_API");
        string apiKey = Environment.GetEnvironmentVariable("API_KEY");

        var apiUrl =
          $"{baseAPI.TrimEnd('/')}/v1/TypeGoods/get-list-simplify?IsDeleted={isContainDelete}";

        using var httpClient = new HttpClient();

        // Giống cấu hình Authorization trong Postman:
        // API Key, Key = X-API-KEY, Add to = Header
        httpClient.DefaultRequestHeaders.Add(
            "X-API-KEY",
            apiKey.Trim());

        using var response = await httpClient.GetAsync(apiUrl);

        var responseContent =
            await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
          throw new HttpRequestException(
              $"TypeGoods. " +
              $"URL: {apiUrl}. " +
              $"HTTP {(int)response.StatusCode} " +
              $"({response.ReasonPhrase}). " +
              $"Response: {responseContent}");
        }

        return JsonConvert.DeserializeObject<TypeGoodsAPI>(responseContent);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<ProductGroupAPI> ProductGroup(bool isContainDelete = false)
    {
      try
      {
        string baseAPI = Environment.GetEnvironmentVariable("URL_API");
        string apiKey = Environment.GetEnvironmentVariable("API_KEY");

        var apiUrl =
          $"{baseAPI.TrimEnd('/')}/v1/ProductGroup/get-list-simplify?IsDeleted={isContainDelete}";

        using var httpClient = new HttpClient();

        // Giống cấu hình Authorization trong Postman:
        // API Key, Key = X-API-KEY, Add to = Header
        httpClient.DefaultRequestHeaders.Add(
            "X-API-KEY",
            apiKey.Trim());

        using var response = await httpClient.GetAsync(apiUrl);

        var responseContent =
            await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
          throw new HttpRequestException(
              $"ProductGroup. " +
              $"URL: {apiUrl}. " +
              $"HTTP {(int)response.StatusCode} " +
              $"({response.ReasonPhrase}). " +
              $"Response: {responseContent}");
        }

        return JsonConvert.DeserializeObject<ProductGroupAPI>(responseContent);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<ProductAPI> Product(bool isContainDelete = false)
    {
      try
      {
        string baseAPI = Environment.GetEnvironmentVariable("URL_API");
        string apiKey = Environment.GetEnvironmentVariable("API_KEY");

        var apiUrl =
          $"{baseAPI.TrimEnd('/')}/v1/ProductFood/get-list-simplify?IsDeleted={isContainDelete}";

        using var httpClient = new HttpClient();

        // Giống cấu hình Authorization trong Postman:
        // API Key, Key = X-API-KEY, Add to = Header
        httpClient.DefaultRequestHeaders.Add(
            "X-API-KEY",
            apiKey.Trim());

        using var response = await httpClient.GetAsync(apiUrl);

        var responseContent =
            await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
          throw new HttpRequestException(
              $"Product. " +
              $"URL: {apiUrl}. " +
              $"HTTP {(int)response.StatusCode} " +
              $"({response.ReasonPhrase}). " +
              $"Response: {responseContent}");
        }

        return JsonConvert.DeserializeObject<ProductAPI>(responseContent);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<CategoryTareAPI> CategoryTare(bool isContainDelete = false)
    {
      try
      {
        string baseAPI = Environment.GetEnvironmentVariable("URL_API");
        string apiKey = Environment.GetEnvironmentVariable("API_KEY");

        var apiUrl =
          $"{baseAPI.TrimEnd('/')}/v1/CategoryTare/get-list-simplify?IsDeleted={isContainDelete}";

        using var httpClient = new HttpClient();

        // Giống cấu hình Authorization trong Postman:
        // API Key, Key = X-API-KEY, Add to = Header
        httpClient.DefaultRequestHeaders.Add(
            "X-API-KEY",
            apiKey.Trim());

        using var response = await httpClient.GetAsync(apiUrl);

        var responseContent =
            await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
          throw new HttpRequestException(
              $"CategoryTare. " +
              $"URL: {apiUrl}. " +
              $"HTTP {(int)response.StatusCode} " +
              $"({response.ReasonPhrase}). " +
              $"Response: {responseContent}");
        }

        return JsonConvert.DeserializeObject<CategoryTareAPI>(responseContent);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<ClientAPI> Client(bool isContainDelete = false)
    {
      try
      {
        string baseAPI = Environment.GetEnvironmentVariable("URL_API");
        string apiKey = Environment.GetEnvironmentVariable("API_KEY");

        var apiUrl =
          $"{baseAPI.TrimEnd('/')}/v1/Client/get-list-simplify?IsDeleted={isContainDelete}";

        using var httpClient = new HttpClient();

        // Giống cấu hình Authorization trong Postman:
        // API Key, Key = X-API-KEY, Add to = Header
        httpClient.DefaultRequestHeaders.Add(
            "X-API-KEY",
            apiKey.Trim());

        using var response = await httpClient.GetAsync(apiUrl);

        var responseContent =
            await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
          throw new HttpRequestException(
              $"Client. " +
              $"URL: {apiUrl}. " +
              $"HTTP {(int)response.StatusCode} " +
              $"({response.ReasonPhrase}). " +
              $"Response: {responseContent}");
        }

        return JsonConvert.DeserializeObject<ClientAPI>(responseContent);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<UserAPI> User(bool isContainDelete = false)
    {
      try
      {
        string baseAPI = Environment.GetEnvironmentVariable("URL_API_AUTH");
        string apiKey = Environment.GetEnvironmentVariable("API_KEY");

        var apiUrl =
          $"{baseAPI.TrimEnd('/')}/v1/User/get-list-simplify?page=1&pageSize=20&searchStr=";
        using var httpClient = new HttpClient();

        // Giống cấu hình Authorization trong Postman:
        // API Key, Key = X-API-KEY, Add to = Header
        httpClient.DefaultRequestHeaders.Add(
            "X-API-KEY",
            apiKey.Trim());

        using var response = await httpClient.GetAsync(apiUrl);

        var responseContent =
            await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
          throw new HttpRequestException(
              $"User. " +
              $"URL: {apiUrl}. " +
              $"HTTP {(int)response.StatusCode} " +
              $"({response.ReasonPhrase}). " +
              $"Response: {responseContent}");
        }

        return JsonConvert.DeserializeObject<UserAPI>(responseContent);
      }
      catch (Exception)
      {
        throw;
      }
    }


  }
}
