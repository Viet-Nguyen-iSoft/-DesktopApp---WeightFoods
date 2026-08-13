using HelperManager;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.UserControls;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmChooseDelivery : Form
  {
    public FrmChooseDelivery()
    {
      InitializeComponent();
      CustomUI();
    }

    #region Instance
    private static FrmChooseDelivery _Instance = null;
    public static FrmChooseDelivery Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmChooseDelivery();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ucTitleFrm.FunctionButton(eTypeButton.None);
      ucTitleFrm.Title = "Chọn kế hoạch giao nhận";
      ucTitleFrm.Image = Properties.Resources.icon_type;
    }

    public async Task ShowListData()
    {
      var deliveries = await AppCore.Ins.GetDataDeliveryScheduleAsync(
          AppCore.Ins?._dataManager?.ProductionOrder?.Id,
           AppCore.Ins?._dataManager?.EnumExportImport
          );

      LoadDeliverySchedule(deliveries);
    }

    private void LoadDeliverySchedule(List<DeliverySchedule> deliverySchedules)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LoadDeliverySchedule(deliverySchedules);
        }));
        return;
      }

      try
      {
        flowPanel.Controls.Clear();
        if (deliverySchedules.Count <= 0)
        {
          return;
        }

        double crollsize = 0.0;
        if (deliverySchedules.Count > 3)
        {
          crollsize = 20.0;
        }

        double _margin = 10;
        Size sizePanel = new Size(flowPanel.Width, flowPanel.Height);
        int w = (int)((double)sizePanel.Width / 1.0 - (_margin * 2.4) - crollsize);
        int h = (int)((double)sizePanel.Height / 3.0 - (_margin * 2.5));
        sizePanel = new Size(w, h);

        DateTime dt = DateTime.Now;
        foreach (var deliverySchedule in deliverySchedules)
        {
          var uc = new UcOrderProduction(deliverySchedule, deliverySchedule?.TicketCode ?? string.Empty)
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
      AppCore.Ins._dataManager.DeliverySchedule = e as DeliverySchedule;
      AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.ListItemDelivery;
      await FrmPageOperation.Instance.ChangePage(AppModulSupport.ListItemDelivery);
    }



  }
}
