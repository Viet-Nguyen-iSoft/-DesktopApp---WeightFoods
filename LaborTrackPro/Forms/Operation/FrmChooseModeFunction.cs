using HelperManager;
using LaborTrackPro.Controls;
using LaborTrackPro.UserControls;
using System.Threading.Tasks;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmChooseModeFunction : Form
  {
    public FrmChooseModeFunction()
    {
      InitializeComponent();
      CustomUI();
      this.Load += FrmChooseMode_Load;
      this.Shown += FrmChooseMode_Shown;
    }

    #region Instance
    private static FrmChooseModeFunction _Instance = null;
    public static FrmChooseModeFunction Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmChooseModeFunction();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ucTitleFrm.FunctionButton(eTypeButton.None);
      ucTitleFrm.Title = "Chọn chức năng";
      ucTitleFrm.Image = Properties.Resources.icon_function;
    }

    private string[] _mode = new string[] { "Cân", "Biên bản giao nhận" };
    private int _padding = 50;

    private void FrmChooseMode_Load(object? sender, EventArgs e)
    {
      AppCore.Ins.OnSendEndOfWeighingCycle += Ins_OnSendEndOfWeighingCycle;
    }

    private void FrmChooseMode_Shown(object? sender, EventArgs e)
    {
      ShowControls();
    }

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

        int ucWidth = 450, ucHeight = 600;
        int totalWidth = _mode.Length * (ucWidth + _padding*2);
        int emptySpace = flowLayoutPanel.ClientSize.Width - totalWidth;

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
            uc.Image = Properties.Resources.IconInPhieuCan;
          }
          else if (mode == _mode[1])
          {
            uc.Image = Properties.Resources.IconInPhieuGiaoNhan;
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
          AppCore.Ins._dataManager.EnumModeFunction = EnumModeFunction.PrintLabel;
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.AreaInternalOrExternal;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.AreaInternalOrExternal);
        }
        else if (e == _mode[1])
        {
          AppCore.Ins._dataManager.EnumModeFunction = EnumModeFunction.PrintDelivery;
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.AreaInternalOrExternal;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.AreaInternalOrExternal);
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

        if (AppCore.Ins._dataManager.EnumModeFunction == EnumModeFunction.PrintLabel)
        {
          foreach (var uc in all_uc)
          {
            uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[0]);
          }
        }
        else if (AppCore.Ins._dataManager.EnumModeFunction == EnumModeFunction.PrintDelivery)
        {
          foreach (var uc in all_uc)
          {
            uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[1]);
          }
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void Ins_OnSendEndOfWeighingCycle()
    {
      try
      {
        if (this.InvokeRequired)
        {
          this.Invoke(new Action(() =>
          {
            Ins_OnSendEndOfWeighingCycle();
          }));
          return;
        }

        var all_uc = flowLayoutPanel.Controls
                        .OfType<UcItemMode>()
                        .ToList();

        foreach (var uc in all_uc)
        {
          uc.Highlight(false);
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

  }
}
