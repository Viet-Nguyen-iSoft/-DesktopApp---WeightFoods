using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborTrackPro.ApiHelper
{
  public class ApiHelper
  {
    private static readonly HttpClient client = new HttpClient();

    /// <summary>
    /// Gọi API kiểu GET
    /// </summary>
    public static async Task<string> GetAsync(string url)
    {
      var response = await client.GetAsync(url);
      response.EnsureSuccessStatusCode();
      int status = (int)response.StatusCode;
      return await response.Content.ReadAsStringAsync();
      
      //return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// Gọi API kiểu POST (với body dạng JSON)
    /// </summary>
    public static async Task<string> PostAsync(string url, string jsonData)
    {
      var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var response = await client.PostAsync(url, content);
      response.EnsureSuccessStatusCode();
      return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// Gọi API kiểu PUT (với body dạng JSON)
    /// </summary>
    public static async Task<string> PutAsync(string url, string jsonData)
    {
      var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var response = await client.PutAsync(url, content);
      response.EnsureSuccessStatusCode();
      return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// Gọi API kiểu DELETE
    /// </summary>
    public static async Task<string> DeleteAsync(string url)
    {
      var response = await client.DeleteAsync(url);
      response.EnsureSuccessStatusCode();
      return await response.Content.ReadAsStringAsync();
    }
  }
}
