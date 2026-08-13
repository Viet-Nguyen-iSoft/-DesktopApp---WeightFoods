using LaborTrackPro.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using PdfSharp.Pdf.IO;
using System;
using System.Text;

namespace LaborTrackPro.Controls
{
  public partial class AppCore
  {
    private void StartShowUI()
    {
      //Application.Run(FrmMain.Instance);
      Application.Run(FrmTestRFID.Instance);
    }


    public async Task ShowHtmlFilesInIframesSafely(WebView2 webView21, List<string> htmlFiles, int height)
    {
      try
      {
        // 1. khởi tạo WebView2 nếu cần
        await webView21.EnsureCoreWebView2Async();

        // 2. chuẩn hóa và chỉ lấy file tồn tại
        var existing = htmlFiles.Where(f => File.Exists(f)).ToList();
        if (!existing.Any())
        {
          MessageBox.Show("Không tìm thấy file HTML hợp lệ.");
          return;
        }

        // 3. tạo file wrapper tạm
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("<!doctype html><html><head><meta charset='utf-8'><title>Wrapper</title>");
        sb.AppendLine("<style>iframe{border:1px solid #ccc; width:100%; height:960px; margin-bottom:10px;}</style>");
        sb.AppendLine("</head><body>");

        foreach (var f in existing)
        {
          var uri = new Uri(f).AbsoluteUri; // bắt buộc dùng AbsoluteUri
          //sb.AppendLine($"<iframe src=\"{uri}\"></iframe>");
        //  await WaitNavigationCompleted(webView21);

        //  var height = await webView21.ExecuteScriptAsync(@"
        //Math.max(
        //    document.body.scrollHeight,
        //    document.documentElement.scrollHeight
        //)");

          sb.AppendLine($"<iframe src=\"{uri}\" scrolling=\"no\" style=\"border:none;width:100%;height:{height}px;overflow:hidden;\"></iframe>"); //960
        }

        sb.AppendLine("</body></html>");

        // 4. lưu file tạm vào temp folder
        string temp = Path.Combine(Path.GetTempPath(), "webview_wrapper_" + Guid.NewGuid().ToString("N") + ".html");
        File.WriteAllText(temp, sb.ToString(), System.Text.Encoding.UTF8);

        // 5. load file tạm
        webView21.CoreWebView2.Navigate(new Uri(temp).AbsoluteUri);
      }
      catch (Exception)
      {
        throw;
      }
    }


    public async Task ExportHtmlToPdfAsync(WebView2 webView, string htmlPath, string outputPdfPath)
    {
      try
      {
        if (!File.Exists(htmlPath))
        {
          throw new Exception("Không tìm thấy file HTML cần in.");
        }

        await webView.EnsureCoreWebView2Async();

        var tcs = new TaskCompletionSource<bool>();

        // Sự kiện khi load xong HTML
        void OnNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
          if (e.IsSuccess)
            tcs.TrySetResult(true);
          else
            tcs.TrySetException(new Exception("Không tải được HTML"));
        }

        webView.CoreWebView2.NavigationCompleted += OnNavigationCompleted;

        // Load HTML
        webView.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);

        await tcs.Task;

        webView.CoreWebView2.NavigationCompleted -= OnNavigationCompleted;


        // ✨ Chèn CSS để xóa khoảng trắng dư
        string cleanCss = @"
                          const style = document.createElement('style');
                          style.innerHTML = `
                              html, body {
                                  margin: 0 !important;
                                  padding: 0 !important;
                                  background: white;
                                  height: auto !important;
                              }
                              * {
                                  box-sizing: border-box;
                              }
                              @page {
                                  margin: 0;
                              }
                          `;
                          document.head.appendChild(style);

                          // Cắt bỏ khoảng trắng cuối
                          const body = document.body;
                          const html = document.documentElement;
                          const height = Math.max(body.scrollHeight, body.offsetHeight, html.clientHeight, html.scrollHeight, html.offsetHeight);
                          html.style.height = height + 'px';
                          body.style.height = height + 'px';
                          window.scrollTo(0, 0);
                      ";
        await webView.CoreWebView2.ExecuteScriptAsync(cleanCss);

        // ✨ Tạo thiết lập in PDF (giữ đúng tỉ lệ, bỏ margin)
        var settings = webView.CoreWebView2.Environment.CreatePrintSettings();
        settings.MarginTop = 0;
        settings.MarginBottom = 0;
        settings.MarginLeft = 0;
        settings.MarginRight = 0;
        settings.Orientation = CoreWebView2PrintOrientation.Portrait;
        settings.ScaleFactor = 1.0;

        // Xuất PDF
        await webView.CoreWebView2.PrintToPdfAsync(outputPdfPath, settings);

        //Modify
        using var pdf = PdfReader.Open(outputPdfPath, PdfDocumentOpenMode.Modify);
        var lastPage = pdf.Pages[pdf.Pages.Count - 1];

        // Nếu trang gần như trắng, xóa
        if (pdf.Pages.Count >= 2)
          pdf.Pages.RemoveAt(pdf.Pages.Count - 1);

        pdf.Save(outputPdfPath);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
