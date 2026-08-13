using HelperManager;
using KeysStrokerLib;
using KeysStrokerLib.Events;
using LaborTrackPro.Communication;
using System.Net.NetworkInformation;
using static HelperManager.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Controls
{
  public partial class AppCore
  {
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
          Ping ping = new Ping();
          PingReply findIpDevice = ping.Send(_ipServer ?? "", 1000);
          var rsPing = findIpDevice.Status.ToString().Equals("Success");
          if (rsPing)
          {
            enumStatusConnectCurrent = EnumStatusConnectTcp.Connect;
          }
          else
          {
            enumStatusConnectCurrent = EnumStatusConnectTcp.Disconnect;
          }
        }

        OnSendStatusConnectServer?.Invoke(enumStatusConnectCurrent);
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

    #region Weight
    private WeightService? _scale;
    public void InitWeight(string name, TcpClientJson tcpClientJson)
    {
      _scale = new WeightService(
        name,
        tcpClientJson.IP ?? "127.0.0.1",
        tcpClientJson.Port ?? 8000,
        tcpClientJson.Timeout ?? 200,
        tcpClientJson.SampleTime ?? 100
        );

      _scale.ConnectionChanged += Scale_ConnectionChanged;

      _scale.WeightReceived += _scale_WeightReceived;

      _scale.LogReceived += Scale_LogReceived;

      _scale.Start();
    }

    private void _scale_WeightReceived(object? sender, MessageDataOutputWeight e)
    {
      //Debug.WriteLine($"Weight: {e.Net}");
      OnSendDataWeight?.Invoke(e);

      if (_s7NetService!=null && _alarm==true)
      {
        if (AppCore.Ins._dataManager.EnumStepOperation == EnumStepOperation.Waiting)
        {
          Int32 data = (Int32)(e.Net * 1000);
          _s7NetService.WritePlcInt32(0, data);
          _s7NetService.WritePlcInt32(4, 0);
        }
        else
        {
          Int32 data = (Int32)(0);
          _s7NetService.WritePlcInt32(0, data);
          _s7NetService.WritePlcInt32(4, 0);
        } 
      }  
    }

    private void Scale_ConnectionChanged(object? sender, bool e)
    {
      EnumStatusConnectTcp enumStatusConnectTcp = e == true ? EnumStatusConnectTcp.Connect : EnumStatusConnectTcp.Disconnect;
      OnSendStatusConnectWeight?.Invoke(sender, enumStatusConnectTcp);
    }

    private void Scale_LogReceived(object? sender, string e)
    {
      //Debug.WriteLine($"Log: {e}");
    }
    #endregion


    #region HID
    public void InitHID(TcpClientJson tcpClientJson)
    {
      string ip = tcpClientJson?.IP ?? "127.0.0.1";
      int port = tcpClientJson?.Port ?? 8080;

      TcpClientConnectionHID tcpClientConnection = new TcpClientConnectionHID(ip, port);
      tcpClientConnection.OnDataReceived += TcpClientConnection_OnDataReceived;
      tcpClientConnection.OnConnectionStatusChanged += TcpClientConnection_OnConnectionStatusChanged;
      tcpClientConnection.Connect();
    }

    private void TcpClientConnection_OnConnectionStatusChanged(object? sender, bool e)
    {
      OnSendStatusConnectHID?.Invoke(this, e);
    }

    private void TcpClientConnection_OnDataReceived(object? sender, string e)
    {
      if (string.IsNullOrEmpty(e))
      {
        return;
      }

      var rs = JsonHelper.FromJson<MessageHID>(e);

      if (rs != null)
      {
        string codeHID = TextHelper.RemoveLeadingZeros(rs?.raw ?? string.Empty);
        MessageDataOutput messageDataOutput = new MessageDataOutput();
        messageDataOutput.DataAsString = rs?.raw ?? string.Empty;

        OnSendDataRfid?.Invoke(sender, messageDataOutput);
      }
    }

    #endregion

    #region HID Usb
    private Keystroker? _keystroker { get; set; }
    public void InitRfidUsb()
    {
      _keystroker = new Keystroker();
      _keystroker.OnFlushKeysInputEvent += this._keystroker_OnFlushKeysInputEvent;
      _keystroker.Start();
    }

    private void _keystroker_OnFlushKeysInputEvent(object? sender, KeyStrokerEventArgs e)
    {
      MessageDataOutput messageDataOutput = new MessageDataOutput();
      messageDataOutput.DataAsString = e?.DataAsString ?? string.Empty;
      OnSendDataRfid?.Invoke(sender, messageDataOutput);
    }
    #endregion

  }

  public class MessageHID
  {
    public string? type { get; set; }
    public int? value { get; set; }
    public string? hex { get; set; }
    public string? raw { get; set; }
  }
}
