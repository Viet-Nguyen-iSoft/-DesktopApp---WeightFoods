using HelperManager;
using iSoft.Communication.JsonPayload;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.EnumData;
using static HelperManager.EnumData;

namespace Common.Settings
{
  public partial class PopupSettingTcpClient : Form
  {
    public event EventHandler<Connection>? OnSendConfirm;
    private Connection? _connection {  get; set; }
    public PopupSettingTcpClient()
    {
      InitializeComponent();

      iconSendReq.Tag = false;
      iconSendReq.Image = Properties.Resources.switch_off;

      iconAutoConnect.Tag = false;
      iconAutoConnect.Image = Properties.Resources.switch_off;
    }
    public PopupSettingTcpClient(Connection connection):this()
    {
      _connection = connection;
      btnConfirm.Text = "       Cập nhật";

      var jsonConfigTcp = JsonHelper.FromJson<JsonConfigTcpClient>(connection?.JsonStrConfig);
      LoadData(jsonConfigTcp);
    }

    private void LoadData(JsonConfigTcpClient? jsonConfigTcpClient)
    {
      if (InvokeRequired)
      {
        Invoke(new Action(() => LoadData(jsonConfigTcpClient)));
        return;
      }

      txtIP.Texts = jsonConfigTcpClient?.Host ?? string.Empty;
      txtPort.Texts = jsonConfigTcpClient?.Port.ToString() ?? string.Empty;
      txtTimeout.Texts = jsonConfigTcpClient?.TimeoutMs.ToString() ?? string.Empty;

      iconAutoConnect.Image = jsonConfigTcpClient?.AutoConnect??false ? Properties.Resources.switch_on : Properties.Resources.switch_off;
      iconSendReq.Image = jsonConfigTcpClient?.Request ?? false ? Properties.Resources.switch_on : Properties.Resources.switch_off;
      
      iconAutoConnect.Tag = jsonConfigTcpClient?.AutoConnect ?? false;
      iconSendReq.Tag = jsonConfigTcpClient?.Request ?? false;
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
      JsonConfigTcpClient jsonConfigTcpClient = new JsonConfigTcpClient();
      jsonConfigTcpClient.Host = txtIP.Texts;
      jsonConfigTcpClient.Port = int.Parse(txtPort.Texts);
      jsonConfigTcpClient.TimeoutMs = int.Parse(txtTimeout.Texts);
      jsonConfigTcpClient.AutoConnect = (bool)iconAutoConnect.Tag;
      jsonConfigTcpClient.Request = (bool)iconSendReq.Tag;
      jsonConfigTcpClient.TimeRequest = 500;
      string json = JsonHelper.ToJson(jsonConfigTcpClient);

      if (_connection==null)
      {
        Connection connection = new Connection();
        connection.Name = "Cân TCP";
        connection.Code = "";
        connection.EnumDevice = EnumDevice.Weight;
        connection.EnumCommunicationType = EnumCommunicationType.TcpClient;
        connection.JsonStrConfig = json;
        OnSendConfirm?.Invoke(sender, connection);
        this.Close();
      }
      else
      {
        _connection.JsonStrConfig = json;
        OnSendConfirm?.Invoke(sender, _connection);
        this.Close();
      }  
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void iconSendReq_Click(object sender, EventArgs e)
    {
      ToggleSendRequest();
    }

    private void iconAutoConnect_Click(object sender, EventArgs e)
    {
      ToggleSendAutoConnect();
    }

    private void ToggleSendRequest()
    {
      bool isOn = iconSendReq.Tag is bool value && value;
      isOn = !isOn;

      iconSendReq.Tag = isOn;
      iconSendReq.Image = isOn
        ? Properties.Resources.switch_on
        : Properties.Resources.switch_off;
    }

    private void ToggleSendAutoConnect()
    {
      bool isOn = iconAutoConnect.Tag is bool value && value;
      isOn = !isOn;

      iconAutoConnect.Tag = isOn;
      iconAutoConnect.Image = isOn
        ? Properties.Resources.switch_on
        : Properties.Resources.switch_off;
    }
  }
}
