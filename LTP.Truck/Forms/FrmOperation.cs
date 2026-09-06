using HelperManager;
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
using static LTP.Truck.EnumData;

namespace LTP.Truck.Forms
{
  public partial class FrmOperation : Form
  {
    public FrmOperation()
    {
      InitializeComponent();
      this.Load += FrmOperation_Load;
    }

    #region Instance
    private static FrmOperation _Instance = null;
    public static FrmOperation Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmOperation();
        return _Instance;
      }
    }
    #endregion

    private void btnClose_Click(object sender, EventArgs e)
    {
      Program.CloseApp();
    }

    private void FrmOperation_Load(object? sender, EventArgs e)
    {
      this.btnHome.Click += btnHome_Click;
      this.btnHome.PerformClick();

      this.btnClient.Click += BtnClient_Click;
      this.btnTypeGoods.Click += BtnTypeGoods_Click;
      this.btnWarehouse.Click += BtnWarehouse_Click;
    }

    private async void BtnWarehouse_Click(object? sender, EventArgs e)
    {
      await ChangePage(EnumScreen.MD_Warehouse);
    }

    private async void BtnTypeGoods_Click(object? sender, EventArgs e)
    {
      await ChangePage(EnumScreen.MD_TypeGoods);
    }
    private async void BtnClient_Click(object? sender, EventArgs e)
    {
      await ChangePage(EnumScreen.MD_Client);
    }
    private async void btnMasterData_Click(object sender, EventArgs e)
    {
      await ChangePage(EnumScreen.MD_Client);
    }
    

    private async void btnHome_Click(object? sender, EventArgs e)
    {
      await ChangePage(EnumScreen.Home);
    }
    private async void btnSetting_Click(object sender, EventArgs e)
    {
      await ChangePage(EnumScreen.Setting);
    }
    

    #region ChangePage
    public async Task ChangePage(EnumScreen appModulSupport, bool actionBack = false)
    {
      try
      {
        switch (appModulSupport)
        {
          case EnumScreen.Home:
            OpenChildForm(appModulSupport, FrmHome.Instance);
            break;
          case EnumScreen.Setting:
            OpenChildForm(appModulSupport, FrmSetting.Instance);
            break;
          case EnumScreen.MD_Client:
            OpenChildForm(appModulSupport, FrmMasterData.Instance);
            await FrmMasterData.Instance.LoadData(EnumTypeMasterData.Client);
            break;
          case EnumScreen.MD_TypeGoods:
            OpenChildForm(appModulSupport, FrmMasterData.Instance);
            await FrmMasterData.Instance.LoadData(EnumTypeMasterData.TypeGoods);
            break;
          case EnumScreen.MD_Warehouse:
            OpenChildForm(appModulSupport, FrmMasterData.Instance);
            await FrmMasterData.Instance.LoadData(EnumTypeMasterData.Warehouse);
            break;
            //case AppModulSupport.AreaInternalOrExternal:
            //  OpenChildForm(appModulSupport, FrmInternalOrExternal.Instance);
            //  HideBackButton(false);
            //  FrmInternalOrExternal.Instance.CheckHighlight();
            //  break;
            //case AppModulSupport.OpTypePO:
            //  OpenChildForm(appModulSupport, FrmOpModePO.Instance);
            //  HideBackButton(false);
            //  FrmOpModePO.Instance.CheckHighlight();
            //  break;
            //case AppModulSupport.OpShowListPO:
            //  OpenChildForm(appModulSupport, FrmOpListPO.Instance);
            //  HideBackButton(false);
            //  if (!actionBack)
            //    FrmOpListPO.Instance.LoadDataByChangeMode();
            //  break;
            //case AppModulSupport.OpTypeForPoOther:
            //  OpenChildForm(appModulSupport, FrmTypeForPOOther.Instance);
            //  HideBackButton(false);
            //  FrmTypeForPOOther.Instance.CheckHighlight();
            //  break;
            //case AppModulSupport.OpChooseExportImport:
            //  OpenChildForm(appModulSupport, FrmChooseExportImport.Instance);
            //  FrmChooseExportImport.Instance.CheckChangeTitle();
            //  FrmChooseExportImport.Instance.CheckHighlight();
            //  HideBackButton(false);
            //  break;
            //case AppModulSupport.OpTypeMR:
            //  OpenChildForm(appModulSupport, FrmTypeMR.Instance);
            //  HideBackButton(false);
            //  break;
            //case AppModulSupport.OpDetailMRs:
            //  OpenChildForm(appModulSupport, FrmDetailMRs.Instance);
            //  HideBackButton(false);
            //  if (!actionBack)
            //  {
            //    await FrmDetailMRs.Instance.LoadItemMaterial();
            //  }
            //  break;
            //case AppModulSupport.OpRMs_BTP_Defect:
            //  AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.DetailRMs_BTP_Defect;
            //  OpenChildForm(appModulSupport, FrmListMRs_BTP_Defect.Instance);
            //  HideBackButton(false);
            //  if (!actionBack)
            //    FrmListMRs_BTP_Defect.Instance.LoadItemMaterial();
            //  break;
            //case AppModulSupport.OperationPrint:
            //  AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.Print;
            //  OpenChildForm(appModulSupport, FrmOperationPrint.Instance);
            //  HideBackButton(false);
            //  if (!actionBack)
            //    FrmOperationPrint.Instance.ShowData();
            //  break;
            //case AppModulSupport.Menu:
            //  OpenChildForm(appModulSupport, FrmMenu.Instance);
            //  HideBackButton(true);
            //  break;
            //case AppModulSupport.Setting:
            //  OpenChildForm(appModulSupport, FrmSetting.Instance);
            //  HideBackButton(true);
            //  break;
            //case AppModulSupport.LoadingPrintting:
            //  OpenChildForm(appModulSupport, FrmLoadingPrinting.Instance);
            //  HideBackButton(true);
            //  break;
            //case AppModulSupport.MasterData:
            //  OpenChildForm(appModulSupport, FrmMasterData.Instance);
            //  HideBackButton(true);
            //  break;
            //case AppModulSupport.CheckUpdateVer:
            //  OpenChildForm(appModulSupport, FrmCheckVersion.Instance);
            //  HideBackButton(true);
            //  break;

            //case AppModulSupport.ScanReceiving:
            //  OpenChildForm(appModulSupport, FrmScanRfidReceiving.Instance);
            //  HideBackButton(false);
            //  AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ScanReceiving;
            //  if (!actionBack)
            //  {
            //    if (AppCore.Ins._dataManager.EnumInternalExternalStatus == EnumInternalExternalStatus.External)
            //    {
            //      if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Import)
            //        FrmScanRfidReceiving.Instance.SetTitle("Thông tin bên nhận");
            //      if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Export)
            //        FrmScanRfidReceiving.Instance.SetTitle("Thông tin bên giao");
            //    }
            //    else
            //    {
            //      FrmScanRfidReceiving.Instance.SetTitle("Thông tin bên nhận");
            //    }
            //  }
            //  break;
            //case AppModulSupport.ScanDelivery:
            //  OpenChildForm(appModulSupport, FrmScanRfidDelivery.Instance);
            //  HideBackButton(false);
            //  AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ScanDelivery;
            //  if (!actionBack)
            //  {
            //    FrmScanRfidDelivery.Instance.SetTitle("Thông tin bên giao");
            //  }
            //  break;
            //case AppModulSupport.DeliveryPlan:
            //  OpenChildForm(appModulSupport, FrmChooseDelivery.Instance);
            //  HideBackButton(false);
            //  if (!actionBack)
            //    await FrmChooseDelivery.Instance.ShowListData();
            //  break;
            //case AppModulSupport.ListItemDelivery:
            //  OpenChildForm(appModulSupport, FrmListItemDelivery.Instance);
            //  HideBackButton(false);
            //  FrmListItemDelivery.Instance.ApplyCheckedRowsStyle();
            //  if (!actionBack)
            //    FrmListItemDelivery.Instance.ShowListData();
            //  break;
            //case AppModulSupport.ReviewDelivery:
            //  OpenChildForm(appModulSupport, FrmReviewDelivery.Instance);
            //  HideBackButton(false);
            //  AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ReviewDelivery;
            //  if (!actionBack)
            //    await FrmReviewDelivery.Instance.ShowData();
            //  break;

        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private Form CurrentForm;
    public void OpenChildForm(EnumScreen modulSupport, Form childForm)
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
        if (this.panelMain.Tag is Tuple<EnumScreen, Form>)
        {
          Tuple<EnumScreen, Form> TagAsForm = (Tuple<EnumScreen, Form>)(this.panelMain.Tag);
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

  }
}
