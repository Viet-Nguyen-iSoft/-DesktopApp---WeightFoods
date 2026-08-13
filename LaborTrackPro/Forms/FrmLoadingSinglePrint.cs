using HelperManager;
using LaborTrackPro.Controls;
using System.Drawing.Printing;

namespace LaborTrackPro.Forms
{
  public partial class FrmLoadingSinglePrint : Form
  {
    public delegate void SendPrintDone();
    public event SendPrintDone OnSendPrintDone;

    private System.Timers.Timer _tmrDelayPrint = new System.Timers.Timer();
    public bool ShowUiDone = false;
    public FrmLoadingSinglePrint()
    {
      InitializeComponent();
      _tmrDelayPrint.Interval = 1000;
      _tmrDelayPrint.Elapsed += _tmrDelayPrint_Elapsed;
    }

    private void _tmrDelayPrint_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      try
      {
        _tmrDelayPrint.Stop();
        PrintScreen();
        //OnSendPrintDone?.Invoke();
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
      finally
      {
        if (this.InvokeRequired)
        {
          this.Invoke(new Action(() => this.Close()));
        }
        else
        {
          this.Close();
        }
      }

    }




    private PrintDocument printDoc;

    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
    private Bitmap memoryImage;

    private void PrintScreen()
    {
      try
      {
        Graphics mygraphics = panel1.CreateGraphics();
        Size s = panel1.Size;
        memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
        Graphics memoryGraphics = Graphics.FromImage(memoryImage);
        IntPtr dc1 = mygraphics.GetHdc();
        IntPtr dc2 = memoryGraphics.GetHdc();
        BitBlt(dc2, 0, 0, panel1.ClientRectangle.Width, panel1.ClientRectangle.Height, dc1, 0, 0, 13369376);
        mygraphics.ReleaseHdc(dc1);
        memoryGraphics.ReleaseHdc(dc2);

        printDoc = new PrintDocument();
        printDoc.PrintPage += PrintDoc_PrintPage;
        printDoc.EndPrint += PrintDoc_EndPrint;
        //printDoc.PrinterSettings.PrinterName = AppCore.Ins._appConfig.NamePrinter;
        //printDoc.QueryPageSettings += PrintDoc_QueryPageSettings;

        //printDoc.Print();
        PrintDialog printDialog = new PrintDialog();
        printDialog.Document = printDoc;
        if (printDialog.ShowDialog() == DialogResult.OK)
        {

        }
      }
      catch (Exception)
      {
      }

    }

    private void PrintDoc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
    {
      throw new NotImplementedException();
    }

    private void PrintDoc_EndPrint(object sender, PrintEventArgs e)
    {
      if (e.PrintAction == PrintAction.PrintToPrinter)
      {
        OnSendPrintDone?.Invoke();
      }

    }

    private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
    {
      if (memoryImage != null)
      {
        e.Graphics.DrawImage(memoryImage, 0, 0);
      }
    }

    private void FrmLoadingSinglePrint_Load(object sender, EventArgs e)
    {

    }

    private void FrmLoadingSinglePrint_Shown(object sender, EventArgs e)
    {
      //if (ShowUiDone)
      //{
      //  PrintScreen();
      //  this.Close();
      //}
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //PrintScreen();
      //this.Close();
    }
  }
}
