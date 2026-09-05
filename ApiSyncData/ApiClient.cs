using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiSyncData
{
  public class ApiClient : IDisposable
  {
    private readonly HttpClient _http;
    private readonly int _retryCount;

    public string BaseUrl { get; }
    public string BearerToken { get; set; }

    public ApiClient(string baseUrl, string apiKey, int timeoutSeconds = 30, int retryCount = 2)
    {
      try
      {
        BaseUrl = baseUrl.TrimEnd('/');
        _retryCount = retryCount;

        _http = new HttpClient
        {
          Timeout = TimeSpan.FromSeconds(timeoutSeconds)
        };

        //_http.DefaultRequestHeaders.Add("x-api-key", "3c6987ac-09cb-4f4d-8232-5b885324b21b");
        //_http.DefaultRequestHeaders.Add("x-api-key", apiKey);
      }
      catch (Exception)
      {
        throw;
      }
    }
    #region Core

    private async Task<T> SendAsync<T>(
        HttpMethod method,
        string url,
        object body = null,
        Dictionary<string, string> headers = null)
    {
      int retry = 0;

      while (true)
      {
        try
        {
          using (var request = new HttpRequestMessage(method, $"{BaseUrl}/{url}"))
          {
            if (!string.IsNullOrEmpty(BearerToken))
              request.Headers.Authorization =
                  new AuthenticationHeaderValue("Bearer", BearerToken);

            if (headers != null)
              foreach (var h in headers)
                request.Headers.Add(h.Key, h.Value);

            if (body != null)
            {
              string json = JsonConvert.SerializeObject(body);
              request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var response = await _http.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
              throw new Exception($"HTTP {(int)response.StatusCode}: {content}");

            if (typeof(T) == typeof(string))
              return (T)(object)content;

            return JsonConvert.DeserializeObject<T>(content);
          }
        }
        catch
        {
          retry++;
          if (retry > _retryCount)
            throw;

          await Task.Delay(500);
        }
      }
    }

    #endregion

    #region Methods

    //public Task<T> GetAsync<T>(string url)
    //    => SendAsync<T>(HttpMethod.Get, $"{BaseUrl}/{url}");

    //public Task<T> PostAsync<T>(string url, object body)
    //    => SendAsync<T>(HttpMethod.Post, url, body);

    //public Task<T> PutAsync<T>(string url, object body)
    //    => SendAsync<T>(HttpMethod.Put, url, body);

    //public Task<T> DeleteAsync<T>(string url)
    //    => SendAsync<T>(HttpMethod.Delete, url);

    public Task<T> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
    {
      return SendGetAsync<T>(HttpMethod.Get, url, null, headers);
    }

    private async Task<T> SendGetAsync<T>(
    HttpMethod method,
    string url,
    object? body = null,
    Dictionary<string, string>? headers = null)
    {
      int retry = 0;
      string fullUrl = $"{BaseUrl}/{url.TrimStart('/')}";

      while (true)
      {
        try
        {
          using (var request = new HttpRequestMessage(method, fullUrl))
          {
            // Bearer token
            if (!string.IsNullOrWhiteSpace(BearerToken))
            {
              request.Headers.Authorization =
                  new AuthenticationHeaderValue("Bearer", BearerToken);
            }

            // Custom headers
            if (headers != null)
            {
              foreach (var h in headers)
              {
                request.Headers.Remove(h.Key); // tránh duplicate
                request.Headers.Add(h.Key, h.Value);
              }
            }

            // Body (POST, PUT...)
            if (body != null)
            {
              string json = JsonConvert.SerializeObject(body);
              request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            // Send request
            using (var response = await _http.SendAsync(request))
            {
              string content = await response.Content.ReadAsStringAsync();

              //if (!response.IsSuccessStatusCode)
              //{
              //  throw new HttpRequestException(
              //      $"[{(int)response.StatusCode}] {response.ReasonPhrase} - {content}");
              //}

              // Nếu trả string
              if (typeof(T) == typeof(string))
              {
                return (T)(object)content;
              }

              // Nếu empty
              if (string.IsNullOrWhiteSpace(content))
              {
                return default!;
              }

              return JsonConvert.DeserializeObject<T>(content)!;
            }
          }
        }
        catch (Exception ex)
        {
          retry++;

          if (retry > _retryCount)
          {
            throw new Exception($"Call API failed after {retry} attempts: {fullUrl}", ex);
          }

          // delay retry (có thể exponential nếu thích)
          await Task.Delay(500 * retry);
        }
      }
    }



    public async Task<T> PostJsonAsync<T>(string url, string json)
    {
      //using (var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseUrl}/{url}"))
      //{
      //  if (!string.IsNullOrEmpty(BearerToken))
      //    request.Headers.Authorization =
      //        new AuthenticationHeaderValue("Bearer", BearerToken);

      //  request.Content = new StringContent(json, Encoding.UTF8, "application/json");

      //  var response = await _http.SendAsync(request);
      //  var content = await response.Content.ReadAsStringAsync();

      //  //if (!response.IsSuccessStatusCode)
      //  //  throw new Exception($"HTTP {(int)response.StatusCode}: {content}");

      //  if (typeof(T) == typeof(string))
      //    return (T)(object)content;

      //  return JsonConvert.DeserializeObject<T>(content);
      //}

      using (var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseUrl}/{url}"))
      {
        if (!string.IsNullOrEmpty(BearerToken))
          request.Headers.Authorization =
              new AuthenticationHeaderValue("Bearer", BearerToken);

        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _http.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        if (typeof(T) == typeof(string))
          return (T)(object)content;

        return JsonConvert.DeserializeObject<T>(content);
      }
    }

    public async Task<string> PostFormDataAsync(
     string url,
     Dictionary<string, string> formData)
    {
      using (var content = new MultipartFormDataContent())
      {
        foreach (var item in formData)
        {
          content.Add(new StringContent(item.Value), item.Key);
        }

        using (var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"{BaseUrl}/{url}"))
        {
          if (!string.IsNullOrEmpty(BearerToken))
          {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", BearerToken);
          }

          request.Content = content;

          var response = await _http.SendAsync(request);
          var responseContent = await response.Content.ReadAsStringAsync();

          if (!response.IsSuccessStatusCode)
          {
            throw new Exception(
                $"HTTP {(int)response.StatusCode}\r\n{responseContent}");
          }

          return responseContent;
        }
      }
    }

    #endregion

    #region Upload File

    public async Task<T> UploadFileAsync<T>(
        string url,
        string filePath,
        string formName = "file")
    {
      using (var content = new MultipartFormDataContent())
      {
        var fileContent = new StreamContent(File.OpenRead(filePath));
        content.Add(fileContent, formName, Path.GetFileName(filePath));

        var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseUrl}/{url}")
        {
          Content = content
        };

        if (!string.IsNullOrEmpty(BearerToken))
          request.Headers.Authorization =
              new AuthenticationHeaderValue("Bearer", BearerToken);

        var response = await _http.SendAsync(request);

        var result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
          throw new Exception(result);

        return JsonConvert.DeserializeObject<T>(result);
      }
    }

    #endregion

    public void Dispose()
    {
      _http?.Dispose();
    }

    public Task<string> GetAvailableLotCodeAsync(int type)
    {
      string url =
          $"v1/LaborProductivityRecognition/get-available-lot-code?type={type}";

      return GetAsync<string>(url);
    }
  }
}
