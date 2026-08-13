using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace HelperManager
{
  public class PrintQueueDevice
  {
    public string Name { get; set; } = "";
    public string DeviceId { get; set; } = "";
    public string Status { get; set; } = "";
    public string PnpClass { get; set; } = "";
  }

  public static class PrinterUSBHelper
  {
    public static List<PrintQueueDevice> GetPrintQueuesFromDeviceManager()
    {
      List<PrintQueueDevice> list = new List<PrintQueueDevice>();

      try
      {
        using (ManagementObjectSearcher searcher =
            new ManagementObjectSearcher(
                "SELECT * FROM Win32_PnPEntity WHERE PNPClass='PrintQueue'"))
        {
          foreach (ManagementObject obj in searcher.Get())
          {
            list.Add(new PrintQueueDevice
            {
              Name = obj["Name"]?.ToString() ?? "",
              DeviceId = obj["DeviceID"]?.ToString() ?? "",
              Status = obj["Status"]?.ToString() ?? "",
              PnpClass = obj["PNPClass"]?.ToString() ?? ""
            });
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      return list;
    }

    public static DataPrint GetPrinterStatus(string printerName)
    {
      ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
      foreach (ManagementObject item in managementObjectSearcher.Get())
      {
        string text = item["Name"]?.ToString();
        if (text != null && text.Trim().Equals(printerName.Trim(), StringComparison.OrdinalIgnoreCase))
        {
          DataPrint dataPrint = new DataPrint();
          dataPrint.StatusPrintA4 = StatusPrintA4.Offline;

          bool flag = (bool)item["WorkOffline"];
          ushort num = (ushort)((item["PrinterStatus"] != null) ? ((ushort)item["PrinterStatus"]) : 0);
          if (flag)
          {
            dataPrint.Code = 0;
            return dataPrint;
          }

          StatusPrintA4 statusPrintA4 = StatusPrintA4.Other;
          if (num == 3)
          {
            statusPrintA4 = StatusPrintA4.Idle;
          }
          else if (num == 4)
          {
            statusPrintA4 = StatusPrintA4.Printing;
          }
          else if (num == 7)
          {
            statusPrintA4 = StatusPrintA4.Error;
          }
          else
          {
            statusPrintA4 = StatusPrintA4.Other;
          }

          dataPrint.StatusPrintA4 = statusPrintA4;
          dataPrint.Code = num;
          return dataPrint;
        }
      }

      DataPrint dataPrintNotFound = new DataPrint();
      dataPrintNotFound.StatusPrintA4 = StatusPrintA4.NotFound;
      dataPrintNotFound.Code = 0;
      return dataPrintNotFound;
    }
  }

  public class DataPrint
  {
    public StatusPrintA4 StatusPrintA4 { get; set; }
    public int Code { get; set; }
  }

  public enum StatusPrintA4
  {
    Idle = 3,
    Printing = 4,
    Error = 7,
    Offline,
    NotFound,
    Other
  }
}
