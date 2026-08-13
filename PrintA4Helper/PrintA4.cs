using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace PrintA4Helper
{
  public class PrintA4
  {
    public static async Task<bool> WaitPrintCompleted(
    string printerName,
    TimeSpan timeout)
    {
      var server = new LocalPrintServer();
      var queue = server.GetPrintQueue(printerName);

      DateTime start = DateTime.Now;

      // Danh sách Job trước khi in
      //queue.Refresh();
      queue.Dispose();
      queue = server.GetPrintQueue(printerName);
      var oldJobs = queue.GetPrintJobInfoCollection()
                         .Select(x => x.JobIdentifier)
                         .ToHashSet();

      PrintSystemJobInfo job = null;

      // Chờ Job mới xuất hiện
      while (DateTime.Now - start < timeout)
      {
        await Task.Delay(500);

        //queue.Refresh();
        queue.Dispose();
        queue = server.GetPrintQueue(printerName);

        job = queue.GetPrintJobInfoCollection()
                   .FirstOrDefault(x => !oldJobs.Contains(x.JobIdentifier));

        if (job != null)
          break;
      }

      if (job == null)
        return false;

      int jobId = job.JobIdentifier;

      // Theo dõi Job
      while (DateTime.Now - start < timeout)
      {
        await Task.Delay(500);

        //queue.Refresh();
        queue.Dispose();
        queue = server.GetPrintQueue(printerName);

        job = queue.GetPrintJobInfoCollection()
                   .FirstOrDefault(x => x.JobIdentifier == jobId);

        // Job biến mất => đã gửi xong tới máy in
        if (job == null)
          return true;

        if (job.IsDeleted ||
            job.IsCompleted)
          return true;

        if (job.IsOffline ||
            job.IsPaperOut ||
            job.IsBlocked ||
            job.IsInError)
          return false;
      }

      return false;
    }
  }
}
