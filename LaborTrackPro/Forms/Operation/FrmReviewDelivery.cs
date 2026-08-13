using HelperManager;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.Printer;
using LaborTrackPro.UserControls;
using Sprache;
using System.Data;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HelperManager.EnumData;
using static LaborTrackPro.EnumData;
using static LaborTrackPro.Helper.DTO;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmReviewDelivery : Form
  {
    private System.Timers.Timer _timerSendStatusConnectPrint = new System.Timers.Timer();
    private StatusPrintA4 _statusPrintA4 { get; set; }
    private StatusPrintA4 _statusPrintA4Previous { get; set; }
    private string _pathFilePdf { get; set; }
    public FrmReviewDelivery()
    {
      InitializeComponent();
      CustomUI();
      ucTitleFrmPrintA41.OnSendPrinterUCClick += UcTitleFrm_OnSendPrinterUCClick;
      ucTitleFrmPrintA41.OnSendPermitOverWeightClick += UcTitleFrmPrintA41_OnSendPermitOverWeightClick;
      AppCore.Ins.OnSendEndOfWeighingDeliveryCycle += Ins_OnSendEndOfWeighingDeliveryCycle;
    }

    private void Ins_OnSendEndOfWeighingDeliveryCycle()
    {
      _employeePermitWeightOver = null;
    }

    #region Instance
    private static FrmReviewDelivery _Instance = null;
    public static FrmReviewDelivery Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmReviewDelivery();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ElipseControl elipseControl2 = new ElipseControl();
      elipseControl2.TargetControl = tableLayoutPanel6;
      elipseControl2.CornerRadius = 20;
    }
    private void FrmReviewDelivery_Load(object sender, EventArgs e)
    {
      _timerSendStatusConnectPrint.Interval = 1000;
      _timerSendStatusConnectPrint.Elapsed += _timerSendStatusConnectPrint_Elapsed;
      _timerSendStatusConnectPrint.Start();
    }

    private void _timerSendStatusConnectPrint_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      try
      {
        _timerSendStatusConnectPrint.Stop();

        List<string> printers = PrinterSettings.InstalledPrinters
                               .Cast<string>()
                               .ToList();
        bool find = printers.Any(x => x == AppCore.Ins._appConfig.NamePrinterA4);
        if (find)
        {
          var rs = PrinterUSBHelper.GetPrinterStatus(AppCore.Ins._appConfig.NamePrinterA4);
          _statusPrintA4 = rs.StatusPrintA4;
        }
        else
        {
          _statusPrintA4 = StatusPrintA4.NotFound;
        }

        if (_statusPrintA4Previous != _statusPrintA4)
        {
          _statusPrintA4Previous = _statusPrintA4;
          ShowStatusPrintA4(_statusPrintA4);
        }
      }
      catch (Exception)
      {
        //TODO
      }
      finally
      {
        _timerSendStatusConnectPrint.Start();
      }
    }



    private List<string> _htmlFiles = new List<string>();
    private InformationDelivery _informationFillDelivery = new InformationDelivery();
    private Employee _employeePermitWeightOver { get; set; }
    private bool _rsNotAlarm { get; set; } = false;
    private int _cntSumary { get; set; } = 1;
    public async Task ShowData() //ShowDeliveryA4
    {
      try
      {
        //int n = 30;
        //MaterialDeliveryDTO data = AppCore.Ins._dataManager?.DataLogDelivery?.MaterialDelivaryDTOs.FirstOrDefault();
        //AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = new List<MaterialDeliveryDTO>();
        //AppCore.Ins._dataManager?.DataLogDelivery?.MaterialDelivaryDTOs.Add(data);
        //for (int i = 1; i < n; i++)
        //{
        //  AppCore.Ins._dataManager?.DataLogDelivery?.MaterialDelivaryDTOs.Add(data);
        //}


        //Lấy danh sách phòng ban cần in
        var department = AppCore.Ins._dataManager.DataLogDelivery.SettingLabels?
                        .Where(x => !string.IsNullOrEmpty(x.Name))
                        .SelectMany(x => Enumerable.Repeat(x.Name!, x.NumberCopy ?? 1))
                        .ToArray();

        _htmlFiles = new List<string>();
        if (department?.Length > 0)
        {
          _informationFillDelivery = MapperDTO.ConvertManagerDataToInformationDelivery(AppCore.Ins._dataManager, department);
          _htmlFiles = department
                      .Select(item => Path.Combine(AppCore.Ins._folderOutput, $"{item}.html"))
                      .ToList();

          //Nội vi
          if (_informationFillDelivery.EnumInternalExternal == EnumInternalExternalStatus.Internal)
          {
            if ((_informationFillDelivery.DeliveryEmployee != null) && (_informationFillDelivery.ReceivingEmployee != null))
            {
              EnumTyCheckAlarm enumTyCheckAlarm = EnumTyCheckAlarm.None;
              if (_informationFillDelivery?.ProductionOrder?.EnumProcessing == EnumProcessing.Processing)
              {
                if (_informationFillDelivery.EnumExportImport == EnumExportImport.Export)
                {
                  if (_informationFillDelivery?.DeliveryEmployee?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                  {
                    enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Export;
                  }
                  else
                  {
                    enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Export_Internal;
                  }
                }
                else if (_informationFillDelivery.EnumExportImport == EnumExportImport.Import)
                {
                  if (_informationFillDelivery?.ReceivingEmployee?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                  {
                    enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Import;
                  }
                  else
                  {
                    enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Import_Internal;
                  }
                }
              }
              else if (_informationFillDelivery?.ProductionOrder?.EnumProcessing == EnumProcessing.Unprocessed)
              {
                if (_informationFillDelivery.EnumExportImport == EnumExportImport.Export)
                {
                  if (_informationFillDelivery?.DeliveryEmployee?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                  {
                    enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Export;
                  }
                  else
                  {
                    enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Export_Internal;
                  }
                }
                else if (_informationFillDelivery.EnumExportImport == EnumExportImport.Import)
                {
                  if (_informationFillDelivery?.ReceivingEmployee?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                  {
                    enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Import;
                  }
                  else
                  {
                    enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Import_Internal;
                  }
                }
              }

              
              //var dataFirst = _informationFillDelivery?.MaterialDelivaryDTOs?.FirstOrDefault();
              //bool mrDefect = dataFirst?.MaterialType == "Phế phẩm";
              //MaxValueCheckAlarm maxValue = await AppCore.Ins.GetMaxValueInternal(_informationFillDelivery?.ProductionOrder,
              //_informationFillDelivery?.Machine,
              //_informationFillDelivery?.Material,
              //_informationFillDelivery?.DeliveryEmployee?.Departments?.FirstOrDefault()?.IdSrc,
              //_informationFillDelivery?.ReceivingEmployee?.Departments?.FirstOrDefault()?.IdSrc,
              //enumTyCheckAlarm, mrDefect);

              //maxValue.CheckAlarm = (_employeePermitWeightOver == null) && maxValue.CheckAlarm;

              _informationFillDelivery.IsCheckAlarm = (_employeePermitWeightOver == null);
              _informationFillDelivery.EnumTyCheckAlarm = enumTyCheckAlarm;
            }

            await CreateFileHtmlV2(_informationFillDelivery);
            await ShowUI(_htmlFiles);
          }
          else if (_informationFillDelivery.EnumInternalExternal == EnumInternalExternalStatus.External)
          {
            //MaxValueCheckAlarm maxValue = await GetMaxValueExternal(_informationFillDelivery?.ProductionOrder,
            //  _informationFillDelivery?.Machine,
            //  _informationFillDelivery?.Material,
            //  _informationFillDelivery?.EnumExportImport
            //  );
            //_informationFillDelivery.MaxValueCheckAlarm = maxValue;

            _informationFillDelivery.IsCheckAlarm = (_employeePermitWeightOver == null);
            await CreateFileHtmlV2(_informationFillDelivery);
            await ShowUI(_htmlFiles);
          }
        }

        //.Check đủ data
        await CheckValid();

        VisibleDepartmentDelivery(_informationFillDelivery?.EnumInternalExternal == EnumInternalExternalStatus.Internal);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private async Task CheckValid()
    {
      if (_informationFillDelivery.EnumInternalExternal == EnumInternalExternalStatus.Internal)
      {
        var valid = AppCore.Ins._dataManager.DataLogDelivery.EmployeeDelivery != null &&
        AppCore.Ins._dataManager.DataLogDelivery.EmployeeReceiving != null &&
        AppCore.Ins._dataManager.DataLogDelivery.EmployeeQC != null;
        valid = valid && _rsNotAlarm;

        ucTitleFrmPrintA41.SetEnabelBtnPermitOverWeight(!_rsNotAlarm);
        ucTitleFrmPrintA41.SetEnabelBtn(false);
        if (valid)
        {
          await CreateFile();
        }
      }
      else if (_informationFillDelivery.EnumInternalExternal == EnumInternalExternalStatus.External)
      {
        var valid = AppCore.Ins._dataManager.DataLogDelivery.EmployeeReceiving != null &&
        AppCore.Ins._dataManager.DataLogDelivery.EmployeeQC != null;
        valid = valid && _rsNotAlarm;

        ucTitleFrmPrintA41.SetEnabelBtnPermitOverWeight(!_rsNotAlarm);
        ucTitleFrmPrintA41.SetEnabelBtn(false);
        if (valid)
        {
          await CreateFile();
        }
      }
    }

    private void EnablePrint()
    {
      ucTitleFrmPrintA41.SetEnabelBtn(true);
    }

    private async Task CreateFileHtmlV2(InformationDelivery information)
    {
      try
      {
        string pathFileTemplate = information.EnumInternalExternal == EnumInternalExternalStatus.Internal ?
                                       Application.StartupPath + "Template\\NoiVi.html" :
                                       Application.StartupPath + "Template\\NgoaiVi.html";

        string pathFileTemplateTable = Application.StartupPath + "Template\\Table.html";
        string pathFileTemplateTableSumary = Application.StartupPath + "Template\\TableSumary.html";

        //Tạo file
        var rs = await PrinterHelper.GenerateHtmlFilesFromTemplate(pathFileTemplate,
                                                    pathFileTemplateTable,
                                                    pathFileTemplateTableSumary,
                                                    AppCore.Ins._folderOutput,
                                                    information);
        _rsNotAlarm = rs.Check;
        _cntSumary = rs.CntSumary;
      }
      catch (Exception)
      {
        throw;
      }
    }

    private void UcTitleFrm_OnSendPrinterUCClick()
    {
      try
      {
        VisibleButton(false);
        if (_htmlFiles.Count() <= 0)
        {
          new FrmInformation().ShowMessage($"Không có thông tin phiếu in", eImage.Information);
          return;
        }

        if (_statusPrintA4 == StatusPrintA4.Idle)
        {
          PopupStatusPrint popupStatusPrint = new PopupStatusPrint(AppCore.Ins._appConfig.NamePrinterA4, _pathFilePdf);
          popupStatusPrint.OnSendStatusPrint += PopupStatusPrint_OnSendStatusPrint;
          popupStatusPrint.ShowDialog();
        }
        else
        {
          new FrmInformation().ShowMessage($"Không kết nối được máy in", eImage.Information);
          return;
        }
      }
      catch (Exception ex)
      {
        ShowFrmInformation($"Lỗi: {ex.ToString()}", eImage.Warning);
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
      finally
      {
        VisibleButton(true);
      }
    }

    private async void PopupStatusPrint_OnSendStatusPrint(object? sender, bool e)
    {
      try
      {
        DateTime dtPrintA4 = _dt;
        var listUpdate = AppCore.Ins._dataManager.DataLogDelivery.DatalogWeights;

        DatalogDelivery dataLogDelivery = new DatalogDelivery();
        dataLogDelivery.AreaInternalOrExternal = (int)AppCore.Ins._dataManager.EnumInternalExternalStatus;

        if (AppCore.Ins._dataManager.ProductionOrder != null)
        {
          dataLogDelivery.ProductionOrderId = AppCore.Ins._dataManager.ProductionOrder.Id;
        }

        if (AppCore.Ins._dataManager.DataLogDelivery.EmployeeDelivery != null)
        {
          dataLogDelivery.EmployeeDeliverId = AppCore.Ins._dataManager.DataLogDelivery.EmployeeDelivery.Id;
        }
        else
        {
          if (AppCore.Ins._dataManager?.EnumInternalExternalStatus == EnumInternalExternalStatus.External)
          {
            if (AppCore.Ins._dataManager?.DataLogDelivery.EmployeeReceiving != null)
            {
              dataLogDelivery.EmployeeDeliverId = AppCore.Ins._dataManager.DataLogDelivery.EmployeeReceiving.Id;
            }
          }
        }

        if (AppCore.Ins._dataManager?.DataLogDelivery.EmployeeReceiving != null)
        {
          dataLogDelivery.EmployeeReceiveId = AppCore.Ins._dataManager.DataLogDelivery.EmployeeReceiving.Id;
        }
        if (AppCore.Ins._dataManager?.DataLogDelivery.EmployeeQC != null)
        {
          dataLogDelivery.EmployeeQCId = AppCore.Ins._dataManager.DataLogDelivery.EmployeeQC.Id;
        }
        if (AppCore.Ins._dataManager?.DeliverySchedule != null)
        {
          dataLogDelivery.DeliveryScheduleId = AppCore.Ins._dataManager?.DeliverySchedule.Id;
        }

        dataLogDelivery.MachineId = AppCore.Ins._dataManager?.Machine?.Id;
        dataLogDelivery.DeletedFlag = false;
        dataLogDelivery.SyncFlag = false;
        dataLogDelivery.JsonInforFill = System.Text.Json.JsonSerializer.Serialize(_informationFillDelivery);
        dataLogDelivery.CreatedAt = dtPrintA4;
        var rs = await AppCore.Ins.AddDelivery(dataLogDelivery);
        if (listUpdate?.Count > 0)
        {
          if (AppCore.Ins._dataManager?.EnumInternalExternalStatus == EnumInternalExternalStatus.Internal)
          {
            Employee? emloyeeDelivery = AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery;
            Employee? emloyeeReceiving = AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceiving;

            foreach (var item in listUpdate)
            {
              EnumCheckData enumCheckData = EnumCheckData.UnCheck;
              if (item.eExportImport == EnumExportImport.Export)
              {
                if (emloyeeDelivery?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse ||
                  emloyeeReceiving?.Departments.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                {
                  enumCheckData = EnumCheckData.Check;
                }
              }
              else if (item.eExportImport == EnumExportImport.Import)
              {
                if (emloyeeReceiving?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                {
                  enumCheckData = EnumCheckData.Check;
                }
              }

              item.EnumCheckData = enumCheckData;
              item.UpdatedAt = dtPrintA4;

              if (_employeePermitWeightOver != null)
              {
                item.UserAllowWeightOverId = _employeePermitWeightOver.Id;
              }
              if (AppCore.Ins._dataManager?.DeliverySchedule != null)
              {
                item.DeliveryScheduleId = AppCore.Ins._dataManager?.DeliverySchedule.Id;
              }

              await AppCore.Ins.UpdateRecordAsync(rs.Id, item);
            }
          }
          else if (AppCore.Ins._dataManager?.EnumInternalExternalStatus == EnumInternalExternalStatus.External)
          {
            foreach (var item in listUpdate)
            {
              item.EnumCheckData = EnumCheckData.Check;
              item.UpdatedAt = dtPrintA4;
              if (_employeePermitWeightOver != null)
              {
                item.UserAllowWeightOverId = _employeePermitWeightOver.Id;
              }
              
              await AppCore.Ins.UpdateRecordAsync(rs.Id, item);
            }
          }
        }

        ShowFrmInformation("Lưu dữ liệu thành công !", eImage.Information);
        FrmLoadingPrinting_OnSendPrintSuccess();

        _employeePermitWeightOver = null;
      }
      catch (Exception ex)
      {
        ShowFrmInformation($"Lỗi: {ex.ToString()} !", eImage.Warning);
      }
    }

    private void FrmLoadingPrinting_OnSendPrintSuccess()
    {
      AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.Waiting;
      FrmMain.Instance.ChangePage(AppModulSupport.Waiting);
      AppCore.Ins.EndOfWeighingDeliveryCycle();
    }

    private void ShowFrmInformation(string message, eImage eImage)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowFrmInformation(message, eImage);
        }));
        return;
      }

      new FrmInformation().ShowMessage(message, eImage);
    }

    private void VisibleButton(bool visible)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          VisibleButton(visible);
        }));
        return;
      }

      ucTitleFrmPrintA41.VisibleButton(visible);
    }

    private void ShowStatusPrintA4(StatusPrintA4 status)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowStatusPrintA4(status);
        }));
        return;
      }

      ucTitleFrmPrintA41.SetStatus(status);
    }

    private void btnReceiving_Click(object sender, EventArgs e)
    {
      PopupScanRfid popupScanRfid = new PopupScanRfid(eScanRfid.ScanReceiving);
      popupScanRfid.Size = new Size(1900, 900);
      popupScanRfid.StartPosition = FormStartPosition.Manual;
      var screen = Screen.PrimaryScreen.WorkingArea;
      int x = (screen.Width - popupScanRfid.Width) / 2;
      int y = 130;
      popupScanRfid.Location = new Point(x, y);
      popupScanRfid.OnSendSearchUCClick += PopupScanRfid_OnSendSearchUCClick;
      popupScanRfid.ShowDialog();
    }

    private async Task ShowUI(List<string> htmls)
    {
      try
      {
        if (htmls.Count > 0)
        {
          int count = (AppCore.Ins._dataManager?.DataLogDelivery?.MaterialDelivaryDTOs?.Count ?? 0) + (_cntSumary - 1);
          int height = 500 + count * 34;
          await AppCore.Ins.ShowHtmlFilesInIframesSafely(webView21, htmls, height);
        }
        else
        {
          new FrmInformation().ShowMessage("Không có thông tin phòng ban in phiếu giao nhận. Vui lòng cài đặt phần này !", eImage.Warning);
          return;
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    private void btnQC_Click(object sender, EventArgs e)
    {
      PopupScanRfid popupScanRfid = new PopupScanRfid(eScanRfid.ScanQC);
      popupScanRfid.Size = new Size(1900, 900);
      popupScanRfid.StartPosition = FormStartPosition.Manual;
      var screen = Screen.PrimaryScreen.WorkingArea;
      int x = (screen.Width - popupScanRfid.Width) / 2;
      int y = 110;
      popupScanRfid.Location = new Point(x, y);
      popupScanRfid.OnSendSearchUCClick += PopupScanRfid_OnSendSearchUCClick;
      popupScanRfid.ShowDialog();
    }

    private async void PopupScanRfid_OnSendSearchUCClick(eScanRfid eScanRfid, Employee employee)
    {
      if (eScanRfid == eScanRfid.ScanReceiving)
      {
        AppCore.Ins._dataManager.DataLogDelivery.EmployeeReceiving = employee;
      }
      else if (eScanRfid == eScanRfid.ScanQC)
      {
        AppCore.Ins._dataManager.DataLogDelivery.EmployeeQC = employee;
      }

      await ShowData();
    }


    private void UcTitleFrmPrintA41_OnSendPermitOverWeightClick()
    {
      PopupScanRfid popupScanRfid = new PopupScanRfid(eScanRfid.PermitWeightOver);
      popupScanRfid.Size = new Size(1900, 900);
      popupScanRfid.StartPosition = FormStartPosition.Manual;
      var screen = Screen.PrimaryScreen.WorkingArea;
      int x = (screen.Width - popupScanRfid.Width) / 2;
      int y = 110;
      popupScanRfid.Location = new Point(x, y);
      popupScanRfid.OnSendSearchUCClick += Popup_OnSendSearchUCClick;
      popupScanRfid.ShowDialog();
    }


    private async void Popup_OnSendSearchUCClick(eScanRfid eScanRfid, Employee employee)
    {
      _employeePermitWeightOver = employee;
      if (employee != null)
      {
        //_informationFillDelivery.MaxValueCheckAlarm.CheckAlarm = (_employeePermitWeightOver == null);
        _informationFillDelivery.IsCheckAlarm = (_employeePermitWeightOver == null);
        await CreateFileHtmlV2(_informationFillDelivery);
        await ShowUI(_htmlFiles);
        await CheckValid();
      }
    }

   

    private DateTime _dt { get; set; }
    private async Task<bool> CreateFile()
    {
      try
      {
        _dt = DateTime.Now;
        foreach (var item in _htmlFiles)
        {
          string html = item;
          string pdf = item.Replace(".html", ".pdf");
          await PdfHelper.HtmlToPdfAsync(html, pdf);
        }

        List<string> pathsPdf = _htmlFiles
            .Select(path => Path.ChangeExtension(path, ".pdf"))
            .ToList();

        string fileName = $"Sumary{_dt.ToString("yyyyMMddHHmmss")}";
        _pathFilePdf = Application.StartupPath + $"Template\\OutputFiles\\{fileName}.pdf";
        PdfPrinter.MergePdf(pathsPdf, _pathFilePdf);

        EnablePrint();
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    private void VisibleDepartmentDelivery(bool visible)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          VisibleDepartmentDelivery(visible);
        }));
        return;
      }


      btnReceiving.Visible = visible;
    }

  }

}
