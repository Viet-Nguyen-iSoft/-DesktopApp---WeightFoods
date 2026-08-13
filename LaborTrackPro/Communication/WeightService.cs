using SuperSimpleTcp;
using System.Net.NetworkInformation;
using System.Text;
using static HelperManager.EnumData;

namespace LaborTrackPro.Communication
{
  public class WeightService : IDisposable
  {
    #region Events

    public event EventHandler<MessageDataOutputWeight>? WeightReceived;

    //public event EventHandler<string>? RawDataReceived;

    public event EventHandler<bool>? ConnectionChanged;

    public event EventHandler<string>? LogReceived;

    #endregion

    #region Fields

    private readonly string _ip;
    private readonly int _port;
    private readonly int _sample_time;
    private readonly int _sample_out;

    private SimpleTcpClient? _client;

    private readonly StringBuilder _receiveBuffer = new();

    private readonly object _lockBuffer = new();

    private CancellationTokenSource? _cts;

    private Task? _workerTask;

    private volatile bool _isRunning = false;

    private volatile bool _isConnecting = false;

    #endregion

    #region Properties

    public bool IsConnected => _client?.IsConnected ?? false;
    private MessageDataOutputWeight OutputWeight { get; set; } = new MessageDataOutputWeight();

    private bool PingIp
    {
      get
      {
        Ping ping = new Ping();
        PingReply FindPLC = ping.Send(_ip, _sample_out);
        return FindPLC.Status.ToString().Equals("Success");
      }
    }

    #endregion

    #region Constructor

    public WeightService(string nameDevice, string ip, int port, int timeout, int sample_time_ms)
    {
      OutputWeight.NameDevice = nameDevice;
      _ip = ip;
      _port = port;
      _sample_out = timeout;
      _sample_time = sample_time_ms;
    }

    #endregion

    #region Public

    public void Start()
    {
      if (_isRunning)
        return;

      _isRunning = true;

      _cts = new CancellationTokenSource();

      _workerTask = Task.Run(() => WorkerLoop(_cts.Token));
    }

    public async Task StopAsync()
    {
      try
      {
        _isRunning = false;

        if (_cts != null)
        {
          _cts.Cancel();
        }

        if (_workerTask != null)
        {
          await _workerTask;
        }

        Disconnect();
      }
      catch
      {

      }
    }

    public async Task SendAsync(string command)
    {
      try
      {
        if (_client == null)
          return;

        if (!_client.IsConnected)
          return;

        await _client.SendAsync(command);
      }
      catch (Exception ex)
      {
        LogReceived?.Invoke(this, ex.Message);
        ForceDisconnect();
      }
    }

    public async Task Tare()
    {
      await SendAsync("T\r\n");
    }

    public async Task Zero()
    {
      await SendAsync("Z\r\n");
    }

    #endregion

    #region Worker

    private async Task WorkerLoop(CancellationToken token)
    {
      while (!token.IsCancellationRequested)
      {
        try
        {
          if (PingIp)
          {
            if (!IsConnected)
            {
              Connect();
            }
            if (IsConnected)
            {
              await SendAsync("SI\r\n");
            }
            else
            {
              ConnectionChanged?.Invoke(this, false);
            }
          }
          else
          {
            ConnectionChanged?.Invoke(this, false);
          }

          await Task.Delay(_sample_time, token);
        }
        catch (Exception ex)
        {
          LogReceived?.Invoke(this, ex.Message);
        }
      }
    }

    #endregion

    #region Connect

    private void Connect()
    {
      if (_isConnecting)
        return;

      try
      {
        _isConnecting = true;

        Disconnect();

        CreateClient();

        if (PingIp)
          _client!.Connect();
      }
      catch (Exception ex)
      {
        LogReceived?.Invoke(this, ex.Message);
        ForceDisconnect();
      }
      finally
      {
        _isConnecting = false;
      }
    }

    private void CreateClient()
    {
      _client = new SimpleTcpClient(_ip, _port);

      _client.Events.Connected += Client_Connected;
      _client.Events.Disconnected += Client_Disconnected;
      _client.Events.DataReceived += Client_DataReceived;

      _client.Settings.ConnectTimeoutMs = 1000;
      _client.Settings.NoDelay = true;

      _client.Keepalive.EnableTcpKeepAlives = true;
    }

    private void Disconnect()
    {
      try
      {
        if (_client != null)
        {
          _client.Events.Connected -= Client_Connected;
          _client.Events.Disconnected -= Client_Disconnected;
          _client.Events.DataReceived -= Client_DataReceived;

          if (_client.IsConnected)
          {
            _client.Disconnect();
          }

          _client.Dispose();

          _client = null;
        }
      }
      catch
      {

      }
    }

    private void ForceDisconnect()
    {
      try
      {
        Disconnect();
      }
      catch
      {

      }

      ConnectionChanged?.Invoke(this, false);
    }

    #endregion

    #region TCP Events

    private void Client_Connected(object? sender, ConnectionEventArgs e)
    {
      LogReceived?.Invoke(this, $"Connected: {e.IpPort}");
      ConnectionChanged?.Invoke(this, true);
    }

    private void Client_Disconnected(object? sender, ConnectionEventArgs e)
    {
      LogReceived?.Invoke(this, $"Disconnected: {e.IpPort}");
      ConnectionChanged?.Invoke(this, false);
    }


    private int filter = 0;
    private void Client_DataReceived(object? sender, DataReceivedEventArgs e)
    {
      try
      {
        string chunk = Encoding.ASCII.GetString(e.Data);

        lock (_lockBuffer)
        {
          _receiveBuffer.Append(chunk);

          string buffer = _receiveBuffer.ToString();

          int index;

          while ((index = buffer.IndexOf("\n")) >= 0)
          {
            string line = buffer[..index]
                .TrimEnd('\r', '\n');

            buffer = buffer[(index + 1)..];

            ProcessLine(line);
          }

          _receiveBuffer.Clear();

          _receiveBuffer.Append(buffer);



          if (filter > 6)
          {
            ConnectionChanged?.Invoke(this, true);
            filter = 0;
          }
          else
          {
            filter++;
          }
        }
      }
      catch (Exception ex)
      {
        LogReceived?.Invoke(this, ex.Message);
      }
    }

    #endregion

    #region Parser

    private void ProcessLine(string message)
    {
      try
      {
        var rs = Decode(message);
        if (rs != null)
        {
          if (rs.EnumValueWeight == eValueWeightType.Net)
          {
            OutputWeight.Net = rs.Net;
            OutputWeight.ActiveWeighingStatus = rs.ActiveWeighingStatus;
            OutputWeight.EnumValueWeight = rs.EnumValueWeight;
            OutputWeight.UnitOfWeight = rs.UnitOfWeight;
            OutputWeight.SourceDateTime = rs.SourceDateTime;
            OutputWeight.DataAsString = rs.DataAsString;

            WeightReceived?.Invoke(this, OutputWeight);
          }
        }
      }
      catch (Exception ex)
      {
        LogReceived?.Invoke(this, ex.Message);
      }
    }


    public static MessageDataOutputWeight? Decode(string message)
    {
      try
      {
        if (string.IsNullOrEmpty(message)) return null;

        MessageDataOutputWeight sicsOutputData = new MessageDataOutputWeight();
        string[] parts = message.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 4)
        {
          sicsOutputData.Net = 0.0;
          sicsOutputData.ActiveWeighingStatus = ActiveWeighingStatus.Default;
          sicsOutputData.EnumValueWeight = eValueWeightType.Net;
          sicsOutputData.UnitOfWeight = UnitOfWeight.None;
          sicsOutputData.DataAsString = message;
          sicsOutputData.SourceDateTime = DateTime.Now;
          return sicsOutputData;
        }

        string key = parts[0].Replace("\r", "").Replace("\n", "");
        if (key == "S")
        {
          sicsOutputData.EnumValueWeight = eValueWeightType.Net;
          if (parts[1] == "S")
          {
            sicsOutputData.Net = double.Parse(parts[2]);
            sicsOutputData.ActiveWeighingStatus = ActiveWeighingStatus.Stable;
            if (parts[3].Trim() == "kg")
            {
              sicsOutputData.UnitOfWeight = UnitOfWeight.Kilograms;
            }
          }
          else if (parts[1] == "D")
          {
            sicsOutputData.Net = double.Parse(parts[2]);
            sicsOutputData.ActiveWeighingStatus = ActiveWeighingStatus.Motion;
            if (parts[3].Trim() == "kg")
            {
              sicsOutputData.UnitOfWeight = UnitOfWeight.Kilograms;
            }
          }
          else if (parts[1] == "+")
          {
            sicsOutputData.Net = 0.0;
            sicsOutputData.Tare = 0.0;
            sicsOutputData.ActiveWeighingStatus = ActiveWeighingStatus.Overload;
            sicsOutputData.UnitOfWeight = UnitOfWeight.None;
          }
          else if (parts[1] == "-")
          {
            sicsOutputData.Net = 0.0;
            sicsOutputData.Tare = 0.0;
            sicsOutputData.ActiveWeighingStatus = ActiveWeighingStatus.Underload;
            sicsOutputData.UnitOfWeight = UnitOfWeight.None;
          }
        }
        else if (key == "TA")
        {
          sicsOutputData.EnumValueWeight = eValueWeightType.Tare;
          sicsOutputData.Tare = double.Parse(parts[2]);
        }

        return sicsOutputData;
      }
      catch (Exception)
      {
        return null;
      }
    }

    #endregion

    #region Dispose

    public void Dispose()
    {
      try
      {
        _cts?.Cancel();

        Disconnect();

        _cts?.Dispose();
      }
      catch
      {

      }
    }

    #endregion
  }

  public class MessageDataOutputWeight
  {
    public string? NameDevice { get; set; }

    public double Net { get; set; } = 0.0;

    public double Tare { get; set; } = 0.0;
    public UnitOfWeight UnitOfWeight { get; set; }

    public eValueWeightType EnumValueWeight { get; set; } = eValueWeightType.Net;

    public ActiveWeighingStatus ActiveWeighingStatus { get; set; } = ActiveWeighingStatus.Default;

    public DateTime SourceDateTime { get; set; }

    public byte[]? DataAsBytes { get; set; }

    public string? DataAsString { get; set; }
  }
}
