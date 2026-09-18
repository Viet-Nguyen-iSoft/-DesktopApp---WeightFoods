using HelperManager;
using iSoft.Communication.Communication;
using iSoft.Communication.Interface;
using iSoft.Communication.JsonPayload;
using System.Net.NetworkInformation;
using static HelperManager.EnumData;
using static iSoft.Communication.EnumCommunication;

namespace LTP.Truck.Controls
{
  public partial class AppCore
  {
    public event EventHandler<MessageDataOutput>? OnSendDataWeightTruck;
    public event EventHandler<CommunicationStatusChangedEventArgs>? OnSendStatusWeightTruck;

    public event EventHandler<MessageDataOutput>? OnSendDataWeightGoods;
    public event EventHandler<CommunicationStatusChangedEventArgs>? OnSendStatusWeightGoods;

    public event EventHandler<CommunicationStatusChangedEventArgs>? OnSendStatusWeight;
    public event EventHandler<EnumStatusConnectTcp>? OnSendStatusServer;
    private const string ScaleId = "SCALE_01";

    private readonly ICommunicationService _communication =
        new CommunicationService();
    public void ConnectWeight()
    {
      _communication.DataReceived += Communication_DataReceived;
      _communication.ConnectionStatusChanged += Communication_StatusChanged;

      if (AppCore.Ins._connection != null)
      {
        var configData = JsonHelper.FromJson<JsonConfigTcpClient>(AppCore.Ins._connection.JsonStrConfig ?? string.Empty);
        if (configData == null)
          return;

        var config = new ConfigTcpClient
        {
          Code = ScaleId,
          NameDevice = "Cân TCP",
          Host = configData.Host,
          Port = configData.Port,
          eModeCommunication = eModeCommunication.SICS,
          AutoConnect = configData.AutoConnect,
          TimeoutMs = configData.TimeoutMs,
          Request = configData.Request,
          TimeRequest = configData.TimeRequest
        };

        _communication.AddConnection(
          config,
          machineId: null,
          device: eDevice.Weight);
      }  
    }

    private void Communication_DataReceived(
       object? sender,
       MessageDataOutput data)
    {
      OnSendDataWeightTruck?.Invoke(sender, data);
      OnSendDataWeightGoods?.Invoke(sender, data);
    }

    private void Communication_StatusChanged(
        object? sender,
        CommunicationStatusChangedEventArgs e)
    {
      OnSendStatusWeightTruck?.Invoke(sender, e);
      OnSendStatusWeightGoods?.Invoke(sender, e);
      OnSendStatusWeight?.Invoke(sender, e);
    }



    #region Check kết nối Server
    public System.Timers.Timer _timerCheckConnectServer = new System.Timers.Timer();
    public void CheckConnectServer()
    {
      _timerCheckConnectServer.Interval = 2000;
      _timerCheckConnectServer.Elapsed += TimerCheckConnectServer_Elapsed;
      _timerCheckConnectServer.Start();
    }

    private void TimerCheckConnectServer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      try
      {
        _timerCheckConnectServer.Stop();

        EnumStatusConnectTcp enumStatusConnectCurrent = EnumStatusConnectTcp.Disconnect;
        if (_appConfig != null)
        {
          var rsPing = CanPingServer(_appConfig?.IpServer??string.Empty, _appConfig?.PortServer ?? 8000, _appConfig?.TimeoutConnectServer ?? 500);
          if (rsPing)
          {
            enumStatusConnectCurrent = EnumStatusConnectTcp.Connect;
          }
          else
          {
            enumStatusConnectCurrent = EnumStatusConnectTcp.Disconnect;
          }
        }

        OnSendStatusServer?.Invoke(sender, enumStatusConnectCurrent);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
      finally
      {
        _timerCheckConnectServer.Start();
      }
    }
    #endregion
    public bool CanPingServer(string ip, int port, int timout)
    {
      try
      {
        using var ping = new Ping();
        int pingTimeout = Math.Clamp(timout, 100, 1000);
        PingReply reply = ping.Send(ip, pingTimeout);
        return reply.Status == IPStatus.Success;
      }
      catch
      {
        return false;
      }
    }
  }
}
