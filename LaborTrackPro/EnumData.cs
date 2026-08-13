using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborTrackPro
{
  public class EnumData
  {
    public enum AppModulSupport
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

    public enum eScanRfid
    {
      ScanDelivery,
      ScanQC,
      PermitWeightOver,
      ScanReceiving,
    }

    public enum eImage
    {
      Confirm,
      Question,
      Warning,
      Information,
    }

    public enum eTypeSync
    {
      None,
      New,
      Update,
    }
    public enum EnumWarningStatus
    {
      Normal = 1,
      Warning,
    }
    public enum EnumApproveStatus
    {
      NotApprove = 1,
      Approved,
      Rejected,
    }

    public enum EnumTypeTare
    {
      None,
      Tare,
      NoneTare,
    }

    public enum eTagData
    {
      None,
      Net,
      Tare,
      Gross,
      ProductionOrder,
      Operator,
      Datetime,
      Department,
      ItemProduct,
    }

    public enum eActionForm
    {
      None,
      Edit,
      Add,
    }
    

    public enum EnumStepOperation
    {
      None,
      Waiting,
      ChooseMode,
      ModePO,
      TypeForPoOther,

      TypeExportImport,
      ListPO,
      TypeMRInPo,
      DetailMRs,
      DetailRMs_BTP_Defect,

      



      GroupMRsInPO,
      DetailMRsOther,
      RMsDefect,


      
      MaterialAllOther,


      AreaInternalOrExternal,
      ScanDelivery,
      ScanReceiving,
      ScanQC,
      DeliveryPlan,
      ListItemDelivery,
      ReviewDelivery,
      Print,
    }

    public enum EnumModeFunction
    {
      None,
      PrintLabel,
      PrintDelivery,
    }

    public enum eTypeDataRefresh
    {
      Material,
      Production,
      ProductionWeight,
      ProductionOrder,
      Factory,
      Machine,
      Department,
      Employee,
      SettingTare,
      Image,

    }
    



  }
}
