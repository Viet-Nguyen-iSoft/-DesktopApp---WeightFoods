using HelperManager;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Setting
{
  public partial class FrmSettingServer : Form
  {
    public delegate void SendEnableSyncData(AppConfig appConfig);
    public event SendEnableSyncData? OnSendEnableSyncData;

    public FrmSettingServer()
    {
      InitializeComponent();
      CustomUI();
      this.Load += FrmSettingServer_Load;
    }
    private void CustomUI()
    {
      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.TargetControl = this.tableLayoutPanel2;
      elipseControl01.CornerRadius = 15;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.TargetControl = this.tableLayoutPanel3;
      elipseControl02.CornerRadius = 15;
    }
    #region Instance
    private static FrmSettingServer _Instance = null;
    public static FrmSettingServer Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmSettingServer();
        return _Instance;
      }
    }
    #endregion

    private bool isUpdate;
    private void FrmSettingServer_Load(object? sender, EventArgs e)
    {
      try
      {
        if (AppCore.Ins._appConfig != null)
        {
          isUpdate = AppCore.Ins._appConfig.IsAutoSyncData;
          txtIpServer.Texts = AppCore.Ins._appConfig.IpServer ?? "N/A";
          txtTimeSync.Texts = AppCore.Ins._appConfig.TimeSyncData.ToString() ?? "N/A";
          picAutoSync.Image = isUpdate ? Properties.Resources.icon_toggle_on :
                                             Properties.Resources.icon_toggle_off;
        }


        InitComboBox(AppCore.Ins._appConfig?.MachineId ?? 0);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private async void btnSaveServer_Click(object sender, EventArgs e)
    {
      try
      {
        if (AppCore.Ins._appConfig != null)
        {
          int timeSync = 2000;
          int.TryParse(txtTimeSync.Texts.Trim(), out timeSync);

          if (timeSync < 2000)
          {
            new FrmInformation().ShowMessage("Thời gian đồng bộ dữ liệu tối thiểu 2000ms", eImage.Warning);
            return;
          }

          if (!string.IsNullOrEmpty(txtIpServer.Texts.Trim()) && !string.IsNullOrEmpty(txtTimeSync.Texts.Trim()))
          {
            AppCore.Ins._appConfig.IpServer = txtIpServer.Texts.Trim();
            AppCore.Ins._appConfig.IsAutoSyncData = isUpdate;
            AppCore.Ins._appConfig.TimeSyncData = int.Parse(txtTimeSync.Texts.Trim());
            await AppCore.Ins.UpdateAppConfig_Async(AppCore.Ins._appConfig);
            new FrmInformation().ShowMessage("Lưu thành công.", eImage.Information);

            OnSendEnableSyncData?.Invoke(AppCore.Ins._appConfig);
          }
          else
          {
            new FrmInformation().ShowMessage("Có thông tin đang để trống.", eImage.Warning);
          }
        }
        else
        {
          new FrmInformation().ShowMessage("Không tìm thấy thông tin.", eImage.Warning);
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void picAutoSync_Click(object sender, EventArgs e)
    {
      isUpdate = !isUpdate;
      picAutoSync.Image = isUpdate ? Properties.Resources.icon_toggle_on :
                                         Properties.Resources.icon_toggle_off;
    }

    private void txtTimeSync_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
      {
        e.Handled = true;
      }
    }






    ///Machine
    ///
    private void InitComboBox(long machineId)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          InitComboBox(machineId);
        }));
        return;
      }

      try
      {
        var dto = DTOHelper.ConvertMachineToDTO(AppCore.Ins._machines);

        cbbMachine.DataSource = null;

        cbbMachine.DisplayMember = "DisplayText";
        cbbMachine.ValueMember = "Id";

        cbbMachine.DataSource = dto;


        var index = dto.FindIndex(x => x.Id == machineId);

        if (index >= 0)
        {
          cbbMachine.SelectedIndex = index;
        }
      }
      catch (Exception)
      {
      }
    }

    private async void btnSaveStationMachine_Click(object sender, EventArgs e)
    {
      MachineDTO? machine = cbbMachine.SelectedItem as MachineDTO;
      if (machine != null)
      {
        AppCore.Ins._appConfig.MachineId = machine.Id;
        AppCore.Ins._appConfig.UpdatedAt = DateTime.Now;
        await AppCore.Ins.UpdateAppConfig_Async(AppCore.Ins._appConfig);
        new FrmInformation().ShowMessage("Lưu thành công.", eImage.Information);
      }
      else
      {
        new FrmInformation().ShowMessage("Không tìm thấy thông tin !", eImage.Warning);
      }
    }
  }
}
