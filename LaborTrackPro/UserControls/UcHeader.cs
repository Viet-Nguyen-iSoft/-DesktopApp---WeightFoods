using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.Forms;
using LaborTrackPro.Forms.Operation;
using Org.BouncyCastle.Math.Field;
using System.Data;
using System.Threading.Tasks;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.Controls.AppCore;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.UserControls
{
  public partial class UcHeader : UserControl
  {
    public UcHeader()
    {
      InitializeComponent();
    }

    public bool HideBackButton
    {
      set
      {
        this.btnBack.Visible = !value;
      }
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

    private void btnHome_Click(object sender, EventArgs e)
    {
      FrmMain.Instance.ChangePage(AppModulSupport.Waiting);
      AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.Waiting;
      AppCore.Ins.EndOfWeighingCycle();
    }

    private async void btnBack_Click(object sender, EventArgs e)
    {
      EnumStepOperation eStepOperation = AppCore.Ins._dataManager.EnumStepOperation;
      switch (eStepOperation)
      {
        case EnumData.EnumStepOperation.ChooseMode:
          FrmMain.Instance.ChangePage(AppModulSupport.Waiting);
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.Waiting;
          break;
        case EnumData.EnumStepOperation.ModePO:
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.AreaInternalOrExternal, true);
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.AreaInternalOrExternal;
          break;
        case EnumData.EnumStepOperation.ListPO:
          if ((AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhSanXuat)
              || (AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhLayMau)
              || (AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhDuPhong))
          {
            await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpTypePO, true);
            AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ModePO;
            //CheckMode
            FrmOpModePO.Instance.CheckHighlight();
          }
          else if (AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhThuNghiem)
          {
            await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpTypeForPoOther, true);
            AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.TypeForPoOther;
          }
          break;
        case EnumData.EnumStepOperation.TypeExportImport:
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpShowListPO, true);
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ListPO;
          break;
        case EnumData.EnumStepOperation.TypeMRInPo:
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpChooseExportImport, true);
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.TypeExportImport;
          FrmChooseExportImport.Instance.CheckHighlight();
          break;
        case EnumData.EnumStepOperation.DetailMRs:
          if (FrmDetailMRs.Instance._enumGroupData == EnumGroupData.Level1)
          {
            await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpTypeMR, true);
            AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.TypeMRInPo;
          }
          else
          {
            await FrmDetailMRs.Instance.LoadItemMaterial();
          }
          break;
        case EnumData.EnumStepOperation.DetailRMs_BTP_Defect:
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpDetailMRs, true);
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.DetailMRs;
          break;
        case EnumData.EnumStepOperation.Print:
          if (AppCore.Ins._dataManager.DataLogPrintLabel.EnumMaterialType == EnumMaterialType.Material ||
            AppCore.Ins._dataManager.DataLogPrintLabel.EnumMaterialType == EnumMaterialType.SemiFinishedGoods ||
            AppCore.Ins._dataManager.DataLogPrintLabel.EnumMaterialType == EnumMaterialType.MRsDefect ||
           AppCore.Ins._dataManager.DataLogPrintLabel.EnumMaterialType == EnumMaterialType.RawMaterial)
          {
            if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Import)
            {
              await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpRMs_BTP_Defect, true);
              AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.DetailRMs_BTP_Defect;
            }
            else
            {
              await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpDetailMRs, true);
              AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.DetailMRs;
            }
          }
          else if (AppCore.Ins._dataManager.DataLogPrintLabel.EnumMaterialType == EnumMaterialType.FinshGoods)
          {
            await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpDetailMRs, true);
            AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.DetailMRs;
          }
          AppCore.Ins._dataManager.DataLogPrintLabel.TypeTare = EnumTypeTare.None;
          break;
        case EnumData.EnumStepOperation.AreaInternalOrExternal:
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpChooseModeFunction, true);
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ChooseMode;
          break;
        case EnumData.EnumStepOperation.ScanReceiving:
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.TypeExportImport;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpChooseExportImport, true);
          break;
        case EnumData.EnumStepOperation.ScanDelivery:
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ScanReceiving;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.ScanReceiving, true);
          break;
        case EnumData.EnumStepOperation.DeliveryPlan:
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ScanDelivery;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.ScanDelivery, true);
          break;
        case EnumData.EnumStepOperation.ListItemDelivery:
          if (AppCore.Ins._dataManager.EnumInternalExternalStatus == EnumInternalExternalStatus.Internal)
          {
            if (AppCore.Ins._dataManager.DataLogDelivery.IsDelivery == true)
            {
              AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.DeliveryPlan;
              await FrmPageOperation.Instance.ChangePage(AppModulSupport.DeliveryPlan, true);
            }
            else
            {
              AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ScanDelivery;
              await FrmPageOperation.Instance.ChangePage(AppModulSupport.ScanDelivery, true);
            }
          }
          else if (AppCore.Ins._dataManager.EnumInternalExternalStatus == EnumInternalExternalStatus.External)
          {
            AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ScanReceiving;
            await FrmPageOperation.Instance.ChangePage(AppModulSupport.ScanReceiving, true);
          }
          break;
        case EnumData.EnumStepOperation.ReviewDelivery:
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ListItemDelivery;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.ListItemDelivery, true);
          break;
        case EnumData.EnumStepOperation.MaterialAllOther:
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpTypeMR, true);
          break;
        case EnumData.EnumStepOperation.TypeForPoOther:
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ModePO;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpTypePO, true);
          break;
        default:
          break;
      }
    }
  }
}
