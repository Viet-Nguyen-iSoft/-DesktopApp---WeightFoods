using HelperManager;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms
{
  public partial class FrmOpModePO : Form
  {
    public FrmOpModePO()
    {
      InitializeComponent();
      CustomUI();
      this.Load += FrmOpModeProductionOrder_Load;
      this.Shown += FrmOpModeProductionOrder_Shown;
    }

    #region Instance
    private static FrmOpModePO _Instance = null;
    public static FrmOpModePO Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmOpModePO();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ucTitleFrm.FunctionButton(eTypeButton.None);
      ucTitleFrm.Title = "Chọn kiểu Lệnh sản xuất";
      ucTitleFrm.Image = Properties.Resources.icon_type;
    }

    private string[] _mode = new string[] { "Lệnh sản xuất", "Lệnh thử nghiệm", "Lệnh dự phòng", "Lệnh lấy mẫu" };
    private int _padding = 20;
    private void FrmOpModeProductionOrder_Load(object? sender, EventArgs e)
    {
      AppCore.Ins.OnSendEndOfWeighingCycle += Ins_OnSendEndOfWeighingCycle;
    }
    
    private void FrmOpModeProductionOrder_Shown(object? sender, EventArgs e)
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

        int ucWidth = 433;
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
            uc.Image = Properties.Resources.icon_order_product;
          }
          else if (mode == _mode[1])
          {
            uc.Image = Properties.Resources.icon_order_product_another;
          }
          else if (mode == _mode[2])
          {
            uc.Image = Properties.Resources.icon_request_other;
          }
          else if (mode == _mode[3])
          {
            uc.Image = Properties.Resources.icon_order_product_another;
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
          //Check phòng ban
          var deparment = AppCore.Ins._dataManager.DataLogPrintLabel.Employee?.Departments?.FirstOrDefault();
          bool valid =  deparment?.EnumGroup == EnumGroup.Warehouse ||
                        deparment?.EnumGroup == EnumGroup.SoChe ||
                        deparment?.EnumGroup == EnumGroup.CheBien ||
                        deparment?.EnumGroup == EnumGroup.QC ||
                        deparment?.EnumGroup == EnumGroup.Packing;

          if (!valid && AppCore.Ins._isAdmin == false)
          {
            new FrmInformation().ShowMessage("Phòng ban thẻ này không được phép cân Lệnh sản xuất !", eImage.Warning);
            return;
          }

          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ListPO;
          AppCore.Ins._dataManager.EnumProductionOrderType = EnumProductionOrderType.LenhSanXuat;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpShowListPO);
        }
        else if (e == _mode[1])
        {
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.TypeForPoOther;
          AppCore.Ins._dataManager.EnumProductionOrderType = EnumProductionOrderType.LenhThuNghiem;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpTypeForPoOther);
        }
        else if (e == _mode[2])
        {
          AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ListPO;
          AppCore.Ins._dataManager.EnumProductionOrderType = EnumProductionOrderType.LenhDuPhong;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpShowListPO);
        }
        else if (e == _mode[3])
        {
          if (AppCore.Ins._dataManager.EnumInternalExternalStatus == EnumInternalExternalStatus.Internal)
          {
            AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ListPO;
            AppCore.Ins._dataManager.EnumProductionOrderType = EnumProductionOrderType.LenhLayMau;
            await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpShowListPO);
          }
          else
          {
            new FrmInformation().ShowMessage("Lệnh lấy mẫu không cho cân Ngoại vi !", eImage.Warning);
            return;
          }   
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

        if (AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhSanXuat)
        {
          all_uc.ForEach(uc => uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[0]));
        }
        else if (AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhThuNghiem)
        {
          all_uc.ForEach(uc => uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[1]));
        }
        else if (AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhDuPhong)
        {
          all_uc.ForEach(uc => uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[2]));
        }
        else if (AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhLayMau)
        {
          all_uc.ForEach(uc => uc.Highlight(uc.Tag != null && uc.Tag.ToString() == _mode[3]));
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
