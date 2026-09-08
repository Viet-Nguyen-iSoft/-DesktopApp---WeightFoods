using iSoft.Communication.Communication;
using iSoft.Communication.Interface;
using iSoft.Communication.JsonPayload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.EnumData;
using static iSoft.Communication.EnumCommunication;
using static LaborTrackPro.Controls.AppCore;

namespace LTP.Truck.Controls
{
  public partial class AppCore
  {
    public event EventHandler<MessageDataOutput>? OnSendDataWeight;
    private const string ScaleId = "SCALE_01";

    private readonly ICommunicationService _communication =
        new CommunicationService();
    public void ConnectWeight()
    {
      _communication.DataReceived += Communication_DataReceived;
      _communication.ConnectionStatusChanged += Communication_StatusChanged;

      var config = new ConfigTcpClient
      {
        Code = ScaleId,
        NameDevice = "Cân TCP",
        Host = "192.168.2.198",
        Port = 8000,
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

    private void Communication_DataReceived(
       object? sender,
       MessageDataOutput data)
    {
      OnSendDataWeight?.Invoke(sender, data);
    }

    private void Communication_StatusChanged(
        object? sender,
        CommunicationStatusChangedEventArgs e)
    {
      //BeginInvoke(() =>
      //{
      //  //lblStatus.Text = e.IsConnected
      //  //    ? $"{e.ConnectionId}: Connected"
      //  //    : $"{e.ConnectionId}: Disconnected";
      //});
    }
  }
}
