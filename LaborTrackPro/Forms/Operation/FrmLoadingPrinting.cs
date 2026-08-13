using HelperManager;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.Printer;
using LaborTrackPro.UserControls;
using System.Drawing.Printing;
using TestConnectPrinter;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms
{
  public partial class FrmLoadingPrinting : Form
  {
    public delegate void SendPrintSuccess(EnumStatusConnect enumStatusConnect);
    public event SendPrintSuccess? OnSendPrintSuccess;

    private InforPrinter _inforPrinter;
    private System.Timers.Timer _tmrDelayStartPrint = new System.Timers.Timer();

    private int _currentPrint = 0;
    private int _totalPrint = 0;
    private int _margin = 10;

    private int timeSleep = 1000;
    private int timeSleepCloseApp = 3000;

    private Size SizeMm;
    private Size SizePx;
    private Size SizeUc;
    private bool isOk = false;
    private bool _cancelPrint = false;

    #region Instance
    private static FrmLoadingPrinting _Instance = null;
    public static FrmLoadingPrinting Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmLoadingPrinting();
        return _Instance;
      }
    }
    #endregion

    public FrmLoadingPrinting()
    {
      InitializeComponent();
      CustomUi();
      this.Load += FrmLoadingPrinting_Load;
      this.Shown += FrmLoadingPrinting_Shown;
      this.FormClosing += FrmLoadingPrinting_FormClosing;
    }

    public FrmLoadingPrinting(InforPrinter inforPrinter) : this()
    {
      _inforPrinter = inforPrinter;
    }

    private void CustomUi()
    {
      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.CornerRadius = 5;
      elipseControl01.TargetControl = progressBar1;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.CornerRadius = 10;
      elipseControl02.TargetControl = flowLayoutPanel;

      ElipseControl elipseControl04 = new ElipseControl();
      elipseControl04.CornerRadius = 10;
      elipseControl04.TargetControl = tableLayoutPanel4;
    }

    private void FrmLoadingPrinting_Load(object? sender, EventArgs e)
    {
      isOk = true;
    }

    private void FrmLoadingPrinting_Shown(object? sender, EventArgs e)
    {
      if (!isOk) return;

      //Size
      double H = 100.0;
      double W = 80.0;
      double h = (double)((flowLayoutPanel.Height - 50) / 2.0);
      double w = h * W / H;
      SizeUc = new Size((int)w, (int)h);


      _totalPrint = _inforPrinter.NumberCopy;
      LoadListLabelPrinter(_inforPrinter, SizeUc);
      StatusNumberLabel(_currentPrint++, _totalPrint);

      _tmrDelayStartPrint.Interval = AppCore.Ins._appConfig.TimeDelayPrinter ?? 1000;
      _tmrDelayStartPrint.Elapsed += _tmrDelayStartPrint_Elapsed;
      _tmrDelayStartPrint.Start();
    }


    private void _tmrDelayStartPrint_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      try
      {
        _tmrDelayStartPrint.Stop();
        var status = StartPrinter();
        if (status == EnumStatusConnect.Sucess)
        {
          Thread.Sleep(timeSleepCloseApp);

          OnSendPrintSuccess?.Invoke(status);
          ClosePopup();
        }
        else
        {
          OnSendPrintSuccess?.Invoke(status);
          ClosePopup();
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void ClosePopup()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ClosePopup();
        }));
        return;
      }

      this.Close();
    }

    private void StatusNumberLabel(int current, int total)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          StatusNumberLabel(current, total);
        }));
        return;
      }

      lbNumberPrinted.Text = $"{current} / {total}";
      progressBar1.Value = (int)((((double)(current)) / ((double)total)) * 100);
      if (current == total)
      {
        lbStatus.Text = "Đã in xong";
        btnCancel.Text = "Thoát";
      }
    }

    private void FrmLoadingPrinting_FormClosing(object? sender, FormClosingEventArgs e)
    {
      if (_tmrDelayStartPrint != null)
      {
        _tmrDelayStartPrint.Stop();
        _tmrDelayStartPrint.Dispose();
      }
    }


    private void LoadListLabelPrinter(InforPrinter inforPrinter, Size size)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LoadListLabelPrinter(inforPrinter, size);
        }));
        return;
      }

      try
      {
        flowLayoutPanel.Controls.Clear();

        for (int i = 0; i < inforPrinter.NumberCopy; i++)
        {
          var printerCopy = new InforPrinter
          {
            TitleLabel = inforPrinter.TitleLabel,
            Net = inforPrinter.Net,
            Tare = inforPrinter.Tare,
            ProductionOrder = inforPrinter.ProductionOrder,
            Operator = inforPrinter.Operator,
            Datetime = inforPrinter.Datetime,
            Department = inforPrinter.Department,
            NameMR = inforPrinter.NameMR,
            IsDefect = inforPrinter.IsDefect,
            CodeMR = inforPrinter.CodeMR,
            TareName = inforPrinter.TareName,
            InternalExternal = inforPrinter.InternalExternal,
          };

          UcPrintLabel ucPrintLabel = new UcPrintLabel()
          {
            Margin = new Padding(_margin),
          };
          ucPrintLabel.SizeCus = size;
          ucPrintLabel.Tag = printerCopy;
          ucPrintLabel.ShowInforOnLabel(printerCopy);
          flowLayoutPanel.Controls.Add(ucPrintLabel);
        }

        this.lbNumberPrinted.Text = $"{_currentPrint}/{_totalPrint}";
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }

    }


    #region Print Draw Image

    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
    private Bitmap memoryImage;
    private PrintDocument printDoc;

    private List<Bitmap> pagesToPrint = new List<Bitmap>();
    private int currentPageIndex = 0;

    #endregion


    private EnumStatusConnect StartPrinter()
    {
      try
      {
        pagesToPrint.Clear();

        var listUc = flowLayoutPanel.Controls.OfType<UcPrintLabel>().ToList();
        for (int i = 0; i < listUc.Count; i++)
        {
          if (i > 0)
          {
            listUc[i - 1].PrintSuccess();
            StatusNumberLabel(_currentPrint++, _totalPrint);
          }
          var dataTag = listUc[i].Tag as InforPrinter;
          if (AppCore.Ins._isPrinterLabel)
          {
            DTOPrintLabel dto = new DTOPrintLabel();
            dto.TitleLabel = dataTag?.TitleLabel;
            dto.PoName = dataTag?.ProductionOrder;
            dto.Material = dataTag?.NameMR;
            dto.Net = $"{(dataTag?.Net ?? 0).ToString("F3")} kg";
            dto.Date = dataTag?.Datetime;
            dto.OpName = dataTag?.Operator;
            dto.Department = dataTag?.Department;
            dto.IsDefect = dataTag?.IsDefect ?? false;
            dto.CodeMaterial = dataTag?.CodeMR;
            dto.TareName = dataTag?.TareName;
            dto.InternalExternal = dataTag?.InternalExternal;

            //PrinterHelper.PrinterLabel(printer, dto);


            int startX = 50;
            int startY = 200;
            int offserY = 100;
            int rowIndex = 0;
            int fontH = 50;
            int fontW = 50;
            int fontInternalExternal = 400;
            if (dto.InternalExternal == "(Ngoại vi)")
            {
              fontInternalExternal = 380;
            }

            List<string> mrName = TextHelper.SplitTextByMaxLength(dto?.Material ?? string.Empty, 35);

            string zpl = "";
            if (mrName.Count() <= 1)
            {
              zpl = $@"
^XA
^MCY
^LH0,0
^LS0
^PW960
^LL1200
^CI28

^FO{startX + 60},50
^A@N,80,80,E:69296989.TTF
^FD[Title_Label]
^FS

^FO{fontInternalExternal},135
^A@N,{fontH},{fontW},E:69296989.TTF
^FD[InternalExternal]
^FS

^FO{startX},{startY + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDLệnh sản xuất:
^FS


^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FD[PO_Code]
^FS


^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FD[MaterialNameL1]
^FS

^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FD[MaterialCode]
^FS

^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDNet: [Net]
^FS

^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDNgày: [Datetime]
^FS


^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDNgười cân: [Operator]
^FS


^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDPhòng ban: [Department]
^FS

^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDTare: [TareName]
^FS

^XZ
";
            }
            else
            {
              zpl = $@"
^XA
^MCY
^LH0,0
^LS0
^PW960
^LL1200
^CI28

^FO{startX + 60},50
^A@N,80,80,E:69296989.TTF
^FD[Title_Label]
^FS

^FO{fontInternalExternal},135
^A@N,{fontH},{fontW},E:69296989.TTF
^FD[InternalExternal]
^FS

^FO{startX},{startY + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDLệnh sản xuất:
^FS


^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FD[PO_Code]
^FS


^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FD[MaterialNameL1]
^FS

^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FD[MaterialNameL2]
^FS


^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FD[MaterialCode]
^FS

^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDNet: [Net]
^FS

^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDNgày: [Datetime]
^FS


^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDNgười cân: [Operator]
^FS


^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDPhòng ban: [Department]
^FS

^FO{startX},{startY - 30 + (rowIndex++) * offserY}
^A@N,{fontH},{fontW},E:69296989.TTF
^FDTare: [TareName]
^FS

^XZ
";
            }

            if (mrName.Count() == 1)
            {
              string zplPrint = zpl.Replace("[PO_Code]", dto?.PoName)
                                    .Replace("[Title_Label]", dto?.TitleLabel)
                                    .Replace("[MaterialNameL1]", mrName[0])
                                    .Replace("[MaterialCode]", dto?.CodeMaterial)
                                    .Replace("[Net]", dto?.Net)
                                    .Replace("[Datetime]", dto?.Date)
                                    .Replace("[Operator]", dto?.OpName)
                                    .Replace("[Department]", dto?.Department)
                                    .Replace("[InternalExternal]", dto?.InternalExternal)
                                    .Replace("[TareName]", dto?.TareName);
              var rs = ZebraPrinterTcpHelper.PrintLabelWeight(AppCore.Ins._ipPrintLabel, 9100, zplPrint);
              if (rs != EnumStatusConnect.Sucess)
              {
                return rs;
              }
            }
            else if (mrName.Count() > 1)
            {
              string zplPrint = zpl.Replace("[PO_Code]", dto?.PoName)
                                    .Replace("[Title_Label]", dto?.TitleLabel)
                                    .Replace("[MaterialNameL1]", mrName[0])
                                    .Replace("[MaterialNameL2]", mrName[1])
                                    .Replace("[MaterialCode]", dto?.CodeMaterial)
                                    .Replace("[Net]", dto?.Net)
                                    .Replace("[Datetime]", dto?.Date)
                                    .Replace("[Operator]", dto?.OpName)
                                    .Replace("[Department]", dto?.Department)
                                    .Replace("[InternalExternal]", dto?.InternalExternal)
                                    .Replace("[TareName]", dto?.TareName);
              var rs = ZebraPrinterTcpHelper.PrintLabelWeight(AppCore.Ins._ipPrintLabel, 9100, zplPrint);
              if (rs != EnumStatusConnect.Sucess)
              {
                return rs;
              }
            }
          }

          Thread.Sleep(timeSleep);
        }

        if (listUc.Count() > 0)
        {
          listUc[listUc.Count() - 1].PrintSuccess();
          StatusNumberLabel(_currentPrint++, _totalPrint);
        }

        return EnumStatusConnect.Sucess;
      }
      catch (Exception)
      {
        return EnumStatusConnect.Disconnect;
      }
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

    public bool PrintPanel(UcPrintLabel ctrl, Size size, string printerName = null)
    {
      pagesToPrint.Clear();
      if (ctrl is UserControl)
      {
        using (Graphics mygraphics = ctrl.CreateGraphics())
        {
          Bitmap bmp = new Bitmap(size.Width, size.Height, mygraphics);
          using (Graphics memoryGraphics = Graphics.FromImage(bmp))
          {
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, ctrl.ClientRectangle.Width, ctrl.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
          }
          pagesToPrint.Add(bmp);
        }
      }

      if (pagesToPrint.Count == 0)
      {
        return false;
      }

      printDoc = new PrintDocument();
      printDoc.PrintPage += PrintDoc_PrintPage;
      printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
      printDoc.PrinterSettings.PrinterName = AppCore.Ins._appConfig.NamePrinter ?? string.Empty;
      printDoc.Print();

      return true;
    }

    private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
    {
      if (_cancelPrint)
      {
        e.Cancel = true;
        return;
      }

      Bitmap bmp = pagesToPrint[0];
      e.Graphics.DrawImage(bmp, 0, 0);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      _cancelPrint = true;
      this.Close();
    }

  }
}
