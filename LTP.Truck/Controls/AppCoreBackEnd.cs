using iSoft.Database.Models;
using iSoft.Database.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static HelperManager.EnumData;

namespace LTP.Truck.Controls
{
  public partial class AppCore
  {
    #region Instance
    private static AppCore _ins = new AppCore();
    public static AppCore Ins
    {
      get
      {
        return _ins == null ? _ins = new AppCore() : _ins;
      }
    }
    #endregion

    #region Event
    //public delegate void SendDataWeight(MessageDataOutputWeight messageDataOutputWeight);
    //public event SendDataWeight? OnSendDataWeight;

    //public delegate void SendDataRfid(object? sender, MessageDataOutput e);
    //public event SendDataRfid? OnSendDataRfid;

    //public delegate void SendStatusDevice(MessageDataEvent messageDataEvent);
    //public event SendStatusDevice? OnSendStatusDevice;

    //public delegate void SendStatusConnectServer(EnumStatusConnectTcp enumStatusConnectTcp);
    //public event SendStatusConnectServer? OnSendStatusConnectServer;

    //public delegate void SendEndOfWeighingCycle();
    //public event SendEndOfWeighingCycle? OnSendEndOfWeighingCycle;

    //public delegate void SendEndOfWeighingDeliveryCycle();
    //public event SendEndOfWeighingDeliveryCycle? OnSendEndOfWeighingDeliveryCycle;

    //public event EventHandler<bool>? OnSendStatusConnectHID;
    //public event EventHandler<EnumStatusConnectTcp>? OnSendStatusConnectWeight;
    //public event EventHandler<List<Product>>? OnSendChangeTare;
    #endregion


    public readonly ClientService _clientService = new();
    public readonly TypeGoodsService _typeGoodsService = new();
    public readonly WarehouseService _warehouseService = new();
    public readonly RecordTruckService _recordTruckService = new();
    public readonly RecordWeightService _recordWeightService = new();
    public readonly CategoryTareService _categoryTareService = new();
    public readonly ProductGroupService _productGroupService = new();
    public readonly ProductService _productService = new();
    public readonly AppConfigService _appConfigService = new();
    public readonly StationService _stationService = new();
    public readonly ConnectionService _connectionService = new();
    

    public string _folderFileLog = Application.StartupPath + "Logs";
    public void Init()
    {
      try
      {
        LoadDataConfig().Wait();

        // _enableRabbit = (Environment.GetEnvironmentVariable("IS_ENABLE_RABBITMQ").ToLower() == "true");

        // _hostAPI = Environment.GetEnvironmentVariable("HOST_API");
        // _baseAPI = Environment.GetEnvironmentVariable("URL_API");
        // _apiKey = Environment.GetEnvironmentVariable("API_KEY");

        // _isPrinterLabel = (Environment.GetEnvironmentVariable("IS_PRINTER_LABEL").ToLower() == "true");
        // _delivery_permit_hour = int.Parse(Environment.GetEnvironmentVariable("HOUR_DELIVERY"));
        // _isAdmin = (Environment.GetEnvironmentVariable("IS_ADMIN").ToLower() == "true");

        // _timeout_backhome_minute = int.Parse(Environment.GetEnvironmentVariable("TIME_OUT_BACKHOME"));
        // _alarm = (Environment.GetEnvironmentVariable("ALARM").ToLower() == "true");

        if (!Directory.Exists(_folderFileLog))
          Directory.CreateDirectory(_folderFileLog);

        // _isTopMost = !_isAdmin;

        // _dataManager.DataLogPrintLabel = new DataLogPrintLabel();
        // _dataManager.DataLogDelivery = new DataLogDeliveryManager();
        //_dataManager.Machine = _machineCurrent;

        // _inforLine = _appConfig.Version + " - " + _machineCurrent?.Name ?? string.Empty;
        // _ipPrintLabel = _appConfig?.NamePrinter ?? string.Empty;

        // if (_alarm)
        // {
        //   _s7NetService = new S7NetService();
        //   _s7NetService.Connect("192.168.3.202", 1000, 500, 1);
        // }  

        StartShowUI();
      }
      catch (Exception ex)
      {
        MessageBox.Show("Lỗi khởi động chương trình !");
        Environment.Exit(1);
      }
    }

    public AppConfig? _appConfig { get;set; }
    public Station? _station { get;set; }
    public async Task LoadDataConfig()
    {
      try
      {
        _appConfig = await _appConfigService.GetAppConfigAsync();
        _station = await _stationService.GetFirstDataStation();
      }
      catch (Exception)
      {
        throw;
      }
    }

  }
}
