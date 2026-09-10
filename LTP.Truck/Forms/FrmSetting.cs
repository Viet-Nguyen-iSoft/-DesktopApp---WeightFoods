using Common;
using Common.Settings;
using HelperManager;
using iSoft.Communication.JsonPayload;
using iSoft.Database.Models;
using LTP.Truck.Controls;
using LTP.Truck.Custom;
using Newtonsoft.Json;
using System.Data;
using System.Drawing.Printing;
using static Common.EnumData;
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
      flowCommWeight.FlowDirection = FlowDirection.LeftToRight;
      flowCommWeight.WrapContents = false;
      this.Load += FrmSetting_Load;
      btnSavePrint.Click += btnSavePrint_Click;
      btnAddCommWeight.Click += btnAddCommWeight_Click;

      AppCore.Ins.OnSendDataWeightTruck += Ins_OnSendDataWeightTruck;
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

      ElipseControl elipseControl03 = new ElipseControl();
      elipseControl03.CornerRadius = 20;
      elipseControl03.TargetControl = tableLayoutPanel4;

      ElipseControl elipseControl04 = new ElipseControl();
      elipseControl04.CornerRadius = 20;
      elipseControl04.TargetControl = tableLayoutPanel7;
    }

    private async void FrmSetting_Load(object? sender, EventArgs e)
    {
      LoadInstalledPrinters();
      await LoadWeightConnectionsAsync();
    }

    private void LoadInstalledPrinters()
    {
      var printerNames = PrinterSettings.InstalledPrinters
        .Cast<string>()
        .OrderBy(name => name)
        .ToList();

      cbbPrint.BeginUpdate();
      try
      {
        cbbPrint.Items.Clear();
        cbbPrint.Items.AddRange(printerNames.Cast<object>().ToArray());

        var savedPrinter = AppCore.Ins._appConfig?.NamePrint;
        if (!string.IsNullOrWhiteSpace(savedPrinter))
          cbbPrint.SelectedItem = printerNames.FirstOrDefault(name =>
            string.Equals(name, savedPrinter, StringComparison.OrdinalIgnoreCase));

        if (cbbPrint.SelectedIndex < 0 && cbbPrint.Items.Count > 0)
          cbbPrint.SelectedIndex = 0;
      }
      finally
      {
        cbbPrint.EndUpdate();
      }
    }

    private async void btnSavePrint_Click(object? sender, EventArgs e)
    {
      if (cbbPrint.SelectedItem is not string printerName ||
        string.IsNullOrWhiteSpace(printerName))
      {
        PopupConfirm popupConfirm = new PopupConfirm("Vui lòng chọn máy in !", EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popupConfirm.ShowDialog();
        return;
      }

      var appConfig = AppCore.Ins._appConfig;
      if (appConfig == null)
      {
        PopupConfirm popupConfirm = new PopupConfirm("Không tìm thấy cấu hình ứng dụng !", EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popupConfirm.ShowDialog();
        return;
      }

      try
      {
        appConfig.NamePrint = printerName;
        appConfig.UpdatedAt = DateTime.UtcNow;
        AppCore.Ins._appConfig = await AppCore.Ins._appConfigService
          .AddOrUpdateAsync(appConfig);

        PopupConfirm popupConfirm = new PopupConfirm("Đã lưu máy in.", EnumTypeMsg.MessageManualClose, EnumImageMsg.Information);
        popupConfirm.ShowDialog();
      }
      catch (Exception ex)
      {
        HelperManager.LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
        PopupConfirm popupConfirm = new PopupConfirm("Không thể lưu máy in. Vui lòng thử lại !", EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popupConfirm.ShowDialog();
      }
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
              Width = Math.Max(100, flowCommWeight.ClientSize.Width / 3 - 5),
              Height = 200
            };
            item.OnSendDataDetail += Item_OnSendDataDetail;
            item.OnSendDelete += Item_OnSendDelete;
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

    private async void Item_OnSendDelete(Connection? obj)
    {
      if (obj == null)
        return;

      try
      {
        obj.DeletedFlag = true;
        obj.UpdatedAt = DateTime.UtcNow;
        await AppCore.Ins._connectionService.AddOrUpdateAsync(obj);

        await LoadWeightConnectionsAsync();
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


    private void btnAddCommWeight_Click(object? sender, EventArgs e)
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

    private void Ins_OnSendDataWeightTruck(object? sender, iSoft.Communication.Interface.MessageDataOutput e)
    {

    }
  }
}
