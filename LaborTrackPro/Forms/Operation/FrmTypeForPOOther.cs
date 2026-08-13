using HelperManager;
using LaborTrackPro.Controls;
using LaborTrackPro.UserControls;
using System.Windows.Forms;
using static HelperManager.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmTypeForPOOther : Form
  {
    public FrmTypeForPOOther()
    {
      InitializeComponent();

      CustomUI();
      
      this.Load += FrmTypeForPOOther_Load;
      this.Shown += FrmTypeForPOOther_Shown;
    }


    private void FrmTypeForPOOther_Load(object? sender, EventArgs e)
    {
      AppCore.Ins.OnSendEndOfWeighingCycle += Ins_OnSendEndOfCycle;
      AppCore.Ins.OnSendEndOfWeighingDeliveryCycle += Ins_OnSendEndOfCycle;
    }

    private void FrmTypeForPOOther_Shown(object? sender, EventArgs e)
    {
      ShowControls();
    }

    private void Ins_OnSendEndOfCycle()
    {
      ClearHighlight();
    }

    #region Instance
    private static FrmTypeForPOOther _Instance = null;
    public static FrmTypeForPOOther Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmTypeForPOOther();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      this.ucTitleFrm.FunctionButton(eTypeButton.None);
      this.ucTitleFrm.Title = "Chọn hình thức của Lệnh thử nghiệm";
      this.ucTitleFrm.Image = Properties.Resources.icon_type;
    }

    private string[] _mode = new string[] { "Kiểm tra máy", "Kiểm tra SP mới", "Làm mẫu" };
    private int _padding = 50;
    private void ShowControls()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowControls();
        }));
        return;
      }

      try
      {
        flowLayoutPanel.Controls.Clear();
        flowLayoutPanel.WrapContents = false;
        flowLayoutPanel.AutoScroll = false;
        flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;

        int ucWidth = 450;
        int ucHeight = 600;

        int totalWidth = _mode.Length * (ucWidth + _padding * 2);
        int emptySpace = flowLayoutPanel.ClientSize.Width - totalWidth;

        // Nếu còn dư thì add panel rỗng để căn giữa
        if (emptySpace > 0)
        {
          Panel spacer = new Panel();
          spacer.Width = emptySpace / 2;
          spacer.Height = 1;
          flowLayoutPanel.Controls.Add(spacer);
        }

        foreach (var mode in _mode)
        {
          var uc = new UcItemMode(mode);
          uc.Margin = new Padding(_padding);
          uc.Width = ucWidth;
          uc.Height = ucHeight;
          uc.Title = mode;
          uc.Tag = mode;
          if (mode == _mode[0])
          {
            uc.Image = Properties.Resources.icon_PO;
          }
          else if (mode == _mode[1])
          {
            uc.Image = Properties.Resources.icon_PO;
          }
          else if (mode == _mode[2])
          {
            uc.Image = Properties.Resources.icon_PO;
          }

          uc.OnSendItemClicked += Uc_OnSendItemClicked;
          flowLayoutPanel.Controls.Add(uc);
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private async void Uc_OnSendItemClicked(object? sender, string e)
    {
      try
      {
        if (e == _mode[0])
        {
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ListPO;
          AppCore.Ins._dataManager.EnumProductionOrderType = EnumProductionOrderType.LenhThuNghiem;
          AppCore.Ins._dataManager.EnumProductionOrderCategory = EnumProductionOrderCategory.MachineTesting;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpShowListPO);
        }
        else if (e == _mode[1])
        {
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ListPO;
          AppCore.Ins._dataManager.EnumProductionOrderType = EnumProductionOrderType.LenhThuNghiem;
          AppCore.Ins._dataManager.EnumProductionOrderCategory = EnumProductionOrderCategory.NewProductTesting;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpShowListPO);
        }
        else if (e == _mode[2])
        {
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ListPO;
          AppCore.Ins._dataManager.EnumProductionOrderType = EnumProductionOrderType.LenhThuNghiem;
          AppCore.Ins._dataManager.EnumProductionOrderCategory = EnumProductionOrderCategory.SampleProduction;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpShowListPO);
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    public void CheckHighlight()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          CheckHighlight();
        }));
        return;
      }

      try
      {
        var all_uc = flowLayoutPanel.Controls
                        .OfType<UcItemMode>()
                        .ToList();

        if (AppCore.Ins._dataManager.EnumProductionOrderCategory == EnumProductionOrderCategory.MachineTesting)
        {
          all_uc.ForEach(uc => uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[0]));
        }
        else if (AppCore.Ins._dataManager.EnumProductionOrderCategory == EnumProductionOrderCategory.NewProductTesting)
        {
          all_uc.ForEach(uc => uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[1]));
        }
        else if (AppCore.Ins._dataManager.EnumProductionOrderCategory == EnumProductionOrderCategory.SampleProduction)
        {
          all_uc.ForEach(uc => uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[2]));
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    public void ClearHighlight()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ClearHighlight();
        }));
        return;
      }

      try
      {
        var all_uc = flowLayoutPanel.Controls
                        .OfType<UcItemMode>()
                        .ToList();
        if (all_uc?.Count()>0)
        {
          all_uc.ForEach(uc => uc.Highlight(false));
        }  
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }




  }
}
