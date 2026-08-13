using HelperManager;
using LaborTrackPro.Controls;
using LaborTrackPro.UserControls;
using System.Threading.Tasks;
using static HelperManager.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmInternalOrExternal : Form
  {
    public FrmInternalOrExternal()
    {
      InitializeComponent();
      CustomUI();
      this.Shown += FrmChooseMode_Shown;
      AppCore.Ins.OnSendEndOfWeighingDeliveryCycle += Ins_OnSendEndOfWeighingDeliveryCycle;
    }

    #region Instance
    private static FrmInternalOrExternal _Instance = null;
    public static FrmInternalOrExternal Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmInternalOrExternal();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ucTitleFrm.FunctionButton(eTypeButton.None);
      ucTitleFrm.Title = "Hình thức giao nhận";
      ucTitleFrm.Image = Properties.Resources.icon_type;
    }

    private void FrmChooseMode_Shown(object? sender, EventArgs e)
    {
      ShowControls();
    }


    private string[] _mode = new string[] { "Nội vi", "Ngoại vi" };
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

        int ucWidth = 450, ucHeight = 600;
        int totalWidth = _mode.Length * (ucWidth + _padding * 2);
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
            uc.Image = Properties.Resources.iconInternal;
          }
          else if (mode == _mode[1])
          {
            uc.Image = Properties.Resources.iconExternal;
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
          AppCore.Ins._dataManager.EnumInternalExternalStatus = EnumInternalExternalStatus.Internal;
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ModePO;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpTypePO);
        }
        else if (e == _mode[1])
        {
          //Check phòng ban
          var deparment = AppCore.Ins._dataManager.DataLogPrintLabel.Employee?.Departments?.FirstOrDefault();
          bool valid = deparment?.EnumGroup == EnumGroup.Warehouse;

          if (!valid && AppCore.Ins._isAdmin == false)
          {
            new FrmInformation().ShowMessage("Cân ngoại vi chỉ cho phép bộ phận Kho thực hiện !", eImage.Warning);
            return;
          }


          AppCore.Ins._dataManager.EnumInternalExternalStatus = EnumInternalExternalStatus.External;
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ModePO;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpTypePO);
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void Ins_OnSendEndOfWeighingDeliveryCycle()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          Ins_OnSendEndOfWeighingDeliveryCycle();
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

        if (AppCore.Ins._dataManager.EnumInternalExternalStatus == EnumInternalExternalStatus.Internal)
        {
          foreach (var uc in all_uc)
          {
            uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[0]);
          }
        }
        else if (AppCore.Ins._dataManager.EnumInternalExternalStatus == EnumInternalExternalStatus.External)
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

  }
}
