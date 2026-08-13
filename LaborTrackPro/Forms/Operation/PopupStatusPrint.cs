using HelperManager;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using System.Drawing.Printing;

namespace LaborTrackPro.Forms.Operation
{
  public partial class PopupStatusPrint : Form
  {
    public event EventHandler<bool>? OnSendStatusPrint;

    public bool _triggerPrint = true;
    public bool _busyPrint = false;

    private string _namePrintA4 { get; set; }
    private string _pathFileName { get; set; }

    private System.Timers.Timer _timerSendStatusConnectPrint = new System.Timers.Timer();
    private List<string> _printers { get; set; }
    private DataPrint? _statusPrintA4 { get; set; }
    private DataPrint? _statusPrintA4Previous { get; set; }

    public PopupStatusPrint()
    {
      InitializeComponent();
      CustomUI();
      this.Load += PopupStatusPrint_Load;
    }

    public PopupStatusPrint(string namePrint, string pathFile) : this()
    {
      _namePrintA4 = namePrint;
      _pathFileName = pathFile;
    }

    private void CustomUI()
    {
      this.TopMost = AppCore.Ins._isTopMost;

      ElipseControl elipseControl0 = new ElipseControl();
      elipseControl0.TargetControl = tableLayoutPanel3;
      elipseControl0.CornerRadius = 20;
    }


    private void PopupStatusPrint_Load(object? sender, EventArgs e)
    {
      _timerSendStatusConnectPrint.Interval = 500;
      _timerSendStatusConnectPrint.Elapsed += _timerSendStatusConnectPrint_Elapsed;
      _timerSendStatusConnectPrint.Start();

      _printers = PrinterSettings.InstalledPrinters
                                .Cast<string>()
                                .ToList();
    }

    private void StartPrint()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          StartPrint();
        }));
        return;
      }

      try
      {
        ShowStatus("Đang in ...");
        PdfPrinter.PrintPdf(_pathFileName, _namePrintA4);
        ShowStatus("In thành công");
        OnSendStatusPrint?.Invoke(this, true);
        this.Close();
      }
      catch (Exception ex)
      {
        ShowStatus($"In thất bại: {ex.ToString()}");
      }
    }

    private void _timerSendStatusConnectPrint_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      try
      {
        _timerSendStatusConnectPrint.Stop();

        if (!_busyPrint)
        {
          bool find = _printers.Any(x => x == _namePrintA4);
          if (find)
          {
            _statusPrintA4 = PrinterUSBHelper.GetPrinterStatus(_namePrintA4);
          }
          else
          {
            DataPrint dataPrintNotFound = new DataPrint();
            dataPrintNotFound.StatusPrintA4 = StatusPrintA4.NotFound;
            dataPrintNotFound.Code = -1;

            _statusPrintA4 = dataPrintNotFound;
          }

          if (_statusPrintA4Previous != _statusPrintA4)
          {
            _statusPrintA4Previous = _statusPrintA4;
            ShowStatusPrintA4(_statusPrintA4);
          }

          if (_triggerPrint == true && _statusPrintA4.StatusPrintA4 == StatusPrintA4.Idle)
          {
            _busyPrint = true;
            StartPrint();
            _triggerPrint = false;
          }
        }  
      }
      catch (Exception ex)
      {
        //TODO
      }
      finally
      {
        _timerSendStatusConnectPrint.Start();
      }
    }

    private void ShowStatusPrintA4(DataPrint value)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowStatusPrintA4(value);
        }));
        return;
      }

      string hex = value.Code.ToString("X4");
      if (value.StatusPrintA4 == StatusPrintA4.Idle)
      {
        lbStatus.Text = $"Trạng thái máy in: [{hex}] Máy in sẵn sàng";
        lbStatus.ForeColor = Color.DarkGreen;
      }
      else if (value.StatusPrintA4 == StatusPrintA4.Printing)
      {
        lbStatus.Text = $"Trạng thái máy in: [{hex}] Máy in đang in";
        lbStatus.ForeColor = Color.DarkGreen;
      }
      else if (value.StatusPrintA4 == StatusPrintA4.Error)
      {
        lbStatus.Text = $"Trạng thái máy in:[{hex}] Máy in lỗi";
        lbStatus.ForeColor = Color.DarkGreen;
      }
      else if (value.StatusPrintA4 == StatusPrintA4.Offline)
      {
        lbStatus.Text = $"Trạng thái máy in: [{hex}] Máy in mất điện hoặc mất kết nối";
        lbStatus.ForeColor = Color.Red;
      }
      else
      {
        lbStatus.Text = $"Trạng thái máy in: [{hex}] Máy in lỗi không xác định";
        lbStatus.ForeColor = Color.Red;
      }
    }

    private void ShowStatus(string status)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowStatus(status);
        }));
        return;
      }

      label2.Text = status;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

  }
}
