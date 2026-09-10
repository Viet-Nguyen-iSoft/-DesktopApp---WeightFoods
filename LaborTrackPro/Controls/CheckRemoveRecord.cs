using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborTrackPro.Controls
{
  public partial class AppCore
  {
    private CancellationTokenSource _cts;

    private async Task StartPollingRemoveRecordExpiredAsync()
    {
      try
      {
        _cts = new CancellationTokenSource();

        while (!_cts.Token.IsCancellationRequested)
        {
          await DoWorkAsync();

          await Task.Delay(60000, _cts.Token);
        }
      }
      catch (Exception)
      {

      }
    }

    private async Task DoWorkAsync()
    {
      DateTime dateTime = DateTime.UtcNow.AddHours(-AppCore.Ins._delivery_permit_hour);
      var records = await AppCore.Ins.GetDataExpire(dateTime);
      if (records?.Count()>0)
      {
        records.ForEach(x => x.DeletedFlag = true);
        records.ForEach(x => x.SyncFlag = false);
        records.ForEach(x => x.UpdatedAt = DateTime.UtcNow);
        await UpdateRecordAsync(records);
      }  
    }

    public void StopPolling()
    {
      _cts?.Cancel();
    }
  }
}
