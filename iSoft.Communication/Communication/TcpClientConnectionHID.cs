using SuperSimpleTcp;
using System.Net.NetworkInformation;
using System.Text;

namespace iSoft.Communication.Communication
{
  public class TcpClientConnectionHID
  {
    public event EventHandler<string> OnDataReceived;
    public event EventHandler<bool> OnConnectionStatusChanged;

    private System.Timers.Timer _timerCheckConnect = new System.Timers.Timer();
    private SimpleTcpClient _Client;
    private string _ip;
    private int _port;
    public TcpClientConnectionHID(string host, int port)
    {
      _ip = host;
      _port = port;
      Init(host, port);
    }

    public void Init(string host, int port)
    {
      _Client = new SimpleTcpClient(host, port);

      _Client.Events.Connected += ConnectedHandler;
      _Client.Events.Disconnected += Disconnected;
      _Client.Events.DataReceived += DataReceived;
      //_Client.Events.DataSent += DataSent;
      _Client.Keepalive.EnableTcpKeepAlives = true;
      _Client.Settings.MutuallyAuthenticate = false;
      _Client.Settings.AcceptInvalidCertificates = true;
      _Client.Settings.ConnectTimeoutMs = 300;
      _Client.Settings.NoDelay = true;

      _timerCheckConnect.Interval = 1000;
      _timerCheckConnect.Elapsed += _timerCheckConnect_Elapsed;
      _timerCheckConnect.Start();
    }

    private void _timerCheckConnect_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      try
      {
        _timerCheckConnect.Stop();
        if (!_Client.IsConnected)
        {
          if (PingIp)
          {
            _Client.Events.Connected -= ConnectedHandler;
            _Client.Events.Disconnected -= Disconnected;
            _Client.Events.DataReceived -= DataReceived;
            _Client.Dispose();

            _Client = new SimpleTcpClient(_ip, _port);

            _Client.Events.Connected += ConnectedHandler;
            _Client.Events.Disconnected += Disconnected;
            _Client.Events.DataReceived += DataReceived;
            _Client.Keepalive.EnableTcpKeepAlives = true;
            _Client.Settings.MutuallyAuthenticate = false;
            _Client.Settings.AcceptInvalidCertificates = true;
            _Client.Settings.ConnectTimeoutMs = 300;
            _Client.Settings.NoDelay = true;

            Connect();
          }

        }
      }
      catch (Exception)
      {

      }
      finally
      {
        _timerCheckConnect.Start();
      }
    }

    public void Connect()
    {
      try
      {
        if (PingIp)
          _Client.Connect();
      }
      catch (Exception)
      {
        throw;
      }
    }

    private bool PingIp
    {
      get
      {
        Ping ping = new Ping();
        PingReply FindPLC = ping.Send(_ip, 500);
        return FindPLC.Status.ToString().Equals("Success");
      }
    }

    private void ConnectedHandler(object? sender, ConnectionEventArgs e)
    {
      OnConnectionStatusChanged?.Invoke(sender, true);
    }

    public void Disconnected(object? sender, ConnectionEventArgs e)
    {
      OnConnectionStatusChanged?.Invoke(sender, false);
    }

    public void DataReceived(object? sender, DataReceivedEventArgs e)
    {
      string chunk = Encoding.UTF8.GetString(e.Data);
      OnDataReceived?.Invoke(sender, chunk);
    }



  }

}
