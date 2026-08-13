using KeysStrokerLib;
using KeysStrokerLib.Entities;
using KeysStrokerLib.Entities.CallbackObjects;
using KeysStrokerLib.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace iSoft.Communication.USB
{
  public class Keystroker : KeystrokeAPI
  {
    private string _currentWindown = "[Unknow]";
    private Timer _timerClearBuffer;
    private bool _isRunning;
    private string _bufffer = String.Empty;
    private TimeSpan _flushTimeOut = TimeSpan.FromMilliseconds(40);
    private Stopwatch _stopWatch;
    private List<string> _fillByWindownName;
    private TimeSpan _clearBufferPeriodTime = TimeSpan.FromMilliseconds(150);

    private DateTime _lastFushCharAdded;



    // <summary>
    /// FlushInterval là một Queue được khởi tạo với kích thước tối đa là 100. 
    /// Nó được sử dụng để lưu trữ danh sách các khoảng thời gian giữa các lần nhận dữ liệu gần đây. 
    /// Mỗi khi có dữ liệu được nhận, một khoảng thời gian mới sẽ được thêm vào cuối hàng đợi. 
    /// Khi hàng đợi đã đầy, phần tử ở đầu hàng đợi sẽ bị loại bỏ để tạo chỗ cho phần tử mới.
    /// </summary>
    public Queue<TimeSpan> FlushInterval { get; private set; } = new Queue<TimeSpan>(100);
    public double FlushIntervalInMs
    {
      get => AvgFlushInterval.TotalMilliseconds;
    }


    public TimeSpan AvgFlushInterval
    {
      get
      {
        return FlushInterval.Count > 0 ? new TimeSpan((long)FlushInterval.Average(x => x.Ticks)) : new TimeSpan(0);
      }
    }

    public event EventHandler<KeyStrokerEventArgs> OnFlushKeysInputEvent;

    public List<string> FillByWindownName { get => _fillByWindownName; set => _fillByWindownName = value; }
    public bool IsRunning { get => _isRunning; set => _isRunning = value; }
    public TimeSpan FlushTimeOut { get => _flushTimeOut; set => _flushTimeOut = value; }
    public TimeSpan ClearBufferPeriodTime { get => _clearBufferPeriodTime; set => _clearBufferPeriodTime = value; }


    public KeyCode EndKeyCodes { get; set; } = (KeyCode.Enter | KeyCode.Tab) | KeyCode.Return;

    public Keystroker(List<string> fillByWindownName) : this()
    {
      _fillByWindownName = fillByWindownName;
    }

    public Keystroker()
    {
      _stopWatch = new Stopwatch();

      _timerClearBuffer = new Timer(_timerClearBuffer_CallBack, null, Timeout.Infinite, Timeout.Infinite);
      //_timerClearBuffer.Elapsed += TimerClearBuffer_Elapsed;
    }

    private void _timerClearBuffer_CallBack(object state)
    {
      if (_stopWatch.Elapsed > _flushTimeOut)
      {
        if (_bufffer?.Length >= 1)
        {
          //call event
          //OnFlushKeysInputEvent?.Invoke(this, KeyStrokerEventArgs.New(_bufffer, _currentWindown));
          _bufffer = String.Empty;
        }
      }
    }


    public void Start()
    {
      this.CreateKeyboardHook(keyPressed);

      _isRunning = true;
      _timerClearBuffer.Change(TimeSpan.Zero, _clearBufferPeriodTime);
      //_timerClearBuffer.Start();
    }

    public void Stop()
    {
      base.Close();
      _isRunning = false;
      _timerClearBuffer.Change(Timeout.Infinite, Timeout.Infinite);
      //_timerClearBuffer.Stop();
    }

    private async void keyPressed(KeyPressed _char)
    {
      if (_isRunning == false) return;

      if (checkFillWinDownNames(_char.CurrentWindow) == false) return;

      if (
        ((_char.KeyCode & EndKeyCodes) == _char.KeyCode)
        && _bufffer?.Length > 1)
      {
        //call event
        if (_currentWindown != _char.CurrentWindow)
          this._currentWindown = _char.CurrentWindow;
        if (_bufffer == string.Empty) return;

        await Task.Run(() => OnFlushKeysInputEvent?.Invoke(this, KeyStrokerEventArgs.New(_bufffer, _currentWindown)));
        _bufffer = string.Empty;
      }

      if (!string.IsNullOrEmpty(_bufffer) && _stopWatch.Elapsed > _flushTimeOut)
      {
        _bufffer = string.Empty;
      }
      else
      {
        addToBuffer(_char);
      }
      _stopWatch.Restart();
    }

    private bool checkFillWinDownNames(string windownName)
    {
      if (this._fillByWindownName?.Count <= 0)
        return true;
      else if (this._fillByWindownName?.Count >= 0)
      {
        foreach (var item in _fillByWindownName)
        {
          if (windownName.Contains(item))
            return true;
          else
            return false;
        }
      }
      return true;
    }

    private void addToBuffer(KeyPressed _char)
    {
      if ((int)_char.KeyCode >= 48 && (int)_char.KeyCode <= 90)
      {
        if (string.IsNullOrEmpty(_bufffer)) //  flush just start
        {
          // do nothing
        }
        else
        {
          // add to FlushInterval
          FlushInterval.Enqueue(_stopWatch.Elapsed);
          if (FlushInterval.Count > 100)
            FlushInterval.Dequeue();
        }

        _bufffer += _char.ToString();

        _lastFushCharAdded = DateTime.Now;
      }
    }
  }
}
