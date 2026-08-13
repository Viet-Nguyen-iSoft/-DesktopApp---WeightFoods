
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API
{
  public static class ApiGetRelease
  {
    // Thay thông tin của bạn
    private const string Owner = "Viet-Nguyen-iSoft";
    private const string Repo = "HSF.PreWeight";

    // PAT của bạn
    private const string Token = "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";

    //public static async Task<GitHubReleaseDTO?> GetLatestReleaseAsync()
    //{
    //  using HttpClient client = new();

    //  client.DefaultRequestHeaders.UserAgent.ParseAdd("LaborTrackPro");

    //  client.DefaultRequestHeaders.Authorization =
    //      new AuthenticationHeaderValue("Bearer", Token);

    //  var url = $"https://api.github.com/repos/{Owner}/{Repo}/releases/latest";

    //  var response = await client.GetAsync(url);

    //  if (!response.IsSuccessStatusCode)
    //    return null;

    //  var json = await response.Content.ReadAsStringAsync();

    //  return JsonSerializer.Deserialize<GitHubReleaseDTO>(json);
    //}

    public static async Task<GitHubReleaseDTO?> GetLatestReleaseAsync()
    {
      using HttpClient client = new();

      client.DefaultRequestHeaders.UserAgent.ParseAdd("LaborTrackPro");

      client.DefaultRequestHeaders.Authorization =
          new AuthenticationHeaderValue("Bearer", Token);


      // Lấy release mới nhất
      var url =
          $"https://api.github.com/repos/{Owner}/{Repo}/releases/latest";


      var response = await client.GetAsync(url);


      if (!response.IsSuccessStatusCode)
        return null;


      var json =
          await response.Content.ReadAsStringAsync();


      var release =
          JsonSerializer.Deserialize<GitHubReleaseDTO>(
              json,
              new JsonSerializerOptions
              {
                PropertyNameCaseInsensitive = true
              });


      if (release == null)
        return null;



      // Lấy commit của release
      var commitUrl =
          $"https://api.github.com/repos/{Owner}/{Repo}/commits?sha={release.TagName}";


      var commitResponse =
          await client.GetAsync(commitUrl);


      if (commitResponse.IsSuccessStatusCode)
      {
        var commitJson =
            await commitResponse.Content.ReadAsStringAsync();


        var commits =
            JsonSerializer.Deserialize<List<GitHubCommitDTO>>(
                commitJson,
                new JsonSerializerOptions
                {
                  PropertyNameCaseInsensitive = true
                });


        release.CommitMessage =
            commits?
            .FirstOrDefault()?
            .Commit.Message;
      }


      return release;
    }

    public static async Task<bool> DownloadReleaseAsync(
    GitHubReleaseDTO release,
    string savePath)
    {
      var asset = release.Assets
          .FirstOrDefault(x =>
              x.Name.EndsWith(".zip",
              StringComparison.OrdinalIgnoreCase));


      if (asset == null)
        return false;



      using HttpClient client = new();


      client.DefaultRequestHeaders.UserAgent.ParseAdd(
          "LaborTrackPro");


      client.DefaultRequestHeaders.Authorization =
          new AuthenticationHeaderValue(
              "Bearer",
              Token);


      client.DefaultRequestHeaders.Accept.ParseAdd(
          "application/octet-stream");



      string url =
          $"https://api.github.com/repos/{Owner}/{Repo}/releases/assets/{asset.Id}";



      var response =
          await client.GetAsync(url);



      if (!response.IsSuccessStatusCode)
      {
        Console.WriteLine(response.StatusCode);
        Console.WriteLine(
            await response.Content.ReadAsStringAsync());

        return false;
      }



      await using var stream =
          await response.Content.ReadAsStreamAsync();


      await using var file =
          File.Create(savePath);


      await stream.CopyToAsync(file);


      return true;
    }

    public static Version GetCurrentVersion()
    {
      var version =
          Assembly.GetExecutingAssembly()
          .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
          .InformationalVersion;


      if (string.IsNullOrEmpty(version))
        return new Version(1, 0, 0);


      // bỏ phần +commit
      version = version.Split('+')[0];


      return Version.Parse(version);
    }

  }

  public class GitHubReleaseDTO
  {
    [JsonPropertyName("tag_name")]
    public string TagName { get; set; } = "";


    [JsonPropertyName("body")]
    public string Body { get; set; } = "";


    public string? CommitMessage { get; set; }


    [JsonPropertyName("assets")]
    public List<GitHubAssetDTO> Assets { get; set; } = new();
  }


  public class GitHubAssetDTO
  {
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("browser_download_url")]
    public string BrowserDownloadUrl { get; set; } = "";
  }

  public class GitHubCommitDTO
  {
    public GitHubCommitInfoDTO Commit { get; set; } = new();
  }


  public class GitHubCommitInfoDTO
  {
    public string Message { get; set; } = "";
  }
}
