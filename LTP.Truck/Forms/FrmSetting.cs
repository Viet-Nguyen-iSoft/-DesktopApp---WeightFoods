using Common.Settings;
using HelperManager;
using iSoft.Communication.JsonPayload;
using iSoft.Database.Models;
using iSoft.Database.Service;
using LTP.Truck.Controls;
using LTP.Truck.Custom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
      CustomUI();
      flowCommWeight.AutoScroll = true;
      flowCommWeight.FlowDirection = FlowDirection.TopDown;
      flowCommWeight.WrapContents = false;
      this.Load += FrmSetting_Load;
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

    private void CustomUI()
    {
      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.CornerRadius = 20;
      elipseControl01.TargetControl = this;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.CornerRadius = 20;
      elipseControl02.TargetControl = tableLayoutPanel3;
    }

    private async void FrmSetting_Load(object? sender, EventArgs e)
    {
      await LoadWeightConnectionsAsync();
    }

    private async Task LoadWeightConnectionsAsync()
    {
      try
      {
        var connections = await AppCore.Ins._connectionService.GetAllAsync();
        var weightConnections = connections
          .Where(connection => connection.EnumDevice == EnumDevice.Weight)
          .OrderBy(connection => connection.Name)
          .ThenBy(connection => connection.Id)
          .ToList();

        flowCommWeight.SuspendLayout();
        try
        {
          flowCommWeight.Controls.Clear();

          foreach (var connection in weightConnections)
          {
            var item = new UcComm
            {
              Connection = connection,
              CommName = EnumHelper.GetDescription(connection.EnumCommunicationType),
              Information = GetConnectionInformation(connection),
              Tag = connection,
              Margin = new Padding(3),
              Width = Math.Max(100, flowCommWeight.ClientSize.Width / 2 - 5),
              Height = 200
            };
            item.OnSendDataDetail += Item_OnSendDataDetail;
            flowCommWeight.Controls.Add(item);
          }
        }
        finally
        {
          flowCommWeight.ResumeLayout();
        }
      }
      catch (Exception ex)
      {
        HelperManager.LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void Item_OnSendDataDetail(Connection? obj)
    {
      if (obj?.EnumCommunicationType == EnumCommunicationType.TcpClient)
      {
        PopupSettingTcpClient popupSettingTcpClient = new PopupSettingTcpClient(obj);
        popupSettingTcpClient.OnSendConfirm += TcpClient_OnSendConfirm;
        popupSettingTcpClient.ShowDialog();
      }  
    }

    private static string GetConnectionInformation(Connection connection)
    {
      if (connection.EnumCommunicationType != EnumCommunicationType.TcpClient ||
        string.IsNullOrWhiteSpace(connection.JsonStrConfig))
      {
        return string.Empty;
      }

      try
      {
        var config = JsonConvert.DeserializeObject<JsonConfigTcpClient>(
          connection.JsonStrConfig);
        return config == null
          ? string.Empty
          : $"IP: {config.Host} - Port: {config.Port}";
      }
      catch (JsonException)
      {
        return "Cấu hình TCP không hợp lệ";
      }
    }


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

    private async void TcpClient_OnSendConfirm(object? sender, Connection e)
    {
      e.StationId = AppCore.Ins._station?.Id;

      await AppCore.Ins._connectionService.AddOrUpdateAsync(e);
      await LoadWeightConnectionsAsync();
    }
  }
}
