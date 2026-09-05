using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP.Truck
{
  public class EnumData
  {
    public enum EnumScreen
    {
      Waiting,
      Operation,

      Home,
      MasterData,
      Employee,

      OpChooseModeFunction,
      OpTypePO,
      OpShowListPO,
      OpChooseExportImport,
      OpTypeMR,
      OpDetailMRs,
      OpRMs_BTP_Defect,

      OpTypeForPoOther,

      OperationPrint,

      Menu,
      LogInSussess,


      Setting,
      SettingDevice,
      SettingServer,
      SettingPrinter,
      SettingMachine,


      Department,
      ProductionOrder,
      Material,
      Product,


      LoadingPrintting,

      CheckUpdateVer,

      AreaInternalOrExternal,

      ScanRfid,
      ScanReceiving,
      ScanDelivery,
      //ScanQC,
      DeliveryPlan,
      ListItemDelivery,
      ReviewDelivery
    }
  }
}
