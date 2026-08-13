using HelperManager;
using LaborTrackPro.Controls;
using LaborTrackPro.UserControls;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmChooseExportImport : Form
  {
    public FrmChooseExportImport()
    {
      InitializeComponent();
      CustomUI();
      this.Load += FrmChooseMode_Load;
      this.Shown += FrmChooseMode_Shown;
    }

    #region Instance
    private static FrmChooseExportImport _Instance = null;
    public static FrmChooseExportImport Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmChooseExportImport();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ucTitleFrm.FunctionButton(eTypeButton.None);
      ucTitleFrm.Title = "Chọn Nhận hàng/Trả hàng";
      ucTitleFrm.Image = Properties.Resources.icon_function;
    }

    private void FrmChooseMode_Load(object? sender, EventArgs e)
    {
      AppCore.Ins.OnSendEndOfWeighingCycle += Ins_OnSendEndOfWeighingCycle;
      AppCore.Ins.OnSendEndOfWeighingDeliveryCycle += Ins_OnSendEndOfWeighingCycle;
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

        all_uc.ForEach(x => x.Highlight(false));
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    public void CheckChangeTitle()
    {
      if (AppCore.Ins._dataManager.EnumInternalExternalStatus == EnumInternalExternalStatus.Internal)
      {
        UpdateModeTitles("Nhận hàng", "Trả hàng");
      }
      else if (AppCore.Ins._dataManager.EnumInternalExternalStatus == EnumInternalExternalStatus.External)
      {
        UpdateModeTitles("Xuất hàng", "Nhập hàng");
      }
      else
      {
        UpdateModeTitles("N/A", "N/A");
      }
    }

    private void FrmChooseMode_Shown(object? sender, EventArgs e)
    {
      ShowControls();
      CheckChangeTitle();
    }

    private string[] _mode = new string[] { "Export", "Import" };
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
            uc.Image = Properties.Resources.icon_giao_hang;
          }
          else if (mode == _mode[1])
          {
            uc.Image = Properties.Resources.icon_tra_hang;
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

    private void UpdateModeTitles(string exportTitle, string importTitle)
    {
      if (InvokeRequired)
      {
        Invoke(() => UpdateModeTitles(exportTitle, importTitle));
        return;
      }

      foreach (UcItemMode uc in flowLayoutPanel.Controls.OfType<UcItemMode>())
      {
        switch (uc.Tag?.ToString())
        {
          case "Export":
            uc.Title = exportTitle;
            break;

          case "Import":
            uc.Title = importTitle;
            break;
        }
      }
    }

    private async void Uc_OnSendItemClicked(object? sender, string e)
    {
      try
      {
        if (e == _mode[0])
        {
          AppCore.Ins._dataManager.EnumExportImport = EnumExportImport.Export;
        }
        else if (e == _mode[1])
        {
          AppCore.Ins._dataManager.EnumExportImport = EnumExportImport.Import;
        }

        if (AppCore.Ins._dataManager.EnumModeFunction == EnumModeFunction.PrintLabel)
        {
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.TypeMRInPo;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpTypeMR);
        }
        else if (AppCore.Ins._dataManager.EnumModeFunction == EnumModeFunction.PrintDelivery)
        {
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.ScanReceiving);
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

        if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Export)
        {
          all_uc.ForEach(uc => uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[0]));
        }
        else if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Import)
        {
          all_uc.ForEach(uc => uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[1]));
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

  }
}
