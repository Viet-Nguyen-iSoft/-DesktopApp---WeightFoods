using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace LaborTrackPro.Service
{
  public class IdleMonitor
  {
    private readonly Timer _timer;
    private DateTime _lastAction;

    public int TimeoutMinutes { get; set; } = 5;

    public event Action? Timeout;

    public IdleMonitor()
    {
      _lastAction = DateTime.Now;

      _timer = new Timer();
      _timer.Interval = 1000; // kiểm tra mỗi giây
      _timer.Tick += Timer_Tick;
    }

    public void Start()
    {
      _lastAction = DateTime.Now;
      _timer.Start();
    }

    public void Stop()
    {
      _timer.Stop();
    }

    public void Reset()
    {
      _lastAction = DateTime.Now;
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
      if ((DateTime.Now - _lastAction).TotalMinutes >= TimeoutMinutes)
      {
        _lastAction = DateTime.Now;
        Timeout?.Invoke();
      }
    }
  }
}
