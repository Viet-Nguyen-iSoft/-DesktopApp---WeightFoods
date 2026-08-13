using HelperManager;
using iSoft.Database.Models;
using LaborTrackPro.Communication;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.UserControls;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmScanRfidDelivery : Form
  {
    public FrmScanRfidDelivery()
    {
      InitializeComponent();
      CustomUI();
      this.Load += FrmScanRfid_Load;
    }


    #region Instance
    private static FrmScanRfidDelivery _Instance = null;
    public static FrmScanRfidDelivery Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmScanRfidDelivery();
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

    private void CustomUI()
    {
      ucTitleFrm.FunctionButton(eTypeButton.None);
      ucTitleFrm.Title = "Thông tin bên giao";
      ucTitleFrm.Image = Properties.Resources.icon_info;
    }

    private void FrmScanRfid_Load(object? sender, EventArgs e)
    {
      AppCore.Ins.OnSendDataRfid += Ins_OnSendDataRfid;
      AppCore.Ins.OnSendEndOfWeighingCycle += Ins_OnSendEndOfWeighingCycle;
      AppCore.Ins.OnSendEndOfWeighingDeliveryCycle += Ins_OnSendEndOfWeighingDeliveryCycle;

      this.Shown += (s, e) =>
      {
        this.ActiveControl = null;
        this.Focus();
      };
    }

    private void Ins_OnSendDataRfid(object? sender, MessageDataOutput e)
    {
      try
      {
        bool isActive = AppCore.Ins._dataManager.EnumStepOperation == EnumStepOperation.ScanDelivery;
        if (!isActive) return;

        string data = e?.DataAsString ?? string.Empty;
        if (!string.IsNullOrEmpty(data))
        {
          var employee = AppCore.Ins._employees?.FirstOrDefault(x => x.IdCardCode == data && !x.DeletedFlag);
          if (employee == null)
          {
            new FrmInformation().ShowMessage("Không tìm thấy thông tin !", eImage.Warning);
            return;
          }

          SetInforIdCard(employee);
          AppCore.Ins._dataManager.DataLogDelivery.EmployeeDelivery = employee;
        }
        else
        {
          new FrmInformation().ShowMessage("Thẻ có mã trống, kiểm tra lại !", eImage.Warning);
          return;
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    public void SetInforIdCard(Employee? employee)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetInforIdCard(employee);
        }));
        return;
      }

      if (employee != null)
      {
        this.btnNext.Enabled = true;
        this.btnNext.BackColor = Color.FromArgb(49, 68, 108);
        ucIdCard.IdCardName = employee?.FullName ?? "N/A";
        ucIdCard.DepartmentName = employee?.Departments?.FirstOrDefault()?.Name ?? "N/A";
      }
      else
      {
        this.btnNext.Enabled = false;
        this.btnNext.BackColor = Color.Gray;
        ucIdCard.IdCardName = "...";
        ucIdCard.DepartmentName = "...";
      }
    }

    public void SetTitle(string title)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetTitle(title);
        }));
        return;
      }
      ucIdCard.Title = title;
      ucTitleFrm.Title = title;
    }

    private void Ins_OnSendEndOfWeighingDeliveryCycle()
    {
      SetInforIdCard(null);
    }

    private void Ins_OnSendEndOfWeighingCycle()
    {
      AppCore.Ins._dataManager.DataLogDelivery.EmployeeQC = null;
      AppCore.Ins._dataManager.DataLogDelivery.EmployeeDelivery = null;
      AppCore.Ins._dataManager.DataLogDelivery.EmployeeReceiving = null;
      SetInforIdCard(null);
    }

    private async void btnNext_Click(object sender, EventArgs e)
    {
      if (AppCore.Ins._dataManager.EnumInternalExternalStatus == HelperManager.EnumData.EnumInternalExternalStatus.Internal)
      {
        //Kiểm tra in phiếu nội bộ hay giữa các phòng ban
        AppCore.Ins._dataManager.DataLogDelivery.IsDelivery = AppCore.Ins._dataManager.DataLogDelivery?.EmployeeReceivingFirst?.Departments?.FirstOrDefault()?.EnumGroup == HelperManager.EnumData.EnumGroup.Warehouse ||
                                                              AppCore.Ins._dataManager.DataLogDelivery?.EmployeeDelivery?.Departments?.FirstOrDefault()?.EnumGroup == HelperManager.EnumData.EnumGroup.Warehouse;
        if (AppCore.Ins._dataManager?.DataLogDelivery?.IsDelivery == true)
        {
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.DeliveryPlan;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.DeliveryPlan);
        }
        else
        {
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ListItemDelivery;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.ListItemDelivery);
        }
      }
      else if (AppCore.Ins._dataManager.EnumInternalExternalStatus == HelperManager.EnumData.EnumInternalExternalStatus.External)
      {
        AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ListItemDelivery;
        await FrmPageOperation.Instance.ChangePage(AppModulSupport.ListItemDelivery);
      }  
    }
  }
}
