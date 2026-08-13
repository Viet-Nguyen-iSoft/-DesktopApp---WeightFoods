using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace HelperManager
{
  public static class PdfPrinter
  {
    /// <summary>
    /// In file PDF đến máy in chỉ định.
    /// </summary>
    /// <param name="pdfPath">Đường dẫn file PDF</param>
    /// <param name="printerName">Tên máy in</param>
    /// <param name="copies">Số bản in</param>
    /// <returns>true nếu gửi lệnh in thành công</returns>
    public static void PrintPdf(string pdfPath, string printerName)
    {
      try
      {
        Process.Start(new ProcessStartInfo
        {
          FileName = pdfPath,
          Verb = "printto",
          Arguments = $"\"{printerName}\"",
          UseShellExecute = true,
          CreateNoWindow = true
        });
      }
      catch (Exception)
      {
        throw;
      }
    }

    public static void MergePdf(List<string> pathsPdf, string pathFilePdfOut)
    {
      try
      {
        if (pathsPdf == null || pathsPdf.Count == 0)
          throw new ArgumentException("Danh sách PDF rỗng.");

        // Tạo thư mục nếu chưa có
        var dir = Path.GetDirectoryName(pathFilePdfOut);
        if (!string.IsNullOrWhiteSpace(dir))
          Directory.CreateDirectory(dir);

        using (PdfDocument outputDocument = new PdfDocument())
        {
          foreach (string pdf in pathsPdf)
          {
            if (!File.Exists(pdf))
              continue;

            using (PdfDocument inputDocument = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
            {
              for (int i = 0; i < inputDocument.PageCount; i++)
              {
                outputDocument.AddPage(inputDocument.Pages[i]);
              }
            }
          }

          outputDocument.Save(pathFilePdfOut);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }



  }
}
