namespace LaborTrackPro.Communication
{
  public class TcpClientJson
  {
    public string? IP { get; set; } = "127.0.0.1";
    public int? Port { get; set; } = 502;
    public int? Timeout { get; set; } = 500;
    public int? TimeConnect { get; set; } = 1000;
    public int? SampleTime { get; set; } = 200;
  }
}
