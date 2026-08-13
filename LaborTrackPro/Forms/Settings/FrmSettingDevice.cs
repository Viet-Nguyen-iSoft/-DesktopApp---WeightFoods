using HelperManager;
using LaborTrackPro.Communication;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Settings
{
  public partial class FrmSettingDevice : Form
  {
    public FrmSettingDevice()
    {
      InitializeComponent();
      CustomUI();
      this.Load += FrmSettingDevice_Load;
    }

    #region Instance
    private static FrmSettingDevice _Instance = null;
    public static FrmSettingDevice Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmSettingDevice();
        return _Instance;
      }
    }
    #endregion


    private void CustomUI()
    {
      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.TargetControl = this.tableLayoutPanel2;
      elipseControl01.CornerRadius = 15;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.TargetControl = this.tableLayoutPanel3;
      elipseControl02.CornerRadius = 15;
    }

    private void FrmSettingDevice_Load(object? sender, EventArgs e)
    {
      LoadWeightSetting();
      LoadHidSetting();
    }

    private void LoadWeightSetting()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LoadWeightSetting();
        }));
        return;
      }

      if (!string.IsNullOrEmpty(AppCore.Ins._connectionsWeight?.JsonStrConfig))
      {
        var config = JsonHelper.FromJson<TcpClientJson>(AppCore.Ins._connectionsWeight.JsonStrConfig);
        if (config != null)
        {
          txtIpWeight.Texts = config.IP ?? string.Empty;
          portWeight.Value = config.Port ?? 0;
          timeoutWeight.Value = config.Timeout ?? 0;
          checkConnectWeight.Value = config.TimeConnect ?? 0;
          sampleTimeWeight.Value = config.SampleTime ?? 0;
        }

        txtNameWeight.Texts = AppCore.Ins._connectionsWeight.Name ?? string.Empty;
      }

    }


    private void LoadHidSetting()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LoadHidSetting();
        }));
        return;
      }

      if (!string.IsNullOrEmpty(AppCore.Ins._connectionsHID?.JsonStrConfig))
      {
        var config = JsonHelper.FromJson<TcpClientJson>(AppCore.Ins._connectionsHID.JsonStrConfig);
        if (config != null)
        {
          txtIpHID.Texts = config.IP ?? string.Empty;
          portHID.Value = config.Port ?? 0;
          timeoutHID.Value = config.Timeout ?? 0;
          checkConnectHID.Value = config.TimeConnect ?? 0;
        }

        txtNameHID.Texts = AppCore.Ins._connectionsHID.Name ?? string.Empty;
      }
    }

    private void btnBackWeight_Click(object sender, EventArgs e)
    {
      LoadWeightSetting();
    }

    private void btnBackHid_Click(object sender, EventArgs e)
    {
      LoadHidSetting();
    }

    private async void btnSaveWeight_Click(object sender, EventArgs e)
    {
      try
      {
        TcpClientJson tcpClientJson = new TcpClientJson();
        tcpClientJson.IP = txtIpWeight.Texts;
        tcpClientJson.Port = (int)portWeight.Value;
        tcpClientJson.Timeout = (int)timeoutWeight.Value;
        tcpClientJson.TimeConnect = (int)checkConnectWeight.Value;
        tcpClientJson.SampleTime = (int)sampleTimeWeight.Value;

        if (AppCore.Ins._connectionsWeight != null)
        {
          AppCore.Ins._connectionsWeight.Name = txtNameWeight.Texts;
          AppCore.Ins._connectionsWeight.JsonStrConfig = JsonHelper.ToJson(tcpClientJson);
          AppCore.Ins._connectionsWeight.UpdatedAt = DateTime.Now;
          await AppCore.Ins.UpdateConnection(AppCore.Ins._connectionsWeight);

          new FrmInformation().ShowMessage("Lưu thành công.", eImage.Information);
        }
        else
        {
          new FrmInformation().ShowMessage("Không tìm thấy thông tin !", eImage.Warning);
        }
      }
      catch (Exception)
      {
        new FrmInformation().ShowMessage("Lưu thất bại !", eImage.Warning);
      }
    }

    private async void btnSaveHid_Click(object sender, EventArgs e)
    {
      try
      {
        TcpClientJson tcpClientJson = new TcpClientJson();
        tcpClientJson.IP = txtIpHID.Texts;
        tcpClientJson.Port = (int)portHID.Value;
        tcpClientJson.Timeout = (int)timeoutHID.Value;
        tcpClientJson.TimeConnect = (int)checkConnectHID.Value;

        if (AppCore.Ins._connectionsHID != null)
        {
          AppCore.Ins._connectionsHID.Name = txtNameHID.Texts;
          AppCore.Ins._connectionsHID.JsonStrConfig = JsonHelper.ToJson(tcpClientJson);
          AppCore.Ins._connectionsHID.UpdatedAt = DateTime.Now;
          await AppCore.Ins.UpdateConnection(AppCore.Ins._connectionsHID);
          new FrmInformation().ShowMessage("Lưu thành công.", eImage.Information);
        }
        else
        {
          new FrmInformation().ShowMessage("Không tìm thấy thông tin !", eImage.Warning);
        }
      }
      catch (Exception)
      {
        new FrmInformation().ShowMessage("Lưu thất bại !", eImage.Warning);
      }
    }
  }
}
