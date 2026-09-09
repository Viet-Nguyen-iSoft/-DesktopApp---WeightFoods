using Common.Settings;
using iSoft.Database.Models;
using iSoft.Database.Service;
using LTP.Truck.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HelperManager.EnumData;

namespace LTP.Truck.Forms
{
  public partial class FrmSetting : Form
  {
    private readonly Color _primaryColor = Color.FromArgb(51, 108, 181);
    private Panel? _connectionEditor;
    private TableLayoutPanel? _settingFields;

    public FrmSetting()
    {
      InitializeComponent();
    }
    #region Instance
    private static FrmSetting _Instance = null;
    public static FrmSetting Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmSetting();
        return _Instance;
      }
    }
    #endregion


    private void btnAddCommWeight_Click(object sender, EventArgs e)
    {
      PopupChooseComm popupChooseComm = new PopupChooseComm();
      popupChooseComm.OnSendConfirm += PopupChooseComm_OnSendConfirm;
      popupChooseComm.ShowDialog();
    }

    private void PopupChooseComm_OnSendConfirm(object? sender, Common.EnumData.EnumCommunication e)
    {
      PopupSettingTcpClient tcpClient = new PopupSettingTcpClient();
      tcpClient.OnSendConfirm += TcpClient_OnSendConfirm;
      tcpClient.ShowDialog();
    }

    private async void TcpClient_OnSendConfirm(object? sender, string e)
    {
      Connection connection = new Connection();
      connection.Name = "Cân TCP";
      connection.Code = "";
      connection.EnumDevice = EnumDevice.Weight;
      connection.EnumCommunicationType = EnumCommunicationType.TcpClient;
      connection.JsonStrConfig = e;
      connection.StationId = AppCore.Ins._station?.Id;

      await AppCore.Ins._connectionService.AddOrUpdateAsync(connection);
    }
  }
}
