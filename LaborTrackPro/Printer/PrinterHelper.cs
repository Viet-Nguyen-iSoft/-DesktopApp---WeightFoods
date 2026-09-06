using iSoft.Database.DTO;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using Path = System.IO.Path;

namespace LaborTrackPro.Printer
{
  public class PrinterHelper
  {
    [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
    public static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

    [DllImport("winspool.Drv", EntryPoint = "ClosePrinter")]
    public static extern bool ClosePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true)]
    public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] ref DOCINFOA di);

    [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter")]
    public static extern bool EndDocPrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter")]
    public static extern bool StartPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter")]
    public static extern bool EndPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true)]
    public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DOCINFOA
    {
      [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
      [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
      [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
    }

    /// <summary>
    /// Hàm dùng để gửi lệnh in cho máy in Zebra
    /// </summary>
    /// <param name="printerName"></param>
    /// <param name="zplCommand"></param>
    /// <returns></returns>
    public static bool SendStringToPrinter(string printerName, string zplCommand)
    {
      IntPtr hPrinter;
      DOCINFOA di = new DOCINFOA
      {
        pDocName = "Zebra Print Job",
        pDataType = "RAW"
      };

      if (OpenPrinter(printerName.Normalize(), out hPrinter, IntPtr.Zero))
      {
        if (StartDocPrinter(hPrinter, 1, ref di))
        {
          StartPagePrinter(hPrinter);
          IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(zplCommand);
          WritePrinter(hPrinter, pBytes, zplCommand.Length, out _);
          Marshal.FreeCoTaskMem(pBytes);
          EndPagePrinter(hPrinter);
          EndDocPrinter(hPrinter);
        }
        ClosePrinter(hPrinter);
        return true;
      }
      return false;
    }


    /// <summary>
    /// Hàm dùng để tạo nhiều file html theo phòng ban
    /// </summary>
    /// <param name="templatePath"></param>
    /// <param name="outputFolder"></param>
    /// <param name="informationDelivery"></param>
    /// <param name="contents"></param>
    /// 

    private static string BreakLineByLength(string? text, int length = 20)
    {
      if (string.IsNullOrEmpty(text))
        return string.Empty;

      return string.Join(
          "<br/>",
          Enumerable.Range(0, (text.Length + length - 1) / length)
              .Select(i => text.Substring(
                  i * length,
                  Math.Min(length, text.Length - i * length)))
      );
    }

   

    /// <summary>
    /// In một file qua tên máy in cụ thể.
    /// </summary>
    /// <param name="filePath">Đường dẫn đầy đủ tới file cần in.</param>
    /// <param name="printerName">Tên máy in (ví dụ: "Microsoft Print to PDF").</param>
    public static void PrintFile(string filePath, string printerName)
    {
      if (!File.Exists(filePath))
      {
        Console.WriteLine("❌ Không tìm thấy file cần in.");
        return;
      }

      try
      {
        ProcessStartInfo psi = new ProcessStartInfo
        {
          FileName = filePath,
          Verb = "PrintTo",
          Arguments = $"\"{printerName}\"",
          CreateNoWindow = true,
          WindowStyle = ProcessWindowStyle.Hidden
        };

        using (Process p = new Process())
        {
          p.StartInfo = psi;
          p.Start();
          p.WaitForExit(10000); // đợi tối đa 10 giây
        }

        Console.WriteLine($"✅ Đã gửi lệnh in tới máy in: {printerName}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"⚠️ Lỗi khi in: {ex.Message}");
      }
    }



    public static void PrinterLabel(string printer, DTOPrintLabel dTOPrintLabel)
    {
      try
      {
        Brush brush = Brushes.Black;
        Font fontTitlePhieuCan = new Font("Arial", 20, FontStyle.Bold);

        Font fontTitle = new Font("Arial", 12, FontStyle.Regular);
        Font fontData = new Font("Arial", 12, FontStyle.Bold);
        Font fontDataMR = new Font("Arial", 10, FontStyle.Bold);
        Font fontDataLittle = new Font("Arial", 10, FontStyle.Bold);


        // 30–60: rất mờ | 80–120: mờ vừa
        Brush watermarkBrush = new SolidBrush(Color.FromArgb(80, Color.Black));
        Font watermarkFont = new Font("Arial", 40, FontStyle.Bold);

        PrintDocument pd = new PrintDocument();
        pd.PrinterSettings.PrinterName = printer;
        pd.DefaultPageSettings.PaperSize = new PaperSize("Label80x100", 315, 394);
        //pd.DefaultPageSettings.PaperSize = new PaperSize("Label80x100", 415, 394);
        pd.DefaultPageSettings.Margins = new Margins(30, 0, 0, 0);

        int startY = 60;
        int startX = 60;
        int offset_Y = 30;

        startX = 10;

        pd.PrintPage += (sender, e) =>
        {
          e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
          e.Graphics.TranslateTransform(-e.PageSettings.HardMarginX, -e.PageSettings.HardMarginY);
          // ===== WATERMARK MỜ =====
          if (dTOPrintLabel.IsDefect)
          {
            e.Graphics.TranslateTransform(60, 220);
            e.Graphics.RotateTransform(-40);

            e.Graphics.DrawString(
                "PHE PHAM",
                watermarkFont,
                watermarkBrush,
                0,
                0
            );

            e.Graphics.ResetTransform();
          }

          e.Graphics.DrawString("PHIẾU CÂN", fontTitlePhieuCan, brush, new PointF(80, 15));

          int k = 0;

          e.Graphics.DrawString("Lệnh sản xuất:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y))); k++;
          e.Graphics.DrawString(dTOPrintLabel.PoName, fontDataLittle, brush, new PointF(startX, startY - 5 + (k * offset_Y))); k++;

          e.Graphics.DrawString(dTOPrintLabel.Material, fontDataMR, brush, new PointF(startX, startY + (k * offset_Y))); k++;

          e.Graphics.DrawString("Mã nguyên liệu:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y)));
          e.Graphics.DrawString(dTOPrintLabel.CodeMaterial, fontData, brush, new PointF(startX + 120, startY + (k * offset_Y))); k++;

          e.Graphics.DrawString("Net:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y)));
          e.Graphics.DrawString(dTOPrintLabel.Net, fontData, brush, new PointF(startX + 90, startY + (k * offset_Y))); k++;

          e.Graphics.DrawString("Ngày:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y)));
          e.Graphics.DrawString(dTOPrintLabel.Date, fontData, brush, new PointF(startX + 90, startY + (k * offset_Y))); k++;

          e.Graphics.DrawString("Người cân:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y)));
          e.Graphics.DrawString(dTOPrintLabel.OpName, fontData, brush, new PointF(startX + 90, startY + (k * offset_Y))); k++;

          e.Graphics.DrawString("Phòng ban:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y)));
          e.Graphics.DrawString(dTOPrintLabel.Department, fontData, brush, new PointF(startX + 90, startY + (k * offset_Y))); k++;
        };

        pd.Print();
      }
      catch (Exception)
      {
        throw;
      }
    }


  }

  public class DTOPrintLabel
  {
    public string? TitleLabel { get; set; }
    public string? PoName { get; set; }
    public string? Material { get; set; }
    public string? CodeMaterial { get; set; }
    public string? Net { get; set; }
    public string? Date { get; set; }
    public string? OpName { get; set; }
    public string? Department { get; set; }
    public string? TareName { get; set; }

    public bool IsDefect { get; set; } = false;
    public string? InternalExternal { get; set; }

  }
}
