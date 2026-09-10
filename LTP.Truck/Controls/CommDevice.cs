using HelperManager;
using iSoft.Communication.Communication;
using iSoft.Communication.Interface;
using iSoft.Communication.JsonPayload;
using static iSoft.Communication.EnumCommunication;

namespace LTP.Truck.Controls
{
  public partial class AppCore
  {
    public event EventHandler<MessageDataOutput>? OnSendDataWeightTruck;
    public event EventHandler<CommunicationStatusChangedEventArgs>? OnSendStatusWeightTruck;

    public event EventHandler<MessageDataOutput>? OnSendDataWeightGoods;
    public event EventHandler<CommunicationStatusChangedEventArgs>? OnSendStatusWeightGoods;
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
        var config = new ConfigTcpClient
        {
          Code = ScaleId,
          NameDevice = "Cân TCP",
          Host = configData.Host,
          Port = configData.Port,
          eModeCommunication = eModeCommunication.SICS,
          AutoConnect = true,
          TimeoutMs = 5000,
          Request = true,
          TimeRequest = 200
        };

        _communication.AddConnection(
          config,
          machineId: null,
          device: eDevice.Weight);

        _communication.Connect(ScaleId);
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
    }
  }
}
