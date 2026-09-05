using HelperManager;
using iSoft.Communication.Communication;
using iSoft.Communication.Interface;
using iSoft.Communication.JsonPayload;
using LaborTrackPro.Communication;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.Forms;
using System.Diagnostics;
using static iSoft.Communication.EnumCommunication;
using static LaborTrackPro.EnumData;
using Message = System.Windows.Forms.Message;

namespace LaborTrackPro
{
  public partial class FrmMain : Form
  {
    #region Event
    public delegate void SendChangeFactory();
    public event SendChangeFactory? OnSendChangeFactory;

    public delegate void SendChangeMachine();
    public event SendChangeMachine? OnSendChangeMachine;

    public delegate void SendChangeProduction();
    public event SendChangeProduction? OnSendChangeProduction;

    public delegate void SendChangeMaterial();
    public event SendChangeMaterial? OnSendChangeMaterial;

    public delegate void SendChangeProductionOrder();
    public event SendChangeProductionOrder? OnSendChangeProductionOrder;

    public delegate void SendChangeDepartment();
    public event SendChangeDepartment? OnSendChangeDepartment;

    public delegate void SendChangeSettingTare();
    public event SendChangeSettingTare? OnSendChangeSettingTare;

    public delegate void SendChangeEmployee();
    public event SendChangeEmployee? OnSendChangeEmployee;

    public delegate void SendChangeImage();
    public event SendChangeImage? OnSendChangeImage;

    #endregion

    #region Instance
    private static FrmMain _Instance = null;
    public static FrmMain Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmMain();
        return _Instance;
      }
    }
    #endregion


    public FrmMain()
    {
      InitializeComponent();

      this.FormBorderStyle = FormBorderStyle.None;
      this.WindowState = FormWindowState.Maximized;

      this.TopMost = AppCore.Ins._isTopMost;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Enter)
      {
        if (this.ActiveControl is Button btn && btn.Focused)
        {
          return true;
        }
        if (this.ActiveControl is RJButton btnRJ && btnRJ.Focused)
        {
          return true;
        }
        if (this.ActiveControl is UserControl uc && uc.Focused)
        {
          return true;
        }
        if (this.ActiveControl is DataGridView dgv && dgv.Focused)
        {
          return true;
        }
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    #region ChangePage
    public void ChangePage(AppModulSupport appModulSupport)
    {
      switch (appModulSupport)
      {
        case AppModulSupport.Waiting:
          OpenChildForm(appModulSupport, FrmWaiting.Instance);
          break;
        case AppModulSupport.Operation:
          OpenChildForm(appModulSupport, FrmOperation.Instance);
          break;
      }
    }

    private Form CurrentForm;
    public void OpenChildForm(AppModulSupport modulSupport, Form childForm)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          OpenChildForm(modulSupport, childForm);
        }));
        return;
      }

      bool Is_same_form = false;
      if (this.panelMain.Tag != null)
      {
        if (this.panelMain.Tag is Tuple<AppModulSupport, Form>)
        {
          Tuple<AppModulSupport, Form> TagAsForm = (Tuple<AppModulSupport, Form>)(this.panelMain.Tag);
          if (TagAsForm.Item1 == modulSupport)
          {
            Is_same_form = true;
          }
        }
      }
      if (Is_same_form == false)
      {
        if (CurrentForm != null)
        {
          CurrentForm.Visible = false;
        }
        this.panelMain.Controls.Clear();
        this.panelMain.Tag = Tuple.Create(modulSupport, childForm);
        CurrentForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        childForm.BringToFront();
        this.panelMain.Controls.Add(childForm);
        childForm.Show();
      }
      else
      {

      }
    }
    #endregion

    public void ShowMainForm()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowMainForm();
        }));
        return;
      }
      try
      {
        this.WindowState = FormWindowState.Maximized;
        this.ShowInTaskbar = true;
        this.ShowDialog();
        this.BringToFront();
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private const string ScaleId = "SCALE_01";

    private readonly ICommunicationService _communication =
        new CommunicationService();
    private void FrmMain_Load(object sender, EventArgs e)
    {
      CheckOpenMulApp();
      ChangePage(AppModulSupport.Waiting);


      //_communication.DataReceived += Communication_DataReceived;
      //_communication.ConnectionStatusChanged += Communication_StatusChanged;

      //var config = new ConfigTcpClient
      //{
      //  Code = ScaleId,
      //  NameDevice = "Cân TCP",
      //  Host = "192.168.1.15",
      //  Port = 8000,
      //  eModeCommunication = eModeCommunication.SICS,
      //  AutoConnect = true,
      //  TimeoutMs = 5000,
      //  Request = true,
      //  TimeRequest = 200
      //};

      //_communication.AddConnection(
      //    config,
      //    machineId: null,
      //    device: eDevice.Weight);

      //_communication.Connect(ScaleId);

    }

    private void Communication_DataReceived(
       object? sender,
       iSoft.Communication.Interface.MessageDataOutput data)
    {
      BeginInvoke(() =>
      {
        var a = data.ValueWeight.ToString();
        //txtWeight.Text = data.ValueWeight.ToString();
      });
    }

    private void Communication_StatusChanged(
        object? sender,
        CommunicationStatusChangedEventArgs e)
    {
      BeginInvoke(() =>
      {
        //lblStatus.Text = e.IsConnected
        //    ? $"{e.ConnectionId}: Connected"
        //    : $"{e.ConnectionId}: Disconnected";
      });
    }

    private void CheckOpenMulApp()
    {
      string procName = Process.GetCurrentProcess().ProcessName;
      Process[] processes = Process.GetProcessesByName(procName);
      if (processes.Length > 1)
      {
        Program.CloseApp();
      }
    }

    private async void FrmMain_Shown(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(AppCore.Ins._connectionsWeight?.JsonStrConfig))
      {
        var config = JsonHelper.FromJson<TcpClientJson>(AppCore.Ins._connectionsWeight.JsonStrConfig);
        if (config != null)
        {
          AppCore.Ins.InitWeight(AppCore.Ins._connectionsWeight?.Name ?? "N/A", config);
        }
      }

      if (!string.IsNullOrEmpty(AppCore.Ins._connectionsHID?.JsonStrConfig))
      {
        var config = JsonHelper.FromJson<TcpClientJson>(AppCore.Ins._connectionsHID.JsonStrConfig);
        if (config != null)
        {
          AppCore.Ins.InitHID(config);
        }
      }


      if (AppCore.Ins._isAdmin)
      {
        AppCore.Ins.InitRfidUsb();
      }

      //AppCore.Ins.CheckConnectServer();

      //await AppCore.Ins.StartData();
    }

    public void CallEvent(eTypeDataRefresh eTypeDataRefresh)
    {
      try
      {
        if (this.InvokeRequired)
        {
          this.Invoke(new Action(() =>
          {
            CallEvent(eTypeDataRefresh);
          }));
          return;
        }

        switch (eTypeDataRefresh)
        {
          case eTypeDataRefresh.Production:
            OnSendChangeProduction?.Invoke();
            break;
          case eTypeDataRefresh.Material:
            OnSendChangeMaterial?.Invoke();
            break;
          case eTypeDataRefresh.ProductionOrder:
            OnSendChangeProductionOrder?.Invoke();
            break;
          case eTypeDataRefresh.Factory:
            OnSendChangeFactory?.Invoke();
            break;
          case eTypeDataRefresh.Machine:
            OnSendChangeMachine?.Invoke();
            break;
          case eTypeDataRefresh.Department:
            OnSendChangeDepartment?.Invoke();
            break;
          case eTypeDataRefresh.Employee:
            OnSendChangeEmployee?.Invoke();
            break;
          case eTypeDataRefresh.SettingTare:
            OnSendChangeSettingTare?.Invoke();
            break;
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public void MiniTab()
    {
      this.WindowState = FormWindowState.Minimized;
    }
  }
}
