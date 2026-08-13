using HelperManager;
using iSoft.Database.Models;
using LaborTrackPro.Communication;
using LaborTrackPro.Controls;
using System.Diagnostics;
using static HelperManager.EnumData;
using static LaborTrackPro.EnumData;
using Point = System.Drawing.Point;

namespace LaborTrackPro.Forms
{
  public partial class FrmWaiting : Form
  {
    public FrmWaiting()
    {
      InitializeComponent();
      this.Load += FrmWaiting_Load;
      this.lbVersion.Text = $"Copyright @ {DateTime.Now.Year} i-Soft JSC. All rights reserved. - {AppCore.Ins._inforLine}";
    }

    #region Instance
    private static FrmWaiting _Instance = null;
    public static FrmWaiting Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmWaiting();
        return _Instance;
      }
    }
    #endregion

    private System.Timers.Timer _timerDelay = new System.Timers.Timer();
    private System.Timers.Timer _timerBlink = new System.Timers.Timer();
    private Employee? _employee { get; set; }

    private int filterStatus { get; set; } = 0;
    private EnumStatusConnectTcp _enumStatusConnectTcpServerPrevios { get; set; } = EnumStatusConnectTcp.None;

    private void FrmWaiting_Load(object? sender, EventArgs e)
    {
      AppCore.Ins.OnSendDataRfid += Ins_OnSendDataRfid;
      AppCore.Ins.OnSendStatusConnectHID += Ins_OnSendStatusConnectHID;
      AppCore.Ins.OnSendStatusConnectServer += Ins_OnSendStatusConnectServer;

      _timerDelay.Interval = 1000;
      _timerDelay.Elapsed += TimerDelay_Elapsed;

      _timerBlink.Interval = 400;
      _timerBlink.Elapsed += _timerBlink_Elapsed;
    }

    private void _timerBlink_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      try
      {
        _timerBlink.Stop();
        BlinkStatusServer();
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
      finally
      {
        _timerBlink.Start();
      }
    }


    private void Ins_OnSendStatusConnectServer(EnumStatusConnectTcp enumStatusConnectTcp)
    {
      if (enumStatusConnectTcp != EnumStatusConnectTcp.Connect)
      {
        filterStatus++;
      }
      else
      {
        filterStatus = 0;
      }

      if (_enumStatusConnectTcpServerPrevios != enumStatusConnectTcp)
      {
        if (enumStatusConnectTcp == EnumStatusConnectTcp.Connect)
        {
          _enumStatusConnectTcpServerPrevios = enumStatusConnectTcp;
          HideStatusServer(true);
          _timerBlink.Stop();
        }
        else if ((enumStatusConnectTcp != EnumStatusConnectTcp.Connect) && filterStatus > 5)
        {
          _enumStatusConnectTcpServerPrevios = enumStatusConnectTcp;
          _timerBlink.Start();
        }
      }
    }

    private void Ins_OnSendStatusConnectHID(object? sender, bool e)
    {
      ShowStatusHID(e);
    }

    private void Ins_OnSendDataRfid(object? sender, MessageDataOutput e)
    {
      try
      {
        if (_enumStatusConnectTcpServerPrevios != EnumStatusConnectTcp.Connect)
        {
          ShowInformation("Mết kết nối Server. Không thể sử dụng hệ cân !", eImage.Warning);
          return;
        }

        string data = e?.DataAsString ?? string.Empty;

        if (AppCore.Ins._dataManager.EnumStepOperation != EnumStepOperation.Waiting) return;

        if (!string.IsNullOrEmpty(data))
        {
          _employee = AppCore.Ins._employees?.FirstOrDefault(x => x.IdCardCode == data && x.DeletedFlag == false);
          if (_employee != null)
          {
            if (_employee.Departments == null || _employee.Departments?.Count() <= 0 || _employee.Departments?.FirstOrDefault()?.DeletedFlag == true)
            {
              ShowInformation("Không tìm thấy thông tin phòng ban của thẻ !", eImage.Warning);
              return;
            }

            HideInforOperator(false);
            SetOperator(_employee);

            AppCore.Ins.LogAction($"{_employee.FullName} Quét thẻ đăng nhập", eAction.Action);
            this._timerDelay.Start();
          }
          else
          {
            ShowInformation("Không tìm thấy thông tin !", eImage.Warning);
          }
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void ShowInformation(string message, eImage eImage)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowInformation(message, eImage);
        }));
        return;
      }

      new FrmInformation().ShowMessage(message, eImage);
    }


    private async void PassLoginByRfid(Employee? employee)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          PassLoginByRfid(employee);
        }));
        return;
      }

      AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ChooseMode;
      AppCore.Ins._dataManager.DataLogPrintLabel.Employee = employee;

      FrmMain.Instance.ChangePage(AppModulSupport.Background);
      await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpChooseModeFunction);
    }

    private void SetOperator(Employee employee)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetOperator(employee);
        }));
        return;
      }

      this.lbOperator.Text = employee.FullName ?? string.Empty;
      this.lbDepartment.Text = employee.Departments?.FirstOrDefault()?.Name ?? string.Empty;
    }

    private void HideInforOperator(bool hide)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          HideInforOperator(hide);
        }));
        return;
      }

      this.lbOperator.Visible = !hide;
      this.lbHello.Visible = !hide;
      this.lbDepartment.Visible = !hide;
    }

    private void TimerDelay_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      try
      {
        this._timerDelay.Stop();
        HideInforOperator(true);
        PassLoginByRfid(_employee);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private async void label2_Click(object sender, EventArgs e)
    {
      if (AppCore.Ins._isAdmin)
      {
        FrmMain.Instance.ChangePage(AppModulSupport.Background);
        AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ChooseMode;
        await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpChooseModeFunction);
      }
      //#if DEBUG
      //      if (AppCore.Ins._isAdmin)
      //      {
      //        FrmMain.Instance.ChangePage(AppModulSupport.Background);
      //        AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ChooseMode;
      //        await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpChooseModeFunction);
      //      }
      //#elif RELEASE

      //#endif
    }


    private void btnMenu_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.InvokeRequired)
        {
          this.Invoke(new Action(() =>
          {
            var frm = FrmOptionCloseApp.Instance;

            frm.StartPosition = FormStartPosition.Manual;
            var screen = Screen.PrimaryScreen.WorkingArea;
            int x = (screen.Width - frm.Width) / 2;
            int y = (screen.Height - frm.Height) / 2 - 200;
            if (y < 0) y = 0;

            frm.OnSendRestart -= Frm_OnSendRestart;
            frm.OnSendRestart += Frm_OnSendRestart;

            frm.OnSendClose -= Frm_OnSendCloseApp;
            frm.OnSendClose += Frm_OnSendCloseApp;

            frm.OnSendMini -= Frm_OnSendMini;
            frm.OnSendMini += Frm_OnSendMini;

            frm.OnSendCheckUpdateVersion -= Frm_OnSendCheckUpdateVersion;
            frm.OnSendCheckUpdateVersion += Frm_OnSendCheckUpdateVersion;

            frm.Location = new Point(x, y);
            frm.ShowDialog();
            frm.BringToFront();
          }));
        }
        else
        {
          var frm = FrmOptionCloseApp.Instance;

          frm.StartPosition = FormStartPosition.Manual;
          var screen = Screen.PrimaryScreen.WorkingArea;
          int x = (screen.Width - frm.Width) / 2;
          int y = (screen.Height - frm.Height) / 2 - 200;
          if (y < 0) y = 0;

          frm.OnSendRestart -= Frm_OnSendRestart;
          frm.OnSendRestart += Frm_OnSendRestart;

          frm.OnSendClose -= Frm_OnSendCloseApp;
          frm.OnSendClose += Frm_OnSendCloseApp;

          frm.OnSendMini -= Frm_OnSendMini;
          frm.OnSendMini += Frm_OnSendMini;

          frm.OnSendCheckUpdateVersion -= Frm_OnSendCheckUpdateVersion;
          frm.OnSendCheckUpdateVersion += Frm_OnSendCheckUpdateVersion;

          frm.Location = new Point(x, y);
          frm.ShowDialog();
          frm.BringToFront();
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void Frm_OnSendCheckUpdateVersion(object? sender, EventArgs e)
    {
      PopupApplyVersionNew popupApplyVersionNew = new PopupApplyVersionNew();
      popupApplyVersionNew.OnSendApply += PopupApplyVersionNew_OnSendApply;
      popupApplyVersionNew.ShowDialog();
    }

    private async void PopupApplyVersionNew_OnSendApply(object? sender, string e)
    {
      AppCore.Ins._appConfig.Version = e;
      AppCore.Ins._appConfig.UpdatedAt = DateTime.Now;
      await AppCore.Ins.UpdateAppConfig_Async(AppCore.Ins._appConfig);

      string app = Path.Combine(Application.StartupPath, "Versions\\ApplyVersion\\ApplyNewVersion.exe");
      Process.Start(app);

      Application.Exit();
    }

    private void Frm_OnSendMini(object? sender, EventArgs e)
    {
      FrmMain.Instance.MiniTab();
    }

    private void Frm_OnSendRestart(object? sender, EventArgs e)
    {
      Program.StartApp();
    }

    private void Frm_OnSendCloseApp(object? sender, EventArgs e)
    {
      try
      {
        Program.CloseApp();
      }
      catch (Exception)
      {
        Environment.Exit(0);
      }
    }

    private void ShowStatusHID(bool connect)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowStatusHID(connect);
        }));
        return;
      }

      lbStatusHID.Visible = !connect;
    }

    private void HideStatusServer(bool hide)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          HideStatusServer(hide);
        }));
        return;
      }

      lbStatusConnectServer.Visible = !hide;
    }

    private void BlinkStatusServer()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          BlinkStatusServer();
        }));
        return;
      }

      lbStatusConnectServer.Visible = !lbStatusConnectServer.Visible;
    }

    private void pictureBoxLogo_Click(object sender, EventArgs e)
    {
      //try
      //{
      //  string pathFile = @"C:\Users\Admin\Downloads\V1.pdf";
      //  if (File.Exists(pathFile))
      //  {
      //    Guid poId = Guid.Parse("2783e94e-12b3-4fc1-8192-788243785885");
      //    Guid tikId = Guid.Parse("787c90ef-5c3d-4674-b355-7b322bc6ed62");
      //    var rsPost = await AppCore.Ins.UploadWeightTicketPdf(poId, tikId, pathFile);
      //  }
      //}
      //catch (Exception ex)
      //{
      //}
      //return;
      //GetMaxDeliverySchedule getMaxDelivery = new GetMaxDeliverySchedule();
      //getMaxDelivery.DeliveryScheduleId = Guid.Parse("10bad70e-f130-4365-bdd3-4c5b865ce233");
      //getMaxDelivery.MaterialId = Guid.Parse("3f02774b-264a-49c7-9e53-e1aae6b9c7cf");
      //getMaxDelivery.DataMachineId = Guid.Parse("6fdf5b6b-a646-4d79-bbab-52d4dcc9ec87");
      //getMaxDelivery.TypeData = EnumExportImport.Import;
      //var rs = await AppCore.Ins.GetMaxWeightDeliverySchedule(getMaxDelivery);
    }

    //private void pictureBoxLogo_Click(object sender, EventArgs e)
    //{
    //  try
    //  {
    //    //string poIdStr = "329031eb-f405-48ba-8ac8-40b66794c00b";
    //    //Guid poId = Guid.Parse(poIdStr);

    //    //string ticketIdStr = "329031eb-f405-48ba-8ac8-40b66794c00b";
    //    //Guid ticketId = Guid.Parse(ticketIdStr);

    //    //string pathFile = @"C:\Users\Admin\Downloads\Q5.pdf";

    //    //var rs = await AppCore.Ins.UploadWeightTicketPdf(poId, ticketId, pathFile);

    //    //string poIdStr = "6df3cb65-c594-413c-b764-21189abff352";
    //    //string mrIdStr = "8fb00651-724f-48e6-8716-29c494990fdb";
    //    //string machineIdStr = "766682a5-ebf9-437f-8ca6-8a476d7ee6c6";

    //    //Guid poId = Guid.Parse(poIdStr);
    //    //Guid mrdId = Guid.Parse(mrIdStr);
    //    //Guid machineId = Guid.Parse(machineIdStr);

    //    //GetMaxAllowedInternal getMaxAllowedInternal = new GetMaxAllowedInternal();
    //    //getMaxAllowedInternal.ProductionOrderId = poId;
    //    //getMaxAllowedInternal.DataMachineId = machineId;
    //    //getMaxAllowedInternal.MaterialId = mrdId;

    //    //var rs = await AppCore.Ins.GetMaxWeightInternal(getMaxAllowedInternal);
    //  }
    //  catch (Exception ex)
    //  {

    //  }
    //}

    //private ModbusTcpClient client = new ModbusTcpClient("192.168.5.130", 502);
    //private Random rd = new Random();
    //private void PictureBoxLogo_Click(object? sender, EventArgs e)
    //{
    //  try
    //  {
    //    int dNumber = 100;
    //    string address01 = (4096 + 100 + 0).ToString();
    //    string address02 = (4096 + 100 + 4).ToString();
    //    string address03 = (4096 + 100 + 8).ToString();

    //    double valueWrite = rd.Next(2000000, 5000000) / 1000.0;
    //    //valueWrite = 0.0;
    //    double valueWrite02 = rd.Next(1, 5) / 1000.0;
    //    int valueWrite03 = 5;


    //    valueWrite = 100.30;
    //    valueWrite02 = 5.0;
    //    valueWrite03 = 10;

    //    client.Write(
    //                    address01,   // D100 = 4096 + 100
    //                    valueWrite,
    //                    1,        // Station ID
    //                    16        // Write Multiple Registers
    //                );
    //    client.Write(
    //                    address02,   // D100 = 4096 + 100
    //                    valueWrite02,
    //                    1,        // Station ID
    //                    16        // Write Multiple Registers
    //                );
    //    client.Write(
    //                    address03,   // D100 = 4096 + 100
    //                    (Int16)valueWrite03,
    //                    1,        // Station ID
    //                    16        // Write Multiple Registers
    //                );

    //    var result = client.ReadDouble(
    //            address01,   // D100
    //            1,
    //            3         // Read Holding Registers
    //        );
    //    var result02 = client.ReadDouble(
    //            address02,   // D100
    //            1,
    //            3         // Read Holding Registers
    //        );


    //    if (result.IsSucceed)
    //    {
    //      double value = Convert.ToDouble(result.Value);
    //      double value02 = Convert.ToDouble(result02.Value);
    //      Debug.WriteLine($"Giá trị = {valueWrite} - {value}");
    //      Debug.WriteLine($"Giá trị = {valueWrite02} - {value02}");
    //    }
    //  }
    //  finally
    //  {

    //  }
    //}
  }
}
