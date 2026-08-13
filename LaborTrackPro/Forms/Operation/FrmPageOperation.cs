using HelperManager;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.Forms.CheckUpdate;
using LaborTrackPro.Forms.Operation;
using LaborTrackPro.Forms.Settings;
using LaborTrackPro.FrmChild.Operation;
using LaborTrackPro.Setting;
using static HelperManager.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms
{
  public partial class FrmPageOperation : Form
  {
    private System.Timers.Timer timerRealtimeShowUI = new System.Timers.Timer();
    private bool _rolePermitAccessMenu = false;
    public FrmPageOperation()
    {
      InitializeComponent();
      this.Load += FrmBackground_Load;
    }

    #region Instance
    private static FrmPageOperation _Instance = null;
    public static FrmPageOperation Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmPageOperation();
        return _Instance;
      }
    }
    #endregion

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
    private void FrmBackground_Load(object? sender, EventArgs e)
    {
      this.timerRealtimeShowUI.Interval = 1000;
      this.timerRealtimeShowUI.Elapsed += TimerRealtimeShowUI_Elapsed;
      this.timerRealtimeShowUI.Start();

      AppCore.Ins.OnSendStatusConnectServer += Ins_OnSendStatusConnectServer;
      AppCore.Ins.OnSendStatusConnectWeight += Ins_OnSendStatusConnectWeight;

      ucFooter.SetVersion(AppCore.Ins._inforLine);
      ucFooter.VisibleSetting = AppCore.Ins._isAdmin;
    }

    private EnumStatusConnectTcp _enumStatusConnectTcpPrevious_Weight = EnumStatusConnectTcp.None;
    private void Ins_OnSendStatusConnectWeight(object? sender, EnumStatusConnectTcp e)
    {
      if (_enumStatusConnectTcpPrevious_Weight != e)
      {
        _enumStatusConnectTcpPrevious_Weight = e;
        ucFooter.SetStatusWeight(e);
      }
    }

    private EnumStatusConnectTcp _enumStatusConnectTcpPrevious_Server = EnumStatusConnectTcp.None;
    private void Ins_OnSendStatusConnectServer(EnumStatusConnectTcp enumStatusConnectTcp)
    {
      if (_enumStatusConnectTcpPrevious_Server!= enumStatusConnectTcp)
      {
        _enumStatusConnectTcpPrevious_Server = enumStatusConnectTcp;
        ucFooter.SetStatusServer(enumStatusConnectTcp);
      } 
    }

    private void TimerRealtimeShowUI_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      try
      {
        this.timerRealtimeShowUI.Stop();
        ShowTimeUI();
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
      finally
      {
        this.timerRealtimeShowUI.Start();
      }
    }

    private void ShowTimeUI()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowTimeUI();
        }));
        return;
      }

      DateTime dt = DateTime.Now;
      ucFooter.Datetime = dt.ToString("HH:mm:ss dd/MM/yyyy");
    }


    #region ChangePage
    public async Task ChangePage(AppModulSupport appModulSupport, bool actionBack = false)
    {
      try
      {
        switch (appModulSupport)
        {
          case AppModulSupport.OpChooseModeFunction:
            OpenChildForm(appModulSupport, FrmChooseModeFunction.Instance);
            HideBackButton(false);
            FrmChooseModeFunction.Instance.CheckHighlight();
            break;
          case AppModulSupport.AreaInternalOrExternal:
            OpenChildForm(appModulSupport, FrmInternalOrExternal.Instance);
            HideBackButton(false);
            FrmInternalOrExternal.Instance.CheckHighlight();
            break;
          case AppModulSupport.OpTypePO:
            OpenChildForm(appModulSupport, FrmOpModePO.Instance);
            HideBackButton(false);
            FrmOpModePO.Instance.CheckHighlight();
            break;
          case AppModulSupport.OpShowListPO:
            OpenChildForm(appModulSupport, FrmOpListPO.Instance);
            HideBackButton(false);
            if (!actionBack)
              FrmOpListPO.Instance.LoadDataByChangeMode();
            break;
          case AppModulSupport.OpTypeForPoOther:
            OpenChildForm(appModulSupport, FrmTypeForPOOther.Instance);
            HideBackButton(false);
            FrmTypeForPOOther.Instance.CheckHighlight();
            break;
          case AppModulSupport.OpChooseExportImport:
            OpenChildForm(appModulSupport, FrmChooseExportImport.Instance);
            FrmChooseExportImport.Instance.CheckChangeTitle();
            FrmChooseExportImport.Instance.CheckHighlight();
            HideBackButton(false);
            break;
          case AppModulSupport.OpTypeMR:
            OpenChildForm(appModulSupport, FrmTypeMR.Instance);
            HideBackButton(false);
            break;
          case AppModulSupport.OpDetailMRs:
            OpenChildForm(appModulSupport, FrmDetailMRs.Instance);
            HideBackButton(false);
            if (!actionBack)
            {
              await FrmDetailMRs.Instance.LoadItemMaterial();
            }  
            break;
          case AppModulSupport.OpRMs_BTP_Defect:
            AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.DetailRMs_BTP_Defect;
            OpenChildForm(appModulSupport, FrmListMRs_BTP_Defect.Instance);
            HideBackButton(false);
            if (!actionBack)
              FrmListMRs_BTP_Defect.Instance.LoadItemMaterial();
            break;
          case AppModulSupport.OperationPrint:
            AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.Print;
            OpenChildForm(appModulSupport, FrmOperationPrint.Instance);
            HideBackButton(false);
            if (!actionBack)
              FrmOperationPrint.Instance.ShowData();
            break;
          case AppModulSupport.Menu:
            OpenChildForm(appModulSupport, FrmMenu.Instance);
            HideBackButton(true);
            break;
          case AppModulSupport.Setting:
            OpenChildForm(appModulSupport, FrmSetting.Instance);
            HideBackButton(true);
            break;
          case AppModulSupport.LoadingPrintting:
            OpenChildForm(appModulSupport, FrmLoadingPrinting.Instance);
            HideBackButton(true);
            break;
          case AppModulSupport.MasterData:
            OpenChildForm(appModulSupport, FrmMasterData.Instance);
            HideBackButton(true);
            break;
          case AppModulSupport.CheckUpdateVer:
            OpenChildForm(appModulSupport, FrmCheckVersion.Instance);
            HideBackButton(true);
            break;
         
          case AppModulSupport.ScanReceiving:
            OpenChildForm(appModulSupport, FrmScanRfidReceiving.Instance);
            HideBackButton(false);
            AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ScanReceiving;
            if (!actionBack)
            {
              if (AppCore.Ins._dataManager.EnumInternalExternalStatus == EnumInternalExternalStatus.External)
              {
                if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Import)
                  FrmScanRfidReceiving.Instance.SetTitle("Thông tin bên nhận");
                if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Export)
                  FrmScanRfidReceiving.Instance.SetTitle("Thông tin bên giao");
              }  
              else
              {
                FrmScanRfidReceiving.Instance.SetTitle("Thông tin bên nhận");
              }  
            }  
            break;
          case AppModulSupport.ScanDelivery:
            OpenChildForm(appModulSupport, FrmScanRfidDelivery.Instance);
            HideBackButton(false);
            AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ScanDelivery;
            if (!actionBack)
            {
              FrmScanRfidDelivery.Instance.SetTitle("Thông tin bên giao");
            }
            break;
          case AppModulSupport.DeliveryPlan:
            OpenChildForm(appModulSupport, FrmChooseDelivery.Instance);
            HideBackButton(false);
            if (!actionBack)
              await FrmChooseDelivery.Instance.ShowListData();
            break;
          case AppModulSupport.ListItemDelivery:
            OpenChildForm(appModulSupport, FrmListItemDelivery.Instance);
            HideBackButton(false);
            FrmListItemDelivery.Instance.ApplyCheckedRowsStyle();
            if (!actionBack)
              FrmListItemDelivery.Instance.ShowListData();
            break;
          case AppModulSupport.ReviewDelivery:
            OpenChildForm(appModulSupport, FrmReviewDelivery.Instance);
            HideBackButton(false);
            AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ReviewDelivery;
            if (!actionBack)
              await FrmReviewDelivery.Instance.ShowData();
            break;
         
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
      finally
      {
        AppCore.Ins.ResetIdle();
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
    }
    #endregion


    public void HideBackButton(bool hide)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          HideBackButton(hide);
        }));
        return;
      }

      this.ucHeader.HideBackButton = hide;
    }

  }
}
