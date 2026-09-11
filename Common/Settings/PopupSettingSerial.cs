using HelperManager;
using iSoft.Communication.JsonPayload;
using iSoft.Database.Models;
using System.IO.Ports;
using static HelperManager.EnumData;

namespace Common.Settings
{
  public partial class PopupSettingSerial : Form
  {
    public event EventHandler<Connection>? OnSendConfirm;
    private Connection? _connection;

    public PopupSettingSerial()
    {
      InitializeComponent();

      iconSendReq.Tag = false;
      iconSendReq.Image = Properties.Resources.switch_off;
      iconAutoConnect.Tag = false;
      iconAutoConnect.Image = Properties.Resources.switch_off;

      cbbComm.DataSource = SerialPort.GetPortNames()
        .OrderBy(port => port)
        .ToList();
    }

    public PopupSettingSerial(Connection connection) : this()
    {
      _connection = connection;
      btnConfirm.Text = "       Cập nhật";

      var config = JsonHelper.FromJson<JsonConfigTcpSerial>(connection.JsonStrConfig);
      LoadData(config);
    }

    private void LoadData(JsonConfigTcpSerial? config)
    {
      var portName = config?.COM;
      if (!string.IsNullOrWhiteSpace(portName) && !cbbComm.Items.Contains(portName))
      {
        var ports = cbbComm.Items.Cast<string>().ToList();
        ports.Add(portName);
        cbbComm.DataSource = ports.OrderBy(port => port).ToList();
      }

      cbbComm.SelectedItem = portName;

      var autoConnect = config?.AutoConnect ?? false;
      var sendRequest = config?.Request ?? false;
      iconAutoConnect.Tag = autoConnect;
      iconAutoConnect.Image = autoConnect ? Properties.Resources.switch_on : Properties.Resources.switch_off;
      iconSendReq.Tag = sendRequest;
      iconSendReq.Image = sendRequest ? Properties.Resources.switch_on : Properties.Resources.switch_off;
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
      var config = new JsonConfigTcpSerial
      {
        COM = cbbComm.SelectedItem?.ToString(),
        AutoConnect = iconAutoConnect.Tag is bool autoConnect && autoConnect,
        Request = iconSendReq.Tag is bool sendRequest && sendRequest,
        TimeRequest = 500
      };

      _connection ??= new Connection
      {
        Name = "Cân Serial",
        Code = string.Empty,
        EnumDevice = EnumDevice.Weight,
        EnumCommunicationType = EnumCommunicationType.SerialPort
      };

      _connection.JsonStrConfig = JsonHelper.ToJson(config);
      OnSendConfirm?.Invoke(sender, _connection);
      Close();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void iconSendReq_Click(object sender, EventArgs e)
    {
      ToggleSwitch(iconSendReq);
    }

    private void iconAutoConnect_Click(object sender, EventArgs e)
    {
      ToggleSwitch(iconAutoConnect);
    }

    private static void ToggleSwitch(PictureBox icon)
    {
      var isOn = !(icon.Tag is bool value && value);
      icon.Tag = isOn;
      icon.Image = isOn ? Properties.Resources.switch_on : Properties.Resources.switch_off;
    }
  }
}
