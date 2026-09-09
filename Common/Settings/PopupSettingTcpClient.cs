using HelperManager;
using iSoft.Communication.JsonPayload;
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

namespace Common.Settings
{
  public partial class PopupSettingTcpClient : Form
  {
    public event EventHandler<string>? OnSendConfirm;
    public PopupSettingTcpClient()
    {
      InitializeComponent();

      iconSendReq.Tag = false;
      iconSendReq.Image = Properties.Resources.switch_off;

      iconAutoConnect.Tag = false;
      iconAutoConnect.Image = Properties.Resources.switch_off;
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
      JsonConfigTcpClient jsonConfigTcpClient = new JsonConfigTcpClient();
      jsonConfigTcpClient.Host = txtIP.Texts;
      jsonConfigTcpClient.Port = int.Parse(txtPort.Texts);
      jsonConfigTcpClient.TimeoutMs = int.Parse(txtTimeout.Texts);
      jsonConfigTcpClient.AutoConnect = DataHelper.IsOn(iconAutoConnect);
      jsonConfigTcpClient.Request = DataHelper.IsOn(iconSendReq);
      jsonConfigTcpClient.TimeRequest = 500;

      string json = JsonHelper.ToJson(jsonConfigTcpClient);
      OnSendConfirm?.Invoke(sender, json);
      this.Close();
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
