using HelperManager;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.Forms;
using LaborTrackPro.UserControls;
using static HelperManager.EnumData;
using static LaborTrackPro.EnumData;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LaborTrackPro.FrmChild.Operation
{
  public partial class FrmOpListPO : Form
  {
    public FrmOpListPO()
    {
      InitializeComponent();
      CustomUI();
      InitScrollButton();

      FrmMain.Instance.OnSendChangeProductionOrder += Ins_OnSendChangeProductionOrder;
    }

    #region Instance
    private static FrmOpListPO _Instance = null;
    public static FrmOpListPO Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmOpListPO();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ElipseControl elipseControl1 = new ElipseControl();
      elipseControl1.TargetControl = flowPanel;
      elipseControl1.CornerRadius = 20;

      ucTitleFrm.FunctionButton(eTypeButton.None);
      ucTitleFrm.Image = Properties.Resources.icon_PO;
    }

    public void SetTiltePage()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetTiltePage();
        }));
        return;
      }

      if (AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhSanXuat)
      {
        ucTitleFrm.Title = "Lệnh sản xuất";
      }
      else if (AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhThuNghiem)
      {
        if (AppCore.Ins._dataManager.EnumProductionOrderCategory == EnumProductionOrderCategory.MachineTesting)
        {
          ucTitleFrm.Title = "Lệnh thử nghiệm >> Kiểm tra máy";
        }
        else if (AppCore.Ins._dataManager.EnumProductionOrderCategory == EnumProductionOrderCategory.NewProductTesting)
        {
          ucTitleFrm.Title = "Lệnh thử nghiệm >> Kiểm tra sản phẩm mới";
        }
        else if (AppCore.Ins._dataManager.EnumProductionOrderCategory == EnumProductionOrderCategory.SampleProduction)
        {
          ucTitleFrm.Title = "Lệnh thử nghiệm >> Làm mẫu";
        }
      }
      else if (AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhDuPhong)
      {
        ucTitleFrm.Title = "Lệnh dự phòng";
      }
      else if (AppCore.Ins._dataManager.EnumProductionOrderType == EnumProductionOrderType.LenhLayMau)
      {
        ucTitleFrm.Title = "Lệnh lấy mẫu";
      }
    }

    private void Ins_OnSendChangeProductionOrder()
    {
      LoadProductionOrders(AppCore.Ins._dataManager.EnumInternalExternalStatus, AppCore.Ins._dataManager.EnumProductionOrderType, AppCore.Ins._dataManager.EnumProductionOrderCategory);
    }

    public void LoadDataByChangeMode()
    {
      SetTiltePage();
      LoadProductionOrders(AppCore.Ins._dataManager.EnumInternalExternalStatus, AppCore.Ins._dataManager.EnumProductionOrderType, AppCore.Ins._dataManager.EnumProductionOrderCategory);
    }

    private void LoadProductionOrders(EnumInternalExternalStatus enumExportImport, EnumProductionOrderType enumProductionOrderType, EnumProductionOrderCategory enumProductionOrderCategory)
    {
      if (enumProductionOrderType == EnumProductionOrderType.LenhSanXuat)
      {
        var rs = Search(AppCore.Ins._productionOrders, enumProductionOrderType, enumExportImport);
        LoadProductionOrder(rs);
      }
      else if (enumProductionOrderType == EnumProductionOrderType.LenhThuNghiem)
      {
        var rs = Search(AppCore.Ins._productionOrders, enumProductionOrderType, enumProductionOrderCategory, enumExportImport);
        LoadProductionOrder(rs);
      }
      else if (enumProductionOrderType == EnumProductionOrderType.LenhDuPhong)
      {
        var rs = Search(AppCore.Ins._productionOrders, enumProductionOrderType, enumExportImport);
        LoadProductionOrder(rs);
      }
      else if (enumProductionOrderType == EnumProductionOrderType.LenhLayMau)
      {
        var rs = Search(AppCore.Ins._productionOrders, enumProductionOrderType, enumExportImport);
        LoadProductionOrder(rs);
      }
    }

    private void LoadProductionOrder(List<ProductionOrder> productionOrders)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LoadProductionOrder(productionOrders);
        }));
        return;
      }

      try
      {
        flowPanel.Controls.Clear();
        if (productionOrders.Count <= 0)
        {
          return;
        }

        double crollsize = 0.0;
        if (productionOrders.Count > 3)
        {
          crollsize = 20.0;
        }

        double _margin = 10;
        Size sizePanel = new Size(flowPanel.Width, flowPanel.Height);
        int w = (int)((double)sizePanel.Width / 1.0 - (_margin * 2.4) - crollsize);
        int h = (int)((double)sizePanel.Height / 3.0 - (_margin * 2.5));
        sizePanel = new Size(w, h);

        DateTime dt = DateTime.Now;
        foreach (var productionOrder in productionOrders)
        {
          var uc = new UcOrderProduction(productionOrder, productionOrder.Name??"N/A")
          {
            Margin = new Padding((int)_margin),
          };
          uc.OnSendItemClicked += Uc_OnSendItemClicked;
          uc.SizeCus = sizePanel;
          flowPanel.Controls.Add(uc);
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private async void Uc_OnSendItemClicked(object? sender, object e)
    {
      AppCore.Ins._dataManager.ProductionOrder = e as ProductionOrder;
      AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.TypeExportImport;
      await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpChooseExportImport);
    }

    //private List<ProductionOrder> Search(List<ProductionOrder>? productionOrders, 
    //  EnumProductionOrderType enumProductionOrderType,
    //  EnumInternalExternalStatus enumExportImport)
    //{
    //  if (productionOrders?.Count > 0)
    //  {
    //    DateTime dt = DateTime.Now.Date;
    //    if (enumExportImport == EnumInternalExternalStatus.Internal)
    //    {
    //      productionOrders = productionOrders?
    //      .Where(x =>
    //              x.ProductionOrderType == enumProductionOrderType &&
    //              x.ApproveStatus == 2 &&
    //              x.EffectiveFrom.HasValue &&
    //              x.EffectiveTo.HasValue &&
    //              dt >= x.EffectiveFrom.Value.Date &&
    //              dt <= x.EffectiveTo.Value.Date)
    //     .ToList();
    //      return productionOrders?.OrderBy(x => x.Name).ToList() ?? new List<ProductionOrder>();
    //    }
    //    else if (enumExportImport == EnumInternalExternalStatus.External)
    //    {
    //      productionOrders = productionOrders?
    //     .Where(x =>
    //              x.ProductionOrderType == enumProductionOrderType &&
    //              x.ApproveStatus == 2 &&
    //              x.EffectiveFromExternal.HasValue &&
    //              x.EffectiveToExternal.HasValue &&
    //              dt >= x.EffectiveFromExternal.Value.Date &&
    //              dt <= x.EffectiveToExternal.Value.Date)
    //     .ToList();
    //      return productionOrders?.OrderBy(x => x.Name).ToList() ?? new List<ProductionOrder>();
    //    }

    //    return productionOrders;
    //  }
    //  else
    //  {
    //    return new List<ProductionOrder>();
    //  }
    //}

    private List<ProductionOrder> Search(
    List<ProductionOrder>? productionOrders,
    EnumProductionOrderType productionOrderType,
    EnumInternalExternalStatus internalExternalStatus,
    int allowedDeviationDays = 1)
    {
      if (productionOrders is null || productionOrders.Count == 0)
        return new List<ProductionOrder>();

      var today = DateTime.Today;
      var deviationDays = Math.Max(0, allowedDeviationDays);

      return productionOrders
          .Where(x =>
          {
            if (x.ProductionOrderType != productionOrderType ||
              x.ApproveStatus != 2)
            {
              return false;
            }

            DateTime? effectiveFrom = null;
            DateTime? effectiveTo = null;

            switch (internalExternalStatus)
            {
              case EnumInternalExternalStatus.Internal:
                effectiveFrom = x.EffectiveFrom;
                effectiveTo = x.EffectiveTo;
                break;

              case EnumInternalExternalStatus.External:
                effectiveFrom = x.EffectiveFromExternal;
                effectiveTo = x.EffectiveToExternal;
                break;

              default:
                return false;
            }

            if (!effectiveFrom.HasValue || !effectiveTo.HasValue)
              return false;

            // Chỉ lấy phần ngày, bỏ hoàn toàn giờ/phút/giây.
            var fromDate = effectiveFrom.Value.Date.AddDays(-deviationDays);
            var toDate = effectiveTo.Value.Date.AddDays(deviationDays);

            return today >= fromDate && today <= toDate;
          })
          .OrderBy(x => x.Name)
          .ToList();
    }

    private List<ProductionOrder> Search(
    List<ProductionOrder>? productionOrders,
    EnumProductionOrderType productionOrderType,
    EnumProductionOrderCategory productionOrderCategory,
    EnumInternalExternalStatus internalExternalStatus,
    int allowedDeviationDays = 1)
    {
      if (productionOrders is null || productionOrders.Count == 0)
        return new List<ProductionOrder>();

      var today = DateTime.Today;
      var deviationDays = Math.Max(0, allowedDeviationDays);

      return productionOrders
          .Where(x =>
          {
            if (x.ProductionOrderType != productionOrderType ||
              x.ProductionOrderCategory != productionOrderCategory ||
              x.ApproveStatus != 2)
            {
              return false;
            }

            DateTime? effectiveFrom;
            DateTime? effectiveTo;

            switch (internalExternalStatus)
            {
              case EnumInternalExternalStatus.Internal:
                effectiveFrom = x.EffectiveFrom;
                effectiveTo = x.EffectiveTo;
                break;

              case EnumInternalExternalStatus.External:
                effectiveFrom = x.EffectiveFromExternal;
                effectiveTo = x.EffectiveToExternal;
                break;

              default:
                return false;
            }

            if (!effectiveFrom.HasValue || !effectiveTo.HasValue)
              return false;

            // Chỉ lấy phần ngày, bỏ giờ/phút/giây.
            var fromDate = effectiveFrom.Value.Date
              .AddDays(-deviationDays);

            var toDate = effectiveTo.Value.Date
              .AddDays(deviationDays);

            return today >= fromDate && today <= toDate;
          })
          .OrderBy(x => x.Name)
          .ToList();
    }


    #region Scroll
    private System.Windows.Forms.Timer? _scrollTimer;
    private int _scrollDirection = 0; // -1 = Up, 1 = Down
    private void InitScrollButton()
    {
      _scrollTimer = new System.Windows.Forms.Timer();
      _scrollTimer.Interval = 30; // tốc độ cuộn
      _scrollTimer.Tick += ScrollTimer_Tick;

      // UP
      btnUp.MouseDown += BtnUp_MouseDown;
      btnUp.MouseUp += BtnScroll_MouseUp;
      btnUp.MouseLeave += BtnScroll_MouseUp;
      btnUp.Click += btnUp_Click;

      // DOWN
      btnDown.MouseDown += BtnDown_MouseDown;
      btnDown.MouseUp += BtnScroll_MouseUp;
      btnDown.MouseLeave += BtnScroll_MouseUp;
      btnDown.Click += btnDown_Click;
    }

    private void ScrollTimer_Tick(object? sender, EventArgs e)
    {
      int currentY = Math.Abs(flowPanel.AutoScrollPosition.Y);

      int scrollStep = 20;

      int newY = currentY + (_scrollDirection * scrollStep);

      if (newY < 0)
        newY = 0;

      flowPanel.AutoScrollPosition = new Point(0, newY);
    }

    private void BtnUp_MouseDown(object? sender, MouseEventArgs e)
    {
      _scrollDirection = -1;
      _scrollTimer?.Start();
    }

    private void BtnDown_MouseDown(object? sender, MouseEventArgs e)
    {
      _scrollDirection = 1;
      _scrollTimer?.Start();
    }

    private void BtnScroll_MouseUp(object? sender, EventArgs e)
    {
      _scrollTimer?.Stop();
    }

    private void btnUp_Click(object? sender, EventArgs e)
    {
      int currentY = Math.Abs(flowPanel.AutoScrollPosition.Y);

      int newY = Math.Max(0, currentY - flowPanel.Height - 100);

      flowPanel.AutoScrollPosition = new Point(0, newY);
    }

    private void btnDown_Click(object? sender, EventArgs e)
    {
      int currentY = Math.Abs(flowPanel.AutoScrollPosition.Y);
      flowPanel.AutoScrollPosition = new Point(0, currentY + flowPanel.Height - 100);
    }

    #endregion



  }
}
