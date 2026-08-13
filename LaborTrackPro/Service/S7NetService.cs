using HelperManager;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using PlcSiemens = S7.Net.Plc;

namespace LaborTrackPro.Service
{
  public class S7NetService
  {
    public delegate void ReadDataDone(object obj);
    public event ReadDataDone? OnReadDataDone;

    public delegate void StatusConnect(long connectionId, bool IsConnect);
    public event StatusConnect? OnStatusConnect;

    private PlcSiemens? _clientPlcSiemens { get; set; }
    private string? IP { get; set; }
    private int Port { get; set; }
    private int TimeoutPing { get; set; } = 500;
    private int TimeoutConnect { get; set; } = 500;
    private System.Timers.Timer _timerCheckConnectPlc = new System.Timers.Timer();
    private System.Timers.Timer _timerWriteDataPlc = new System.Timers.Timer();
    private int _numberDB = 1;
    private readonly object _plcLock = new object();
    private bool PingIP
    {
      get
      {
        Ping ping = new Ping();
        PingReply FindPLC = ping.Send(IP, TimeoutPing);
        return FindPLC.Status.ToString().Equals("Success");
      }
    }
    public void Connect(string ip, int timeOutPingIp, int timeOutConnect, int numberDB)
    {
      try
      {
        IP = ip;
        TimeoutPing = timeOutPingIp;
        TimeoutConnect = timeOutConnect;
        _numberDB = numberDB;

        if (PingIP)
        {
          _clientPlcSiemens = new S7.Net.Plc(CpuType.S71200, ip, 0, 1);
          _clientPlcSiemens.Open();
        }
      }
      catch (Exception)
      {
        throw;
      }
      finally
      {
        _timerCheckConnectPlc.Interval = TimeoutConnect > 1000 ? TimeoutConnect : 1000;
        _timerCheckConnectPlc.Elapsed += _timerCheckConnectPlc_Elapsed;
        _timerCheckConnectPlc.Start();

        _timerWriteDataPlc.Interval = 1000;
        _timerWriteDataPlc.Elapsed += _timerWriteDataPlc_Elapsed;
        _timerWriteDataPlc.Start();
      }
    }

    private void _timerWriteDataPlc_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      if (_timerWriteDataPlc == null) return;
      lock (_plcLock)
      {
        try
        {
          if (_clientPlcSiemens?.IsConnected==true)
          {
            WriteSoftwareOpen();
          }
        }
        catch (Exception ex)
        {

        }
        finally
        {
          if (_timerWriteDataPlc != null && !_timerWriteDataPlc.Enabled)
          {
            try { _timerWriteDataPlc.Start(); } catch (ObjectDisposedException) { }
          }
        }
      }
    }

    public void DisConnect()
    {
      _timerCheckConnectPlc.Elapsed -= _timerCheckConnectPlc_Elapsed;
      _timerCheckConnectPlc.Stop();
      _timerCheckConnectPlc.Dispose();

      _clientPlcSiemens?.Close();
    }

    public bool IsConnected
    {
      get
      {
        return _clientPlcSiemens?.IsConnected ?? false;
      }
    }
   


    private void _timerCheckConnectPlc_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      if (_timerCheckConnectPlc == null) return;
      lock (_plcLock)
      {
        try
        {
          if (_clientPlcSiemens == null || !_clientPlcSiemens.IsConnected)
          {
            if (PingIP)
            {
              _clientPlcSiemens?.Close();
              _clientPlcSiemens = new Plc(CpuType.S71200, IP, 0, 1);
              _clientPlcSiemens.Open();
            }
          }
        }
        catch (Exception)
        {

        }
        finally
        {
          if (_timerCheckConnectPlc != null && !_timerCheckConnectPlc.Enabled)
          {
            try { _timerCheckConnectPlc.Start(); } catch (ObjectDisposedException) { }
          }
        }
      }
    }


    public void WriteSoftwareOpen()
    {
      lock (_plcLock)
      {
        try
        {
          if (_clientPlcSiemens?.IsConnected ?? false)
          {
            WritePlcInt16(_numberDB, 12, (Int16)1);
          }
        }
        catch (Exception)
        {
          throw;
        }
      }
    }



    public void WritePlc(int DbNumber, int adressPLC, int value)
    {
      try
      {
        if (_clientPlcSiemens != null && _clientPlcSiemens.IsConnected)
        {
          _clientPlcSiemens.Write(DataType.DataBlock, DbNumber,
                                                     adressPLC, value);
        }
      }
      catch (Exception ex)
      {
        //LogHelper.LogErrorToFileLog(nameof(WritePlc), ex, Application.StartupPath + "Logs");
      }
    }

    public async Task WritePlcAsync(int DbNumber, int adressPLC, int value)
    {
      try
      {
        if (_clientPlcSiemens != null && _clientPlcSiemens.IsConnected)
        {
          await _clientPlcSiemens.WriteAsync(DataType.DataBlock, DbNumber,
                                                     adressPLC, value);
        }
      }
      catch (Exception ex)
      {
        
      }
    }

    public void WritePlc(int DbNumber, int adressPLC, byte value)
    {
      try
      {
        if (_clientPlcSiemens != null && _clientPlcSiemens.IsConnected)
        {
          _clientPlcSiemens.Write(DataType.DataBlock, DbNumber,
                                                     adressPLC, value);
        }
      }
      catch (Exception ex)
      {
        //LogHelper.LogErrorToFileLog(nameof(WritePlc), ex, Application.StartupPath + "Logs");
      }
    }

    public void WritePlcInt16(int DbNumber, int adressPLC, Int16 value)
    {
      try
      {
        if (_clientPlcSiemens != null && _clientPlcSiemens.IsConnected)
        {
          _clientPlcSiemens.Write(DataType.DataBlock, DbNumber,
                                                     adressPLC, value);
        }
      }
      catch (Exception ex)
      {
        //LogHelper.LogErrorToFileLog(nameof(WritePlcInt16), ex, Application.StartupPath + "Logs");
      }
    }

    public void WritePlcInt32( int adressPLC, Int32 value)
    {
      try
      {
        if (_clientPlcSiemens != null && _clientPlcSiemens.IsConnected)
        {
          _clientPlcSiemens.Write(DataType.DataBlock, _numberDB,
                                                     adressPLC, value);
        }
      }
      catch (Exception ex)
      {
        //LogHelper.LogErrorToFileLog(nameof(WritePlcInt16), ex, Application.StartupPath + "Logs");
      }
    }

    public void WritePlcByte(int DbNumber, int adressPLC, byte value)
    {
      try
      {
        lock (_plcLock)
        {
          if (_clientPlcSiemens != null && _clientPlcSiemens.IsConnected)
          {
            _clientPlcSiemens?.Write(
             DataType.DataBlock,
             DbNumber,
             adressPLC,
             value
         );
          }
        }
      }
      catch (Exception ex)
      {
       
      }
    }

    public async Task WritePlcAsync(int DbNumber, int adressPLC, byte value)
    {
      try
      {
        if (_clientPlcSiemens != null && _clientPlcSiemens.IsConnected)
        {
          await _clientPlcSiemens?.WriteAsync(
           DataType.DataBlock,
           DbNumber,
           adressPLC,
           value
     );
        }
      }
      catch (Exception ex)
      {

      }
    }

    public bool WritePlcV2(int DbNumber, int adressPLC, byte value)
    {
      try
      {
        lock (_plcLock)
        {
          if (_clientPlcSiemens != null && _clientPlcSiemens.IsConnected)
          {
            _clientPlcSiemens?.Write(
             DataType.DataBlock,
             DbNumber,
             adressPLC,
             value
           );
            return true;
          }
        }
        return false;
      }
      catch (Exception ex)
      {
        return false;
      }
    }


  }
}
