using HelperManager;
using iSoft.Database.Models;
using LaborTrackPro.Communication;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.Forms.Operation;
using TestConnectPrinter;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.FrmChild.Operation
{
  public partial class FrmOperationPrint : Form
  {
    public FrmOperationPrint()
    {
      InitializeComponent();
      CustomUI();
      this.Shown += FrmOperationPrint_Shown;
    }

    #region Instance
    private static FrmOperationPrint _Instance = null;
    public static FrmOperationPrint Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmOperationPrint();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.CornerRadius = 10;
      elipseControl02.TargetControl = tableLayoutPanel4;

      ElipseControl elipseControl03 = new ElipseControl();
      elipseControl03.CornerRadius = 10;
      elipseControl03.TargetControl = tableLayoutPanel7;

      ElipseControl elipseControl05 = new ElipseControl();
      elipseControl05.CornerRadius = 10;
      elipseControl05.TargetControl = labelPrint;
    }
    private void FrmOperationPrint_Load(object sender, EventArgs e)
    {
      AppCore.Ins.OnSendDataWeight += Ins_OnSendDataWeight;
      AppCore.Ins.OnSendEndOfWeighingCycle += Ins_OnSendEndOfWeighingCycle;
    }

    private void Ins_OnSendEndOfWeighingCycle()
    {
      StatusModeTare(EnumTypeTare.None);
    }

    private void FrmOperationPrint_Shown(object? sender, EventArgs e)
    {
      StatusModeTare(EnumTypeTare.None);
    }

    public void ShowData()
    {
      try
      {
        var inforDataMR = AppCore.Ins.ProcessingDataForDirectItem(AppCore.Ins._dataManager?.DataLogPrintLabel);

        string titleLabel = string.Empty;
        if (AppCore.Ins._dataManager?.EnumInternalExternalStatus == EnumInternalExternalStatus.Internal)
        {
          titleLabel = AppCore.Ins._dataManager?.EnumExportImport == EnumExportImport.Export ? "THÔNG TIN NHẬN HÀNG" : "THÔNG TIN TRẢ HÀNG";
        }
        else if (AppCore.Ins._dataManager?.EnumInternalExternalStatus == EnumInternalExternalStatus.External)
        {
          titleLabel = AppCore.Ins._dataManager?.EnumExportImport == EnumExportImport.Export ? "THÔNG TIN XUẤT HÀNG" : "THÔNG TIN NHẬP HÀNG";
        }
        string titleLabelInternalExternal = AppCore.Ins._dataManager?.EnumInternalExternalStatus == EnumInternalExternalStatus.Internal ? "(Nội vi)" : "(Ngoại vi)";
        InforPrinter inforPrinter = new InforPrinter();
        inforPrinter.TitleLabel = titleLabel;
        inforPrinter.InternalExternal = titleLabelInternalExternal;
        inforPrinter.ProductionOrder = AppCore.Ins._dataManager?.ProductionOrder?.Name;
        inforPrinter.NameMR = inforDataMR.Name;
        inforPrinter.CodeMR = inforDataMR.Code;
        inforPrinter.Datetime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        inforPrinter.Operator = AppCore.Ins._dataManager?.DataLogPrintLabel?.Employee?.FullName;
        inforPrinter.Department = AppCore.Ins._dataManager?.DataLogPrintLabel?.Employee?.Departments?.FirstOrDefault()?.Name;

        ShowInforLabel(inforPrinter);
        StatusModeTare(EnumTypeTare.None);

        //await CheckGetMaxValue();
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void ShowInforLabel(InforPrinter inforPrinter)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowInforLabel(inforPrinter);
        }));
        return;
      }

      this.lbTitleLabel.Text = inforPrinter.TitleLabel;
      this.lbPO.Text = inforPrinter.ProductionOrder;
      this.lbPathMaterial.Text = inforPrinter.NameMR;
      this.lbCodeMaterial.Text = inforPrinter.CodeMR;
      this.lbDate.Text = inforPrinter.Datetime;
      this.lbOp.Text = inforPrinter.Operator;
      this.lbDepartment.Text = inforPrinter.Department;
      this.lbInternalExternal.Text = inforPrinter.InternalExternal;
    }


    private double _tareValue = 0.0;
    private double _netValue = 0.0;
    private void Ins_OnSendDataWeight(MessageDataOutputWeight e)
    {
      try
      {
        if (AppCore.Ins._dataManager.EnumStepOperation != EnumStepOperation.Print) return;

        if (AppCore.Ins._dataManager.DataLogPrintLabel.TypeTare == EnumTypeTare.NoneTare)
        {
          _tareValue = 0;
          _netValue = e.Net;
        }
        else if (AppCore.Ins._dataManager.DataLogPrintLabel.TypeTare == EnumTypeTare.Tare)
        {
          _tareValue = AppCore.Ins._dataManager?.DataLogPrintLabel?.MaterialForTare?.ValueTare ?? 0.0;
          _netValue = e.Net - _tareValue;
        }
        else
        {
          _tareValue = 0;
          _netValue = 0;
        }

        _tareValue = Math.Round(_tareValue, 3);
        _netValue = Math.Round(_netValue, 3);

        if (AppCore.Ins._dataManager != null)
        {
          AppCore.Ins._dataManager.DataLogPrintLabel.Net = _netValue;
          AppCore.Ins._dataManager.DataLogPrintLabel.Tare = _tareValue;
        }

        SetInforWeight(e, _netValue, _tareValue);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void SetInforWeight(MessageDataOutputWeight outputWeight, double net, double tare)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetInforWeight(outputWeight, net, tare);
        }));
        return;
      }
      try
      {
        this.lbNameWeight.Text = $"{outputWeight.NameDevice}";
        this.lbGrossWeight.Text = $"{Math.Round(net + tare, 3).ToString("F3")}";
        this.lbNetWeight.Text = $"{Math.Round(net, 3).ToString("F3")}";

        switch (outputWeight.ActiveWeighingStatus)
        {
          case ActiveWeighingStatus.Stable:
            this.lbStatus.Text = "Giá trị ổn định";
            this.lbStatus.ForeColor = Color.FromArgb(64, 175, 101);
            break;
          case ActiveWeighingStatus.Motion:
            this.lbStatus.Text = "Giá trị chưa ổn định";
            this.lbStatus.ForeColor = Color.Yellow;
            break;
          case ActiveWeighingStatus.Default:
            this.lbStatus.Text = "Mặc định";
            this.lbStatus.ForeColor = Color.Gray;
            break;
          case ActiveWeighingStatus.Distable:
            break;
          case ActiveWeighingStatus.Overload:
            this.lbStatus.Text = "Overload";
            this.lbStatus.ForeColor = Color.Red;
            break;
          case ActiveWeighingStatus.Underload:
            this.lbStatus.Text = "Underload";
            this.lbStatus.ForeColor = Color.Red;
            break;
          case ActiveWeighingStatus.CommandUnderstoodButNotExecutableAtPresent:
            break;
          default:
            break;
        }

        this.lbNet.Text = $"{net.ToString("F3")} Kg";
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }


    private DatalogWeight _record { get; set; }
    private async void btnCofirmPrint_Click(object sender, EventArgs e)
    {
      try
      {
        LockBtn(true);
        //if (AppCore.Ins._isPrinterLabel == true)
        //{
        //  //Check kết nối máy in trước
        //  EnumStatusConnect status = ZebraPrinterTcpHelper.GetStatusPrint(AppCore.Ins._ipPrintLabel);
        //  if (status == EnumStatusConnect.Disconnect)
        //  {
        //    new FrmInformation().ShowMessage("Không kết nối được máy in !", eImage.Warning);
        //    return;
        //  }
        //  else if (status == EnumStatusConnect.PaperOut)
        //  {
        //    new FrmInformation().ShowMessage("Máy in hết giấy !", eImage.Warning);
        //    return;
        //  }
        //  else if (status == EnumStatusConnect.Pause)
        //  {
        //    new FrmInformation().ShowMessage("Máy in đang ở trạng thái PAUSE !", eImage.Warning);
        //    return;
        //  }
        //  else if (status == EnumStatusConnect.OverTemperature)
        //  {
        //    new FrmInformation().ShowMessage("Nhiệt độ máy in đang cao !", eImage.Warning);
        //    return;
        //  }
        //  else if (status == EnumStatusConnect.UnderTemperature)
        //  {
        //    new FrmInformation().ShowMessage("Nhiệt độ máy in đang thấp !", eImage.Warning);
        //    return;
        //  }
        //}

        if (AppCore.Ins._machineCurrent == null || AppCore.Ins._machineCurrent.Id <= 0)
        {
          new FrmInformation().ShowMessage("Chưa cài đặt thông tin trạm cân !", eImage.Warning);
          return;
        }

        if (AppCore.Ins._dataManager.DataLogPrintLabel?.Employee == null || AppCore.Ins._dataManager.DataLogPrintLabel?.Employee.Id <= 0)
        {
          new FrmInformation().ShowMessage("Chưa tìm thấy thông tin nhân viên !", eImage.Warning);
          return;
        }

        if ((float)(AppCore.Ins._dataManager.DataLogPrintLabel?.Net ?? 0.0) <= 0)
        {
          new FrmInformation().ShowMessage("Giá trị cân nhỏ hơn hoặc bằng 0", eImage.Warning);
          return;
        }

        if (AppCore.Ins._dataManager.DataLogPrintLabel?.TypeTare == EnumTypeTare.None)
        {
          new FrmInformation().ShowMessage("Vui lòng chọn Tare hay không Tare trước khi cân !", eImage.Warning);
          return;
        }


        bool isDefect = (AppCore.Ins._dataManager.DataLogPrintLabel?.EnumMaterialType == EnumMaterialType.MRsDefect);
        _record = new DatalogWeight();
        _record.Net = (float)(AppCore.Ins._dataManager.DataLogPrintLabel?.Net ?? 0);
        _record.Tare = (float)(AppCore.Ins._dataManager.DataLogPrintLabel?.Tare ?? 0);
        _record.InternalExternalStatus = AppCore.Ins._dataManager.EnumInternalExternalStatus;
        _record.eExportImport = AppCore.Ins._dataManager.EnumExportImport;
        _record.eTypeRecord = isDefect ? eTypeRecord.Defective : eTypeRecord.Normal;
        _record.WasteFlag = isDefect;
        _record.EnumCheckData = EnumCheckData.UnCheck;

        if (AppCore.Ins._dataManager.DataLogPrintLabel?.Employee != null)
          _record.EmployeeId = AppCore.Ins._dataManager.DataLogPrintLabel?.Employee?.Id ?? 0;

        if (AppCore.Ins._machineCurrent.Id > 0)
          _record.MachineId = AppCore.Ins._machineCurrent.Id;

        if (AppCore.Ins._dataManager?.ProductionOrder != null)
          _record.ProductionOrderId = AppCore.Ins._dataManager?.ProductionOrder?.Id ?? 0;

        if (AppCore.Ins._dataManager?.DataLogPrintLabel?.Material != null)
          _record.MaterialId = AppCore.Ins._dataManager?.DataLogPrintLabel?.Material?.Id;

        if (AppCore.Ins._dataManager?.DataLogPrintLabel?.MaterialDefect != null)
          _record.MaterialDefectId = AppCore.Ins._dataManager?.DataLogPrintLabel?.MaterialDefect?.Id;

        if (AppCore.Ins._dataManager?.DataLogPrintLabel?.MaterialForTare != null)
        {
          _record.MaterialTareId = AppCore.Ins._dataManager?.DataLogPrintLabel?.MaterialForTare?.Id;
        }

        _record.CreatedAt = DateTime.Now;
        await FrmLoadingPrinting_OnSendPrintSuccess(EnumStatusConnect.Sucess);

        //if (AppCore.Ins._isPrinterLabel == true)
        //{
        //  int numberCopy = AppCore.Ins._appConfig.NumberLabelWeight ?? 0;
        //  if (numberCopy > 0)
        //  {
        //    PopupPrinter(numberCopy);
        //  }
        //  else
        //  {
        //    new FrmInformation().ShowMessage("Không tìm thấy thông tin số phiếu để in !", eImage.Information);
        //  }
        //}
        //else
        //{
        //  FrmLoadingPrinting_OnSendPrintSuccess(EnumStatusConnect.Sucess);
        //}    
      }
      catch (Exception ex)
      {
        new FrmInformation().ShowMessage("Lưu dữ liệu thất bại !", eImage.Warning);

        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
      finally
      {
        LockBtn(false);
      }
    }

    private void PopupPrinter(int numberCopy)
    {
      try
      {
        var inforDataMR = AppCore.Ins.ProcessingDataForDirectItem(AppCore.Ins._dataManager?.DataLogPrintLabel);
        string titleLabel = string.Empty;
        if (AppCore.Ins._dataManager?.EnumInternalExternalStatus == EnumInternalExternalStatus.Internal)
        {
          titleLabel = AppCore.Ins._dataManager?.EnumExportImport == EnumExportImport.Export ? "THÔNG TIN NHẬN HÀNG" : "THÔNG TIN TRẢ HÀNG";
        }
        else if (AppCore.Ins._dataManager?.EnumInternalExternalStatus == EnumInternalExternalStatus.External)
        {
          titleLabel = AppCore.Ins._dataManager?.EnumExportImport == EnumExportImport.Export ? "THÔNG TIN NHẬP HÀNG" : "THÔNG TIN XUẤT HÀNG";
        }

        string titleLabelInternalExternal = AppCore.Ins._dataManager?.EnumInternalExternalStatus == EnumInternalExternalStatus.Internal ? "(Nội vi)" : "(Ngoại vi)";
        InforPrinter inforPrinter = new InforPrinter();
        inforPrinter.TitleLabel = titleLabel;
        inforPrinter.InternalExternal = titleLabelInternalExternal;
        inforPrinter.ProductionOrder = AppCore.Ins._dataManager?.ProductionOrder?.Name ?? "Yêu cầu khác";
        inforPrinter.Operator = AppCore.Ins._dataManager?.DataLogPrintLabel?.Employee?.FullName ?? "";
        inforPrinter.Department = AppCore.Ins._dataManager?.DataLogPrintLabel?.Employee?.Departments?.FirstOrDefault()?.Name ?? "";
        inforPrinter.Tare = AppCore.Ins._dataManager?.DataLogPrintLabel?.Tare ?? 0;
        inforPrinter.Net = AppCore.Ins._dataManager?.DataLogPrintLabel?.Net ?? 0;
        inforPrinter.Datetime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        inforPrinter.NameMR = inforDataMR.Name;
        inforPrinter.CodeMR = inforDataMR.Code;
        inforPrinter.IsDefect = ((AppCore.Ins._dataManager?.DataLogPrintLabel?.Material?.MaterialType ?? 0) == (int)EnumMaterialType.MRsDefect);
        inforPrinter.NumberCopy = numberCopy;
        inforPrinter.TareName = GetDescriptionTare(AppCore.Ins._dataManager?.DataLogPrintLabel?.MaterialForTare);

        //FrmLoadingPrinting frmLoadingPrinting = new FrmLoadingPrinting(inforPrinter);
        //frmLoadingPrinting.OnSendPrintSuccess += FrmLoadingPrinting_OnSendPrintSuccess;
        //frmLoadingPrinting.ShowDialog();
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private string GetDescriptionTare(Material? material)
    {
      if (material == null) return "Không Tare";
      return $"{material?.Name} {material?.Grade}";
    }

    private async Task FrmLoadingPrinting_OnSendPrintSuccess(EnumStatusConnect status)
    {
      if (status == EnumStatusConnect.Sucess)
      {
        await AppCore.Ins.AddRecordAsync(_record);

        AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.Waiting;
        AppCore.Ins.EndOfWeighingCycle();
        FrmMain.Instance.ChangePage(AppModulSupport.Waiting);
      }
      else if (status == EnumStatusConnect.Disconnect)
      {
        new FrmInformation().ShowMessage("Không tìm thấy kết nối máy in !", eImage.Warning);
        return;
      }
      else if (status == EnumStatusConnect.PaperOut)
      {
        new FrmInformation().ShowMessage("Máy in hết giấy !", eImage.Warning);
        return;
      }
      else if (status == EnumStatusConnect.Pause)
      {
        new FrmInformation().ShowMessage("Máy in đang ở trạng thái PAUSE !", eImage.Warning);
        return;
      }
      else if (status == EnumStatusConnect.OverTemperature)
      {
        new FrmInformation().ShowMessage("Nhiệt độ máy in đang cao !", eImage.Warning);
        return;
      }
      else if (status == EnumStatusConnect.UnderTemperature)
      {
        new FrmInformation().ShowMessage("Nhiệt độ máy in đang thấp !", eImage.Warning);
        return;
      }
    }

    private void btnNoneTare_Click(object sender, EventArgs e)
    {
      AppCore.Ins._dataManager.DataLogPrintLabel.TypeTare = EnumTypeTare.NoneTare;
      AppCore.Ins._dataManager.DataLogPrintLabel.MaterialForTare = null;
      StatusModeTare(AppCore.Ins._dataManager.DataLogPrintLabel.TypeTare);
    }

    private void btnChageTare_Click(object sender, EventArgs e)
    {
      var listTares = AppCore.Ins._materialTares;

      if (listTares == null || listTares?.Count() <= 0)
      {
        new FrmInformation().ShowMessage("Không có danh sách Tare !", eImage.Information);
        return;
      }

      FrmChangeTare frmChangeTare = new FrmChangeTare(listTares);
      frmChangeTare.Size = new Size(1900, 900);
      frmChangeTare.StartPosition = FormStartPosition.Manual;
      var screen = Screen.PrimaryScreen.WorkingArea;
      int x = (screen.Width - frmChangeTare.Width) / 2;
      int y = 130;
      frmChangeTare.Location = new Point(x, y);
      frmChangeTare.OnSendOKClicked += FrmChangeTare_OnSendOKClicked;
      frmChangeTare.ShowDialog();
    }

    private void FrmChangeTare_OnSendOKClicked(object? sender, Material e)
    {
      AppCore.Ins._dataManager.DataLogPrintLabel.TypeTare = EnumTypeTare.Tare;
      AppCore.Ins._dataManager.DataLogPrintLabel.MaterialForTare = e;
      StatusModeTare(AppCore.Ins._dataManager.DataLogPrintLabel.TypeTare);
    }

    private void StatusModeTare(EnumTypeTare eTypeTare)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          StatusModeTare(eTypeTare);
        }));
        return;
      }

      switch (eTypeTare)
      {
        case EnumTypeTare.None:
          btnNoneTare.BackColor = Color.Gray;
          btnTareManual.BackColor = Color.Gray;
          btnCofirmPrint.BackColor = Color.Gray;
          btnCofirmPrint.Enabled = false;
          break;
        case EnumTypeTare.Tare:
          btnNoneTare.BackColor = Color.Gray;
          btnTareManual.BackColor = Color.FromArgb(49, 68, 108);
          lbNameTare.Text = GetDescriptionTare(AppCore.Ins._dataManager?.DataLogPrintLabel?.MaterialForTare);
          btnCofirmPrint.BackColor = Color.FromArgb(64, 175, 101);
          btnCofirmPrint.Enabled = true;
          break;
        case EnumTypeTare.NoneTare:
          btnNoneTare.BackColor = Color.FromArgb(49, 68, 108);
          btnTareManual.BackColor = Color.Gray;
          lbNameTare.Text = "Không tare";
          btnCofirmPrint.BackColor = Color.FromArgb(64, 175, 101);
          btnCofirmPrint.Enabled = true;
          break;
      }

    }

    private void LockBtn(bool lockBtn)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LockBtn(lockBtn);
        }));
        return;
      }

      this.btnCofirmPrint.Enabled = !lockBtn;
    }

  }
}
